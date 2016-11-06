/*
select * from LOS_TRIGGERS.Profesional where prof_id=146592599
select * from LOS_TRIGGERS.Administrador where admi_id=1
select * from LOS_TRIGGERS.Afiliado where afil_numero=112396001

select * from LOS_TRIGGERS.Usuario where user_profesional=146592599 AND user_afiliado=99988853002 --user_id: 5551, user_name: prof
select * from LOS_TRIGGERS.Usuario where user_administrador=1 --user_id: 5579, user_name: admin
select * from LOS_TRIGGERS.Usuario where user_afiliado=112396001 --user_id: 1, user_name: afil
*/
--SELECT * from LOS_TRIGGERS.Turno where turn_afiliado=112396001 order by turn_fecha DESC
--select * from LOS_TRIGGERS.Tipo_Cancelacion
--SELECT * from LOS_TRIGGERS.Turno where turn_afiliado=112396001 order by turn_fecha DESC
--select * from LOS_TRIGGERS.Modificacion_Plan
--select * from LOS_TRIGGERS.Dia_Atencion where dia_especialidad_profesional=17

--espe=10033
--espe_prof=17
--prof=146592599
/*
set @inicio=(select dia_hora_inicio from LOS_TRIGGERS.Dia_Atencion where dia_especialidad_profesional=(select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=146592599 AND especialidad=10033) AND dia_nombre_dia=DATENAME(weekday, GETDATE()))
set @fin=(select dia_hora_fin from LOS_TRIGGERS.Dia_Atencion where dia_especialidad_profesional=(select espe_prof_id from LOS_TRIGGERS.Especialidad_Profesional where profesional=146592599 AND especialidad=10033) AND dia_nombre_dia=DATENAME(weekday, GETDATE()))

PRINT @inicio+', '+@fin

WHILE(@inicio<@fin)
	BEGIN
		select @inicio as hora_inicio, FORMAT(DATEADD(MINUTE, 30, @inicio), 'HH:mm') as hora_fin
		set @inicio = FORMAT(DATEADD(MINUTE, 30, @inicio), 'HH:mm')
	END;
GO

declare @d2 as date, @d1 as date
set @d1=GETDATE()
set @d2=CAST('2016-12-12' as date)
EXEC LOS_TRIGGERS.RegistrarAgendaProfesional 146592599, 10033, @d1, @d2
*/
--select * from LOS_TRIGGERS.Horario_Atencion where hora_especialidad_profesional=17
--SELECT * FROM LOS_TRIGGERS.Plan_Medico