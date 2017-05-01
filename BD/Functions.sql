USE GD1C2017
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Julian
-- Create date: 22/04/2017
-- Description:	Creacion de Funciones
-- =============================================

----------------------FUNCION DE FILTRADO DE AUTOS------------------------------
CREATE FUNCTION [ASD].fx_filtrarAutos (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
Returns Table
AS
	RETURN
		(Select * From [ASD].Autos
		where 
			Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID)

GO
----------------------FUNCION DE FILTRADO DE CHOFERES------------------------------
CREATE FUNCTION [ASD].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [ASD].Choferes
		where 
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		)
GO
----------------------FUNCION DE FILTRADO DE CLIENTES------------------------------
CREATE FUNCTION [ASD].fx_filtrarClientes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [ASD].Clientes
		where 
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		)
GO
----------------------FUNCION DE FILTRADO DE TURNOS------------------------------
CREATE FUNCTION [ASD].fx_filtrarTurnos (@descripcion varchar(255))		
Returns Table
AS
	RETURN
		(Select * From [ASD].Turnos
		where 
			Descripcion like '%'+ @descripcion+ '%'
		)
GO
----------------------- BUSQUEDAS POR ID --------------------------
CREATE FUNCTION [ASD].fx_getCliente(@id int)
RETURNS TABLE 
AS
RETURN 
(SELECT * From [ASD].Clientes WHERE id = @id)
GO

CREATE FUNCTION [ASD].fx_getChofer(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [ASD].Choferes WHERE id = @id)
GO

CREATE FUNCTION [ASD].fx_getAuto(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [ASD].Autos WHERE id = @id)
GO

CREATE FUNCTION [ASD].fx_getTurno(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [ASD].Turnos WHERE id = @id)
GO

CREATE FUNCTION [ASD].fx_getDescripcion(@id int)
RETURNS VARCHAR(256) 
AS
BEGIN
	RETURN (SELECT Descripcion From [ASD].fx_getTurno(@id))
END;
GO

CREATE FUNCTION [ASD].fx_getRol(@Id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [ASD].Roles WHERE ID = @id)
GO

CREATE FUNCTION [ASD].fx_getRolId(@rol varchar(20))
RETURNS int 
AS
BEGIN
	RETURN (SELECT ID From [ASD].Roles WHERE Rol = @rol)
END;
GO

CREATE FUNCTION [ASD].fx_getNombreChofer(@id int)
RETURNS TABLE
AS
	RETURN (SELECT Nombre, Apellido From [ASD].fx_getChofer(@id))
GO



CREATE FUNCTION [ASD].fx_getUsuario(@user varchar(30))
RETURNS TABLE 
AS
RETURN (SELECT * From [ASD].Usuarios WHERE Usuario = @user)
GO

---------------------------------- LOGIN USUARIO
CREATE FUNCTION [ASD].fx_getRolesDeUsuario(@usuario varchar(30))
RETURNS TABLE
AS
RETURN (Select Rol From [ASD].Roles 
		Where ID IN (Select Rol FROM [ASD].RolXUsuario Where Usuario = @usuario))
GO

CREATE FUNCTION [ASD].fx_getCantidadRolesDeUsuario(@usuario varchar(30))			--Devuelve la cantidad de roles que tiene ese usuario
RETURNS int																		--(Usada para otorgar funcionalidades)
AS
BEGIN
	RETURN (Select count(*) as 'Cantidad de Roles' FROM [ASD].RolXUsuario Where Usuario = @usuario)
END;
GO
