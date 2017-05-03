SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-------------------------------- >> CLIENTES
CREATE PROCEDURE [ASD].SP_cargarClientes 
AS
BEGIN
	Insert into [ASD].Clientes(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		[gd_esquema].Maestra.Cliente_Nombre,
		[gd_esquema].Maestra.Cliente_Apellido,
		[gd_esquema].Maestra.Cliente_DNI,
		[gd_esquema].Maestra.Cliente_Telefono,
		[gd_esquema].Maestra.Cliente_Direccion,
		[gd_esquema].Maestra.Cliente_Mail,
		[gd_esquema].Maestra.Cliente_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosClientes 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Clientes
	
	DELETE FROM [ASD].Clientes
	DBCC CHECKIDENT ('[ASD].Clientes', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_altaCliente(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	INSERT INTO [ASD].Clientes
	values(@nombre, @apellido, @dni, @telefono, @direccion, @mail, @fecha_nacimiento,1)
END
GO

CREATE PROCEDURE [ASD].SP_modifCliente(
		@id int,
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	UPDATE [ASD].fx_getCliente(@id)
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarCliente(@id int)
AS BEGIN
	UPDATE [ASD].fx_getCliente(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarCliente(@id int)
AS BEGIN
	UPDATE [ASD].fx_getCliente(@id)
	SET Habilitado=1
END
GO


-------------------------------- >> CHOFERES

CREATE PROCEDURE [ASD].SP_cargarChoferes 
AS
BEGIN
	Insert into [ASD].Choferes(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		[gd_esquema].Maestra.Cliente_Nombre,
		[gd_esquema].Maestra.Cliente_Apellido,
		[gd_esquema].Maestra.Cliente_DNI,
		[gd_esquema].Maestra.Cliente_Telefono,
		[gd_esquema].Maestra.Cliente_Direccion,
		[gd_esquema].Maestra.Cliente_Mail,
		[gd_esquema].Maestra.Cliente_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosChoferes 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Choferes
	
	DELETE FROM [ASD].Choferes
	DBCC CHECKIDENT ('[ASD].Choferes', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_altaChofer(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	INSERT INTO [ASD].Choferes
	values(@nombre, @apellido, @dni, @telefono, @direccion, @mail, @fecha_nacimiento, 1)
END
GO

CREATE PROCEDURE [ASD].SP_modifChofer(
		@id int,
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	UPDATE [ASD].Choferes
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento
 WHERE ID = @id
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarChofer(@id int)
AS BEGIN
	UPDATE [ASD].fx_getChofer(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarChofer(@id int)
AS BEGIN
	UPDATE [ASD].fx_getChofer(@id)
	SET Habilitado=1
END
GO

------------------------------ >> AUTOS

CREATE PROCEDURE [ASD].SP_cargarAutos
AS
BEGIN
	INSERT INTO [ASD].Autos(Marca, Modelo, Patente, Licencia, Rodado)
	SELECT DISTINCT 
		[gd_esquema].Maestra.Auto_Marca,
		[gd_esquema].Maestra.Auto_Modelo,
		[gd_esquema].Maestra.Auto_Patente,
		[gd_esquema].Maestra.Auto_Licencia,
		[gd_esquema].Maestra.Auto_Rodado
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosAutos
AS
Begin
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Autos
	
	DELETE FROM [ASD].Autos
	DBCC CHECKIDENT ('[ASD].Autos', RESEED, 0)
End
go

CREATE PROCEDURE [ASD].SP_altaAuto(
			@marca varchar(255),
			@modelo varchar(255),
			@patente varchar(10),
			@licencia varchar(26),
			@rodado varchar(10),
			@chofer int)
AS
BEGIN
	Insert into [ASD].Autos
	values(@marca, @modelo, @patente, @licencia, @rodado,@chofer,1)
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarAuto(@id int)
AS BEGIN
	UPDATE [ASD].fx_getAuto(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarAuto(@id int)
AS BEGIN
	UPDATE [ASD].fx_getAuto(@id)
	SET Habilitado=1
END
GO

CREATE PROCEDURE [ASD].SP_modifAuto(
				@id int,
				@marca varchar(255),
				@modelo varchar(255),
				@patente varchar(10),
				@licencia varchar(26),
				@rodado varchar(10),
				@chofer int)
AS
BEGIN
	UPDATE [ASD].Autos
	SET Marca = @marca,
		Modelo = @modelo,
		Patente = @patente,
		Licencia = @licencia,
		Rodado = @rodado,
		Chofer = @chofer
	WHERE ID = @id
END
GO

------------------------------ >> TURNOS

CREATE PROCEDURE [ASD].SP_cargarTurnos
AS
BEGIN
	INSERT INTO [ASD].Turnos(Hora_Inicio, Hora_Fin, Precio_Base, Precio_km, Descripcion)
	SELECT DISTINCT 
		[gd_esquema].Maestra.Turno_Hora_Inicio,
		[gd_esquema].Maestra.Turno_Hora_Fin,
		[gd_esquema].Maestra.Turno_Precio_Base,
		[gd_esquema].Maestra.Turno_Valor_Kilometro,
		[gd_esquema].Maestra.Turno_Descripcion
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [ASD].SP_altaTurno(@inicio numeric(18,0),
								 @fin numeric(18,0),
								 @precioBase numeric(18,2),
								 @precioKm numeric(18,2),
								 @descripcion varchar(255),
								 @habilitado bit) 
AS
BEGIN
	Insert into [ASD].Turnos
	values(@inicio, @fin, @precioBase, @precioKm, @descripcion, @habilitado)
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosTurnos 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Turnos
	
	DELETE FROM [ASD].Turnos
	DBCC CHECKIDENT ('[ASD].Turnos', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarTurno(@id int)
AS
BEGIN
	UPDATE [ASD].fx_getTurno(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [ASD].SP_habilitarTurno(@id int)
AS
BEGIN
	UPDATE [ASD].fx_getTurno(@id)
	SET Habilitado=1
END
GO


CREATE PROCEDURE [ASD].[SP_modifTurno](
					@id int,
					@inicio numeric(18,0),
					@fin numeric(18,0),
					@precioBase numeric(18,2),
					@precioKm numeric(18,2),
					@descripcion varchar(255),
					@habilitado bit)
AS
BEGIN
	UPDATE [ASD].Turnos
	SET Hora_Inicio = @inicio,
		Hora_Fin = @fin,
		Precio_Base = @precioBase,
		Precio_km = @precioKM,
		Descripcion = @descripcion,
		Habilitado = @habilitado
	WHERE ID = @id
END
GO

------------------------------ >> ROLES
CREATE PROCEDURE [ASD].SP_altaRol(@rol varchar(20),
					@clientes bit, @choferes bit, @autos bit, @roles bit,@turnos bit,
					@viajes	bit, @facturacion bit, @rendicion bit, @estadisticas bit)
AS
BEGIN
	INSERT INTO [ASD].Roles
	values(@rol, @clientes,@choferes,@autos,@roles,@turnos,@viajes,@facturacion,@rendicion,@estadisticas,1)
END
GO


CREATE PROCEDURE [ASD].SP_modificarRol(@id int, @rol varchar(20),
					@clientes bit, @choferes bit, @autos bit, @roles bit,@turnos bit,
					@viajes	bit, @facturacion bit, @rendicion bit, @estadisticas bit)
AS
BEGIN
	UPDATE [ASD].fx_getRol(@id)
	SET 
	Rol = @rol,
	Clientes = @clientes,
	Choferes = @choferes,
	Autos = @autos,
	Roles = @roles,
	Turnos = @turnos,
	Viajes = @viajes,
	Facturacion = @facturacion,
	Rendicion = @rendicion,
	Estadisticas = @estadisticas
END
GO

CREATE PROCEDURE [ASD].SP_eliminarRolEnUsuarios(@id int)
AS
BEGIN
	DELETE [ASD].RolXUsuario where Rol = @id
END
GO

CREATE PROCEDURE [ASD].SP_deshabilitarRol(@id int)
AS
BEGIN
	UPDATE [ASD].fx_getRol(@id)
	SET Habilitado = 0
	EXEC [ASD].SP_eliminarRolEnUsuarios @id
END
GO

CREATE PROCEDURE [ASD].SP_habilitarRol(@id int)
AS
BEGIN
	UPDATE [ASD].fx_getRol(@id)
	SET Habilitado = 1
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosRoles
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [ASD].Roles

	DELETE FROM [ASD].Turnos
	DBCC CHECKIDENT ('[ASD].Roles', RESEED, 0)
END
GO

CREATE PROCEDURE [ASD].SP_crearRolesDefault
AS
BEGIN
	Exec [ASD].SP_altaRol 'admin',1,1,1,1,1,1,1,1,1
	Exec [ASD].SP_altaRol 'cliente',0,0,0,0,0,0,0,1,0
	Exec [ASD].SP_altaRol 'chofer',0,0,0,0,0,0,1,0,0
								 -- @rol, @clientes, @choferes, @autos, @roles, @turnos, @viajes,
								 -- @facturacion, @rendicion, @estadisticas
END
GO

---------------------------------- USUARIOS
CREATE PROCEDURE [ASD].SP_altaUsuario(@usuario varchar(30), @pass varchar(256))
AS
BEGIN
	INSERT INTO [ASD].Usuarios
	values(@usuario,HASHBYTES('SHA2_256',@pass),0)
END
GO

CREATE PROCEDURE [ASD].SP_modifPass(@usuario varchar(30), @pass varchar(256))
AS
BEGIN
	UPDATE [ASD].Usuarios
	SET Pass = HASHBYTES('SHA2_256',@pass)
	WHERE Usuario = @usuario
END
GO

CREATE PROCEDURE [ASD].SP_eliminarUsuario(@usuario varchar(30))
AS
BEGIN
	DELETE [ASD].RolXUsuario						--- Primero se le borran los roles para evitar problemas con FK
	WHERE Usuario = @usuario
	Delete [ASD].Usuarios							--- Despues se borra el usuario
	WHERE Usuario = @usuario
END
GO

CREATE PROCEDURE [ASD].SP_crearUsuariosDefault
AS
BEGIN
	Exec [ASD].SP_altaUsuario 'admin','w23e'
	Exec [ASD].SP_altaUsuario 'cliente','cliente'
	Exec [ASD].SP_altaUsuario 'chofer','chofer'
END
GO

CREATE PROCEDURE [ASD].SP_eliminarTodosUsuarios
AS
BEGIN
	DELETE FROM [ASD].Usuarios
END
GO

CREATE PROCEDURE [ASD].SP_loginOk(@usuario varchar(30))
AS
BEGIN
	Declare @intentos int
	SET @intentos = (select intentosLogueo from [ASD].fx_getUsuario(@usuario))
	if (@intentos >=3) return 0
	else BEGIN
		UPDATE [ASD].fx_getUsuario(@usuario)
		SET intentosLogueo = 0
		return 3
	END
END
GO

CREATE PROCEDURE [ASD].SP_loginFail(@usuario varchar(30))
AS
BEGIN
	Declare @intentosRealizados int, @msg varchar(100)
	SET @intentosRealizados = (select intentosLogueo from [ASD].fx_getUsuario(@usuario))
	if (@intentosRealizados < 3) BEGIN							-- se le agrega un intento fallido
						UPDATE [ASD].fx_getUsuario(@usuario)
						SET intentosLogueo = intentosLogueo + 1
						return (3-(@intentosRealizados+1))
					   END;
	else BEGIN
		if (@intentosRealizados=3) return 0			--Intentos realizados = 3 = max => Deshabilitado
		else throw 51000, 'Usuario Inexistente',1		-- Mal el usuario
		END 
END
GO

CREATE PROCEDURE [ASD].SP_login(@usuario varchar(30), @password varchar(256))
AS
BEGIN 
	Declare @contraseña varchar(256), @resultado int
	SET @contraseña = (Select pass from [ASD].fx_getUsuario(@usuario))
	if( HASHBYTES('SHA2_256',@password) = @contraseña)
		EXEC @resultado = [ASD].SP_loginOk @usuario
	else Exec @resultado = [ASD].SP_loginFail @usuario
	SELECT @resultado
END
GO

CREATE PROCEDURE [ASD].SP_asignarRol(@usuario varchar(30), @rol varchar(20))
AS
BEGIN 
	declare @rolId int
	set @rolId = [ASD].fx_getRolId(@rol)
	if (not exists (Select 1 from [ASD].RolXUsuario			-- Si no tenia asignado el rol se lo asigna. Sino no hace nada
						where usuario = @usuario and rol = @rolId))			  
	Begin
		Insert into [ASD].RolXUsuario
		values(@usuario,@rolId)
	End
END
GO

CREATE PROCEDURE [ASD].SP_quitarRol(@usuario varchar(30), @rol varchar(20))
AS
BEGIN 
	DECLARE @RolId int
	Set @RolId = [ASD].fx_getRolId(@rol)
	Delete from [ASD].RolXUsuario where(
	Usuario = @usuario AND Rol = @RolId)
END
GO

