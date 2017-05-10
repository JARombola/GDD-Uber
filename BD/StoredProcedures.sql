SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--------------------------------------------------------------- >> CLIENTES
CREATE PROCEDURE [MAIDEN].SP_cargarClientes 
AS
BEGIN
	Insert into [MAIDEN].Clientes(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
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

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosClientes 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Clientes
	
	DELETE FROM [MAIDEN].Clientes
	DBCC CHECKIDENT ('[MAIDEN].Clientes', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_altaCliente(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	INSERT INTO [MAIDEN].Clientes
	values(@nombre, @apellido, @dni, @telefono, @direccion, @mail, @fecha_nacimiento,1)
END
GO

CREATE PROCEDURE [MAIDEN].SP_modifCliente(
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
	UPDATE [MAIDEN].fx_getCliente(@id)
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento
END
GO

CREATE PROCEDURE [MAIDEN].SP_deshabilitarCliente(@id int)
AS BEGIN
	UPDATE [MAIDEN].fx_getCliente(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [MAIDEN].SP_habilitarCliente(@id int)
AS BEGIN
	UPDATE [MAIDEN].fx_getCliente(@id)
	SET Habilitado=1
END
GO


--------------------------------------------------------------- >> CHOFERES

CREATE PROCEDURE [MAIDEN].SP_cargarChoferes 
AS
BEGIN
	Insert into [MAIDEN].Choferes(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		[gd_esquema].Maestra.Chofer_Nombre,
		[gd_esquema].Maestra.Chofer_Apellido,
		[gd_esquema].Maestra.Chofer_DNI,
		[gd_esquema].Maestra.Chofer_Telefono,
		[gd_esquema].Maestra.Chofer_Direccion,
		[gd_esquema].Maestra.Chofer_Mail,
		[gd_esquema].Maestra.Chofer_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosChoferes 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Choferes
	
	DELETE FROM [MAIDEN].Choferes
	DBCC CHECKIDENT ('[MAIDEN].Choferes', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_altaChofer(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	INSERT INTO [MAIDEN].Choferes
	values(@nombre, @apellido, @dni, @telefono, @direccion, @mail, @fecha_nacimiento, 1)
END
GO

CREATE PROCEDURE [MAIDEN].SP_modifChofer(
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
	UPDATE [MAIDEN].Choferes
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

CREATE PROCEDURE [MAIDEN].SP_deshabilitarChofer(@id int)
AS BEGIN
	UPDATE [MAIDEN].fx_getChofer(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [MAIDEN].SP_habilitarChofer(@id int)
AS BEGIN
	UPDATE [MAIDEN].fx_getChofer(@id)
	SET Habilitado=1
END
GO

--------------------------------------------------------------- >> AUTOS
--		******** TIENEN QUE ESTAR CARGADOS LOS CHOFERES ANTES*********
CREATE PROCEDURE [MAIDEN].SP_cargarAutos
AS
BEGIN
	INSERT INTO [MAIDEN].Autos(Marca, Modelo, Patente, Licencia, Rodado, Chofer)
	SELECT DISTINCT 
		[gd_esquema].Maestra.Auto_Marca,
		[gd_esquema].Maestra.Auto_Modelo,
		[gd_esquema].Maestra.Auto_Patente,
		[gd_esquema].Maestra.Auto_Licencia,
		[gd_esquema].Maestra.Auto_Rodado,
		[MAIDEN].fx_getChoferId([gd_esquema].Maestra.Chofer_Dni)
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosAutos
AS
Begin
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Autos
	
	DELETE FROM [MAIDEN].Autos
	DBCC CHECKIDENT ('[MAIDEN].Autos', RESEED, 0)
End
go

CREATE PROCEDURE [MAIDEN].SP_altaAuto(
			@marca varchar(255),
			@modelo varchar(255),
			@patente varchar(10),
			@chofer int,
			@turno int)
AS
BEGIN
	Insert into [MAIDEN].vw_Autos(Marca,Modelo,Patente,Chofer,Turno)
	values(@marca, @modelo, @patente,@chofer, @turno)
END
GO

CREATE PROCEDURE [MAIDEN].SP_deshabilitarAuto(@id int)
AS BEGIN
	UPDATE [MAIDEN].fx_getAuto(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [MAIDEN].SP_habilitarAuto(@id int)
AS BEGIN
	UPDATE [MAIDEN].fx_getAuto(@id)
	SET Habilitado=1
END
GO

CREATE PROCEDURE [MAIDEN].SP_modifAuto(
				@id int,
				@marca varchar(255),
				@modelo varchar(255),
				@patente varchar(10),
				@chofer int,
				@turno int)
AS
BEGIN
	UPDATE [MAIDEN].Autos
	SET Marca = @marca,
		Modelo = @modelo,
		Patente = @patente,
		Chofer = @chofer,
		Turno = @turno
	WHERE ID = @id
END
GO

--------------------------------------------------------------- >> TURNOS

CREATE PROCEDURE [MAIDEN].SP_cargarTurnos
AS
BEGIN
	INSERT INTO [MAIDEN].Turnos(Hora_Inicio, Hora_Fin, Precio_Base, Precio_km, Descripcion)
	SELECT DISTINCT 
		[gd_esquema].Maestra.Turno_Hora_Inicio,
		[gd_esquema].Maestra.Turno_Hora_Fin,
		[gd_esquema].Maestra.Turno_Precio_Base,
		[gd_esquema].Maestra.Turno_Valor_Kilometro,
		[gd_esquema].Maestra.Turno_Descripcion
	FROM [gd_esquema].Maestra
END
GO

CREATE PROCEDURE [MAIDEN].SP_altaTurno(@inicio numeric(18,0),
								 @fin numeric(18,0),
								 @precioBase numeric(18,2),
								 @precioKm numeric(18,2),
								 @descripcion varchar(255),
								 @habilitado bit) 
AS
BEGIN
	Insert into [MAIDEN].Turnos
	values(@inicio, @fin, @precioBase, @precioKm, @descripcion, @habilitado)
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosTurnos 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Turnos
	
	DELETE FROM [MAIDEN].Turnos
	DBCC CHECKIDENT ('[MAIDEN].Turnos', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_deshabilitarTurno(@id int)
AS
BEGIN
	UPDATE [MAIDEN].fx_getTurno(@id)
	SET Habilitado=0
END
GO

CREATE PROCEDURE [MAIDEN].SP_habilitarTurno(@id int)
AS
BEGIN
	UPDATE [MAIDEN].fx_getTurno(@id)
	SET Habilitado=1
END
GO


CREATE PROCEDURE [MAIDEN].[SP_modifTurno](
					@id int,
					@inicio numeric(18,0),
					@fin numeric(18,0),
					@precioBase numeric(18,2),
					@precioKm numeric(18,2),
					@descripcion varchar(255),
					@habilitado bit)
AS
BEGIN
	UPDATE [MAIDEN].Turnos
	SET Hora_Inicio = @inicio,
		Hora_Fin = @fin,
		Precio_Base = @precioBase,
		Precio_km = @precioKM,
		Descripcion = @descripcion,
		Habilitado = @habilitado
	WHERE ID = @id
END
GO

--------------------------------------------------------------- >> ROLES
CREATE PROCEDURE [MAIDEN].SP_altaRol(@rol varchar(20),
					@clientes bit, @choferes bit, @autos bit, @roles bit,@turnos bit,
					@viajes	bit, @facturacion bit, @rendicion bit, @estadisticas bit)
AS
BEGIN
	INSERT INTO [MAIDEN].Roles
	values(@rol, @clientes,@choferes,@autos,@roles,@turnos,@viajes,@facturacion,@rendicion,@estadisticas,1)
END
GO


CREATE PROCEDURE [MAIDEN].SP_modificarRol(@id int, @rol varchar(20),
					@clientes bit, @choferes bit, @autos bit, @roles bit,@turnos bit,
					@viajes	bit, @facturacion bit, @rendicion bit, @estadisticas bit)
AS
BEGIN
	UPDATE [MAIDEN].fx_getRol(@id)
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

CREATE PROCEDURE [MAIDEN].SP_eliminarRolEnUsuarios(@id int)
AS
BEGIN
	DELETE [MAIDEN].RolXUsuario where Rol = @id
END
GO

CREATE PROCEDURE [MAIDEN].SP_deshabilitarRol(@id int)
AS
BEGIN
	UPDATE [MAIDEN].fx_getRol(@id)
	SET Habilitado = 0
	EXEC [MAIDEN].SP_eliminarRolEnUsuarios @id
END
GO

CREATE PROCEDURE [MAIDEN].SP_habilitarRol(@id int)
AS
BEGIN
	UPDATE [MAIDEN].fx_getRol(@id)
	SET Habilitado = 1
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosRoles
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Roles

	DELETE FROM [MAIDEN].Turnos
	DBCC CHECKIDENT ('[MAIDEN].Roles', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_crearRolesDefault
AS
BEGIN
	Exec [MAIDEN].SP_altaRol 'admin',1,1,1,1,1,1,1,1,1
	Exec [MAIDEN].SP_altaRol 'cliente',0,0,0,0,0,0,0,1,0
	Exec [MAIDEN].SP_altaRol 'chofer',0,0,0,0,0,0,1,0,0
								 -- @rol, @clientes, @choferes, @autos, @roles, @turnos, @viajes,
								 -- @facturacion, @rendicion, @estadisticas
END
GO

--------------------------------------------------------------- USUARIOS
CREATE PROCEDURE [MAIDEN].SP_altaUsuario(@usuario varchar(30), @pass varchar(256))
AS
BEGIN
	INSERT INTO [MAIDEN].Usuarios
	values(@usuario,HASHBYTES('SHA2_256',@pass),0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_modifPass(@usuario varchar(30), @pass varchar(256))
AS
BEGIN
	UPDATE [MAIDEN].Usuarios
	SET Pass = HASHBYTES('SHA2_256',@pass)
	WHERE Usuario = @usuario
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarUsuario(@usuario varchar(30))
AS
BEGIN
	DELETE [MAIDEN].RolXUsuario						--- Primero se le borran los roles para evitar problemas con FK
	WHERE Usuario = @usuario
	Delete [MAIDEN].Usuarios							--- Despues se borra el usuario
	WHERE Usuario = @usuario
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosUsuarios
AS
BEGIN
	DELETE FROM [MAIDEN].RolXUsuario
	DELETE FROM [MAIDEN].Usuarios
END
GO

CREATE PROCEDURE [MAIDEN].SP_loginOk(@usuario varchar(30))
AS
BEGIN
	Declare @intentos int
	SET @intentos = (select intentosLogueo from [MAIDEN].fx_getUsuario(@usuario))
	if (@intentos >=3) return 0
	else BEGIN
		UPDATE [MAIDEN].fx_getUsuario(@usuario)
		SET intentosLogueo = 0
		return 3
	END
END
GO

CREATE PROCEDURE [MAIDEN].SP_loginFail(@usuario varchar(30))
AS
BEGIN
	Declare @intentosRealizados int, @msg varchar(100)
	SET @intentosRealizados = (select intentosLogueo from [MAIDEN].fx_getUsuario(@usuario))
	if (@intentosRealizados < 3) BEGIN							-- se le agrega un intento fallido
						UPDATE [MAIDEN].fx_getUsuario(@usuario)
						SET intentosLogueo = intentosLogueo + 1
						return (3-(@intentosRealizados+1))
					   END;
	else BEGIN
		if (@intentosRealizados=3) return 0			--Intentos realizados = 3 = max => Deshabilitado
		else throw 51000, 'Usuario Inexistente',1		-- Mal el usuario
		END 
END
GO

CREATE PROCEDURE [MAIDEN].SP_login(@usuario varchar(30), @password varchar(256))
AS
BEGIN 
	Declare @contraseña varchar(256), @resultado int
	SET @contraseña = (Select pass from [MAIDEN].fx_getUsuario(@usuario))
	if( HASHBYTES('SHA2_256',@password) = @contraseña)
		EXEC @resultado = [MAIDEN].SP_loginOk @usuario
	else Exec @resultado = [MAIDEN].SP_loginFail @usuario
	SELECT @resultado
END
GO

CREATE PROCEDURE [MAIDEN].SP_asignarRol(@usuario varchar(30), @rol varchar(20))
AS
BEGIN 
	declare @rolId int
	set @rolId = [MAIDEN].fx_getRolId(@rol)
	if (not exists (Select 1 from [MAIDEN].RolXUsuario			-- Si no tenia asignado el rol se lo asigna. Sino no hace nada
						where usuario = @usuario and rol = @rolId))			  
	Begin
		Insert into [MAIDEN].RolXUsuario
		values(@usuario,@rolId)
	End
END
GO

CREATE PROCEDURE [MAIDEN].SP_quitarRol(@usuario varchar(30), @rol varchar(20))
AS
BEGIN 
	DECLARE @RolId int
	Set @RolId = [MAIDEN].fx_getRolId(@rol)
	Delete from [MAIDEN].RolXUsuario where(
	Usuario = @usuario AND Rol = @RolId)
END
GO

CREATE PROCEDURE [MAIDEN].SP_crearUsuariosDefault
AS
BEGIN
	Exec [MAIDEN].SP_altaUsuario 'admin','w23e'
	Exec [MAIDEN].SP_asignarRol 'admin', 'admin'
	Exec [MAIDEN].SP_altaUsuario 'cliente','cliente'
	Exec [MAIDEN].SP_asignarRol 'cliente', 'cliente'
	Exec [MAIDEN].SP_altaUsuario 'chofer','chofer'
	Exec [MAIDEN].SP_asignarRol 'chofer','chofer'
END
GO
--------------------------------------------------------------- VIAJES
CREATE PROCEDURE [MAIDEN].SP_altaViaje(@idChofer int,
									@idAuto int,
									@kms numeric(18,0),
									@fecha datetime,
									@idCliente int,
									@horaFin time)
AS
BEGIN 
	Declare @idTurno int
	Select @idTurno = ID from [MAIDEN].Turnos where (
		DATEPART(HOUR,@fecha) between Hora_Inicio and Hora_Fin
	)
	if (@idTurno is null) throw 51000,'No hay turno en ese horario',16;
	else BEGIN
			if (@idTurno = (select Turno from [MAIDEN].Autos where ID = @idAuto))			-- Verifica que el turno que corresponde (segun los horarios ingresados) 
			BEGIN																			-- coincida con el turno registrado en el auto
				INSERT INTO [MAIDEN].vw_Viajes(Chofer,Auto,Turno,Km,Fecha,Cliente,Hora_Fin)
				values(@idChofer, @idAuto,@idTurno , @kms, @fecha, @idCliente,@horaFin)
			END
			else throw 51000,'El horario no coincide con el turno del auto',16;
		END
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosViajes
AS
BEGIN
	DELETE FROM [MAIDEN].Viajes
	DBCC CHECKIDENT ('[MAIDEN].Viajes', RESEED, 0)
END
GO
-------- ***** TIENEN QUE ESTAR CHOFERES, AUTOS, TURNOS y CLIENES CARGADOS****-----------
CREATE PROCEDURE [MAIDEN].SP_cargarViajes
AS
BEGIN
	Insert into [MAIDEN].Viajes(Chofer,Auto,Turno,Km,Fecha,Cliente)
	Select distinct 
		[MAIDEN].fx_getChoferId(Chofer_dni),
		[MAIDEN].fx_getAutoId(Auto_Patente),
		[MAIDEN].fx_getTurnoId(Turno_Hora_Inicio),
		Viaje_Cant_Kilometros,
		Viaje_Fecha,
		[MAIDEN].fx_getClienteId(Cliente_Dni)
	From [gd_esquema].Maestra
END
GO


--------------------------------------------------------------- RENDICION
--****************** FALTA SUMARLE EL TEMA DEL IMPORTE DE LAS RENDICIONES QUE NO ENTIENDO COMO ES	**************************************
CREATE PROCEDURE [MAIDEN].SP_rendicion(@idChofer int, @idTurno int, @fecha Date)
AS BEGIN
	DECLARE @total numeric(18,2)
	DECLARE @nro_rendicion numeric(18,2)
	DECLARE @Tabla_Viajes Table(							-- Guardo en una variable de tabla, los datos de los viajes, turnos, etc.
		viajeId int, clienteId int,horaInicio datetime, horaFin time, kms numeric(18,0), precioBase numeric(18,2), precioKm numeric(18,2), totalDelViaje numeric(18,2), totalDelDia numeric(18,2)
		)
		if not exists (select 1 from [MAIDEN].Rendicion where Chofer = @idChofer and cast(Fecha as date) = @fecha)			-- Si la rendicion NO existia, la creo (tengo que consultar a TODOS los viajes para ver cuales corresponden)
			BEGIN
				Insert into @Tabla_Viajes(viajeId,clienteId,horaInicio,horaFin,kms,precioBase,precioKm,totalDelViaje)									
				Select * from [MAIDEN].fx_crearRendicion(@idChofer,@idTurno,@fecha)
				Select @total = sum(totalDelViaje) from @Tabla_Viajes

				INSERT INTO @Tabla_Viajes(totalDelDia)
				values(@total)
	
				INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Total,Importe)
				Values(@idChofer, CAST(@fecha as DateTime),@total,0)
	
				SET @nro_rendicion = @@IDENTITY
	
				Insert into [MAIDEN].Rendicion_viajes(Viaje,Nro_Rendicion)
				Select viajeId,@nro_rendicion from @Tabla_Viajes where viajeId IS NOT NULL
			END
			ELSE BEGIN																							-- Si la rendicion ya existia, solo consulto los viajes que estaban registrados para la rendicion
				Insert into @Tabla_Viajes(viajeId,clienteId,horaInicio,horaFin,kms,precioBase,precioKm,totalDelViaje)
				SELECT * FROM [MAIDEN].fx_cargarRendicion(@idChofer)
				Select @total = sum(totalDelViaje) from @Tabla_Viajes
				INSERT INTO @Tabla_Viajes(totalDelDia)
				values(@total)
			END
	

	Select (select nombre+' '+apellido as Cliente from [MAIDEN].fx_getCliente(viaje.clienteId))as 'Cliente', FORMAT(viaje.horaInicio,'HH:mm') as 'Hora Inicio', FORMAT(viaje.horaFin,'HH:mm') as 'Hora Fin', viaje.kms as 'Distancia(Kms)', viaje.precioBase as 'Precio Base', viaje.precioKm as 'Precio Km', viaje.totalDelViaje as '$ del viaje', viaje.totalDelDia as '$ TOTAL'
		FROM @Tabla_Viajes viaje
		GROUP BY viaje.clienteId,viaje.horaInicio,viaje.horaFin,viaje.kms,viaje.precioBase,viaje.precioKm,viaje.totalDelViaje,viaje.totalDelDia
		ORDER BY CASE WHEN viaje.horaInicio IS NULL THEN 1
						 else 0
						 END
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodasRendiciones
AS
Begin

	DELETE FROM [MAIDEN].Rendicion_viajes				--Primero elimino esta porque hace referencia a RENDICION
	
	DELETE FROM [MAIDEN].Rendicion
	
	DELETE FROM [MAIDEN].Rendicion
	DBCC CHECKIDENT ('[MAIDEN].Rendicion', RESEED, 0)


End


