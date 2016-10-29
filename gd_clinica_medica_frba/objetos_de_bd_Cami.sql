/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/

--- << ABM ROLES >> ---
/*
IF OBJECT_ID ('LOS_TRIGGERS.AltaRol') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRol
GO
CREATE PROC LOS_TRIGGERS.AltaRol (@nombre varchar(255)) AS
	BEGIN
		
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.BajaRol') is not null DROP PROCEDURE LOS_TRIGGERS.BajaRol
GO
CREATE PROC LOS_TRIGGERS.BajaRol (@nombre varchar(255)) AS
	BEGIN

	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
CREATE PROC LOS_TRIGGERS.ModificarRol (@nombre varchar(255), @nuevo_nombre varchar(255)) AS
	BEGIN

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

IF OBJECT_ID ('LOS_TRIGGERS.Agregar_Funcionalidad_Rol') is not null DROP PROCEDURE LOS_TRIGGERS.Agregar_Funcionalidad_Rol
GO
CREATE PROC LOS_TRIGGERS.Agregar_Funcionalidad_Rol (@rol varchar(255), @funcionalidad varchar(255)) AS
	SET IDENTITY_INSERT LOS_TRIGGERS.Funcionalidad_Rol ON
	GO
	BEGIN

	END;
	SET IDENTITY_INSERT LOS_TRIGGERS.Funcionalidad_Rol OFF
GO
*/