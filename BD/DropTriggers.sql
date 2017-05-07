USE [GD1C2017]
GO
/****** Object:  Trigger [ASD].[controlTurnosSuperpuestos]    Script Date: 02/05/2017 17:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('[ASD].tg_controlTurnosSuperpuestos', 'TR') IS NOT NULL  
    DROP TRIGGER [ASD].tg_controlTurnosSuperpuestos;  
GO

IF OBJECT_ID ('[ASD].tg_controlActualizacionTurnos', 'TR') IS NOT NULL  
    DROP TRIGGER [ASD].tg_controlActualizacionTurnos;  
GO

IF OBJECT_ID ('[ASD].tg_controlViajesSuperpuestos', 'TR') IS NOT NULL  
    DROP TRIGGER [ASD].tg_controlViajesSuperpuestos;  
GO