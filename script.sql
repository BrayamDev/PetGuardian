USE [PetGuardian]
GO
/****** Object:  Table [dbo].[adoptantes]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adoptantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreAdoptante] [varchar](80) NULL,
	[numeroDocumento] [int] NOT NULL,
	[numeroContacto] [int] NOT NULL,
	[numeroEmergencia] [int] NOT NULL,
	[foto] [nvarchar](max) NULL,
	[direccionResidencia] [varchar](100) NULL,
 CONSTRAINT [PK_adoptantes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[animales]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[animales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreAnimal] [nvarchar](max) NOT NULL,
	[imagen] [nvarchar](max) NOT NULL,
	[urlDocumentos] [nvarchar](max) NULL,
	[tipoAnimalId] [int] NULL,
	[vacunasId] [int] NULL,
	[fechaIngreso] [datetime2](7) NOT NULL,
	[estadoSalud] [nvarchar](max) NOT NULL,
	[observaciones] [nvarchar](max) NOT NULL,
	[procedencia] [nvarchar](max) NOT NULL,
	[estado] [bit] NOT NULL,
	[edad] [int] NOT NULL,
	[fundacionId] [int] NOT NULL,
	[adoptanteId] [int] NOT NULL,
	[raza] [varchar](200) NOT NULL,
	[sexo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_animales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fundaciones]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fundaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreFundacion] [varchar](200) NULL,
	[estado] [bit] NOT NULL,
	[nit] [varchar](50) NULL,
	[descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_fundaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[nombreRol] [varchar](250) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoAnimal]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoAnimal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreTipoAnimal] [varchar](50) NULL,
	[descripcion] [varchar](500) NULL,
 CONSTRAINT [PK_TipoAnimal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuarios] [int] NOT NULL,
	[nombreCompleto] [varchar](150) NULL,
	[correoElectronico] [varchar](250) NULL,
	[usuarioRed] [varchar](30) NULL,
	[fotoPerfil] [varchar](500) NULL,
	[contrasena] [varchar](150) NULL,
	[rol_id] [int] NULL,
 CONSTRAINT [PK__Usuarios__3940559A1452386B] PRIMARY KEY CLUSTERED 
(
	[idUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacunas]    Script Date: 10/05/2024 0:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacunas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreVacuna] [varchar](80) NULL,
	[fechaCaducidad] [date] NULL,
 CONSTRAINT [PK_vacunas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[animales]  WITH CHECK ADD  CONSTRAINT [FK_animales_adoptantes] FOREIGN KEY([adoptanteId])
REFERENCES [dbo].[adoptantes] ([id])
GO
ALTER TABLE [dbo].[animales] CHECK CONSTRAINT [FK_animales_adoptantes]
GO
ALTER TABLE [dbo].[animales]  WITH CHECK ADD  CONSTRAINT [FK_animales_fundaciones] FOREIGN KEY([fundacionId])
REFERENCES [dbo].[fundaciones] ([id])
GO
ALTER TABLE [dbo].[animales] CHECK CONSTRAINT [FK_animales_fundaciones]
GO
ALTER TABLE [dbo].[animales]  WITH CHECK ADD  CONSTRAINT [FK_animales_TipoAnimal] FOREIGN KEY([tipoAnimalId])
REFERENCES [dbo].[tipoAnimal] ([id])
GO
ALTER TABLE [dbo].[animales] CHECK CONSTRAINT [FK_animales_TipoAnimal]
GO
ALTER TABLE [dbo].[animales]  WITH CHECK ADD  CONSTRAINT [FK_animales_vacunas] FOREIGN KEY([vacunasId])
REFERENCES [dbo].[vacunas] ([id])
GO
ALTER TABLE [dbo].[animales] CHECK CONSTRAINT [FK_animales_vacunas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Rol] FOREIGN KEY([rol_id])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Rol]
GO
