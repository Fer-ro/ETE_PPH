USE [ETE]
GO
/****** Object:  Table [dbo].[Accesos_Default]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accesos_Default](
	[ID_NivelAcceso] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Acceso] [nchar](40) NULL,
 CONSTRAINT [PK_Accesos] PRIMARY KEY CLUSTERED 
(
	[ID_NivelAcceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvanceTickets]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvanceTickets](
	[ID_AvaceTicket] [int] IDENTITY(1,1) NOT NULL,
	[Avance] [int] NULL,
	[FK_ID_Ticket] [int] NULL,
	[FK_ID_UsuarioApoyo] [int] NULL,
	[Fecha_Registro] [int] NULL,
	[Descripcion_Trabajo_Realizado] [nchar](10) NULL,
	[Fecha_Inicio_Reparacion] [datetime] NULL,
	[Fecha_Fin_Reparacion] [nchar](10) NULL,
	[Tiempo_Validacion] [time](7) NULL,
	[Cantidad_Piezas_Prueba] [nchar](10) NULL,
	[Disposicion] [nchar](10) NULL,
	[Responsable] [nchar](10) NULL,
	[Aprobacion_Por_Calidad] [nchar](10) NULL,
	[Descripcion_Trabajo_PorHacer] [nchar](10) NULL,
 CONSTRAINT [PK_AvanceTickets] PRIMARY KEY CLUSTERED 
(
	[ID_AvaceTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogo_Area_Fallas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogo_Area_Fallas](
	[ID_AreaFalla] [int] IDENTITY(1,1) NOT NULL,
	[Area_Falla] [nvarchar](50) NULL,
 CONSTRAINT [PK_Catalogo_Area_Fallas] PRIMARY KEY CLUSTERED 
(
	[ID_AreaFalla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogo_Codigos_Scrap]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogo_Codigos_Scrap](
	[ID_Catalogo_Scrap] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_defecto] [nvarchar](15) NULL,
	[Descripcion_defecto] [nvarchar](50) NULL,
	[FK_ID_TipoFalla] [int] NULL,
 CONSTRAINT [PK_Catalogo_Codigos_Scrap] PRIMARY KEY CLUSTERED 
(
	[ID_Catalogo_Scrap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogo_Impactos_OT]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogo_Impactos_OT](
	[ID_TipoImpacto] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Impacto_OT] [nvarchar](50) NULL,
 CONSTRAINT [PK_Catalogo_Impactos_OT] PRIMARY KEY CLUSTERED 
(
	[ID_TipoImpacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Celdas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Celdas](
	[ID_Celda] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Linea] [int] NULL,
	[Nom_Celda] [varchar](20) NULL,
 CONSTRAINT [PK__Celdas__03A01EC8B4ACB2E5] PRIMARY KEY CLUSTERED 
(
	[ID_Celda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Codigos_Paro]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Codigos_Paro](
	[ID_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[FK_ID_TipoParo] [int] NULL,
	[FK_ID_Area_Fallo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contramedidas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contramedidas](
	[ID_Contramedida] [int] IDENTITY(1,1) NOT NULL,
	[Contramedida] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contramedidas] PRIMARY KEY CLUSTERED 
(
	[ID_Contramedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cordones]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cordones](
	[ID_Cordon] [int] IDENTITY(1,1) NOT NULL,
	[Cordon] [nvarchar](50) NULL,
	[Tipo_Maquina] [nvarchar](15) NULL,
 CONSTRAINT [PK_Cordones] PRIMARY KEY CLUSTERED 
(
	[ID_Cordon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[ID_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[Departamento] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[ID_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estatus_Permisos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estatus_Permisos](
	[FK_ID_EstatusPermisos] [int] IDENTITY(1,1) NOT NULL,
	[Estatus] [nchar](15) NULL,
 CONSTRAINT [PK_Estatus_Permisos] PRIMARY KEY CLUSTERED 
(
	[FK_ID_EstatusPermisos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estatus_Tickets]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estatus_Tickets](
	[ID_EstatusTicket] [int] IDENTITY(1,1) NOT NULL,
	[Estatus] [nchar](15) NULL,
 CONSTRAINT [PK_Estatus_Tickets] PRIMARY KEY CLUSTERED 
(
	[ID_EstatusTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estatus_Usuarios]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estatus_Usuarios](
	[ID_Estatus_Usuarios] [int] IDENTITY(1,1) NOT NULL,
	[Estatus] [nchar](10) NULL,
 CONSTRAINT [PK_Estatus_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Estatus_Usuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estaus_Solicitud]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estaus_Solicitud](
	[ID_EstatusSolicitud] [int] NOT NULL,
	[Solicitud] [nvarchar](50) NULL,
 CONSTRAINT [PK_Estaus_Solicitud] PRIMARY KEY CLUSTERED 
(
	[ID_EstatusSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historico_Logueos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historico_Logueos](
	[ID_Historico] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Usuario] [int] NULL,
	[Fecha_Logueo] [datetime] NULL,
 CONSTRAINT [PK_Historico_Logueos] PRIMARY KEY CLUSTERED 
(
	[ID_Historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lineas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lineas](
	[ID_Linea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Tipo_Linea] [nchar](10) NULL,
	[FK_ID_Proyecto] [int] NULL,
	[Tipo_Maquina] [nchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logo]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logo](
	[Id_Logo] [int] IDENTITY(1,1) NOT NULL,
	[img] [image] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Logo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[ID_Menu] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Menu] [nvarchar](30) NULL,
	[Menu_Descripcion] [nvarchar](40) NULL,
	[FK_ID_NivelAcceso_Deault] [int] NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[ID_Menu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paginas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paginas](
	[ID_Paginas] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Pagina] [nvarchar](50) NULL,
	[FK_ID_Menu] [int] NULL,
	[NivelAcceso_Default] [int] NULL,
	[Direccion_Sitio] [nvarchar](50) NULL,
	[Nombre_En_Menu] [nvarchar](20) NULL,
	[Orden_En_Menu] [int] NULL,
	[Clase_Icono] [nvarchar](25) NULL,
 CONSTRAINT [PK_Paginas] PRIMARY KEY CLUSTERED 
(
	[ID_Paginas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[ID_Permiso] [int] IDENTITY(1,1) NOT NULL,
	[Permiso_Descripcion] [nchar](30) NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[ID_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyectos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyectos](
	[ID_Proyecto] [int] IDENTITY(1,1) NOT NULL,
	[Proyecto] [nchar](15) NULL,
 CONSTRAINT [PK_Proyectos] PRIMARY KEY CLUSTERED 
(
	[ID_Proyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto_Usuarios]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto_Usuarios](
	[ID_Puesto] [int] IDENTITY(1,1) NOT NULL,
	[Puesto_Usuario] [nvarchar](50) NULL,
 CONSTRAINT [PK_Puesto_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rangos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rangos](
	[ID_Rango] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Rango] [nchar](40) NULL,
 CONSTRAINT [PK_Rangos] PRIMARY KEY CLUSTERED 
(
	[ID_Rango] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Acceso_Menus]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Acceso_Menus](
	[ID_Permiso_Menu] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Menu] [int] NULL,
	[FK_ID_Usuario] [int] NULL,
	[FK_ID_Acceso] [int] NULL,
 CONSTRAINT [PK_Registro_Acceso_Menus] PRIMARY KEY CLUSTERED 
(
	[ID_Permiso_Menu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Contramedidas_OT]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Contramedidas_OT](
	[ID_Registro] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Contramedida] [int] NULL,
	[FK_ID_RegistroOT] [int] NULL,
	[FK_Usuario_Atendio] [int] NULL,
	[Fecha_Registro] [datetime2](7) NULL,
	[Fecha_Inicio] [datetime2](7) NULL,
	[Fecha_Termino] [datetime2](7) NULL,
	[Comentarios] [nvarchar](500) NULL,
	[Fecha_Aprobo] [datetime2](7) NULL,
	[FK_ID_Usuario_Aprobo] [int] NULL,
	[Afecto_Produccion] [nchar](10) NULL,
	[FK_ID_Aprobo_Calidad] [int] NULL,
	[Fecha_Aprobo_Calidad] [datetime2](7) NULL,
	[Afecto_Calidad] [nchar](10) NULL,
 CONSTRAINT [PK_Registro_Contramedidas_OT] PRIMARY KEY CLUSTERED 
(
	[ID_Registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Cordones_Contramedidas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Cordones_Contramedidas](
	[ID_Registro_Cordon] [int] IDENTITY(1,1) NOT NULL,
	[Cordones] [nvarchar](700) NULL,
	[FK_ID_Contramedida] [int] NULL,
 CONSTRAINT [PK_Registro_Cordones_Contramedidas] PRIMARY KEY CLUSTERED 
(
	[ID_Registro_Cordon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_OrdenesTrabajo]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_OrdenesTrabajo](
	[ID_Solicitud] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_UsuarioSolicito] [int] NULL,
	[FK_ID_TipoImpacto] [int] NULL,
	[FK_ID_Tipo_Falla] [int] NULL,
	[FK_ID_Estatus_Solicitud] [int] NULL,
	[FK_ID_Celda] [int] NULL,
	[Fecha_Registro] [datetime] NULL,
	[Comentarios] [nvarchar](400) NULL,
	[Fecha_Inicio_Falla] [datetime2](7) NULL,
	[Robot_Zona] [nchar](10) NULL,
 CONSTRAINT [PK_Registro_OrdenesTrabajo] PRIMARY KEY CLUSTERED 
(
	[ID_Solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Permisos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Permisos](
	[ID_Registro_Permisos] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Permiso] [int] NULL,
	[FK_ID_Usuario] [int] NULL,
	[FK_ID_EstatusPermiso] [int] NULL,
 CONSTRAINT [PK_Registro_Permisos] PRIMARY KEY CLUSTERED 
(
	[ID_Registro_Permisos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Sensosres_Contramedidas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Sensosres_Contramedidas](
	[ID_Registro_Sensores] [int] IDENTITY(1,1) NOT NULL,
	[Registro_Direccion] [nchar](10) NULL,
	[FK_ID_RegistroContramedida] [int] NULL,
 CONSTRAINT [PK_Registro_Sensosres_Contramedidas] PRIMARY KEY CLUSTERED 
(
	[ID_Registro_Sensores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Tickets]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Tickets](
	[ID_Ticket] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Usr_AtiendeOrden] [int] NULL,
	[FK_ID_Estatus_Ticket] [int] NULL,
	[FK_ID_SolicitudOT] [int] NULL,
	[Fecha_Registro_Ticket] [datetime] NULL,
	[Fecha_Comenzo_Ticket] [datetime] NULL,
	[Fecha_Termino_Ticket] [datetime] NULL,
	[Comentarios] [nvarchar](400) NULL,
 CONSTRAINT [PK_Registro_Tickets] PRIMARY KEY CLUSTERED 
(
	[ID_Ticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registros_Acceso_Paginas]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registros_Acceso_Paginas](
	[ID_Permiso_Pagina] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Usuario] [int] NULL,
	[FK_ID_Pagina] [int] NULL,
	[FK_ID_TipoAcceso] [int] NULL,
 CONSTRAINT [PK_Registros_Acceso_Paginas] PRIMARY KEY CLUSTERED 
(
	[ID_Permiso_Pagina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registros_Scrap]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registros_Scrap](
	[ID_Registro_Scrap] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad_Piezas_NG] [int] NULL,
	[Fecha_Captura] [datetime] NULL,
	[Fecha_Registro] [datetime] NULL,
	[FK_ID_CodigoScrap] [int] NULL,
	[Lado] [nchar](2) NULL,
	[Comentarios] [nvarchar](100) NULL,
	[FK_ID_Usuario] [nchar](10) NULL,
 CONSTRAINT [PK__Registro__5A9358CD1850B5D1] PRIMARY KEY CLUSTERED 
(
	[ID_Registro_Scrap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrosETE]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrosETE](
	[ID_Registro] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Usuario] [int] NULL,
	[FK_ID_TipoParo] [int] NULL,
	[FK_ID_Celda] [int] NULL,
	[FK_ID_Tecnico] [int] NULL,
	[Fecha_Inicio_Paro] [datetime] NULL,
	[Fecha_Fin_Paro] [datetime] NULL,
	[Folio] [varchar](10) NULL,
	[Fecha_Registro] [datetime] NULL,
	[Comentario] [nvarchar](200) NULL,
 CONSTRAINT [PK__Registro__E331D300BDEE4125] PRIMARY KEY CLUSTERED 
(
	[ID_Registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Robots]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Robots](
	[ID_Robot] [int] IDENTITY(1,1) NOT NULL,
	[Robot] [nvarchar](12) NULL,
 CONSTRAINT [PK_Robots] PRIMARY KEY CLUSTERED 
(
	[ID_Robot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sensores]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensores](
	[ID_Sensor] [int] IDENTITY(1,1) NOT NULL,
	[Direccion1] [int] NULL,
	[Direccion2] [int] NULL,
	[Direccion3] [int] NULL,
 CONSTRAINT [PK_Sensores] PRIMARY KEY CLUSTERED 
(
	[ID_Sensor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubMenus]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubMenus](
	[ID_SubMenu] [int] IDENTITY(1,1) NOT NULL,
	[FK_ID_Menu] [int] NULL,
	[Codigo_SubMenu] [nchar](10) NULL,
	[Descripcion_SubMenu] [nchar](10) NULL,
 CONSTRAINT [PK_SubMenus] PRIMARY KEY CLUSTERED 
(
	[ID_SubMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tecnicos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tecnicos](
	[ID_Tecnico] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Tecnico] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Tecnico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Accesos]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Accesos](
	[ID_Acceso] [int] IDENTITY(1,1) NOT NULL,
	[Acceso] [nchar](10) NULL,
 CONSTRAINT [PK_Accesos_1] PRIMARY KEY CLUSTERED 
(
	[ID_Acceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_De_Paros]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_De_Paros](
	[ID_TipoParo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_De_Paro] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tipos_De_Paros] PRIMARY KEY CLUSTERED 
(
	[ID_TipoParo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 2022-10-17 09:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](30) NULL,
	[Nombre_Usuario] [nvarchar](80) NULL,
	[FK_ID_Nivel_Rango] [int] NULL,
	[FK_ID_Estatus] [int] NULL,
	[FK_ID_Departamento] [int] NULL,
	[FK_ID_Puesto] [int] NULL,
	[Nomina] [int] NULL,
	[Password] [int] NULL,
 CONSTRAINT [PK__Usuarios__63C76BE2D8DB73D0] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Celdas]  WITH CHECK ADD  CONSTRAINT [FK__Celdas__Id_Linea__3F466844] FOREIGN KEY([FK_ID_Linea])
REFERENCES [dbo].[Lineas] ([ID_Linea])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Celdas] CHECK CONSTRAINT [FK__Celdas__Id_Linea__3F466844]
GO
ALTER TABLE [dbo].[RegistrosETE]  WITH CHECK ADD  CONSTRAINT [FK__Registros__Id_Ce__45F365D3] FOREIGN KEY([FK_ID_Celda])
REFERENCES [dbo].[Celdas] ([ID_Celda])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegistrosETE] CHECK CONSTRAINT [FK__Registros__Id_Ce__45F365D3]
GO
ALTER TABLE [dbo].[RegistrosETE]  WITH CHECK ADD  CONSTRAINT [FK__Registros__Id_Pa__44FF419A] FOREIGN KEY([FK_ID_TipoParo])
REFERENCES [dbo].[Codigos_Paro] ([ID_Codigo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegistrosETE] CHECK CONSTRAINT [FK__Registros__Id_Pa__44FF419A]
GO
ALTER TABLE [dbo].[RegistrosETE]  WITH CHECK ADD  CONSTRAINT [FK__Registros__Id_Te__46E78A0C] FOREIGN KEY([FK_ID_Tecnico])
REFERENCES [dbo].[Tecnicos] ([ID_Tecnico])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegistrosETE] CHECK CONSTRAINT [FK__Registros__Id_Te__46E78A0C]
GO
ALTER TABLE [dbo].[RegistrosETE]  WITH CHECK ADD  CONSTRAINT [FK__Registros__Id_Us__440B1D61] FOREIGN KEY([FK_ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegistrosETE] CHECK CONSTRAINT [FK__Registros__Id_Us__440B1D61]
GO
