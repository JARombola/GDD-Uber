	-- Si la funcion existe => La borra
IF OBJECT_ID(N'[ASD].fx_filtrarChoferes', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarChoferes
GO

IF OBJECT_ID(N'[ASD].fx_filtrarClientes', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarClientes
GO

IF OBJECT_ID(N'[ASD].fx_filtrarAutos', N'IF') IS NOT NULL 
	DROP FUNCTION [ASD].fx_filtrarAutos
GO

IF OBJECT_ID (N'[ASD].fx_filtrarTurnos', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_filtrarTurnos;  
GO  

IF OBJECT_ID (N'[ASD].fx_getCliente', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getCliente;  
GO

IF OBJECT_ID (N'[ASD].fx_getChofer', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getChofer;  
GO    

IF OBJECT_ID (N'[ASD].fx_getAuto', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getAuto;  
GO  

IF OBJECT_ID (N'[ASD].fx_getTurno', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getTurno;  
GO  

IF OBJECT_ID (N'[ASD].fx_getRol', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getRol;  
GO

IF OBJECT_ID (N'[ASD].fx_getUsuario', N'IF') IS NOT NULL  
    DROP FUNCTION [ASD].fx_getUsuario;  
GO    
