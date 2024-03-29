USE [master]
GO
/****** Object:  Database [HousingManagementDb]    Script Date: 10-Jan-19 02:15:53 PM ******/
CREATE DATABASE [HousingManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HousingManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\HousingManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HousingManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\HousingManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HousingManagementDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HousingManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HousingManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HousingManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HousingManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HousingManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HousingManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [HousingManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HousingManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HousingManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HousingManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HousingManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HousingManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HousingManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HousingManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HousingManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HousingManagementDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HousingManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HousingManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HousingManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HousingManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HousingManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HousingManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HousingManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HousingManagementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [HousingManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [HousingManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HousingManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HousingManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HousingManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HousingManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HousingManagementDb', N'ON'
GO
ALTER DATABASE [HousingManagementDb] SET QUERY_STORE = OFF
GO
USE [HousingManagementDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [HousingManagementDb]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 10-Jan-19 02:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentAds]    Script Date: 10-Jan-19 02:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentAds](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Headline] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Rent] [nvarchar](max) NULL,
	[MainImage] [nvarchar](max) NULL,
	[BedroomNo] [int] NULL,
	[BathroomNo] [int] NULL,
	[OthersNo] [int] NULL,
	[NeighborhoodEast] [nvarchar](max) NULL,
	[NeighborhoodEastDistance] [nvarchar](max) NULL,
	[NeighborhoodWest] [nvarchar](max) NULL,
	[NeighborhoodWestDistance] [nvarchar](max) NULL,
	[NeighborhoodNorth] [nvarchar](max) NULL,
	[NeighborhoodNorthDistance] [nvarchar](max) NULL,
	[NeighborhoodSouth] [nvarchar](max) NULL,
	[NeighborhoodSouthDistance] [nvarchar](max) NULL,
	[AddedBy] [bigint] NULL,
	[OwnerName] [nvarchar](max) NULL,
	[OwnerContact] [nvarchar](max) NULL,
	[OwnerEmail] [nvarchar](max) NULL,
 CONSTRAINT [PK_RentAds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 10-Jan-19 02:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AddedBy] [bigint] NULL,
	[AddedName] [nvarchar](max) NULL,
	[AgainstId] [bigint] NULL,
	[ReportReason] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Report1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellAds]    Script Date: 10-Jan-19 02:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellAds](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Headline] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL,
	[MainImage] [nvarchar](max) NULL,
	[BedroomNo] [int] NULL,
	[BathroomNo] [int] NULL,
	[OthersNo] [int] NULL,
	[NeighborhoodEast] [nvarchar](max) NULL,
	[NeighborhoodEastDistance] [nvarchar](max) NULL,
	[NeighborhoodWest] [nvarchar](max) NULL,
	[NeighborhoodWestDistance] [nvarchar](max) NULL,
	[NeighborhoodNorth] [nvarchar](max) NULL,
	[NeighborhoodNorthDistance] [nvarchar](max) NULL,
	[NeighborhoodSouth] [nvarchar](max) NULL,
	[NeighborhoodSouthDistance] [nvarchar](max) NULL,
	[AddedBy] [bigint] NULL,
	[OwnerName] [nvarchar](max) NULL,
	[OwnerContact] [nvarchar](max) NULL,
	[OwnerEmail] [nvarchar](max) NULL,
 CONSTRAINT [PK_SellAds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10-Jan-19 02:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [FirstName], [LastName], [Image], [Contact], [Email], [Address], [Username], [Password]) VALUES (1, N'Mashuka', N'Meem', N'Meem.jpg', N'01621212121', N'mashuka.meem@gmail.com', N'Dhaka', N'Meem', N'meem1234')
INSERT [dbo].[Admins] ([Id], [FirstName], [LastName], [Image], [Contact], [Email], [Address], [Username], [Password]) VALUES (2, N'Me', N'Meem', N'Meem2.jpg', N'1322422', N'm@gmail.com', N'tongi', N'M', N'1209')
SET IDENTITY_INSERT [dbo].[Admins] OFF
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([Id], [AddedBy], [AddedName], [AgainstId], [ReportReason], [Comment]) VALUES (1, 1, N'meem', 3, N'assds', N'ssds')
SET IDENTITY_INSERT [dbo].[Report] OFF
SET IDENTITY_INSERT [dbo].[SellAds] ON 

INSERT [dbo].[SellAds] ([Id], [Headline], [Details], [Address], [Price], [MainImage], [BedroomNo], [BathroomNo], [OthersNo], [NeighborhoodEast], [NeighborhoodEastDistance], [NeighborhoodWest], [NeighborhoodWestDistance], [NeighborhoodNorth], [NeighborhoodNorthDistance], [NeighborhoodSouth], [NeighborhoodSouthDistance], [AddedBy], [OwnerName], [OwnerContact], [OwnerEmail]) VALUES (1, N'1', N'1', N'1', N'1', N'Main1.jpg', 0, 0, 0, N'1', N'1', N'1', N'1', N'11', N'1', N'1', N'1', 1, NULL, NULL, NULL)
INSERT [dbo].[SellAds] ([Id], [Headline], [Details], [Address], [Price], [MainImage], [BedroomNo], [BathroomNo], [OthersNo], [NeighborhoodEast], [NeighborhoodEastDistance], [NeighborhoodWest], [NeighborhoodWestDistance], [NeighborhoodNorth], [NeighborhoodNorthDistance], [NeighborhoodSouth], [NeighborhoodSouthDistance], [AddedBy], [OwnerName], [OwnerContact], [OwnerEmail]) VALUES (2, N'2', N'2', N'2', N'2', N'Main2.jpg', 2, 0, 0, N'2', N'2', N'2', N'2', N'2', N'2', N'2', N'2', 2, NULL, NULL, NULL)
INSERT [dbo].[SellAds] ([Id], [Headline], [Details], [Address], [Price], [MainImage], [BedroomNo], [BathroomNo], [OthersNo], [NeighborhoodEast], [NeighborhoodEastDistance], [NeighborhoodWest], [NeighborhoodWestDistance], [NeighborhoodNorth], [NeighborhoodNorthDistance], [NeighborhoodSouth], [NeighborhoodSouthDistance], [AddedBy], [OwnerName], [OwnerContact], [OwnerEmail]) VALUES (8, N'3', N'3', N'3', N'3', N'Main.jpg', 5, 4, 3, N'3', N'3', N'3', N'3', N'3', N'3', N'3', N'3', 3, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SellAds] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Image], [Contact], [Email], [Address], [Username], [Password], [Status]) VALUES (1, N'Mashuka', N'Meem', N'Meem2.jpg', N'01861111111', N'mashuka.meem@gmail.com', N'Dhaka', N'Meem', N'meem1234', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [HousingManagementDb] SET  READ_WRITE 
GO
