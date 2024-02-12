
CREATE DATABASE [gestion_gimnasio]
GO
USE [gestion_gimnasio]
GO

CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nchar](10) NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](10) NOT NULL,
	[email] [varchar](50) NULL,
	[foto] [image] NULL,
	[altura] [decimal](5, 2) NULL,
	[peso] [decimal](5, 2) NULL,
	[estado] [bit] NOT NULL,
	[id_membresia] [int] NULL,
	[id_tipo_cliente] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Costo_Membresia]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Costo_Membresia](
	[id_costo_membresia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[valor] [money] NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Promociones_membresias] PRIMARY KEY CLUSTERED 
(
	[id_costo_membresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membresias]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresias](
	[id_membresia] [int] IDENTITY(1,1) NOT NULL,
	[fecha_registro] [date] NULL,
	[descripcion] [varchar](100) NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[estado] [bit] NOT NULL,
	[id_tipo_membresia] [int] NULL,
	[id_costo_membresia] [int] NULL,
	[id_promocion] [int] NULL,
 CONSTRAINT [PK_Membresias] PRIMARY KEY CLUSTERED 
(
	[id_membresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago_diario]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago_diario](
	[id_pago_diario] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[monto] [money] NOT NULL,
	[estado] [bit] NOT NULL,
	[id_registro] [int] NULL,
 CONSTRAINT [PK_Pago_diario] PRIMARY KEY CLUSTERED 
(
	[id_pago_diario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[id_promocion] [int] IDENTITY(1,1) NOT NULL,
	[fecha_registro] [date] NULL,
	[descripcion] [nchar](50) NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[id_promocion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Asistencia]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Asistencia](
	[id_registro] [int] IDENTITY(0,1) NOT NULL,
	[fecha] [date] NULL,
	[estado] [bit] NOT NULL,
	[id_cliente] [int] NULL,
 CONSTRAINT [PK_Registro_Asistencia] PRIMARY KEY CLUSTERED 
(
	[id_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Cliente]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Cliente](
	[id_tipo_cliente] [int] IDENTITY(0,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_tipo_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Membresia]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Membresia](
	[id_tipo_membresia] [int] IDENTITY(0,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_Membresia] PRIMARY KEY CLUSTERED 
(
	[id_tipo_membresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/1/2024 11:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[nombre_usuario] [varchar](30) NOT NULL,
	[contraseña] [varchar](30) NOT NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Membresias] FOREIGN KEY([id_membresia])
REFERENCES [dbo].[Membresias] ([id_membresia])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Membresias]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Tipo_Cliente] FOREIGN KEY([id_tipo_cliente])
REFERENCES [dbo].[Tipo_Cliente] ([id_tipo_cliente])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Tipo_Cliente]
GO
ALTER TABLE [dbo].[Membresias]  WITH CHECK ADD  CONSTRAINT [FK_Membresias_Costo_Membresia] FOREIGN KEY([id_costo_membresia])
REFERENCES [dbo].[Costo_Membresia] ([id_costo_membresia])
GO
ALTER TABLE [dbo].[Membresias] CHECK CONSTRAINT [FK_Membresias_Costo_Membresia]
GO
ALTER TABLE [dbo].[Membresias]  WITH CHECK ADD  CONSTRAINT [FK_Membresias_Promociones] FOREIGN KEY([id_promocion])
REFERENCES [dbo].[Promociones] ([id_promocion])
GO
ALTER TABLE [dbo].[Membresias] CHECK CONSTRAINT [FK_Membresias_Promociones]
GO
ALTER TABLE [dbo].[Membresias]  WITH CHECK ADD  CONSTRAINT [FK_Membresias_Tipo_Membresia] FOREIGN KEY([id_tipo_membresia])
REFERENCES [dbo].[Tipo_Membresia] ([id_tipo_membresia])
GO
ALTER TABLE [dbo].[Membresias] CHECK CONSTRAINT [FK_Membresias_Tipo_Membresia]
GO
ALTER TABLE [dbo].[Pago_diario]  WITH CHECK ADD  CONSTRAINT [FK_Pago_diario_Registro_Asistencia] FOREIGN KEY([id_registro])
REFERENCES [dbo].[Registro_Asistencia] ([id_registro])
GO
ALTER TABLE [dbo].[Pago_diario] CHECK CONSTRAINT [FK_Pago_diario_Registro_Asistencia]
GO
ALTER TABLE [dbo].[Registro_Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Asistencia_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Registro_Asistencia] CHECK CONSTRAINT [FK_Registro_Asistencia_Cliente]
GO
USE [master]
GO
ALTER DATABASE [gestion_membresias] SET  READ_WRITE 
GO
