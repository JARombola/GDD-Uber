USE [GD1C2017]
GO
/****** Object:  Schema [MAIDEN]    Script Date: 23/05/2017 15:41:34 ******/
CREATE SCHEMA [MAIDEN]
GO
/****** Object:  Table [MAIDEN].[Autos]    Script Date: 23/05/2017 15:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [MAIDEN].[Clientes](
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
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Clientes] PRIMARY KEY)
GO

CREATE TABLE [MAIDEN].[Choferes](
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
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Choferes] PRIMARY KEY
	)
GO

CREATE TABLE [MAIDEN].[Turnos](
	[Hora_Inicio] [numeric](18, 0) NOT NULL,
	[Hora_Fin] [numeric](18, 0) NOT NULL,
	[Precio_Base] [numeric](18, 2) NOT NULL,
	[Precio_km] [numeric](18, 2) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Habilitado] [bit] DEFAULT 1,
	[ID] [int] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Turnos] PRIMARY KEY)
GO

CREATE TABLE [MAIDEN].[Autos](
	[Marca] [varchar](255) NOT NULL,
	[Modelo] [varchar](255) NOT NULL,
	[Patente] [varchar](10) NOT NULL UNIQUE,
	[Licencia] [varchar](26),
	[Rodado] [varchar](10),
	[Habilitado] [bit] DEFAULT 1,									--Al registrarlos estan habilitados
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_AUTO] PRIMARY KEY,
	[Chofer] [int] CONSTRAINT [FK_Auto_Chofer] REFERENCES [MAIDEN].[Choferes],
	[Turno] [int] CONSTRAINT [FK_Auto_Turno] REFERENCES [MAIDEN].[Turnos])
GO

CREATE TABLE [MAIDEN].[Roles](
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Rol] PRIMARY KEY,
	[Rol] [varchar](20) NOT NULL,
	[Habilitado] [bit] DEFAULT 1)
GO

CREATE TABLE [MAIDEN].[Funcionalidad](
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Funcionalidad] PRIMARY KEY,
	[Descripcion] [nvarchar](100))
GO

CREATE TABLE [MAIDEN].[FuncionalidadXRol](
	[Rol] [int] REFERENCES [MAIDEN].Roles,
	[Funcionalidad] [int] REFERENCES [MAIDEN].[Funcionalidad],
 CONSTRAINT [PK_FuncionalidadXRol] PRIMARY KEY (Rol, Funcionalidad))
GO

CREATE TABLE [MAIDEN].[Usuarios](
	[Usuario] [varchar](30) NOT NULL CONSTRAINT [PK_Usuario] PRIMARY KEY,
	[Pass] [varchar](256) NOT NULL,
	[IntentosLogueo] [int] NOT NULL)
GO

CREATE TABLE [MAIDEN].[RolXUsuario](
	[Usuario] [varchar](30) NOT NULL,
	[Rol] [int] NOT NULL,
 CONSTRAINT [PK_RolXUsuario] PRIMARY KEY (Usuario,Rol),
-- CONSTRAINT [IX_RolXUsuario] UNIQUE (Rol,Usuario))							** CREO QUE NO ES NECESARIO
)
GO

CREATE TABLE [MAIDEN].[Rendicion](
	[Nro] [numeric](18, 0) IDENTITY(1,1) CONSTRAINT [PK_Rendicion] PRIMARY KEY,
	[Chofer] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Turno] [int] CONSTRAINT [FK_Rendicion_Turno] REFERENCES [MAIDEN].[Turnos],
	[Importe_Total] [numeric](18, 2) NOT NULL)													
GO

CREATE TABLE [MAIDEN].[Viajes](
	[ID] [int] IDENTITY(1,1) CONSTRAINT [PK_Viajes] PRIMARY KEY,
	[Chofer] [int] NOT NULL CONSTRAINT [FK_Viaje_Chofer] REFERENCES [MAIDEN].[Choferes],
	[Auto] [int] NOT NULL CONSTRAINT [FK_Viaje_Auto] REFERENCES [MAIDEN].[Autos],
	[Turno] [int] NOT NULL CONSTRAINT [FK_Viaje_Turno] REFERENCES [MAIDEN].[Turnos],
	[Km] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cliente] [int] NOT NULL CONSTRAINT [FK_Viaje_Cliente] REFERENCES [MAIDEN].[Clientes],
	[Hora_Fin] [time](7),												-- Se controla que no sean null en la vista
	[NroRendicion] [numeric](18, 0) CONSTRAINT [FK_Viaje_Rendicion] REFERENCES [MAIDEN].[Rendicion])
GO

SET ANSI_PADDING OFF

