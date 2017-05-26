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
CREATE TRIGGER [MAIDEN].tg_controlTurnosSuperpuestos ON [MAIDEN].[Turnos]			
   AFTER INSERT, UPDATE
AS 
BEGIN
	if Exists (select 1 from [MAIDEN].Turnos turno, inserted nuevo where(
	nuevo.Hora_Inicio between turno.Hora_Inicio and turno.Hora_Fin-1
	OR 
	nuevo.Hora_Fin between turno.Hora_Inicio+1 and turno.Hora_Fin)AND turno.ID!=nuevo.id)
	BEGIN
		rollback transaction;
		throw 51000,'Turnos superpuestos',1;
	END
if exists (select Hora_inicio,Hora_Fin  from inserted where Hora_Inicio>Hora_Fin)
		BEGIN
			rollback transaction;
			throw 51000,'Error en los horarios del turno (duracion mayor a 1 dia)',1;
		END
END
GO
-- Cuando se modifica un turno, si había algun VIAJE que hacía referencia a él, 
-- también se deja una copia del turno viejo. Sino, el viaje quedaría quizá con precios que no
-- eran los de ese momento. (Los datos del viaje quedarían inconsistentes

CREATE TRIGGER [MAIDEN].tg_controlActualizacionTurnos ON [MAIDEN].[Turnos]
	AFTER UPDATE
AS 
BEGIN Declare @idViejo int, @idNuevo int
	Select @idViejo = ID from deleted 

	if exists (Select 1 from [MAIDEN].Viajes, deleted turnoViejo where Turno = turnoViejo.id)
		BEGIN
			BEGIN
				INSERT INTO [MAIDEN].Turnos 
				select d.Hora_Inicio,d.Hora_Fin,d.Precio_Base,d.Precio_km,d.Descripcion,0 from deleted d
				SET @idNuevo = @@IDENTITY
			END
			BEGIN
			UPDATE [MAIDEN].viajes 
				SET Turno = @idNuevo
				where Turno = @idViejo
			END
		END

END
GO

--------------------Este trigger controla que el cliente no registre 2 viajes 
--------------------que se superponen (es decir, dentro del mismo intervalo de tiempo)
CREATE TRIGGER [MAIDEN].tg_controlViajesSuperpuestos ON [MAIDEN].vw_Viajes
	INSTEAD OF INSERT
AS 
BEGIN DECLARE @fechaViaje DATETIME
	SET @fechaViaje = (SELECT Fecha from inserted)
	if exists(select 1 from [MAIDEN].Viajes v where 
		v.Cliente= (Select Cliente from inserted) 
		AND Cast (@fechaViaje as Date) = CAST(v.Fecha as DATE) 
		AND cast (@fechaViaje as time) BETWEEN cast(Fecha as Time) AND v.Hora_Fin
		AND ID != (Select id from inserted))
		BEGIN 
			Rollback transaction;
			throw 51000,'Ya existe otro viaje del cliente en ese horario',1;
		END
		else BEGIN
			insert into [MAIDEN].Viajes(Auto,Chofer,Cliente,Fecha,Hora_Fin,Km,Turno)
			select Auto,Chofer,Cliente,Fecha,Hora_Fin,Km,Turno from inserted
			END
END
GO

------------------------------ CLIENTES
CREATE TRIGGER [MAIDEN].tg_altaClientes ON [MAIDEN].[Clientes]
	 INSTEAD OF INSERT
AS 
BEGIN
	BEGIN TRY
		INSERT INTO MAIDEN.Clientes(Nombre,Apellido,Direccion,DNI,Fecha_Nacimiento,Mail,Telefono)
		select Nombre,Apellido,Direccion,DNI,Fecha_Nacimiento,Mail,Telefono from inserted
	END TRY 
	BEGIN CATCH
	IF @@TRANCOUNT > 0 BEGIN 
					ROLLBACK; -- end the transaction that trigger is in
					throw 51000,'ERROR',16;
					END
	END catch
END 
GO
