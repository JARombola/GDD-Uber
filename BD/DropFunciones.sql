IF EXISTS 
(SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[ASD].fx_filtrarChoferes') 
AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))

DROP FUNCTION [ASD].fx_filtrarChoferes
GO

IF EXISTS 
(SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[ASD].fx_filtrarClientes') 
AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))

DROP FUNCTION [ASD].fx_filtrarClientes
GO

IF EXISTS 
(SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[ASD].fx_filtrarAutos') 
AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))

DROP FUNCTION [ASD].fx_filtrarAutos
GO
