USE [master]
GO
/****** Object:  Database [ProjectWork]    Script Date: 4/15/2017 11:43:12 PM ******/
CREATE DATABASE [ProjectWork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectWork', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjectWork.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectWork_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjectWork_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectWork] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectWork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectWork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectWork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectWork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectWork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectWork] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectWork] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProjectWork] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectWork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectWork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectWork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectWork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectWork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectWork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectWork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectWork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectWork] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProjectWork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectWork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectWork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectWork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectWork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectWork] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProjectWork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectWork] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectWork] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectWork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectWork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectWork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectWork] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProjectWork]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/15/2017 11:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/15/2017 11:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 4/15/2017 11:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[HashedPassword] [nvarchar](200) NOT NULL,
	[Salt] [nvarchar](200) NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 4/15/2017 11:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_RoleId]    Script Date: 4/15/2017 11:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/15/2017 11:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserRole]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId]
GO
USE [master]
GO
ALTER DATABASE [ProjectWork] SET  READ_WRITE 
GO
