USE GD1C2017
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
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
								 @marca varchar(255))
Returns Table
AS
	RETURN
		(Select distinct gd_esquema.Maestra.Auto_Modelo, gd_esquema.Maestra.Auto_Patente
			From gd_esquema.Maestra
		where 
			gd_esquema.Maestra.Auto_Modelo like '%'+@modelo+'%'
			OR
			gd_esquema.Maestra.Auto_Patente = @patente
			OR
			gd_esquema.Maestra.Auto_Marca = @marca)
GO
----------------------FUNCION DE FILTRADO DE CHOFERES------------------------------
CREATE FUNCTION [ASD].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select distinct Chofer_Apellido,Chofer_Nombre, Chofer_Dni
			From gd_esquema.Maestra
		where 
			gd_esquema.Maestra.Chofer_Nombre like '%'+ @nombre+ '%'
			OR
			gd_esquema.Maestra.Chofer_Apellido like '%'+@apellido+'%'
			OR
			gd_esquema.Maestra.Chofer_Dni = @DNI
		)
GO
----------------------FUNCION DE FILTRADO DE CLIENTES------------------------------
CREATE FUNCTION [ASD].fx_filtrarClientes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
Returns Table
AS
	RETURN
		(Select distinct Cliente_Apellido,Cliente_Nombre, Cliente_Dni
			From gd_esquema.Maestra
		where 
			gd_esquema.Maestra.Cliente_Nombre like '%'+ @nombre+ '%'
			OR
			gd_esquema.Maestra.Cliente_Apellido like '%'+@apellido+'%'
			OR
			gd_esquema.Maestra.Cliente_Dni = @DNI
		)
GO
----------------------FUNCION DE FILTRADO DE TURNOS------------------------------
CREATE FUNCTION [ASD].fx_filtrarTurnos (@descripcion varchar(255))		
Returns Table
AS
	RETURN
		(Select distinct Turno_Descripcion, Turno_Precio_Base, Turno_Valor_Kilometro
			From gd_esquema.Maestra
		where 
			gd_esquema.Maestra.Turno_Descripcion like '%'+ @descripcion+ '%'
		)
GO