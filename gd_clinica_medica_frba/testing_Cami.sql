/*
-- << JUEGO DE DATOS >>
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
	where espe_prof_id=9

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

EXEC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional @profesional=1465925099 -- Muestra 1
EXEC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional @profesional=18756896099 -- Muestra 3
EXEC LOS_TRIGGERS.ComboEspecialidadesDeUnProfesional @profesional=28036677099 -- Muestra 3

EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado @afiliado=1123960001 -- Muestra 24 (fechas pasadas), 0 (actual)
EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado @afiliado=1133472001 -- Muestra 34 (fechas pasadas), 0 (actual)

-- << PEDIDO DE TURNOS >> -- RESULTADO: OK
declare @fecha_turno as date
set @fecha_turno=CONVERT(date, GETDATE())
EXEC LOS_TRIGGERS.PedirTurno @afiliado=1123960001, @profesional=1465925099, @especialidad=10033, @fecha=@fecha_turno, @hora='19:30'
EXEC LOS_TRIGGERS.PedirTurno @afiliado=1123960001, @profesional=1465925099, @especialidad=10033, @fecha=@fecha_turno, @hora='12:00'
-- ** Verifico que no me deje sacar turno cuando ya está asignado el horario **
EXEC LOS_TRIGGERS.PedirTurno @afiliado=1133472001, @profesional=1465925099, @especialidad=10033, @fecha=@fecha_turno, @hora='19:30'
EXEC LOS_TRIGGERS.TurnosAsignadosAUnAfiliado @afiliado=1123960001 -- Muestra bien

-- << CNCELACIÓN DE TURNOS >> -- RESULTADO: REVISAR
-- Por Afiliado:
EXEC LOS_TRIGGERS.CancelarTurno @usuario=1, @turno=202166, @tipo_canc=4, @motivo='Se me hizo tarde'
-- Por Profesional un solo Turno:

-- Por Profesional período de Turnos:
*/
