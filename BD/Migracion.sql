USE [GD1C2017]
GO

DECLARE @RC int

EXECUTE @RC = [MAIDEN].[SP_migrarClientes] 

EXECUTE @RC = [MAIDEN].[SP_migrarChoferes] 

EXECUTE @RC = [MAIDEN].[SP_migrarTurnos] 

EXECUTE @RC = [MAIDEN].[SP_migrarAutos] 

EXECUTE @RC = [MAIDEN].[SP_migrarRendiciones] 

EXECUTE @RC = [MAIDEN].[SP_migrarFacturas] 

EXECUTE @RC = [MAIDEN].[SP_migrarViajes]

EXECUTE @RC = [MAIDEN].[SP_crearFuncionalidadesDefault] 

EXECUTE @RC = [MAIDEN].[SP_crearRolesDefault] 

EXECUTE @RC = [MAIDEN].[SP_crearUsuariosDefault] 

GO



