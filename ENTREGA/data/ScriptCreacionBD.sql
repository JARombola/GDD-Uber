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
-- CONSTRAINT [IX_RolXUsuario] UNIQUE (Rol,Usuario))							** CREO QUE NO ES NECESARIO
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
	[Hora_Fin] [time](7),												-- Se controla que no sean null en la vista
	[NroRendicion] [numeric](18, 0) CONSTRAINT [FK_Viaje_Rendicion] REFERENCES [MAIDEN].[Rendicion],
	[NroFactura] [numeric](18, 0) CONSTRAINT [FK_Viaje_Factura] REFERENCES [MAIDEN].[Factura])

GO

SET ANSI_PADDING OFF

