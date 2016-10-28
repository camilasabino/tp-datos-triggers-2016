/************* EJERCICIO 2 *************/




USE [GD2C2016]
GO
/****** Object:  StoredProcedure [dbo].[usuario_login]    Script Date: 27/10/2016 10:00:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usuario_login]
(
@user_name varchar(30),
@user_password varchar(30),
@rol varchar(30),
@resultado bit OUTPUT
)
AS
DECLARE @intentos_fallidos numeric(1)
DECLARE @password varchar(30)
DECLARE @num_afiliado numeric(18)
DECLARE @num_profesional numeric(18)
DECLARE @num_administrador numeric(18)

SELECT @password = user_password,@intentos_fallidos=user_intentos_fallidos_login,
--@DNI = user_dni 
@num_afiliado = user_afiliado,
@num_profesional = user_profesional,
@num_administrador = user_administrador
FROM LOS_TRIGGERS.Usuario
where user_name = @user_name
IF (@password = HASHBYTES('SHA2_256', CONVERT(varchar(255), CONVERT(int,@user_password))))
	BEGIN
		SET @resultado = 1
		UPDATE LOS_TRIGGERS.Usuario SET user_intentos_fallidos_login = 0 
		WHERE user_name = @user_name 
		IF (@rol='Afiliado' and @intentos_fallidos > 2)
			UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 1
			where  @num_afiliado = afil_numero
		IF (@rol='Administrador' and @intentos_fallidos > 2)
			UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 1
			where @num_administrador = admi_id
		IF (@rol='Profesional' and @intentos_fallidos > 2)
			UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 1
			where @num_profesional = prof_id

	END	
ELSE
IF (@password is not null)
	BEGIN
		SET @resultado = 0
		IF (@intentos_fallidos >= 2)
			BEGIN
				UPDATE LOS_TRIGGERS.Usuario SET user_intentos_fallidos_login = user_intentos_fallidos_login + 1
					WHERE user_name = @user_name 
				IF (@rol='Afiliado' and @intentos_fallidos = 3)
					UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 0
					where  @num_afiliado = afil_numero
				IF (@rol='Administrador' and @intentos_fallidos = 3)
					UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 0
					where @num_administrador = admi_id
				IF (@rol='Profesional' and @intentos_fallidos = 3)
					UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 0
					where @num_profesional = prof_id
								--EXEC usuario_inhabilitar @DNI,@rol
			END 
		ELSE
			UPDATE LOS_TRIGGERS.Usuario SET user_intentos_fallidos_login = user_intentos_fallidos_login + 1
			WHERE user_name = @user_name
	END












/************* EJERCICIO 3 *************/

USE GD2C2016

INSERT INTO LOS_TRIGGERS.Administrador (admi_nombre_rol,admi_habilitacion)
						values ('Administrador',1)

INSERT INTO LOS_TRIGGERS.Usuario (user_name,user_password,user_intentos_fallidos_login,user_administrador)
values ('admin',HASHBYTES('SHA2_256', CONVERT(varchar(255), 'w23e')),0,@@IDENTITY)
