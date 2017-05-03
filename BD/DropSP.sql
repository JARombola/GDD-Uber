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
IF OBJECT_ID ('[ASD].SP_cargarTurnos', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_cargarTurnos;  
GO

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


------------------------------------- ROLES
IF OBJECT_ID ('[ASD].SP_altaRol', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaRol
GO

IF OBJECT_ID ('[ASD].SP_eliminarRolEnUsuarios', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarRolEnUsuarios
GO

IF OBJECT_ID ('[ASD].SP_modificarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modificarRol
GO

IF OBJECT_ID ('[ASD].SP_deshabilitarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_deshabilitarRol
GO

IF OBJECT_ID ('[ASD].SP_habilitarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_habilitarRol
GO

IF OBJECT_ID ('[ASD].SP_eliminarTodosRoles', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosRoles
GO

IF OBJECT_ID ('[ASD].SP_crearRolesDefault', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_crearRolesDefault
GO

----------------------------------- USUARIOS
IF OBJECT_ID ('[ASD].SP_altaUsuario', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_altaUsuario
GO

IF OBJECT_ID ('[ASD].SP_modifPass', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_modifPass
GO

IF OBJECT_ID ('[ASD].SP_eliminarUsuario', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarUsuario
GO


IF OBJECT_ID ('[ASD].SP_eliminarTodosUsuarios', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_eliminarTodosUsuarios
GO

IF OBJECT_ID ('[ASD].SP_crearUsuariosDefault', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_crearUsuariosDefault
GO

IF OBJECT_ID ('[ASD].SP_login', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_login
GO

IF OBJECT_ID ('[ASD].SP_loginOk', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_loginOk
GO

IF OBJECT_ID ('[ASD].SP_loginFail', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_loginFail
GO

IF OBJECT_ID ('[ASD].SP_asignarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_asignarRol
GO

IF OBJECT_ID ('[ASD].SP_quitarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [ASD].SP_quitarRol
GO
