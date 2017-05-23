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
CREATE PROCEDURE [MAIDEN].SP_altaRol(@rol varchar(20),@funcionalidades nvarchar(100))
AS
BEGIN
	Declare @ID_ROL int
	INSERT INTO [MAIDEN].Roles(Rol,Habilitado)
	values (@rol, 1)
	SET @ID_ROL = @@IDENTITY
	INSERT INTO [MAIDEN].FuncionalidadXRol(Rol,Funcionalidad)
	Select @ID_ROL,ID FROM [MAIDEN].Funcionalidad where
	@funcionalidades like '%;'+ cast(ID as nvarchar(3)) + ';%'
END
GO


CREATE PROCEDURE [MAIDEN].SP_modifRol(@idRol int, @nombreRol varchar(20),@funcionalidades nvarchar(100))
AS
BEGIN
	UPDATE [MAIDEN].fx_getRol(@idRol)
	SET Rol = @nombreRol

	DELETE FROM [MAIDEN].FuncionalidadXRol where Rol = @idRol 
	INSERT INTO MAIDEN.FuncionalidadXRol 
	Select @idRol, ID from [MAIDEN].Funcionalidad where @funcionalidades like '%;'+ cast(ID as nvarchar(3)) + ';%'
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

	DELETE FROM [MAIDEN].Roles
	DBCC CHECKIDENT ('[MAIDEN].Roles', RESEED, 0)
END
GO

CREATE PROCEDURE [MAIDEN].SP_crearFuncionalidadesDefault		-- Se crean las funcionalidades basicas, cada una tendra su id segun el orde de creacion empezando por 1
AS
BEGIN
	INSERT INTO Funcionalidad(Descripcion)
	VALUES ('clientes'),('choferes'),('autos'),('roles'),('turnos'),('viajes'),('facturacion'),
	('rendicion'),('estadisticas')
								--1 = clientes, 2 = choferes, 3= autos....
END
GO

CREATE PROCEDURE [MAIDEN].SP_eliminarTodasFuncionalidades		-- Se crean las funcionalidades basicas, cada una tendra su id segun el orde de creacion empezando por 1
AS
BEGIN
	DELETE FROM [MAIDEN].FuncionalidadXRol

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
	Declare @idTurno int;
	
	if exists(select 1 from [MAIDEN].viajes where(Chofer = @idChofer AND 
	Format(@fecha, 'HH:mm') BETWEEN Format(Fecha,'HH:mm') AND Hora_Fin)) throw 52000,'EL chofer ya tiene otro viaje registrado en ese horario',16

	Select @idTurno = ID from [MAIDEN].Turnos where (
		DATEPART(HOUR,@fecha) between Hora_Inicio and Hora_Fin-1
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
-------- ***** TIENEN QUE ESTAR CHOFERES, AUTOS, TURNOS, CLIENES y RENDICIONES CARGADOS****-----------
CREATE PROCEDURE [MAIDEN].SP_cargarViajes
AS
BEGIN
	Insert into [MAIDEN].Viajes(Chofer,Auto,Turno,Km,Fecha,Cliente,NroRendicion)
	Select distinct 
		[MAIDEN].fx_getChoferId(Chofer_dni),
		[MAIDEN].fx_getAutoId(Auto_Patente),
		[MAIDEN].fx_getTurnoId(Turno_Hora_Inicio),
		Viaje_Cant_Kilometros,
		Viaje_Fecha,
		[MAIDEN].fx_getClienteId(Cliente_Dni),
		Rendicion_Nro
	From [gd_esquema].Maestra
END
GO


--------------------------------------------------------------- RENDICION
--****************** FALTA SUMARLE EL TEMA DEL IMPORTE DE LAS RENDICIONES QUE NO ENTIENDO COMO ES	**************************************
CREATE PROCEDURE [MAIDEN].SP_actualizarRendicionEnViajes(@idChofer int, @fecha Date,@codRendicion numeric(18,0))
AS BEGIN
	UPDATE [MAIDEN].Viajes
	SET NroRendicion = @codRendicion
	WHERE(
		cast(Fecha as DATE) = @fecha 
		AND Chofer = @idChofer
	)
END
GO

CREATE PROCEDURE [MAIDEN].SP_rendicion(@idChofer int, @fecha Date)
AS BEGIN
	Declare @cod_Rendicion int, @total numeric(18,2) 
	if not exists (Select 1 from [MAIDEN].Rendicion Where @idChofer = Chofer and @fecha = Fecha)	-- Si la rendicion todavia no se habia hecho...
	BEGIN
		INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Turno,Importe_Total)
		Select @idChofer, @fecha, t.ID, sum(t.Precio_Base+t.Precio_km*v.Km) 
		From Turnos t, Viajes v
		Where v.Chofer = @idChofer AND v.Turno = t.ID AND Cast(v.Fecha as Date) = @fecha
		group by t.ID

		SET @cod_Rendicion = @@IDENTITY					-- Necesito el ID para actualizarlo en los viajes
		
		Select @total = Importe_Total from [MAIDEN].Rendicion where Nro = @cod_Rendicion
		EXEC [MAIDEN].SP_actualizarRendicionEnViajes @idChofer, @fecha, @cod_Rendicion				-- Seteo la FK en viajes, para saber a que Rendicion le corresponde
	
		Select [MAIDEN].fx_getDatosRendicion(@cod_Rendicion)
		Union Select null,null,null,null,null,null,null, @total
		ORDER BY 8				 
	END
	ELSE throw 51000,'La rendición para ese chofer ya ha sido realizada en el día',16;
END
GO

CREATE PROCEDURE [MAIDEN].SP_cargarRendiciones
AS
BEGIN
	SET IDENTITY_INSERT [MAIDEN].Rendicion ON				-- La tabla usa Identity, pero la tabla ya tiene ciertos valores. De esta forma permitirá setearle, sin problemas con los identity
	INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Nro, Importe_Total, Turno)
	SELECT [MAIDEN].fx_getChoferId(Chofer_Dni), CAST(Rendicion_Fecha as Date),Rendicion_Nro,sum(Rendicion_Importe), [MAIDEN].fx_getTurnoId(Turno_Hora_Inicio)  
	From [gd_esquema].Maestra
	Where Rendicion_Nro is not null
	Group by Chofer_Dni, CAST(Rendicion_Fecha as Date), Rendicion_Nro, Turno_Hora_Inicio
	SET IDENTITY_INSERT [MAIDEN].Rendicion OFF
END
GO




CREATE PROCEDURE [MAIDEN].SP_eliminarTodasRendiciones
AS
Begin

	UPDATE [MAIDEN].Viajes SET NroRendicion = null 

	DELETE FROM [MAIDEN].Rendicion
	
	DELETE FROM [MAIDEN].Rendicion
	DBCC CHECKIDENT ('[MAIDEN].Rendicion', RESEED, 0)


End


