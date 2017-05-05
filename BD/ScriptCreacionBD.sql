USE [GD1C2017]
GO
/****** Object:  User [gd]    Script Date: 05/05/2017 18:52:26 ******/
CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [ASD]    Script Date: 05/05/2017 18:52:26 ******/
CREATE SCHEMA [ASD]
GO
/****** Object:  Table [ASD].[Autos]    Script Date: 05/05/2017 18:52:26 ******/
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
	[Chofer] [int] NULL,
 CONSTRAINT [PK_Auto_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[Choferes]    Script Date: 05/05/2017 18:52:26 ******/
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
/****** Object:  Table [ASD].[Clientes]    Script Date: 05/05/2017 18:52:26 ******/
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
/****** Object:  Table [ASD].[Roles]    Script Date: 05/05/2017 18:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[Roles](
	[Rol] [varchar](20) NOT NULL,
	[Clientes] [bit] NULL,
	[Choferes] [bit] NULL,
	[Autos] [bit] NULL,
	[Roles] [bit] NULL,
	[Turnos] [bit] NULL,
	[Viajes] [bit] NULL,
	[Facturacion] [bit] NULL,
	[Rendicion] [bit] NULL,
	[Estadisticas] [bit] NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Roles_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[RolXUsuario]    Script Date: 05/05/2017 18:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[RolXUsuario](
	[Usuario] [varchar](30) NOT NULL,
	[Rol] [int] NOT NULL,
 CONSTRAINT [PK_RolXUsuario] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC,
	[Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_RolXUsuario] UNIQUE NONCLUSTERED 
(
	[Rol] ASC,
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[Turnos]    Script Date: 05/05/2017 18:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[Turnos](
	[Hora_Inicio] [numeric](18, 0) NOT NULL,
	[Hora_Fin] [numeric](18, 0) NOT NULL,
	[Precio_Base] [numeric](18, 2) NOT NULL,
	[Precio_km] [numeric](18, 2) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[Usuarios]    Script Date: 05/05/2017 18:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ASD].[Usuarios](
	[Usuario] [varchar](30) NOT NULL,
	[Pass] [varchar](256) NOT NULL,
	[IntentosLogueo] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ASD].[Viajes]    Script Date: 05/05/2017 18:52:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ASD].[Viajes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Chofer] [int] NOT NULL,
	[Auto] [int] NOT NULL,
	[Turno] [int] NOT NULL,
	[Km] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cliente] [int] NOT NULL,
 CONSTRAINT [PK_Viajes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ASD].[Autos] ADD  CONSTRAINT [DF_Autos_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [ASD].[Choferes] ADD  CONSTRAINT [DF_Choferes_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [ASD].[Clientes] ADD  CONSTRAINT [DF_Clientes_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [ASD].[Roles] ADD  CONSTRAINT [DF_Roles_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [ASD].[Turnos] ADD  CONSTRAINT [DF_Turnos_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [ASD].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_IntentosLogueo]  DEFAULT ((0)) FOR [IntentosLogueo]
GO
ALTER TABLE [ASD].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Auto_Chofer] FOREIGN KEY([Chofer])
REFERENCES [ASD].[Choferes] ([ID])
GO
ALTER TABLE [ASD].[Autos] CHECK CONSTRAINT [FK_Auto_Chofer]
GO
ALTER TABLE [ASD].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol] FOREIGN KEY([Rol])
REFERENCES [ASD].[Roles] ([ID])
GO
ALTER TABLE [ASD].[RolXUsuario] CHECK CONSTRAINT [FK_Rol]
GO
ALTER TABLE [ASD].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario] FOREIGN KEY([Usuario])
REFERENCES [ASD].[Usuarios] ([Usuario])
GO
ALTER TABLE [ASD].[RolXUsuario] CHECK CONSTRAINT [FK_Usuario]
GO
ALTER TABLE [ASD].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Chofer] FOREIGN KEY([Chofer])
REFERENCES [ASD].[Choferes] ([ID])
GO
ALTER TABLE [ASD].[Viajes] CHECK CONSTRAINT [FK_Chofer]
GO
ALTER TABLE [ASD].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes] FOREIGN KEY([Cliente])
REFERENCES [ASD].[Clientes] ([ID])
GO
ALTER TABLE [ASD].[Viajes] CHECK CONSTRAINT [FK_Clientes]
GO
ALTER TABLE [ASD].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Turno] FOREIGN KEY([Turno])
REFERENCES [ASD].[Turnos] ([ID])
GO
ALTER TABLE [ASD].[Viajes] CHECK CONSTRAINT [FK_Turno]
GO
ALTER TABLE [ASD].[Choferes]  WITH CHECK ADD  CONSTRAINT [CK_Choferes_DNI] CHECK  (([DNI]>(0)))
GO
ALTER TABLE [ASD].[Choferes] CHECK CONSTRAINT [CK_Choferes_DNI]
GO
