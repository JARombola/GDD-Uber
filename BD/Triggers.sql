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

--Este trigger controla que no hayan turnos superpuestos / con duracion > a 1 dia
CREATE TRIGGER [ASD].tg_controlTurnosSuperpuestos ON [ASD].[Turnos]			
   AFTER INSERT, UPDATE
AS 
BEGIN
	Declare @cantidad int
	Select @cantidad = COUNT(*) FROM [ASD].Turnos turnos, inserted nuevo Where(
		(nuevo.Hora_Inicio between turnos.Hora_Inicio and turnos.Hora_Fin
		OR
		nuevo.Hora_Fin between turnos.Hora_Inicio and turnos.Hora_Fin)
		AND turnos.ID != nuevo.ID)
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
GO
-- Cuando se modifica un turno, si había algun VIAJE que hacía referencia a él, 
-- también se deja una copia del turno viejo. Sino, el viaje quedaría quizá con precios que no
-- eran los de ese momento. (Los datos del viaje quedarían inconsistentes

CREATE TRIGGER [ASD].tg_controlActualizacionTurnos ON [ASD].[Turnos]
	AFTER UPDATE
AS 
BEGIN Declare @idViejo int, @idNuevo int
	Select @idViejo = ID from deleted 

	if exists (Select 1 from [ASD].Viajes, deleted turnoViejo where Turno = turnoViejo.id)
		BEGIN
			BEGIN
				INSERT INTO [ASD].Turnos 
				select d.Hora_Inicio,d.Hora_Fin,d.Precio_Base,d.Precio_km,d.Descripcion,0 from deleted d
				SET @idNuevo = @@IDENTITY
			END
			BEGIN
			UPDATE [ASD].viajes 
				SET Turno = @idNuevo
				where Turno = @idViejo
			END
		END

END
GO



