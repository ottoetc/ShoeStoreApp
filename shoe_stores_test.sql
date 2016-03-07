USE [master]
GO
/****** Object:  Database [shoe_stores_test]    Script Date: 3/7/2016 10:17:16 AM ******/
CREATE DATABASE [shoe_stores_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'shoe_stores', FILENAME = N'C:\Users\ottoe\shoe_stores_test.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'shoe_stores_log', FILENAME = N'C:\Users\ottoe\shoe_stores_test_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [shoe_stores_test] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [shoe_stores_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [shoe_stores_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [shoe_stores_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [shoe_stores_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [shoe_stores_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [shoe_stores_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [shoe_stores_test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [shoe_stores_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [shoe_stores_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [shoe_stores_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [shoe_stores_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [shoe_stores_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [shoe_stores_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [shoe_stores_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [shoe_stores_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [shoe_stores_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [shoe_stores_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [shoe_stores_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [shoe_stores_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [shoe_stores_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [shoe_stores_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [shoe_stores_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [shoe_stores_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [shoe_stores_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [shoe_stores_test] SET  MULTI_USER 
GO
ALTER DATABASE [shoe_stores_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [shoe_stores_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [shoe_stores_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [shoe_stores_test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [shoe_stores_test] SET DELAYED_DURABILITY = DISABLED 
GO
USE [shoe_stores_test]
GO
/****** Object:  Table [dbo].[brands]    Script Date: 3/7/2016 10:17:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stores]    Script Date: 3/7/2016 10:17:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stores_brands]    Script Date: 3/7/2016 10:17:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores_brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[store_id] [int] NULL,
	[brand_id] [int] NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [shoe_stores_test] SET  READ_WRITE 
GO
