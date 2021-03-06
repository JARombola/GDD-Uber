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
	if Exists (select 1 from [MAIDEN].Turno turno, inserted nuevo		--Controla que no haya otro turno en el mismo horario que:
					WHERE												-- 1) ambos turnos esten habilitado. Si existe alguno que NO sea de respaldo
					NOT	(nuevo.Hora_Fin <= turno.Hora_Inicio			-- 2) Que el ID no sea el mismo (para la modificacion)
							OR nuevo.Hora_Inicio >= turno.Hora_Fin)		-- 3) Horarios.
					 AND
					nuevo.Habilitado = 1 AND turno.Respaldo=0 AND turno.Habilitado=1 AND nuevo.ID != turno.ID)
	BEGIN
		rollback transaction;
		throw 51000,'Ya existe un tuno activo en dicho intervalo',1;
	END
END
GO
-- Cuando se modifica un turno, si había algun VIAJE que hacía referencia a él, 
-- entonces el turno "modificado" se crea como uno nuevo para mantener la referencia de los
-- viajes al turno viejo (el cual se marca como deshabilitado).
-- Sino, el viaje quedaría quizá con precios que no eran los de ese momento.
--			 (Los datos del viaje quedarían inconsistentes)

CREATE TRIGGER [MAIDEN].tg_controlActualizacionTurnos ON [MAIDEN].[Turno]
	AFTER UPDATE
AS 
BEGIN Declare @idViejo int, @idNuevo int
	Select @idViejo = ID from deleted 

		if exists (Select 1 from [MAIDEN].Viaje, deleted turnoViejo where Turno = turnoViejo.id)
		BEGIN
			UPDATE [MAIDEN].Turno
			SET Respaldo=1, Habilitado=0
			WHERE ID = (Select ID from deleted)

			INSERT INTO [MAIDEN].Turno(Hora_Inicio,Hora_Fin,Precio_Base,Precio_km,Descripcion,Habilitado) 
			select i.Hora_Inicio,i.Hora_Fin,i.Precio_Base,i.Precio_km,i.Descripcion,i.Habilitado from inserted i
			
			SELECT @idNuevo = @@IDENTITY
			
			UPDATE [MAIDEN].Auto 
				SET Turno=@idNuevo
			WHERE Turno=@idViejo
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
