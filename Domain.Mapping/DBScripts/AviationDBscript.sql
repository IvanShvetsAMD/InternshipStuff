USE [master]
GO
/****** Object:  Database [AviationDB]    Script Date: 04-Apr-16 17:01:49 ******/
CREATE DATABASE [AviationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AviationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AviationDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10240KB )
 LOG ON 
( NAME = N'AviationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AviationDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AviationDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AviationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AviationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AviationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AviationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AviationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AviationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AviationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AviationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AviationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AviationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AviationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AviationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AviationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AviationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AviationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AviationDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AviationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AviationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AviationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AviationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AviationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AviationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AviationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AviationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AviationDB] SET  MULTI_USER 
GO
ALTER DATABASE [AviationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AviationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AviationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AviationDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AviationDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AviationDB]
GO
/****** Object:  Table [dbo].[Aircraft]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aircraft](
	[SerialNumber] [int] IDENTITY(1,1) NOT NULL,
	[Registration] [nvarchar](10) NOT NULL,
	[Owner] [nvarchar](50) NULL,
	[RegistrationDate] [date] NULL,
 CONSTRAINT [Aircraft_PK] PRIMARY KEY CLUSTERED 
(
	[SerialNumber] ASC,
	[Registration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AircraftRegistry]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AircraftRegistry](
	[EntryID] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [int] NOT NULL,
	[Registration] [nvarchar](10) NULL,
	[RegistrationDate] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GasCompartment]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GasCompartment](
	[GasCompartmentID] [int] IDENTITY(1,1) NOT NULL,
	[ParentAircraftID] [int] NULL,
	[Capacity] [float] NOT NULL,
	[CurrentVolume] [float] NOT NULL,
 CONSTRAINT [PK_GasCompartment] PRIMARY KEY CLUSTERED 
(
	[GasCompartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Generator]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generator](
	[GeneratorID] [int] IDENTITY(1,1) NOT NULL,
	[OutputCurrent] [float] NOT NULL,
	[OutrpurVoltage] [float] NOT NULL,
 CONSTRAINT [PK_Generator] PRIMARY KEY CLUSTERED 
(
	[GeneratorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Spool]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spool](
	[SpoolID] [int] IDENTITY(1,1) NOT NULL,
	[SpoolType] [nvarchar](50) NOT NULL CONSTRAINT [SpoolTypeDefaultValue]  DEFAULT ('Turbine engine spool'),
PRIMARY KEY CLUSTERED 
(
	[SpoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TurbineBlade]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurbineBlade](
	[SerialNumber] [int] IDENTITY(1,1) NOT NULL,
	[ParentSpoolID] [int] NULL,
	[Length] [int] NOT NULL,
	[MaterialType] [nvarchar](50) NOT NULL CONSTRAINT [TurbineBlade_MaterialType_DefaultValue]  DEFAULT ('High temp alloy'),
	[MaxTemp] [int] NOT NULL,
	[HasCoolingChannels] [bit] NULL DEFAULT ((0)),
	[Chord] [int] NULL,
 CONSTRAINT [PK_TurbineBlade] PRIMARY KEY CLUSTERED 
(
	[SerialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TurbineBladeStatistics]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurbineBladeStatistics](
	[MaterialType] [nvarchar](50) NOT NULL CONSTRAINT [TurbineBladeStatistics_MaterialType_DefaultValue]  DEFAULT ('High temp alloy'),
	[MaxTemp] [int] NOT NULL,
	[HasCoolingChannels] [bit] NOT NULL CONSTRAINT [TurbineBladeStatistics_HasCoolingChannels_DefaultValue]  DEFAULT ((0)),
	[NumberOfBlades] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Aircraft] ON 

INSERT [dbo].[Aircraft] ([SerialNumber], [Registration], [Owner], [RegistrationDate]) VALUES (1, N'ER-RMG', N'Air Moldova', CAST(N'2016-01-01' AS Date))
INSERT [dbo].[Aircraft] ([SerialNumber], [Registration], [Owner], [RegistrationDate]) VALUES (2, N'ER-AXP', N'Air Moldova', CAST(N'2010-08-16' AS Date))
SET IDENTITY_INSERT [dbo].[Aircraft] OFF
SET IDENTITY_INSERT [dbo].[AircraftRegistry] ON 

INSERT [dbo].[AircraftRegistry] ([EntryID], [SerialNumber], [Registration], [RegistrationDate]) VALUES (1, 1, N'ER-AXV', CAST(N'2012-10-25' AS Date))
INSERT [dbo].[AircraftRegistry] ([EntryID], [SerialNumber], [Registration], [RegistrationDate]) VALUES (2, 2, N'ER-AXP', CAST(N'2010-08-16' AS Date))
INSERT [dbo].[AircraftRegistry] ([EntryID], [SerialNumber], [Registration], [RegistrationDate]) VALUES (3, 3, N'ER-AXV', CAST(N'2012-10-25' AS Date))
INSERT [dbo].[AircraftRegistry] ([EntryID], [SerialNumber], [Registration], [RegistrationDate]) VALUES (4, 2, N'ER-AEG', CAST(N'2010-08-16' AS Date))
INSERT [dbo].[AircraftRegistry] ([EntryID], [SerialNumber], [Registration], [RegistrationDate]) VALUES (5, 1, N'ER-RMG', CAST(N'2016-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[AircraftRegistry] OFF
SET IDENTITY_INSERT [dbo].[GasCompartment] ON 

INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (1, 1, 200, 10)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (2, 1, 400, 4)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (3, 1, 200, 100)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (4, 2, 200, 100)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (5, 2, 400, 40)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (6, 2, 200, 100)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (7, 12, 200, 150)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (8, 12, 400, 400)
INSERT [dbo].[GasCompartment] ([GasCompartmentID], [ParentAircraftID], [Capacity], [CurrentVolume]) VALUES (9, 12, 200, 10)
SET IDENTITY_INSERT [dbo].[GasCompartment] OFF
SET IDENTITY_INSERT [dbo].[Generator] ON 

INSERT [dbo].[Generator] ([GeneratorID], [OutputCurrent], [OutrpurVoltage]) VALUES (1, 0, 0)
INSERT [dbo].[Generator] ([GeneratorID], [OutputCurrent], [OutrpurVoltage]) VALUES (2, 100, 28)
INSERT [dbo].[Generator] ([GeneratorID], [OutputCurrent], [OutrpurVoltage]) VALUES (3, 6, 120)
SET IDENTITY_INSERT [dbo].[Generator] OFF
SET IDENTITY_INSERT [dbo].[Spool] ON 

INSERT [dbo].[Spool] ([SpoolID], [SpoolType]) VALUES (1, N'LP spool')
INSERT [dbo].[Spool] ([SpoolID], [SpoolType]) VALUES (2, N'HP Spool')
INSERT [dbo].[Spool] ([SpoolID], [SpoolType]) VALUES (3, N'IP spool')
INSERT [dbo].[Spool] ([SpoolID], [SpoolType]) VALUES (4, N'Fan')
SET IDENTITY_INSERT [dbo].[Spool] OFF
SET IDENTITY_INSERT [dbo].[TurbineBlade] ON 

INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (1, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (2, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (3, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (4, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (5, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (6, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (7, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (8, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (9, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (10, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (11, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (12, 2, 12, N'Ti', 1500, 0, 10)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (13, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (14, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (15, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (16, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (17, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (18, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (19, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (20, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (21, 1, 12, N'High temp alloy', 1100, 1, 15)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (22, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (23, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (24, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (25, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (26, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (27, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (28, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (29, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (30, 4, 12, N'Mg', 1000, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (31, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (32, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (33, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (34, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (35, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (36, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (37, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (38, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (39, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (40, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (41, 3, 11, N'W (tungsten) alloy', 1275, 0, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (42, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (43, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (44, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (45, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (46, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (47, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (48, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (49, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (50, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (51, 3, 11, N'Ceramic plated alloy', 1350, 1, 8)
INSERT [dbo].[TurbineBlade] ([SerialNumber], [ParentSpoolID], [Length], [MaterialType], [MaxTemp], [HasCoolingChannels], [Chord]) VALUES (52, NULL, 11, N'Ceramic plated alloy', 1350, 0, 8)
SET IDENTITY_INSERT [dbo].[TurbineBlade] OFF
INSERT [dbo].[TurbineBladeStatistics] ([MaterialType], [MaxTemp], [HasCoolingChannels], [NumberOfBlades]) VALUES (N'Ceramic plated alloy', 1350, 0, 1)
INSERT [dbo].[TurbineBladeStatistics] ([MaterialType], [MaxTemp], [HasCoolingChannels], [NumberOfBlades]) VALUES (N'Ceramic plated alloy', 1350, 1, 10)
INSERT [dbo].[TurbineBladeStatistics] ([MaterialType], [MaxTemp], [HasCoolingChannels], [NumberOfBlades]) VALUES (N'High temp alloy', 1100, 1, 9)
INSERT [dbo].[TurbineBladeStatistics] ([MaterialType], [MaxTemp], [HasCoolingChannels], [NumberOfBlades]) VALUES (N'Mg', 1000, 1, 9)
INSERT [dbo].[TurbineBladeStatistics] ([MaterialType], [MaxTemp], [HasCoolingChannels], [NumberOfBlades]) VALUES (N'Ti', 1500, 0, 12)
INSERT [dbo].[TurbineBladeStatistics] ([MaterialType], [MaxTemp], [HasCoolingChannels], [NumberOfBlades]) VALUES (N'W (tungsten) alloy', 1275, 0, 11)
SET ANSI_PADDING ON

GO
/****** Object:  Index [Aircraft_Registration_UNIQUE]    Script Date: 04-Apr-16 17:01:49 ******/
ALTER TABLE [dbo].[Aircraft] ADD  CONSTRAINT [Aircraft_Registration_UNIQUE] UNIQUE NONCLUSTERED 
(
	[Registration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique_spool_ID_Type]    Script Date: 04-Apr-16 17:01:49 ******/
ALTER TABLE [dbo].[Spool] ADD  CONSTRAINT [unique_spool_ID_Type] UNIQUE NONCLUSTERED 
(
	[SpoolID] ASC,
	[SpoolType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TurbineBlade]  WITH CHECK ADD  CONSTRAINT [FK_TurbineBladeID_ParentSpoolID] FOREIGN KEY([ParentSpoolID])
REFERENCES [dbo].[Spool] ([SpoolID])
GO
ALTER TABLE [dbo].[TurbineBlade] CHECK CONSTRAINT [FK_TurbineBladeID_ParentSpoolID]
GO
ALTER TABLE [dbo].[GasCompartment]  WITH CHECK ADD  CONSTRAINT [chk_CurrentVolume] CHECK  (([CurrentVolume]<=[Capacity]))
GO
ALTER TABLE [dbo].[GasCompartment] CHECK CONSTRAINT [chk_CurrentVolume]
GO
/****** Object:  StoredProcedure [dbo].[GetMaxRegistrationDate]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaxRegistrationDate]
	@InputSerialNumber int
AS
SELECT TOP 1 ar2.[RegistrationDate] 
FROM [AircraftRegistry] AS ar2
WHERE [ar2].[SerialNumber] = @InputSerialNumber
ORDER BY [ar2].[RegistrationDate] DESC

GO
/****** Object:  StoredProcedure [dbo].[GetMinRegistrationDate]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMinRegistrationDate]
	@InputSerialNumber int
AS
SELECT TOP 1 ar2.[RegistrationDate] 
FROM [AircraftRegistry] AS ar2
WHERE [ar2].[SerialNumber] = @InputSerialNumber
ORDER BY [ar2].[RegistrationDate] ASC

GO
/****** Object:  StoredProcedure [dbo].[uspMultipleResults]    Script Date: 04-Apr-16 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMultipleResults] 
	@InputSerialNumber int
AS
SELECT TOP 1 ar2.[RegistrationDate] 
FROM [AircraftRegistry] AS ar2
WHERE [ar2].[SerialNumber] = @InputSerialNumber
ORDER BY [ar2].[RegistrationDate] DESC

GO
USE [master]
GO
ALTER DATABASE [AviationDB] SET  READ_WRITE 
GO
