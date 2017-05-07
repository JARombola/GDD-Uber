	-- Si la funcion existe => La borra
	-- IF = Funciones de Tabla, FN = Funciones escalares
IF OBJECT_ID(N'[ASD].fx_filtrarChoferes', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarChoferes
GO

IF OBJECT_ID(N'[ASD].fx_filtrarChoferesHabilitados', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarChoferesHabilitados
GO

IF OBJECT_ID(N'[ASD].fx_filtrarClientes', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarClientes
GO

IF OBJECT_ID(N'[ASD].fx_filtrarClientesHabilitados', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarClientesHabilitados
GO

IF OBJECT_ID(N'[ASD].fx_filtrarAutos', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarAutos
GO

IF OBJECT_ID(N'[ASD].fx_filtrarAutosHabilitados', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarAutosHabilitados
GO

IF OBJECT_ID (N'[ASD].fx_filtrarTurnos', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_filtrarTurnos;  
GO  

IF OBJECT_ID (N'[ASD].fx_filtrarTurnosHabilitados', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_filtrarTurnosHabilitados;  
GO  

IF OBJECT_ID (N'[ASD].fx_getTurnoId', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getTurnoId;  
GO  

IF OBJECT_ID (N'[ASD].fx_getChoferId', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getChoferId;  
GO 

IF OBJECT_ID (N'[ASD].fx_getAutoId', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getAutoId;  
GO 

IF OBJECT_ID (N'[ASD].fx_getClienteId', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getClienteId;  
GO 

---------------------------------------------------------------------
IF OBJECT_ID (N'[ASD].fx_getCliente', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getCliente;  
GO

IF OBJECT_ID (N'[ASD].fx_getChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getChofer;  
GO    

IF OBJECT_ID (N'[ASD].fx_getNombreChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getNombreChofer;  
GO   

IF OBJECT_ID (N'[ASD].fx_getAutoDelChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getAutoDelChofer;  
GO

IF OBJECT_ID (N'[ASD].fx_getAuto', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getAuto;  
GO  

IF OBJECT_ID (N'[ASD].fx_getTurno', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getTurno;  
GO  

IF OBJECT_ID (N'[ASD].fx_getDescripcion', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getDescripcion;  
GO  

IF OBJECT_ID (N'[ASD].fx_getRol', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getRol;  
GO

IF OBJECT_ID (N'[ASD].fx_getRolId', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getRolId;  
GO

IF OBJECT_ID (N'[ASD].fx_getUsuario', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getUsuario;  
GO    

IF OBJECT_ID (N'[ASD].fx_getRolesDeUsuario', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getRolesDeUsuario;  
GO    

IF OBJECT_ID (N'[ASD].fx_getCantidadRolesDeUsuario', N'FN') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getCantidadRolesDeUsuario;  
GO    
