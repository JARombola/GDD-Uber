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
	Insert into [MAIDEN].Cliente(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
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
	DELETE FROM [MAIDEN].Cliente
	
	DELETE FROM [MAIDEN].Cliente
	DBCC CHECKIDENT ('[MAIDEN].Cliente', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_altaCliente(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@piso int,
		@depto char(1),
		@localidad varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
		
AS
BEGIN
	INSERT INTO [MAIDEN].Cliente(Nombre,Apellido,DNI,Telefono,Direccion,piso,depto,localidad,mail,Fecha_Nacimiento)
	values(@nombre, @apellido, @dni,@telefono, @direccion,@piso,@depto,@localidad, @mail, @fecha_nacimiento)
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
	Insert into [MAIDEN].Chofer(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
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
	DELETE FROM [MAIDEN].Chofer
	
	DELETE FROM [MAIDEN].Chofer
	DBCC CHECKIDENT ('[MAIDEN].Chofer', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_altaChofer(
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@piso int,
		@depto char(1),
		@localidad varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime)
AS
BEGIN
	INSERT INTO [MAIDEN].Chofer(Nombre,Apellido,Dni,Telefono,Direccion,piso,depto,localidad,Mail,Fecha_Nacimiento)
	values(@nombre, @apellido, @dni,@telefono, @direccion,@piso,@depto,@localidad, @mail, @fecha_nacimiento)
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
	UPDATE [MAIDEN].getChofer(@id)
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
	INSERT INTO [MAIDEN].Auto(Marca, Modelo, Patente, Licencia, Rodado, Chofer)
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
	DELETE FROM [MAIDEN].Auto
	
	DELETE FROM [MAIDEN].Auto
	DBCC CHECKIDENT ('[MAIDEN].Auto', RESEED, 0)
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
	Insert into [MAIDEN].Auto(Marca,Modelo,Patente,Chofer,Turno)
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
	UPDATE [MAIDEN].fx_getAuto(@id)
	SET Marca = @marca,
		Modelo = @modelo,
		Patente = @patente,
		Chofer = @chofer,
		Turno = @turno
END
GO

--------------------------------------------------------------- >> TURNOS

CREATE PROCEDURE [MAIDEN].SP_cargarTurnos
AS
BEGIN
	INSERT INTO [MAIDEN].Turno(Hora_Inicio, Hora_Fin, Precio_Base, Precio_km, Descripcion)
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
	Insert into [MAIDEN].Turno
	values(@inicio, @fin, @precioBase, @precioKm, @descripcion, @habilitado)
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosTurnos 
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Turno
	
	DELETE FROM [MAIDEN].Turno
	DBCC CHECKIDENT ('[MAIDEN].Turno', RESEED, 0)
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
	UPDATE [MAIDEN].fx_getTurno(@id)
	SET Hora_Inicio = @inicio,
		Hora_Fin = @fin,
		Precio_Base = @precioBase,
		Precio_km = @precioKM,
		Descripcion = @descripcion,
		Habilitado = @habilitado
END
GO

--------------------------------------------------------------- >> ROLES
CREATE PROCEDURE [MAIDEN].SP_altaRol(@rol varchar(20),@funcionalidades nvarchar(100))
AS
BEGIN
	Declare @ID_ROL int
	INSERT INTO [MAIDEN].Rol(Rol,Habilitado)
	values (@rol, 1)
	SET @ID_ROL = @@IDENTITY
	INSERT INTO [MAIDEN].Funcionalidad_por_Rol(Rol,Funcionalidad)
	Select @ID_ROL,ID FROM [MAIDEN].Funcionalidad where
	@funcionalidades like '%;'+ cast(ID as nvarchar(3)) + ';%'
END
GO


CREATE PROCEDURE [MAIDEN].SP_modifRol(@idRol int, @nombreRol varchar(20),@funcionalidades nvarchar(100))
AS
BEGIN
	UPDATE [MAIDEN].fx_getRol(@idRol)
	SET Rol = @nombreRol

	DELETE FROM [MAIDEN].Funcionalidad_por_Rol where Rol = @idRol 
	INSERT INTO MAIDEN.Funcionalidad_por_Rol 
	Select @idRol, ID from [MAIDEN].Funcionalidad where @funcionalidades like '%;'+ cast(ID as nvarchar(3)) + ';%'
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarRolEnUsuarios(@id int)
AS
BEGIN
	DELETE [MAIDEN].Rol_por_Usuario where Rol = @id
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
	DELETE FROM [MAIDEN].Rol

	DELETE FROM [MAIDEN].Rol
	DBCC CHECKIDENT ('[MAIDEN].Rol', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_crearFuncionalidadesDefault		-- Se crean las funcionalidades basicas, cada una tendra su id segun el orde de creacion empezando por 1
AS
BEGIN
	INSERT INTO Funcionalidad(ID, Descripcion)
	VALUES (1,'clientes'),(2,'choferes'),(4,'autos'),(5,'roles'),(6,'turnos'),(7,'viajes'),(8,'facturacion'),
	(9,'rendicion'),(10,'estadisticas')
								--1 = clientes, 2 = choferes, 3= autos....
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodasFuncionalidades		-- Se crean las funcionalidades basicas, cada una tendra su id segun el orde de creacion empezando por 1
AS
BEGIN
	DELETE FROM [MAIDEN].Funcionalidad_por_Rol

	DELETE FROM [MAIDEN].Funcionalidad
	DBCC CHECKIDENT ('[MAIDEN].Funcionalidad', RESEED, 0)
END
GO


CREATE PROCEDURE [MAIDEN].SP_crearRolesDefault
AS
BEGIN
	Exec [MAIDEN].SP_altaRol 'admin',';1;2;3;4;5;6;7;8;9;'
	Exec [MAIDEN].SP_altaRol 'cliente',';7;'
	Exec [MAIDEN].SP_altaRol 'chofer',';8;'
								 -- @clientes, @choferes, @autos, @roles, @turnos, @viajes,
								 -- @facturacion, @rendicion, @estadisticas
END
GO

--------------------------------------------------------------- USUARIOS
CREATE PROCEDURE [MAIDEN].SP_altaUsuario(@usuario varchar(30), @pass varchar(256))
AS
BEGIN
	INSERT INTO [MAIDEN].Usuario
	values(@usuario,HASHBYTES('SHA2_256',@pass),0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_modifPass(@usuario varchar(30), @pass varchar(256))
AS
BEGIN
	UPDATE [MAIDEN].Usuario
	SET Pass = HASHBYTES('SHA2_256',@pass)
	WHERE Usuario = @usuario
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarUsuario(@usuario varchar(30))
AS
BEGIN
	DELETE [MAIDEN].Rol_por_Usuario						--- Primero se le borran los roles para evitar problemas con FK
	WHERE Usuario = @usuario
	Delete [MAIDEN].Usuario							--- Despues se borra el usuario
	WHERE Usuario = @usuario
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosUsuarios
AS
BEGIN
	DELETE FROM [MAIDEN].Rol_por_Usuario
	DELETE FROM [MAIDEN].Usuario
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
	if (not exists (Select 1 from [MAIDEN].Rol_por_Usuario			-- Si no tenia asignado el rol se lo asigna. Sino no hace nada
						where usuario = @usuario and rol = @rolId))			  
	Begin
		Insert into [MAIDEN].Rol_por_Usuario
		values(@usuario,@rolId)
	End
END
GO

CREATE PROCEDURE [MAIDEN].SP_quitarRol(@usuario varchar(30), @rol varchar(20))
AS
BEGIN 
	DECLARE @RolId int
	Set @RolId = [MAIDEN].fx_getRolId(@rol)
	Delete from [MAIDEN].Rol_por_Usuario where(
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
	Declare @idTurno int;
	
	if exists(select 1 from [MAIDEN].viaje where(Chofer = @idChofer AND NOT(
	(@horaFin) < Format(Fecha,'HH:mm')
	 OR (Format(@fecha,'HH:mm') >Hora_Fin))
	AND CAST(Fecha as Date) = CAST(@fecha as Date))) throw 51000,'EL chofer ya tiene otro viaje registrado en ese horario',16;

	if exists(select 1 from [MAIDEN].viaje where(Cliente = @idCliente AND NOT(
	(@horaFin) < Format(Fecha,'HH:mm')
	 OR (Format(@fecha,'HH:mm') >Hora_Fin))
	AND CAST(Fecha as Date) = CAST(@fecha as Date))) throw 51000,'EL cliente ya tiene otro viaje registrado en ese horario',16;

	Select @idTurno = ID from [MAIDEN].Turno where (
		DATEPART(HOUR,@fecha) between Hora_Inicio and Hora_Fin-1
	)

	if (@idTurno is null) throw 51000,'No hay turno en ese horario',16;
	else BEGIN
			if (@idTurno = (select Turno from [MAIDEN].Auto where ID = @idAuto))			-- Verifica que el turno que corresponde (segun los horarios ingresados) 
			BEGIN																			-- coincida con el turno registrado en el auto
				INSERT INTO [MAIDEN].Viaje(Chofer,Auto,Turno,Km,Fecha,Cliente,Hora_Fin)
				values(@idChofer, @idAuto,@idTurno , @kms, @fecha, @idCliente,@horaFin)
			END
			else throw 51000,'El horario no coincide con el turno del auto',16;
		END
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodosViajes
AS
BEGIN
	DELETE FROM [MAIDEN].Viaje
	DBCC CHECKIDENT ('[MAIDEN].Viaje', RESEED, 0)
END
GO
-------- ***** TIENEN QUE ESTAR CHOFERES, AUTOS, TURNOS, CLIENES y RENDICIONES CARGADOS****-----------
CREATE PROCEDURE [MAIDEN].SP_cargarViajes
AS
BEGIN
INSERT INTO [MAIDEN].Viaje(Chofer,Auto,Turno,Km,Fecha,Cliente,NroRendicion, NroFactura)
SELECT DISTINCT 
	[MAIDEN].fx_getChoferId(a.Chofer_dni),
	[MAIDEN].fx_getAutoId(a.Auto_Patente),
	[MAIDEN].fx_getTurnoId(a.Turno_Hora_Inicio),
	a.Viaje_Cant_Kilometros,
	a.Viaje_Fecha,
	[MAIDEN].fx_getClienteId(a.Cliente_Dni),
	a.Rendicion_Nro,
	b.Factura_Nro
From [gd_esquema].Maestra a JOIN [gd_esquema].[Maestra] b on
(a.Cliente_Dni = b.Cliente_Dni AND a.Viaje_Fecha = b.Viaje_Fecha AND a.Chofer_Dni = b.Chofer_Dni)
WHERE (a.Rendicion_Nro is not null and b.Factura_Nro is not null)				-- Esto combina los registros que corresponden al mismo viaje pero estan separados por rendicion y factura
END
GO

--------------------------------------------------------------- RENDICION
CREATE PROCEDURE [MAIDEN].SP_actualizarRendicionEnViajes(@idChofer int, @fecha Date,@codRendicion numeric(18,0))
AS BEGIN
	UPDATE [MAIDEN].Viaje
	SET NroRendicion = @codRendicion
	WHERE(cast(Fecha as DATE) = @fecha 
		AND Chofer = @idChofer)
END
GO

CREATE PROCEDURE [MAIDEN].SP_Rendicion(@idChofer int, @fecha Date)
AS BEGIN
	Declare @cod_Rendicion int, @total numeric(18,2) 
	if not exists (Select 1 from [MAIDEN].Rendicion Where @idChofer = Chofer and @fecha = Fecha)	-- Si la rendicion todavia no se habia hecho...
	BEGIN
		INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Turno,Importe_Total)
		Select @idChofer, @fecha, t.ID, sum(t.Precio_Base+t.Precio_km*v.Km)*0.3				-- Le corresponde el 30% del precio del viaje 
		From Turno t join Viaje v on (t.ID = v.Turno)
		Where Cast(v.Fecha as Date) = @fecha
		group by t.ID

		SET @cod_Rendicion = @@IDENTITY					-- Necesito el ID para actualizarlo en los viajes
		
		Select @total = Importe_Total from [MAIDEN].Rendicion where Nro = @cod_Rendicion
		EXEC [MAIDEN].SP_actualizarRendicionEnViajes @idChofer, @fecha, @cod_Rendicion				-- Seteo la FK en viajes, para saber a que Rendicion le corresponde
	
		Select * FROM [MAIDEN].fx_getDatosRendicion(@cod_Rendicion)
		Union Select null,null,null,null,null,null,null,null, @total
		ORDER BY 9			 
	END
	ELSE throw 51000,'La rendición para ese chofer ya ha sido realizada en el día',16;
END
GO

CREATE PROCEDURE [MAIDEN].SP_cargarRendiciones
AS
BEGIN
	SET IDENTITY_INSERT [MAIDEN].Rendicion ON				-- La tabla usa Identity, pero la tabla ya tiene ciertos valores. De esta forma permitirá setearle, sin problemas con los identity
	INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Nro, Importe_Total, Turno)
	SELECT [MAIDEN].fx_getChoferId(Chofer_Dni),
		   CAST(Rendicion_Fecha as Date),
		   Rendicion_Nro,
		   sum(Rendicion_Importe),
		   [MAIDEN].fx_getTurnoId(Turno_Hora_Inicio)  
	From [gd_esquema].Maestra
	Where Rendicion_Nro is not null
	Group by Chofer_Dni, CAST(Rendicion_Fecha as Date), Rendicion_Nro, Turno_Hora_Inicio
	SET IDENTITY_INSERT [MAIDEN].Rendicion OFF
END
GO


CREATE PROCEDURE [MAIDEN].SP_eliminarTodasRendiciones
AS
BEGIN
	UPDATE [MAIDEN].Viaje SET NroRendicion = null 
	DELETE FROM [MAIDEN].Rendicion
	DELETE FROM [MAIDEN].Rendicion
	DBCC CHECKIDENT ('[MAIDEN].Rendicion', RESEED, 0)

END
GO

--------------------------------------------FACTURAS
CREATE PROCEDURE [MAIDEN].SP_actualizarFacturaEnViajes(@idCliente int, @fechaInicio datetime, @fechaFin datetime, @codFactura numeric(18,0))
AS BEGIN 
	UPDATE [MAIDEN].Viaje
	SET NroFactura = @codFactura
	WHERE (Fecha BETWEEN @fechaInicio AND @fechaFin
			AND Cliente = @idCliente)
END
GO

CREATE PROCEDURE [MAIDEN].SP_Facturacion(@idCliente int, @fechaInicio datetime, @fechaFin datetime)
AS BEGIN 
	DECLARE @cod_Factura int, @total numeric(18,2)
	IF NOT EXISTS (Select 1 FROM [MAIDEN].Factura WHERE Cliente = @idCliente AND Fecha BETWEEN @fechaInicio AND @fechaFin)
		BEGIN
			INSERT INTO [MAIDEN].Factura(Cliente,Fecha,Fecha_Inicio,Fecha_Fin,Importe_total)
			SELECT @idCliente, GETDATE(), @fechaInicio, @fechaFin, sum(t.Precio_Base+t.Precio_km*v.Km)
			FROM [MAIDEN].Viaje v join [MAIDEN].Turno t on v.Turno = t.ID
			WHERE v.Cliente = @idCliente AND v.Fecha BETWEEN @fechaInicio AND @fechaFin
			
			SET @cod_Factura = @@IDENTITY

			SELECT @total = Importe_Total from [MAIDEN].Factura

			EXEC [MAIDEN].SP_actualizarFacturaEnViajes @idCliente, @fechaInicio, @fechaFin, @cod_Factura
			
			Select * FROM [MAIDEN].fx_getDatosFactura(@cod_Factura)
			Union Select null,null,null,null,null,null,null,@total
			ORDER BY 8	
		END
	ELSE throw 51000,'Ya fue realizada la factura al cliente para las fechas ingresadas.',16;
END
GO

CREATE PROCEDURE [MAIDEN].SP_cargarFacturas
AS BEGIN
	SET IDENTITY_INSERT [MAIDEN].Factura ON				-- La tabla usa Identity, pero la tabla ya tiene ciertos valores. De esta forma permitirá setearle, sin problemas con los identity
	INSERT INTO [MAIDEN].Factura(Nro,Cliente,Fecha,Fecha_Inicio,Fecha_Fin,Importe_Total)
	SELECT DISTINCT
		   Factura_Nro,
		   [MAIDEN].fx_getClienteId(Cliente_Dni),
		   Factura_Fecha,
		   Factura_Fecha_Inicio,
		   Factura_Fecha_Fin,
		   sum(Turno_Precio_Base+Turno_Valor_Kilometro*Viaje_Cant_Kilometros)
	From [gd_esquema].Maestra
	Where Factura_Nro IS NOT NULL
	Group by Cliente_Dni,Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin,Factura_Fecha
	SET IDENTITY_INSERT [MAIDEN].Rendicion OFF
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodasFacturas
AS
BEGIN
	UPDATE [MAIDEN].Viaje SET NroFactura = null 
	DELETE FROM [MAIDEN].Factura
	DELETE FROM [MAIDEN].Factura
	DBCC CHECKIDENT ('[MAIDEN].Factura', RESEED, 0)

END
GO
