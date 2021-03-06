USE [master]
GO
/****** Object:  Database [ElClavoOxidado]    Script Date: 19/7/2017 9:02:22 p. m. ******/
CREATE DATABASE [ElClavoOxidado]
GO
USE [ElClavoOxidado]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 19/7/2017 9:02:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] NOT NULL,
	[Usuario] [nvarchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Tipo] [nvarchar](50) NULL,
	[Actividad] [nvarchar](500) NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](20) NULL,
	[DVH] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[Codigo] [int] NOT NULL,
	[Categoria] [int] NOT NULL,
	[Proveedor] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Precio] [decimal](9, 2) NOT NULL,
	[DVH] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[ID] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[DVH] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [nvarchar](16) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](64) NULL,
	[Familia] [int] NULL,
	[Bloqueado] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Categoria] ([Id], [Nombre], [DVH]) VALUES (1, N'Máquinas', N'¡LÕ“‹… ãÕ}UÃæ;¡.<zIÕ¬qåçèªV)Ð1')
INSERT [dbo].[Categoria] ([Id], [Nombre], [DVH]) VALUES (2, N'Carpinteria', N',¹ámŽ¦šqZz°â]¬|5ÿC€1¥³R±…žÎë‚')
INSERT [dbo].[Categoria] ([Id], [Nombre], [DVH]) VALUES (3, N'Construcción', N'{Aå°ô5Ó8'';Fo0
7áÇ81lu=Ëðé?–ì')
INSERT [dbo].[Categoria] ([Id], [Nombre], [DVH]) VALUES (4, N'Electricidad', N'ÝZ%áÆ²MÕ$WvÃÇåàŸÔîE7À°:´ä‚âi}')
INSERT [dbo].[Categoria] ([Id], [Nombre], [DVH]) VALUES (5, N'Hogar', N'U-Ú!1òG#\SnnßñîÌÈÌ°Ù—d–ð’RœÏA')
INSERT [dbo].[Producto] ([Codigo], [Categoria], [Proveedor], [Descripcion], [Precio], [DVH]) VALUES (1, 1, 1, N'Rotopercutora', CAST(10000.00 AS Decimal(9, 2)), N'Šˆw´ñ‰GO²»¼}Žp)é<Ò0T''ySç\BÔÛ')
INSERT [dbo].[Proveedor] ([ID], [Nombre], [DVH]) VALUES (1, N'DeWalt', N'¯?´¨Ývg»`1Û•ª¬y%Òjß¯d_·ƒ§*à')
INSERT [dbo].[Proveedor] ([ID], [Nombre], [DVH]) VALUES (2, N'Black&Decker', N'·%–ÆVgÚ=;Ã(êÿæ|d!9l¤ßÑoÊ')
INSERT [dbo].[Proveedor] ([ID], [Nombre], [DVH]) VALUES (3, N'Bosch', N'êmü¯™çY¤²=›Iªæf—sfètZÌûâ;p')
INSERT [dbo].[Proveedor] ([ID], [Nombre], [DVH]) VALUES (4, N'Karcher', N'š"EÐš$j#î³âqz|^Lÿ»œ7«ohw,')
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Familia], [Bloqueado]) VALUES (N'123456', N'123456', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 3, 0)
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Familia], [Bloqueado]) VALUES (N'Facu123', N'facu418@gmail.com', N'4dcb736f06d0062c8f12f3664d073b55c915ffa449ca0a4d8b8721a899947e7c', 2, 0)
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Familia], [Bloqueado]) VALUES (N'FacuTripelhorn', N'facundo.tripelhorn@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1, 0)
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Familia], [Bloqueado]) VALUES (N'Juanito', N'juanito@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 2, 0)
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([Proveedor])
REFERENCES [dbo].[Proveedor] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarMailUser]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarMailUser]
@Usuario nvarchar(16),
@Email nvarchar(50)
AS
UPDATE usuario SET Email = @Email
where id = @Usuario


GO
/****** Object:  StoredProcedure [dbo].[AltaBitacora]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AltaBitacora]
@Id int,
@Usuario nvarchar(50),
@Tipo nvarchar(50),
@Actividad nvarchar(500)
AS
INSERT INTO Bitacora VALUES (@Id, @Usuario, GETDATE(), @Tipo, @Actividad)
GO
/****** Object:  StoredProcedure [dbo].[AltaCategoria]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AltaCategoria]
@Id int,
@Nombre nvarchar(100)
AS
DECLARE @DV varchar(32) = HASHBYTES('SHA2_256', CONVERT(varchar(5),@Id) + @Nombre)
INSERT INTO Categoria VALUES(@Id, @Nombre, @DV)
GO
/****** Object:  StoredProcedure [dbo].[AltaProducto]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AltaProducto]
@Codigo int,
@Categoria int,
@Proveedor int,
@Descripcion nvarchar(100),
@Precio decimal(9,2)
AS
DECLARE @DVH varchar(32)
SET @DVH = HASHBYTES('SHA2_256', CONVERT(nvarchar(5), @Codigo) + CONVERT(nvarchar(5), @Categoria) + CONVERT(nvarchar(5), @Proveedor) + @Descripcion + CONVERT(nvarchar(10),@Precio))
INSERT INTO Producto VALUES(@Codigo, @Categoria, @Proveedor, @Descripcion, @Precio, @DVH)
GO
/****** Object:  StoredProcedure [dbo].[AltaProveedor]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AltaProveedor]
@Id int,
@Nombre nvarchar(100)
AS
DECLARE @DV varchar(32) = HASHBYTES('SHA2_256', CONVERT(nvarchar(5),@Id) + @Nombre)
INSERT INTO Proveedor VALUES(@Id, @Nombre, @DV)
GO
/****** Object:  StoredProcedure [dbo].[AltaUsuario]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AltaUsuario]
@Usuario nvarchar(16),
@Email nvarchar(50),
@Password nvarchar(64),
@Familia int
AS
IF (NOT EXISTS (SELECT Id FROM Usuario WHERE Id = @Usuario))
BEGIN
INSERT INTO Usuario VALUES (@Usuario, @Email, @Password, @Familia, 0)
END
GO
/****** Object:  StoredProcedure [dbo].[AsignarRol]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsignarRol]
@Usuario nvarchar(16),
@Familia int
AS
UPDATE Usuario SET Familia = @Familia WHERE Id = @Usuario
GO
/****** Object:  StoredProcedure [dbo].[BloquearUser]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BloquearUser]
@Usuario nvarchar(16)
AS
UPDATE usuario SET Bloqueado = 1
where id = @Usuario


GO
/****** Object:  StoredProcedure [dbo].[CambiarContraseña]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarContraseña]
@Usuario nvarchar(16),
@Password nvarchar(64)
AS
UPDATE Usuario SET Password = @Password WHERE Id = @Usuario
GO
/****** Object:  StoredProcedure [dbo].[CheckCategoria]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckCategoria]
@Id int,
@Nombre nvarchar(100)
AS
DECLARE @DV varchar(32) = HASHBYTES('SHA2_256', CONVERT(varchar(5),@Id) + @Nombre)
SELECT * FROM Categoria WHERE DVH = @DV
GO
/****** Object:  StoredProcedure [dbo].[CheckProducto]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckProducto]
@Codigo int,
@Categoria int,
@Proveedor int,
@Descripcion nvarchar(100),
@Precio decimal(9,2)
AS
DECLARE @DVH varchar(32)
SET @DVH = HASHBYTES('SHA2_256', CONVERT(nvarchar(5), @Codigo) + CONVERT(nvarchar(5), @Categoria) + CONVERT(nvarchar(5), @Proveedor) + @Descripcion + CONVERT(nvarchar(10),@Precio))
SELECT * 
FROM Producto 
WHERE DVH = @DVH
GO
/****** Object:  StoredProcedure [dbo].[CheckProveedor]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckProveedor]
@Id int,
@Nombre nvarchar(100)
AS
DECLARE @DV varchar(32) = HASHBYTES('SHA2_256', CONVERT(varchar(5),@Id) + @Nombre)
SELECT * FROM Proveedor WHERE DVH = @DV
GO
/****** Object:  StoredProcedure [dbo].[ChequearUsuario]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChequearUsuario]
@Usuario nvarchar(16)
AS
SELECT * FROM Usuario WHERE Id = @Usuario

GO
/****** Object:  StoredProcedure [dbo].[CrearBackup]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearBackup]
@Path nvarchar(2000),
@Nombre nvarchar(50)
AS
DECLARE @Fecha nvarchar(50)
SET @Path = @Path + @Nombre + '.bak'
BACKUP DATABASE ElClavoOxidado TO DISK = @Path


GO
/****** Object:  StoredProcedure [dbo].[GetBitacora]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBitacora]
AS
SELECT * FROM Bitacora


GO
/****** Object:  StoredProcedure [dbo].[GetCategoria]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoria]
@Id int
AS
SELECT * FROM Categoria WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetCategorias]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategorias]
AS
SELECT * FROM Categoria
GO
/****** Object:  StoredProcedure [dbo].[GetProducto]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducto]
@Codigo int
AS
SELECT * FROM Producto WHERE Codigo = @Codigo
GO
/****** Object:  StoredProcedure [dbo].[GetProductos]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductos]
AS
SELECT * FROM Producto

GO
/****** Object:  StoredProcedure [dbo].[GetProveedor]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProveedor]
@Id int
AS
SELECT * FROM Proveedor WHERE Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[GetProveedores]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProveedores]
AS
SELECT * FROM Proveedor

GO
/****** Object:  StoredProcedure [dbo].[GetUsuarios]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsuarios]
AS
SELECT * FROM Usuario
GO
/****** Object:  StoredProcedure [dbo].[KillProcess]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KillProcess]
@dbName SYSNAME  
AS  
BEGIN  
SET NOCOUNT ON  
 
DECLARE @spid INT,  
@activas INT,  
@query VARCHAR(255)  
 
SELECT @spid = MIN(spid), @activas = COUNT(*)  
FROM master..sysprocesses  
WHERE dbid = DB_ID(@dbname)  
AND spid != @@SPID  
  
WHILE @spid IS NOT NULL  
BEGIN  
    SET @query = 'KILL '+RTRIM(@spid)  
    EXEC(@query)
    SELECT @spid = MIN(spid), @activas = COUNT(*)  
    FROM master..sysprocesses  
    WHERE dbid = DB_ID(@dbname) AND spid != @@SPID
END
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUser]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUser] 
@Usuario nvarchar(50),
@Pass nvarchar(64)
AS
DECLARE @IsValid int
SET @IsValid = 0

IF (Select Password FROM usuario where usuario.id = @Usuario) = @Pass
	BEGIN
		SET @IsValid = 1
	END

Select Usuario.id as "Usuario", @IsValid as "IsValid", Bloqueado, Familia
FROM usuario 
where Usuario.id = @Usuario

GO
/****** Object:  StoredProcedure [dbo].[RestoreBase]    Script Date: 19/7/2017 9:02:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RestoreBase]
@Archivo nvarchar(2000)
AS
RESTORE DATABASE ElClavoOxidado FROM DISK = @Archivo WITH REPLACE


GO
USE [master]
GO
ALTER DATABASE [ElClavoOxidado] SET  READ_WRITE 
GO
