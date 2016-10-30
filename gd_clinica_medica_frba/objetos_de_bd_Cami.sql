/*************************************************************************************
*				           OBJETOS DE BASE DE DATOS                                  *
**************************************************************************************/

--- << ABM ROLES >> ---
/*
IF OBJECT_ID ('LOS_TRIGGERS.AltaRol') is not null DROP PROCEDURE LOS_TRIGGERS.AltaRol
GO
CREATE PROC LOS_TRIGGERS.AltaRol (@nombre_rol varchar(255)) AS
	BEGIN
	
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.ModificarRol') is not null DROP PROCEDURE LOS_TRIGGERS.ModificarRol
GO
CREATE PROC LOS_TRIGGERS.ModificarRol (@nombre varchar(255)) AS
	BEGIN

	END;
GO
*/

IF OBJECT_ID ('LOS_TRIGGERS.InhabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.InhabilitarRol
GO
CREATE PROC LOS_TRIGGERS.InhabilitarRol (@nombre_rol varchar(255)) AS
	BEGIN
		IF (@nombre_rol='Afiliado')
			begin
				UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 0
				UPDATE LOS_TRIGGERS.Usuario set user_afiliado = null
				where user_afiliado is not null
			end
		ELSE IF (@nombre_rol='Administrador')
			begin
				UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 0
				UPDATE LOS_TRIGGERS.Usuario set user_administrador = null
				where user_administrador is not null
			end
		ELSE IF (@nombre_rol='Profesional')
			begin
				UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 0
				UPDATE LOS_TRIGGERS.Usuario set user_profesional = null
				where user_profesional is not null
			end
	END;
GO

IF OBJECT_ID ('LOS_TRIGGERS.HabilitarRol') is not null DROP PROCEDURE LOS_TRIGGERS.HabilitarRol
GO
CREATE PROC LOS_TRIGGERS.HabilitarRol (@nombre_rol varchar(255)) AS
	BEGIN
		IF (@nombre_rol='Afiliado')
			UPDATE LOS_TRIGGERS.Afiliado set afil_habilitacion = 1
		ELSE IF (@nombre_rol='Administrador')
			UPDATE LOS_TRIGGERS.Administrador set admi_habilitacion = 1
		ELSE IF (@nombre_rol='Profesional')
			UPDATE LOS_TRIGGERS.Profesional set prof_habilitacion = 1
	END;
GO


--- << Funcionalidades >> ---
IF OBJECT_ID ('LOS_TRIGGERS.AgregarFuncionalidadRol') is not null DROP PROCEDURE LOS_TRIGGERS.AgregarFuncionalidadRol
GO
CREATE PROC LOS_TRIGGERS.AgregarFuncionalidadRol (@funcionalidad varchar(255), @rol varchar(255)) AS
BEGIN
		declare @func_id as numeric(18,0)
		set @func_id = (select func_id from LOS_TRIGGERS.Funcionalidad where func_nombre=@funcionalidad)
		IF (@rol='Afiliado')
			begin
				insert into LOS_TRIGGERS.Funcionalidad_Rol
					select @func_id, afil_numero from LOS_TRIGGERS.Afiliado
			end
		ELSE IF (@rol='Administrador')
			begin
				insert into LOS_TRIGGERS.Funcionalidad_Rol
					select @func_id, admi_id from LOS_TRIGGERS.Administrador
			end
		ELSE IF (@rol='Profesional')
			begin
				insert into LOS_TRIGGERS.Funcionalidad_Rol
					select @func_id, prof_id from LOS_TRIGGERS.Profesional
			end
END
GO
