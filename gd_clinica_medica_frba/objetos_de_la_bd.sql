/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/

--- << ABM ROLES >> ---
--- NOTA: Completar y revisar
IF OBJECT_ID ('LOS_TRIGGERS.AltaRol') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRol
GO
CREATE PROC LOS_TRIGGERS.AltaRol (@nombre varchar(255)) AS
	BEGIN
		IF @nombre='afiliado'
			insert into LOS_TRIGGERS.Afiliado(afil_nombre_rol, afil_habilitacion) values (@nombre, 1)
		ELSE IF @nombre='profesional'
			insert into LOS_TRIGGERS.Profesional(prof_nombre_rol, prof_habilitacion) values (@nombre, 1)
		ELSE IF @nombre='administrador'
			insert into LOS_TRIGGERS.Administrador(admi_nombre_rol, admi_habilitacion) values (@nombre, 1)
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.BajaRol') is not null DROP PROCEDURE LOS_TRIGGERS.BajaRol
GO
CREATE PROC LOS_TRIGGERS.BajaRol (@nombre varchar(255)) AS
	BEGIN
		update LOS_TRIGGERS.Afiliado set afil_habilitacion=0 where afil_nombre_rol=@nombre
		update LOS_TRIGGERS.Profesional set prof_habilitacion=0 where prof_nombre_rol=@nombre
		update LOS_TRIGGERS.Administrador set admi_habilitacion=0 where admi_nombre_rol=@nombre
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
CREATE PROC LOS_TRIGGERS.ModificarRol (@nombre varchar(255), @nuevo_nombre varchar(255)) AS
	BEGIN
		update LOS_TRIGGERS.Afiliado set afil_nombre_rol=@nuevo_nombre where afil_nombre_rol=@nombre
		update LOS_TRIGGERS.Profesional set prof_nombre_rol=@nuevo_nombre where prof_nombre_rol=@nombre
		update LOS_TRIGGERS.Administrador set admi_nombre_rol=@nuevo_nombre where admi_nombre_rol=@nombre
	END;
GO

--- << Funcionalidades >> ---
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidad') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidad
GO
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidad (@nombre varchar(255)) AS 
	BEGIN
		insert into LOS_TRIGGERS.Funcionalidad(func_nombre) values (@nombre)
	END;
GO

/*
IF OBJECT_ID ('LOS_TRIGGERS.Agregar_Funcionalidad_Rol') is not null DROP PROCEDURE LOS_TRIGGERS.Agregar_Funcionalidad_Rol
GO
CREATE PROC LOS_TRIGGERS.Agregar_Funcionalidad_Rol (@rol varchar(255), @funcionalidad varchar(255)) AS
	SET IDENTITY_INSERT LOS_TRIGGERS.Funcionalidad_Rol ON
	GO
	BEGIN
		---TODO
	END;
	SET IDENTITY_INSERT LOS_TRIGGERS.Funcionalidad_Rol OFF
GO
*/