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
