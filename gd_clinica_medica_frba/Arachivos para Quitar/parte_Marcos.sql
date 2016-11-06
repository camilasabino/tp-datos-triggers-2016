IF OBJECT_ID ('LOS_TRIGGERS.usuario_login') is not null DROP PROCEDURE LOS_TRIGGERS.usuario_login
GO	
CREATE PROC LOS_TRIGGERS.usuario_login (@user_name varchar(30), @user_password varchar(30), @rol varchar(30), @resultado int OUTPUT)
AS
BEGIN
DECLARE @intentos_fallidos numeric(1), @password varbinary(300), @num_afiliado numeric(18), @num_profesional numeric(18), @num_administrador numeric(18)

SELECT @password = user_password,@intentos_fallidos=user_intentos_fallidos_login,
--@DNI = user_dni 
@num_afiliado = user_afiliado, @num_profesional = user_profesional, @num_administrador = user_administrador
FROM LOS_TRIGGERS.Usuario where user_name = @user_name
IF (@password = HASHBYTES('SHA2_256', CONVERT(varchar(255), CONVERT(int, @user_password))))
	BEGIN
		SET @resultado = 1
		UPDATE LOS_TRIGGERS.Usuario SET user_intentos_fallidos_login = 0  WHERE user_name = @user_name 
		IF (@intentos_fallidos > 2)
		BEGIN
			SET @resultado = 2
			IF (@rol='Afiliado')
				UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 1
				where  @num_afiliado = afil_numero
			IF (@rol='Administrador')
				UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 1
				where @num_administrador = admi_id
			IF (@rol='Profesional')
				UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 1
				where @num_profesional = prof_id
		END

	END	
ELSE
IF (@password is not null)
	BEGIN
		SET @resultado = 0
		IF (@intentos_fallidos >= 2)
			BEGIN
				UPDATE LOS_TRIGGERS.Usuario SET user_intentos_fallidos_login = user_intentos_fallidos_login + 1 WHERE user_name = @user_name 
				IF (@rol='Afiliado' and @intentos_fallidos = 2)
					UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 0 where  @num_afiliado = afil_numero
				IF (@rol='Administrador' and @intentos_fallidos = 2)
					UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 0 where @num_administrador = admi_id
				IF (@rol='Profesional' and @intentos_fallidos = 2)
					UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 0 where @num_profesional = prof_id
								--EXEC usuario_inhabilitar @DNI,@rol
			END 
		ELSE
			UPDATE LOS_TRIGGERS.Usuario SET user_intentos_fallidos_login = user_intentos_fallidos_login + 1	WHERE user_name = @user_name
	END
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.usuario_traer_ID_rol') is not null DROP PROCEDURE LOS_TRIGGERS.usuario_traer_ID_rol
GO	
CREATE PROC LOS_TRIGGERS.usuario_traer_ID_rol(
	@usuario nvarchar(255), @rol nvarchar(255), @nro numeric(18) OUTPUT)
AS 
BEGIN
	SELECT @nro=CASE @rol WHEN 'Afiliado' THEN user_afiliado
				 WHEN 'Profesional' THEN user_profesional
				 WHEN 'Administrativo' THEN user_administrador
				 END
		FROM LOS_TRIGGERS.Usuario
		WHERE @usuario = user_name
	IF (@nro is null) set @nro = 0
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.usuario_tiene_permiso') is not null DROP PROCEDURE LOS_TRIGGERS.usuario_tiene_permiso
GO
CREATE PROC LOS_TRIGGERS.usuario_tiene_permiso(
	@rol nvarchar(255), @funcionalidad nvarchar(255), @resultado bit OUTPUT)
AS
BEGIN
	IF @rol='Afiliado'
		(SELECT * FROM LOS_TRIGGERS.Funcionalidad AS f 
		JOIN LOS_TRIGGERS.Funcionalidad_Rol AS fr on f.func_id = fr.funcionalidad
		WHERE f.func_nombre = @funcionalidad and fr.afiliado is not null)
	IF @rol = 'Administrador'
		(SELECT * FROM LOS_TRIGGERS.Funcionalidad AS f 
		JOIN LOS_TRIGGERS.Funcionalidad_Rol AS fr on f.func_id = fr.funcionalidad
		WHERE f.func_nombre = @funcionalidad and fr.administrador is not null)
	IF @rol='Profesional'
		(SELECT * FROM LOS_TRIGGERS.Funcionalidad AS f 
		JOIN LOS_TRIGGERS.Funcionalidad_Rol AS fr on f.func_id = fr.funcionalidad
		WHERE f.func_nombre = @funcionalidad and fr.profesional is not null)
	IF (@@ROWCOUNT = 0)
		SET @RESULTADO =0	
	ELSE
		SET @RESULTADO =1	
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.registro_llegada') is not null DROP PROCEDURE LOS_TRIGGERS.registro_llegada
GO			
CREATE PROC LOS_TRIGGERS.registro_llegada (
	@turn_numero numeric(18,0), @bono_numero numeric(18,0), @afiliado numeric(18,0), @fecha datetime)
AS
BEGIN
	UPDATE LOS_TRIGGERS.Turno SET turn_fecha_y_hora_asistencia = convert(datetime,@fecha)
		WHERE turn_numero = @turn_numero
	INSERT INTO LOS_TRIGGERS.Diagnostico (diag_fecha_y_hora,diag_sintomas,diag_descripcion)
		VALUES (null,null,null)
	INSERT INTO LOS_TRIGGERS.Consulta_Medica (cons_diagnostico,cons_turno) 
		VALUES (@@IDENTITY,@turn_numero)
	UPDATE LOS_TRIGGERS.Bono SET bono_afiliado = @afiliado, bono_consulta_medica = @@IDENTITY
		WHERE bono_numero = @bono_numero
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.registro_resultado') is not null DROP PROCEDURE LOS_TRIGGERS.registro_resultado
GO				
CREATE PROC LOS_TRIGGERS.registro_resultado (
	@turn_numero numeric(18,0), @fecha_y_hora datetime, @diag_sintomas varchar(255), @diag_descripcion varchar(255))
AS
BEGIN
	DECLARE @ID_DIAGNOSTICO NUMERIC(18,0)
	SELECT @ID_DIAGNOSTICO=cons_diagnostico FROM LOS_TRIGGERS.Consulta_Medica 
	WHERE cons_turno = @turn_numero
	UPDATE LOS_TRIGGERS.Diagnostico SET diag_fecha_y_hora = @fecha_y_hora, diag_sintomas = @diag_sintomas, diag_descripcion = @diag_descripcion
	WHERE diag_id = @ID_DIAGNOSTICO
END;
GO