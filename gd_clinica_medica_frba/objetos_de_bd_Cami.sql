/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/

--- << ABM de Rol >> ---
/*
IF OBJECT_ID ('LOS_TRIGGERS.AltaRol') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRol
GO
CREATE PROC LOS_TRIGGERS.AltaRol (@nombre_rol varchar(255)) AS
	BEGIN
	
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
CREATE PROC LOS_TRIGGERS.ModificarRol (@nombre varchar(255)) AS
	BEGIN

	END;
GO
*/

IF OBJECT_ID ('LOS_TRIGGERS.InhabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.InhabilitarRol
GO
CREATE PROC LOS_TRIGGERS.InhabilitarRol (@nombre_rol varchar(255)) AS
	BEGIN
		IF (@nombre_rol='Afiliado')
			BEGIN
				UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 0
				UPDATE LOS_TRIGGERS.Usuario set user_afiliado = null where user_afiliado is not null
			END
		ELSE IF (@nombre_rol='Administrador')
			BEGIN
				UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 0
				UPDATE LOS_TRIGGERS.Usuario set user_administrador = null where user_administrador is not null
			END
		ELSE IF (@nombre_rol='Profesional')
			BEGIN
				UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 0
				UPDATE LOS_TRIGGERS.Usuario set user_profesional = null where user_profesional is not null
			END
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.HabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.HabilitarRol
GO
CREATE PROC LOS_TRIGGERS.HabilitarRol (@nombre_rol varchar(255)) AS
	BEGIN
		IF (@nombre_rol='Afiliado')
			update LOS_TRIGGERS.Afiliado set afil_habilitacion = 1
		ELSE IF (@nombre_rol='Administrador')
			update LOS_TRIGGERS.Administrador set admi_habilitacion = 1
		ELSE IF (@nombre_rol='Profesional')
			update LOS_TRIGGERS.Profesional set prof_habilitacion = 1
	END;
GO


--- << Funcionalidades >> ---
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidadRol') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidadRol
GO
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidadRol (@funcionalidad varchar(255), @rol varchar(255)) AS
BEGIN
		declare @func_id as numeric(18,0)
		set @func_id = (select func_id from LOS_TRIGGERS.Funcionalidad where func_nombre=@funcionalidad)
		IF (@rol='Afiliado')
			BEGIN
				insert into LOS_TRIGGERS.Funcionalidad_Rol
					select @func_id, afil_numero from LOS_TRIGGERS.Afiliado
			END
		ELSE IF (@rol='Administrador')
			BEGIN
				insert into LOS_TRIGGERS.Funcionalidad_Rol
					select @func_id, admi_id from LOS_TRIGGERS.Administrador
			END
		ELSE IF (@rol='Profesional')
			BEGIN
				insert into LOS_TRIGGERS.Funcionalidad_Rol
					select @func_id, prof_id from LOS_TRIGGERS.Profesional
			END
END
GO

IF OBJECT_ID ('LOS_TRIGGERS.QuitarFuncionalidadRol') is not null DROP PROCEDURE LOS_TRIGGERS.QuitarFuncionalidadRol
GO
CREATE PROC LOS_TRIGGERS.QuitarFuncionalidadRol (@funcionalidad varchar(255), @rol varchar(255)) AS
BEGIN
		declare @func_id as numeric(18,0)
		set @func_id = (select func_id from LOS_TRIGGERS.Funcionalidad where func_nombre=@funcionalidad)
		IF (@rol='Afiliado')
			BEGIN
				delete from LOS_TRIGGERS.Funcionalidad_Rol
				where funcionalidad=@func_id AND rol IN (select afil_numero from LOS_TRIGGERS.Afiliado)
			END
		ELSE IF (@rol='Administrador')
			BEGIN
				delete from LOS_TRIGGERS.Funcionalidad_Rol
				where funcionalidad=@func_id AND rol IN (select admi_id from LOS_TRIGGERS.Administrador)
			END
		ELSE IF (@rol='Profesional')
			BEGIN
				delete from LOS_TRIGGERS.Funcionalidad_Rol
				where funcionalidad=@func_id AND rol IN (select prof_id from LOS_TRIGGERS.Profesional)
			END
END
GO

--- << Pedido y Cancelación de Turno >> ---
IF OBJECT_ID ('LOS_TRIGGERS.RegistrarTurno') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarTurno
GO
CREATE PROC LOS_TRIGGERS.CancelarTurno (@afiliado numeric(18,00), @profesional numeric(18,00), @fecha datetime, @motivo varchar(255)) AS
BEGIN
		insert into LOS_TRIGGERS.Turno (turn_afiliado, turn_profesional, turn_fecha_atencion)
			values(@afiliado, @profesional, @fecha)
END
GO

IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurno') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurno
GO
CREATE PROC LOS_TRIGGERS.CancelarTurno (@afiliado numeric(18,00), @profesional numeric(18,00), @turno numeric(18,0), @tipo numeric(18,0), @motivo varchar(255)) AS
BEGIN
	declare @fecha_turno as datetime
	set @fecha_turno = (select turn_fecha_atencion from LOS_TRIGGERS.Turno where turn_numero=@turno)

	IF (GETDATE() < @fecha_turno)
		BEGIN
			insert into LOS_TRIGGERS.Cancelacion_Turno (canc_afiliado, canc_profesional, canc_fecha, canc_fecha_turno, canc_tipo, canc_motivo, can_horario_atencion)
				select @afiliado, @profesional, @fecha_turno, GETDATE(), @tipo, @motivo, hora_id
				from LOS_TRIGGERS.Horario_Atencion where hora_turno=@turno

			update LOS_TRIGGERS.Horario_Atencion set hora_turno = null where hora_turno=@turno
			delete from LOS_TRIGGERS.Turno where turn_numero=@turno
		END
END
GO