USE [GD1C2017]
GO

DECLARE @RC int

EXECUTE @RC = [MAIDEN].[SP_cargarClientes] 

EXECUTE @RC = [MAIDEN].[SP_cargarChoferes] 

EXECUTE @RC = [MAIDEN].[SP_cargarTurnos] 

EXECUTE @RC = [MAIDEN].[SP_cargarAutos] 

EXECUTE @RC = [MAIDEN].[SP_cargarRendiciones] 

EXECUTE @RC = [MAIDEN].[SP_cargarViajes]

EXECUTE @RC = [MAIDEN].[SP_crearFuncionalidadesDefault] 

EXECUTE @RC = [MAIDEN].[SP_crearRolesDefault] 

EXECUTE @RC = [MAIDEN].[SP_crearUsuariosDefault] 

GO



