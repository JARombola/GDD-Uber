----------------------------------------------->>CLIENTES
IF OBJECT_ID ('[ASD].SP_cargarClientes', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_cargarClientes;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosClientes', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosClientes;  
GO

IF OBJECT_ID ('[ASD].SP_altaCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaCliente;  
GO

IF OBJECT_ID ('[ASD].SP_modifCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modifCliente;  
GO

IF OBJECT_ID ('[ASD].SP_deshabilitarCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_deshabilitarCliente;  
GO

IF OBJECT_ID ('[ASD].SP_habilitarCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_habilitarCliente;  
GO

------------------------------------------------->>TURNOS
IF OBJECT_ID ('[ASD].SP_altaTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaTurno;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosTurnos', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosTurnos;  
GO

IF OBJECT_ID ('[ASD].SP_deshabilitarTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_deshabilitarTurno;  
GO

IF OBJECT_ID ('[ASD].SP_habilitarTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_habilitarTurno;  
GO

IF OBJECT_ID ('[ASD].SP_modifTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modifTurno;  
GO

------------------------------------------------->>CHOFERES
IF OBJECT_ID ('[ASD].SP_cargarChoferes', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_cargarChoferes;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosChoferes', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosChoferes;  
GO

IF OBJECT_ID ('[ASD].SP_altaChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaChofer;  
GO

IF OBJECT_ID ('[ASD].SP_modifChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modifChofer;  
GO

IF OBJECT_ID ('[ASD].SP_deshabilitarChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_deshabilitarChofer;  
GO

IF OBJECT_ID ('[ASD].SP_habilitarChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_habilitarChofer;  
GO

------------------------------------- AUTOS
IF OBJECT_ID ('[ASD].SP_cargarAutos', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_cargarAutos;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosAutos', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosAutos
GO

IF OBJECT_ID ('[ASD].SP_altaAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaAuto
GO

IF OBJECT_ID ('[ASD].SP_deshabilitarAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_deshabilitarAuto
GO

IF OBJECT_ID ('[ASD].SP_habilitarAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_habilitarAuto
GO

IF OBJECT_ID ('[ASD].SP_modifAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modifAuto
GO
