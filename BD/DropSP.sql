--							>>CLIENTES
IF OBJECT_ID ('[ASD].SP_cargarClientes', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_cargarClientes;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosClientes', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosClientes;  
GO

--							>>TURNOS
IF OBJECT_ID ('[ASD].SP_altaTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaTurno;  
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosTurnos', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosTurnos;  
GO

IF OBJECT_ID ('[ASD].SP_altaCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaCliente;  
GO

