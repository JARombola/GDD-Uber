USE [GD1C2017]
GO

DECLARE @RC int

-- TODO: Establezca los valores de los parámetros aquí.

EXECUTE @RC = [MAIDEN].[SP_cargarClientes] 

EXECUTE @RC = [MAIDEN].[SP_cargarChoferes] 

EXECUTE @RC = [MAIDEN].[SP_cargarTurnos] 

EXECUTE @RC = [MAIDEN].[SP_cargarAutos] 

EXECUTE @RC = [MAIDEN].[SP_cargarViajes] 

EXECUTE @RC = [MAIDEN].[SP_crearRolesDefault] 

EXECUTE @RC = [MAIDEN].[SP_crearUsuariosDefault] 
GO



