USE [GD1C2017]
GO
/****** Object:  Trigger [ASD].[controlTurnosSuperpuestos]    Script Date: 02/05/2017 17:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [ASD].controlTurnosSuperpuestos ON [ASD].[Turnos]			--Controla que no hayan turnos superpuestos / con duracion > a 1 dia
   AFTER INSERT, UPDATE
AS 
BEGIN
	Declare @cantidad int
	Select @cantidad = COUNT(*) FROM [ASD].Turnos turnos, inserted nuevo Where(
		nuevo.Hora_Inicio between turnos.Hora_Inicio and turnos.Hora_Fin
		OR
		nuevo.Hora_Fin between turnos.Hora_Inicio and turnos.Hora_Fin)
	if (@cantidad>1)BEGIN
					rollback transaction;
					throw 51000,'Turnos superpuestos',1;
					END
	if((select hora_inicio from inserted) > (select hora_fin from inserted))
		BEGIN
			rollback transaction;
			throw 51000,'Error en los horarios del turno (duracion mayor a 1 dia)',1;
		END
END


