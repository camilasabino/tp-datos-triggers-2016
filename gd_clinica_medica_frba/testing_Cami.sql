/*************************************************************************************
*				         TESTS PARA LOS OBEJTOS CREADOS                              *
**************************************************************************************/
-- << JUEGO DE DATOS >>
declare @fecha_sistema as datetime
set @fecha_sistema = CAST('2016-11-01' as datetime)

INSERT INTO LOS_TRIGGERS.Administrador (admi_habilitacion, nombre_rol) values (1, 'Administrador')
INSERT INTO LOS_TRIGGERS.Usuario (user_name, user_password, user_intentos_fallidos_login, user_administrador)
	values ('admin', HASHBYTES('SHA2_256', CONVERT(varchar(255), 'w23e')), 0, (select SCOPE_IDENTITY()))

update LOS_TRIGGERS.Usuario set user_name='prof' where user_id=5551
update LOS_TRIGGERS.Usuario set user_name='afil' where user_id=1

INSERT INTO LOS_TRIGGERS.Afiliado (afil_habilitacion, nombre_rol) values (1, 'Afiliado')
update LOS_TRIGGERS.Usuario set user_afiliado=(select SCOPE_IDENTITY()) where user_id=5551

declare @primer_dia as datetime
set @primer_dia=CONVERT(datetime, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0))
update LOS_TRIGGERS.Especialidad_Profesional
	set disponible_desde_fecha=@primer_dia,
		disponible_hasta_fecha=CONVERT(datetime, DATEADD(d, 365, @primer_dia))
	where espe_prof_id=17

insert into LOS_TRIGGERS.Dia_Atencion(dia_especialidad_profesional, dia_nombre_dia, dia_hora_inicio, dia_hora_fin)
	values(17, 'Lunes', '12:00', '19:30')
insert into LOS_TRIGGERS.Dia_Atencion(dia_especialidad_profesional, dia_nombre_dia, dia_hora_inicio, dia_hora_fin)
	values(17, 'Martes', '11:00', '18:00')
insert into LOS_TRIGGERS.Dia_Atencion(dia_especialidad_profesional, dia_nombre_dia, dia_hora_inicio, dia_hora_fin)
	values(17, 'Jueves', '14:00', '16:30')

-- << COMOBO TODOS LOS ROLES Y ROLES POR USUARIO >> -- RESULTADO: OK
EXEC LOS_TRIGGERS.ComboRoles

EXEC LOS_TRIGGERS.ComboRolesDeUnUsuario @usuario=5551
EXEC LOS_TRIGGERS.ComboRolesDeUnUsuario @usuario=5579
EXEC LOS_TRIGGERS.ComboRolesDeUnUsuario @usuario=1

-- << MODIFICAR NOMBRE ROLES >> -- RESULTADO: OK
EXEC LOS_TRIGGERS.ModificarRol @rol='Afiliado', @nuevo_nombre='Afil'
EXEC LOS_TRIGGERS.ModificarRol @rol='Profesional', @nuevo_nombre='Prof'
EXEC LOS_TRIGGERS.ModificarRol @rol='Administrador', @nuevo_nombre='Admi'

EXEC LOS_TRIGGERS.ModificarRol @rol='Afil', @nuevo_nombre='Afiliado'
EXEC LOS_TRIGGERS.ModificarRol @rol='Prof', @nuevo_nombre='Profesional'
EXEC LOS_TRIGGERS.ModificarRol @rol='Admi', @nuevo_nombre='Administrador'

-- << HABILITACIÓN E INHABILITACIÓN DE ROLES >> -- RESULTADO: OK
EXEC LOS_TRIGGERS.InhabilitarRol @rol='Afiliado'
EXEC LOS_TRIGGERS.InhabilitarRol @rol='Profesional'
EXEC LOS_TRIGGERS.InhabilitarRol @rol='Administrador'

EXEC LOS_TRIGGERS.HabilitarRol @rol='Afiliado'
EXEC LOS_TRIGGERS.HabilitarRol @rol='Profesional'
EXEC LOS_TRIGGERS.HabilitarRol @rol='Administrador'

-- << AGREGAR Y QUITAR FUNCIONALIDAD A UN ROL >> -- RESULTADO: OK
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Afiliado', @funcionalidad='Pedido de Turno'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Afiliado', @funcionalidad='Compra de Bono'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Administrador', @funcionalidad='Listado Estadístico'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Administrador', @funcionalidad='Abm de Rol'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Profesional', @funcionalidad='Registro de Consulta Médica'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Profesional', @funcionalidad='Registro de Diagnóstico Médico'

-- ** Verifico que no se agregue una funcionalidad por duplicado **
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Afiliado', @funcionalidad='Pedido de Turno'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Afiliado', @funcionalidad='Compra de Bono'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Administrador', @funcionalidad='Listado Estadístico'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Administrador', @funcionalidad='Abm de Rol'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Profesional', @funcionalidad='Registro de Consulta Médica'
EXEC LOS_TRIGGERS.AgregarFuncionalidadAUnRol @rol='Profesional', @funcionalidad='Registro de Diagnóstico Médico'

EXEC LOS_TRIGGERS.QuitarFuncionalidadAUnRol @rol='Afiliado', @funcionalidad='Pedido de Turno'
EXEC LOS_TRIGGERS.QuitarFuncionalidadAUnRol @rol='Afiliado', @funcionalidad='Compra de Bono'
EXEC LOS_TRIGGERS.QuitarFuncionalidadAUnRol @rol='Administrador', @funcionalidad='Listado Estadístico'
EXEC LOS_TRIGGERS.QuitarFuncionalidadAUnRol @rol='Administrador', @funcionalidad='Abm de Rol'
EXEC LOS_TRIGGERS.QuitarFuncionalidadAUnRol @rol='Profesional', @funcionalidad='Registro de Consulta Médica'
EXEC LOS_TRIGGERS.QuitarFuncionalidadAUnRol @rol='Profesional', @funcionalidad='Registro de Diagnóstico Médico'

-- << MOSTRAR TODOS LOS PROFESIONALES Y LAS ESPECIALIDADES DE UN PROFESIONAL>> -- RESULTADO: OK
EXEC LOS_TRIGGERS.ComboProfesionales

EXEC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional @profesional=146592599 -- Muestra 1
EXEC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional @profesional=1875689699 -- Muestra 3
EXEC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional @profesional=2803667799 -- Muestra 3

EXEC LOS_TRIGGERS.ComboHorariosDeUnProfesionalEnUnaEspecialidad 146592599, 10033 -- OK
EXEC LOS_TRIGGERS.AgendaCompletaDeUnProfesional 146592599, 10033, @fecha_sistema -- OK

EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado 112396001, @fecha_sistema -- Muestra 24 (fechas pasadas), 0 (actual)
EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado 113347201, @fecha_sistema -- Muestra 34 (fechas pasadas), 0 (actual)

-- << PEDIDO DE TURNOS >> -- RESULTADO: OK
declare @fecha_turno as date
set @fecha_turno=CONVERT(date, GETDATE())
EXEC LOS_TRIGGERS.PedirTurno @afiliado=112396001, @profesional=146592599, @especialidad=10033, @fecha=@fecha_turno, @hora='19:30'
EXEC LOS_TRIGGERS.PedirTurno @afiliado=112396001, @profesional=146592599, @especialidad=10033, @fecha=@fecha_turno, @hora='12:00'
-- ** Verifico que no me deje sacar turno cuando ya está asignado el horario **
EXEC LOS_TRIGGERS.PedirTurno @afiliado=113347201, @profesional=146592599, @especialidad=10033, @fecha=@fecha_turno, @hora='19:30'
EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado 112396001, @fecha_sistema -- Muestra bien

-- << CNCELACIÓN DE TURNOS >> -- RESULTADO: OK
-- Por Afiliado: -- OK
EXEC LOS_TRIGGERS.CancelarTurnoAfiliado 112396001, 202165, 4, 'Me demoré', @fecha_sistema -- OK
select * from LOS_TRIGGERS.Cancelacion_Turno where canc_emisor_afiliado=112396001
EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado 112396001, @fecha_sistema -- Muestra bien

-- Por Profesional un solo Turno: -- OK
EXEC LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular 146592599, 202166, 4, 'No puedo asistir', @fecha_sistema -- OK
select * from LOS_TRIGGERS.Cancelacion_Turno where canc_afiliado=112396001
EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado 112396001, @fecha_sistema -- Muestra bien

-- Por Profesional período de Turnos: -- OK
declare @fecha_turno1 as date, @fecha_turno2 as date, @fecha_turno3 as date
set @fecha_turno1=CONVERT(date, '2016-11-14')
set @fecha_turno2=CONVERT(date, '2016-11-21')
set @fecha_turno3=CONVERT(date, '2016-11-28')
EXEC LOS_TRIGGERS.PedirTurno @afiliado=112396001, @profesional=146592599, @especialidad=10033, @fecha=@fecha_turno1, @hora='16:30'
EXEC LOS_TRIGGERS.PedirTurno @afiliado=112396001, @profesional=146592599, @especialidad=10033, @fecha=@fecha_turno2, @hora='15:00'
EXEC LOS_TRIGGERS.PedirTurno @afiliado=112396001, @profesional=146592599, @especialidad=10033, @fecha=@fecha_turno3, @hora='13:30'

declare @d2 as date, @d1 as date
set @d1=GETDATE()
set @d2=CAST('2016-12-12' as date)
EXEC LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo 146592599, @d1, @d2, 4, 'Me voy de vacaciones'

select * from LOS_TRIGGERS.Turno where turn_afiliado=112396001 -- OK
select * from LOS_TRIGGERS.Cancelacion_Turno where canc_afiliado=112396001 -- OK

-- << RESGITRO DE AGENDA PROFESIONAL >> -- RESULTADO: OK
EXEC LOS_TRIGGERS.RegistrarAgendaProfesional 146592599, 10033, @d1, @d2, @fecha_sistema

-- << LISTADO ESTADÍSTICO >> -- RESULTADO: REVISAR
-- A) 
EXEC LOS_TRIGGERS.EspecialidadeConMasCancelaciones 2016,2 -- OK

-- B)
EXEC LOS_TRIGGERS.ProfesionalesConMenosHorasTrabajadas 2015, 2, 555556, 10010 -- OK

-- << MODIFICACIÓN AFILIADO >> -- RESULTADO: OK
-- Afiliado Nº: 112396001
--select * from LOS_TRIGGERS.Afiliado where afil_numero=112396001
--select * from LOS_TRIGGERS.Usuario where user_afiliado=112396001
EXEC LOS_TRIGGERS.ModificarAfiliadoTelefono 112396001, 2226538726
EXEC LOS_TRIGGERS.ModificarAfiliadoDireccion 112396001, 'Del Carmen 1064'
EXEC LOS_TRIGGERS.ModificarAfiliadoEstadoCivil 112396001, 'Concubinato'
EXEC LOS_TRIGGERS.ModificarAfiliadoMail 112396001, 'mail_mail@gmail.com'

-- << BAJA AFILIADO >> -- RESULTADO: OK
EXEC LOS_TRIGGERS.DarDeBajaUnAfiliado 124453901, @fecha_sistema
select * from LOS_TRIGGERS.Baja_Afiliado -- OK
select * from LOS_TRIGGERS.Afiliado where afil_numero=124453901 -- OK

declare @prox_lunes as date
set @prox_lunes = DATEADD(day, 3, GETDATE())
EXEC LOS_TRIGGERS.PedirTurno 112396001, 146592599, 10033, @prox_lunes,'19:00'
EXEC LOS_TRIGGERS.PedirTurno 112396001, 146592599, 10033, @prox_lunes, '12:30'
select * from LOS_TRIGGERS.Turno where turn_afiliado=112396001 and year(turn_fecha)=2016

EXEC LOS_TRIGGERS.DarDeBajaUnAfiliado 112396001, @fecha_sistema
select * from LOS_TRIGGERS.Turno where turn_afiliado=112396001 and year(turn_fecha)=2016 --OK

-- << ALTA AFILIADO >> -- RESULTADO: OK
update LOS_TRIGGERS.Usuario set user_afiliado=null where user_id in (2,3,4,5,6)
update LOS_TRIGGERS.Afiliado set afil_relacion_con_titular='Titular' where afil_numero=154849901

EXEC LOS_TRIGGERS.DarDeAltaUnAfiliado 6, 15936354, null, 'Divorciado/a', 555555, 0, 'Titular'
select * from LOS_TRIGGERS.Afiliado where afil_numero=1593635401
select * from LOS_TRIGGERS.Usuario where user_afiliado=1593635401

-- Titular: 154849901
EXEC LOS_TRIGGERS.DarDeAltaUnAfiliado 2, 18333824, 154849901, 'Casado/a', 555558, 0, 'Cónyuge'
EXEC LOS_TRIGGERS.DarDeAltaUnAfiliado 3, 38859824, 154849901, 'Soltero/a', 555558, 0, 'Hijo/a'
EXEC LOS_TRIGGERS.DarDeAltaUnAfiliado 4, 40859824, 154849901, 'Soltero/a', 555558, 0, 'Hijo/a'
EXEC LOS_TRIGGERS.DarDeAltaUnAfiliado 5, 45859824, 154849901, 'Soltero/a', 555558, 0, 'Hijo/a'
select * from LOS_TRIGGERS.Afiliado where afil_titular_grupo_familiar=154849901

-- << MODIFICACIÓN PLAN MÉDICO >> RESULTADO: OK
EXEC LOS_TRIGGERS.ModificarAfiliadoPlanMedico 1593635401, 555556, 'No podía pagar el Plan anterior', @fecha_sistema
select * from LOS_TRIGGERS.Afiliado where afil_numero = 1593635401
select * from LOS_TRIGGERS.Modificacion_Plan

EXEC LOS_TRIGGERS.ModificarAfiliadoPlanMedico 154849901, 555555, 'Elijo un plan mejor', @fecha_sistema
select * from LOS_TRIGGERS.Afiliado where afil_titular_grupo_familiar = 154849901
select * from LOS_TRIGGERS.Modificacion_Plan