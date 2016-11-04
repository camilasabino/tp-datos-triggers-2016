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

IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoPlanMedico') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoPlanMedico
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoPlanMedico(@afiliado numeric(18,0), @nuevo_plan numeric(18,0), @motivo varchar(255)) AS
	BEGIN
		DECLARE @fecha datetime
		update LOS_TRIGGERS.Afiliado set afil_plan_medico = @nuevo_plan where afil_numero = @afiliado
		insert into LOS_TRIGGERS.Modificacion_Plan(modi_id,modi_fecha_y_hora,modi_motivo) 
				values (@nuevo_plan, GETDATE(), @motivo)
	END;
GO

--<Baja Afiliado>--
IF OBJECT_ID ('LOS_TRIGGERS.RegistrarBajaLogicaAfiliado') is not null DROP TRIGGER LOS_TRIGGERS.RegistrarBajaLogicaAfiliado
GO
CREATE TRIGGER LOS_TRIGGERS.RegistrarBajaLogicaAfiliado ON LOS_TRIGGERS.Afiliado 
	AFTER UPDATE
	AS
	BEGIN
		DECLARE @afiliado numeric(18,0) = (select afil_numero FROM inserted)
		delete from LOS_TRIGGERS.Turno where turn_afiliado = (@afiliado)  
		insert into LOS_TRIGGERS.Baja_Afiliado(baja_afiliado,baja_fecha) 
				values (@afiliado, GETDATE())
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
CREATE FUNCTION LOS_TRIGGERS.CalcularNumeroAfiliado(@afiliado numeric(18,0), @titular numeric(18,0), @relacionConTitular varchar(255))
	RETURNS numeric(18,0)
	AS
	BEGIN
		IF(@afiliado = @titular) RETURN @afiliado
		ELSE  DECLARE @numeroAfiliado numeric(18,0)
		IF(@relacionConTitular = 'Conyuge') 
			BEGIN	
				set @numeroAfiliado = @afiliado + 1
				RETURN @numeroAfiliado
			END
		ELSE IF(@relacionConTitular = 'Hijo' OR @relacionConTitular = 'Hija')
			BEGIN
				set @numeroAfiliado = (select TOP 1 afil_numero from Afiliado where afil_titular_grupo_familiar = @titular order by afil_numero DESC) + 1
				RETURN @numeroAfiliado
			END
			RETURN @numeroAfiliado
	END
GO


IF OBJECT_ID ('LOS_TRIGGERS.DarDeAltaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeAltaUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.DarDeAltaUnAfiliado(@afiliadoNumero numeric(18,0),@estadoCivil varchar(255), @titular numeric(18,0), @plan numeric(18,0), @familiaresACargo numeric(2,0), @relacionConTitular varchar(255)) AS
	BEGIN
		insert into LOS_TRIGGERS.Afiliado(afil_numero, afil_estado_civil, afil_habilitacion, nombre_rol, afil_plan_medico, afil_cant_consultas_realizadas, afil_cant_familiares_a_cargo, afil_relacion_con_titular) 
			values (LOS_TRIGGERS.CalcularNumeroAfiliado(@afiliadoNumero, @titular,@relacionConTitular), @estadoCivil, 1, 'Afiliado', @plan, 0, @familiaresACargo, @relacionConTitular) 
	END;

GO

/******** Compra de Bonos ********/



/******** Listado Estadístico ********/