/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/

IF OBJECT_ID ('LOS_TRIGGERS.Calendario') IS NOT NULL DROP TABLE LOS_TRIGGERS.Calendario
CREATE TABLE [LOS_TRIGGERS].[Calendario](
	[dia_del_año] [date] NOT NULL,
 CONSTRAINT [PK_Calendar_Date] PRIMARY KEY CLUSTERED ([dia_del_año] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

DECLARE @primer_dia datetime
DECLARE @ultimo_dia datetime
SET @primer_dia = DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
SET @ultimo_dia = DATEADD(d, 365, @primer_dia)

WHILE @primer_dia <= @ultimo_dia
	BEGIN
		insert into [LOS_TRIGGERS].[Calendario] (dia_del_año)
			select @primer_dia SET @primer_dia = DATEADD(dd, 1, @primer_dia)
	END

--- << ABM de Rol >> ---

IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
CREATE PROC LOS_TRIGGERS.ModificarRol (@rol varchar(255), @nuevo_nombre varchar(255)) AS
	BEGIN
		--select TABLE_NAME From INFORMATION_SCHEMA.COLUMNS Where column_name = 'nombre_rol'
		update LOS_TRIGGERS.Administrador set nombre_rol = @nuevo_nombre where nombre_rol=@rol
		update LOS_TRIGGERS.Afiliado set nombre_rol = @nuevo_nombre where nombre_rol=@rol
		update LOS_TRIGGERS.Profesional set nombre_rol = @nuevo_nombre where nombre_rol=@rol
	END;
GO


IF OBJECT_ID ('LOS_TRIGGERS.AltaRolAdministrador') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRolAdministrador
GO
CREATE PROC LOS_TRIGGERS.AltaRolAdministrador AS
	BEGIN
		IF OBJECT_ID ('LOS_TRIGGERS.Administrador') IS NOT NULL DROP TABLE LOS_TRIGGERS.Administrador
		CREATE TABLE LOS_TRIGGERS.Administrador (
			[admi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
			[admi_habilitacion] [bit] NULL
		);
	
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.AltaRolAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRolAfiliado
GO
CREATE PROC LOS_TRIGGERS.AltaRolAfiliado AS
	BEGIN
	IF OBJECT_ID ('LOS_TRIGGERS.Afiliado') IS NOT NULL DROP TABLE LOS_TRIGGERS.Afiliado
	CREATE TABLE LOS_TRIGGERS.Afiliado (
		[afil_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
		[afil_estado_civil] [varchar](255) NULL,
		[afil_habilitacion] [bit] NULL,
		[afil_titular_grupo_familiar] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
		[afil_plan_medico] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Plan_Medico,
		[afil_cant_consultas_realizadas] [numeric](18, 0) NULL
	);
	
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.AltaRolProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRolProfesional
GO
CREATE PROC LOS_TRIGGERS.AltaRolProfesional AS
	BEGIN
	IF OBJECT_ID ('LOS_TRIGGERS.Profesional ') IS NOT NULL DROP TABLE LOS_TRIGGERS.Profesional 
	CREATE TABLE LOS_TRIGGERS.Profesional  (
		[prof_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
		[prof_matricula] [numeric](18, 0) NULL,
		[prof_horas_laborales] [numeric](2, 0) NULL,
		[prof_habilitacion] [bit] NULL,
	);
	
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.AltaRol') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRol
GO
CREATE PROC LOS_TRIGGERS.AltaRol (@nombre_rol varchar(255)) AS
	BEGIN
		IF (@nombre_rol='Afiliado') EXEC LOS_TRIGGERS.AltaRolAfiliado
		ELSE IF (@nombre_rol='Administrador') EXEC LOS_TRIGGERS.AltaRolAdministrador
		ELSE IF (@nombre_rol='Profesional') EXEC LOS_TRIGGERS.AltaRolProfesional
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.InhabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.InhabilitarRol
GO
CREATE PROC LOS_TRIGGERS.InhabilitarRol (@nombre_rol varchar(255)) AS
	BEGIN
		IF (@nombre_rol='Afiliado')
			BEGIN
				update LOS_TRIGGERS.Afiliado set afil_habilitacion = 0
				update LOS_TRIGGERS.Usuario set user_afiliado = null where user_afiliado is not null
			END
		ELSE IF (@nombre_rol='Administrador')
			BEGIN
				update LOS_TRIGGERS.Administrador set admi_habilitacion = 0
				update LOS_TRIGGERS.Usuario set user_administrador = null where user_administrador is not null
			END
		ELSE IF (@nombre_rol='Profesional')
			BEGIN
				update LOS_TRIGGERS.Profesional set prof_habilitacion = 0
				update LOS_TRIGGERS.Usuario set user_profesional = null where user_profesional is not null
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
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidadAUnRol (@rol varchar(255), @funcionalidad varchar(255)) AS
BEGIN
		declare @func_id as numeric(18,0)
		set @func_id = (select func_id from LOS_TRIGGERS.Funcionalidad where func_nombre=@funcionalidad)

		IF (@rol='Afiliado')
			insert into LOS_TRIGGERS.Funcionalidad_Rol select @func_id, afil_numero from LOS_TRIGGERS.Afiliado
		ELSE IF (@rol='Administrador')
			insert into LOS_TRIGGERS.Funcionalidad_Rol select @func_id, admi_id from LOS_TRIGGERS.Administrador
		ELSE IF (@rol='Profesional')
			insert into LOS_TRIGGERS.Funcionalidad_Rol select @func_id, prof_id from LOS_TRIGGERS.Profesional
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.QuitarFuncionalidadAUnRol') is not null DROP PROCEDURE LOS_TRIGGERS.QuitarFuncionalidadAUnRol
GO
CREATE PROC LOS_TRIGGERS.QuitarFuncionalidadAUnRol (@funcionalidad varchar(255), @rol varchar(255)) AS
BEGIN
		declare @func_id as numeric(18,0)
		set @func_id = (select func_id from LOS_TRIGGERS.Funcionalidad where func_nombre=@funcionalidad)

		IF (@rol='Afiliado')
			delete from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND rol IN (select afil_numero from LOS_TRIGGERS.Afiliado)
		ELSE IF (@rol='Administrador')
			delete from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND rol IN (select admi_id from LOS_TRIGGERS.Administrador)
		ELSE IF (@rol='Profesional')
			delete from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND rol IN (select prof_id from LOS_TRIGGERS.Profesional)
END;
GO

-- << Carga de Funcionalidades a los Roles >>
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'Login y Seguridad'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'ABM de Rol'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'ABM de Afiliado'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'ABM de Profesional'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'ABM de Plan'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'ABM de Especialidad Médica'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'Registro de Usuario'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'Registro de Agenda de Profesional'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'Compra de Bono'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Administrador', @funcionalidad = 'Listado Estadístico'

EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Profesional', @funcionalidad = 'Login y Seguridad'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Profesional', @funcionalidad = 'Registro de Agenda de Profesional'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Profesional', @funcionalidad = 'Registro de Consulta Médica'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Profesional', @funcionalidad = 'Registro de Diagnóstico Médico'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Profesional', @funcionalidad = 'Cancelación de Turno'

EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Afiliado', @funcionalidad = 'Login y Seguridad'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Afiliado', @funcionalidad = 'Compra de Bono'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Afiliado', @funcionalidad = 'Pedido de Turno'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol = 'Afiliado', @funcionalidad = 'Cancelación de Turno'

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
		select dia_id, dia_nombre_dia, dia_hora_inicio, dia_hora_fin
		from LOS_TRIGGERS.Dia_Atencion
		where dia_especialidad_profesional=(select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=@profesional AND especialidad=@especialidad)
		order by dia_id
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarTurno') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarTurno
GO
CREATE PROC LOS_TRIGGERS.CancelarTurno (@afiliado numeric(18,00), @profesional numeric(18,00), @especialidad numeric(18,0), @fecha datetime) AS
BEGIN
		insert into LOS_TRIGGERS.Turno (turn_afiliado, turn_especialidad_profesional, turn_fecha)
			select @afiliado, (select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=@profesional AND especialidad=@especialidad), @fecha
END
GO

--- << Cancelación de un Turno >> ---
IF OBJECT_ID ('LOS_TRIGGERS.TurnosAsignadosAUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.TurnosAsignadosAUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado (@afiliado numeric(18,0)) AS
	BEGIN
		select turn_numero, user_apellido+', '+user_nombre, espe_descripcion, CONVERT(date, turn_fecha), turn_nombre_dia, turn_hora_inicio
		from LOS_TRIGGERS.Turno, LOS_TRIGGERS.Usuario, LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad
		where turn_afiliado=@afiliado AND turn_fecha >= GETDATE() AND espe_prof_id=turn_especialidad_profesional AND espe_codigo=especialidad
		order by turn_fecha, turn_hora_inicio
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurno') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurno
GO
CREATE PROC LOS_TRIGGERS.CancelarTurno (@afiliado numeric(18,00), @profesional numeric(18,00), @turno numeric(18,0), @tipo numeric(18,0), @motivo varchar(255)) AS
BEGIN
	declare @fecha_turno as datetime
	set @fecha_turno = (select turn_fecha from LOS_TRIGGERS.Turno where turn_numero=@turno)

	IF (GETDATE() < @fecha_turno)
		BEGIN
			insert into LOS_TRIGGERS.Cancelacion_Turno (canc_afiliado, canc_profesional, canc_fecha_y_hora, canc_fecha_turno, canc_tipo, canc_motivo)
				select @afiliado, @profesional, @fecha_turno, GETDATE(), @tipo, @motivo
	

			delete from LOS_TRIGGERS.Turno where turn_numero=@turno
		END
END;
GO

--- << Registrar la Agenda de un Profesional >> ---
-- 1) Determinar Profesional
-- 2) Determinar Especialidad
-- 3) Determinar día de atención
-- 4) Determinar rango horario (con turnos c/30 min)
-- 5) Verificar que no acumule más de 48hs p/semana
-- 6) Determinar fechas de disponibilidad
-- ** Una vez cargada, la agenda es inalterable **

IF OBJECT_ID ('LOS_TRIGGERS.DiasDeAtencionDeLaClinica') is not null DROP PROCEDURE LOS_TRIGGERS.DiasDeAtencionDeLaClinica
GO
CREATE PROC LOS_TRIGGERS.DiasDeAtencionDeLaClinica AS
BEGIN
	select dia_nombre_dia from LOS_TRIGGERS.Dia_Atencion where dia_clinica is not null
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RangoHorarioDeLaClinica') is not null DROP PROCEDURE LOS_TRIGGERS.RangoHorarioDeLaClinica
GO
CREATE PROC LOS_TRIGGERS.RangoHorarioDeLaClinica (@dia varchar(255)) AS
BEGIN
		select dia_hora_inicio, dia_hora_fin from LOS_TRIGGERS.Dia_Atencion where dia_clinica is not null AND dia_nombre_dia=@dia
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarDiaAtencionProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarDiaAtencionProfesional
GO
CREATE PROC LOS_TRIGGERS.RegistrarDiaAtencionProfesional (@profesional numeric(18,0), @especialidad numeric(18,0), @dia varchar(255), @inicio varchar(255), @fin varchar(255)) AS
BEGIN
	declare @horas_acumuladas as int
	set @horas_acumuladas = (select prof_horas_laborales from LOS_TRIGGERS.Profesional where prof_id=@profesional) + DATEDIFF(hour, @fin, @inicio)
	
	IF (@horas_acumuladas <= 48)
		BEGIN
			insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_especialidad_profesional)
				select @dia, @inicio, @fin, (select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=@profesional AND especialidad=@especialidad)

			update LOS_TRIGGERS.Profesional
				set prof_horas_laborales = CONVERT(numeric(2,0), @horas_acumuladas)
		END
	--ELSE
		-- NO PERMITIDO
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.RegistrarAgendaProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarAgendaProfesional
GO
CREATE PROC LOS_TRIGGERS.RegistrarAgendaProfesional (@profesional numeric(18,0), @especialidad numeric(18,0), @desde date, @hasta date) AS
BEGIN
	IF (@desde >= GETDATE() AND @desde < @hasta AND @hasta <= CONVERT(date, DATEADD(yy, DATEDIFF(yy,0,getdate()) + 1, -1)))
		BEGIN
			update LOS_TRIGGERS.Especialidad_Profesional
				set disponible_desde_fecha = @desde, disponible_hasta_fecha = @hasta
				where profesional=@profesional AND especialidad=@especialidad
		END
	--ELSE
		-- NO ESTÁ EN EL RANGO DE ESTE AÑO O ES INVÁLIDO
END;
GO
