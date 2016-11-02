/*
select * from LOS_TRIGGERS.Profesional where prof_id=1465925099
select * from LOS_TRIGGERS.Administrador where admi_id=1
select * from LOS_TRIGGERS.Afiliado where afil_numero=1123960001

select * from LOS_TRIGGERS.Usuario where user_profesional=1465925099 AND user_afiliado=99988853002 --user_id: 5551, user_name: prof
select * from LOS_TRIGGERS.Usuario where user_administrador=1 --user_id: 5579, user_name: admin
select * from LOS_TRIGGERS.Usuario where user_afiliado=1123960001 --user_id: 1, user_name: afil
*/
--SELECT * from LOS_TRIGGERS.Turno where turn_afiliado=1123960001 order by turn_fecha DESC
--select * from LOS_TRIGGERS.Tipo_Cancelacion
SELECT * from LOS_TRIGGERS.Turno where turn_afiliado=1123960001 order by turn_fecha DESC