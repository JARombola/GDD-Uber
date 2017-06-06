	-- Si la funcion existe => La borra
	-- IF = Funciones de Tabla, FN = Funciones escalares

IF OBJECT_ID(N'[MAIDEN].fx_filtrarChoferes', N'IF') IS NOT NULL 
	DROP FUNCTION [MAIDEN].fx_filtrarChoferes
GO

IF OBJECT_ID(N'[MAIDEN].fx_filtrarChoferesHabilitados', N'IF') IS NOT NULL 
	DROP FUNCTION [MAIDEN].fx_filtrarChoferesHabilitados
GO

IF OBJECT_ID(N'[MAIDEN].fx_filtrarClientes', N'IF') IS NOT NULL 
	DROP FUNCTION [MAIDEN].fx_filtrarClientes
GO

IF OBJECT_ID(N'[MAIDEN].fx_filtrarClientesHabilitados', N'IF') IS NOT NULL 
	DROP FUNCTION [MAIDEN].fx_filtrarClientesHabilitados
GO

IF OBJECT_ID(N'[MAIDEN].fx_filtrarAutos', N'IF') IS NOT NULL 
	DROP FUNCTION [MAIDEN].fx_filtrarAutos
GO

IF OBJECT_ID(N'[MAIDEN].fx_filtrarAutosHabilitados', N'IF') IS NOT NULL 
	DROP FUNCTION [MAIDEN].fx_filtrarAutosHabilitados
GO

IF OBJECT_ID (N'[MAIDEN].fx_filtrarTurnos', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_filtrarTurnos;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_filtrarTurnosHabilitados', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_filtrarTurnosHabilitados;  
GO  
------------------------------------------- BUSQUEDAS PARA MIGRACION
IF OBJECT_ID (N'[MAIDEN].fx_getTurnoId', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getTurnoId;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getChoferId', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getChoferId;  
GO 

IF OBJECT_ID (N'[MAIDEN].fx_getAutoId', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getAutoId;  
GO 

IF OBJECT_ID (N'[MAIDEN].fx_getClienteId', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getClienteId;  
GO 

-------------------------------------------- LOGIN - USUARIOS
IF OBJECT_ID (N'[MAIDEN].fx_getRolId', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRolId;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getFuncionalidades', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getFuncionalidades;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getRoles', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRoles;  
GO   

IF OBJECT_ID (N'[MAIDEN].fx_getRolesHabilitados', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRolesHabilitados;  
GO   

IF OBJECT_ID (N'[MAIDEN].fx_getRolesDeUsuario', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRolesDeUsuario;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_getFuncionalidades', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getFuncionalidades;  
GO  

------------------------------- CARGAS COMBOBOX
IF OBJECT_ID (N'[MAIDEN].fx_getMarcas', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getMarcas;  
GO 

IF OBJECT_ID (N'[MAIDEN].fx_getUsuarios', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getUsuarios;  
GO 

-------------------------------- VIAJES
IF OBJECT_ID (N'[MAIDEN].fx_getAutoDelChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getAutoDelChofer;  
GO

------------------------------- RENDICION
IF OBJECT_ID (N'[MAIDEN].fx_getDatosRendicion', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getDatosRendicion;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getRendicionExistente', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRendicionExistente;  
GO   

------------------------------- FACTURA
IF OBJECT_ID (N'[MAIDEN].fx_getDatosFactura', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getDatosFactura;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getFacturaExistente', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getFacturaExistente;  
GO  

---------------------------------------- ESTADISTICAS
IF OBJECT_ID (N'[MAIDEN].fx_choferesMayorRecaudacion', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_choferesMayorRecaudacion;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_choferesViajesMasLargos', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_choferesViajesMasLargos;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_clientesMismoAuto', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_clientesMismoAuto;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_clientesMayorConsumo', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_clientesMayorConsumo;  
GO  

 
