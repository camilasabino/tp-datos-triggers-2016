USE [GD2C2016]
GO

/*************************************************************************************
*				     INICIALIZACIÓN DE LA BASE DE DATOS                              *
**************************************************************************************/

--- CREACIÓN DEL ESQUEMA ---
IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'LOS_TRIGGERS'))
	BEGIN
		EXEC (N'CREATE SCHEMA [LOS_TRIGGERS] AUTHORIZATION [gd]')
		PRINT 'El esquema LOS_TRIGGERS ha sido creado.'
	END
GO

--- VERIFICAR Y RESTABLECER TABLAS ANTERIORES ---
IF OBJECT_ID ('LOS_TRIGGERS.Funcionalidad_Rol') IS NOT NULL DROP TABLE LOS_TRIGGERS.Funcionalidad_Rol
IF OBJECT_ID ('LOS_TRIGGERS.Funcionalidad') IS NOT NULL DROP TABLE LOS_TRIGGERS.Funcionalidad
IF OBJECT_ID ('LOS_TRIGGERS.Usuario') IS NOT NULL DROP TABLE LOS_TRIGGERS.Usuario
IF OBJECT_ID ('LOS_TRIGGERS.Administrador') IS NOT NULL DROP TABLE LOS_TRIGGERS.Administrador
IF OBJECT_ID ('LOS_TRIGGERS.Modificacion_Plan') IS NOT NULL DROP TABLE LOS_TRIGGERS.Modificacion_Plan
IF OBJECT_ID ('LOS_TRIGGERS.Compra_Bono') IS NOT NULL DROP TABLE LOS_TRIGGERS.Compra_Bono
IF OBJECT_ID ('LOS_TRIGGERS.Bono') IS NOT NULL DROP TABLE LOS_TRIGGERS.Bono
IF OBJECT_ID ('LOS_TRIGGERS.Baja_Afiliado') IS NOT NULL DROP TABLE LOS_TRIGGERS.Baja_Afiliado
IF OBJECT_ID ('LOS_TRIGGERS.Consulta_Medica') IS NOT NULL DROP TABLE LOS_TRIGGERS.Consulta_Medica
IF OBJECT_ID ('LOS_TRIGGERS.Diagnostico') IS NOT NULL DROP TABLE LOS_TRIGGERS.Diagnostico
IF OBJECT_ID ('LOS_TRIGGERS.Turno') IS NOT NULL DROP TABLE LOS_TRIGGERS.Turno
IF OBJECT_ID ('LOS_TRIGGERS.Cancelacion_Turno') IS NOT NULL DROP TABLE LOS_TRIGGERS.Cancelacion_Turno
IF OBJECT_ID ('LOS_TRIGGERS.Tipo_Cancelacion') IS NOT NULL DROP TABLE LOS_TRIGGERS.Tipo_Cancelacion
IF OBJECT_ID ('LOS_TRIGGERS.Dia_Atencion') IS NOT NULL DROP TABLE LOS_TRIGGERS.Dia_Atencion
IF OBJECT_ID ('LOS_TRIGGERS.Horario_Atencion') IS NOT NULL DROP TABLE LOS_TRIGGERS.Horario_Atencion
IF OBJECT_ID ('LOS_TRIGGERS.Clinica') IS NOT NULL DROP TABLE LOS_TRIGGERS.Clinica
IF OBJECT_ID ('LOS_TRIGGERS.Especialidad_Profesional') IS NOT NULL DROP TABLE LOS_TRIGGERS.Especialidad_Profesional
IF OBJECT_ID ('LOS_TRIGGERS.Especialidad') IS NOT NULL DROP TABLE LOS_TRIGGERS.Especialidad
IF OBJECT_ID ('LOS_TRIGGERS.Tipo_Especialidad') IS NOT NULL DROP TABLE LOS_TRIGGERS.Tipo_Especialidad
IF OBJECT_ID ('LOS_TRIGGERS.Profesional') IS NOT NULL DROP TABLE LOS_TRIGGERS.Profesional
IF OBJECT_ID ('LOS_TRIGGERS.Afiliado') IS NOT NULL DROP TABLE LOS_TRIGGERS.Afiliado
IF OBJECT_ID ('LOS_TRIGGERS.Plan_Medico') IS NOT NULL DROP TABLE LOS_TRIGGERS.Plan_Medico
PRINT 'Las tablas del sistema han sido restablecidas.'
GO

--- CREACIÓN DE NUEVAS TABLAS ---

--- << Administrador >>
CREATE TABLE [LOS_TRIGGERS].[Administrador](
	[admi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[admi_habilitacion] [bit] NULL,
	[nombre_rol] [varchar](255) NULL
	);

--- << Información útil sobre la Clínica >>
CREATE TABLE [LOS_TRIGGERS].[Clinica](
	[clin_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[clin_nombre] [varchar](255) NULL
	);

--- << Funcionalidad >>
CREATE TABLE [LOS_TRIGGERS].[Funcionalidad](
	[func_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[func_nombre] [varchar](127) NULL
	);

--- << Diagnóstico >>
CREATE TABLE [LOS_TRIGGERS].[Diagnostico](
	[diag_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[diag_fecha_y_hora] [datetime] NULL,
	[diag_sintomas] [varchar](255) NULL,
	[diag_descripcion] [varchar](255) NULL
	);

--- << Plan Médico >>
CREATE TABLE [LOS_TRIGGERS].[Plan_Medico](
	[plan_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[plan_precio_bono_consulta] [numeric](18, 0) NULL,
	[plan_precio_bono_farmacia] [numeric](18, 0) NULL,
	[plan_med_descripcion] [varchar](255) NULL
	);

--- << Profesional >>
CREATE TABLE [LOS_TRIGGERS].[Profesional](
	[prof_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[prof_matricula] [numeric](18, 0) NULL,
	[prof_horas_laborales] [numeric](2, 0) NULL,
	[nombre_rol] [varchar](255) NULL,
	[prof_habilitacion] [bit] NULL
	);

--- << Tipo Cancelación de Turno >>
CREATE TABLE [LOS_TRIGGERS].[Tipo_Cancelacion](
	[tipo_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[tipo_descripcion] [varchar](255) NULL
	);

--- << Tipo Especialidad >>
CREATE TABLE [LOS_TRIGGERS].[Tipo_Especialidad](
	[tipo_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[tipo_descripcion] [varchar](255) NULL
	);

--- << Especialidad >>
CREATE TABLE [LOS_TRIGGERS].[Especialidad](  
	[espe_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[espe_descripcion] [varchar](255) NULL,
	[espe_tipo] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Tipo_Especialidad
	);

--- << Afiliado >>
CREATE TABLE [LOS_TRIGGERS].[Afiliado](
	[afil_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[afil_estado_civil] [varchar](255) NULL,
	[afil_habilitacion] [bit] NULL,
	[nombre_rol] [varchar](255) NULL,
	[afil_titular_grupo_familiar] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[afil_plan_medico] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Plan_Medico,
	[afil_cant_consultas_realizadas] [numeric](18, 0) NULL,
	[afil_cant_familiares_a_cargo] [numeric](2, 0) NULL,
	[afil_relacion_con_titular] [varchar](255) NULL
	);

--- << Baja Afiliado >>
CREATE TABLE [LOS_TRIGGERS].[Baja_Afiliado](
	[baja_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[baja_fecha] [datetime] NULL,
	[baja_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado
	);

--- << Modificación Plan >>
CREATE TABLE [LOS_TRIGGERS].[Modificacion_Plan](
	[modi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[modi_fecha_y_hora] [datetime] NULL,
	[modi_motivo] [varchar](255) NULL,
	[modi_viejo_plan] [varchar](255) NULL,
	[modi_nuevo_plan] [varchar](255) NULL,
	[modi_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado
	);

--- << Funcionalidad Rol >>
CREATE TABLE [LOS_TRIGGERS].[Funcionalidad_Rol](
	[func_rol_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[administrador] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Administrador,
	[profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Profesional,
	[funcionalidad] [numeric](18, 0) NOT NULL foreign key references LOS_TRIGGERS.Funcionalidad
	);

--- << Especialidad Profesional >>
CREATE TABLE [LOS_TRIGGERS].[Especialidad_Profesional](
	[espe_prof_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[profesional] [numeric](18, 0) NOT NULL foreign key references LOS_TRIGGERS.Profesional,
	[especialidad] [numeric](18, 0) NOT NULL foreign key references LOS_TRIGGERS.Especialidad,
	[disponible_desde_fecha] [date] NULL,
	[disponible_hasta_fecha] [date] NULL
	);

--- << Día de Atención >>
CREATE TABLE [LOS_TRIGGERS].[Dia_Atencion](
	[dia_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[dia_especialidad_profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Especialidad_Profesional,
	[dia_clinica] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Clinica,
	[dia_nombre_dia] [varchar](255) NULL,
	[dia_hora_inicio] [varchar](255) NULL,
	[dia_hora_fin] [varchar](255) NULL
	);

--- << Horario de Atención >>
CREATE TABLE [LOS_TRIGGERS].[Horario_Atencion](
	[hora_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[hora_especialidad_profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Especialidad_Profesional,
	[hora_nombre_dia] [varchar](255) NULL,
	[hora_fecha] [varchar](255) NULL,
	[hora_inicio] [varchar](255) NULL,
	[hora_fin] [varchar](255) NULL,
	[hora_disponible] [bit] NULL
	);

--- << Turno >>
CREATE TABLE [LOS_TRIGGERS].[Turno](
	[turn_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[turn_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[turn_especialidad_profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Especialidad_Profesional,
	[turn_fecha] [datetime] NULL,
	[turn_nombre_dia] [varchar](255) NULL,
	[turn_hora_inicio] [varchar](255) NULL,
	[turn_hora_fin] [varchar](255) NULL,
	[turn_fecha_y_hora_asistencia] [datetime] NULL
	);

--- << Consulta Médica >>
CREATE TABLE [LOS_TRIGGERS].[Consulta_Medica](
	[cons_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[cons_turno] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Turno,
	[cons_diagnostico] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Diagnostico
	);

--- << Bono >>
CREATE TABLE [LOS_TRIGGERS].[Bono](
	[bono_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[bono_plan_medico] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Plan_Medico,
	[bono_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[bono_consulta_medica] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Consulta_Medica,
	[bono_fecha_impresion] [datetime] NULL
	);

--- << Cancelación Turno >>
CREATE TABLE [LOS_TRIGGERS].[Cancelacion_Turno](
	[canc_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[canc_especialidad_profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Especialidad_Profesional,
	[canc_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[canc_emisor_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[canc_emisor_profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Profesional,
	[canc_fecha_y_hora] [datetime] NULL,
	[canc_fecha_turno] [datetime] NULL,
	[canc_hora_turno] [varchar](255) NULL,
	[canc_motivo] [varchar](255) NULL,
	[canc_tipo] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Tipo_Cancelacion
	);

--- << Compra Bono >>
CREATE TABLE [LOS_TRIGGERS].[Compra_Bono](
	[comp_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[comp_bono] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Bono,
	[comp_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[comp_monto] [numeric](18, 0) NULL,
	[comp_cantidad] [numeric](4, 0) NULL,
	[comp_fecha_y_hora] [datetime] NULL
	);

--- << Usuario >>
CREATE TABLE [LOS_TRIGGERS].[Usuario](
	[user_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL primary key,
	[user_name] [varchar](255) NULL,
	[user_password] [varbinary](300) NULL,
	[user_intentos_fallidos_login] [numeric](1, 0) NULL,
	[user_nombre] [varchar](255) NULL,
	[user_apellido] [varchar](255) NULL,
	[user_dni] [numeric](18, 0) NULL,
	[user_telefono] [numeric](18, 0) NULL,
	[user_mail] [varchar](255) NULL,
	[user_fecha_nacimiento] [datetime] NULL,
	[user_sexo] [char](3) NULL,
	[user_direccion] [varchar](255) NULL,
	[user_afiliado] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Afiliado,
	[user_profesional] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Profesional,
	[user_administrador] [numeric](18, 0) NULL foreign key references LOS_TRIGGERS.Administrador
	);

PRINT 'Fin de la CREACIÓN de tablas.'
GO

/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/
-- En scripts separados (por ahora)

/*************************************************************************************
*			         MIGRACIÓN (de tabla Maestra al Sistema)                          *
**************************************************************************************/
PRINT 'Comienza la MIGRACIÓN.'
GO

SET DATEFIRST 7 -- Domingo

--- << Planes Médicos >>
SET IDENTITY_INSERT LOS_TRIGGERS.Plan_Medico ON
insert into LOS_TRIGGERS.Plan_Medico (plan_id, plan_med_descripcion, plan_precio_bono_consulta, plan_precio_bono_farmacia)
	select distinct(Plan_Med_Codigo), Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
	from gd_esquema.Maestra where Plan_Med_Codigo is not null
SET IDENTITY_INSERT LOS_TRIGGERS.Plan_Medico OFF
PRINT '1. Tabla Plan Médico OK'
GO

--- << Tipos de Especialidad >>
SET IDENTITY_INSERT LOS_TRIGGERS.Tipo_Especialidad ON
insert into LOS_TRIGGERS.Tipo_Especialidad (tipo_id, tipo_descripcion)
	select distinct(Tipo_Especialidad_Codigo), Tipo_Especialidad_Descripcion from gd_esquema.Maestra
	where Tipo_Especialidad_Codigo is not null
SET IDENTITY_INSERT LOS_TRIGGERS.Tipo_Especialidad OFF
PRINT '2. Tabla Tipo_Especialidad OK'
GO

--- << Especialidades >>
SET IDENTITY_INSERT LOS_TRIGGERS.Especialidad ON
insert into LOS_TRIGGERS.Especialidad (espe_codigo, espe_descripcion, espe_tipo)
	select distinct(Especialidad_Codigo), Especialidad_Descripcion, Tipo_Especialidad_Codigo
	from gd_esquema.Maestra where Especialidad_Codigo is not null
SET IDENTITY_INSERT LOS_TRIGGERS.Especialidad OFF
PRINT '3. Tabla Especialidad OK'
GO

--- << Afiliados >>
SET IDENTITY_INSERT LOS_TRIGGERS.Afiliado ON
declare @dni as numeric(18,0), @direccion as varchar(255), @mail as varchar(255), @nombre as varchar(255), @nro_afiliado as numeric(18,0),
		@apellido as varchar(255), @nacimiento as datetime, @telefono as numeric(18,0), @plan as numeric(18,0)
declare AFILIADOS cursor for select distinct (Paciente_Dni), Paciente_Direccion, Paciente_Mail, Paciente_Nombre, Paciente_Apellido, Paciente_Fecha_Nac, Paciente_Telefono, Plan_Med_Codigo
							from gd_esquema.Maestra where Paciente_Dni is not null
OPEN AFILIADOS
FETCH NEXT FROM AFILIADOS INTO @dni, @direccion, @mail, @nombre, @apellido, @nacimiento, @telefono, @plan
WHILE @@fetch_status = 0
	BEGIN
		set @nro_afiliado = CONVERT(numeric(18,0), CAST(@dni as varchar) + '01')
		insert into LOS_TRIGGERS.Afiliado (afil_numero, afil_habilitacion, afil_cant_consultas_realizadas, afil_plan_medico, afil_titular_grupo_familiar, nombre_rol, afil_cant_familiares_a_cargo, afil_relacion_con_titular)
			values (@nro_afiliado, 1, 0, @plan, @nro_afiliado, 'Afiliado', 0, 'Titular')
	
		insert into LOS_TRIGGERS.Usuario (user_name, user_password, user_afiliado, user_intentos_fallidos_login, user_dni, user_direccion, user_mail, user_nombre, user_apellido, user_fecha_nacimiento, user_telefono)
			select CONVERT(varchar(255), @dni), HASHBYTES('SHA2_256', CONVERT(varchar(255), @dni)), @nro_afiliado, 0, @dni, @direccion, @mail, @nombre, @apellido, @nacimiento, @telefono
		
		FETCH NEXT FROM AFILIADOS INTO @dni, @direccion, @mail, @nombre, @apellido, @nacimiento, @telefono, @plan
	END
CLOSE AFILIADOS
DEALLOCATE AFILIADOS
GO
SET IDENTITY_INSERT LOS_TRIGGERS.Afiliado OFF
PRINT '4. Tabla Afiliado OK'
GO

--- << Profesionales >>
SET IDENTITY_INSERT LOS_TRIGGERS.Profesional ON
declare @dni as numeric(18,0), @direccion as varchar(255), @mail as varchar(255), @nombre as varchar(255),
		@apellido as varchar(255), @nacimiento as datetime, @telefono as numeric(18,0), @nro_profesional as numeric(18,0)

declare PROFESIONALES cursor for select distinct (Medico_Dni), Medico_Direccion, Medico_Mail, Medico_Nombre,
				Medico_Apellido, Medico_Fecha_Nac, Medico_Telefono from gd_esquema.Maestra where Medico_Dni is not null
OPEN PROFESIONALES
FETCH NEXT FROM PROFESIONALES INTO @dni, @direccion, @mail, @nombre, @apellido, @nacimiento, @telefono
WHILE @@fetch_status = 0
	BEGIN
		set @nro_profesional = CONVERT(numeric(18,0), CAST(@dni as varchar) + '99')
		insert into LOS_TRIGGERS.Profesional(prof_id, prof_habilitacion, prof_horas_laborales, nombre_rol)
			values (@nro_profesional, 1, 0, 'Profesional')
		
		insert into LOS_TRIGGERS.Usuario (user_name, user_password, user_profesional, user_intentos_fallidos_login, user_dni, user_direccion, user_mail, user_nombre, user_apellido, user_fecha_nacimiento, user_telefono)
			select CONVERT(varchar(255), CONVERT(int, @dni)), HASHBYTES('SHA2_256', CONVERT(varchar(255), CONVERT(int, @dni))), @nro_profesional, 0, @dni, @direccion, @mail, @nombre, @apellido, @nacimiento, @telefono

		FETCH NEXT FROM PROFESIONALES INTO @dni, @direccion, @mail, @nombre, @apellido, @nacimiento, @telefono
	END
CLOSE PROFESIONALES
DEALLOCATE PROFESIONALES
SET IDENTITY_INSERT LOS_TRIGGERS.Profesional OFF
PRINT '5. Tabla Profesional OK'
GO

-- << Especialidad_Profesional >>
insert into LOS_TRIGGERS.Especialidad_Profesional(especialidad, profesional)
select distinct(Especialidad_Codigo), CONVERT(numeric(18,0), CAST(Medico_Dni as varchar) + '99')
from gd_esquema.Maestra where Medico_Dni is not null
PRINT '6. Tabla Especialidad_Profesional OK'
GO

--- << Bonos >>
SET IDENTITY_INSERT LOS_TRIGGERS.Bono ON
insert into LOS_TRIGGERS.Bono (bono_numero, bono_fecha_impresion, bono_afiliado, bono_plan_medico)
	select distinct(Bono_Consulta_Numero), Bono_Consulta_Fecha_Impresion, CONVERT(numeric(18,0), CAST(Paciente_Dni as varchar) + '01'), Plan_Med_Codigo
	from gd_esquema.Maestra where Bono_Consulta_Numero is not null
SET IDENTITY_INSERT LOS_TRIGGERS.Bono OFF
PRINT '7. Tabla Bono OK'
GO

--- << Compras de Bonos >>
insert into LOS_TRIGGERS.Compra_Bono (comp_bono, comp_fecha_y_hora, comp_afiliado, comp_monto, comp_cantidad)
	select distinct(Bono_Consulta_Numero), Compra_Bono_Fecha, CONVERT(numeric(18,0), CAST(Paciente_Dni as varchar) + '01'), Plan_Med_Precio_Bono_Consulta, 1
	from gd_esquema.Maestra where Compra_Bono_Fecha is not null
PRINT '8. Tabla Compra_Bono OK'
GO

--- << Turnos, Consultas Médicas & Diagnósticos >>
SET IDENTITY_INSERT LOS_TRIGGERS.Turno ON
declare @turno as numeric(18,0), @fecha_turno as datetime, @sintomas as varchar(255), @descripcion as varchar(255), @bono as numeric(18,0), @profesional as numeric(18,0), @especialidad as numeric(18,0)
declare TURNOS cursor for select distinct (Turno_Numero), Turno_Fecha, Consulta_Sintomas, Consulta_Enfermedades, Bono_Consulta_Numero, Medico_Dni, Especialidad_Codigo
							from gd_esquema.Maestra where Turno_Numero is not null AND Bono_Consulta_Numero is not null
OPEN TURNOS
FETCH NEXT FROM TURNOS INTO @turno, @fecha_turno, @sintomas, @descripcion, @bono, @profesional, @especialidad
WHILE @@fetch_status = 0
	BEGIN
			insert into LOS_TRIGGERS.Turno (turn_numero, turn_fecha, turn_nombre_dia, turn_hora_inicio, turn_hora_fin, turn_especialidad_profesional)
				select @turno, @fecha_turno, datename(weekday, @fecha_turno), FORMAT(@fecha_turno, 'HH:mm'), FORMAT(dateadd(minute, 30, @fecha_turno), 'HH:mm'), espe_prof_id
				from LOS_TRIGGERS.Especialidad_Profesional where especialidad=@especialidad AND profesional=CONVERT(numeric(18,0), CAST(@profesional as varchar) + '99')
			
			insert into LOS_TRIGGERS.Diagnostico (diag_sintomas, diag_descripcion) values(@sintomas, @descripcion)
				
			insert into LOS_TRIGGERS.Consulta_Medica (cons_diagnostico, cons_turno) values ((select SCOPE_IDENTITY()), @turno)
				
			update LOS_TRIGGERS.Bono
				set bono_consulta_medica=(select SCOPE_IDENTITY()) where bono_numero=@bono

		FETCH NEXT FROM TURNOS INTO @turno, @fecha_turno, @sintomas, @descripcion, @bono, @profesional, @especialidad
	END
CLOSE TURNOS
DEALLOCATE TURNOS
SET IDENTITY_INSERT LOS_TRIGGERS.Turno OFF
PRINT '9. Tabla Turno OK'
GO

-- << Afiliados y Profesionales en Turnos >>
declare @turno as numeric(18,0), @afiliado as numeric(18,0), @profesional as numeric(18,0), @especialidad as numeric(18,0)
declare TURNOS cursor for select distinct (Turno_Numero), Paciente_Dni, Medico_Dni, Especialidad_Codigo from gd_esquema.Maestra where Turno_Numero is not null
OPEN TURNOS
FETCH NEXT FROM TURNOS INTO @turno, @afiliado, @profesional, @especialidad
WHILE @@fetch_status = 0
	BEGIN
			update LOS_TRIGGERS.Turno
				set turn_afiliado=CONVERT(numeric(18,0), CAST(@afiliado as varchar) + '01'), turn_especialidad_profesional=(select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=CONVERT(numeric(18,0), CAST(@profesional as varchar) + '99') AND especialidad=@especialidad)
				where turn_numero=@turno

		FETCH NEXT FROM TURNOS INTO @turno, @afiliado, @profesional, @especialidad
	END
CLOSE TURNOS
DEALLOCATE TURNOS
PRINT '11. Carga Profesionales y Afiliados en Turnos OK'
GO

-- << Cantidad de Consultas realizadas por Afiliado >>
declare @afiliado as numeric(18,0), @consultas as int
declare CONSULTAS cursor for select turn_afiliado, COUNT(distinct(cons_numero))
					from gd_esquema.Maestra, LOS_TRIGGERS.Afiliado, LOS_TRIGGERS.Consulta_Medica, LOS_TRIGGERS.Turno
					where turn_afiliado=CONVERT(numeric(18,0), CAST(Paciente_Dni as varchar) + '01') AND cons_turno=turn_numero
						AND Paciente_Dni is not null AND Consulta_Sintomas is not null
					group by turn_afiliado
OPEN CONSULTAS
FETCH NEXT FROM CONSULTAS INTO @afiliado, @consultas
WHILE @@fetch_status = 0
	BEGIN
			update LOS_TRIGGERS.Afiliado
				set afil_cant_consultas_realizadas = CONVERT(numeric(18,0), @consultas)
				where afil_numero=@afiliado

		FETCH NEXT FROM CONSULTAS INTO @afiliado, @consultas
	END
CLOSE CONSULTAS
DEALLOCATE CONSULTAS
PRINT '12. Consultas realizadas por Afiliados OK'
GO

-- << Rango de atención de la Clínica >>
declare @clinica as numeric(18,0)
insert into LOS_TRIGGERS.Clinica (clin_nombre) values('Clinica Medica FRBA')
set @clinica = (select SCOPE_IDENTITY())
insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_clinica) values('Lunes', '07:00', '20:00', @clinica)
insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_clinica) values('Martes', '07:00', '20:00', @clinica)
insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_clinica) values('Miércoles', '07:00', '20:00', @clinica)
insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_clinica) values('Jueves', '07:00', '20:00', @clinica)
insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_clinica) values('Viernes', '07:00', '20:00', @clinica)
insert into LOS_TRIGGERS.Dia_Atencion(dia_nombre_dia, dia_hora_fin, dia_hora_inicio, dia_clinica) values('Sábado', '10:00', '15:00', @clinica)

PRINT '13. Rango de Atención de la Clínica OK'
GO

-- << Tipos de Cancelaciones de Turno >>
insert into LOS_TRIGGERS.Tipo_Cancelacion (tipo_descripcion)
	values ('Ya no necesito el servicio'),
			('He encontrado otro servicio alternativo que cubre mejor mis necesidades'),
			('La atención al cliente no ha cubierto mis expectativas'),
			('No puedo asistir debido a un problema personal'),
			('Otro motivo')
PRINT '14. Tipos de Cancelación de Turno OK'
GO

-- << Funcionalidades del Sistema >>
insert into LOS_TRIGGERS.Funcionalidad (func_nombre)
	values ('Abm de Rol'),
			('Registro de Usuario'),
			('Abm de Afiliado'),
			('Abm de Profesional'),
			('Abm de Especialidad Médica'),
			('Compra de Bono'),
			('Abm de Plan'),
			('Pedido de Turno'),
			('Registro de Agenda Profesional'),
			('Registro de Consulta Médica'),
			('Registro de Diagnóstico Médico'),
			('Cancelación de Turno'),
			('Listado Estadístico')
PRINT '15.  Funcionalidades del Sistema OK'
GO

--- TODO:
--  Calcular cantidad de horas laborales en Profesional (quizás no haga falta).
-- Analizar si los turnos que tienen NULL en Consulta es porque se cancelaron y, en ese caso, registrar las cancelaciones correspondientes.