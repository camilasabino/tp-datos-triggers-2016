/******** ABM Afiliados *********/

--<Modificación de los datos del Afiliado>--

IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoDireccion') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoDireccion
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoDireccion(@afiliado numeric(18,0), @nueva_direccion varchar(255)) AS
	BEGIN
		update LOS_TRIGGERS.Usuario set user_direccion = @nueva_direccion where user_afiliado = @afiliado
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoTelefono') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoTelefono
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoTelefono(@afiliado numeric(18,0), @nuevo_telefono numeric(18,0)) AS
	BEGIN
		update LOS_TRIGGERS.Usuario set user_telefono = @nuevo_telefono where user_afiliado = @afiliado
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoMail') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoMail
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoMail(@afiliado numeric(18,0), @nuevo_mail varchar(255)) AS
	BEGIN
		update LOS_TRIGGERS.Usuario set user_mail = @nuevo_mail where user_afiliado = @afiliado
	END;
GO

--- << Historial de cambios del Plan Médico de un Afiliado >> ---
IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoPlanMedico') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoPlanMedico
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoPlanMedico(@afiliado numeric(18,0), @nuevo_plan numeric(18,0), @motivo varchar(255)) AS
	BEGIN
		IF (@nuevo_plan <> (select afil_plan_medico from LOS_TRIGGERS.Afiliado where afil_numero = @afiliado))
			BEGIN
				IF (@afiliado = (select afil_titular_grupo_familiar from LOS_TRIGGERS.Afiliado where afil_numero=@afiliado))
					BEGIN
						insert into LOS_TRIGGERS.Modificacion_Plan(modi_afiliado, modi_viejo_plan, modi_nuevo_plan, modi_fecha_y_hora, modi_motivo)
							select afil_numero, afil_plan_medico, @nuevo_plan, GETDATE(), @motivo
							from LOS_TRIGGERS.Afiliado where afil_titular_grupo_familiar=@afiliado
						update LOS_TRIGGERS.Afiliado set afil_plan_medico = @nuevo_plan where afil_titular_grupo_familiar = @afiliado
					END
				ELSE
					BEGIN
						insert into LOS_TRIGGERS.Modificacion_Plan(modi_afiliado, modi_viejo_plan, modi_nuevo_plan, modi_fecha_y_hora, modi_motivo)
							select @afiliado, afil_plan_medico, @nuevo_plan, GETDATE(), @motivo
							from LOS_TRIGGERS.Afiliado where afil_numero=@afiliado
						update LOS_TRIGGERS.Afiliado set afil_plan_medico = @nuevo_plan where afil_numero = @afiliado
					END
			END
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ComboEstadoCivil') is not null DROP VIEW LOS_TRIGGERS.ComboEstadoCivil
GO
CREATE VIEW LOS_TRIGGERS.ComboEstadoCivil AS
	select 'Soltero/a' as estado_civil UNION select 'Casado/a' as estado_civil
	UNION select 'Viudo/a' as estado_civil UNION select 'Concubinato' as estado_civil
	UNION select 'Divorciado/a' as estado_civil
WITH CHECK OPTION
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoEstadoCivil') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoEstadoCivil
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoEstadoCivil(@afiliado numeric(18,0), @nuevoEstadoCivil varchar(255)) AS
	BEGIN
		update LOS_TRIGGERS.Afiliado set afil_estado_civil = @nuevoEstadoCivil where afil_numero = @afiliado
	END;
GO

--<Baja Afiliado>--

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarBajaLogicaAfiliado') is not null DROP TRIGGER LOS_TRIGGERS.RegistrarBajaLogicaAfiliado
GO
CREATE TRIGGER LOS_TRIGGERS.RegistrarBajaLogicaAfiliado ON LOS_TRIGGERS.Afiliado 
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		IF (UPDATE(afil_habilitacion) AND 0=(select afil_habilitacion FROM INSERTED))
			BEGIN
				DECLARE @afiliado numeric(18,0) = (select afil_numero FROM INSERTED)
				delete from LOS_TRIGGERS.Turno where turn_afiliado = @afiliado AND NOT EXISTS (select * from LOS_TRIGGERS.Consulta_Medica where cons_turno=turn_numero)
				insert into LOS_TRIGGERS.Baja_Afiliado(baja_afiliado, baja_fecha) values (@afiliado, GETDATE())
			END
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.DarDeBajaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeBajaUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.DarDeBajaUnAfiliado(@afiliado numeric(18,0)) AS
	BEGIN
		update LOS_TRIGGERS.Afiliado set afil_habilitacion = 0 where afil_numero = @afiliado
	END;
GO

--<Alta Afiliado>--

IF OBJECT_ID ('LOS_TRIGGERS.CalcularNumeroAfiliado') is not null DROP FUNCTION LOS_TRIGGERS.CalcularNumeroAfiliado
GO
CREATE FUNCTION LOS_TRIGGERS.CalcularNumeroAfiliado(@dni numeric(18,0), @numeroDelTitular numeric(18,0), @relacionConTitular varchar(255))
	RETURNS numeric(18,0)
	AS
	BEGIN
		DECLARE @numeroAfiliado numeric(18,0) 
		IF(@relacionConTitular = 'Titular') set @numeroAfiliado = (@dni*100) + 1  
		ELSE IF(@relacionConTitular = 'Cónyuge') set @numeroAfiliado = @numeroDelTitular + 1
		ELSE IF(@relacionConTitular = 'Hijo/a') set @numeroAfiliado = ISNULL((select TOP 1 afil_numero from LOS_TRIGGERS.Afiliado where afil_titular_grupo_familiar=@numeroDelTitular AND afil_relacion_con_titular='Hijo/a' order by afil_numero DESC), @numeroDelTitular+1) + 1
		
		RETURN @numeroAfiliado
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.DarDeAltaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeAltaUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.DarDeAltaUnAfiliado(@usuario numeric(18,0), @dni numeric(18,0), @titularNumero numeric(18,0), @estadoCivil varchar(255), @plan numeric(18,0), @familiaresACargo numeric(2,0), @relacionConTitular varchar(255)) AS
	SET IDENTITY_INSERT LOS_TRIGGERS.Afiliado ON
	BEGIN
		insert into LOS_TRIGGERS.Afiliado(afil_numero, afil_estado_civil, afil_habilitacion, nombre_rol, afil_plan_medico, afil_cant_consultas_realizadas, afil_cant_familiares_a_cargo, afil_titular_grupo_familiar, afil_relacion_con_titular) 
			values (LOS_TRIGGERS.CalcularNumeroAfiliado(@dni,@titularNumero,@relacionConTitular), @estadoCivil, 1, 'Afiliado', @plan, 0, @familiaresACargo, @titularNumero, @relacionConTitular) 
		
		update LOS_TRIGGERS.Usuario set user_afiliado = (select SCOPE_IDENTITY()) where user_id=@usuario

		IF(@relacionConTitular='Hijo/a' OR @relacionConTitular='Cónyuge')
			update LOS_TRIGGERS.Afiliado set afil_cant_familiares_a_cargo = afil_cant_familiares_a_cargo +1 where afil_numero = @titularNumero
	
	SET IDENTITY_INSERT LOS_TRIGGERS.Afiliado OFF
	END;
GO

/******** Compra de Bonos ********/



/******** Listado Estadístico ********/