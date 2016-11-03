/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/

--- << Historial de cambios de Plan Médico >> ---
IF OBJECT_ID ('LOS_TRIGGERS.ModificacionPlan') is not null DROP TRIGGER LOS_TRIGGERS.ModificacionPlan
GO
CREATE TRIGGER LOS_TRIGGERS.ModificacionPlan 
ON LOS_TRIGGERS.Plan_Medico
AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	INSERT INTO LOS_TRIGGERS.Modificacion_Plan(modi_fecha_y_hora, modi_plan_medico, modi_motivo)
		SELECT GETDATE(), plan_id, 'Precio bono consulta: '+CAST(plan_precio_bono_consulta as varchar)+
										'. Precio bono farmacia: '+CAST(plan_precio_bono_farmacia as varchar)+
										'. Descripción: '+plan_med_descripcion
		FROM INSERTED
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.InsercionPlan') is not null DROP TRIGGER LOS_TRIGGERS.InsercionPlan
GO
CREATE TRIGGER LOS_TRIGGERS.InsercionPlan 
ON LOS_TRIGGERS.Plan_Medico
AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	INSERT INTO LOS_TRIGGERS.Modificacion_Plan(modi_fecha_y_hora, modi_plan_medico, modi_motivo)
		SELECT GETDATE(), plan_id, 'Precio bono consulta: '+CAST(plan_precio_bono_consulta as varchar)+
										'. Precio bono farmacia: '+CAST(plan_precio_bono_farmacia as varchar)+
										'. Descripción: '+plan_med_descripcion
		FROM INSERTED
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.Calendario') IS NOT NULL DROP TABLE LOS_TRIGGERS.Calendario
CREATE TABLE [LOS_TRIGGERS].[Calendario](
	[dia_del_año] [date] NOT NULL primary key
	);

DECLARE @primer_dia datetime, @ultimo_dia datetime
SET @primer_dia = DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)
SET @ultimo_dia = DATEADD(d, 365, @primer_dia)

WHILE @primer_dia <= @ultimo_dia
	BEGIN
		insert into [LOS_TRIGGERS].[Calendario] (dia_del_año)
			select @primer_dia SET @primer_dia = DATEADD(dd, 1, @primer_dia)
	END;
GO

--- << ABM de Rol >> ---
IF OBJECT_ID ('LOS_TRIGGERS.ComboRoles') is not null DROP PROCEDURE LOS_TRIGGERS.ComboRoles
GO
CREATE PROC LOS_TRIGGERS.ComboRoles AS
	BEGIN
		select nombre_rol as rol from LOS_TRIGGERS.Afiliado where nombre_rol is not null
		UNION select nombre_rol from LOS_TRIGGERS.Administrador where nombre_rol is not null
		UNION select nombre_rol from LOS_TRIGGERS.Profesional where nombre_rol is not null
		order by nombre_rol
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ComboRolesDeUnUsuario') is not null DROP PROCEDURE LOS_TRIGGERS.ComboRolesDeUnUsuario
GO
CREATE PROC LOS_TRIGGERS.ComboRolesDeUnUsuario(@usuario numeric(18,0)) AS
	BEGIN
		select nombre_rol as rol from LOS_TRIGGERS.Afiliado, LOS_TRIGGERS.Usuario where user_id=@usuario AND afil_numero=user_afiliado AND afil_habilitacion=1
		UNION select nombre_rol from LOS_TRIGGERS.Administrador, LOS_TRIGGERS.Usuario where user_id=@usuario AND admi_id=user_administrador AND admi_habilitacion=1
		UNION select nombre_rol from LOS_TRIGGERS.Profesional, LOS_TRIGGERS.Usuario where user_id=@usuario AND prof_id=user_profesional AND prof_habilitacion=1
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
CREATE PROC LOS_TRIGGERS.ModificarRol (@rol varchar(255), @nuevo_nombre varchar(255)) AS
	BEGIN
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
		CREATE TABLE [LOS_TRIGGERS].[Administrador](
			[admi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
			[admi_habilitacion] [bit] NULL,
			[nombre_rol] [varchar](255) NULL
		);
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.AltaRolAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRolAfiliado
GO
CREATE PROC LOS_TRIGGERS.AltaRolAfiliado AS
	BEGIN
	IF OBJECT_ID ('LOS_TRIGGERS.Afiliado') IS NOT NULL DROP TABLE LOS_TRIGGERS.Afiliado
	CREATE TABLE [LOS_TRIGGERS].[Afiliado](
		[afil_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
		[afil_estado_civil] [varchar](255) NULL,
		[afil_habilitacion] [bit] NULL,
		[nombre_rol] [varchar](255) NULL,
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
	CREATE TABLE [LOS_TRIGGERS].[Profesional](
		[prof_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
		[prof_matricula] [numeric](18, 0) NULL,
		[prof_horas_laborales] [numeric](2, 0) NULL,
		[nombre_rol] [varchar](255) NULL,
		[prof_habilitacion] [bit] NULL
	);
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.AltaRol') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRol
GO
CREATE PROC LOS_TRIGGERS.AltaRol (@rol varchar(255)) AS
	BEGIN
		IF (@rol='Afiliado') EXEC LOS_TRIGGERS.AltaRolAfiliado
		ELSE IF (@rol='Administrador') EXEC LOS_TRIGGERS.AltaRolAdministrador
		ELSE IF (@rol='Profesional') EXEC LOS_TRIGGERS.AltaRolProfesional
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.InhabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.InhabilitarRol
GO
CREATE PROC LOS_TRIGGERS.InhabilitarRol (@rol varchar(255)) AS
	BEGIN
		IF (@rol='Afiliado')
			BEGIN
				update LOS_TRIGGERS.Afiliado set afil_habilitacion = 0
				update LOS_TRIGGERS.Usuario set user_afiliado = null where user_afiliado is not null
			END
		ELSE IF (@rol='Administrador')
			BEGIN
				update LOS_TRIGGERS.Administrador set admi_habilitacion = 0
				update LOS_TRIGGERS.Usuario set user_administrador = null where user_administrador is not null
			END
		ELSE IF (@rol='Profesional')
			BEGIN
				update LOS_TRIGGERS.Profesional set prof_habilitacion = 0
				update LOS_TRIGGERS.Usuario set user_profesional = null where user_profesional is not null
			END
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.HabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.HabilitarRol
GO
CREATE PROC LOS_TRIGGERS.HabilitarRol (@rol varchar(255)) AS
	BEGIN
		IF (@rol='Afiliado')
			update LOS_TRIGGERS.Afiliado set afil_habilitacion = 1
		ELSE IF (@rol='Administrador')
			update LOS_TRIGGERS.Administrador set admi_habilitacion = 1
		ELSE IF (@rol='Profesional')
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

		IF (@rol='Afiliado' AND NOT EXISTS (select func_rol_id from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND afiliado is not null))
			insert into LOS_TRIGGERS.Funcionalidad_Rol(funcionalidad, afiliado) select @func_id, afil_numero from LOS_TRIGGERS.Afiliado
		ELSE IF (@rol='Administrador' AND NOT EXISTS (select func_rol_id from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND administrador is not null))
			insert into LOS_TRIGGERS.Funcionalidad_Rol(funcionalidad, administrador) select @func_id, admi_id from LOS_TRIGGERS.Administrador
		ELSE IF (@rol='Profesional' AND NOT EXISTS (select func_rol_id from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND profesional is not null))
			insert into LOS_TRIGGERS.Funcionalidad_Rol(funcionalidad, profesional) select @func_id, prof_id from LOS_TRIGGERS.Profesional
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.QuitarFuncionalidadAUnRol') is not null DROP PROCEDURE LOS_TRIGGERS.QuitarFuncionalidadAUnRol
GO
CREATE PROC LOS_TRIGGERS.QuitarFuncionalidadAUnRol (@rol varchar(255), @funcionalidad varchar(255)) AS
BEGIN
		declare @func_id as numeric(18,0)
		set @func_id = (select func_id from LOS_TRIGGERS.Funcionalidad where func_nombre=@funcionalidad)

		IF (@rol='Afiliado')
			delete from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND afiliado IN (select afil_numero from LOS_TRIGGERS.Afiliado)
		ELSE IF (@rol='Administrador')
			delete from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND administrador IN (select admi_id from LOS_TRIGGERS.Administrador)
		ELSE IF (@rol='Profesional')
			delete from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func_id AND profesional IN (select prof_id from LOS_TRIGGERS.Profesional)
END;
GO

-- << Carga de Funcionalidades a los Roles >>
/*
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'ABM de Rol'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'ABM de Afiliado'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'ABM de Profesional'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'ABM de Plan'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'ABM de Especialidad Médica'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'Registro de Usuario'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'Registro de Agenda de Profesional'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'Compra de Bono'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Administrador', 'Listado Estadístico'

EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Profesional', 'Registro de Agenda de Profesional'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Profesional', 'Registro de Consulta Médica'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Profesional', 'Registro de Diagnóstico Médico'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Profesional', 'Cancelación de Turno'

EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Afiliado', 'Compra de Bono'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Afiliado', 'Pedido de Turno'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol 'Afiliado', 'Cancelación de Turno'
*/
--- << Pedido de un Turno >> ---
IF OBJECT_ID ('LOS_TRIGGERS.ComboProfesionales') is not null DROP PROCEDURE LOS_TRIGGERS.ComboProfesionales
GO
CREATE PROC LOS_TRIGGERS.ComboProfesionales AS
	BEGIN
		select user_profesional, user_apellido+', '+user_nombre as apellido_y_nombre
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

IF OBJECT_ID ('LOS_TRIGGERS.PedirTurno') is not null DROP PROCEDURE LOS_TRIGGERS.PedirTurno
GO
CREATE PROC LOS_TRIGGERS.PedirTurno (@afiliado numeric(18,00), @profesional numeric(18,00), @especialidad numeric(18,0), @fecha date, @hora varchar(255)) AS
BEGIN
		IF (NOT EXISTS (select turn_numero from LOS_TRIGGERS.Turno where CAST(turn_fecha as date)=@fecha AND turn_hora_inicio=@hora)
			AND NOT EXISTS (select canc_id from LOS_TRIGGERS.Cancelacion_Turno where CAST(canc_fecha_turno as date)=@fecha AND canc_hora_turno=@hora))
				insert into LOS_TRIGGERS.Turno (turn_afiliado, turn_especialidad_profesional, turn_fecha, turn_nombre_dia, turn_hora_inicio, turn_hora_fin)
					select @afiliado, (select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=@profesional AND especialidad=@especialidad), cast(@fecha as datetime)+cast(@hora as datetime),
						datename(weekday, @fecha), @hora, format(dateadd(minute, 30, cast(@hora as datetime)), 'HH:mm')
		ELSE PRINT 'Ya hay un turno asignado para ese horario.'
END
GO

--- << Cancelación de un Turno >> ---
-- OBS.: Muestra todos los turnos asignados a partir de la fecha actual, no pasados
IF OBJECT_ID ('LOS_TRIGGERS.TurnosAsignadosAUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.TurnosAsignadosAUnAfiliado
GO
CREATE PROC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado (@afiliado numeric(18,0)) AS
	BEGIN
		select turn_numero, user_apellido+', '+user_nombre as profesional, espe_descripcion, CONVERT(date, turn_fecha) as fecha, turn_nombre_dia, turn_hora_inicio
		from LOS_TRIGGERS.Turno, LOS_TRIGGERS.Usuario, LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad
		where turn_afiliado=@afiliado AND turn_fecha >= GETDATE() AND espe_prof_id=turn_especialidad_profesional AND espe_codigo=especialidad AND user_profesional=profesional
		order by turn_fecha, turn_hora_inicio
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurnoAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurnoAfiliado
GO
CREATE PROC LOS_TRIGGERS.CancelarTurnoAfiliado (@afiliado numeric(18,0), @turno numeric(18,0), @tipo_canc numeric(18,0), @motivo varchar(255)) AS
BEGIN
	insert into LOS_TRIGGERS.Cancelacion_Turno (canc_afiliado, canc_emisor_afiliado, canc_especialidad_profesional, canc_fecha_turno, canc_hora_turno, canc_fecha_y_hora, canc_tipo, canc_motivo)
		select @afiliado, @afiliado, turn_especialidad_profesional, turn_fecha, turn_hora_inicio, GETDATE(), @tipo_canc, @motivo
		from LOS_TRIGGERS.Turno where turn_numero=@turno

	delete from LOS_TRIGGERS.Turno where turn_numero=@turno
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular
GO
CREATE PROC LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular (@profesional numeric(18,0), @turno numeric(18,0), @tipo_canc numeric(18,0), @motivo varchar(255)) AS
BEGIN
	insert into LOS_TRIGGERS.Cancelacion_Turno (canc_afiliado, canc_emisor_profesional, canc_especialidad_profesional, canc_fecha_turno, canc_hora_turno, canc_fecha_y_hora, canc_tipo, canc_motivo)
		select turn_afiliado, @profesional, turn_especialidad_profesional, turn_fecha, turn_hora_inicio, GETDATE(), @tipo_canc, @motivo
		from LOS_TRIGGERS.Turno where turn_numero=@turno

	delete from LOS_TRIGGERS.Turno where turn_numero=@turno
END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo
GO
CREATE PROC LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo (@profesional numeric(18,0), @desde date, @hasta date, @tipo_canc numeric(18,0), @motivo varchar(255)) AS
BEGIN
	declare @turno as numeric(18,0)
	declare CANCELACIONES cursor for select turn_numero from LOS_TRIGGERS.Turno, LOS_TRIGGERS.Especialidad_Profesional
									where espe_prof_id=turn_especialidad_profesional AND profesional=@profesional AND (turn_fecha BETWEEN @desde AND @hasta)
	OPEN CANCELACIONES
	FETCH NEXT FROM CANCELACIONES INTO @turno
	WHILE @@fetch_status = 0
	BEGIN
			EXEC LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular @profesional=@profesional, @turno=@turno, @tipo_canc=@tipo_canc, @motivo=@motivo

		FETCH NEXT FROM CANCELACIONES INTO @turno
	END
CLOSE CANCELACIONES
DEALLOCATE CANCELACIONES
END;
GO
/*
IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurno') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurno
GO
CREATE PROC LOS_TRIGGERS.CancelarTurno (@usuario numeric(18,0), @turno numeric(18,0), @tipo_canc numeric(18,0), @motivo varchar(255)) AS
BEGIN
	declare @rol_id as numeric(18,0), @cancelacion as numeric(18,0)

	IF EXISTS (select user_profesional from LOS_TRIGGERS.Usuario where user_id=@usuario)
		set @rol_id = (select user_profesional from LOS_TRIGGERS.Usuario where user_id=@usuario)
	ELSE IF EXISTS (select user_afiliado from LOS_TRIGGERS.Usuario where user_id=@usuario)
		set @rol_id = (select user_afiliado from LOS_TRIGGERS.Usuario where user_id=@usuario)

	insert into LOS_TRIGGERS.Cancelacion_Turno (canc_afiliado, canc_especialidad_profesional, canc_fecha_turno, canc_fecha_y_hora, canc_tipo, canc_motivo, canc_hora_turno)
		select turn_afiliado, espe_prof_id, turn_fecha, GETDATE(), @tipo_canc, @motivo, turn_hora_inicio
		from LOS_TRIGGERS.Turno, LOS_TRIGGERS.Especialidad_Profesional where turn_numero=@turno AND espe_prof_id=turn_especialidad_profesional

	-- Seteo al emisor:
	set @cancelacion = (select SCOPE_IDENTITY())
	IF(@rol_id = (select turn_afiliado from LOS_TRIGGERS.Turno where turn_numero=@turno))
		update LOS_TRIGGERS.Cancelacion_Turno set canc_emisor_afiliado=@rol_id where canc_id=@cancelacion
	ELSE
		update LOS_TRIGGERS.Cancelacion_Turno set canc_emisor_profesional=@rol_id where canc_id=@cancelacion

	delete from LOS_TRIGGERS.Turno where turn_numero=@turno

END;
GO
*/
--- << Registrar la Agenda de un Profesional >> ---
-- 1) Determinar Profesional
-- 2) Determinar Especialidad
-- 3) Determinar día de atención
-- 4) Determinar rango horario (con turnos c/30 min)
-- 5) Verificar que no acumule más de 48hs p/semana
-- 6) Determinar fechas de disponibilidad
-- ** Una vez cargada, la agenda es inalterable **
IF OBJECT_ID ('LOS_TRIGGERS.DiasDeAtencionDeLaClinica') is not null DROP VIEW LOS_TRIGGERS.DiasDeAtencionDeLaClinica
GO
CREATE VIEW LOS_TRIGGERS.DiasDeAtencionDeLaClinica AS
	select dia_nombre_dia from LOS_TRIGGERS.Dia_Atencion where dia_clinica is not null
WITH CHECK OPTION
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
	ELSE PRINT 'El profesional no puede sumar más de 48 hs laborales.'
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
	ELSE PRINT 'El rango hrario es inválido o no está dentro del resto de este año.'
END;
GO

-- << Listado Estadístico >> (a y c)
IF OBJECT_ID ('LOS_TRIGGERS.EspecialidadeConMasCancelaciones') is not null DROP PROCEDURE LOS_TRIGGERS.EspecialidadeConMasCancelaciones
GO
CREATE PROC LOS_TRIGGERS.EspecialidadeConMasCancelaciones (@anio datetime, @semestre integer) AS
	BEGIN
		declare @mes as integer
		IF (@semestre = 1) set @mes = 1
		ELSE IF (@semestre = 2) set @mes = 7

		select TOP 5 espe_codigo, espe_descripcion, ISNULL(COUNT(canc_id), 0) as cantidad_cancelaciones
		from LOS_TRIGGERS.Cancelacion_Turno, LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Especialidad
		where espe_prof_id=canc_especialidad_profesional AND espe_codigo=especialidad
			AND year(canc_fecha_y_hora)=@anio AND (month(canc_fecha_y_hora) BETWEEN @mes AND @mes+5)
		group by espe_codigo, espe_descripcion order by 3 DESC
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ProfesionalesConMenosHorasTrabajadas') is not null DROP PROCEDURE LOS_TRIGGERS.ProfesionalesConMenosHorasTrabajadas
GO
CREATE PROC LOS_TRIGGERS.ProfesionalesConMenosHorasTrabajadas (@anio datetime, @semestre integer, @plan numeric(18,0), @especialidad numeric(18,0)) AS
	BEGIN
		declare @mes as integer
		IF (@semestre = 1) set @mes = 1
		ELSE IF (@semestre = 2) set @mes = 7

		select TOP 5 profesional, user_apellido+', '+user_nombre as nombre_y_apellido, ISNULL((COUNT(turn_numero)*30)/60, 0) as cantidad_horas_trabajadas
		from  LOS_TRIGGERS.Turno, LOS_TRIGGERS.Especialidad_Profesional, LOS_TRIGGERS.Usuario, LOS_TRIGGERS.Afiliado, LOS_TRIGGERS.Plan_Medico
		where turn_fecha_y_hora_asistencia is not null AND espe_prof_id=turn_especialidad_profesional AND especialidad=@especialidad
			AND user_profesional=profesional AND afil_numero=turn_afiliado AND afil_plan_medico=@plan
			AND year(turn_fecha)=@anio AND (month(turn_fecha) BETWEEN @mes AND @mes+5)
		group by profesional, user_apellido+', '+user_nombre order by 3 ASC
	END;
GO