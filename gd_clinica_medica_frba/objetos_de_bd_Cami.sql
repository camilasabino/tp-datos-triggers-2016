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
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidadAUnRol') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidadAUnRol
GO
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidadAUnRol (@funcionalidad varchar(255), @rol varchar(255)) AS
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
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.QuitarFuncionalidadAUnRol') is not null DROP PROCEDURE LOS_TRIGGERS.QuitarFuncionalidadAUnRol
GO
CREATE PROC LOS_TRIGGERS.QuitarFuncionalidadAUnRol (@funcionalidad varchar(255), @rol varchar(255)) AS
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
END;
GO

--- << Pedido de un Turno >> ---
IF OBJECT_ID ('LOS_TRIGGERS.ComboProfesionales') is not null DROP PROCEDURE LOS_TRIGGERS.ComboProfesionales
GO
CREATE PROC LOS_TRIGGERS.ComboProfesionales AS
	BEGIN
		select user_profesional, user_apellido+', '+user_nombre
		from LOS_TRIGGERS.Usuario where user_profesional is not null
		order by user_apellido, user_nombre
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional
GO
CREATE PROC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional (@profesional numeric(18,0)) AS
	BEGIN
		select espe_codigo, tipo_descripcion, espe_descripcion
		from LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad, LOS_TRIGGERS.Tipo_Especialidad
		where profesional=@profesional AND espe_codigo=especialidad AND espe_tipo=tipo_id
		order by tipo_descripcion, espe_descripcion
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ComboHorariosDeUnProfesionalEnUnaEspecialidad') is not null DROP PROCEDURE LOS_TRIGGERS.ComboHorariosDeUnProfesionalEnUnaEspecialidad
GO
CREATE PROC LOS_TRIGGERS.ComboHorariosDeUnProfesionalEnUnaEspecialidad (@profesional numeric(18,0), @especialidad numeric(18,0)) AS
	BEGIN
		select hora_id, hora_fecha_asignada, hora_dia_atencion, hora_inicio_atencion
		from LOS_TRIGGERS.Horario_Atencion
		where hora_especialidad_profesional=(select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=@profesional AND especialidad=@especialidad) AND hora_fecha_asignada >= GETDATE()
		order by hora_fecha_asignada, hora_inicio_atencion
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarTurno') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarTurno
GO
CREATE PROC LOS_TRIGGERS.CancelarTurno (@afiliado numeric(18,00), @profesional numeric(18,00), @fecha datetime) AS
BEGIN
		insert into LOS_TRIGGERS.Turno (turn_afiliado, turn_profesional, turn_fecha_atencion)
			values(@afiliado, @profesional, @fecha)
END
GO

--- << Cancelación de un Turno >> ---
IF OBJECT_ID ('LOS_TRIGGERS.TurnosAsignadosAUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.TurnosAsignadosAUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado (@afiliado numeric(18,0)) AS
	BEGIN
		select turn_numero, user_apellido+', '+user_nombre, espe_descripcion, hora_fecha_asignada, hora_inicio_atencion
		from LOS_TRIGGERS.Turno, LOS_TRIGGERS.Horario_Atencion, LOS_TRIGGERS.Usuario, LOS_TRIGGERS.Especialidad
		where turn_afiliado=@afiliado AND hora_turno=turn_numero AND user_profesional=turn_profesional AND espe_codigo=turn_especialidad
		order by hora_fecha_asignada, hora_inicio_atencion
	END;
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
END;
GO

--- << Registrar la Agenda de un Profesional >> ---
-- 1) Determinar Profesional
-- 2) Determinar Especialidad
-- 3) Determinar día
-- 4) Determinar rango horario (con turnos c/30 min)
-- 5) Verificar que no acumule más de 48hs p/semana
-- 6) Determinar fechas de disponibilidad
-- ** Una vez cargada, la agenda es inalterable **

IF OBJECT_ID ('LOS_TRIGGERS.DiasDeAtencionDeLaClinica') is not null DROP PROCEDURE LOS_TRIGGERS.DiasDeAtencionDeLaClinica
GO
CREATE PROC LOS_TRIGGERS.DiasDeAtencionDeLaClinica AS
BEGIN
	select 'Lunes' as dias_de_atencion UNION select 'Martes' as dias_de_atencion
	UNION select 'Miércoles' as dias_de_atencion UNION select 'Jueves' as dias_de_atencion
	UNION select 'Viernes' as dias_de_atencion UNION select 'Sábado' as dias_de_atencion
	--TODO: ver el order by
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RangoHorarioDeLaClinica') is not null DROP PROCEDURE LOS_TRIGGERS.RangoHorarioDeLaClinica
GO
CREATE PROC LOS_TRIGGERS.RangoHorarioDeLaClinica (@dia varchar(255)) AS
BEGIN
	IF (@dia = 'Sábado')
		select clin_inicio_sabado, clin_fin_sabado from LOS_TRIGGERS.Clinica where clin_nombre='Clinica Medica FRBA'
	ELSE
		select clin_inicio_dia_semana, clin_fin_dia_semana from LOS_TRIGGERS.Clinica where clin_nombre='Clinica Medica FRBA'
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarDiaAtencionProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarDiaAtencionProfesional
GO
CREATE PROC LOS_TRIGGERS.RegistrarDiaAtencionProfesional (@profesional numeric(18,0), @especialidad numeric(18,0), @dia varchar(255)) AS
BEGIN
	
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarAgendaProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarAgendaProfesional
GO
CREATE PROC LOS_TRIGGERS.RegistrarAgendaProfesional (@profesional numeric(18,0), @especialidad numeric(18,0), @dia varchar(255)) AS
BEGIN
	
END;
GO
