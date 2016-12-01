
-- BORRADO DE TABLAS:

IF OBJECT_ID ('LOS_TRIGGERS.Funcionalidad_Rol') IS NOT NULL DROP TABLE LOS_TRIGGERS.Funcionalidad_Rol
IF OBJECT_ID ('LOS_TRIGGERS.Funcionalidad') IS NOT NULL DROP TABLE LOS_TRIGGERS.Funcionalidad
IF OBJECT_ID ('LOS_TRIGGERS.Usuario') IS NOT NULL DROP TABLE LOS_TRIGGERS.Usuario
IF OBJECT_ID ('LOS_TRIGGERS.Administrador') IS NOT NULL DROP TABLE LOS_TRIGGERS.Administrador
IF OBJECT_ID ('LOS_TRIGGERS.Modificacion_Plan') IS NOT NULL DROP TABLE LOS_TRIGGERS.Modificacion_Plan
IF OBJECT_ID ('LOS_TRIGGERS.Bono') IS NOT NULL DROP TABLE LOS_TRIGGERS.Bono
IF OBJECT_ID ('LOS_TRIGGERS.Compra_Bono') IS NOT NULL DROP TABLE LOS_TRIGGERS.Compra_Bono
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
IF OBJECT_ID ('LOS_TRIGGERS.Calendario') IS NOT NULL DROP TABLE LOS_TRIGGERS.Calendario

-- BORRADO DE STORED PROCEDURES Y FUNCIONES:

IF OBJECT_ID ('LOS_TRIGGERS.usuario_traer_ID_rol') is not null DROP PROCEDURE LOS_TRIGGERS.usuario_traer_ID_rol
GO
IF OBJECT_ID ('LOS_TRIGGERS.usuario_login') is not null DROP PROCEDURE LOS_TRIGGERS.usuario_login
GO
IF OBJECT_ID ('LOS_TRIGGERS.usuario_tiene_permiso') is not null DROP PROCEDURE LOS_TRIGGERS.usuario_tiene_permiso
GO
IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
IF OBJECT_ID ('LOS_TRIGGERS.InhabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.InhabilitarRol
GO
IF OBJECT_ID ('LOS_TRIGGERS.HabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.HabilitarRol
GO
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidadAUnRol') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidadAUnRol
GO
IF OBJECT_ID ('LOS_TRIGGERS.QuitarFuncionalidadAUnRol') is not null DROP PROCEDURE LOS_TRIGGERS.QuitarFuncionalidadAUnRol
GO
IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoDireccion') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoDireccion
GO
IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoTelefono') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoTelefono
GO
IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoMail') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoMail
GO
IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoPlanMedico') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoPlanMedico
GO
IF OBJECT_ID ('LOS_TRIGGERS.ModificarAfiliadoEstadoCivil') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarAfiliadoEstadoCivil
GO
IF OBJECT_ID ('LOS_TRIGGERS.DarDeBajaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeBajaUnAfiliado
GO
IF OBJECT_ID ('LOS_TRIGGERS.CalcularNumeroAfiliado') is not null DROP FUNCTION LOS_TRIGGERS.CalcularNumeroAfiliado
GO
IF OBJECT_ID ('LOS_TRIGGERS.VerificarTitular') is not null DROP FUNCTION LOS_TRIGGERS.VerificarTitular
GO
IF OBJECT_ID ('LOS_TRIGGERS.DarDeAltaUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.DarDeAltaUnAfiliado
GO
IF OBJECT_ID('LOS_TRIGGERS.CalcularMontoCompraBonos') is not null DROP FUNCTION LOS_TRIGGERS.CalcularMontoCompraBonos
GO
IF OBJECT_ID ('LOS_TRIGGERS.ComprarBonos') is not null DROP PROCEDURE LOS_TRIGGERS.ComprarBonos
GO
IF OBJECT_ID ('LOS_TRIGGERS.ComboProfesionalesDeUnaEspecialidad') is not null DROP PROCEDURE LOS_TRIGGERS.ComboProfesionalesDeUnaEspecialidad
GO
IF OBJECT_ID ('LOS_TRIGGERS.ComboFechasDisponiblesTurno') is not null DROP PROCEDURE LOS_TRIGGERS.ComboFechasDisponiblesTurno
GO
IF OBJECT_ID ('LOS_TRIGGERS.HorariosDisponiblesTurno') is not null DROP PROCEDURE LOS_TRIGGERS.HorariosDisponiblesTurno
GO
IF OBJECT_ID ('LOS_TRIGGERS.PedirTurno') is not null DROP PROCEDURE LOS_TRIGGERS.PedirTurno
GO
IF OBJECT_ID ('LOS_TRIGGERS.TurnosAsignadosAUnAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.TurnosAsignadosAUnAfiliado
GO
IF OBJECT_ID ('LOS_TRIGGERS.TurnosDeUnProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.TurnosDeUnProfesional
GO
IF OBJECT_ID ('LOS_TRIGGERS.FechasDeAtencionProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.FechasDeAtencionProfesional
GO
IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurnoAfiliado') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurnoAfiliado
GO
IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurnoProfesionalDiaParticular
GO
IF OBJECT_ID ('LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo') is not null DROP PROCEDURE LOS_TRIGGERS.CancelarTurnosProfesionalPeriodo
GO
IF OBJECT_ID ('LOS_TRIGGERS.RegistrarDiaAtencionProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarDiaAtencionProfesional
GO
IF OBJECT_ID ('LOS_TRIGGERS.RegistrarAgendaProfesional') is not null DROP PROCEDURE LOS_TRIGGERS.RegistrarAgendaProfesional
GO
IF OBJECT_ID ('LOS_TRIGGERS.registro_llegada') is not null DROP PROCEDURE LOS_TRIGGERS.registro_llegada
GO			
IF OBJECT_ID ('LOS_TRIGGERS.registro_resultado') is not null DROP PROCEDURE LOS_TRIGGERS.registro_resultado
GO
IF OBJECT_ID ('LOS_TRIGGERS.EspecialidadesConMasCancelaciones') is not null DROP PROCEDURE LOS_TRIGGERS.EspecialidadesConMasCancelaciones
GO
IF OBJECT_ID('LOS_TRIGGERS.ProfesionalesMasConsultadosPorPlan') is not null DROP PROCEDURE LOS_TRIGGERS.ProfesionalesMasConsultadosPorPlan
GO
IF OBJECT_ID ('LOS_TRIGGERS.ProfesionalesConMenosHorasTrabajadas') is not null DROP PROCEDURE LOS_TRIGGERS.ProfesionalesConMenosHorasTrabajadas
GO
IF OBJECT_ID('LOS_TRIGGERS.AfiliadosConMasBonosComprados') is not null DROP PROCEDURE LOS_TRIGGERS.AfiliadosConMasBonosComprados
GO
IF OBJECT_ID ('LOS_TRIGGERS.EspecialidadesConMasBonosUtilizados') is not null DROP PROCEDURE LOS_TRIGGERS.EspecialidadesConMasBonosUtilizados
GO
