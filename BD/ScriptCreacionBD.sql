USE [GD1C2017]
GO
/****** Object:  Schema [MAIDEN]    Script Date: 08/05/2017 19:08:56 ******/
CREATE SCHEMA [MAIDEN]
GO
/****** Object:  Table [MAIDEN].[Autos]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MAIDEN].[Autos](
	[Marca] [varchar](255) NOT NULL,
	[Modelo] [varchar](255) NOT NULL,
	[Patente] [varchar](10) NOT NULL,
	[Licencia] [varchar](26) NULL,
	[Rodado] [varchar](10) NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Chofer] [int] NULL,
	[Turno] [int] NULL,
 CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Patentes] UNIQUE NONCLUSTERED 
(
	[Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MAIDEN].[Choferes]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MAIDEN].[Choferes](
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Choferes_Dni] UNIQUE NONCLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MAIDEN].[Clientes]    Script Date: 08/05/2017 19:08:56 ******/
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
	[Telefono] [numeric](18, 0) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Mail] [varchar](255) NULL,
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Clientes_Dni] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MAIDEN].[Roles]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MAIDEN].[Roles](
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
/****** Object:  Table [MAIDEN].[RolXUsuario]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MAIDEN].[RolXUsuario](
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
/****** Object:  Table [MAIDEN].[Turnos]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MAIDEN].[Turnos](
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
/****** Object:  Table [MAIDEN].[Usuarios]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MAIDEN].[Usuarios](
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
/****** Object:  Table [MAIDEN].[Viajes]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MAIDEN].[Viajes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Chofer] [int] NOT NULL,
	[Auto] [int] NOT NULL,
	[Turno] [int] NOT NULL,
	[Km] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cliente] [int] NOT NULL,
	[Hora_Fin] [time](7) NULL,
 CONSTRAINT [PK_Viajes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [MAIDEN].[vw_Autos]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [MAIDEN].[vw_Autos]
AS
SELECT        Marca, Modelo, Patente, Chofer, Turno
FROM          MAIDEN.Autos coche
LEFT JOIN	 [MAIDEN].Choferes chofer on coche.Chofer = chofer.ID
WHERE (Chofer.ID IS NOT NULL) AND (Turno IS NOT NULL)


GO
/****** Object:  View [MAIDEN].[vw_Viajes]    Script Date: 08/05/2017 19:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [MAIDEN].[vw_Viajes]
AS
SELECT        MAIDEN.Viajes.*
FROM            MAIDEN.Viajes
WHERE Hora_Fin IS NOT NULL


GO
ALTER TABLE [MAIDEN].[Autos] ADD  CONSTRAINT [DF_Autos_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [MAIDEN].[Choferes] ADD  CONSTRAINT [DF_Choferes_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [MAIDEN].[Clientes] ADD  CONSTRAINT [DF_Clientes_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [MAIDEN].[Roles] ADD  CONSTRAINT [DF_Roles_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [MAIDEN].[Turnos] ADD  CONSTRAINT [DF_Turnos_Habilitado]  DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [MAIDEN].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_IntentosLogueo]  DEFAULT ((0)) FOR [IntentosLogueo]
GO
ALTER TABLE [MAIDEN].[Viajes] ADD  CONSTRAINT [DF_Viajes_Hora_Fin]  DEFAULT (NULL) FOR [Hora_Fin]
GO
ALTER TABLE [MAIDEN].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Choferes] FOREIGN KEY([Chofer])
REFERENCES [MAIDEN].[Choferes] ([ID])
GO
ALTER TABLE [MAIDEN].[Autos] CHECK CONSTRAINT [FK_Autos_Choferes]
GO
ALTER TABLE [MAIDEN].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Turnos] FOREIGN KEY([Turno])
REFERENCES [MAIDEN].[Turnos] ([ID])
GO
ALTER TABLE [MAIDEN].[Autos] CHECK CONSTRAINT [FK_Autos_Turnos]
GO
ALTER TABLE [MAIDEN].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol] FOREIGN KEY([Rol])
REFERENCES [MAIDEN].[Roles] ([ID])
GO
ALTER TABLE [MAIDEN].[RolXUsuario] CHECK CONSTRAINT [FK_Rol]
GO
ALTER TABLE [MAIDEN].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario] FOREIGN KEY([Usuario])
REFERENCES [MAIDEN].[Usuarios] ([Usuario])
GO
ALTER TABLE [MAIDEN].[RolXUsuario] CHECK CONSTRAINT [FK_Usuario]
GO
ALTER TABLE [MAIDEN].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Chofer] FOREIGN KEY([Chofer])
REFERENCES [MAIDEN].[Choferes] ([ID])
GO
ALTER TABLE [MAIDEN].[Viajes] CHECK CONSTRAINT [FK_Chofer]
GO
ALTER TABLE [MAIDEN].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes] FOREIGN KEY([Cliente])
REFERENCES [MAIDEN].[Clientes] ([ID])
GO
ALTER TABLE [MAIDEN].[Viajes] CHECK CONSTRAINT [FK_Clientes]
GO
ALTER TABLE [MAIDEN].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Turno] FOREIGN KEY([Turno])
REFERENCES [MAIDEN].[Turnos] ([ID])
GO
ALTER TABLE [MAIDEN].[Viajes] CHECK CONSTRAINT [FK_Turno]
GO
ALTER TABLE [MAIDEN].[Choferes]  WITH CHECK ADD  CONSTRAINT [CK_Choferes_DNI] CHECK  (([DNI]>(0)))
GO
ALTER TABLE [MAIDEN].[Choferes] CHECK CONSTRAINT [CK_Choferes_DNI]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[26] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Autos (MAIDEN)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'MAIDEN', @level1type=N'VIEW',@level1name=N'vw_Autos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'MAIDEN', @level1type=N'VIEW',@level1name=N'vw_Autos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Viajes (MAIDEN)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'MAIDEN', @level1type=N'VIEW',@level1name=N'vw_Viajes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'MAIDEN', @level1type=N'VIEW',@level1name=N'vw_Viajes'
GO
