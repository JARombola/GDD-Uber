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

----------------------FUNCIONES DE AUTOS------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarAutos (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Autos
		where 
			Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarAutosHabilitados (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Autos
		where (
			Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID)
			AND Habilitado=1)
GO

CREATE FUNCTION [MAIDEN].fx_getAutoId(@patente varchar(10))
RETURNS INT AS
BEGIN
	RETURN(Select id from [MAIDEN].Autos Where Patente = @patente)
END;
GO

----------------------FUNCION DE FILTRADO DE CHOFERES------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Choferes
		where 
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarChoferesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Choferes
		where (
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI )
			AND Habilitado=1
		)
GO

CREATE FUNCTION [MAIDEN].fx_getChoferId(@Dni numeric(18,0))
RETURNS int 
as Begin
	return (Select id from [MAIDEN].Choferes where Dni = @Dni)
End;
GO
----------------------FUNCIONES DE CLIENTES------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarClientes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Clientes
		where 
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarClientesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Clientes
		where (
			Nombre like '%'+ @nombre+ '%'
			OR
			Apellido like '%'+@apellido+'%'
			OR
			DNI = @DNI
		) AND Habilitado = 1
		)
GO

CREATE FUNCTION [MAIDEN].fx_getClienteId(@dni int)
RETURNS INT
AS BEGIN
	RETURN(Select id from [MAIDEN].Clientes where DNI = @dni)
END;
GO
----------------------FUNCION DE FILTRADO DE TURNOS------------------------------
CREATE FUNCTION [MAIDEN].fx_filtrarTurnos (@descripcion varchar(255))		
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Turnos
		where 
			Descripcion like '%'+ @descripcion+ '%'
		)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarTurnosHabilitados (@descripcion varchar(255))		
Returns Table
AS
	RETURN
		(Select * From [MAIDEN].Turnos
		where 
			Descripcion like '%'+ @descripcion+ '%'
			AND Habilitado=1
		)
GO

CREATE FUNCTION [MAIDEN].fx_getTurnoId (@hora_inicio numeric(18,0))		
Returns int
AS BEGIN
	RETURN
		(Select ID From [MAIDEN].Turnos t
		where @hora_inicio =Hora_Inicio)
	END;
GO

----------------------- BUSQUEDAS POR ID --------------------------
CREATE FUNCTION [MAIDEN].fx_getCliente(@id int)
RETURNS TABLE 
AS
RETURN 
(SELECT * From [MAIDEN].Clientes WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getChofer(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Choferes WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getAuto(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Autos WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getTurno(@id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Turnos WHERE id = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getDescripcion(@id int)
RETURNS VARCHAR(256) 
AS
BEGIN
	RETURN (SELECT Descripcion From [MAIDEN].fx_getTurno(@id))
END;
GO

CREATE FUNCTION [MAIDEN].fx_getRol(@Id int)
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Roles WHERE ID = @id)
GO

CREATE FUNCTION [MAIDEN].fx_getRolId(@rol varchar(20))
RETURNS int 
AS
BEGIN
	RETURN (SELECT ID From [MAIDEN].Roles WHERE Rol = @rol)
END;
GO

CREATE FUNCTION [MAIDEN].fx_getNombreChofer(@id int)
RETURNS TABLE
AS
	RETURN (SELECT Nombre, Apellido From [MAIDEN].fx_getChofer(@id))
GO

CREATE FUNCTION [MAIDEN].fx_getUsuario(@user varchar(30))
RETURNS TABLE 
AS
RETURN (SELECT * From [MAIDEN].Usuarios WHERE Usuario = @user)
GO

---------------------------------- LOGIN USUARIO
CREATE FUNCTION [MAIDEN].fx_getRolesDeUsuario(@usuario varchar(30))
RETURNS TABLE
AS
RETURN (Select Rol From [MAIDEN].Roles 
		Where ID IN (Select Rol FROM [MAIDEN].RolXUsuario Where Usuario = @usuario))
GO

CREATE FUNCTION [MAIDEN].fx_getCantidadRolesDeUsuario(@usuario varchar(30))			--Devuelve la cantidad de roles que tiene ese usuario
RETURNS int																		--(Usada para otorgar funcionalidades)
AS
BEGIN
	RETURN (Select count(*) as 'Cantidad de Roles' FROM [MAIDEN].RolXUsuario Where Usuario = @usuario)
END;
GO

----------------------- FUNCION PARA LOS VIAJES
-- Devuelve los datos del Auto para autocompletar el viaje una vez seleccionado el chofer

CREATE FUNCTION [MAIDEN].fx_getAutoDelChofer(@idChofer int)
Returns Table
AS Return(
		Select * from [MAIDEN].Autos where
		(Chofer = @idChofer 
		AND Habilitado = 1)
	)
GO

