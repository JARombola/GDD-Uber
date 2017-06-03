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

---------------------------------------------------------------------
IF OBJECT_ID (N'[MAIDEN].fx_getCliente', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getCliente;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getChofer;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_getNombreChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getNombreChofer;  
GO   

IF OBJECT_ID (N'[MAIDEN].fx_getAutoDelChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getAutoDelChofer;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getAuto', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getAuto;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getTurno', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getTurno;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getDescripcion', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getDescripcion;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getRol', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRol;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getRolId', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRolId;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getFuncionalidades', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getFuncionalidades;  
GO

IF OBJECT_ID (N'[MAIDEN].fx_getUsuario', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getUsuario;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_getRolesDeUsuario', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getRolesDeUsuario;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_getCantidadRolesDeUsuario', N'FN') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getCantidadRolesDeUsuario;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_getDatosRendicion', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getDatosRendicion;  
GO    

IF OBJECT_ID (N'[MAIDEN].fx_getFuncionalidades', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getFuncionalidades;  
GO  

IF OBJECT_ID (N'[MAIDEN].fx_getDatosFactura', N'IF') IS NOT NULL  
    DROP FUNCTION [MAIDEN].fx_getDatosFactura;  
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