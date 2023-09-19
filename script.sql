USE [master]
GO
/****** Object:  Database [Cadastro]    Script Date: 17/09/2023 19:41:29 ******/
CREATE DATABASE [Cadastro2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cadastro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cadastro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cadastro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cadastro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cadastro] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cadastro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cadastro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cadastro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cadastro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cadastro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cadastro] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cadastro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cadastro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cadastro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cadastro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cadastro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cadastro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cadastro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cadastro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cadastro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cadastro] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cadastro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cadastro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cadastro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cadastro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cadastro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cadastro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cadastro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cadastro] SET RECOVERY FULL 
GO
ALTER DATABASE [Cadastro] SET  MULTI_USER 
GO
ALTER DATABASE [Cadastro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cadastro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cadastro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cadastro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cadastro] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cadastro] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cadastro', N'ON'
GO
ALTER DATABASE [Cadastro] SET QUERY_STORE = ON
GO
ALTER DATABASE [Cadastro] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Cadastro]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdGuid] [uniqueidentifier] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [Pk_Id] PRIMARY KEY NONCLUSTERED 
(
	[IdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [CIX_Cliente]    Script Date: 17/09/2023 19:41:29 ******/
CREATE UNIQUE CLUSTERED INDEX [CIX_Cliente] ON [dbo].[Cliente]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[IdGuid] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logradouro]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logradouro](
	[IdGuid] [uniqueidentifier] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LogradouroNome] [varchar](50) NOT NULL,
	[IdCliente] [uniqueidentifier] NULL,
 CONSTRAINT [Pk_Id_Logradouro] PRIMARY KEY NONCLUSTERED 
(
	[IdGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [CIX_Logradouro]    Script Date: 17/09/2023 19:41:29 ******/
CREATE UNIQUE CLUSTERED INDEX [CIX_Logradouro] ON [dbo].[Logradouro]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (newid()) FOR [IdGuid]
GO
ALTER TABLE [dbo].[Logradouro] ADD  DEFAULT (newid()) FOR [IdGuid]
GO
ALTER TABLE [dbo].[Logradouro]  WITH CHECK ADD  CONSTRAINT [FK_ClienteLogradouro] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdGuid])
GO
ALTER TABLE [dbo].[Logradouro] CHECK CONSTRAINT [FK_ClienteLogradouro]
GO
/****** Object:  StoredProcedure [dbo].[CreateCliente]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateCliente] @Nome nvarchar(50) = NULL, @Email nvarchar(50) = NULL, @IdGuid UNIQUEIDENTIFIER
AS
INSERT INTO [dbo].[Cliente]
           ([IdGuid]
           ,[Nome]
           ,[Email])
     VALUES
           (@IdGuid
           ,@Nome
           ,@Email)
GO
/****** Object:  StoredProcedure [dbo].[CreateLogradouro]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateLogradouro] @IdGuid UNIQUEIDENTIFIER, @LogradouroNome VARCHAR(50), @IdCliente UNIQUEIDENTIFIER
AS
INSERT INTO [dbo].[Logradouro]
           ([IdGuid]
           ,[LogradouroNome]
           ,[IdCliente])
     VALUES
           (@IdGuid
           ,@LogradouroNome
           ,@IdCliente)
GO
/****** Object:  StoredProcedure [dbo].[DeleteCliente]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCliente] @IdGuid UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[Cliente]
      WHERE IdGuid = @IdGuid
GO
/****** Object:  StoredProcedure [dbo].[DeleteLogradouro]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteLogradouro] @IdGuid UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[Logradouro]
      WHERE [IdGuid] = @IdGuid
GO
/****** Object:  StoredProcedure [dbo].[UpdateCliente]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCliente] @Nome nvarchar(50) = NULL, @Email nvarchar(50) = NULL, @IdGuid UNIQUEIDENTIFIER
AS
UPDATE [dbo].[Cliente]
   SET [Nome] = @Nome
      ,[Email] = @Email
 WHERE [IdGuid] = @IdGuid
GO
/****** Object:  StoredProcedure [dbo].[UpdateLogradouro]    Script Date: 17/09/2023 19:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateLogradouro] @IdGuid UNIQUEIDENTIFIER, @LogradouroNome VARCHAR(50), @IdCliente UNIQUEIDENTIFIER
AS
UPDATE [dbo].[Logradouro]
   SET [IdGuid] = @IdGuid
      ,[LogradouroNome] = @LogradouroNome
      ,[IdCliente] = @IdCliente
 WHERE [IdGuid] = @IdGuid
GO
USE [master]
GO
ALTER DATABASE [Cadastro] SET  READ_WRITE 
GO
