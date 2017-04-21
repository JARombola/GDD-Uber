USE [GD1C2017]
GO
/****** Object:  Schema [ASD]    Script Date: 21/04/2017 17:26:35 ******/
CREATE SCHEMA [ASD]
GO
/****** Object:  Table [ASD].[Autos]    Script Date: 21/04/2017 17:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[Autos](
	[Marca] [varchar](255) NOT NULL,
	[Modelo] [varchar](255) NOT NULL,
	[Patente] [varchar](10) NOT NULL,
	[Licencia] [varchar](26) NOT NULL,
	[Rodado] [varchar](10) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Auto_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[Choferes]    Script Date: 21/04/2017 17:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[Choferes](
	[Nombre] [varchar](255) NULL,
	[Apellido] [varchar](255) NULL,
	[Dni] [numeric](18, 0) NULL,
	[Direccion] [varchar](255) NULL,
	[Telefono] [numeric](18, 0) NULL,
	[Mail] [varchar](50) NULL,
	[Fecha_Nacimiento] [datetime] NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Choferes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[Clientes]    Script Date: 21/04/2017 17:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[Clientes](
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[DNI] [numeric](18, 0) NOT NULL,
	[Telefono] [numeric](18, 0) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Mail] [varchar](255) NULL,
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
