USE [GD1C2017]
GO

CREATE SCHEMA [MAIDEN]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
-----------------------------------------------------------------------------------------*
-----------------------------------------TABLAS------------------------------------------*
-----------------------------------------------------------------------------------------*

CREATE TABLE [MAIDEN].[Cliente](
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[Telefono] [numeric](18, 0) NOT NULL UNIQUE,
	[Direccion] [varchar](255) NOT NULL,
	[Piso] INT,
	[Depto] [char](1),
	[Localidad] [varchar](255),
	[Mail] [varchar](255),
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Habilitado] [bit] NOT NULL DEFAULT 1,
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Cliente] PRIMARY KEY)
GO

CREATE TABLE [MAIDEN].[Chofer](
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Dni] [numeric](18, 0) NOT NULL UNIQUE,
	[Telefono] [numeric](18, 0) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Piso] INT,
	[Depto] [char](1),
	[Localidad] [varchar](255),
	[Mail] [varchar](50) NOT NULL,
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Habilitado] [bit] DEFAULT 1,
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Chofer] PRIMARY KEY
	)
GO

CREATE TABLE [MAIDEN].[Turno](
	[Hora_Inicio] [numeric](18, 0) NOT NULL,
	[Hora_Fin] [numeric](18, 0) NOT NULL,
	[Precio_Base] [numeric](18, 2) NOT NULL,
	[Precio_km] [numeric](18, 2) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Habilitado] [bit] DEFAULT 1,
	[Respaldo] [bit] DEFAULT 0,
	[ID] [int] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Turno] PRIMARY KEY)
GO

CREATE TABLE [MAIDEN].[Auto](
	[Marca] [varchar](255) NOT NULL,
	[Modelo] [varchar](255) NOT NULL,
	[Patente] [varchar](10) NOT NULL CONSTRAINT [Patente_Unica] UNIQUE,
	[Licencia] [varchar](26),
	[Rodado] [varchar](10),
	[Habilitado] [bit] DEFAULT 1,									--Al registrarlos estan habilitados
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_AUTO] PRIMARY KEY,
	[Chofer] [int] CONSTRAINT [FK_Auto_Chofer] REFERENCES [MAIDEN].[Chofer] UNIQUE,
	[Turno] [int] CONSTRAINT [FK_Auto_Turno] REFERENCES [MAIDEN].[Turno])
GO

CREATE TABLE [MAIDEN].[Rol](
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Rol] PRIMARY KEY,
	[Rol] [varchar](20) NOT NULL,
	[Habilitado] [bit] DEFAULT 1)
GO

CREATE TABLE [MAIDEN].[Funcionalidad](
	[ID] [int] CONSTRAINT [PK_Funcionalidad] PRIMARY KEY,
	[Descripcion] [nvarchar](100))
GO

CREATE TABLE [MAIDEN].[Funcionalidad_por_Rol](
	[Rol] [int] REFERENCES [MAIDEN].Rol,
	[Funcionalidad] [int] REFERENCES [MAIDEN].[Funcionalidad],
 CONSTRAINT [PK_Funcionalidad_por_Rol] PRIMARY KEY (Rol, Funcionalidad))
GO

CREATE TABLE [MAIDEN].[Usuario](
	[Usuario] [varchar](30) NOT NULL CONSTRAINT [PK_Usuario] PRIMARY KEY,
	[Pass] [varchar](256) NOT NULL,
	[IntentosLogueo] [int] NOT NULL)
GO

CREATE TABLE [MAIDEN].[Rol_por_Usuario](
	[Usuario] [varchar](30) NOT NULL,
	[Rol] [int] NOT NULL,
 CONSTRAINT [PK_Rol_por_Usuario] PRIMARY KEY (Usuario,Rol),
)
GO

CREATE TABLE [MAIDEN].[Rendicion](
	[Nro] [numeric](18, 0) IDENTITY(1,1) CONSTRAINT [PK_Rendicion] PRIMARY KEY,
	[Chofer] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Turno] [int] CONSTRAINT [FK_Rendicion_Turno] REFERENCES [MAIDEN].[Turno],
	[Importe_Total] [numeric](18, 2) DEFAULT 0)													
GO

CREATE TABLE [MAIDEN].[Factura](
	[Nro] [numeric](18, 0) IDENTITY(1,1) CONSTRAINT [PK_Factura] PRIMARY KEY,
	[Cliente] [int] NOT NULL CONSTRAINT [FK_Factura_Cliente] REFERENCES [MAIDEN].[Cliente],
	[Fecha] [datetime] NOT NULL,
	[Fecha_inicio] [datetime] NOT NULL,
	[Fecha_fin] [datetime] NOT NULL,
	[Importe_Total][numeric](18, 2) DEFAULT 0)
GO


CREATE TABLE [MAIDEN].[Viaje](
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Viajes] PRIMARY KEY,
	[Chofer] [int] NOT NULL CONSTRAINT [FK_Viaje_Chofer] REFERENCES [MAIDEN].[Chofer],
	[Auto] [int] NOT NULL CONSTRAINT [FK_Viaje_Auto] REFERENCES [MAIDEN].[Auto],
	[Turno] [int] NOT NULL CONSTRAINT [FK_Viaje_Turno] REFERENCES [MAIDEN].[Turno],
	[Km] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cliente] [int] NOT NULL CONSTRAINT [FK_Viaje_Cliente] REFERENCES [MAIDEN].[Cliente],
	[Hora_Fin] [time](7),											
	[NroRendicion] [numeric](18, 0) CONSTRAINT [FK_Viaje_Rendicion] REFERENCES [MAIDEN].[Rendicion],
	[NroFactura] [numeric](18, 0) CONSTRAINT [FK_Viaje_Factura] REFERENCES [MAIDEN].[Factura])
GO

-----------------------------------------------------------------------------------------*
-----------------------------------------FUNCIONES---------------------------------------*
-----------------------------------------------------------------------------------------*
-- =============================================
--					**  AUTOS  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarAutos (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
RETURNS TABLE
AS RETURN
		(Select a.ID, a.Marca, a.Modelo,a.Patente,a.Licencia,a.Rodado,a.Habilitado,
		(c.Nombre+' '+c.Apellido) as Chofer, c.ID as IDChofer, t.ID as IDTurno,
		t.Descripcion as Turno 
		From [MAIDEN].Auto a 
		left join [MAIDEN].Chofer c on (a.Chofer = c.ID)
		left join [MAIDEN].Turno t on (a.Turno = t.ID)
		where 
			Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarAutosHabilitados (@modelo varchar(255),			
								 @patente varchar(10),
								 @marca varchar(255),
								 @choferID int)
RETURNS TABLE
AS RETURN
		(Select a.ID as ID, a.Marca, a.Modelo,a.Patente,a.Licencia,a.Rodado, a.Habilitado,
		(c.Nombre+' '+c.Apellido) as Chofer, c.ID as IDChofer, t.ID as IDTurno,
		t.Descripcion as Turno 
		From [MAIDEN].Auto a 
		left join [MAIDEN].Chofer c on (a.Chofer = c.ID)
		left join [MAIDEN].Turno t on (a.Turno = t.ID)
		where 
			(Modelo like '%'+@modelo+'%'
			OR
			Patente = @patente
			OR
			Marca = @marca
			OR
			Chofer = @choferID) AND a.Habilitado = 1)
GO

CREATE FUNCTION [MAIDEN].fx_getMarcas()
RETURNS TABLE
AS RETURN 
		(SELECT DISTINCT Marca FROM [MAIDEN].Auto)
GO

-- =============================================
--					**  CHOFERES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarChoferes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN(
		Select chofer.ID as ID, chofer.Nombre, chofer.Apellido, chofer.Dni, chofer.Mail,chofer.Telefono,
			chofer.Direccion,chofer.Localidad, chofer.Piso, chofer.Depto,
			chofer.Fecha_Nacimiento, chofer.habilitado From [MAIDEN].Chofer chofer
		WHERE Nombre like '%'+ @nombre+ '%'
			  OR
			  Apellido like '%'+@apellido+'%'
			  OR
			  DNI = @DNI)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarChoferesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN
		(	Select chofer.ID as ID, chofer.Nombre, chofer.Apellido, chofer.Dni, chofer.Mail,chofer.Telefono,
			chofer.Direccion,chofer.Localidad, chofer.Piso, chofer.Depto,
			chofer.Fecha_Nacimiento,chofer.Habilitado From [MAIDEN].Chofer chofer
		WHERE ((Nombre like '%'+ @nombre+ '%'
			  OR
			  Apellido like '%'+@apellido+'%'
			  OR
			  DNI = @DNI) AND Habilitado=1)
			  )
GO

-- =============================================
--					**  CLIENTES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarClientes (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN
		(Select cliente.ID as ID, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Mail, cliente.Telefono,
		cliente.Direccion,cliente.Localidad, cliente.Piso, cliente.Depto,
		cliente.Fecha_Nacimiento, cliente.Habilitado From [MAIDEN].Cliente cliente
		WHERE Nombre like '%'+ @nombre+ '%'
				OR
			  Apellido like '%'+@apellido+'%'
				OR
			  DNI = @DNI)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarClientesHabilitados (@nombre varchar(255),			
								 @apellido varchar(255),
								 @DNI numeric(18,0))
RETURNS TABLE
AS RETURN
		(Select cliente.ID as ID, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Mail, cliente.Telefono,
		cliente.Direccion,cliente.Localidad, cliente.Piso, cliente.Depto,
		cliente.Fecha_Nacimiento, cliente.Habilitado From [MAIDEN].Cliente cliente
		WHERE (Nombre like '%'+ @nombre+ '%'
				OR
			  Apellido like '%'+@apellido+'%'
				OR
			  DNI = @DNI) AND Habilitado = 1)
GO

-- =============================================
--					**  TURNOS  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_filtrarTurnos (@descripcion varchar(255))		
RETURNS TABLE
AS RETURN
		(Select t.ID,t.Descripcion,t.Hora_Inicio,t.Hora_Fin,t.Precio_Base,t.Precio_km, t.Habilitado From [MAIDEN].Turno t where 
			Descripcion like '%'+ @descripcion+ '%' AND Respaldo = 0)
GO

CREATE FUNCTION [MAIDEN].fx_filtrarTurnosHabilitados (@descripcion varchar(255))		
RETURNS TABLE
AS RETURN
		(Select t.ID,t.Descripcion,t.Hora_Inicio,t.Hora_Fin,t.Precio_Base,t.Precio_km,t.Habilitado From [MAIDEN].Turno t where 
			Descripcion like '%'+ @descripcion+ '%' AND Respaldo = 0 
			AND Habilitado = 1)
GO
-- =============================================
--					**  ROLES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getRolId(@rol varchar(20))
RETURNS INT 
AS
BEGIN
	RETURN (SELECT ID From [MAIDEN].Rol WHERE Rol = @rol)
END;
GO

-- =============================================
--					**  FUNCIONALIDADES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getFuncionalidades(@idRol int)		-- Devuelve las funcionalidades del rol
RETURNS TABLE
AS
RETURN SELECT Funcionalidad from [MAIDEN].Funcionalidad_por_Rol where Rol = @idRol
GO
-- =============================================
--					**  USUARIOS  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getUsuarios()			-- Devuelve todos los usuarios registrados
RETURNS TABLE
AS
RETURN (Select Usuario From [MAIDEN].Usuario)
GO

CREATE FUNCTION [MAIDEN].fx_getRolesDeUsuario(@usuario varchar(30))		-- Devuelve los nombres de los roles del usuario
RETURNS TABLE
AS
RETURN (Select Rol From [MAIDEN].Rol 
		Where ID IN (Select Rol FROM [MAIDEN].Rol_por_Usuario Where Usuario = @usuario))
GO

-- =============================================
--					**  ROLES  **
-- =============================================
CREATE FUNCTION [MAIDEN].fx_getRoles()			-- Devuelve los roles existentes
RETURNS TABLE
AS
	RETURN (Select Rol,Habilitado FROM [MAIDEN].Rol)
GO

CREATE FUNCTION [MAIDEN].fx_getRolesHabilitados()			
RETURNS TABLE
AS
	RETURN (Select * FROM [MAIDEN].fx_getRoles() where Habilitado = 1)
GO
-- =============================================
--					**  VIAJES  **
-- =============================================
-- Devuelve los datos del Auto para autocompletar el viaje una vez seleccionado el chofer
CREATE FUNCTION [MAIDEN].fx_getAutoDelChofer(@idChofer int)
RETURNS TABLE 
AS RETURN(
			Select a.*,t.Hora_Inicio,t.Hora_Fin from [MAIDEN].Auto a 
							LEFT JOIN [MAIDEN].Turno t on (a.Turno =t.ID)
			where Chofer = @idChofer 
			AND a.Habilitado = 1)
GO

-- =============================================
--					**  RENDICION  **
-- =============================================
-- Devuelve los datos de la rendicion que ESTÁ SIENDO REGISTRADA (Se usa en SP_Rendicion)
-- La diferencia con la funcion siguiente es que aún no tenemos el total de la rendición
CREATE FUNCTION [MAIDEN].fx_getDatosRendicion(@nroRendicion numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select c.nombre+' '+c.apellido as Cliente, 
		FORMAT(viaje.Fecha,'HH:mm') as 'Hora Inicio',
		FORMAT(viaje.Hora_Fin,'HH:mm') as 'Hora Fin',
		viaje.Km as 'Distancia(Kms)', 
		turno.Precio_Base as 'Precio Base',
		turno.Precio_km as 'Precio Km',
		(turno.Precio_Base+turno.Precio_km*viaje.Km) as 'Precio del Viaje',
		(turno.Precio_Base+turno.Precio_km*viaje.Km)*0.3 as 'Importe(30%)', 
		null as 'Total del Dia'
		FROM [MAIDEN].Cliente c join [MAIDEN].Viaje viaje on (c.ID = viaje.Cliente) join [MAIDEN].Turno turno on (turno.ID = viaje.Turno)
		Where viaje.NroRendicion = @nroRendicion)
GO

-- Devuelve los datos de la rendicion que YA había sido registrada. (Por eso podemos obtener el total directamente)
CREATE FUNCTION [MAIDEN].fx_getRendicionExistente(@nroRendicion numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select * FROM [MAIDEN].fx_getDatosRendicion(@nroRendicion)
	UNION
	SELECT null,null,null,null,null,null,null,null,Importe_Total from [Maiden].Rendicion
	WHERE Nro=@nroRendicion
)
GO

-- =============================================
--					**  FACTURA  **
-- =============================================
-- Devuelve los datos de la factura que ESTÁ SIENDO REGISTRADA (Se usa en SP_Facturacion)
-- La diferencia con la funcion siguiente es que aún no tenemos el total de la factura
CREATE FUNCTION [MAIDEN].fx_getDatosFactura(@nroFactura numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select CAST(viaje.Fecha as Date)as 'Fecha',
		   FORMAT (viaje.Fecha,'HH:mm') as 'Hora Inicio',
		   FORMAT(viaje.Hora_Fin,'HH:mm') as 'Hora Fin',
		   viaje.Km as 'Distancia(Kms)',
		   turno.Precio_Base as 'Precio Base',
		   turno.Precio_km as 'Precio Km', 
		   (turno.Precio_Base+turno.Precio_km*viaje.Km) as 'Precio del Viaje',
		   null as 'Total de Factura'
		FROM [MAIDEN].Viaje viaje join [MAIDEN].Turno turno on (viaje.Turno = turno.ID) 
						 join [MAIDEN].Chofer chofer on (chofer.ID = viaje.Chofer)
		Where Viaje.NroFactura = @nroFactura
		)
GO

-- Devuelve los datos de la factura que YA había sido registrada. (Por eso podemos obtener el total directamente)
CREATE FUNCTION [MAIDEN].fx_getFacturaExistente(@nroFactura numeric(18,0))
RETURNS TABLE
AS
RETURN(
	Select * FROM [MAIDEN].fx_getDatosFactura(@nroFactura)
	UNION
	SELECT null,null,null,null,null,null,null,Importe_Total from [Maiden].Factura
	WHERE Nro=@nroFactura
)
GO

-- =============================================
--					**  ESTADISTICAS  **
-- =============================================
-- 1) Se agrupan las rendiciones por chofer
-- 2) Se suman los importes de cada una de la rendicion (Total)
-- 3) Se ordenan de forma descendente según el Total (es decir, quedaran primeros los de mayor recaudación)
-- 4) Se muestran los datos de los 5 primeros. (es decir, los 5 de mayor recaudación)
CREATE FUNCTION [MAIDEN].fx_choferesMayorRecaudacion(@anio int, @trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (
			c.Nombre+' '+c.Apellido) as Chofer,
			sum(Importe_Total) as 'Total($)'	
			from [MAIDEN].Rendicion r join [MAIDEN].Chofer c on (r.Chofer = c.ID)
			where year(r.fecha)=@anio AND DATEPART(qq,r.Fecha)=@trimestre 
			Group by r.Chofer, c.Nombre, c.Apellido, c.Direccion, c.Telefono, c.Mail
			order by sum(Importe_Total) desc
)
GO

-- 1) Para cada chofer se selecciona su viaje mas largo (mayor cantidad de kilometros)
-- 2) Se ordenan de forma descendente
-- 2) Se seleccionan los 5 primeros 

CREATE FUNCTION [MAIDEN].fx_choferesViajesMasLargos(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (chofer.Nombre+' '+chofer.Apellido)as Chofer, max(km) as Distancia
		FROM [MAIDEN].Viaje viaje JOIN [MAIDEN].Chofer chofer on  viaje.Chofer = chofer.ID
		GROUP BY chofer.Nombre, chofer.Apellido
		ORDER BY Distancia DESC
)
GO
-- 1) Se agrupan las facturas por cliente
-- 2) Para cada cliente se suman los importes de cada una de estas facturas
-- 3) Se ordenan de mayor a menor según el total de cada cliente (quedarán primeros los de mayor consumo)
-- 4) Se seleccionan los 5 primeros clientes (es decir, los de mayor recaudación)
CREATE FUNCTION [MAIDEN].fx_clientesMayorConsumo(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (c.Nombre+' '+c.Apellido) as Cliente,sum(Importe_Total) as Consumo 
		from [MAIDEN].Factura f join [MAIDEN].Cliente c on (f.Cliente = c.ID)
		WHERE year(f.Fecha) = @anio AND DATEPART(qq,f.Fecha) = @trimestre
		GROUP BY f.Cliente, c.nombre, c.Apellido
		ORDER BY Consumo Desc
)
GO

-- 1) Los viajes se ordenan, para cada cliente, en forma descendente segun la cantidad de veces que utilizó el mismo auto
--				(la numeracion de las filas se reinicia para cada cliente)
-- 2)  Se selecciona de los 5 primeros clientes el vehículo con el que mayor viajes realizó (fila = 1).
CREATE FUNCTION [MAIDEN].fx_clientesMismoAuto(@anio int,@trimestre int)
RETURNS TABLE
AS
RETURN(
		SELECT TOP 5 (cliente.nombre+' '+cliente.Apellido)as Cliente,auto.Marca, auto.Patente,Viajes
				FROM ( SELECT v.cliente, v.Auto,
						 ROW_NUMBER() OVER (PARTITION BY v.Cliente ORDER BY count(*) DESC) AS fila,
						 count(*) as Viajes
				   FROM MAIDEN.Viaje v
				   WHERE YEAR(FECHA)=@anio AND DATEPART(qq,Fecha) = @trimestre
				   GROUP BY v.Cliente,v.Auto)Resultados JOIN [MAIDEN].Cliente cliente ON (Resultados.Cliente = cliente.ID)
														JOIN [MAIDEN].Auto auto on (Resultados.Auto = auto.ID)
				   WHERE Resultados.fila = 1
				   ORDER BY Viajes DESC
)
GO

-----------------------------------------------------------------------------------------*
--------------------------------------PROCEDIMIENTOS-------------------------------------*
-----------------------------------------------------------------------------------------*


-- =============================================
--					** CLIENTES **
-- =============================================

-- >>	INSERTA en nuestra tabla CLIENTE, cada diferente cliente encontrado en la tabla maestra.
-- (Cada combinación de valores encontrada en estos campos indicaría que se trata de un cliente distinto)
CREATE PROCEDURE [MAIDEN].SP_migrarClientes 
AS BEGIN
	INSERT INTO [MAIDEN].Cliente(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		Cliente_Nombre,
		Cliente_Apellido,
		Cliente_DNI,
		Cliente_Telefono,
		Cliente_Direccion,
		Cliente_Mail,
		Cliente_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

-- >>	Recibe los parámetros necesarios para dar de ALTA un nuevo CLIENTE y lo inserta en la tabla CLIENTE
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
AS BEGIN
	INSERT INTO [MAIDEN].Cliente(Nombre,Apellido,DNI,Telefono,Direccion,piso,depto,localidad,mail,Fecha_Nacimiento)
	values(@nombre, @apellido, @dni,@telefono, @direccion,@piso,@depto,@localidad, @mail, @fecha_nacimiento)
END
GO

-- >>	Recibe el id del CLIENTE a MODIFICAR, y los nuevos valores de sus columnas.
-- Luego los actualiza.
CREATE PROCEDURE [MAIDEN].SP_modifCliente(
		@id int,
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime,
		@piso int, @depto char(1), @localidad varchar(255))
AS BEGIN
   UPDATE [MAIDEN].Cliente
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento,
	   Piso = @piso,
	   Depto = @depto,
	   Localidad = @localidad
	   WHERE ID=@id
END
GO

-- >>	Recibe el ID del CLIENTE a deshabilitar, y setea su valor "habilitado" a 0 (falso => No habilitado).
CREATE PROCEDURE [MAIDEN].SP_deshabilitarCliente(@id int)
AS BEGIN
	UPDATE [MAIDEN].Cliente
	SET Habilitado=0
	WHERE ID=@id
END
GO

-- >>	Recibe el ID del CLIENTE a habilitar, y setea su valor "habilitado" a 1 (verdadero => Habilitado).
CREATE PROCEDURE [MAIDEN].SP_habilitarCliente(@id int)
AS BEGIN
	UPDATE [MAIDEN].Cliente
	SET Habilitado=1
	WHERE ID=@id
END
GO
--//
CREATE PROCEDURE [MAIDEN].SP_eliminarTodosClientes 
AS BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [MAIDEN].Cliente
	
	DELETE FROM [MAIDEN].Cliente
	DBCC CHECKIDENT ('[MAIDEN].Cliente', RESEED, 0)
END
GO

-- =============================================
--					** CHOFERES **
-- =============================================
-- >>	INSERTA en nuestra tabla CHOFER, cada diferente chofer encontrado en la tabla maestra.
-- (Cada combinación de valores encontrada en estos campos indicaría que se trata de un chofer distinto)
CREATE PROCEDURE [MAIDEN].SP_migrarChoferes 
AS BEGIN
	INSERT INTO [MAIDEN].Chofer(Nombre,Apellido,DNI,Telefono,Direccion,Mail,Fecha_Nacimiento)
	SELECT Distinct
		Chofer_Nombre,
		Chofer_Apellido,
		Chofer_DNI,
		Chofer_Telefono,
		Chofer_Direccion,
		Chofer_Mail,
		Chofer_Fecha_Nac		
	FROM [gd_esquema].Maestra
END
GO

-- >>	Recibe los parámetros necesarios para dar de ALTA un nuevo CHOFER y lo inserta en la tabla CHOFER
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

-- >>	Recibe el id del CHOFER a MODIFICAR y actualiza sus columnas con los datos recibidos
CREATE PROCEDURE [MAIDEN].SP_modifChofer(
		@id int,
		@nombre varchar(255),
		@apellido varchar(255),
		@dni numeric(18,0),
		@telefono numeric(18,0),
		@direccion varchar(255),
		@mail varchar(255),
		@fecha_nacimiento datetime,
		@piso int, @depto char(1), @localidad varchar(255))
AS BEGIN
	UPDATE [MAIDEN].Chofer
   SET Nombre = @nombre,
       Apellido = @apellido,
	   DNI = @dni,
	   Telefono = @telefono,
	   Direccion = @direccion,
	   Mail = @mail,
	   Fecha_Nacimiento = @fecha_nacimiento,
	   Piso = @piso,
	   Depto = @depto,
	   Localidad = @localidad
	WHERE ID = @id
END
GO

--	>>	Recibe el ID del CHOFER a DESHABILITAR, y setea su valor "habilitado" a 0 (falso).
CREATE PROCEDURE [MAIDEN].SP_deshabilitarChofer(@id int)
AS BEGIN
	UPDATE [MAIDEN].Chofer
	SET Habilitado=0
	WHERE ID=@id
END
GO

--	>>	Recibe el ID del CHOFER a HABILITAR, y setea su valor "habilitado" a 1 (verdadero).
CREATE PROCEDURE [MAIDEN].SP_habilitarChofer(@id int)
AS BEGIN
	UPDATE [MAIDEN].Chofer
	SET Habilitado=1
	WHERE ID=@id
END
GO

-- =============================================
--					** AUTOS **
-- =============================================
-- >>	INSERTA en nuestra tabla AUTO, cada diferente auto encontrado en la tabla maestra.
-- (Cada combinación de valores encontrada en estos campos indicaría que se trata de un auto distinto)
CREATE PROCEDURE [MAIDEN].SP_migrarAutos
AS
BEGIN
	INSERT INTO [MAIDEN].Auto(Marca, Modelo, Patente, Licencia, Rodado, Chofer)
	SELECT DISTINCT 
		Auto_Marca,
		Auto_Modelo,
		Auto_Patente,
		Auto_Licencia,
		Auto_Rodado,
		chofer.ID
	FROM [gd_esquema].Maestra maestra join [MAIDEN].Chofer chofer on (maestra.Chofer_Dni = chofer.Dni)
END
GO

-- >>	Recibe los parámetros necesarios para dar de ALTA un nuevo auto y lo inserta en la tabla AUTO
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

-- >>	Recibe el id del AUTO a MODIFICAR y actualiza sus columnas con los datos recibidos
CREATE PROCEDURE [MAIDEN].SP_modifAuto(
				@id int,
				@marca varchar(255),
				@modelo varchar(255),
				@patente varchar(10),
				@chofer int,
				@turno int)
AS
BEGIN
	UPDATE [MAIDEN].AUTO
	SET Marca = @marca,
		Modelo = @modelo,
		Patente = @patente,
		Chofer = @chofer,
		Turno = @turno
		WHERE ID=@id
END
GO

-- >>	Recibe el ID del AUTO a DESHABILITAR, y setea su valor "habilitado" a 0 (deshabilitado).
CREATE PROCEDURE [MAIDEN].SP_deshabilitarAuto(@id int)
AS BEGIN
	UPDATE [MAIDEN].Auto
	SET Habilitado=0
	WHERE ID = @id
END
GO
-- >>	Recibe el ID del AUTO a HABILITAR, y setea su valor "habilitado" a 1 (habilitado).
CREATE PROCEDURE [MAIDEN].SP_habilitarAuto(@id int)
AS BEGIN
	UPDATE [MAIDEN].Auto
	SET Habilitado=1
	WHERE ID=@id
END
GO

-- =============================================
--					** TURNOS **
-- =============================================
-- >>	INSERTA en nuestra tabla TURNO, cada diferente turno encontrado en la tabla maestra.
-- (Cada combinación de valores encontrada en estos campos indicaría que se trata de un turno distinto)
CREATE PROCEDURE [MAIDEN].SP_migrarTurnos
AS BEGIN
	INSERT INTO [MAIDEN].Turno(Hora_Inicio, Hora_Fin, Precio_Base, Precio_km, Descripcion)
	SELECT DISTINCT 
		Turno_Hora_Inicio,
		Turno_Hora_Fin,
		Turno_Precio_Base,
		Turno_Valor_Kilometro,
		Turno_Descripcion
	FROM [gd_esquema].Maestra
END
GO

-- >>	Recibe los parámetros necesarios para dar de ALTA un nuevo turno y lo inserta en la tabla TURNO
CREATE PROCEDURE [MAIDEN].SP_altaTurno(@inicio numeric(18,0),
								 @fin numeric(18,0),
								 @precioBase numeric(18,2),
								 @precioKm numeric(18,2),
								 @descripcion varchar(255),
								 @habilitado bit) 
AS BEGIN
	INSERT INTO [MAIDEN].Turno(Hora_Inicio,Hora_Fin,Precio_Base,Precio_km,Descripcion,Habilitado)
	VALUES(@inicio, @fin, @precioBase, @precioKm, @descripcion,@habilitado)
END
GO

-- >>	Recibe el id del TURNO a MODIFICAR y actualiza sus columnas con los datos recibidos
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
	UPDATE [MAIDEN].Turno
	SET Hora_Inicio = @inicio,
		Hora_Fin = @fin,
		Precio_Base = @precioBase,
		Precio_km = @precioKM,
		Descripcion = @descripcion,
		Habilitado = @habilitado
	WHERE ID=@id
END
GO

-- >>	Recibe el ID del TURNO a DESHABILITAR, y setea su valor "habilitado" a 0 (deshabilitado).
CREATE PROCEDURE [MAIDEN].SP_deshabilitarTurno(@id int)
AS BEGIN
	UPDATE [MAIDEN].Turno
	SET Habilitado=0
	WHERE ID=@id
END
GO

-- >>	Recibe el ID del TURNO a HABILITAR, y setea su valor "habilitado" a 1 (habilitado).
CREATE PROCEDURE [MAIDEN].SP_habilitarTurno(@id int)
AS
BEGIN
	UPDATE [MAIDEN].Turno
	SET Habilitado=1
	WHERE ID=@id
END
GO

-- =============================================
--					** ROLES **
-- =============================================
-- >>	El procedimiento recibe el nombre del rol, y los ID de las funcionalidades.
-- (Estos IDS deben serializarse entre ';'. De esta forma, 
-- separando el string de acuerdo a dicho caracter, podemos conocer
-- cuales son las funcionalidades indicadas. Por ej: ;1;2;3;4;)
CREATE PROCEDURE [MAIDEN].SP_altaRol(@rol varchar(20),@funcionalidades nvarchar(100))
AS BEGIN
	Declare @ID_ROL int
	INSERT INTO [MAIDEN].Rol(Rol,Habilitado)
	values (@rol, 1)
	SET @ID_ROL = @@IDENTITY
	INSERT INTO [MAIDEN].Funcionalidad_por_Rol(Rol,Funcionalidad)
	Select @ID_ROL,ID FROM [MAIDEN].Funcionalidad where
	@funcionalidades like '%;'+ cast(ID as nvarchar(3)) + ';%'
END
GO

-- >>	Redibe el ID del rol a modificar y sus nuevas funcionalidades. (Serializadas del mismo modo que el SP anterior)
-- Se eliminan toads las funcionalidades que poseía y se le asignan las nuevas.
CREATE PROCEDURE [MAIDEN].SP_modifRol(@idRol int, @nombreRol varchar(20),@funcionalidades nvarchar(100))
AS BEGIN
	UPDATE [MAIDEN].Rol
		SET Rol = @nombreRol
	WHERE ID=@idRol

	DELETE FROM [MAIDEN].Funcionalidad_por_Rol where Rol = @idRol 
	INSERT INTO MAIDEN.Funcionalidad_por_Rol 
	Select @idRol, ID from [MAIDEN].Funcionalidad where
	 @funcionalidades like '%;'+ cast(ID as nvarchar(3)) + ';%'
END
GO

-- >>	Se recibe el ID del rol a deshabilitar.
-- Se setea su campo 'Habilitado en 0 (falso => deshabilitado).
-- Y además se elimina de todos los usuarios que poseían dicho rol
CREATE PROCEDURE [MAIDEN].SP_deshabilitarRol(@id int)
AS BEGIN
	UPDATE [MAIDEN].Rol
	SET Habilitado = 0
	WHERE ID=@id
	DELETE [MAIDEN].Rol_por_Usuario where Rol = @id		--   <--- Se le elimina el rol a todos los usuarios que lo poseian
END
GO

-- >>	Se recibie el ID del rol a habilitar y se setea 'Habilitado' en 1 (verdadero => Habilitado)
CREATE PROCEDURE [MAIDEN].SP_habilitarRol(@id int)
AS BEGIN
	UPDATE [MAIDEN].Rol
	SET Habilitado = 1
	WHERE ID=@id
END
GO

-- >>	Recibe el nombre de usuario y el rol a asignarle.
-- Sólo se le asigna si aún no lo poseía
CREATE PROCEDURE [MAIDEN].SP_asignarRol(@usuario varchar(30), @rol varchar(20))
AS BEGIN 
	declare @rolId int
	set @rolId =(SELECT ID FROM [MAIDEN].Rol where rol=@rol)
	if (not exists (Select 1 from [MAIDEN].Rol_por_Usuario			-- Si no tenia asignado el rol se lo asigna. Sino no hace nada
						where usuario = @usuario and rol = @rolId))			  
	Begin
		Insert into [MAIDEN].Rol_por_Usuario
		values(@usuario,@rolId)
	End
END
GO

-- >>	Recibe el nombre de usuario y el rol a eliminarle.
CREATE PROCEDURE [MAIDEN].SP_quitarRol(@usuario varchar(30), @rol varchar(20))
AS
BEGIN 
	DECLARE @RolId int
	Set @RolId = (SELECT ID FROM [MAIDEN].Rol where rol=@rol)
	Delete from [MAIDEN].Rol_por_Usuario where(
	Usuario = @usuario AND Rol = @RolId)
END
GO

-- =============================================
--					** USUARIOS **
-- =============================================
-- >>	Recibe el nombre de usuario y contraseña,
-- almacena en la tabla USUARIO	dichos datos, CIFRANDO la contraseña según algoritmo SHA256
CREATE PROCEDURE [MAIDEN].SP_altaUsuario(@usuario varchar(30), @pass varchar(256))
AS BEGIN
	INSERT INTO [MAIDEN].Usuario
	values(@usuario,HASHBYTES('SHA2_256',@pass),0)
END
GO

-- >>	Actualiza la contraseña del USUARIO recibido como parámetro
CREATE PROCEDURE [MAIDEN].SP_modifPass(@usuario varchar(30), @pass varchar(256))
AS BEGIN
	UPDATE [MAIDEN].Usuario
	SET Pass = HASHBYTES('SHA2_256',@pass)
	WHERE Usuario = @usuario
END
GO

-- >>	Elimina el USUARIO recibido como parámetro.
-- Para ello primero elimina todos sus roles, y luego da de baja fisica el usuario.
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
-- =============================================
--					** LOGIN **
-- =============================================

-- >>	Cuando el usuario y contraseña son correctos, acá se validan la cantidad de intentos.
-- Si la cantidad de intentos es 3 => se considera que el usuario está bloqueado y se le niega el acceso.
-- Caso contrario se le "resetean" la cantidad de intentos fallidos a 0.
CREATE PROCEDURE [MAIDEN].SP_loginOk(@usuario varchar(30))
AS BEGIN
	Declare @intentos int
	SET @intentos = (select intentosLogueo from [MAIDEN].Usuario WHERE Usuario=@usuario)
	IF (@intentos >=3) return 0					
	ELSE BEGIN									
		UPDATE [MAIDEN].Usuario
		SET intentosLogueo = 0
		WHERE Usuario = @usuario
		return 3						
	END
END
GO

-- >>	Invocado cuando el usuario y contraseña no coinciden. Devuelve la cantidad de intentos restantes.
--Si la cantidad de intentos fallidos es menor a 3 => Se le agrega un fallo
CREATE PROCEDURE [MAIDEN].SP_loginFail(@usuario varchar(30))
AS BEGIN
	Declare @intentosRealizados int
	SET @intentosRealizados = (select intentosLogueo from [MAIDEN].Usuario WHERE Usuario=@usuario)
	if (@intentosRealizados < 3) 
						BEGIN							-- se le agrega un intento fallido
							SET @intentosRealizados = @intentosRealizados+1
							UPDATE [MAIDEN].Usuario
							SET intentosLogueo = @intentosRealizados
							WHERE Usuario=@usuario
						END;
	RETURN (3-@intentosRealizados)				-- devuelve la cantidad de intentos restantes			--Intentos realizados = 3 = max => Deshabilitado
END
GO

-- >>	Invocado al momento de INICIAR SESION en la Aplicación.
-- Controla usuario y contraseña y luego delega en los 2 procedimientos anteriores
-- según los datos sean correctos o no.
CREATE PROCEDURE [MAIDEN].SP_login(@usuario varchar(30), @password varchar(256))
AS BEGIN 
	Declare @contraseña varchar(256), @resultado int
	SET @contraseña = (Select pass from [MAIDEN].USUARIO WHERE Usuario=@usuario)
	IF (@contraseña IS NULL) throw 51000, 'Usuario Inexistente',1	
	if( HASHBYTES('SHA2_256',@password) = @contraseña)			
		EXEC @resultado = [MAIDEN].SP_loginOk @usuario
	else Exec @resultado = [MAIDEN].SP_loginFail @usuario
	SELECT @resultado
END
GO
-- =============================================
--					** VIAJES **
-- =============================================

-- >>	1) Para cada viaje distinto obtengo su Factura y también su Rendicion
--		2) Para cada viaje (repetidos o no) obtengo su Factura y Rendicion
--		3) Obtengo las FK del viaje a otras tablas (Chofer, Cliente, Auto, Turno)
CREATE PROCEDURE [MAIDEN].SP_migrarViajes
AS BEGIN
INSERT INTO [MAIDEN].Viaje(Chofer,Auto,Turno,Km,Fecha,Cliente,NroRendicion, NroFactura)
SELECT 	choferes.ID,
		auto.ID,
		turno.ID,
		viajeSimple.Viaje_Cant_Kilometros,
		viajeSimple.Viaje_Fecha,
		cliente.ID,
		viajeCompleto.Rendicion_Nro,
		viajeCompleto.Factura_Nro FROM [gd_esquema].Maestra viajeSimple			--Viajes SIN factura ni rendicion
		LEFT JOIN (
				SELECT DISTINCT 
					conRendicion.Chofer_dni,
					conRendicion.Auto_Patente,
					conRendicion.Turno_Hora_Inicio,
					conRendicion.Viaje_Cant_Kilometros,
					conRendicion.Viaje_Fecha,
					conRendicion.Cliente_Dni,
					conRendicion.Rendicion_Nro,
					conFactura.Factura_Nro
				From [gd_esquema].Maestra conRendicion JOIN [gd_esquema].[Maestra] conFactura on
				(conRendicion.Cliente_Dni = conFactura.Cliente_Dni			-- Joinea (con Factura <-> con Rendicion) donde sea el MISMO viaje 
					AND conRendicion.Viaje_Fecha = conFactura.Viaje_Fecha 
					AND conRendicion.Chofer_Dni = conFactura.Chofer_Dni)
				WHERE (conRendicion.Rendicion_Nro IS NOT NULL AND conFactura.Factura_Nro IS NOT NULL)
			)viajeCompleto									--Obtengo para cada viaje distinto su viaje completo (datos viaje + NroFactura + NroRendicion (1)
				on (viajeCompleto.Chofer_Dni = viajeSimple.Chofer_Dni 
					AND viajeCompleto.Cliente_Dni = viajeSimple.Cliente_Dni 
					AND viajeCompleto.Viaje_Fecha = viajeSimple.Viaje_Fecha)		-- JOINEO cada viaje "simple" con su correspondiente viaje "completo" (con factura y rendicion) (2)
			JOIN MAIDEN.Chofer choferes on (choferes.dni=viajeSimple.Chofer_Dni)		-- Consulto Chofer	(3)
			JOIN Maiden.Auto auto on (auto.Patente=viajeSimple.Auto_Patente)			-- Consulto Auto
			JOIN Maiden.Cliente cliente on (cliente.DNI = viajeSimple.Cliente_Dni)		-- Consulto Cliente
			JOIN MAIDEN.Turno turno on (turno.Hora_Inicio = viajeSimple.Turno_Hora_Inicio)	-- Consulto Turno
		WHERE (viajeSimple.Factura_Nro IS NULL AND viajeSimple.Rendicion_Nro IS NULL)		-- Viaje simple = SIN factura ni Rendicion
END
GO

-- >>	Recibe los parámetros necesarios para dar de ALTA un nuevo viaje y lo inserta en la tabla VIAJE
CREATE PROCEDURE [MAIDEN].SP_altaViaje(@idChofer int,
									@idAuto int,
									@kms numeric(18,0),
									@fecha datetime,
									@idCliente int,
									@horaFin time)
AS BEGIN 
	Declare @idTurno int;

	if exists(select 1 from [MAIDEN].viaje where(Chofer = @idChofer AND NOT(		-- Controla que no hayan otro viaje del chofer en ese momento
		(@horaFin) < Format(Fecha,'HH:mm')
		 OR (Format(@fecha,'HH:mm') >Hora_Fin))
	AND CAST(Fecha as Date) = CAST(@fecha as Date))) throw 51000,'EL chofer ya tiene otro viaje registrado en ese horario',16;

	if exists(select 1 from [MAIDEN].viaje where(Cliente = @idCliente AND NOT(		-- Controla que no hayan otro viaje del cliente en ese momento
	(@horaFin) < Format(Fecha,'HH:mm')
	 OR (Format(@fecha,'HH:mm') >Hora_Fin))
	AND CAST(Fecha as Date) = CAST(@fecha as Date))) throw 51000,'EL cliente ya tiene otro viaje registrado en ese horario',16;

	Select @idTurno = ID from [MAIDEN].Turno where (					-- Obtiene el turno al que corresponde el horario del viaje
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

-- =============================================
--					** RENDICION **
-- =============================================
-- >>	Para cada rendicion existirá un único registro en nuestra tabla RENDICION con los datos obtenidos de la tabla maestra.
--	En el caso de existir viajes rendidos varias veces (es decir, todas sus columnas identicas),
-- TODOS esos registros serán tenidos en cuenta a la hora de calcular el importe total. (Ninguno de ellos será descartado)
CREATE PROCEDURE [MAIDEN].SP_migrarRendiciones
AS BEGIN
	SET IDENTITY_INSERT [MAIDEN].Rendicion ON								-- Nuestra tabla RENDICION usa Identity como ID, 
	INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Nro, Importe_Total, Turno)		-- pero la tabla maestra ya tiene ciertos valores. De esta forma permitirá setearle dichos valores sin problemas con los identity
	SELECT chofer.ID,
		   CAST(Rendicion_Fecha as Date),
		   Rendicion_Nro,
		   sum(Rendicion_Importe),
		   turno.ID
		   From [gd_esquema].Maestra JOIN MAIDEN.Chofer chofer on (chofer.Dni=Chofer_Dni)
							  JOIN MAIDEN.Turno turno on (turno.Hora_Inicio=Turno_Hora_Inicio)
	Where Rendicion_Nro IS NOT NULL
	Group by chofer.ID, CAST(Rendicion_Fecha as Date), Rendicion_Nro, turno.ID
	SET IDENTITY_INSERT [MAIDEN].Rendicion OFF
END
GO

-- >>	Luego de realizar la rendición del dia, es necesario setearle a los VIAJES que corresponden
--	el nro de la rendicion registrada.
CREATE PROCEDURE [MAIDEN].SP_actualizarRendicionEnViajes(@idChofer int, @fecha Date,@codRendicion numeric(18,0))
AS BEGIN
	UPDATE [MAIDEN].Viaje
	SET NroRendicion = @codRendicion
	WHERE(cast(Fecha as DATE) = @fecha 
		AND Chofer = @idChofer)
END
GO

-- >>	Se realiza la rendicion al chofer indicado, en la fecha y turnos recibidos por parámetro.
-- Si no existia => Se registra la rendicion y se devuelven sus datos
-- Si existia => Se devuelve el Nro de Rendicion correspondiente (por si el usuario desea ver el detalle)
CREATE PROCEDURE [MAIDEN].SP_Rendicion(@idChofer int, @fecha Date, @idTurno int)
AS BEGIN
	Declare @cod_Rendicion int, @total numeric(18,2) 
	SET @cod_Rendicion= (Select Nro from [MAIDEN].Rendicion Where @idChofer = Chofer and @fecha = Fecha AND Turno = @idTurno)	
	IF (@cod_Rendicion IS NULL)
		BEGIN
			INSERT INTO [MAIDEN].Rendicion(Chofer,Fecha,Turno,Importe_Total)
			Select @idChofer, @fecha, t.ID, sum(t.Precio_Base+t.Precio_km*v.Km)*0.3				-- Le corresponde el 30% del precio del viaje 
			From Turno t join Viaje v on (t.ID = v.Turno) 
			WHERE Cast(v.Fecha as Date) = @fecha AND v.Chofer = @idChofer
			GROUP BY t.ID

			SET @cod_Rendicion = @@IDENTITY					-- Necesito el ID para actualizarlo en los viajes
	
			Select @total = Importe_Total from [MAIDEN].Rendicion where Nro = @cod_Rendicion
			EXEC [MAIDEN].SP_actualizarRendicionEnViajes @idChofer, @fecha, @cod_Rendicion				-- Seteo la FK en viajes, para saber a que Rendicion le corresponde
	
			Select * FROM [MAIDEN].fx_getDatosRendicion(@cod_Rendicion)					-- Agrego el total al final
			Union Select null,null,null,null,null,null,null,null, @total
			ORDER BY 9			 
		END
	ELSE throw 51002,@cod_Rendicion,16;				--Devuelve el codigo de rendicion para poder cargarlo posteriormente si el usuario lo desea
END
GO

-- =============================================
--					** FACTURA **
-- =============================================
-- >>	Para cada facturación existirá un único registro en nuestra tabla FACTURA con los datos obtenidos de la tabla maestra.
--	En el caso de existir viajes facturados varias veces (es decir, todas sus columnas identicas),
-- TODOS esos registros serán tenidos en cuenta a la hora de calcular el importe total. (Ninguno de ellos será descartado)
CREATE PROCEDURE [MAIDEN].SP_migrarFacturas
AS BEGIN
	SET IDENTITY_INSERT [MAIDEN].Factura ON				--				<------ Nuestra tabla RENDICION usa Identity como ID, 
	INSERT INTO [MAIDEN].Factura(Nro,Cliente,Fecha,Fecha_Inicio,Fecha_Fin,Importe_Total)			-- pero la tabla maestra ya tiene ciertos valores. De esta forma permitirá setearle dichos valores sin problemas con los identity
	SELECT	Factura_Nro,
		   cliente.ID,
		   Factura_Fecha,
		   Factura_Fecha_Inicio,
		   Factura_Fecha_Fin,
		   SUM(Turno_Precio_Base+Turno_Valor_Kilometro*Viaje_Cant_Kilometros)
		   From [gd_esquema].Maestra JOIN MAIDEN.Cliente cliente on (cliente.DNI = Cliente_Dni)
			WHERE Factura_Nro IS NOT NULL
	GROUP BY Factura_Nro, cliente.ID, Factura_Fecha, Factura_Fecha_Inicio, Factura_Fecha_Fin
	SET IDENTITY_INSERT [MAIDEN].Rendicion OFF
END
GO

-- >>	Luego de realizar una facturacion, es necesario setearle a los VIAJES que corresponden
--	el nro de la factura registrada.
CREATE PROCEDURE [MAIDEN].SP_actualizarFacturaEnViajes(@idCliente int, @fechaInicio datetime, @fechaFin datetime, @codFactura numeric(18,0))
AS BEGIN 
	UPDATE [MAIDEN].Viaje
	SET NroFactura = @codFactura
	WHERE (CAST(Fecha as DATE) BETWEEN CAST(@fechaInicio as DATE) AND CAST(@fechaFin AS DATE)
			AND Cliente = @idCliente)
END
GO

-- >>	Se realiza la facturación al cliente indicado de los viajes comprendido entre las fechas indicadas.
-- Si no existia => Se registra la factura y se devuelven sus datos
-- Si existia => Se devuelve el Nro de Factura correspondiente (por si el usuario desea ver el detalle)
CREATE PROCEDURE [MAIDEN].SP_Facturacion(@idCliente int, @fechaInicio datetime, @fechaFin datetime, @fechaFactura datetime)
AS BEGIN 
	DECLARE @cod_Factura int, @total numeric(18,2)
	SET @cod_Factura = (Select Nro FROM [MAIDEN].Factura WHERE Cliente = @idCliente AND CAST(Fecha_inicio as DATE)= CAST(@fechaInicio AS DATE))
	IF (@cod_Factura IS NULL)							-- No está registrada
		BEGIN
			INSERT INTO [MAIDEN].Factura(Cliente,Fecha,Fecha_Inicio,Fecha_Fin,Importe_total)
			SELECT @idCliente, @fechaFactura, @fechaInicio, @fechaFin, sum(t.Precio_Base+t.Precio_km*v.Km)
			FROM [MAIDEN].Viaje v join [MAIDEN].Turno t on v.Turno = t.ID
			WHERE v.Cliente = @idCliente AND v.Fecha BETWEEN @fechaInicio AND @fechaFin
			
			SET @cod_Factura = @@IDENTITY

			SELECT @total = Importe_Total from [MAIDEN].Factura Where Nro = @cod_Factura

			EXEC [MAIDEN].SP_actualizarFacturaEnViajes @idCliente, @fechaInicio, @fechaFin, @cod_Factura
			
			Select * FROM [MAIDEN].fx_getDatosFactura(@cod_Factura)
			Union Select null,null,null,null,null,null,null,@total
			ORDER BY 8	
		END
	ELSE throw 51002,@cod_Factura,16; --Devuelve el codigo de Factura para poder cargarlo posteriormente si el usuario lo desea
END
GO

-----------------------------------------------------------------------------------*
--------------------------------------TRIGGERS-------------------------------------*
-----------------------------------------------------------------------------------*
--Este trigger controla que no hayan turnos superpuestos / con duracion > a 1 dia
CREATE TRIGGER [MAIDEN].tg_controlTurnosSuperpuestos ON [MAIDEN].[Turno]			
   AFTER INSERT, UPDATE
AS 
BEGIN
	if Exists (select 1 from [MAIDEN].Turno turno, inserted nuevo		--Controla que no haya otro turno en el mismo horario que:
					WHERE												-- 1) ambos turnos esten habilitado. Si existe alguno que NO sea de respaldo
					NOT	(nuevo.Hora_Fin <= turno.Hora_Inicio			-- 2) Que el ID no sea el mismo (para la modificacion)
							OR nuevo.Hora_Inicio >= turno.Hora_Fin)		-- 3) Horarios.
					 AND
					nuevo.Habilitado = 1 AND turno.Respaldo=0 AND turno.Habilitado=1 AND nuevo.ID != turno.ID)
	BEGIN
		rollback transaction;
		throw 51000,'Ya existe un tuno activo en dicho intervalo',1;
	END
END
GO
-- Cuando se modifica un turno, si había algun VIAJE que hacía referencia a él, 
-- entonces el turno "modificado" se crea como uno nuevo para mantener la referencia de los
-- viajes al turno viejo (el cual se marca como deshabilitado).
-- Sino, el viaje quedaría quizá con precios que no eran los de ese momento.
--			 (Los datos del viaje quedarían inconsistentes)

CREATE TRIGGER [MAIDEN].tg_controlActualizacionTurnos ON [MAIDEN].[Turno]
	AFTER UPDATE
AS 
BEGIN Declare @idViejo int, @idNuevo int
	Select @idViejo = ID from deleted 

		if exists (Select 1 from [MAIDEN].Viaje, deleted turnoViejo where Turno = turnoViejo.id)
		BEGIN
			UPDATE [MAIDEN].Turno
			SET Respaldo=1, Habilitado=0
			WHERE ID = (Select ID from deleted)

			INSERT INTO [MAIDEN].Turno(Hora_Inicio,Hora_Fin,Precio_Base,Precio_km,Descripcion,Habilitado) 
			select i.Hora_Inicio,i.Hora_Fin,i.Precio_Base,i.Precio_km,i.Descripcion,i.Habilitado from inserted i
			
			SELECT @idNuevo = @@IDENTITY
			
			UPDATE [MAIDEN].Auto 
				SET Turno=@idNuevo
			WHERE Turno=@idViejo
		END

END
GO

-- ==========================================================================================
--					** FUNCIONALIDADES - ROLES - USUARIOS DEFAULT **
-- ==========================================================================================
-- >>	Crea las FUNCIONALIDADES default
CREATE PROCEDURE [MAIDEN].SP_crearFuncionalidadesDefault
AS BEGIN
	INSERT INTO Funcionalidad(ID, Descripcion)
	VALUES (1,'clientes'),(2,'choferes'),(3,'autos'),(4,'roles'),(5,'turnos'),(6,'viajes'),(7,'facturacion'),
	(8,'rendicion'),(9,'estadisticas')
END
GO

-- >>	Crea los ROLES default, asignandole las funcionalidades especificas a cada uno (serializadas)
-- (Segun los ids de las funcionalidades del SP anterior)
CREATE PROCEDURE [MAIDEN].SP_crearRolesDefault
AS
BEGIN
	Exec [MAIDEN].SP_altaRol 'admin',';1;2;3;4;5;6;7;8;9;'
	Exec [MAIDEN].SP_altaRol 'cliente',';7;'
	Exec [MAIDEN].SP_altaRol 'chofer',';8;'
END
GO
-- >> Crea los usuarios default, asignandoles roles default a cada uno
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
SET ANSI_PADDING OFF

-- ==========================================================================================
--										** EJECUCION DE MIGRACIONES **
-- ==========================================================================================

EXECUTE [MAIDEN].[SP_migrarClientes] 

EXECUTE [MAIDEN].[SP_migrarChoferes] 

EXECUTE [MAIDEN].[SP_migrarTurnos] 

EXECUTE [MAIDEN].[SP_migrarAutos] 

EXECUTE [MAIDEN].[SP_migrarRendiciones] 

EXECUTE [MAIDEN].[SP_migrarFacturas] 

EXECUTE [MAIDEN].[SP_migrarViajes]

EXECUTE [MAIDEN].[SP_crearFuncionalidadesDefault] 

EXECUTE [MAIDEN].[SP_crearRolesDefault] 

EXECUTE [MAIDEN].[SP_crearUsuariosDefault] 