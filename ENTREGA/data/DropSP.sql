----------------------------------------------->>CLIENTES
IF OBJECT_ID ('[MAIDEN].SP_migrarClientes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarClientes;  
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosClientes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosClientes;  
GO

IF OBJECT_ID ('[MAIDEN].SP_altaCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaCliente;  
GO

IF OBJECT_ID ('[MAIDEN].SP_modifCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_modifCliente;  
GO

IF OBJECT_ID ('[MAIDEN].SP_deshabilitarCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_deshabilitarCliente;  
GO

IF OBJECT_ID ('[MAIDEN].SP_habilitarCliente', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_habilitarCliente;  
GO

------------------------------------------------->>TURNOS
IF OBJECT_ID ('[MAIDEN].SP_migrarTurnos', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarTurnos;  
GO

IF OBJECT_ID ('[MAIDEN].SP_altaTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaTurno;  
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosTurnos', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosTurnos;  
GO

IF OBJECT_ID ('[MAIDEN].SP_deshabilitarTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_deshabilitarTurno;  
GO

IF OBJECT_ID ('[MAIDEN].SP_habilitarTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_habilitarTurno;  
GO

IF OBJECT_ID ('[MAIDEN].SP_modifTurno', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_modifTurno;  
GO

------------------------------------------------->>CHOFERES
IF OBJECT_ID ('[MAIDEN].SP_migrarChoferes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarChoferes;  
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosChoferes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosChoferes;  
GO

IF OBJECT_ID ('[MAIDEN].SP_altaChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaChofer;  
GO

IF OBJECT_ID ('[MAIDEN].SP_modifChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_modifChofer;  
GO

IF OBJECT_ID ('[MAIDEN].SP_deshabilitarChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_deshabilitarChofer;  
GO

IF OBJECT_ID ('[MAIDEN].SP_habilitarChofer', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_habilitarChofer;  
GO

------------------------------------- AUTOS
IF OBJECT_ID ('[MAIDEN].SP_migrarAutos', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarAutos;  
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosAutos', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosAutos
GO

IF OBJECT_ID ('[MAIDEN].SP_altaAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaAuto
GO

IF OBJECT_ID ('[MAIDEN].SP_deshabilitarAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_deshabilitarAuto
GO

IF OBJECT_ID ('[MAIDEN].SP_habilitarAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_habilitarAuto
GO

IF OBJECT_ID ('[MAIDEN].SP_modifAuto', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_modifAuto
GO


------------------------------------- ROLES
IF OBJECT_ID ('[MAIDEN].SP_altaRol', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaRol
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarRolEnUsuarios', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarRolEnUsuarios
GO

IF OBJECT_ID ('[MAIDEN].SP_modifRol', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_modifRol
GO

IF OBJECT_ID ('[MAIDEN].SP_deshabilitarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_deshabilitarRol
GO

IF OBJECT_ID ('[MAIDEN].SP_habilitarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_habilitarRol
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosRoles', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosRoles
GO

IF OBJECT_ID ('[MAIDEN].SP_crearRolesDefault', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_crearRolesDefault
GO

IF OBJECT_ID ('[MAIDEN].SP_crearFuncionalidadesDefault', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_crearFuncionalidadesDefault
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodasFuncionalidades', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodasFuncionalidades
GO

----------------------------------- USUARIOS
IF OBJECT_ID ('[MAIDEN].SP_altaUsuario', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaUsuario
GO

IF OBJECT_ID ('[MAIDEN].SP_modifPass', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_modifPass
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarUsuario', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarUsuario
GO


IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosUsuarios', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosUsuarios
GO

IF OBJECT_ID ('[MAIDEN].SP_crearUsuariosDefault', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_crearUsuariosDefault
GO

IF OBJECT_ID ('[MAIDEN].SP_login', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_login
GO

IF OBJECT_ID ('[MAIDEN].SP_loginOk', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_loginOk
GO

IF OBJECT_ID ('[MAIDEN].SP_loginFail', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_loginFail
GO

IF OBJECT_ID ('[MAIDEN].SP_asignarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_asignarRol
GO

IF OBJECT_ID ('[MAIDEN].SP_quitarRol', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_quitarRol
GO

----------------------------------- VIAJES
IF OBJECT_ID ('[MAIDEN].SP_altaViaje', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_altaViaje
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodosViajes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodosViajes
GO

IF OBJECT_ID ('[MAIDEN].SP_migrarViajes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarViajes
GO
-------------------------------------------- RENDICIONES
IF OBJECT_ID ('[MAIDEN].SP_rendicion', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_rendicion
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodasRendiciones', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodasRendiciones
GO

IF OBJECT_ID ('[MAIDEN].SP_migrarRendiciones', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarRendiciones
GO

IF OBJECT_ID ('[MAIDEN].SP_actualizarRendicionEnViajes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_actualizarRendicionEnViajes
GO

------------------------------------------- FACTURAS
IF OBJECT_ID ('[MAIDEN].SP_actualizarFacturaEnViajes', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_actualizarFacturaEnViajes
GO

IF OBJECT_ID ('[MAIDEN].SP_Facturacion', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_Facturacion
GO

IF OBJECT_ID ('[MAIDEN].SP_migrarFacturas', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_migrarFacturas
GO

IF OBJECT_ID ('[MAIDEN].SP_eliminarTodasFacturas', 'P') IS NOT NULL  
    DROP PROCEDURE [MAIDEN].SP_eliminarTodasFacturas
GO

