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

IF OBJECT_ID ('[ASD].SP_bajaCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_bajaCliente;  
GO

------------------------------------------------->>TURNOS
IF OBJECT_ID ('[ASD].SP_altaTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaTurno;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosTurnos', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosTurnos;  
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

IF OBJECT_ID ('[ASD].SP_bajaChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modifChofer;  
GO


