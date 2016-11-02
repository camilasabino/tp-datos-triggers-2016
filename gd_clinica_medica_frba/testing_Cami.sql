/*
INSERT INTO LOS_TRIGGERS.Administrador (admi_habilitacion, nombre_rol) values (1, 'Administrador')
INSERT INTO LOS_TRIGGERS.Usuario (user_name, user_password, user_intentos_fallidos_login, user_administrador)
values ('admin', HASHBYTES('SHA2_256', CONVERT(varchar(255), 'w23e')), 0, @@IDENTITY)

select * from LOS_TRIGGERS.Profesional where prof_id=1465925099
select * from LOS_TRIGGERS.Administrador where admi_id=2
select * from LOS_TRIGGERS.Afiliado where afil_numero=1123960001

select * from LOS_TRIGGERS.Usuario where user_profesional=1465925099 --user_id: 5551
select * from LOS_TRIGGERS.Usuario where user_administrador=2 --user_id: 5579
select * from LOS_TRIGGERS.Usuario where user_afiliado=1123960001 --user_id: 1
*/

EXEC LOS_TRIGGERS.ComboRolesDeUnUsuario @usuario=5551
EXEC LOS_TRIGGERS.ComboRolesDeUnUsuario @usuario=5579
EXEC LOS_TRIGGERS.ComboRolesDeUnUsuario @usuario=1