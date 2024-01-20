USE [gestion_membresias]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 14/1/2024 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[foto] [varchar](100) NULL,
	[altura] [decimal](5, 2) NULL,
	[peso] [decimal](5, 2) NULL,
	[estado] [bit] NOT NULL,
	[id_promocion_membresia] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membresias]    Script Date: 14/1/2024 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresias](
	[id_membresia] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[costo] [money] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[estado] [bit] NOT NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_Membresias] PRIMARY KEY CLUSTERED 
(
	[id_membresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago_diario]    Script Date: 14/1/2024 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago_diario](
	[id_pago_diario] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[monto] [money] NOT NULL,
	[estado] [bit] NOT NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_Pago_diario] PRIMARY KEY CLUSTERED 
(
	[id_pago_diario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 14/1/2024 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[id_promocion] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[descripcion] [nchar](50) NULL,
	[costo] [money] NOT NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[estado] [bit] NOT NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[id_promocion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones_membresias]    Script Date: 14/1/2024 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones_membresias](
	[id_promocion_membresia] [int] IDENTITY(1,1) NOT NULL,
	[id_promocion] [int] NULL,
	[id_membresia] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_Promociones_membresias] PRIMARY KEY CLUSTERED 
(
	[id_promocion_membresia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/1/2024 11:12:10 ******/
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
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Promociones_membresias] FOREIGN KEY([id_promocion_membresia])
REFERENCES [dbo].[Promociones_membresias] ([id_promocion_membresia])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Promociones_membresias]
GO
ALTER TABLE [dbo].[Membresias]  WITH CHECK ADD  CONSTRAINT [FK_Membresias_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Membresias] CHECK CONSTRAINT [FK_Membresias_Usuario]
GO
ALTER TABLE [dbo].[Pago_diario]  WITH CHECK ADD  CONSTRAINT [FK_Pago_diario_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Pago_diario] CHECK CONSTRAINT [FK_Pago_diario_Usuario]
GO
ALTER TABLE [dbo].[Promociones]  WITH CHECK ADD  CONSTRAINT [FK_Promociones_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Promociones] CHECK CONSTRAINT [FK_Promociones_Usuario]
GO
ALTER TABLE [dbo].[Promociones_membresias]  WITH CHECK ADD  CONSTRAINT [FK_Promociones_membresias_Membresias] FOREIGN KEY([id_membresia])
REFERENCES [dbo].[Membresias] ([id_membresia])
GO
ALTER TABLE [dbo].[Promociones_membresias] CHECK CONSTRAINT [FK_Promociones_membresias_Membresias]
GO
ALTER TABLE [dbo].[Promociones_membresias]  WITH CHECK ADD  CONSTRAINT [FK_Promociones_membresias_Promociones] FOREIGN KEY([id_promocion])
REFERENCES [dbo].[Promociones] ([id_promocion])
GO
ALTER TABLE [dbo].[Promociones_membresias] CHECK CONSTRAINT [FK_Promociones_membresias_Promociones]
GO
