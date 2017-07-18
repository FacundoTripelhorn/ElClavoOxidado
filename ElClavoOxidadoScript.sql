USE [master]
/****** Object:  Database [ElClavoOxidado]    Script Date: 18/6/2017 4:17:13 p. m. ******/
CREATE DATABASE [ElClavoOxidado] 
GO
USE [ElClavoOxidado]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 18/6/2017 4:17:13 p. m. ******/
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

CREATE TABLE [dbo].[Bitacora](
	[Id] [int] NOT NULL,
	[Usuario] [nvarchar](16) NULL,
	[Fecha] [datetime] NULL,
	[Tipo] [nvarchar](50) NULL,
	[Actividad] [nvarchar](500) NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (Usuario) REFERENCES Usuario(Id)
 )

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 18/6/2017 4:17:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Proveedores
(
ID integer not null,
Descripcion varchar (100) not null,
PRIMARY KEY (ID)
);

GO

CREATE TABLE Rubros
(
Codigo integer not null,
Descripcion varchar (100) not null,
PRIMARY KEY (Codigo)
);

GO

CREATE TABLE Productos
(
Codigo integer not null,
Codigo_Rubro integer not null,
ID_Proveedor integer not null,
Descripcion varchar (100) not null,
PPU decimal (9,2) not null,
Vigente_desde date,
Vigente_hasta date,
PRIMARY KEY (Codigo),
FOREIGN KEY (Codigo_Rubro) REFERENCES Rubros(Codigo),
FOREIGN KEY (ID_Proveedor) REFERENCES Proveedores(ID)
);

GO

INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Familia],[Bloqueado]) VALUES (N'FacuTripelhorn', N'facundo.tripelhorn@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1,0)
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Familia],[Bloqueado]) VALUES (N'Juanito', N'juanito@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 3,0)

GO
CREATE PROCEDURE ObtenerUser 
@Usuario nvarchar(50),
@Pass nvarchar(64)
AS
DECLARE @IsValid int
SET @IsValid = 0

IF (SELECT Password FROM Usuario WHERE Id = @Usuario) = @Pass
	BEGIN
		SET @IsValid = 1
	END
SELECT Id AS "Usuario", @IsValid AS "IsValid", Bloqueado, Familia
FROM Usuario 
WHERE Id = @Usuario

GO

CREATE PROCEDURE ActualizarMailUser
@Usuario nvarchar(16),
@Email nvarchar(50)
AS
UPDATE usuario SET Email = @Email
where id = @Usuario

GO

CREATE PROCEDURE BloquearUser
@Usuario nvarchar(16)
AS
UPDATE usuario SET Bloqueado = 1
where id = @Usuario

GO

CREATE PROCEDURE GetBitacora
AS
SELECT * FROM Bitacora

GO

CREATE PROCEDURE AltaBitacora
@Id int,
@Usuario nvarchar(50),
@Tipo nvarchar(50),
@Actividad nvarchar(500)
AS
INSERT INTO Bitacora VALUES (@Id, @Usuario, GETDATE(), @Tipo, @Actividad)

GO

create PROCEDURE AltaUsuario
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

CREATE PROCEDURE ChequearUsuario
@Usuario nvarchar(16)
AS
SELECT * FROM Usuario WHERE Id = @Usuario

GO

CREATE PROCEDURE CambiarContraseña
@Usuario nvarchar(16),
@Password nvarchar(64)
AS
UPDATE Usuario SET Password = @Password WHERE Id = @Usuario

GO

CREATE PROCEDURE AsignarRol
@Usuario nvarchar(16),
@Familia int
AS
UPDATE Usuario SET Familia = @Familia WHERE Id = @Usuario

GO

CREATE PROCEDURE CrearBackup
@Path nvarchar(2000),
@Nombre nvarchar(50)
AS
DECLARE @Fecha nvarchar(50)
SET @Fecha = CONVERT(nvarchar(20),GETDATE(),112)
SET @Path = @Path + @Nombre + '_' + @Fecha + '.bak'
BACKUP DATABASE ElClavoOxidado TO DISK = @Path

GO

CREATE PROCEDURE RestoreBase
@Archivo nvarchar(2000)
AS
RESTORE DATABASE ElClavoOxidado FROM DISK = @Archivo WITH REPLACE

GO

CREATE PROCEDURE GetUsuarios
AS
SELECT * FROM Usuario

GO

USE [master]
GO
ALTER DATABASE [ElClavoOxidado] SET  READ_WRITE 
GO
