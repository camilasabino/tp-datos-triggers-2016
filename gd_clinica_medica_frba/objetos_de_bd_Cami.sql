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
*/
--- << Funcionalidades >> ---
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidad') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidad
GO
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidad (@nombre varchar(255)) AS 
	BEGIN
		insert into LOS_TRIGGERS.Funcionalidad(func_nombre) values (@nombre)
	END;
GO

---lista de fcs de un rol---
IF OBJECT_ID ('DB_MASTERS.FuncionesRoles') is not null DROP PROCEDURE DB_MASTERS.FuncionesRoles
GO
CREATE PROC DB_MASTERS.FuncionesRoles (@rol varchar(50)) AS
begin
	declare @id_rol integer = (select id_rol from DB_MASTERS.Roles where nombre=@rol)
	select id_fc from DB_MASTERS.Funciones_Roles where id_rol=@id_rol order by id_fc
end
go

---Actualizar FC's por ROL---
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidadRol') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidadRol
GO
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidadRol (@func numeric(18,0), @rol varchar(255), @habilitado bit) AS
BEGIN
	if @rol='afiliado'
	else if @rol='profesional'
	else if @rol='administrador'


	declare @id_rol numeric(18,0) = (select id_rol from DB_MASTERS.Roles where nombre=@rol)
	if @habilitado = 1
	begin
		if (select funcionalidad from LOS_TRIGGERS.Funcionalidad_Rol where funcionalidad=@func and rol=@id_rol) is null
			insert into DB_MASTERS.Funciones_Roles (id_fc, id_rol) values (@fc, @id_rol)
	end
	else
	begin
		if (select id_fc from DB_MASTERS.Funciones_Roles where id_fc=@fc and id_rol=@id_rol) is not null
			delete from DB_MASTERS.Funciones_Roles where id_fc=@fc and id_rol=@id_rol
	end
END
GO
