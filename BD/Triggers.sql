USE [GD1C2017]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Julian
-- Create date: 07/05/2017
-- Description:	
-- =============================================

--Este trigger controla que no hayan turnos superpuestos / con duracion > a 1 dia
CREATE TRIGGER [MAIDEN].tg_controlTurnosSuperpuestos ON [MAIDEN].[Turno]			
   AFTER INSERT, UPDATE
AS 
BEGIN
	if Exists (select 1 from [MAIDEN].Turno turno, inserted nuevo where(
	nuevo.Hora_Inicio between turno.Hora_Inicio and turno.Hora_Fin-1
	OR 
	nuevo.Hora_Fin between turno.Hora_Inicio+1 and turno.Hora_Fin)AND turno.ID!=nuevo.id)
	BEGIN
		rollback transaction;
		throw 51000,'Turnos superpuestos',1;
	END
END
GO
-- Cuando se modifica un turno, si había algun VIAJE que hacía referencia a él, 
-- también se deja una copia del turno viejo. Sino, el viaje quedaría quizá con precios que no
-- eran los de ese momento. (Los datos del viaje quedarían inconsistentes)

CREATE TRIGGER [MAIDEN].tg_controlActualizacionTurnos ON [MAIDEN].[Turno]
	AFTER UPDATE
AS 
BEGIN Declare @idViejo int, @idNuevo int
	Select @idViejo = ID from deleted 

	if exists (Select 1 from [MAIDEN].Viaje, deleted turnoViejo where Turno = turnoViejo.id)
		BEGIN
			BEGIN
				INSERT INTO [MAIDEN].Turno 
				select d.Hora_Inicio,d.Hora_Fin,d.Precio_Base,d.Precio_km,d.Descripcion,0 from deleted d
				SET @idNuevo = @@IDENTITY
			END
			BEGIN
			UPDATE [MAIDEN].Viaje 
				SET Turno = @idNuevo
				where Turno = @idViejo
			END
		END

END
GO

----------------------Este trigger controla que el cliente no registre 2 viajes 
----------------------que se superponen (es decir, dentro del mismo intervalo de tiempo)
--CREATE TRIGGER [MAIDEN].tg_controlViajesSuperpuestos ON [MAIDEN].Viajes
--	AFTER INSERT
--AS 
--BEGIN DECLARE @fechaViaje DATETIME
--	SET @fechaViaje = (SELECT Fecha from inserted)
--	if exists(select 1 from [MAIDEN].Viajes v where 
--		v.Cliente=(Select Cliente from inserted) 
--		AND Cast (@fechaViaje as Date) = CAST(v.Fecha as DATE) 
--		AND cast (@fechaViaje as time) BETWEEN cast(v.Fecha as Time) AND v.Hora_Fin
--		AND ID != (Select id from inserted))
--		BEGIN;
--			Rollback transaction;
--			throw 51000,'Ya existe otro viaje del cliente en ese horario',16
--		END;
--	if exists(select 1 from [MAIDEN].Viajes v where 
--		v.Chofer= (Select Chofer from inserted) 
--		AND Cast (@fechaViaje as Date) = CAST(v.Fecha as DATE) 
--		AND cast (@fechaViaje as time) BETWEEN cast(v.Fecha as Time) AND v.Hora_Fin
--		AND ID != (Select id from inserted))
--		BEGIN; 
--			Rollback transaction;
--			throw 51000,'Ya existe otro viaje del chofer en ese horario',16
--		END;
--END
--GO
