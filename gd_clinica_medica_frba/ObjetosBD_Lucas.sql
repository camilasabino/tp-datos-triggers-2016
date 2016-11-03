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

IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoPlanMedico') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliado
GO
CREATE PROC LOS_TRIGGERS.ModificarAfiliadoPlanMedico(@afiliado numeric(18,0), @nuevo_plan numeric(18,0), @motivo varchar(255)) AS
	BEGIN
		DECLARE @fecha datetime
		update LOS_TRIGGERS.Afiliado set afil_plan_medico = @nuevo_plan where afil_numero = @afiliado
		set @fecha = GETDATE()
		insert into LOS_TRIGGERS.Modificacion_Plan(modi_id,modi_fecha_y_hora,modi_motivo) 
				values (@nuevo_plan, @fecha, @motivo)
	END;
GO

--<Baja Afiliado>--

IF OBJECT_ID ('LOS_TRIGGERS.DarDeBajaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeBajaUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.DarDeBajaUnAfiliado(@afiliado numeric(18,0), @detalle varchar(255)) AS
	BEGIN
		DECLARE @fecha datetime
		delete LOS_TRIGGERS.Turno where turn_afiliado = @afiliado 
		update LOS_TRIGGERS.Afiliado set afil_habilitacion = 0 where afil_numero = @afiliado
		set @fecha = GETDATE()
		insert into LOS_TRIGGERS.Baja_Afiliado(baja_afiliado,baja_detalle,baja_fecha) 
				values (@afiliado, @detalle, @fecha)
	END;
GO

--<Alta Afiliado>--

IF OBJECT_ID ('LOS_TRIGGERS.DarDeAltaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeAltaUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.DarDeAltaUnAfiliado(@afiliado numeric(18,0), @detalle varchar(255)) AS
	BEGIN

	END;
GO

/******** Compra de Bonos ********/



/******** Listado Estadístico ********/