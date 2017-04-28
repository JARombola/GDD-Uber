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
		(Select distinct * From [ASD].Autos
		where 
			Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
		UNION 
		Select * From [ASD].Autos autito
		where Exists(
			select * from [ASD].Choferes 
			where ID = @choferID
			AND coche = autito.ID
			)
		)

GO
----------------------FUNCION DE FILTRADO DE CHOFERES------------------------------
CREATE FUNCTION [ASD].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select distinct * From [ASD].Choferes
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
		(Select distinct * From [ASD].Clientes
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
		(Select distinct * From [ASD].Turnos
		where 
			Descripcion like '%'+ @descripcion+ '%'
		)
GO
----------------------- BUSQUEDAS POR ID --------------------------
CREATE FUNCTION [ASD].fx_getCliente 
(	@id int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * From [ASD].Clientes WHERE id = @id
)
GO

CREATE FUNCTION [ASD].fx_getChofer 
(	@id int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * From [ASD].Choferes WHERE id = @id
)
GO

CREATE FUNCTION [ASD].fx_getAuto 
(	@id int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * From [ASD].Autos WHERE id = @id
)
GO

CREATE FUNCTION [ASD].fx_getTurno 
(	@id int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * From [ASD].Turnos WHERE id = @id
)
GO