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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE filtrar @modelo varchar(255),
						 @patente varchar(10),
						 @marca varchar(255)
AS
	Select distinct gd_esquema.Maestra.Auto_Modelo, gd_esquema.Maestra.Auto_Patente
		From gd_esquema.Maestra
	where 
		gd_esquema.Maestra.Auto_Modelo = @modelo 
		OR
		gd_esquema.Maestra.Auto_Patente = @patente
		OR
		gd_esquema.Maestra.Auto_Marca = @marca
GO
