USE [master]
GO
/****** Object:  Database [CIMS]    Script Date: 01/28/2018 9:33:23 PM ******/
CREATE DATABASE [CIMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CIMSWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CIMS_data.mdf' , SIZE = 23552KB , MAXSIZE = 51200KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CIMSWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CIMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CIMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CIMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CIMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CIMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CIMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CIMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CIMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CIMS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CIMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CIMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CIMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CIMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CIMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CIMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CIMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CIMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CIMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CIMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CIMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CIMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CIMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CIMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CIMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CIMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CIMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CIMS] SET  MULTI_USER 
GO
ALTER DATABASE [CIMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CIMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CIMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CIMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CIMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CIMS', N'ON'
GO
USE [CIMS]
GO
/****** Object:  UserDefinedTableType [dbo].[BanTypeTable]    Script Date: 01/28/2018 9:33:23 PM ******/
CREATE TYPE [dbo].[BanTypeTable] AS TABLE(
	[BanName] [varchar](max) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EventMediaType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE TYPE [dbo].[EventMediaType] AS TABLE(
	[Description] [varchar](max) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InvolveTypeTable]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE TYPE [dbo].[InvolveTypeTable] AS TABLE(
	[InvolvedID] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PermissionType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE TYPE [dbo].[PermissionType] AS TABLE(
	[MenuId] [int] NULL,
	[PermissionType] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PermissionType2]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE TYPE [dbo].[PermissionType2] AS TABLE(
	[MenuId] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[ReviewTableType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE TYPE [dbo].[ReviewTableType] AS TABLE(
	[ItemNumber] [varchar](50) NULL,
	[ReplacedBy] [varchar](50) NULL,
	[FromHoursMinutes] [varchar](10) NULL,
	[ToHoursMinutes] [varchar](10) NULL,
	[Reason] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[RolesType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE TYPE [dbo].[RolesType] AS TABLE(
	[RoleId] [int] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[CSVToTable]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CSVToTable]  (@InStr VARCHAR(MAX)) 
RETURNS @TempTab TABLE
   (id nvarchar(max) not null)
AS
BEGIN
    ;-- Ensure input ends with comma
	SET @InStr = REPLACE(@InStr + ',', ',,', ',')
	DECLARE @SP INT
DECLARE @VALUE VARCHAR(1000)
WHILE PATINDEX('%,%', @INSTR ) <> 0 
BEGIN
   SELECT  @SP = PATINDEX('%,%',@INSTR)
   SELECT  @VALUE = LEFT(@INSTR , @SP - 1)
   SELECT  @INSTR = STUFF(@INSTR, 1, @SP, '')
   INSERT INTO @TempTab(id) VALUES (@VALUE)
END
	RETURN
END
GO
/****** Object:  Table [dbo].[AccessCardPermitted]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessCardPermitted](
	[PermittedID] [int] IDENTITY(1,1) NOT NULL,
	[CardID] [int] NULL,
	[PermittedDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccessCards]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessCards](
	[CardID] [int] NULL,
	[CardNumber] [nvarchar](50) NULL,
	[IssueDate] [datetime] NULL,
	[TerminationDate] [datetime] NULL,
	[DeactivateDate] [datetime] NULL,
	[ReactivateDate] [datetime] NULL,
	[EmpFirstName] [nvarchar](50) NULL,
	[EmpLastName] [nvarchar](50) NULL,
	[RegNumber] [nvarchar](15) NULL,
	[EmpPosition] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[CurrentEmp] [bit] NOT NULL,
	[GroupedAreas] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressType] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AliasNameType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AliasNameType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameType] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationSettings]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationSettings](
	[Setting] [nvarchar](50) NOT NULL,
	[DataType] [nvarchar](50) NOT NULL,
	[SettingValue] [nvarchar](4000) NOT NULL,
	[Description] [nvarchar](255) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuditQuestions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditQuestions](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[AuditType] [varchar](50) NOT NULL,
	[QuestionGroup] [varchar](50) NULL,
	[Question] [varchar](450) NOT NULL,
	[ScoreType] [bit] NOT NULL CONSTRAINT [DF_AuditQuestions_ScoreType]  DEFAULT ((0)),
	[ToolTip] [varchar](2000) NULL,
 CONSTRAINT [PK_AuditQuestions] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuditsQuestions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditsQuestions](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[AuditID] [int] NOT NULL,
	[Question] [varchar](450) NOT NULL,
	[QuestionType] [tinyint] NOT NULL,
	[ToolTip] [varchar](2000) NULL,
 CONSTRAINT [PK_AuditsQuestions] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BanAuthorizedBy]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAuthorizedBy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizedBy] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banned]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banned](
	[BannedID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentID] [int] NOT NULL CONSTRAINT [DF__Banned__Incident__5FB337D6]  DEFAULT ((0)),
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[EntryDate] [nvarchar](50) NULL,
	[AuthorizedBy] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[BanYears] [int] NULL CONSTRAINT [DF__Banned__BanYears__60A75C0F]  DEFAULT ((0)),
	[BanMonths] [int] NULL CONSTRAINT [DF__Banned__BanMonth__619B8048]  DEFAULT ((0)),
	[BanDays] [int] NULL CONSTRAINT [DF__Banned__BanDays__628FA481]  DEFAULT ((0)),
	[BanTypeId] [int] NULL CONSTRAINT [DF__Banned__BanTypeI__62065FF3]  DEFAULT ((0)),
 CONSTRAINT [aaaaaBanned_PK] PRIMARY KEY NONCLUSTERED 
(
	[BannedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Build]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Build](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Build] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CameraProblems]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CameraProblems](
	[TypeID] [int] NULL,
	[TypeDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashierName]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashierName](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CashierName] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cities]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NOT NULL,
	[StateID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Codes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Codes](
	[Part] [nvarchar](30) NULL,
	[Sequence] [int] NULL CONSTRAINT [DF__Codes__Sequence__5812160E]  DEFAULT ((0)),
	[Description] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Complexion]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complexion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Complexion] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Corporate]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporate](
	[Corporate_id] [bigint] IDENTITY(1,1) NOT NULL,
	[Corporate_logo] [nvarchar](max) NULL,
	[Corporate_background] [nvarchar](max) NULL,
	[Corporate_back_type] [nvarchar](10) NULL,
	[Corporate_CreatedDate] [datetime] NULL,
	[Customer_logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Corporate] PRIMARY KEY CLUSTERED 
(
	[Corporate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [nvarchar](5) NOT NULL,
	[CountryName] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomFields]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomFields](
	[SequenceNumber] [int] NOT NULL,
	[InUse] [bit] NOT NULL,
	[FixedInUse] [bit] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[OriginalName] [varchar](50) NOT NULL,
	[NewName] [varchar](50) NOT NULL,
	[ControlType] [varchar](15) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DispatchActiveDispatcherAreas]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchActiveDispatcherAreas](
	[UserID] [nvarchar](25) NOT NULL,
	[AreaID] [nvarchar](25) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchActiveUnits]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchActiveUnits](
	[UnitCode] [nvarchar](25) NOT NULL,
	[UnitID] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Remarks] [nvarchar](150) NULL,
	[StartTime] [nvarchar](5) NULL,
	[AreaID] [nvarchar](25) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchAreas]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchAreas](
	[AreaID] [nvarchar](25) NULL,
	[AreaDescription] [nvarchar](50) NULL,
 CONSTRAINT [IX_DispatchAreas] UNIQUE NONCLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchCallAdditionalInfo]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchCallAdditionalInfo](
	[CallID] [int] NOT NULL,
	[StartTime] [nvarchar](5) NULL,
	[UnitCode] [nvarchar](25) NULL,
	[Description] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchCalls]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchCalls](
	[CallID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[StartTime] [nvarchar](15) NULL,
	[EndTime] [nvarchar](15) NULL,
	[CallTakerID] [nvarchar](25) NULL,
	[DispatcherID] [nvarchar](25) NULL,
	[Priority] [nvarchar](50) NULL,
	[AreaID] [nvarchar](25) NULL,
	[HoldForUnit] [nvarchar](25) NULL,
	[ScheduledTime] [nvarchar](15) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchCallUnits]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchCallUnits](
	[CallID] [int] NOT NULL,
	[UnitID] [int] NULL,
	[UnitCode] [nvarchar](25) NULL,
	[StartTime] [nvarchar](5) NULL,
	[EndTime] [nvarchar](5) NULL,
	[PrimaryUnit] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchSavedActiveUnits]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchSavedActiveUnits](
	[RosterName] [nvarchar](25) NOT NULL,
	[UnitCode] [nvarchar](25) NOT NULL,
	[UnitID] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[AreaID] [nvarchar](25) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchUnavailableUnitStatusTimes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchUnavailableUnitStatusTimes](
	[UnitCode] [nvarchar](25) NULL,
	[UnitID] [int] NULL,
	[StartTime] [nvarchar](5) NULL,
	[EndTime] [nvarchar](5) NULL,
	[Status] [nvarchar](50) NULL,
	[StatusDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DispatchUnitCodes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchUnitCodes](
	[UnitCode] [nvarchar](25) NOT NULL,
	[UnitDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DisputeResolution]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DisputeResolution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Resolution] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Disputes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disputes](
	[IncidentID] [int] NOT NULL,
	[Resolution] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[DisputeType] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[RecoveredMoney] [bit] NULL,
 CONSTRAINT [aaaaaDisputes_PK] PRIMARY KEY NONCLUSTERED 
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email](
	[EmailID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [varchar](75) NULL,
	[EmailAddress] [varchar](75) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailGroups]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailGroups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](75) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailLog]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailLog](
	[EmailID] [int] IDENTITY(1,1) NOT NULL,
	[EmailDate] [datetime] NOT NULL,
	[EmailTime] [nvarchar](5) NULL,
	[FromUserID] [nvarchar](25) NULL,
	[FromUserName] [nvarchar](100) NULL,
	[ToEmail] [nvarchar](1000) NULL,
	[CCEmail] [nvarchar](1000) NULL,
	[EmailSubject] [nvarchar](255) NULL,
	[RoleName] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailMembers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailMembers](
	[GroupID] [int] NULL,
	[EmailID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpEmployeeIncidents]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpEmployeeIncidents](
	[EmployeeID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeAddress]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAddress](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL CONSTRAINT [DF__EmployeeAd__Subje__51300E55]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__EmployeeAd__Incid__5224328E]  DEFAULT ((0)),
	[ModifiedDate] [datetime] NULL,
	[Apartment] [nvarchar](15) NULL,
	[Address] [nvarchar](150) NULL,
	[City] [nvarchar](15) NULL,
	[ProvState] [nvarchar](20) NULL,
	[PostalZip] [nvarchar](10) NULL,
	[AddressType] [nvarchar](50) NULL,
	[Phone] [nvarchar](250) NULL,
	[CountryID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeAuditReport]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeAuditReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentID] [int] NOT NULL,
	[AuditID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerOrScore] [varchar](6) NULL,
	[Comment] [varchar](2000) NULL,
	[Observation] [int] NULL,
 CONSTRAINT [PK_EmployeeAuditReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeAuditReportScores]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeAuditReportScores](
	[IncidentID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AuditID] [int] NOT NULL,
	[AuditSequence] [int] NOT NULL,
	[AnswerOrScore] [varchar](6) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeGameAuditScore]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeGameAuditScore](
	[IncidentID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AuditType] [varchar](50) NULL,
	[AuditScore] [varchar](10) NULL,
	[AuditComment] [ntext] NULL,
	[Observation] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeGameAuditScores]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeGameAuditScores](
	[IncidentID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AuditType] [varchar](50) NULL,
	[AuditSequence] [int] NOT NULL,
	[AuditScore] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeIncidents]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeIncidents](
	[IncidentID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentNumber] [nvarchar](20) NULL,
	[NatureOfEvent] [nvarchar](50) NULL,
	[ShortDescriptor] [nvarchar](25) NULL,
	[ActiveStatus] [bit] NOT NULL,
	[Status] [nvarchar](25) NULL,
	[IncidentDate] [datetime] NULL,
	[Description] [ntext] NULL,
	[Location] [nvarchar](50) NULL,
	[IncidentRole] [nvarchar](50) NULL,
	[IPVRDescription] [ntext] NULL,
	[Notes] [ntext] NULL,
	[OccurrenceNumber] [nvarchar](50) NULL,
	[IncidentTime] [nvarchar](10) NULL,
	[EndTime] [nvarchar](10) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RoleName] [nvarchar](50) NULL,
	[UD27] [nvarchar](50) NULL,
	[UD34] [nvarchar](50) NULL,
	[UD35] [nvarchar](50) NULL,
	[EventID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ReportView] [bit] NULL,
	[ReportEdit] [bit] NULL,
	[ReportDelete] [bit] NULL,
 CONSTRAINT [PK_EmployeeIncidents] PRIMARY KEY CLUSTERED 
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeIncidentType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeIncidentType](
	[NatureOfEvent] [nvarchar](25) NULL,
	[ShortDescriptor] [nvarchar](25) NULL,
	[ToolTip] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeInvolved]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInvolved](
	[EmployeeID] [int] NULL,
	[IncidentID] [int] NULL,
	[InvolvedID] [int] NULL,
	[MediaID] [int] NULL,
	[InvolvedRole] [nvarchar](50) NULL,
	[FetchDetailsBy] [nvarchar](100) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLicense]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLicense](
	[EmployeeID] [int] NOT NULL,
	[DateOfHire] [datetime] NULL,
	[TerminationDate] [datetime] NULL,
	[LicenseExpirationDate] [datetime] NULL,
	[Department] [nvarchar](50) NULL,
	[LicenseType] [nvarchar](50) NULL,
	[LicenseStatus] [nvarchar](50) NULL,
	[ReasonForLeaving] [ntext] NULL,
	[UD16] [nvarchar](50) NULL,
	[UD17] [nvarchar](50) NULL,
	[UD18] [nvarchar](50) NULL,
	[UD19] [nvarchar](50) NULL,
	[LicenseID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLinked]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeLinked](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL,
	[Description] [varchar](150) NULL,
	[FilePath] [varchar](250) NOT NULL,
 CONSTRAINT [PK_EmployeeLinked] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeePaceAuditShuffleShoe]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeePaceAuditShuffleShoe](
	[IncidentID] [int] NOT NULL,
	[Game] [nvarchar](30) NULL,
	[ShuffleShoe] [varchar](10) NOT NULL,
	[TimeTaken] [varchar](25) NULL,
	[DisplayName] [varchar](50) NULL,
	[StartTime] [varchar](25) NULL,
	[EndTime] [varchar](25) NULL,
	[Description] [ntext] NULL,
	[PaceAuditPositionsPlayed] [int] NULL,
	[PaceAuditHandsPlayed] [int] NULL,
	[PaceAuditHandsPerHour] [int] NULL,
	[Observation] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeePersonal]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePersonal](
	[EmployeeID] [int] NOT NULL,
	[UD10] [nvarchar](50) NULL,
	[UD11] [nvarchar](50) NULL,
	[UD12] [nvarchar](50) NULL,
	[UD13] [nvarchar](50) NULL,
	[UD14] [nvarchar](50) NULL,
	[UD15] [nvarchar](50) NULL,
	[IDType1] [nvarchar](50) NULL,
	[IDNumber1] [nvarchar](25) NULL,
	[IDDefault1] [int] NULL,
	[IDType2] [nvarchar](50) NULL,
	[IDNumber2] [nvarchar](25) NULL,
	[IDDefault2] [bit] NULL,
	[IDType3] [nvarchar](50) NULL,
	[IDNumber3] [nvarchar](25) NULL,
	[IDDefault3] [bit] NULL,
	[DateOfBirth] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeePhone]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePhone](
	[EmployeeID] [int] NULL,
	[PhoneType] [nvarchar](25) NULL,
	[PhoneNumber] [nvarchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeePicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePicturesVideos](
	[EmployeeID] [int] NULL CONSTRAINT [DF__Employee__2BFE89A6]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__Employee__2CF2ADDF]  DEFAULT ((0)),
	[MediaID] [int] NULL CONSTRAINT [DF__Employee__2DE6D218]  DEFAULT ((0)),
	[MediaType] [nvarchar](50) NULL,
	[QuestionID] [int] NULL,
	[Observation] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeePosition]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePosition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRoles](
	[ActiveRole] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNumber] [nvarchar](25) NULL,
	[Age] [float] NULL,
	[Sex] [nvarchar](10) NULL,
	[Race] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
	[FirstName] [nvarchar](25) NULL,
	[MiddleName] [nvarchar](20) NULL,
	[Height] [nvarchar](25) NULL,
	[Weight] [nvarchar](25) NULL,
	[DateOfBirth] [datetime] NULL,
	[StaffPosition] [nvarchar](50) NULL,
	[Eyes] [nvarchar](10) NULL,
	[Complexion] [nvarchar](15) NULL,
	[Build] [nvarchar](15) NULL,
	[Glasses] [nvarchar](10) NULL,
	[Restricted] [bit] NOT NULL CONSTRAINT [DF__Employees__Restri__2739D489]  DEFAULT ((0)),
	[Status] [nvarchar](50) NULL,
	[RoleName] [nvarchar](50) NULL,
	[UD9] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ConvertSubject] [bit] NULL,
 CONSTRAINT [aEmployees_PK] PRIMARY KEY NONCLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeStatus]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpStatus] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeVariance]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeVariance](
	[IncidentID] [int] NOT NULL,
	[Resolution] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[VarianceType] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[AmountShort] [bit] NULL,
	[AmountOver] [bit] NULL,
	[AmountType] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpReportProofread]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpReportProofread](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportProofread] [bit] NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpReportProofread_log]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpReportProofread_log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportProofread] [bit] NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpReportsAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpReportsAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpReportsAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpReportsAccessPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[ReportView] [bit] NULL,
	[ReportEdit] [bit] NULL,
	[ReportDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifyDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpReportsAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpReportsAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpReportsLink]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpReportsLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportLinkWith] [int] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[LinkWithReport] [bit] NULL,
	[FetchDetailsBy] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentAction]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Actions] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentProblems]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentProblems](
	[ProblemID] [int] IDENTITY(1,1) NOT NULL,
	[ProblemType] [nvarchar](50) NULL,
	[EquipNumber] [nvarchar](50) NULL,
	[Problem] [nvarchar](50) NULL,
	[Details] [ntext] NULL,
	[Corrected] [bit] NOT NULL CONSTRAINT [DF__Equipment__Corre__4D94879B]  DEFAULT ((0)),
	[Solution] [nvarchar](50) NULL,
	[Replacement] [nvarchar](50) NULL,
	[StatusTime] [datetime] NULL,
	[CompletedTime] [datetime] NULL,
	[userID] [int] NULL,
 CONSTRAINT [aaaaaEquipmentProblems_PK] PRIMARY KEY NONCLUSTERED 
(
	[ProblemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentStatus]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Problems] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorTime] [datetime] NOT NULL CONSTRAINT [DF_ErrorLog_ErrorTime]  DEFAULT (getdate()),
	[UserName] [sysname] NOT NULL,
	[ErrorNumber] [int] NOT NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [nvarchar](126) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_ErrorLog_ErrorLogID] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventEmployeeIncidents]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventEmployeeIncidents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL,
 CONSTRAINT [EventEmployeeIncidents_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventGeneralReports]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventGeneralReports](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[ReportID] [int] NOT NULL,
 CONSTRAINT [EventGeneralReports_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventLog](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[EventNumber] [int] NOT NULL CONSTRAINT [DF__EventLog__EventN__45F365D3]  DEFAULT ((0)),
	[AttachedEvent] [int] NULL CONSTRAINT [DF__EventLog__Attach__46E78A0C]  DEFAULT ((0)),
	[EventTime] [nvarchar](15) NULL,
	[FromCode] [nvarchar](50) NULL,
	[NatureCode] [nvarchar](50) NULL,
	[NatureDesc] [nvarchar](1000) NULL,
	[DutyDesc] [nvarchar](1000) NULL,
	[Camera] [nvarchar](255) NULL,
	[UserID] [nvarchar](25) NULL,
	[KeyEvent] [bit] NOT NULL CONSTRAINT [DF__EventLog__KeyEve__47DBAE45]  DEFAULT ((0)),
	[FromForm] [nvarchar](25) NULL,
	[FromNumber] [nvarchar](25) NULL,
	[RoleName] [nvarchar](50) NULL,
	[UD20] [nvarchar](50) NULL,
	[UD21] [nvarchar](50) NULL,
	[UD22] [nvarchar](50) NULL,
	[UD23] [nvarchar](50) NULL,
	[UD24] [nvarchar](50) NULL,
	[UD25] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[EndTime] [nvarchar](15) NULL,
	[Site] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
	[Comments] [nvarchar](4000) NULL DEFAULT (''),
	[CreatedBy] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventMedia]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventMedia](
	[EventMediaID] [int] IDENTITY(1,1) NOT NULL,
	[MediaID] [int] NULL CONSTRAINT [DF__EventMedi__Media__4222D4EF]  DEFAULT ((0)),
	[Description] [nvarchar](75) NULL,
	[Details] [ntext] NULL,
	[EventID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventPicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventPicturesVideos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[MediaID] [int] NULL,
	[MediaType] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventReportsAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventReportsAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[ReportAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventReportsAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventReportsAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventRoles](
	[ActiveRole] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventsAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[EventAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewEvent] [bit] NULL,
	[EditEvent] [bit] NULL,
	[DeleteEvent] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventsAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[EventAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewEvent] [bit] NULL,
	[EditEvent] [bit] NULL,
	[DeleteEvent] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventSubjectIncidents]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventSubjectIncidents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL,
 CONSTRAINT [EventSubjectIncidents_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FacialHair]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacialHair](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacialHair] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeatureLocation]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeatureLocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FLocation] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeaturePicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeaturePicturesVideos](
	[FeatureID] [int] NULL,
	[IncidentID] [int] NULL,
	[MediaID] [int] NULL,
	[MediaType] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeatureType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeatureType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeatureType] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ForeignExchangeRates]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForeignExchangeRates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](200) NULL,
	[Rate] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ForeignRates]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForeignRates](
	[ForeignCountry] [nvarchar](50) NULL,
	[Rate] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GameTables]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameTables](
	[Game] [nvarchar](50) NULL,
	[GameCode] [nvarchar](10) NULL,
	[StartTable] [int] NULL,
	[EndTable] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReport]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralReport](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[ReportNumber] [nvarchar](20) NULL,
	[NatureOfEvent] [nvarchar](50) NULL,
	[ShortDescriptor] [nvarchar](25) NULL,
	[ActiveStatus] [bit] NULL,
	[Status] [nvarchar](25) NULL,
	[IncidentDate] [datetime] NULL,
	[Description] [ntext] NULL,
	[Location] [nvarchar](50) NULL,
	[IncidentRole] [nvarchar](50) NULL,
	[OccurrenceNumber] [nvarchar](50) NULL,
	[IncidentTime] [nvarchar](10) NULL,
	[RoleName] [nvarchar](50) NULL,
	[UD51] [nvarchar](50) NULL,
	[UD52] [nvarchar](50) NULL,
	[UD53] [nvarchar](50) NULL,
	[EventID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_GeneralReport_CreatedDate]  DEFAULT (getdate())
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReportBanned]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralReportBanned](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[EntryDate] [nvarchar](50) NULL,
	[AuthorizedBy] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[BanYears] [int] NULL,
	[BanMonths] [int] NULL,
	[BanDays] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReportInvolved]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralReportInvolved](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[InvolvedID] [int] NULL,
	[MediaID] [int] NULL,
	[InvolvedRole] [int] NULL,
	[IsEmployee] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReportLinked]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralReportLinked](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReportsBanType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralReportsBanType](
	[ReportID] [int] NULL,
	[BanName] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReportsDisputes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralReportsDisputes](
	[DisputeID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[DisputeType] [nvarchar](50) NULL,
	[Resolution] [nvarchar](50) NULL,
	[Amount] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[RecoveredMoney] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralReportsServices]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneralReportsServices](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[CallTime] [datetime] NULL,
	[ArriveTime] [datetime] NULL,
	[ServiceBy] [varchar](50) NULL,
	[ServiceFor] [varchar](50) NULL,
	[Description] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GeneralReportsServicesOffered]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneralReportsServicesOffered](
	[ServiceOfferID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[ServiceName] [varchar](50) NULL,
	[Offered] [bit] NULL,
	[Declined] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GenReportLCTCashCall]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportLCTCashCall](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[CashCallTime] [nvarchar](15) NULL,
	[Cashier] [nvarchar](50) NULL,
	[Amount] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenReportLCTCashOuts]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportLCTCashOuts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[Amount] [float] NULL,
	[TypeOfWin] [nvarchar](20) NULL,
	[PaymentType] [nvarchar](20) NULL,
	[ChequeNo] [nvarchar](20) NULL,
	[CashOutTime] [nvarchar](10) NULL,
	[TableNumber] [nvarchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenReportLCTForeignExchange]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportLCTForeignExchange](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[ForeignCountry] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[ForeignAmount] [float] NULL,
	[Rate] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenReportLCTPitTransactions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportLCTPitTransactions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[Pit] [nvarchar](50) NULL,
	[Game] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[BuyInType] [nvarchar](50) NULL,
	[BuyInTime] [nvarchar](15) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenReportsAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportsAccessPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[ReportView] [bit] NULL,
	[ReportEdit] [bit] NULL,
	[ReportDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifyDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenReportsInvolved]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportsInvolved](
	[InvolvedID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[FirstName] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
	[Race] [nvarchar](25) NULL,
	[Sex] [nvarchar](10) NULL,
	[RoleName] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenReportsVehicles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenReportsVehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[LicensePlate] [nvarchar](12) NULL,
	[IssuedIn] [nvarchar](25) NULL,
	[VehicleMake] [nvarchar](50) NULL,
	[VehicleModel] [nvarchar](50) NULL,
	[VehicleYear] [nvarchar](4) NULL,
	[VehicleColor] [nvarchar](20) NULL,
	[VehicleVIN] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenSubReportsAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenSubReportsAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[ReportAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenSubReportsAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenSubReportsAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HairColor]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HairColor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HairColor] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HairLength]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HairLength](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HairLength] [nvarchar](200) NULL,
	[ImagePath] [varchar](200) NULL CONSTRAINT [DF_HairLength_ImagePath]  DEFAULT ('')
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[incedent_pref]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[incedent_pref](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pref_Type] [varchar](50) NOT NULL,
	[pref_Value] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IncidentGeneralReports]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentGeneralReports](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[UserId] [nvarchar](25) NULL,
	[ReportDate] [datetime] NULL,
	[Report] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncidentReports]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentReports](
	[IncidentID] [int] NOT NULL,
	[UserID] [nvarchar](25) NULL,
	[ReportDate] [datetime] NULL,
	[Report] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incidents]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Incidents](
	[IncidentID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentNumber] [nvarchar](20) NULL,
	[NatureOfEvent] [nvarchar](50) NULL,
	[ShortDescriptor] [nvarchar](25) NULL,
	[ActiveStatus] [bit] NOT NULL CONSTRAINT [DF__Incidents__Activ__33D4B598]  DEFAULT ((0)),
	[Status] [nvarchar](25) NULL,
	[IncidentDate] [datetime] NULL,
	[Description] [ntext] NULL,
	[Location] [nvarchar](50) NULL,
	[IncidentRole] [nvarchar](50) NULL,
	[Protected] [bit] NOT NULL CONSTRAINT [DF__Incidents__Prote__34C8D9D1]  DEFAULT ((0)),
	[OccurrenceNumber] [nvarchar](50) NULL,
	[IPVRDescription] [ntext] NULL,
	[IncidentTime] [nvarchar](10) NULL,
	[RoleName] [nvarchar](50) NULL,
	[UD26] [nvarchar](50) NULL,
	[UD32] [nvarchar](50) NULL,
	[UD33] [nvarchar](50) NULL,
	[EventID] [int] NULL,
	[EndDate] [datetime] NULL,
	[EndTime] [varchar](10) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ReportView] [bit] NULL,
	[ReportEdit] [bit] NULL,
	[ReportDelete] [bit] NULL,
 CONSTRAINT [aaaaaIncidents_PK] PRIMARY KEY NONCLUSTERED 
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IncidentType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentType](
	[NatureOfEvent] [nvarchar](25) NULL,
	[ShortDescriptor] [nvarchar](25) NULL,
	[ToolTip] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InitiatedBy]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InitiatedBy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Initiated] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCTCashCall]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCTCashCall](
	[SubjectID] [int] NULL,
	[IncidentID] [int] NULL,
	[CashCallTime] [nvarchar](15) NULL,
	[Cashier] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCTCashOuts]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCTCashOuts](
	[SubjectID] [int] NULL CONSTRAINT [DF__LCTCashOu__Subje__276EDEB3]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__LCTCashOu__Incid__286302EC]  DEFAULT ((0)),
	[Sequence] [smallint] NULL CONSTRAINT [DF__LCTCashOu__Seque__29572725]  DEFAULT ((0)),
	[Amount] [float] NULL CONSTRAINT [DF__LCTCashOu__Amoun__2C3393D0]  DEFAULT ((0)),
	[TypeOfWin] [nvarchar](20) NULL,
	[PaymentType] [nvarchar](20) NULL,
	[ChequeNo] [nvarchar](20) NULL,
	[CashOutTime] [nvarchar](15) NULL,
	[TableNumber] [nvarchar](20) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCTForeignExchange]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCTForeignExchange](
	[SubjectID] [int] NULL CONSTRAINT [DF__LCTForeig__Subje__6C190EBB]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__LCTForeig__Incid__6D0D32F4]  DEFAULT ((0)),
	[ForeignCountry] [nvarchar](50) NULL,
	[Amount] [float] NULL CONSTRAINT [DF__LCTForeig__Amoun__6EF57B66]  DEFAULT ((0)),
	[ForeignAmount] [float] NULL CONSTRAINT [DF__LCTForeig__ForAmt__87654322]  DEFAULT ((0)),
	[Rate] [float] NULL CONSTRAINT [DF__LCTForeig__ForRat__23456789]  DEFAULT ((0)),
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCTMain]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCTMain](
	[LCTID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL,
	[TransactionDate] [datetime] NULL,
	[Apartment] [nvarchar](15) NULL,
	[Address] [nvarchar](150) NULL,
	[City] [nvarchar](15) NULL,
	[ProvState] [nvarchar](20) NULL,
	[PostalZip] [nvarchar](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[FirstName] [nvarchar](25) NULL,
	[MiddleName] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
	[Occupation] [nvarchar](50) NULL,
	[BusinessName] [nvarchar](50) NULL,
	[TypeOfID] [nvarchar](25) NULL,
	[IDNumber] [nvarchar](25) NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[EmployeeTitle] [nvarchar](50) NULL,
	[EmployeeGPEB] [nvarchar](20) NULL,
	[CashierName] [nvarchar](50) NULL,
	[CashierTitle] [nvarchar](50) NULL,
	[CashierGPEB] [nvarchar](20) NULL,
	[Notes] [ntext] NULL,
	[LCTIDNumber] [nvarchar](25) NULL,
 CONSTRAINT [aaaaaLCTMain_PK] PRIMARY KEY NONCLUSTERED 
(
	[SubjectID] ASC,
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCTPitTransactions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCTPitTransactions](
	[SubjectID] [int] NULL CONSTRAINT [DF__LCTPitTra__Subje__182C9B23]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__LCTPitTra__Incid__1920BF5C]  DEFAULT ((0)),
	[Pit] [nvarchar](50) NULL,
	[Game] [nvarchar](50) NULL,
	[Amount] [float] NULL CONSTRAINT [DF__LCTPitTra__Amoun__1A14E395]  DEFAULT ((0)),
	[BuyInType] [nvarchar](20) NULL,
	[BuyInTime] [nvarchar](15) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BuyInTypePitID] [int] NULL,
	[BuyInGameID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[License]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[License](
	[LicenseKey] [nvarchar](450) NOT NULL,
	[LicenseType] [int] NOT NULL,
	[ModulesTotal] [int] NOT NULL,
	[FAN] [int] NOT NULL,
	[FAD] [nvarchar](6) NOT NULL,
	[EVN] [int] NOT NULL,
	[EVD] [nvarchar](6) NOT NULL,
	[SUN] [int] NOT NULL,
	[SUD] [nvarchar](6) NOT NULL,
	[EMN] [int] NOT NULL,
	[EMD] [nvarchar](6) NOT NULL,
	[QUN] [int] NOT NULL,
	[QUD] [nvarchar](6) NOT NULL,
	[DIN] [int] NOT NULL,
	[DID] [nvarchar](6) NOT NULL,
	[SSN] [int] NOT NULL,
	[SSD] [nvarchar](6) NOT NULL,
	[SPN] [int] NOT NULL,
	[SPD] [nvarchar](6) NOT NULL,
	[OCN] [int] NOT NULL,
	[OCD] [nvarchar](6) NOT NULL,
	[UPD] [nvarchar](6) NOT NULL,
	[CustomerName] [nvarchar](75) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LicensedCustomers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicensedCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Roles] [nvarchar](max) NULL,
	[Email] [nvarchar](500) NULL,
	[Password] [nvarchar](50) NULL,
	[Phone] [nvarchar](25) NULL,
	[Country] [int] NULL,
	[State] [int] NULL,
	[City] [nvarchar](50) NULL,
	[Zip] [nvarchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[LicenseExpiryDate] [datetime] NULL,
	[UserName] [nvarchar](50) NULL,
	[CustomerLogo] [nvarchar](max) NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LicensePC]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicensePC](
	[PCID] [int] IDENTITY(1,1) NOT NULL,
	[PCGUID] [uniqueidentifier] NOT NULL,
	[ModulesTotal] [int] NOT NULL,
	[LastUsed] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LU_AgeSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LU_AgeSearch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgeRange] [nvarchar](6) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManageCustomerPermissions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageCustomerPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManageCustomerRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageCustomerRoles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManageMenus]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ManageMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](500) NULL,
	[ParentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ManagePermissions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[PermissionType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManageRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageRoles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManageSubMenuPermissions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageSubMenuPermissions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubMenus] [nvarchar](100) NULL,
	[ParentID] [int] NULL,
	[RoleID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Master_tblState]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_tblState](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](100) NULL,
	[CountryID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterAddressType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterAddressType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AddressType] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterBuyInGame]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterBuyInGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Game] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterBuyInPitType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterBuyInPitType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuyInPitType] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterCashoutTableNumber]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterCashoutTableNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableNumber] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterDepartmentType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterDepartmentType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentType] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterDisputeType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterDisputeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisputeType] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterEyes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterEyes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Eyes] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterGame]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Game] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterHeightUnit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterHeightUnit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[HeightUnitName] [nvarchar](50) NOT NULL,
	[IsDefault] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterLicenseStatus]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterLicenseStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseStatus] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterLicenseType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterLicenseType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseType] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterNatureofIncident]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterNatureofIncident](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nature] [nvarchar](200) NULL,
	[NatureType] [int] NULL,
	[NatureImage] [nvarchar](500) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterRace]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterRace](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Race] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterSex]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterSex](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sex] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterShortDescriptor]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterShortDescriptor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descriptor] [nvarchar](200) NULL,
	[NatureID] [int] NULL,
	[ProShortDescriptor] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterStatus]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterTypeID1]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterTypeID1](
	[Value] [nvarchar](200) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterTypeID2]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterTypeID2](
	[Value] [nvarchar](200) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterTypeID3]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterTypeID3](
	[Value] [nvarchar](200) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Masterwatch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masterwatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[watch] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterWeightUnit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterWeightUnit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WeightUnitName] [nvarchar](50) NOT NULL,
	[IsDefault] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mater_tblCountry]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mater_tblCountry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NULL,
	[ContinentID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaCopy]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaCopy](
	[MediaCopyID] [int] IDENTITY(1,1) NOT NULL,
	[MediaNumbers] [nvarchar](255) NULL,
	[MediaLabel] [nvarchar](100) NULL,
	[IncidentNumber] [nvarchar](50) NULL,
	[OriginalsHeldBy] [nvarchar](50) NULL,
	[SentToOther] [nvarchar](50) NULL,
	[OriginalsSaved] [nvarchar](25) NULL,
	[EventID] [int] NULL,
 CONSTRAINT [aaaaaMediaCopy_PK] PRIMARY KEY NONCLUSTERED 
(
	[MediaCopyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaCopySentTo]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaCopySentTo](
	[MediaCopyID] [int] NULL,
	[CopySentTo] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaProblems]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaProblems](
	[MediaID] [int] NULL,
	[MediaDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaSolutions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaSolutions](
	[MediaID] [int] NULL,
	[MediaDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageAlertRecipients]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageAlertRecipients](
	[AlertID] [int] NOT NULL,
	[UserID] [nvarchar](25) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageAlerts]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageAlerts](
	[AlertID] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](75) NOT NULL,
	[FieldValue] [nvarchar](255) NULL,
	[MessageText] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageGroups]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageGroups](
	[GroupName] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](25) NOT NULL,
	[U_ID] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageRecipients]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageRecipients](
	[UserID] [int] NULL,
	[SenderID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
	[Draft] [bit] NULL,
	[SentToSelf] [bit] NULL,
	[DateRead] [datetime] NULL,
	[DateDeleted] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageText] [ntext] NULL,
	[Description] [nvarchar](150) NULL,
	[DateSent] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MSTTypeOfBan]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MSTTypeOfBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfBan] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NatureCodes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NatureCodes](
	[Code] [nvarchar](20) NULL,
	[Description] [nvarchar](50) NULL,
	[DefaultAction] [nvarchar](20) NULL,
	[DefaultCamera] [nvarchar](20) NULL,
	[UD20] [nvarchar](50) NULL,
	[UD21] [nvarchar](50) NULL,
	[UD22] [nvarchar](50) NULL,
	[UD23] [nvarchar](50) NULL,
	[UD24] [nvarchar](50) NULL,
	[UD25] [nvarchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[new_table]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[new_table](
	[Setting] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[DataType] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Occurrence]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occurrence](
	[OccurrenceID] [int] IDENTITY(1,1) NOT NULL,
	[OccurrenceNumber] [nvarchar](25) NOT NULL,
	[IncidentType] [nvarchar](100) NULL,
	[Description] [ntext] NULL,
	[Location] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[OccurrenceTime] [nvarchar](5) NULL,
	[EventID] [int] NULL,
	[UD28] [nvarchar](50) NULL,
	[UD29] [nvarchar](50) NULL,
	[UD30] [nvarchar](50) NULL,
	[UD31] [nvarchar](50) NULL,
 CONSTRAINT [aaaaaOccurrence_PK] PRIMARY KEY NONCLUSTERED 
(
	[OccurrenceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccurrenceNarrative]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccurrenceNarrative](
	[FromID] [int] NOT NULL,
	[OccurrenceID] [int] NOT NULL,
	[OccurrenceNumber] [nvarchar](50) NOT NULL,
	[FromRole] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](25) NOT NULL,
	[Narrative] [ntext] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [aaaaaOccurrenceNarrative_PK] PRIMARY KEY NONCLUSTERED 
(
	[OccurrenceNumber] ASC,
	[FromRole] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccurrenceRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccurrenceRoles](
	[ActiveRole] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccurrenceRptFrom]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccurrenceRptFrom](
	[FromID] [int] IDENTITY(1,1) NOT NULL,
	[OccurrenceID] [int] NOT NULL,
	[OccurrenceNumber] [nvarchar](25) NOT NULL,
	[FromRole] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](25) NOT NULL,
	[Completed] [bit] NOT NULL,
	[Verified] [bit] NOT NULL,
 CONSTRAINT [aaaaaOccurrenceRptFrom_PK] PRIMARY KEY NONCLUSTERED 
(
	[OccurrenceNumber] ASC,
	[FromRole] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccurrenceSupplemental]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccurrenceSupplemental](
	[FromID] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Narrative] [ntext] NULL,
	[UpdateTime] [datetime] NULL,
	[Completed] [bit] NOT NULL,
	[Verified] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OtherEquipment]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherEquipment](
	[OtherEquipID] [int] NULL,
	[OtherEquipDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PicturesVideos](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Assigned] [int] NULL,
	[MediaExtention] [nvarchar](3) NULL,
	[MediaName] [nvarchar](15) NULL,
	[Description] [nvarchar](75) NULL,
	[MediaDateTime] [datetime] NULL,
	[DefaultPic] [bit] NOT NULL CONSTRAINT [DF__PicturesV__Defau__16CE6296]  DEFAULT ((0)),
	[EncodeArray] [image] NULL,
	[EncodeState] [tinyint] NULL CONSTRAINT [DF__PicturesV__Encod__17C286CF]  DEFAULT ((0)),
	[PicType] [tinyint] NULL,
	[EncodeFaceValues] [nvarchar](50) NULL,
	[FaceValue] [float] NULL,
	[FilePath] [nvarchar](max) NULL,
	[SubFeaturesid] [int] NULL,
	[PictureType] [nvarchar](50) NULL,
	[SubFeatureID] [int] NULL,
 CONSTRAINT [aaaaaPicturesVideos_PK] PRIMARY KEY NONCLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlayerBets]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerBets](
	[PlayerShoeID] [int] NOT NULL,
	[BetID] [int] NOT NULL,
	[Bet] [float] NULL,
	[HouseEdgeCorrelation] [float] NULL,
	[TrueCountCorrelation] [float] NULL,
	[TrueCount] [float] NULL,
	[RunningCount] [float] NULL,
	[HouseEdge] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlayerCards]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlayerCards](
	[PlayerShoeID] [int] NOT NULL,
	[BetID] [int] NOT NULL,
	[Card] [varchar](2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlayerResults]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerResults](
	[PlayerShoeID] [int] NOT NULL,
	[ThreatLevel] [int] NULL,
	[ThreatText] [nvarchar](500) NULL,
	[CountMethod] [nvarchar](75) NULL,
	[ResultsText] [nvarchar](250) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlayerShoes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerShoes](
	[PlayerShoeID] [int] IDENTITY(1,1) NOT NULL,
	[ShoeDate] [datetime] NOT NULL,
	[SubjectID] [int] NULL,
	[IncidentID] [int] NULL,
 CONSTRAINT [PK_PlayerShoes] PRIMARY KEY CLUSTERED 
(
	[PlayerShoeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuickIncident]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuickIncident](
	[IncidentID] [int] IDENTITY(1,1) NOT NULL,
	[QuickDate] [datetime] NULL,
	[QuickTime] [nvarchar](5) NULL,
	[IncidentNumber] [nvarchar](25) NULL,
	[IncidentType] [nvarchar](50) NULL,
	[IncidentLocation] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[UD1] [nvarchar](50) NULL,
	[UD2] [nvarchar](50) NULL,
	[UD3] [nvarchar](50) NULL,
	[UD4] [nvarchar](50) NULL,
	[UD5] [nvarchar](50) NULL,
	[UD6] [nvarchar](50) NULL,
	[UD7] [nvarchar](50) NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuickIncident] PRIMARY KEY CLUSTERED 
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuickMediaCopy]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuickMediaCopy](
	[IncidentID] [int] NOT NULL,
	[MediaType] [nvarchar](50) NULL,
	[Originals] [nvarchar](50) NULL,
	[MediaNumbers] [nvarchar](50) NULL,
	[UD8] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuickPerson]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuickPerson](
	[IncidentID] [int] NOT NULL,
	[PersonType] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PersonPosition] [nvarchar](50) NULL,
	[PersonNumber] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuickRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuickRoles](
	[ActiveRole] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportLogoImage]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportLogoImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[SetImage] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportQueries]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportQueries](
	[ReportID] [int] NOT NULL,
	[QueryID] [int] NOT NULL,
	[FieldSequence] [int] NOT NULL,
	[QueryField] [image] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reports](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](50) NOT NULL,
	[ReportRole] [nvarchar](50) NOT NULL,
	[ReportLayout] [varchar](max) NULL,
	[WholeLayout] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReportSQL]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportSQL](
	[ReportID] [int] NOT NULL,
	[QueryID] [int] NOT NULL,
	[QuerySQL] [nvarchar](2500) NOT NULL,
	[UserModified] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportTables]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTables](
	[GroupName] [nvarchar](50) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[ToJoinTable] [nvarchar](50) NULL,
	[ToJoinColumn] [nvarchar](50) NULL,
	[FromJoinTable] [nvarchar](50) NULL,
	[FromJoinColumn] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Review]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[ItemNumber] [nvarchar](50) NULL,
	[ReplacedBy] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[FromHoursMinutes] [nvarchar](10) NULL,
	[ToHoursMinutes] [nvarchar](10) NULL,
	[Reason] [nvarchar](50) NULL,
	[EventID] [int] NULL,
 CONSTRAINT [aaaaaReview_PK] PRIMARY KEY NONCLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityFunctions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityFunctions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Events] [tinyint] NULL CONSTRAINT [DF__SecurityF__Event__662B2B3B]  DEFAULT ((0)),
	[Occurrence] [tinyint] NULL CONSTRAINT [DF__SecurityF__Occur__671F4F74]  DEFAULT ((0)),
	[Events Media] [tinyint] NULL CONSTRAINT [DF__SecurityF__Event__681373AD]  DEFAULT ((0)),
	[Media Review] [tinyint] NULL CONSTRAINT [DF__SecurityF__Media__690797E6]  DEFAULT ((0)),
	[Media Copy] [tinyint] NULL CONSTRAINT [DF__SecurityF__Media__69FBBC1F]  DEFAULT ((0)),
	[Visitors] [tinyint] NULL CONSTRAINT [DF__SecurityF__Visit__6AEFE058]  DEFAULT ((0)),
	[Occurrence Write] [tinyint] NULL CONSTRAINT [DF__SecurityF__Occur__6BE40491]  DEFAULT ((0)),
	[Occurrence Administration] [tinyint] NULL CONSTRAINT [DF__SecurityF__Occur__6CD828CA]  DEFAULT ((0)),
	[Access Cards] [tinyint] NULL CONSTRAINT [DF__SecurityF__Acces__6DCC4D03]  DEFAULT ((0)),
	[Equipment] [tinyint] NULL CONSTRAINT [DF__SecurityF__Equip__6EC0713C]  DEFAULT ((0)),
	[Subjects] [tinyint] NULL CONSTRAINT [DF__SecurityF__Subje__6FB49575]  DEFAULT ((0)),
	[Address] [tinyint] NULL CONSTRAINT [DF__SecurityF__Addre__70A8B9AE]  DEFAULT ((0)),
	[Alias] [tinyint] NULL CONSTRAINT [DF__SecurityF__Alias__719CDDE7]  DEFAULT ((0)),
	[Features] [tinyint] NULL CONSTRAINT [DF__SecurityF__Featu__72910220]  DEFAULT ((0)),
	[Identification] [tinyint] NULL CONSTRAINT [DF__SecurityF__Ident__73852659]  DEFAULT ((0)),
	[LCT Totals] [tinyint] NULL CONSTRAINT [DF__SecurityF__LCT T__74794A92]  DEFAULT ((0)),
	[Watch List] [tinyint] NULL CONSTRAINT [DF__SecurityF__Watch__756D6ECB]  DEFAULT ((0)),
	[Watch List Edit] [tinyint] NULL CONSTRAINT [DF__SecurityF__Watch__76619304]  DEFAULT ((0)),
	[Restricted Subjects] [tinyint] NULL CONSTRAINT [DF__SecurityF__Restr__7755B73D]  DEFAULT ((0)),
	[Incident Details] [tinyint] NULL CONSTRAINT [DF__SecurityF__Incid__7849DB76]  DEFAULT ((0)),
	[Incident Description] [tinyint] NULL CONSTRAINT [DF__SecurityF__Incid__793DFFAF]  DEFAULT ((0)),
	[Incident Protection] [tinyint] NULL CONSTRAINT [DF__SecurityF__Incid__7A3223E8]  DEFAULT ((0)),
	[Cash Transactions] [tinyint] NULL CONSTRAINT [DF__SecurityF__Cash __7B264821]  DEFAULT ((0)),
	[LCT Details] [tinyint] NULL CONSTRAINT [DF__SecurityF__LCT D__7C1A6C5A]  DEFAULT ((0)),
	[Vehicles] [tinyint] NULL CONSTRAINT [DF__SecurityF__Vehic__7D0E9093]  DEFAULT ((0)),
	[Involved] [tinyint] NULL CONSTRAINT [DF__SecurityF__Invol__7E02B4CC]  DEFAULT ((0)),
	[Banned] [tinyint] NULL CONSTRAINT [DF__SecurityF__Banne__7EF6D905]  DEFAULT ((0)),
	[Dispute/Offense] [tinyint] NULL CONSTRAINT [DF__SecurityF__Dispu__7FEAFD3E]  DEFAULT ((0)),
	[Services] [tinyint] NULL CONSTRAINT [DF__SecurityF__Servi__00DF2177]  DEFAULT ((0)),
	[Combine Subjects] [tinyint] NULL CONSTRAINT [DF__SecurityF__Combi__01D345B0]  DEFAULT ((0)),
	[Users] [tinyint] NULL CONSTRAINT [DF__SecurityF__Users__02C769E9]  DEFAULT ((0)),
	[Permissions] [tinyint] NULL CONSTRAINT [DF__SecurityF__Permi__03BB8E22]  DEFAULT ((0)),
	[Media Capture] [tinyint] NULL CONSTRAINT [DF__SecurityF__Media__04AFB25B]  DEFAULT ((0)),
	[Media Capture Options] [tinyint] NULL CONSTRAINT [DF__SecurityF__Media__05A3D694]  DEFAULT ((0)),
	[Application Options] [tinyint] NULL CONSTRAINT [DF__SecurityF__Appli__0697FACD]  DEFAULT ((0)),
	[Database Options] [tinyint] NULL CONSTRAINT [DF__SecurityF__Datab__078C1F06]  DEFAULT ((0)),
	[Nature of Call Codes] [tinyint] NULL CONSTRAINT [DF__SecurityF__Natur__0880433F]  DEFAULT ((0)),
	[Nature of Incident Codes] [tinyint] NULL CONSTRAINT [DF__SecurityF__Natur__09746778]  DEFAULT ((0)),
	[Dropdown Codes] [tinyint] NULL CONSTRAINT [DF__SecurityF__Dropd__0B5CAFEA]  DEFAULT ((0)),
	[Game Locations] [tinyint] NULL CONSTRAINT [DF__SecurityF__Game __0C50D423]  DEFAULT ((0)),
	[Services Codes] [tinyint] NULL CONSTRAINT [DF__SecurityF__Servi__0D44F85C]  DEFAULT ((0)),
	[Report Options] [tinyint] NULL CONSTRAINT [DF__SecurityF__Repor__0E391C95]  DEFAULT ((0)),
	[E-mails] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_E-mails]  DEFAULT ((0)),
	[Employee] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee]  DEFAULT ((0)),
	[Employee Incident Details] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Incident Details]  DEFAULT ((0)),
	[Employee Involved] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Involved]  DEFAULT ((0)),
	[Employee Game Audit] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Game Audit]  DEFAULT ((0)),
	[Employee Pace Audit] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Pace Audit]  DEFAULT ((0)),
	[Employee IPVR] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_IPVR]  DEFAULT ((0)),
	[Audit Questions] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Audit Questions]  DEFAULT ((0)),
	[Employee Notes] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Notes]  DEFAULT ((0)),
	[Label Names] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Label Names]  DEFAULT ((0)),
	[Employee Variance] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Variance]  DEFAULT ((0)),
	[Badges] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Badges]  DEFAULT ((0)),
	[Foreign Rates] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Foreign Rates]  DEFAULT ((0)),
	[Quick Incident] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Quick Incident]  DEFAULT ((0)),
	[Subject Linked] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Subject Linked]  DEFAULT ((0)),
	[Employee Linked] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Linked]  DEFAULT ((0)),
	[Employee Address] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Address]  DEFAULT ((0)),
	[Employee License] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee License]  DEFAULT ((0)),
	[Employee Personal] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Employee Personal]  DEFAULT ((0)),
	[Transaction Log] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Transaction Log]  DEFAULT ((0)),
	[Messages] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Messages]  DEFAULT ((0)),
	[Message Groups] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Message Groups]  DEFAULT ((0)),
	[Dispatch Administration] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Dispatch Administration]  DEFAULT ((0)),
	[Dispatch Dispatchers] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Dispatch Dispatchers]  DEFAULT ((0)),
	[Dispatch Call Takers] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Dispatch Call Takers]  DEFAULT ((0)),
	[Shared Information] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Shared Information]  DEFAULT ((0)),
	[Shared Emails] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Shared Emails]  DEFAULT ((0)),
	[Change Roles] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Change Roles]  DEFAULT ((0)),
	[Custom Reports] [tinyint] NULL CONSTRAINT [DF_SecurityFunctions_Custom Reports]  DEFAULT ((0)),
	[Multiple Author Reports] [tinyint] NULL,
	[Message Alerts] [tinyint] NULL,
 CONSTRAINT [PK_SecurityFunctions_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceName] [nvarchar](50) NOT NULL,
	[DeclinedAvailable] [bit] NOT NULL CONSTRAINT [DF__Services__Declin__625A9A57]  DEFAULT ((0)),
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[setmetrics]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[setmetrics](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](10) NULL,
	[metrics] [nvarchar](20) NULL,
	[ActiveMetrics] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SharedDatabase]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedDatabase](
	[LocationDescription] [nvarchar](50) NOT NULL,
	[CustomerID] [int] NULL,
	[Server] [nvarchar](125) NOT NULL,
	[UID] [nvarchar](75) NOT NULL,
	[PWD] [nvarchar](75) NOT NULL,
	[DatabaseName] [nvarchar](75) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](max) NOT NULL,
	[CountryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectAddress]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectAddress](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectAd__Subje__51300E55]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__SubjectAd__Incid__5224328E]  DEFAULT ((0)),
	[ModifiedDate] [datetime] NULL,
	[Apartment] [nvarchar](150) NULL,
	[Address] [nvarchar](150) NULL,
	[City] [nvarchar](15) NULL,
	[ProvState] [nvarchar](20) NULL,
	[PostalZip] [nvarchar](10) NULL,
	[AddressType] [nvarchar](50) NULL,
	[CountryID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectAlias]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectAlias](
	[AliasID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL CONSTRAINT [DF__SubjectAl__Subje__4C6B5938]  DEFAULT ((0)),
	[DateEntered] [datetime] NULL,
	[NameType] [nvarchar](25) NULL,
	[FirstName] [nvarchar](25) NULL,
	[MiddleName] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
 CONSTRAINT [aaaaaSubjectAlias_PK] PRIMARY KEY NONCLUSTERED 
(
	[AliasID] ASC,
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectBanType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectBanType](
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectBa__Subje__47A6A41B]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__SubjectBa__Incid__489AC854]  DEFAULT ((0)),
	[BanName] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectIdentification]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectIdentification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectId__Subje__40F9A68C]  DEFAULT ((0)),
	[Occupation] [nvarchar](50) NULL,
	[BusinessName] [nvarchar](50) NULL,
	[IDType1] [nvarchar](50) NULL,
	[IDNumber1] [nvarchar](25) NULL,
	[IDDefault1] [bit] NOT NULL CONSTRAINT [DF__SubjectId__IDDef__41EDCAC5]  DEFAULT ((0)),
	[IDType2] [nvarchar](50) NULL,
	[IDNumber2] [nvarchar](25) NULL,
	[IDDefault2] [bit] NOT NULL CONSTRAINT [DF__SubjectId__IDDef__42E1EEFE]  DEFAULT ((0)),
	[IDType3] [nvarchar](50) NULL,
	[IDNumber3] [nvarchar](25) NULL,
	[IDDefault3] [bit] NOT NULL CONSTRAINT [DF__SubjectId__IDDef__43D61337]  DEFAULT ((0)),
	[LCTID] [nvarchar](25) NULL,
 CONSTRAINT [PK_SubjectIdentification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectIncidents]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectIncidents](
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectIn__Subje__72C60C4A]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__SubjectIn__Incid__73BA3083]  DEFAULT ((0))
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectInvolved]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectInvolved](
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectIn__Subje__3493CFA7]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__SubjectIn__Incid__3587F3E0]  DEFAULT ((0)),
	[InvolvedID] [int] NULL CONSTRAINT [DF__SubjectIn__Invol__367C1819]  DEFAULT ((0)),
	[MediaID] [int] NULL CONSTRAINT [DF__SubjectIn__Media__37703C52]  DEFAULT ((0)),
	[InvolvedRole] [nvarchar](50) NULL,
	[IsEmployee] [bit] NULL CONSTRAINT [DF_SubjectInvolved_IsEmployee]  DEFAULT ((0)),
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectLinked]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubjectLinked](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL,
	[Description] [varchar](150) NULL,
	[FilePath] [varchar](250) NOT NULL,
 CONSTRAINT [PK_SubjectLinked] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubjectMarks]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectMarks](
	[MarkID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectMa__Subje__251C81ED]  DEFAULT ((0)),
	[FeatureType] [nvarchar](25) NULL,
	[FeatureLocation] [nvarchar](25) NULL,
	[Description] [ntext] NULL,
	[MediaID] [int] NULL CONSTRAINT [DF__SubjectMa__Media__2610A626]  DEFAULT ((0)),
 CONSTRAINT [PK_SubjectMarks] PRIMARY KEY CLUSTERED 
(
	[MarkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectPhone]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectPhone](
	[SubjectID] [int] NULL,
	[PhoneType] [nvarchar](25) NULL,
	[PhoneNumber] [nvarchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectPicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectPicturesVideos](
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectPi__Subje__2BFE89A6]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__SubjectPi__Incid__2CF2ADDF]  DEFAULT ((0)),
	[MediaID] [int] NULL CONSTRAINT [DF__SubjectPi__Media__2DE6D218]  DEFAULT ((0)),
	[MediaType] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectRoles](
	[ActiveRole] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[VIP] [nvarchar](25) NULL,
	[Age] [float] NULL,
	[Sex] [nvarchar](10) NULL,
	[Race] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
	[FirstName] [nvarchar](25) NULL,
	[MiddleName] [nvarchar](20) NULL,
	[Height] [nvarchar](25) NULL,
	[Weight] [nvarchar](25) NULL,
	[DateOfBirth] [datetime] NULL,
	[HairColor] [nvarchar](15) NULL,
	[Eyes] [nvarchar](10) NULL,
	[Complexion] [nvarchar](15) NULL,
	[Build] [nvarchar](15) NULL,
	[FacialHair] [nvarchar](25) NULL,
	[HairLength] [nvarchar](25) NULL,
	[Glasses] [nvarchar](10) NULL,
	[Restricted] [bit] NOT NULL CONSTRAINT [DF__Subjects__Restri__2739D489]  DEFAULT ((0)),
	[Status] [nvarchar](50) NULL,
	[RoleName] [nvarchar](50) NULL,
	[CIDSubject] [bit] NULL,
	[CIDPersonID] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[createddate] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [aaaaaSubjects_PK] PRIMARY KEY NONCLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectServices]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectServices](
	[SubjectID] [int] NOT NULL,
	[IncidentID] [int] NOT NULL,
	[CallTime] [datetime] NULL,
	[ArriveTime] [datetime] NULL,
	[ServiceBy] [nvarchar](50) NULL,
	[ServiceFor] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [aaaaaSubjectServices_PK] PRIMARY KEY NONCLUSTERED 
(
	[SubjectID] ASC,
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectServicesOffered]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectServicesOffered](
	[SubjectID] [int] NULL,
	[IncidentID] [int] NULL,
	[ServiceName] [nvarchar](50) NULL,
	[Offered] [bit] NOT NULL,
	[Declined] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectVehicles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectVehicles](
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectVe__Subje__14270015]  DEFAULT ((0)),
	[VehicleID] [int] NULL CONSTRAINT [DF__SubjectVe__Vehic__151B244E]  DEFAULT ((0)),
	[IncidentID] [int] NULL CONSTRAINT [DF__SubjectVe__Incid__160F4887]  DEFAULT ((0)),
	[MediaID] [int] NULL CONSTRAINT [DF__SubjectVe__Media__17036CC0]  DEFAULT ((0))
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectWatch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectWatch](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL CONSTRAINT [DF__SubjectWa__Subje__10566F31]  DEFAULT ((0)),
	[WatchName] [nvarchar](50) NULL,
 CONSTRAINT [PK_SubjectWatch] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubMenu]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubMenu](
	[SubMenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](500) NULL,
	[ParentId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubReportProofread]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubReportProofread](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportProofread] [bit] NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubReportProofread_log]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubReportProofread_log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportProofread] [bit] NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubReportsAccessByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubReportsAccessByRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportAccessRole] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubReportsAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubReportsAccessPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[ReportView] [bit] NULL,
	[ReportEdit] [bit] NULL,
	[ReportDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifyDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubReportsAccessUsers]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubReportsAccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportAccessBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ViewReport] [bit] NULL,
	[EditReport] [bit] NULL,
	[DeleteReport] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubReportsLink]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubReportsLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ReportID] [int] NULL,
	[ReportLinkWith] [int] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[LinkWithReport] [bit] NULL,
	[FetchDetailsBy] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SuperAdmin]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperAdmin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sysidkey]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysidkey](
	[id] [nvarchar](50) NULL,
	[DBVersion] [smallint] NULL,
	[Server] [nvarchar](125) NULL,
	[UID] [nvarchar](75) NULL,
	[PWD] [nvarchar](75) NULL,
	[DatabaseName] [nvarchar](75) NULL,
	[GUID] [uniqueidentifier] NULL,
	[CustomerID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionLog]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionLog](
	[TLID] [int] IDENTITY(1,1) NOT NULL,
	[TLDate] [datetime] NOT NULL,
	[TLTime] [nvarchar](5) NULL,
	[Section] [nvarchar](50) NULL,
	[Action] [nvarchar](50) NULL,
	[Description] [nvarchar](1000) NULL,
	[UserID] [nvarchar](25) NULL,
	[RoleName] [nvarchar](50) NULL,
	[FromNumber] [nvarchar](25) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionLogRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionLogRoles](
	[ActiveRole] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionsMain]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionsMain](
	[SubjectID] [int] NOT NULL CONSTRAINT [DF__Transacti__Subje__06CD04F7]  DEFAULT ((0)),
	[IncidentID] [int] NOT NULL CONSTRAINT [DF__Transacti__Incid__07C12930]  DEFAULT ((0)),
	[TotalPit] [float] NULL CONSTRAINT [DF__Transacti__Total__09A971A2]  DEFAULT ((0)),
	[TotalExchange] [float] NULL CONSTRAINT [DF__Transacti__Total__0A9D95DB]  DEFAULT ((0)),
	[TotalCashOut] [float] NULL CONSTRAINT [DF__Transacti__Total__0B91BA14]  DEFAULT ((0)),
	[BuyInMarker] [float] NULL,
	[CashOutMarker] [float] NULL,
 CONSTRAINT [aaaaaTransactionsMain_PK] PRIMARY KEY NONCLUSTERED 
(
	[SubjectID] ASC,
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserID] [nvarchar](25) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[EventRole] [bit] NOT NULL CONSTRAINT [DF__UserRoles__Event__02FC7413]  DEFAULT ((0))
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Initials] [nvarchar](10) NULL,
	[RegNumber] [nvarchar](15) NULL,
	[Password] [nvarchar](50) NULL,
	[UnitID] [int] NOT NULL,
	[Skills] [nvarchar](50) NULL,
	[IsDispatchable] [bit] NULL,
	[PasswordDate] [datetime] NULL,
	[UserCanChangePassword] [bit] NULL,
	[EMail] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[IsAdmin] [bit] NULL,
	[UserGuid] [varchar](max) NULL,
	[IsEmailVerify] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VarianceResolution]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VarianceResolution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Resolution] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VarianceType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VarianceType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VarianceType] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleColor]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleColor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](12) NULL,
	[IssuedIn] [nvarchar](25) NULL,
	[VehicleMake] [nvarchar](50) NULL,
	[VehicleModel] [nvarchar](50) NULL,
	[VehicleYear] [nvarchar](4) NULL,
	[VehicleColor] [nvarchar](20) NULL,
	[VehicleVIN] [nvarchar](50) NULL,
 CONSTRAINT [aaaaaVehicles_PK] PRIMARY KEY NONCLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehiclesPicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiclesPicturesVideos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehiclesID] [int] NULL,
	[IncidentID] [int] NULL,
	[MediaID] [int] NULL,
	[MediaType] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visitor]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitor](
	[VisitorID] [int] IDENTITY(1,1) NOT NULL,
	[VisitorName] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[FromHoursMinutes] [nvarchar](10) NULL,
	[ToHoursMinutes] [nvarchar](10) NULL,
	[EventID] [int] NULL,
	[VisitorDate] [datetime] NULL,
	[GroupIdentifier] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [aaaaaVisitor_PK] PRIMARY KEY NONCLUSTERED 
(
	[VisitorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitorEmailSend]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorEmailSend](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[SMTP] [nvarchar](5) NULL,
	[Password] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VistorLogoImage]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VistorLogoImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[SetImage] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WatchNames]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WatchNames](
	[WatchID] [int] IDENTITY(1,1) NOT NULL,
	[WatchName] [nvarchar](50) NULL,
 CONSTRAINT [PK_WatchNames] PRIMARY KEY CLUSTERED 
(
	[WatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [CardID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [CardID] ON [dbo].[AccessCardPermitted]
(
	[CardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [ID] ON [dbo].[AccessCardPermitted]
(
	[PermittedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [CardID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [CardID] ON [dbo].[AccessCards]
(
	[CardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [GamingID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [GamingID] ON [dbo].[AccessCards]
(
	[RegNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[Banned]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SentToID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [SentToID] ON [dbo].[CameraProblems]
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchActiveDispatcherAreas]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchActiveDispatcherAreas] ON [dbo].[DispatchActiveDispatcherAreas]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchActiveUnits]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DispatchActiveUnits] ON [dbo].[DispatchActiveUnits]
(
	[UnitCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchActiveUnits_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchActiveUnits_1] ON [dbo].[DispatchActiveUnits]
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DispatchCallAdditionalInfo]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCallAdditionalInfo] ON [dbo].[DispatchCallAdditionalInfo]
(
	[CallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DispatchCalls]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCalls] ON [dbo].[DispatchCalls]
(
	[CallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchCalls_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCalls_1] ON [dbo].[DispatchCalls]
(
	[CallTakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchCalls_2]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCalls_2] ON [dbo].[DispatchCalls]
(
	[DispatcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchCalls_3]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCalls_3] ON [dbo].[DispatchCalls]
(
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchCalls_4]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCalls_4] ON [dbo].[DispatchCalls]
(
	[EndTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DispatchCallUnits]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCallUnits] ON [dbo].[DispatchCallUnits]
(
	[CallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DispatchCallUnits_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchCallUnits_1] ON [dbo].[DispatchCallUnits]
(
	[CallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchSavedActiveUnits]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchSavedActiveUnits] ON [dbo].[DispatchSavedActiveUnits]
(
	[RosterName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchUnavailableUnitStatusTimes]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchUnavailableUnitStatusTimes] ON [dbo].[DispatchUnavailableUnitStatusTimes]
(
	[UnitCode] ASC,
	[StatusDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DispatchUnavailableUnitStatusTimes_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchUnavailableUnitStatusTimes_1] ON [dbo].[DispatchUnavailableUnitStatusTimes]
(
	[UnitID] ASC,
	[StatusDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchUnavailableUnitStatusTimes_2]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchUnavailableUnitStatusTimes_2] ON [dbo].[DispatchUnavailableUnitStatusTimes]
(
	[UnitCode] ASC,
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DispatchUnavailableUnitStatusTimes_3]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_DispatchUnavailableUnitStatusTimes_3] ON [dbo].[DispatchUnavailableUnitStatusTimes]
(
	[StatusDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DispatchUnitCodes]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DispatchUnitCodes] ON [dbo].[DispatchUnitCodes]
(
	[UnitCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[Disputes]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EmailDate]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EmailDate] ON [dbo].[EmailLog]
(
	[EmailDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmailMembers]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmailMembers] ON [dbo].[EmailMembers]
(
	[GroupID] ASC,
	[EmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [AddressID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [AddressID] ON [dbo].[EmployeeAddress]
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeGameAuditScore]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeGameAuditScore] ON [dbo].[EmployeeGameAuditScore]
(
	[IncidentID] ASC,
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeGameAuditScores]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeGameAuditScores] ON [dbo].[EmployeeGameAuditScores]
(
	[IncidentID] ASC,
	[QuestionID] ASC,
	[AuditSequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_EmployeeIncidentType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeIncidentType] ON [dbo].[EmployeeIncidentType]
(
	[NatureOfEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeLicense]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeLicense] ON [dbo].[EmployeeLicense]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeLinked]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeLinked] ON [dbo].[EmployeeLinked]
(
	[EmployeeID] ASC,
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EmployeeID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EmployeeID] ON [dbo].[EmployeePhone]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ActivityID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ActivityID] ON [dbo].[EmployeePicturesVideos]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EmployeeID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EmployeeID] ON [dbo].[EmployeePicturesVideos]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MediaID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaID] ON [dbo].[EmployeePicturesVideos]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [MediaType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaType] ON [dbo].[EmployeePicturesVideos]
(
	[MediaType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmployeeRole]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EmployeeRole] ON [dbo].[EmployeeRoles]
(
	[ActiveRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[EmployeeVariance]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Number]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Number] ON [dbo].[EquipmentProblems]
(
	[EquipNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ProblemID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [ProblemID] ON [dbo].[EquipmentProblems]
(
	[ProblemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [ProblemType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ProblemType] ON [dbo].[EquipmentProblems]
(
	[ProblemType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [FromCode]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [FromCode] ON [dbo].[EventLog]
(
	[FromCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [NatureCode]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [NatureCode] ON [dbo].[EventLog]
(
	[NatureCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Site]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Site] ON [dbo].[EventLog]
(
	[Site] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EventID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EventID] ON [dbo].[EventMedia]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MediaCopyID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MediaCopyID] ON [dbo].[EventMedia]
(
	[EventMediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MediaID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaID] ON [dbo].[EventMedia]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [MediaType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaType] ON [dbo].[EventMedia]
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Initials]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Initials] ON [dbo].[EventRoles]
(
	[ActiveRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Game]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Game] ON [dbo].[GameTables]
(
	[Game] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [GameCode]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [GameCode] ON [dbo].[GameTables]
(
	[GameCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IncidentReports]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_IncidentReports] ON [dbo].[IncidentReports]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IncidentReports_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_IncidentReports_1] ON [dbo].[IncidentReports]
(
	[IncidentID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[LCTCashCall]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[LCTCashCall]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[LCTCashOuts]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[LCTCashOuts]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[LCTForeignExchange]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[LCTForeignExchange]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[LCTMain]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDNumber]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IDNumber] ON [dbo].[LCTMain]
(
	[IDNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[LCTMain]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [LCTID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [LCTID] ON [dbo].[LCTMain]
(
	[LCTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [TypeOfID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [TypeOfID] ON [dbo].[LCTMain]
(
	[TypeOfID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[LCTPitTransactions]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[LCTPitTransactions]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LicensePC]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_LicensePC] ON [dbo].[LicensePC]
(
	[PCID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LicensePC_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_LicensePC_1] ON [dbo].[LicensePC]
(
	[PCGUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EventID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EventID] ON [dbo].[MediaCopy]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TapeCopyID1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [TapeCopyID1] ON [dbo].[MediaCopy]
(
	[MediaCopyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TapeCopyID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [TapeCopyID] ON [dbo].[MediaCopySentTo]
(
	[MediaCopyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SentToID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [SentToID] ON [dbo].[MediaProblems]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SentToID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [SentToID] ON [dbo].[MediaSolutions]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MessageAlertRecipients]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageAlertRecipients] ON [dbo].[MessageAlertRecipients]
(
	[AlertID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MessageAlerts]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageAlerts] ON [dbo].[MessageAlerts]
(
	[AlertID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MessageAlerts_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageAlerts_1] ON [dbo].[MessageAlerts]
(
	[FieldName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MessageGroups]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageGroups] ON [dbo].[MessageGroups]
(
	[GroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Messages]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Messages] ON [dbo].[Messages]
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Messages_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Messages_1] ON [dbo].[Messages]
(
	[DateSent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EventID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EventID] ON [dbo].[Occurrence]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Occur]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Occur] ON [dbo].[Occurrence]
(
	[OccurrenceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Initials]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Initials] ON [dbo].[OccurrenceRoles]
(
	[ActiveRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [FromRole]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [FromRole] ON [dbo].[OccurrenceRptFrom]
(
	[FromRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OccurrenceRptFrom_OccurrenceID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_OccurrenceRptFrom_OccurrenceID] ON [dbo].[OccurrenceRptFrom]
(
	[OccurrenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [OccurrenceID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [OccurrenceID] ON [dbo].[OccurrenceRptFrom]
(
	[OccurrenceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserName]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [UserName] ON [dbo].[OccurrenceRptFrom]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OccurrenceSupplemental_FromID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_OccurrenceSupplemental_FromID] ON [dbo].[OccurrenceSupplemental]
(
	[FromID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SentToID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [SentToID] ON [dbo].[OtherEquipment]
(
	[OtherEquipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [DESCR]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [DESCR] ON [dbo].[PicturesVideos]
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ID] ON [dbo].[PicturesVideos]
(
	[Assigned] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PicturesVideos]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PicturesVideos] ON [dbo].[PicturesVideos]
(
	[Assigned] ASC,
	[PicType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PICDATE]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [PICDATE] ON [dbo].[PicturesVideos]
(
	[MediaDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerBets]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayerBets] ON [dbo].[PlayerBets]
(
	[PlayerShoeID] ASC,
	[BetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerCards]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayerCards] ON [dbo].[PlayerCards]
(
	[PlayerShoeID] ASC,
	[BetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerResults]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayerResults] ON [dbo].[PlayerResults]
(
	[PlayerShoeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerShoes]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayerShoes] ON [dbo].[PlayerShoes]
(
	[PlayerShoeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerShoes_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayerShoes_1] ON [dbo].[PlayerShoes]
(
	[PlayerShoeID] ASC,
	[ShoeDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerShoes_2]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayerShoes_2] ON [dbo].[PlayerShoes]
(
	[SubjectID] ASC,
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuickIncident]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickIncident] ON [dbo].[QuickIncident]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuickIncident_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickIncident_1] ON [dbo].[QuickIncident]
(
	[IncidentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuickIncident_2]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickIncident_2] ON [dbo].[QuickIncident]
(
	[IncidentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuickMediaCopy]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickMediaCopy] ON [dbo].[QuickMediaCopy]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuickMediaCopy_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickMediaCopy_1] ON [dbo].[QuickMediaCopy]
(
	[MediaType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuickPerson]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickPerson] ON [dbo].[QuickPerson]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuickPerson_1]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuickPerson_1] ON [dbo].[QuickPerson]
(
	[PersonType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [QuickRole]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [QuickRole] ON [dbo].[QuickRoles]
(
	[ActiveRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReportSQL]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReportSQL] ON [dbo].[ReportSQL]
(
	[ReportID] ASC,
	[QueryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EventID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EventID] ON [dbo].[Review]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ReviewID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [ReviewID] ON [dbo].[Review]
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Role]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Role] ON [dbo].[SecurityFunctions]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [AddressID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [AddressID] ON [dbo].[SubjectAddress]
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectAddress]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectAddress]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [AddressID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [AddressID] ON [dbo].[SubjectAlias]
(
	[AliasID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectAlias]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectBanType]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectBanType]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectIdentification]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectIncidents]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectIncidents]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubjectLinked]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubjectLinked] ON [dbo].[SubjectLinked]
(
	[SubjectID] ASC,
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [AddressID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [AddressID] ON [dbo].[SubjectMarks]
(
	[MarkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectMarks]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MediaID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaID] ON [dbo].[SubjectMarks]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SubjectID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [SubjectID] ON [dbo].[SubjectPhone]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectPicturesVideos]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectPicturesVideos]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MediaID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaID] ON [dbo].[SubjectPicturesVideos]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [MediaType]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaType] ON [dbo].[SubjectPicturesVideos]
(
	[MediaType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [SubjectRole]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [SubjectRole] ON [dbo].[SubjectRoles]
(
	[ActiveRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [AGE]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [AGE] ON [dbo].[Subjects]
(
	[Age] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [BUILD]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [BUILD] ON [dbo].[Subjects]
(
	[Build] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [COMPLEX]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [COMPLEX] ON [dbo].[Subjects]
(
	[Complexion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EYESCODE]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EYESCODE] ON [dbo].[Subjects]
(
	[Eyes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [FACIALHAIRCODE]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [FACIALHAIRCODE] ON [dbo].[Subjects]
(
	[FacialHair] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [GIVENM]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [GIVENM] ON [dbo].[Subjects]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [HAIRCODE]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [HAIRCODE] ON [dbo].[Subjects]
(
	[HairColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subjects_PersonID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subjects_PersonID] ON [dbo].[Subjects]
(
	[CIDPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [LNAME]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [LNAME] ON [dbo].[Subjects]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RACECode]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [RACECode] ON [dbo].[Subjects]
(
	[Race] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [SEXCODE]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [SEXCODE] ON [dbo].[Subjects]
(
	[Sex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [VIP]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [VIP] ON [dbo].[Subjects]
(
	[VIP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectServices]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectServices]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectServicesOffered]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectServicesOffered]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectVehicles]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[SubjectVehicles]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MediaID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [MediaID] ON [dbo].[SubjectVehicles]
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [VehicleID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [VehicleID] ON [dbo].[SubjectVehicles]
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[SubjectWatch]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [WatchName]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [WatchName] ON [dbo].[SubjectWatch]
(
	[WatchName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Action]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Action] ON [dbo].[TransactionLog]
(
	[Action] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Section]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Section] ON [dbo].[TransactionLog]
(
	[Section] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TLDate]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [TLDate] ON [dbo].[TransactionLog]
(
	[TLDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [TransactionLogRole]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [TransactionLogRole] ON [dbo].[TransactionLogRoles]
(
	[ActiveRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ClientID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [ClientID] ON [dbo].[TransactionsMain]
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IncidentID] ON [dbo].[TransactionsMain]
(
	[IncidentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Initials]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [Initials] ON [dbo].[UserRoles]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [VehicleID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [VehicleID] ON [dbo].[Vehicles]
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EventID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [EventID] ON [dbo].[Visitor]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [VisitorDate]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [VisitorDate] ON [dbo].[Visitor]
(
	[VisitorDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [VisitorID]    Script Date: 01/28/2018 9:33:24 PM ******/
CREATE NONCLUSTERED INDEX [VisitorID] ON [dbo].[Visitor]
(
	[VisitorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccessCardPermitted] ADD  CONSTRAINT [DF__AccessCar__CardI__239E4DCF]  DEFAULT ((0)) FOR [CardID]
GO
ALTER TABLE [dbo].[AccessCards] ADD  CONSTRAINT [DF__AccessCar__CardI__6754599E]  DEFAULT ((0)) FOR [CardID]
GO
ALTER TABLE [dbo].[AccessCards] ADD  CONSTRAINT [DF__AccessCar__Curre__68487DD7]  DEFAULT ((0)) FOR [CurrentEmp]
GO
ALTER TABLE [dbo].[CameraProblems] ADD  CONSTRAINT [DF__CameraPro__TypeI__5BE2A6F2]  DEFAULT ((0)) FOR [TypeID]
GO
ALTER TABLE [dbo].[Disputes] ADD  CONSTRAINT [DF__Disputes__Incide__52593CB8]  DEFAULT ((0)) FOR [IncidentID]
GO
ALTER TABLE [dbo].[Disputes] ADD  CONSTRAINT [DF__Disputes__Amount__534D60F1]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[EmployeePhone] ADD  CONSTRAINT [DF__EmployeePhone__500E55]  DEFAULT ((0)) FOR [EmployeeID]
GO
ALTER TABLE [dbo].[GameTables] ADD  CONSTRAINT [DF__GameTable__Start__398D8EEE]  DEFAULT ((0)) FOR [StartTable]
GO
ALTER TABLE [dbo].[GameTables] ADD  CONSTRAINT [DF__GameTable__EndTa__3A81B327]  DEFAULT ((0)) FOR [EndTable]
GO
ALTER TABLE [dbo].[LCTMain] ADD  CONSTRAINT [DF__LCTMain__Subject__1DE57479]  DEFAULT ((0)) FOR [SubjectID]
GO
ALTER TABLE [dbo].[LCTMain] ADD  CONSTRAINT [DF__LCTMain__Inciden__1ED998B2]  DEFAULT ((0)) FOR [IncidentID]
GO
ALTER TABLE [dbo].[MediaCopySentTo] ADD  CONSTRAINT [DF__MediaCopy__Media__0F975522]  DEFAULT ((0)) FOR [MediaCopyID]
GO
ALTER TABLE [dbo].[MediaProblems] ADD  CONSTRAINT [DF__MediaProb__Media__0BC6C43E]  DEFAULT ((0)) FOR [MediaID]
GO
ALTER TABLE [dbo].[MediaSolutions] ADD  CONSTRAINT [DF__MediaSolu__Media__0425A276]  DEFAULT ((0)) FOR [MediaID]
GO
ALTER TABLE [dbo].[MessageRecipients] ADD  CONSTRAINT [DF_MessageRecipients_Draft]  DEFAULT ((0)) FOR [Draft]
GO
ALTER TABLE [dbo].[OccurrenceRptFrom] ADD  CONSTRAINT [DF__Occurrenc__Compl__3B40CD36]  DEFAULT ((0)) FOR [Completed]
GO
ALTER TABLE [dbo].[OccurrenceRptFrom] ADD  CONSTRAINT [DF__Occurrenc__Verif__3C34F16F]  DEFAULT ((0)) FOR [Verified]
GO
ALTER TABLE [dbo].[OtherEquipment] ADD  CONSTRAINT [DF__OtherEqui__Other__300424B4]  DEFAULT ((0)) FOR [OtherEquipID]
GO
ALTER TABLE [dbo].[SubjectPhone] ADD  CONSTRAINT [DF__SubjectPhone__500E55]  DEFAULT ((0)) FOR [SubjectID]
GO
ALTER TABLE [dbo].[SubjectServices] ADD  CONSTRAINT [DF__SubjectSe__Subje__2180FB33]  DEFAULT ((0)) FOR [SubjectID]
GO
ALTER TABLE [dbo].[SubjectServices] ADD  CONSTRAINT [DF__SubjectSe__Incid__22751F6C]  DEFAULT ((0)) FOR [IncidentID]
GO
ALTER TABLE [dbo].[SubjectServicesOffered] ADD  CONSTRAINT [DF__SubjectSe__Subje__1AD3FDA4]  DEFAULT ((0)) FOR [SubjectID]
GO
ALTER TABLE [dbo].[SubjectServicesOffered] ADD  CONSTRAINT [DF__SubjectSe__Incid__1BC821DD]  DEFAULT ((0)) FOR [IncidentID]
GO
ALTER TABLE [dbo].[SubjectServicesOffered] ADD  CONSTRAINT [DF__SubjectSe__Offer__1CBC4616]  DEFAULT ((0)) FOR [Offered]
GO
ALTER TABLE [dbo].[SubjectServicesOffered] ADD  CONSTRAINT [DF__SubjectSe__Decli__1DB06A4F]  DEFAULT ((0)) FOR [Declined]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([ID])
GO
ALTER TABLE [dbo].[ManageCustomerPermissions]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ManageCustomerRoles] ([RoleId])
GO
ALTER TABLE [dbo].[ManagePermissions]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ManageRoles] ([RoleId])
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[UserInRole]  WITH CHECK ADD  CONSTRAINT [FK_UserInRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[ManageRoles] ([RoleId])
GO
ALTER TABLE [dbo].[UserInRole] CHECK CONSTRAINT [FK_UserInRole_RoleId]
GO
/****** Object:  StoredProcedure [dbo].[ActivateMetrics_ByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActivateMetrics_ByID]
(
@ID int,
@Type nvarchar(10)=Null
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	 Update setmetrics set ActiveMetrics='0' where Type=@Type and  ActiveMetrics='1';
	 Update setmetrics set ActiveMetrics='1' where Type=@Type and ID=@ID ;
	 select @@RowCount as RESULT
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[AddAll_UsersAndRoles_EmployeeAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddAll_UsersAndRoles_EmployeeAccess]
(
    @EmployeeID int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		--INSERT INTO EmployeeAccessUsers (EmployeeID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @EmployeeID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		--  FROM users 
		--WHERE ID <> 1 AND ID <> @CreatedBy
		--AND ID NOT IN (SELECT ReportAccessBy FROM EmployeeAccessUsers 
		--WHERE EmployeeID = @EmployeeID );
		 
		----User who created report should have all rights
		--INSERT INTO EmployeeAccessUsers (EmployeeID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @EmployeeID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		--  FROM users 
		--WHERE ID = @CreatedBy;

		INSERT INTO EmployeeAccessByRole (EmployeeID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @EmployeeID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId NOT IN (SELECT ReportAccessRole FROM EmployeeAccessByRole 
		WHERE EmployeeID = @EmployeeID )  AND RoleId <> (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 

		--Administrator should have all rights
		INSERT INTO EmployeeAccessByRole (EmployeeID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @EmployeeID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId = (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AddAll_UsersAndRoles_EmpReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddAll_UsersAndRoles_EmpReportsAccess]
(
    @EmployeeID int,
    @ReportID int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		--INSERT INTO EmpReportsAccessUsers (EmployeeID,ReportID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @EmployeeID,@ReportID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		--  FROM users 
		--WHERE ID <> 1 AND ID <> @CreatedBy
		--AND ID NOT IN (SELECT ReportAccessBy FROM EmpReportsAccessUsers 
		--WHERE ReportID = @ReportID and ReportID <> 0);
		 
		----User who created report should have all rights
		--INSERT INTO EmpReportsAccessUsers (EmployeeID,ReportID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @EmployeeID,@ReportID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		--  FROM users 
		--WHERE ID = @CreatedBy;

		INSERT INTO EmpReportsAccessByRole (EmployeeID,ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @EmployeeID,@ReportID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId NOT IN (SELECT ReportAccessRole FROM EmpReportsAccessByRole 
		WHERE ReportID = @ReportID and ReportID <> 0)  AND RoleId <> (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 

		--Administrator should have all rights
		INSERT INTO EmpReportsAccessByRole (EmployeeID,ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @EmployeeID,@ReportID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId = (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AddAll_UsersAndRoles_EventsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AddAll_UsersAndRoles_EventsAccess]
(
    @EventID int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 

		INSERT INTO EventsAccessByRole (EventID,EventAccessRole,CreatedBy,CreatedDate,ViewEvent,EditEvent,DeleteEvent)
		SELECT @EventID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewEvent,0 AS EditEvent, 0 AS DeleteEvent
		  FROM ManageRoles 
		WHERE RoleId NOT IN (SELECT EventAccessRole FROM EventsAccessByRole 
		WHERE EventID = @EventID and EventID <> 0) AND RoleId <> (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 

		--Administrator should have all rights
		INSERT INTO EventsAccessByRole (EventID,EventAccessRole,CreatedBy,CreatedDate,ViewEvent,EditEvent,DeleteEvent)
		SELECT @EventID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewEvent,1 AS EditEvent, 1 AS DeleteEvent
		  FROM ManageRoles 
		WHERE RoleId = (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT > 0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[AddAll_UsersAndRoles_GenSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddAll_UsersAndRoles_GenSubReportsAccess]
(
    @ReportID int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 

		INSERT INTO GenSubReportsAccessByRole (ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @ReportID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId NOT IN (SELECT ReportAccessRole FROM SubReportsAccessByRole 
		WHERE ReportID = @ReportID and ReportID <> 0) AND RoleId <> (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 

		--Administrator should have all rights
		INSERT INTO GenSubReportsAccessByRole (ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @ReportID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId = (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT > 0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddAll_UsersAndRoles_SubjectAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddAll_UsersAndRoles_SubjectAccess]
(
    @SubjectID int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		--INSERT INTO SubjectAccessUsers (SubjectID,ReportAccessBy,CreatedBy,CreatedDate,
		--ViewReport,EditReport,DeleteReport)
		--SELECT @SubjectID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		--  FROM users 
		--WHERE ID <> 1 AND ID <> @CreatedBy
		--AND ID NOT IN (SELECT ReportAccessBy FROM SubjectAccessUsers 
		--WHERE SubjectID = @SubjectID ); 

		----User who created report should have all rights
		--INSERT INTO SubjectAccessUsers (SubjectID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @SubjectID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		--  FROM users 
		--WHERE ID = @CreatedBy;

		INSERT INTO SubjectAccessByRole (SubjectID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @SubjectID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId NOT IN (SELECT ReportAccessRole FROM SubjectAccessByRole 
		WHERE SubjectID = @SubjectID ) AND RoleId <> (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 

		--Administrator should have all rights
		INSERT INTO SubjectAccessByRole (SubjectID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @SubjectID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId = (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddAll_UsersAndRoles_SubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddAll_UsersAndRoles_SubReportsAccess]
(
    @SubjectID int,
    @ReportID int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		--INSERT INTO SubReportsAccessUsers (SubjectID,ReportID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @SubjectID,@ReportID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		--  FROM users 
		--WHERE ID <> 1 AND ID <> @CreatedBy
		--AND ID NOT IN (SELECT ReportAccessBy FROM SubReportsAccessUsers 
		--WHERE ReportID = @ReportID and ReportID <> 0); 

		----User who created report should have all rights
		--INSERT INTO SubReportsAccessUsers (SubjectID,ReportID,ReportAccessBy,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		--SELECT @SubjectID,@ReportID,ID,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		--  FROM users 
		--WHERE ID = @CreatedBy;

		INSERT INTO SubReportsAccessByRole (SubjectID,ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @SubjectID,@ReportID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId NOT IN (SELECT ReportAccessRole FROM SubReportsAccessByRole 
		WHERE ReportID = @ReportID and ReportID <> 0) AND RoleId <> (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 

		--Administrator should have all rights
		INSERT INTO SubReportsAccessByRole (SubjectID,ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
		SELECT @SubjectID,@ReportID,RoleId,@CreatedBy,getdate() AS CreatedDate,1 AS ViewReport,1 AS EditReport, 1 AS DeleteReport
		  FROM ManageRoles 
		WHERE RoleId = (SELECT RoleId FROM ManageRoles WHERE RoleName = 'Administrator'); 
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AddressType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[AddressType_Delete](          
@Id int          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Delete from AddressType where Id=@Id           
   Select @@RowCount as RESULT           
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 
GO
/****** Object:  StoredProcedure [dbo].[AddressType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddressType_IU](          
@Id int,          
@AddressType nvarchar(200)          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM AddressType  where Id=@Id)            
   begin            
   update AddressType set AddressType=@AddressType where Id=@Id            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into AddressType(AddressType) values(@AddressType)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[AddressType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[AddressType_Load]          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Select * from AddressType          
   Select @@RowCount as RESULT          
  End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[AddRolesEmployeeAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddRolesEmployeeAccess]
(
@EmployeeID int,
@ReportAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EmployeeAccessByRole (EmployeeID,ReportAccessRole,CreatedBy,CreatedDate)
			values(@EmployeeID,@ReportAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddRolesEventReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddRolesEventReportsAccess]
(
@EventID int,
@ReportAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EventReportsAccessByRole (EventID,ReportAccessRole,CreatedBy,CreatedDate)
			values(@EventID,@ReportAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddRolesEventsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AddRolesEventsAccess]
(
@EventID int,
@EventAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EventsAccessByRole (EventID,EventAccessRole,CreatedBy,CreatedDate)
			values(@EventID,@EventAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[AddRolesGenSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddRolesGenSubReportsAccess]
(
@ReportID int,
@ReportAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO GenSubReportsAccessByRole (ReportID,ReportAccessRole,CreatedBy,CreatedDate)
			values(@ReportID,@ReportAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddRolesReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddRolesReportsAccess]
(
@EmployeeID int,
@ReportID int,
@ReportAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EmpReportsAccessByRole (EmployeeID,ReportID,ReportAccessRole,CreatedBy,CreatedDate)
			values(@EmployeeID,@ReportID,@ReportAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AddRolesSubjectAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddRolesSubjectAccess]
(
@SubjectID int,
@ReportAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO SubjectAccessByRole (SubjectID,ReportAccessRole,CreatedBy,CreatedDate)
			values(@SubjectID,@ReportAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddRolesSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddRolesSubReportsAccess]
(
@SubjectID int,
@ReportID int,
@ReportAccessRole int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO SubReportsAccessByRole (SubjectID,ReportID,ReportAccessRole,CreatedBy,CreatedDate)
			values(@SubjectID,@ReportID,@ReportAccessRole,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AddUsersEmployeeAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddUsersEmployeeAccess]
(
@EmployeeID int,
@ReportAccessBy int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EmployeeAccessUsers (EmployeeID,ReportAccessBy,CreatedBy,CreatedDate)
			values(@EmployeeID,@ReportAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddUsersEventReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddUsersEventReportsAccess]
(
@EventID int,
@ReportAccessBy int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EventReportsAccessUsers (EventId,ReportAccessBy,CreatedBy,CreatedDate)
			values(@EventID,@ReportAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddUsersEventsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AddUsersEventsAccess]
(
    @EventID int,
    @EventAccessBy int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EventsAccessUsers (EventID,EventAccessBy,CreatedBy,CreatedDate)
			values(@EventID,@EventAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[AddUsersGenSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddUsersGenSubReportsAccess]
(
    @ReportID int,
    @ReportAccessBy int,
    @CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO GenSubReportsAccessUsers (ReportID,ReportAccessBy,CreatedBy,CreatedDate)
			values(@ReportID,@ReportAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddUsersReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddUsersReportsAccess]
(
@EmployeeID int,
@ReportID int,
@ReportAccessBy int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO EmpReportsAccessUsers (EmployeeID,ReportID,ReportAccessBy,CreatedBy,CreatedDate)
			values(@EmployeeID,@ReportID,@ReportAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AddUsersSubjectAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddUsersSubjectAccess]
(
@SubjectID int,
@ReportAccessBy int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO SubjectAccessUsers (SubjectID,ReportAccessBy,CreatedBy,CreatedDate)
			values(@SubjectID,@ReportAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[AddUsersSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddUsersSubReportsAccess]
(
@SubjectID int,
@ReportID int,
@ReportAccessBy int,
@CreatedBy int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		INSERT INTO SubReportsAccessUsers (SubjectID,ReportID,ReportAccessBy,CreatedBy,CreatedDate)
			values(@SubjectID,@ReportID,@ReportAccessBy,@CreatedBy,getdate())
		Select @@identity as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[AdvancedSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AdvancedSearch]
(  
@AddressType nvarchar(max)=null,
@Apartment nvarchar(max)=null,  
@Address nvarchar(max)=null,
@country nvarchar(max)=null,  
@city nvarchar(max)=null,  
@state nvarchar(max)=null,  
@zipCode nvarchar(max)=null,
@phone nvarchar(max)=null,
@dateOfHire date=null,
@terminationDate date=null ,
@licenseExpirationDate date=null,
@department nvarchar(max)=null ,
@licenseType nvarchar(max)=null,
@licenseStatus nvarchar(max)=null ,
@type nvarchar(20) = 'A'
)  
AS  
BEGIN  

Declare @SQL nvarchar(max)  

if @type = 'A'
begin

Set @SQL='Select FirstName,LastName,e.EmployeeID,EmpNumber,ms.sex as sex,(select Top(1) PV.FilePath from EmployeePicturesVideos EPV    
 left join PicturesVideos PV on EPV.MediaID = PV.MediaID     
 where EPV.MediaType=''Employee'' and EmployeeID = e.EmployeeID) as FilePath,e.CreatedDate  from EmployeeAddress as ea
inner join Employees e on e.EmployeeID = ea.EmployeeID
 left outer join AddressType as at on at.ID = ea.AddressType 
 left outer join Countries c on c.id = ea.CountryID
 left Outer join MasterSex ms on ms.id = e.sex
  where 1=1 '  
   

 if(@AddressType is not null)  
  Set @SQL=@SQL+'and ea.AddressType = '''+@AddressType+''''  
  
 if(@Apartment is not null)  
  Set @SQL=@SQL+'and Apartment like '''+@Apartment+'%'''  
    
  if(@Address is not null)  
  Set @SQL=@SQL+'and Address like '''+@Address+'%'''  
    
  if(@country is not null)  
  Set @SQL=@SQL+'and CountryID = '''+@country+''''
    
  if(@city is not null)  
  Set @SQL=@SQL+'and City like '''+@city+''''
  
  if(@state is not null)  
  Set @SQL=@SQL+'and ProvState like '''+@state+'''' 
      
  if(@zipCode is not null)  
  Set @SQL=@SQL+'and PostalZip like '''+@zipCode+''''  
    
  if(@phone is not null)  
  Set @SQL=@SQL+'and Phone like '''+@phone+'''' 
    

	Set @SQL=@SQL+' order by ModifiedDate desc' 

end
else
begin

Set @SQL='Select FirstName,LastName,e.EmployeeID,EmpNumber,(select Top(1) PV.FilePath from EmployeePicturesVideos EPV    
 left join PicturesVideos PV on EPV.MediaID = PV.MediaID     
 where EPV.MediaType=''Employee'' and EmployeeID = e.EmployeeID) as FilePath,e.CreatedDate  from EmployeeLicense EL
 inner join Employees e on e.EmployeeID = el.EmployeeID
left outer join MasterLicenseType LT on LT.id = EL.LicenseType
left Outer Join MasterLicenseStatus LS on LS.ID = EL.LicenseStatus
left Outer join MasterDepartmentType DT on DT.id = EL.Department
where 1=1 '  
   

 if(@dateOfHire is not null)  
  Set @SQL=@SQL+'and cast(DateOfHire as date) = '''+ cast(@dateOfHire as nvarchar) +''''  
  
 if(@terminationDate is not null)  
  Set @SQL=@SQL+'and cast(TerminationDate as date) = '''+cast(@terminationDate as nvarchar)+''''  
    
  if(@licenseExpirationDate is not null)  
  Set @SQL=@SQL+'and cast(LicenseExpirationDate as date) = '''+cast(@licenseExpirationDate as nvarchar)+''''  
    
  if(@department is not null)  
  Set @SQL=@SQL+'and Department = '''+@department+''''
    
  if(@licenseType is not null)  
  Set @SQL=@SQL+'and EL.LicenseType = '''+@licenseType+''''
  
  if(@licenseStatus is not null)  
  Set @SQL=@SQL+'and EL.LicenseStatus = '''+@licenseStatus+'''' 
    
	
	      
  end

  print @SQL
    execute(@SQL)

 END

GO
/****** Object:  StoredProcedure [dbo].[AdvancedSearchEmployees]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AdvancedSearchEmployees]
(  
@EmpNumber nvarchar(25)=null,
@FirstName nvarchar(25)=null,  
@MiddleName nvarchar(25)=null,
@LastName nvarchar(25)=null,  
@Sex nvarchar(10)=null,  
@Race nvarchar(25)=null,  
@Complexion nvarchar(15)=null,
@Eyes nvarchar(10)=null,
@Build nvarchar(15)=null,
@Glasses nvarchar(10)=null ,
@Height nvarchar(10)=null ,
@StaffPosition nvarchar(10)=null ,
@Weight nvarchar(10)=null 
)  
AS  
BEGIN  
Declare @SQL nvarchar(max)  
Set @SQL='Select FirstName,LastName,EmployeeID,MiddleName,EmpNumber,ms.sex as sex,(select Top(1) PV.FilePath from EmployeePicturesVideos EPV    
 left join PicturesVideos PV on EPV.MediaID = PV.MediaID     
 where EPV.MediaType=''Employee'' and EmployeeID = Employees.EmployeeID) as FilePath,CreatedDate  from Employees  
  left Outer join MasterSex ms on ms.id = Employees.sex
 where 1=1 '  
   
 if(@EmpNumber is not null)  
  Set @SQL=@SQL+'and EmpNumber like '''+@EmpNumber+'%'''  
  
 if(@FirstName is not null)  
  Set @SQL=@SQL+'and FirstName like '''+@FirstName+'%'''  
    
  if(@LastName is not null)  
  Set @SQL=@SQL+'and LastName like '''+@LastName+'%'''  
    
  if(@Sex is not null)  
  Set @SQL=@SQL+'and Employees.Sex = '''+@Sex+''''
    
  if(@Race is not null)  
  Set @SQL=@SQL+'and Race = '''+@Race+''''
  
  if(@Complexion is not null)  
  Set @SQL=@SQL+'and Complexion = '''+@Complexion+'''' 
      
  if(@Eyes is not null)  
  Set @SQL=@SQL+'and Eyes = '''+@Eyes+''''  
    
   if(@Build is not null)  
  Set @SQL=@SQL+'and Build = '''+@Build+'''' 
    
   if(@Glasses is not null)  
  Set @SQL=@SQL+'and Glasses = '''+@Glasses+'''' 
    
   if(@MiddleName is not null)  
  Set @SQL=@SQL+'and MiddleName like ''%'+@MiddleName+'%''' 

   if(@Height is not null)  
  Set @SQL=@SQL+'and Height = '''+@Height+'''' 

  if(@Weight is not null)  
  Set @SQL=@SQL+'and Weight = '''+@Weight+'''' 

  if(@StaffPosition is not null)  
  Set @SQL=@SQL+'and StaffPosition = '''+@StaffPosition+'''' 
    
 -- print(@SQL)  
  execute(@SQL)  
 END

GO
/****** Object:  StoredProcedure [dbo].[AdvancedSearchsubject]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AdvancedSearchsubject]
(  
	@Apartment nvarchar(max)=null,  
	@Address nvarchar(max)=null,
	@city nvarchar(max)=null,  
	@state nvarchar(max)=null,  
	@zipCode nvarchar(max)=null,
	@AddressType nvarchar(max)=null,
	@country nvarchar(max)=null,  
	@NameType nvarchar(max)=null,  
	@FirstName nvarchar(max)=null, 
	@MiddleName nvarchar(max)=null, 
	@LastName nvarchar(max)=null, 
	@type nvarchar(20) = 'A'
)  
AS  
BEGIN  

Declare @SQL nvarchar(max)  

if @state = '0'
begin

	set @state = null;

end

if @type = 'A'
begin

Set @SQL=' SELECT s.SubjectID, FirstName,MiddleName, LastName,VIP,(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = s.SubjectID) as FilePath,s.ModifiedDate 
from subjectAddress as ea
inner join Subjects as s on s.SubjectID = ea.SubjectID
left outer join AddressType as at on at.ID = ea.AddressType 
left outer join Countries c on c.id = ea.CountryID
left outer join Cities	cc on cc.id = ea.City
where 1=1 '  
   

 if(@Apartment is not null)  
  Set @SQL=@SQL+'and ea.Apartment like ''%'+@Apartment+'%'''  
  
 if(@Address is not null)  
  Set @SQL=@SQL+'and Address like ''%'+@Address+'%'''  
    
  if(@city is not null)  
  Set @SQL=@SQL+'and City = '''+@city +''''  
    
  if(@state  is not null)  
  Set @SQL=@SQL+'and ProvState = '''+@state +''''
    
  if(@zipCode is not null)  
  Set @SQL=@SQL+'and PostalZip = '''+@zipCode +''''
  
  if(@AddressType  is not null)  
  Set @SQL=@SQL+'and ea.AddressType = '''+@AddressType +'''' 
      
  if(@country  is not null)  
  Set @SQL=@SQL+'and CountryID = '''+@country +''''  
   

	--Set @SQL=@SQL+' order by ModifiedDate desc' 

end
else
begin

Set @SQL=' SELECT s.SubjectID, s.FirstName,s.MiddleName, s.LastName,s.VIP,(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = s.SubjectID) as FilePath,s.ModifiedDate
  from subjectAlias EL
  inner join Subjects as s on s.SubjectID = EL.SubjectID
left outer join AliasNameType LT on LT.id = EL.NameType
where 1=1 '  
    
  if(@NameType is not null)  
  Set @SQL=@SQL+'and EL.NameType = '''+@NameType+''''
    
  if(@FirstName is not null)  
  Set @SQL=@SQL+'and EL.FirstName = ''%'+@FirstName+'%'''
  
  if(@MiddleName is not null)  
  Set @SQL=@SQL+'and EL.MiddleName = ''%'+@MiddleName+'%''' 

  if(@LastName is not null)  
  Set @SQL=@SQL+'and EL.LastName = ''%'+@LastName+'%'''
  	      
  end

  print @SQL
    execute(@SQL)

 END

GO
/****** Object:  StoredProcedure [dbo].[AdvancedSearchSubjectFeature]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AdvancedSearchSubjectFeature]
(  
 @FeatureType nvarchar(max) = null,  
 @FeatureLocation nvarchar(max) = null,
 @type varchar(2) = null,
 @watchid int = null
)  
AS
BEGIN

if(@type = 'w')
begin
	Select
	 s.SubjectID, FirstName, MiddleName,LastName,VIP,(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
			left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = s.SubjectID) as FilePath,ModifiedDate
	from SubjectWatch as w
	inner join Subjects as s on s.SubjectID = w.SubjectID
	inner join  WatchNames wn on w.WatchName = wn.watchID
	inner join Masterwatch mw on mw.watch = wn.watchname
	where mw.id=@watchid 

end
else
begin

	Select
	 s.SubjectID, FirstName, MiddleName,LastName,VIP,(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
			left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = s.SubjectID) as FilePath,ModifiedDate
	from subjectMarks as ea
	inner join Subjects as s on s.SubjectID = ea.SubjectID
	left outer join FeatureType as at on at.Id = ea.FeatureType
	left outer join FeatureLocation c on c.Id = ea.FeatureLocation
	where ea.FeatureLocation=@FeatureLocation and ea.FeatureType=@FeatureType


end




END
GO
/****** Object:  StoredProcedure [dbo].[AliasNameType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[AliasNameType_Delete](          
@Id int          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Delete from AliasNameType where Id=@Id           
   Select @@RowCount as RESULT           
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 
GO
/****** Object:  StoredProcedure [dbo].[AliasNameType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AliasNameType_IU](
@Id int,          
@NameType nvarchar(200)          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM AliasNameType  where Id=@Id)            
   begin            
   update AliasNameType set NameType=@NameType where Id=@Id            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into AliasNameType(NameType) values(@NameType)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[AliasNameType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[AliasNameType_Load]          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Select * from AliasNameType          
   Select @@RowCount as RESULT          
  End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[AssignToPicture]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AssignToPicture]
(
@MediaID int=0,
@SubFeatureID int=0,
@PictureType nvarchar(50)
)
as
Begin

	--if @PictureType = 'vehicle'
	--begin

	--	if exists (select 1 from PicturesVideos where PictureType=@PictureType  and SubFeatureID=@SubFeatureID)
	--	begin
	--		update PicturesVideos set PictureType='Media',SubFeatureID=0 where PictureType=@PictureType and SubFeatureID=@SubFeatureID
	--	end

	--	update PicturesVideos set PictureType=@PictureType,SubFeatureID=@SubFeatureID where MediaID=@MediaID 

	--end
	--else
	--begin

	update PicturesVideos set PictureType=@PictureType,SubFeatureID=@SubFeatureID where MediaID=@MediaID 

	--end

   select @@rowcount as result
end
GO
/****** Object:  StoredProcedure [dbo].[AttachEvent_U]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AttachEvent_U] -- 1,'12:40 PM','12:40 PM','Area','Dispatch Priority','Units','naina','naina','12:40 PM'
(  

@EventID int=0,   
@EventNumber int=0,
@AttachedEvent int=0
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
  
			 Begin  
			 Update EventLog set AttachedEvent=@AttachedEvent where EventNumber=@EventNumber 
				select @@RowCount
			 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  
GO
/****** Object:  StoredProcedure [dbo].[Audit_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Procedure [dbo].[Audit_Delete](          
@QuestionId int          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin
    Delete from AuditsQuestions where AuditID = @QuestionId;
   Delete from AuditQuestions where QuestionId=@QuestionId           
   Select @@RowCount as RESULT           
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 
GO
/****** Object:  StoredProcedure [dbo].[Audit_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Audit_IU](
@QuestionId int,          
@AuditType nvarchar(50),
@Question nvarchar(450),
@ScoreType bit          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM AuditQuestions  where QuestionId=@QuestionId)            
   begin            
   update AuditQuestions set AuditType=@AuditType,Question=@Question,ScoreType=@ScoreType where QuestionId=@QuestionId            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into AuditQuestions(AuditType,Question,ScoreType) values(@AuditType,@Question,@ScoreType)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[Audit_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Procedure [dbo].[Audit_Load]          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Select * from AuditQuestions          
   Select @@RowCount as RESULT          
  End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[BanAuthorizedBy_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BanAuthorizedBy_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from BanAuthorizedBy where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[BanAuthorizedBy_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[BanAuthorizedBy_IU](        
@Id int,        
@AuthorizedBy nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM BanAuthorizedBy  where Id=@Id)          
   begin          
   update BanAuthorizedBy set AuthorizedBy=@AuthorizedBy where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into BanAuthorizedBy(AuthorizedBy) values(@AuthorizedBy)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[BanAuthorizedBy_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[BanAuthorizedBy_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from BanAuthorizedBy        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[Banned_LoadByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Banned_LoadByID]    
@BannedId int=0    
As    
BEGIN    
SELECT BannedID, IncidentID,StartDate, EndDate, EntryDate, AuthorizedBy, Description, BanYears, BanMonths, BanDays,
MSTTypeOfBan.TypeOfBan,BanTypeId 
FROM Banned 
LEFT JOIN MSTTypeOfBan ON Banned.BanTypeId = MSTTypeOfBan.Id
WHERE BannedId=@BannedId  
END

GO
/****** Object:  StoredProcedure [dbo].[Banned_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Banned_LoadByIncidentID]    
@IncidentId int=0    
As    
BEGIN    
SELECT BannedID,IncidentID,StartDate, EndDate, EntryDate, BA.AuthorizedBy, Description, BanYears, BanMonths, BanDays,
MSTTypeOfBan.TypeOfBan 
FROM Banned 
LEFT JOIN MSTTypeOfBan ON Banned.BanTypeId = MSTTypeOfBan.Id
LEFT JOIN BanAuthorizedBy AS BA ON Banned.AuthorizedBy = BA.Id
WHERE IncidentID=@IncidentId  
END
GO
/****** Object:  StoredProcedure [dbo].[BannedPictures]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BannedPictures] --'Prohibited','2016-08-21 00:00:00.000','2016-08-27 00:00:00.000'
(
@BanName nvarchar(500),
@StartDate datetime,
@EndDate datetime
)
as
begin
declare @sql nvarchar(max)

 set @sql='SELECT Subjects.SubjectID, Subjects.LastName, Subjects.FirstName, Subjects.MiddleName, 
Subjects.Sex, Subjects.Race, Subjects.Status, SubjectBanType.BanName, Banned.StartDate, Banned.EndDate,
(SELECT TOP 1 PicturesVideos.FilePath FROM PicturesVideos,
 SubjectPicturesVideos WHERE PicturesVideos.MediaID = SubjectPicturesVideos.MediaID
  AND (NOT SubjectPicturesVideos.MediaType IN (''Involved'', ''Dispute'', ''Vehicles'')) 
  AND PicturesVideos.MediaExtention = ''jpg'' AND SubjectPicturesVideos.SubjectID = Subjects.SubjectID
 ORDER BY PicturesVideos.DefaultPic DESC, SubjectPicturesVideos.MediaType DESC) as Picture
 FROM Banned
 INNER JOIN SubjectIncidents ON Banned.IncidentID = SubjectIncidents.IncidentID
 INNER JOIN Subjects ON SubjectIncidents.SubjectID = Subjects.SubjectID 
 INNER JOIN SubjectBanType ON Banned.IncidentID = SubjectBanType.IncidentID
 Where SubjectBanType.BanName In ('''+@BanName+''') AND Banned.EndDate Between '''+convert(nvarchar,@StartDate,101)+''' AND '''+convert(nvarchar,@EndDate,101)+'''
 ORDER BY Subjects.LastName'

 execute(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[BanTypes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[BanTypes]

as
begin
	SELECT Description FROM Codes WHERE Part = 'Ban Types' ORDER BY Sequence
end
GO
/****** Object:  StoredProcedure [dbo].[Build_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Build_Delete](  
@Id int  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Delete from Build where Id=@Id   
	  Select @@RowCount as RESULT   
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[Build_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Build_IU](  
@Id int,  
@Build nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM Build  where Id=@Id)    
   begin    
   update Build set Build=@Build where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into Build(Build) values(@Build)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[Build_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Build_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from Build  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[CashierName_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[CashierName_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from CashierName where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[CashierName_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
Create Procedure [dbo].[CashierName_IU](        
@Id int,        
@CashierName nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM CashierName  where Id=@Id)          
   begin          
   update CashierName set CashierName=@CashierName where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into CashierName(CashierName) values(@CashierName)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[CashierName_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[CashierName_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from CashierName        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[CheckDuplicateUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CheckDuplicateUser] --'naina@nextolive.com',123456      
(      
    @UserName nvarchar(100) = null,
    @ID int = null
)      
AS       
BEGIN      
  
 Begin Try      
  Begin Transaction      
  begin      
   if(Exists (select * from Users where UserName = @UserName AND (@ID IS NULL OR @ID <> ID)))      
    Begin       
     select 1     
     end      
    end 
  COMMIT TRANSACTION              
 End try      
 Begin Catch      
  IF @@TRANCOUNT >0                    
   rollback Transaction      
 End Catch      
END
GO
/****** Object:  StoredProcedure [dbo].[Cities_LoadByStates]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Cities_LoadByStates]
(
@StateID int=0
)
as
begin
	select * from Cities where StateID=@StateID
end
GO
/****** Object:  StoredProcedure [dbo].[Codes_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Codes_LoadAll]   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from Codes where Part = 'Status'
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[Codes_LoadByPart]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Codes_LoadByPart]
(
@Part nvarchar(30)
)
As
Begin
SELECT * FROM Codes WHERE Part =@Part Order By Sequence
End
GO
/****** Object:  StoredProcedure [dbo].[CombineEmployee]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CombineEmployee]     
@CurrentEmployeeID int =0 ,
@CombineEmployeeID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin
	Declare @tempdata1 nvarchar(200) =null;
	Declare @tempdata2 int = 0;
	Declare @tempdata3 bit ='false';
	Declare @tempdata4 float =0;
	Declare @tempdata5 datetime = null;
			set @tempdata1 = (select  EmpNumber from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set EmpNumber = (select  EmpNumber from Employees where EmployeeID = @CombineEmployeeID) 
				where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata4 = (select  Age from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata4 is null)
			Begin
				Update Employees set Age = (select  Age from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Sex from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Sex = (select  Sex from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Race from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Race = (select  Race from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  LastName from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set LastName = (select  LastName from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  FirstName from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set FirstName = (select  FirstName from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  MiddleName from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set MiddleName = (select  MiddleName from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Height from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Height = (select  Height from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Weight from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Weight = (select  Weight from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata5 = (select  DateOfBirth from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata5 is null)
			Begin
				Update Employees set DateOfBirth = (select  DateOfBirth from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  StaffPosition from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set StaffPosition = (select  StaffPosition from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Eyes from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Eyes = (select  Eyes from Employees where EmployeeID = @CombineEmployeeID) 
				where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Complexion from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Complexion = (select  Complexion from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Build from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Build = (select  Build from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Glasses from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Glasses = (select  Glasses from Employees where EmployeeID = @CombineEmployeeID) 
				where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata3 = (select  Restricted from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata3 is null)
			Begin
				Update Employees set Restricted = (select  Restricted from Employees where EmployeeID = @CombineEmployeeID) 
				where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  Status from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set Status = (select  Status from Employees where EmployeeID = @CombineEmployeeID) 
				where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata1 = (select  RoleName from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata1 is null)
			Begin
				Update Employees set RoleName = (select  RoleName from Employees where EmployeeID = @CombineEmployeeID) 
				where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata3 = (select  UD9 from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata3 is null)
			Begin
				Update Employees set UD9 = (select  UD9 from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			set @tempdata2 = (select  UserID from Employees where EmployeeID = @CurrentEmployeeID)
			if(@tempdata2 is null)
			Begin
				Update Employees set UserID = (select  UserID from Employees where EmployeeID = @CombineEmployeeID)
				 where EmployeeID = @CurrentEmployeeID
			End
			-----combine Employee License
		    if(not exists (select * from EmployeeLicense where EmployeeID = @CurrentEmployeeID))
			Begin
				UPDATE EmployeeLicense SET EmployeeID = @CurrentEmployeeID WHERE EmployeeID =  @CombineEmployeeID
			End
			Else
			Begin
				set @tempdata5 = (select  DateOfHire from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata5 is null)
				Begin
					Update EmployeeLicense set DateOfHire = (select  DateOfHire from EmployeeLicense where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata5 = (select  TerminationDate from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata5 is null)
				Begin
					Update EmployeeLicense set TerminationDate = (select  TerminationDate from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata5 = (select  LicenseExpirationDate from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata5 is null)
				Begin
					Update EmployeeLicense set LicenseExpirationDate = (select  LicenseExpirationDate from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  Department from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set Department = (select  Department from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  LicenseType from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set LicenseType = (select  LicenseType from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  LicenseStatus from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set LicenseStatus = (select  LicenseStatus from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  ReasonForLeaving from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set ReasonForLeaving = (select  ReasonForLeaving from EmployeeLicense where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD16 from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set UD16 = (select  UD16 from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD17 from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set UD17 = (select  UD17 from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD18 from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set UD18 = (select  UD18 from EmployeeLicense where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD19 from EmployeeLicense where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeeLicense set UD19 = (select  UD19 from EmployeeLicense where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				--DELETE FROM EmployeeLicense WHERE EmployeeID = @CombineEmployeeID
			End
			--DELETE FROM Employees WHERE EmployeeID = @CombineEmployeeID

			-----combine Employee Personal
			if(not exists (select * from EmployeePersonal where EmployeeID = @CurrentEmployeeID))
			Begin
				UPDATE EmployeePersonal SET EmployeeID = @CurrentEmployeeID WHERE EmployeeID =  @CombineEmployeeID
			End
			Else
			Begin
				set @tempdata1 = (select  UD10 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set UD10 = (select  UD10 from EmployeePersonal where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD11 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set UD11 = (select  UD11 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD12 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set UD12 = (select  UD12 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD13 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set UD13 = (select  UD13 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD14 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set UD14 = (select  UD14 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  UD15 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set UD15 = (select  UD15 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  IDType1 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set IDType1 = (select  IDType1 from EmployeePersonal where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata3 = (select  IDNumber1 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata3 is null)
				Begin
					Update EmployeePersonal set IDNumber1 = (select  IDNumber1 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata2 = (select  IDDefault1 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata2 is null)
				Begin
					Update EmployeePersonal set IDDefault1 = (select  IDDefault1 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  IDType2 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set IDType2 = (select  IDType2 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata3 = (select  IDNumber2 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata3 is null)
				Begin
					Update EmployeePersonal set IDNumber2 = (select  IDNumber2 from EmployeePersonal where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata3 = (select  IDDefault2 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata3 is null)
				Begin
					Update EmployeePersonal set IDDefault2 = (select  IDDefault2 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata1 = (select  IDType3 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata1 is null)
				Begin
					Update EmployeePersonal set IDType3 = (select  IDType3 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata3 = (select  IDNumber3 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata3 is null)
				Begin
					Update EmployeePersonal set IDNumber3 = (select  IDNumber3 from EmployeePersonal where EmployeeID = @CombineEmployeeID)
					 where EmployeeID = @CurrentEmployeeID
				End
				set @tempdata3 = (select  IDDefault3 from EmployeePersonal where EmployeeID = @CurrentEmployeeID)
				if(@tempdata3 is null)
				Begin
					Update EmployeePersonal set IDDefault3 = (select  IDDefault3 from EmployeePersonal where EmployeeID = @CombineEmployeeID) 
					where EmployeeID = @CurrentEmployeeID
				End
				--DELETE FROM EmployeePersonal WHERE EmployeeID = @CombineEmployeeID
			End
			--------------
			--DELETE FROM Employees WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmpEmployeeIncidents SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmployeeAddress SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmployeeInvolved SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmployeeLinked SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmployeePhone SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmployeePicturesVideos SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			UPDATE EmployeeAddress SET EmployeeID = @CurrentEmployeeID  WHERE EmployeeID = @CombineEmployeeID
			select 1
	End 
  COMMIT TRANSACTION 
 End try 
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[CombineSubject]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CombineSubject]     
@CurrentSubjectID int =0 ,
@CombineSubjectID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin
	Declare @tempdata1 nvarchar(200) =null;
	Declare @tempdata2 int = 0;
	Declare @tempdata3 bit ='false';
	Declare @tempdata4 float =0;
	Declare @tempdata5 datetime = null;
			set @tempdata1 = (select  VIP from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set VIP = (select  VIP from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata4 = (select  Age from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata4 is null)
			Begin
				Update Subjects set Age = (select  Age from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Sex from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Sex = (select  Sex from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Race from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Race = (select  Race from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  LastName from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set LastName = (select  LastName from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  FirstName from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set FirstName = (select  FirstName from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  MiddleName from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set MiddleName = (select  MiddleName from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Height from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Height = (select  Height from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Weight from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Weight = (select  Weight from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata5 = (select  DateOfBirth from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata5 is null)
			Begin
				Update Subjects set DateOfBirth = (select  DateOfBirth from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  HairColor from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set HairColor = (select  HairColor from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Eyes from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Eyes = (select  Eyes from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Complexion from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Complexion = (select  Complexion from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Build from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Build = (select  Build from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  FacialHair from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set FacialHair = (select  FacialHair from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  HairLength from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set HairLength = (select  HairLength from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Glasses from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Glasses = (select  Glasses from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata3 = (select  Restricted from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata3 is null)
			Begin
				Update Subjects set Restricted = (select  Restricted from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  Status from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set Status = (select  Status from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata1 = (select  RoleName from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata1 is null)
			Begin
				Update Subjects set RoleName = (select  RoleName from Subjects where SubjectID = @CombineSubjectID) 
				where SubjectID = @CurrentSubjectID
			End
			set @tempdata3 = (select  CIDSubject from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata3 is null)
			Begin
				Update Subjects set CIDSubject = (select  CIDSubject from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			set @tempdata2 = (select  CIDPersonID from Subjects where SubjectID = @CurrentSubjectID)
			if(@tempdata2 is null)
			Begin
				Update Subjects set CIDPersonID = (select  CIDPersonID from Subjects where SubjectID = @CombineSubjectID)
				 where SubjectID = @CurrentSubjectID
			End
			-----combine subject identification
		    if(not exists (select * from SubjectIdentification where SubjectID = @CurrentSubjectID))
			Begin
				UPDATE SubjectIdentification SET SubjectID = @CurrentSubjectID WHERE SubjectID =  @CombineSubjectID
			End
			Else
			Begin
				set @tempdata1 = (select  Occupation from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set Occupation = (select  Occupation from SubjectIdentification where SubjectID = @CombineSubjectID)
					 where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  BusinessName from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set BusinessName = (select  BusinessName from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  IDType1 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set IDType1 = (select  IDType1 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  IDNumber1 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set IDNumber1 = (select  IDNumber1 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata3 = (select  IDDefault1 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata3 is null)
				Begin
					Update SubjectIdentification set IDDefault1 = (select  IDDefault1 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  IDType2 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set IDType2 = (select  IDType2 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  IDNumber2 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set IDNumber2 = (select  IDNumber2 from SubjectIdentification where SubjectID = @CombineSubjectID)
					 where SubjectID = @CurrentSubjectID
				End
				set @tempdata3 = (select  IDDefault2 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata3 is null)
				Begin
					Update SubjectIdentification set IDDefault2 = (select  IDDefault2 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  IDType3 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set IDType3 = (select  IDType3 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  IDNumber3 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set IDNumber3 = (select  IDNumber3 from SubjectIdentification where SubjectID = @CombineSubjectID) 
					where SubjectID = @CurrentSubjectID
				End
				set @tempdata3 = (select  IDDefault3 from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata3 is null)
				Begin
					Update SubjectIdentification set IDDefault3 = (select  IDDefault3 from SubjectIdentification where SubjectID = @CombineSubjectID)
					 where SubjectID = @CurrentSubjectID
				End
				set @tempdata1 = (select  LCTID from SubjectIdentification where SubjectID = @CurrentSubjectID)
				if(@tempdata1 is null)
				Begin
					Update SubjectIdentification set LCTID = (select  LCTID from SubjectIdentification where SubjectID = @CombineSubjectID)
					 where SubjectID = @CurrentSubjectID
				End
				--DELETE FROM SubjectIdentification WHERE SubjectID = @CombineSubjectID
			End
			--DELETE FROM Subjects WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectAddress SET SubjectID = @CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectPhone SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectAlias SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectInvolved SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectInvolved SET InvolvedID =@CurrentSubjectID WHERE InvolvedID = @CombineSubjectID
			UPDATE SubjectBanType SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectIncidents SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectMarks SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectPicturesVideos SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectServices SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectServicesOffered SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectVehicles SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE SubjectLinked SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE EventLog SET FromNumber = @CurrentSubjectID WHERE FromNumber = @CombineSubjectID AND FromForm = 'Subject'
			UPDATE LCTCashOuts SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE LCTForeignExchange SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE LCTMain SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE LCTPitTransactions SET SubjectID =@CurrentSubjectID WHERE SubjectID = @CombineSubjectID
			UPDATE PicturesVideos SET Assigned =@CurrentSubjectID WHERE PicType = 0 AND Assigned = @CombineSubjectID
			select 1
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[Complexion_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Complexion_Delete](  
@Id int  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Delete from Complexion where Id=@Id   
	  Select @@RowCount as RESULT   
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[Complexion_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Complexion_IU](  
@Id int,  
@Complexion nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM Complexion  where Id=@Id)    
   begin    
   update Complexion set Complexion=@Complexion where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into Complexion(Complexion) values(@Complexion)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[Complexion_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Complexion_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from Complexion  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[ConvertEmployeeToSubject]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[ConvertEmployeeToSubject] --55,'1481361271',1
@ConvertEmployeeID int =0,
@SubjectVIP nvarchar(25),
@CreatedBy int
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin 
     Declare @tempSubID int = 0;
	 Declare @tempMediaID int = 0;
		Insert into Subjects(VIP,Age,Sex,Race,LastName,FirstName,MiddleName,Height,Weight,DateOfBirth,Eyes,Complexion,Build,Glasses,Restricted,ModifiedDate,CreatedBy)
		  values(@SubjectVIP,
				(select top 1 Age from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Sex from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Race from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 LastName from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 FirstName from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 MiddleName from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Height from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Weight from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 DateOfBirth from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Eyes from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Complexion from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Build from Employees where EmployeeID = @ConvertEmployeeID),
				(select top 1 Glasses from Employees where EmployeeID = @ConvertEmployeeID),
				isnull((select  isnull(Restricted,0) from Employees where EmployeeID = @ConvertEmployeeID),0),
				getdate(),
				@CreatedBy)
			Select @@Identity AS RESULT
			set @tempSubID = (select top 1 SubjectID from Subjects where VIP = @SubjectVIP)
			if(@tempSubID>0)
			Begin  
			 Insert into SubjectAddress(SubjectID,Apartment,Address,City,ProvState,PostalZip,AddressType,CountryID,ModifiedDate)
			 values(@tempSubID,
					(select  Apartment from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
					(select  Address from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
				    (select  City from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
				    (select  ProvState from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
				    (select  PostalZip from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
				    (select  AddressType from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
				    (select  CountryID from EmployeeAddress where EmployeeID = @ConvertEmployeeID),
				     getdate())
			 Select @@Identity AS RESULT
			End
			 set @tempSubID = (select  top 1SubjectID from Subjects where VIP = @SubjectVIP)
			 set @tempMediaID=(select top 1 MediaID from EmployeePicturesVideos where EmployeeID = @ConvertEmployeeID)
			if(@tempSubID>0 and @tempMediaID>0)
			Begin  
			 Insert into SubjectPicturesVideos(SubjectID,MediaID,MediaType)
			 values(@tempSubID,
					(select top 1 MediaID from EmployeePicturesVideos where EmployeeID = @ConvertEmployeeID),
					'Employee')
			 Select @@Identity AS RESULT	
			End
			 Update Employees set ConvertSubject='true' where EmployeeID = @ConvertEmployeeID
	End   
   COMMIT TRANSACTION   
  End try   
  Begin Catch           
   IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
  End Catch              
END

GO
/****** Object:  StoredProcedure [dbo].[Corporate_update]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Corporate_update]

	@Corporate_logo nvarchar(max) = NULL,
	@Customer_logo nvarchar(max) = NULL,
	@Corporate_background nvarchar(max) =NULL,
	@Corporate_back_type nvarchar(10) =NULL,
	@Corporate_action nvarchar(10) =NULL

AS
BEGIN


if @Corporate_action = 'get'
begin
if Exists(SELECT 1 FROM Corporate)
 begin
  if Exists(SELECT 1 FROM Corporate)
 begin
  select * from Corporate
 end 
 else
 begin
     select 1 as Corporate_id ,'admin-logo.png' as Corporate_logo,'login-bg.jpg' as Corporate_background,'pic' as Corporate_back_type,'2017-02-05 10:58:14.810' as Corporate_CreatedDate,'customer_cam.png' as Customer_logo
 end
 end 
 else
 begin
     select 1 as Corporate_id ,'admin-logo.png' as Corporate_logo,'login-bg.jpg' as Corporate_background,'pic' as Corporate_back_type,'2017-02-05 10:58:14.810' as Corporate_CreatedDate,'customer_cam.png' as Customer_logo
 end
end
else
begin
	if Exists(SELECT 1 FROM Corporate)
	begin

		if @Corporate_action = 'logo'
		begin
			update Corporate set Corporate_logo = @Corporate_logo
		end
		if @Corporate_action = 'logoCustm'
		begin
			update Corporate set Customer_logo=@Customer_logo
		end
		if @Corporate_action = 'back'
		begin

			update Corporate set Corporate_background = @Corporate_background , Corporate_back_type =@Corporate_back_type
		end
	end
	else
	begin

		if @Corporate_action = 'logo'
		begin
			
			insert into Corporate(Corporate_logo,Corporate_CreatedDate) values(@Corporate_logo,GETDATE())

		end
		if @Corporate_action = 'logoCustm'
		begin
			
			insert into Corporate(Customer_logo,Corporate_CreatedDate) values(@Customer_logo,GETDATE())

		end
		if @Corporate_action = 'back'
		begin

			insert into Corporate(Corporate_background, Corporate_back_type,Corporate_CreatedDate) values (@Corporate_background,@Corporate_back_type,GETDATE())

		end

	end

	select @@RowCount

	end

END


GO
/****** Object:  StoredProcedure [dbo].[CropMediaPicture_U]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CropMediaPicture_U] -- 1,'','','Area','Dispatch Priority','Units','naina','naina',''
(  

@MediaID int,   
@FilePath nvarchar(max)=null   



)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
  
			 Begin  
			update PicturesVideos set FilePath=@FilePath where MediaID=@MediaID
			Select @@Rowcount
			 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  
GO
/****** Object:  StoredProcedure [dbo].[Customer_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Customer_DeleteById]
@Id int=0
AS
BEGIN
	Delete from LicensedCustomers
	where Id=@Id
	
	select @@Rowcount
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerPermissions_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CustomerPermissions_IU]
(
@RoleId int=0,
@PermissionTable dbo.PermissionType2 READONLY
)
AS
BEGIN
	Delete from ManageCustomerPermissions where RoleId=@RoleId
	Insert into ManageCustomerPermissions	
	SELECT @RoleId, MenuId  
	FROM @PermissionTable
	
	select @@Rowcount 
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerRole_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CustomerRole_DeleteById]
@ID int=0
AS
BEGIN
	
	 begin
		DElete from ManageCustomerPermissions where RoleId=@ID
		DElete from ManageCustomerRoles  where RoleId=@ID
		
		select @@RowCount
	 end
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerRoles_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CustomerRoles_IU]
(
@RoleName nvarchar(500)=null,
@Id int=0
)
AS
BEGIN
BEGIN TRY
BEGIN Transaction
	If(@Id>0)
	begin
		update ManageCustomerRoles 
		set RoleName=@RoleName
		where RoleId=@Id
		
		select @@RowCount
	end
	else
		if exists(Select * from ManageCustomerRoles where RoleName=@RoleName)
			select -10
			else
			begin
				Insert into ManageCustomerRoles
				values(@RoleName)
				select @@Identity
			end
		COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]   
		END CATCH	
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerRoles_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CustomerRoles_LoadAll]
AS
BEGIN
	Select * from ManageCustomerRoles
END
GO
/****** Object:  StoredProcedure [dbo].[DataGroup]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DataGroup]

as
begin
	SELECT Distinct GroupName FROM ReportTables ORDER BY GroupName
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteAuditQuestionById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteAuditQuestionById]     
@QuestionID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from AuditsQuestions where QuestionID = @QuestionID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteGeneralReport_ByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteGeneralReport_ByID] 
(
@ReportID int=0
)
AS
BEGIN
	Delete from GeneralReport where ReportID=@ReportID
	select @@rowcount AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[DEleteIncident_ByIncidentId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DEleteIncident_ByIncidentId] --2
@Id int=0
AS
BEGIN
	DElete from EmployeeIncidents where IncidentID=@Id
	DElete from EmpEmployeeIncidents where IncidentID=@Id
	DElete from EmpReportsAccessPermission where ReportID=@Id
	select @@rowcount
END
GO
/****** Object:  StoredProcedure [dbo].[DepartmentType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DepartmentType_Delete](  
@id int=0
)  
as  
begin  
	Delete from MasterDepartmentType where id=@id
	select @@RowCount as Result
end
GO
/****** Object:  StoredProcedure [dbo].[DepartmentType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DepartmentType_IU](
@id int=0,
@DepartmentType nvarchar(100)=Null
)
as
begin
	if exists(Select * from MasterDepartmentType where id=@id)
	begin
		Update MasterDepartmentType set DepartmentType=@DepartmentType where id=@id
		select @@Rowcount as RESULT
	end
	else
	begin 
		insert into MasterDepartmentType(DepartmentType) values(@DepartmentType)
		select @@Identity as RESULT
	end
end
GO
/****** Object:  StoredProcedure [dbo].[Dispatch_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Dispatch_IU] -- 1,'','','Area','Dispatch Priority','Units','naina','naina',''
(  

@EventID int,   
@StartTime varchar(15),
@EndTime varchar(15),
@AreaID varchar(50),
@Priority varchar(50),
@HoldForUnit nvarchar(50),
@CallTakerID nvarchar(50),
@DispatcherID nvarchar(50),
@ScheduledTime nvarchar(15)



)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
  
			 Begin  
			 INSERT INTO  DispatchCalls (EventID, StartTime, EndTime, CallTakerID, DispatcherID, AreaID, Priority, HoldForUnit, ScheduledTime)
			  Values (@EventID,@StartTime,@EndTime,@CallTakerID,@DispatcherID,@AreaID,@Priority,@HoldForUnit,@ScheduledTime)
				select @@IDENTITY    
			 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  
GO
/****** Object:  StoredProcedure [dbo].[Dispatch_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Dispatch_print] --'04/01/2016','02/28/2017','12:00 AM','12:00 PM','EventLog.EventDate,DispatchCalls.StartTime'
(
@StartDate datetime,
@EndDate datetime,
@StartTime nvarchar(15),
@EndTime nvarchar(15),
@SortOrder nvarchar(50)
)
as
begin
declare @sql nvarchar(max)

 set @sql='SELECT DispatchCalls.CallID FROM DispatchCalls 
		INNER JOIN EventLog ON DispatchCalls.EventID = EventLog.EventID 
	WHERE EventLog.EventDate Between '''+convert(nvarchar,@StartDate,101)+''' AND '''+convert(nvarchar,@EndDate,101)+'''
	AND	DispatchCalls.StartTime BETWEEN '''+convert(nvarchar,@StartTime,101)+''' AND '''+convert(nvarchar,@EndTime,101)+'''
	ORDER BY '+@SortOrder+''
	execute(@sql)
	--print(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[DispatchAreas_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DispatchAreas_LoadAll]

As
BEGIN
	Select AreaID, AreaDescription From DispatchAreas Order By AreaID
END
GO
/****** Object:  StoredProcedure [dbo].[DispatchUnitCodes_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DispatchUnitCodes_LoadAll]

As
BEGIN
	Select UnitCode, UnitDescription From DispatchUnitCodes Order By UnitCode
END
GO
/****** Object:  StoredProcedure [dbo].[DisputeResolution_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[DisputeResolution_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from DisputeResolution where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[DisputeResolution_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[DisputeResolution_IU](        
@Id int,        
@Resolution nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM DisputeResolution  where Id=@Id)          
   begin          
   update DisputeResolution set Resolution=@Resolution where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into DisputeResolution(Resolution) values(@Resolution)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[DisputeResolution_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[DisputeResolution_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from DisputeResolution        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[Disputes_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Disputes_IU]--'1',
(
@IncidentId int=0,
@DisputeType nvarchar(50), 
@Resolution nvarchar(50), 
@Amount nvarchar(50),
@Description ntext,
@RecoveredMoney  bit
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM Disputes WHERE IncidentID = @IncidentId
		Insert into Disputes(      
		IncidentID, 
		DisputeType, 
		Resolution, 
		Amount,
		Description,
		RecoveredMoney    
		)         
		values (  
		@IncidentId,    
		@DisputeType, 
		@Resolution, 
		@Amount,
		@Description,
		@RecoveredMoney  
	   
		)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[Disputes_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Disputes_LoadByIncidentID]    
@IncidentId int=0    
As    
BEGIN    
 Select * from Disputes    
 where IncidentID=@IncidentId  
END
GO
/****** Object:  StoredProcedure [dbo].[EditIncident_ByIncidentId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EditIncident_ByIncidentId]
@Id int=0
AS
BEGIN
	select ReportEdit,ReportDelete from EmployeeIncidents where IncidentID=@Id
	select @@rowcount
END

GO
/****** Object:  StoredProcedure [dbo].[EmailLog_Print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EmailLog_Print] --'2016-07-04 00:00:00.000','2016-07-10 00:00:00.000','FromUserName'
(
@StartDate datetime,
@EndDate datetime,
@SortOrder nvarchar(50)
)
as

	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
 if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' AND EmailDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+'AND EmailDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' AND EmailDate <= '''+convert(varchar,@EndDate,101)+'''' 

	--Set @SQL='SELECT EmailDate, EmailTime, FromUserName, ToEmail, CCEmail, EmailSubject
	-- FROM EmailLog WHERE EmailDate BETWEEN '''+convert(nvarchar,@StartDate,101)+''' And '''+convert(nvarchar,@EndDate,101)+'''
	-- Order By '+@SortOrder+''

	 SET @SQL ='SELECT EmailDate, EmailTime, FromUserName, ToEmail, CCEmail, EmailSubject
	 FROM EmailLog '+ @Where+'
	 Order By '+@SortOrder+''  

	-- print(@SQL)
  execute(@SQL)
end

GO
/****** Object:  StoredProcedure [dbo].[Employee_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_Delete]
( @EmployeeID INT)
AS
BEGIN
   DELETE  FROM Employees WHERE EmployeeID=@EmployeeID 
   select @@RowCount
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_LoadByUserID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_LoadByUserID](@UserID           INT,
                                              @ReportAccessRole INT)
AS
     BEGIN
	IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
				 SELECT *,
			  (
				 SELECT TOP (1) PV.FilePath
				 FROM EmployeePicturesVideos EPV
					 LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
				 WHERE EPV.MediaType = 'Employee'
					  AND EmployeeID = Employees.EmployeeID
			  ) AS FilePath
			  FROM Employees ORDER BY CreatedDate DESC;
		   END
		   ELSE
		   BEGIN
	WITH cteReportPermission
              AS (
		    SELECT ISNULL(RP.EmployeeID,UP.EmployeeID) AS EmployeeID
			 FROM
			 (SELECT EmployeeID,ViewReport, 1 AS ByRole
			 FROM EmployeeAccessByRole
			 WHERE ReportAccessRole = @ReportAccessRole
				AND ViewReport = '1'
				) AS RP
			 FULL JOIN     
				 (SELECT EmployeeID,ViewReport, 2 ByUser
							  FROM EmployeeAccessUsers
							  WHERE ReportAccessBy = @UserID
							  AND ViewReport = '1'
								   ) AS UP ON RP.EmployeeID = UP.EmployeeID
			 WHERE (RP.ViewReport = 1 AND UP.ViewReport = 1) OR (RP.ViewReport = 1 AND UP.EmployeeID IS NULL)
			 OR(UP.ViewReport = 1 AND RP.EmployeeID IS NULL))

	    SELECT *,
         (
             SELECT TOP (1) PV.FilePath
             FROM EmployeePicturesVideos EPV
                  LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
             WHERE EPV.MediaType = 'Employee'
                   AND EmployeeID = Employees.EmployeeID
         ) AS FilePath
         FROM Employees
         WHERE UserID = @UserID
               OR EmployeeID IN 
			(
			 SELECT EmployeeID FROM cteReportPermission
			)
	   ORDER BY CreatedDate DESC;
         --SELECT *,
         --(
         --    SELECT TOP (1) PV.FilePath
         --    FROM EmployeePicturesVideos EPV
         --         LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
         --    WHERE EPV.MediaType = 'Employee'
         --          AND EmployeeID = Employees.EmployeeID
         --) AS FilePath
         --FROM Employees
         --WHERE UserID = @UserID
         --      OR EmployeeID IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessUsers
         --    WHERE ReportAccessBy = @UserID
         --          AND ReportID = 0
         --          AND ViewReport = '1'
         --)
         --      OR EmployeeID IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessByRole
         --    WHERE ReportAccessRole = @ReportAccessRole
         --          AND ReportID = 0
         --          AND ViewReport = '1'
         --)
         --UNION
         --SELECT *,
         --(
         --    SELECT TOP (1) PV.FilePath
         --    FROM EmployeePicturesVideos EPV
         --         LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
         --    WHERE EPV.MediaType = 'Employee'
         --          AND EmployeeID = Employees.EmployeeID
         --) AS FilePath
         --FROM Employees
         --WHERE EmployeeID IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessByRole
         --    WHERE isnull(ViewReport, 0) = 0
         --          AND isnull(EditReport, 0) = 0
         --          AND isnull(DeleteReport, 0) = 0
         --          AND ReportID = 0
         --)
         --      AND EmployeeID IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessUsers
         --    WHERE isnull(ViewReport, 0) = 0
         --          AND isnull(EditReport, 0) = 0
         --          AND isnull(DeleteReport, 0) = 0
         --          AND ReportID = 0
         --)
         --UNION
         --SELECT *,
         --(
         --    SELECT TOP (1) PV.FilePath
         --    FROM EmployeePicturesVideos EPV
         --         LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
         --    WHERE EPV.MediaType = 'Employee'
         --          AND EmployeeID = Employees.EmployeeID
         --) AS FilePath
         --FROM Employees
         --WHERE EmployeeID NOT IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessByRole
         --)
         --      AND EmployeeID NOT IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessUsers
         --)
         --UNION
         --SELECT *,
         --(
         --    SELECT TOP (1) PV.FilePath
         --    FROM EmployeePicturesVideos EPV
         --         LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
         --    WHERE EPV.MediaType = 'Employee'
         --          AND EmployeeID = Employees.EmployeeID
         --) AS FilePath
         --FROM Employees
         --WHERE EmployeeID NOT IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessByRole
         --)
         --      AND EmployeeID IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessUsers
         --    WHERE isnull(ViewReport, 0) = 0
         --          AND isnull(EditReport, 0) = 0
         --          AND isnull(DeleteReport, 0) = 0
         --          AND ReportID = 0
         --)
         --UNION
         --SELECT *,
         --(
         --    SELECT TOP (1) PV.FilePath
         --    FROM EmployeePicturesVideos EPV
         --         LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
         --    WHERE EPV.MediaType = 'Employee'
         --          AND EmployeeID = Employees.EmployeeID
         --) AS FilePath
         --FROM Employees
         --WHERE EmployeeID NOT IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessUsers
         --)
         --      AND EmployeeID IN
         --(
         --    SELECT EmployeeID
         --    FROM EmpReportsAccessByRole
         --    WHERE isnull(ViewReport, 0) = 0
         --          AND isnull(EditReport, 0) = 0
         --          AND isnull(DeleteReport, 0) = 0
         --          AND ReportID = 0
         --)
         --ORDER BY CreatedDate DESC;
  
         --if((select count(*) from Users where IsAdmin=1 and ID=@UserID)>0)  
         -- begin  
         --  select *,  
         --   (select Top(1) PV.FilePath from EmployeePicturesVideos EPV  
         --  left join PicturesVideos PV on EPV.MediaID = PV.MediaID   
         --  where EmployeeID = Employees.EmployeeID) as FilePath  from Employees  
         -- end  
         --else  
         -- begin  
         --  select *,  
         --   (select Top(1) PV.FilePath from EmployeePicturesVideos EPV  
         --  left join PicturesVideos PV on EPV.MediaID = PV.MediaID where EmployeeID = Employees.EmployeeID) as FilePath  from Employees where UserID =@UserID  
         -- end  
	    END
     END;
GO
/****** Object:  StoredProcedure [dbo].[Employee_LoadByUserIDBackup]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_LoadByUserIDBackup](@UserID           INT,
                                              @ReportAccessRole INT)
AS
     BEGIN
         SELECT *,
         (
             SELECT TOP (1) PV.FilePath
             FROM EmployeePicturesVideos EPV
                  LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
             WHERE EPV.MediaType = 'Employee'
                   AND EmployeeID = Employees.EmployeeID
         ) AS FilePath
         FROM Employees
         WHERE UserID = @UserID
               OR EmployeeID IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessUsers
             WHERE ReportAccessBy = @UserID
                   AND ReportID = 0
                   AND ViewReport = '1'
         )
               OR EmployeeID IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessByRole
             WHERE ReportAccessRole = @ReportAccessRole
                   AND ReportID = 0
                   AND ViewReport = '1'
         )
         UNION
         SELECT *,
         (
             SELECT TOP (1) PV.FilePath
             FROM EmployeePicturesVideos EPV
                  LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
             WHERE EPV.MediaType = 'Employee'
                   AND EmployeeID = Employees.EmployeeID
         ) AS FilePath
         FROM Employees
         WHERE EmployeeID IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessByRole
             WHERE isnull(ViewReport, 0) = 0
                   AND isnull(EditReport, 0) = 0
                   AND isnull(DeleteReport, 0) = 0
                   AND ReportID = 0
         )
               AND EmployeeID IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessUsers
             WHERE isnull(ViewReport, 0) = 0
                   AND isnull(EditReport, 0) = 0
                   AND isnull(DeleteReport, 0) = 0
                   AND ReportID = 0
         )
         UNION
         SELECT *,
         (
             SELECT TOP (1) PV.FilePath
             FROM EmployeePicturesVideos EPV
                  LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
             WHERE EPV.MediaType = 'Employee'
                   AND EmployeeID = Employees.EmployeeID
         ) AS FilePath
         FROM Employees
         WHERE EmployeeID NOT IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessByRole
         )
               AND EmployeeID NOT IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessUsers
         )
         UNION
         SELECT *,
         (
             SELECT TOP (1) PV.FilePath
             FROM EmployeePicturesVideos EPV
                  LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
             WHERE EPV.MediaType = 'Employee'
                   AND EmployeeID = Employees.EmployeeID
         ) AS FilePath
         FROM Employees
         WHERE EmployeeID NOT IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessByRole
         )
               AND EmployeeID IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessUsers
             WHERE isnull(ViewReport, 0) = 0
                   AND isnull(EditReport, 0) = 0
                   AND isnull(DeleteReport, 0) = 0
                   AND ReportID = 0
         )
         UNION
         SELECT *,
         (
             SELECT TOP (1) PV.FilePath
             FROM EmployeePicturesVideos EPV
                  LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
             WHERE EPV.MediaType = 'Employee'
                   AND EmployeeID = Employees.EmployeeID
         ) AS FilePath
         FROM Employees
         WHERE EmployeeID NOT IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessUsers
         )
               AND EmployeeID IN
         (
             SELECT EmployeeID
             FROM EmpReportsAccessByRole
             WHERE isnull(ViewReport, 0) = 0
                   AND isnull(EditReport, 0) = 0
                   AND isnull(DeleteReport, 0) = 0
                   AND ReportID = 0
         )
         ORDER BY CreatedDate DESC;
  
         --if((select count(*) from Users where IsAdmin=1 and ID=@UserID)>0)  
         -- begin  
         --  select *,  
         --   (select Top(1) PV.FilePath from EmployeePicturesVideos EPV  
         --  left join PicturesVideos PV on EPV.MediaID = PV.MediaID   
         --  where EmployeeID = Employees.EmployeeID) as FilePath  from Employees  
         -- end  
         --else  
         -- begin  
         --  select *,  
         --   (select Top(1) PV.FilePath from EmployeePicturesVideos EPV  
         --  left join PicturesVideos PV on EPV.MediaID = PV.MediaID where EmployeeID = Employees.EmployeeID) as FilePath  from Employees where UserID =@UserID  
         -- end  
     END;
GO
/****** Object:  StoredProcedure [dbo].[Employee_Search]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_Search]
(  
 @FirstName nvarchar(250),                    
 @LastName nvarchar(250),                    
 @Sex nvarchar(250),                    
 @Race nvarchar(250)
)                  
AS                  
BEGIN                  
 BEGIN TRY                                                      
  BEGIN TRANSACTION
    declare @query nvarchar(max);        
    declare @where nvarchar(max);     
    set @where='Where 1=1'

    if(@FirstName<>'')        
     begin        
      set @where=@where + ' and FirstName like '''+@FirstName+'%'''         
     end        
    if(@LastName<>'')        
     begin        
      set @where=@where+' and LastName like '''+@LastName+'%'''        
     end        
    if(@Sex<>'')        
     begin        
      set @where=@where+' and Sex = '''+@Sex +''''       
     end        
    if(@Race<>'')        
     begin        
      set @where=@where+' and Race = '''+@Race+''''        
     end        
   
    set @query='SELECT EmployeeID, FirstName, LastName, Status FROM Employees '+@where+''
   -- print @query      
    exec(@query)    

                      
  COMMIT TRANSACTION                  
    END TRY                                                    
 BEGIN CATCH                                                      
   IF @@TRANCOUNT >0                                                      
   ROLLBACK TRANSACTION;              
  select 1 as result                   
   SELECT ERROR_MESSAGE() AS ErrorNumber;                                     
   --EXECUTE [uspLogError];                                                                         
 END CATCH;                   
END 



GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EmployeeAccessPermission]
(
@ID int,
@EmployeeID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EmployeeAccessUsers set ViewReport=@Permission where ID=@ID and EmployeeID=@EmployeeID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EmployeeAccessUsers set EditReport=@Permission where ID=@ID and EmployeeID=@EmployeeID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EmployeeAccessUsers set DeleteReport=@Permission where ID=@ID and EmployeeID=@EmployeeID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[EmployeeAccessPermission_ByRole]
(
@ID int,
@EmployeeID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EmployeeAccessByRole where ID=@ID and EmployeeID=@EmployeeID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EmployeeAccessPermission_ByUser]
(
@ID int,
@EmployeeID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EmployeeAccessUsers where ID=@ID and EmployeeID=@EmployeeID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessPermission_tabCheck]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[EmployeeAccessPermission_tabCheck]
(
@ReportAccessBy int,
@EmployeeID int,
@ReportID int
)
as
begin
	Select count(*) from EmpReportsAccessPermission where ReportAccessBy=@ReportAccessBy
	 and EmployeeID=@EmployeeID and ReportID=@ReportID
	select @@RowCount
end
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EmployeeAccessPermissionByRole]
(
@ID int,
@EmployeeID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EmployeeAccessByRole set ViewReport=@Permission where ID=@ID and EmployeeID=@EmployeeID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EmployeeAccessByRole set EditReport=@Permission where ID=@ID and EmployeeID=@EmployeeID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EmployeeAccessByRole set DeleteReport=@Permission where ID=@ID and EmployeeID=@EmployeeID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EmployeeAccessRoles_Bind]
(
@UserID int,
@EmployeeID int = 0
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select ManageRoles.RoleName,
		EmployeeAccessByRole.* from EmployeeAccessByRole
		left join ManageRoles on ManageRoles.RoleId=EmployeeAccessByRole.ReportAccessRole
		where EmployeeID=@EmployeeID AND ManageRoles.RoleName <> 'Administrator';

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EmployeeAccessUsers_Bind]
(
@UserID int,
@EmployeeID int
)
AS             
BEGIN   
  Begin Try           
    Begin 


		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		EmployeeAccessUsers.* 
		from EmployeeAccessUsers
		left join Users on Users.ID = EmployeeAccessUsers.ReportAccessBy
		where EmployeeID=@EmployeeID 
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

		
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddress_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC  [dbo].[EmployeeAddress_AddEdit]
 (
	@AddressID int,
	@EmployeeID int,
	@IncidentID int ,
	@ModifiedDate datetime,
	@Apartment nvarchar(15),
	@Address nvarchar(150),
	@CountryID int,
	@City nvarchar(15),
	@ProvState nvarchar(20),
	@PostalZip nvarchar(10),
	@AddressType nvarchar(50),
	@Phone nvarchar(250)
	)
	as
	BEGIN

	IF EXISTS (SELECT * FROM  EmployeeAddress WHERE AddressID=@AddressID)
	BEGIN
	UPDATE EmployeeAddress SET 
	  EmployeeID=@EmployeeID,IncidentID=@IncidentID,ModifiedDate=@ModifiedDate,Apartment=@Apartment,Address=@Address,CountryID=@CountryID,City=@City,ProvState=@ProvState,PostalZip=@PostalZip,AddressType=@AddressType,Phone=@Phone
      WHERE	AddressID=@AddressID 
	  SELECT @@ROWCOUNT AS Result
	END
	ELSE
	BEGIN
		INSERT INTO EmployeeAddress(EmployeeID,IncidentID,ModifiedDate,Apartment,Address,City,ProvState,PostalZip,AddressType,Phone,CountryID) 
	    VALUES (@EmployeeID,@IncidentID,@ModifiedDate,@Apartment,@Address,@City,@ProvState,@PostalZip,@AddressType,@Phone,@CountryID)
	    SELECT @@Identity AS Result
	END

	END

	
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddress_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeAddress_Delete]
( @AddressID INT)
AS
BEGIN
   DELETE  FROM EmployeeAddress WHERE AddressID=@AddressID 
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddress_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeAddress_Load]
( @AddressID INT)
AS
BEGIN
   SELECT * FROM EmployeeAddress WHERE AddressID=@AddressID 
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddress_LoadByUserID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeAddress_LoadByUserID]
(@employeeID int)
AS
BEGIN
   SELECT AddressType.AddressType as Addressname,* FROM EmployeeAddress
   left join AddressType on AddressType.ID=EmployeeAddress.AddressType
    where employeeID=@employeeID
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeIDMax_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[EmployeeIDMax_Load]  -- 1  

AS             
BEGIN   
declare @EmployeeID int
  Begin Try            
   Begin Transaction 
    Begin 
   
	  select @EmployeeID=Max(EmployeeID)+1 from Employees
	   if(@EmployeeID is null)
	   begin
	  set @EmployeeID=1
	   end 
	  SELECT RIGHT('00000'+ CONVERT(VARCHAR(6),@EmployeeID),5)
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END




GO
/****** Object:  StoredProcedure [dbo].[EmployeeIncident_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeIncident_IU]        
@EmployeeId int=0,         
@Id int=0 ,    
@ActiveStatus bit=0,    
@Description ntext=null,    
@IncidentDate datetime=null,    
@IncidentNumber nvarchar(20)=null,    
@IncidentRole nvarchar(50)=null,    
@Location nvarchar(50)=null,    
@NatureOfIncident nvarchar(50)=null,    
@ShortDescription nvarchar(25)=null,    
@StartTime nvarchar(10)=null,  
@EndTime nvarchar(10)=null,  
@StartDate datetime=null,   
@EndDate datetime=null,   
@Status nvarchar(25)=null,    
@UD27 nvarchar(50)=null,    
@UD34 nvarchar(50)=null,    
@UD35 nvarchar(50)=null,  
@Notes ntext=null,  
@IPVRDescription ntext=null,
@CreatedBy int=0,
@ReportView bit,
@ReportEdit bit,
@ReportDelete bit    
AS                   
BEGIN         
  Begin Try                  
   Begin Transaction       
     
 Begin      
   if(@Notes is not null and @Id>0)  
   begin  
		update EmployeeIncidents set   
			Notes=@Notes  
		where IncidentID=@Id    
   end  
   else if (@IPVRDescription is not null and @Id>0)  
   begin  
		update EmployeeIncidents set   
			IPVRDescription=@IPVRDescription  
		where IncidentID=@Id   
   end  
  else if(@Id>0)    
  begin    
		update EmployeeIncidents set    
			NatureOfEvent=@NatureOfIncident,    
			ShortDescriptor=@ShortDescription,    
			ActiveStatus=@ActiveStatus,    
			Status=@Status,    
			IncidentDate=@IncidentDate,    
			Description=@Description,    
			Location=@Location,    
			IncidentRole=@IncidentRole,    
			IncidentTime=@StartTime,
			EndTime=@EndTime,    
			StartDate=@StartDate,  
			EndDate=@EndDate,  
			UD27=@UD27,    
			UD34=@UD34,    
			UD35=@UD35,
			ReportDelete=@ReportDelete,
			ReportEdit=@ReportEdit,
			ReportView=@ReportView
		where IncidentID=@Id    
     
 select @Id  
  end    
  else    
  begin    
      
    Insert into EmployeeIncidents(    
    IncidentNumber,    
    NatureOfEvent,    
    ShortDescriptor,    
    ActiveStatus,    
    Status,    
    IncidentDate,    
    Description,    
    Location,    
    IncidentRole,    
    IncidentTime,
    EndTime,
    StartDate,
    EndDate,    
    UD27,    
    UD34,    
    UD35,
	CreatedBy,
	CreatedDate,
	ReportView,
	ReportEdit,
	ReportDelete
    )       
    values (    
    @IncidentNumber,    
    @NatureOfIncident,    
    @ShortDescription,    
    @ActiveStatus,    
    @Status,    
    @IncidentDate,    
    @Description,    
    @Location,    
    @IncidentRole,    
    @StartTime,
    @EndTime,
    @StartDate,
    @EndDate,    
    @UD27,    
    @UD34,    
    @UD35,
	@CreatedBy,
	getdate(),
	@ReportView,
	@ReportEdit,
	@ReportDelete
    )        
    select @Id=@@IDENTITY
        
      update EmployeeIncidents set  
      IncidentNumber=@IncidentNumber  
      where IncidentID=@Id  
    Insert into EmpEmployeeIncidents(EmployeeID,IncidentID)       
    values (@EmployeeId,@Id)        
    select @Id  
   end    
 End       
  COMMIT TRANSACTION       
 End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END

GO
/****** Object:  StoredProcedure [dbo].[EmployeeIncident_LoadALL]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EmployeeIncident_LoadALL](@UserID           INT,@EventId        INT = 0,
                                                          @ReportAccessRole INT = 0,
                                                          @AllReport        INT = 0)
AS
     BEGIN
	DECLARE @viewpermission BIT= 0;

         IF(@AllReport > 0)
             BEGIN
                 SELECT Users.UserName AS ReportCreatorUser,
                        MSD.Descriptor AS ShortDescriptorName,
                        EmployeeIncidents.Status AS Status,
                        CAST(description AS NVARCHAR) AS textdesc,
                        mn.nature AS noi,
                        EmployeeIncidents.CreatedDate AS CreatedDate,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EmployeePicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EPV.MediaType = 'EmpReport'
                           AND EPV.IncidentID = EmployeeIncidents.IncidentID
                 ) AS ImagePath,
                        CASE
                            WHEN isnull(MN.NatureImage, '') <> ''
                            THEN MN.NatureImage
                            ELSE
                 (
                     SELECT ImagePath
                     FROM ReportLogoImage
                     WHERE SetImage = 1
                 )
                        END AS DefaultImage,
                        --(Select ImagePath from ReportLogoImage where SetImage=1) as DefaultImage,
                        EmployeeIncidents.IncidentID,
                        EmployeeIncidents.IncidentNumber,
                        'Employee' AS LinkFile
				     ,EIL.EmployeeID
				    ,EEI.ID AS EventIncidentID
				    ,E.FirstName
				    ,E.LastName
				    ,CASE WHEN EEI.IncidentID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
                 FROM EmployeeIncidents
                      INNER JOIN Users ON Users.ID = EmployeeIncidents.CreatedBy
				  INNER JOIN EmpEmployeeIncidents AS EIL ON EmployeeIncidents.IncidentID = EIL.IncidentID
				  INNER JOIN Employees AS E ON EIL.EmployeeID = E.EmployeeID
                      LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = EmployeeIncidents.ShortDescriptor
                      LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                             AND NatureType = 2
				LEFT JOIN EventEmployeeIncidents AS EEI ON EmployeeIncidents.IncidentID = EEI.IncidentID AND EEI.EventID = @EventId 
				ORDER BY EEI.IncidentID DESC
                 
             END;
         ELSE

             BEGIN

			 IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
             END; 

                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM EmpReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM EmpReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID <> 0
                                   AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
                      SELECT Users.UserName AS ReportCreatorUser,
                             MSD.Descriptor AS ShortDescriptorName,
                             EmployeeIncidents.Status AS Status,
                             CAST(description AS NVARCHAR) AS textdesc,
                             mn.nature AS noi,
                             EmployeeIncidents.CreatedDate AS CreatedDate,
                      (
                          SELECT TOP (1) PV.FilePath
                          FROM EmployeePicturesVideos EPV
                               LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                          WHERE EPV.MediaType = 'EmpReport'
                                AND EPV.IncidentID = EmployeeIncidents.IncidentID
                      ) AS ImagePath,
                             --(Select ImagePath from ReportLogoImage where SetImage=1) as DefaultImage,
                             CASE
                                 WHEN isnull(MN.NatureImage, '') <> ''
                                 THEN MN.NatureImage
                                 ELSE
                      (
                          SELECT ImagePath
                          FROM ReportLogoImage
                          WHERE SetImage = 1
                      )
                             END AS DefaultImage,
                             EmployeeIncidents.IncidentID,
                             EmployeeIncidents.IncidentNumber,
                             'Employee' AS LinkFile
					    ,EIL.EmployeeID
				    ,EEI.ID AS EventIncidentID
				    ,E.FirstName
				    ,E.LastName
				    ,CASE WHEN EEI.IncidentID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
                      FROM EmployeeIncidents
                           INNER JOIN Users ON Users.ID = EmployeeIncidents.CreatedBy
					  INNER JOIN EmpEmployeeIncidents AS EIL ON EmployeeIncidents.IncidentID = EIL.IncidentID
				  INNER JOIN Employees AS E ON EIL.EmployeeID = E.EmployeeID
                           LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = EmployeeIncidents.ShortDescriptor
                           LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                                  AND NatureType = 2
					LEFT JOIN EventEmployeeIncidents AS EEI ON EmployeeIncidents.IncidentID = EEI.IncidentID AND EEI.EventID = @EventId 
				
                      WHERE(
					   CreatedBy = @UserID
                            AND ReportView = '1'
                            AND EmployeeIncidents.IncidentID IN
						 (
							SELECT IncidentID
							FROM EmpEmployeeIncidents
						 )
					  )
                           OR (
					  EmployeeIncidents.IncidentID IN
                              (
                                  SELECT ReportID
                                  FROM cteReportPermission
                              )
						OR 
						(
						    @viewpermission = 1 AND EmployeeIncidents.IncidentID IN
							(
							    SELECT IncidentID
							    FROM EmpEmployeeIncidents
							)
						  )
					   )
					  ORDER BY EEI.IncidentID DESC;
             END
     END

GO
/****** Object:  StoredProcedure [dbo].[EmployeeIncident_LoadByEmployeeID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeIncident_LoadByEmployeeID](@UserID           INT,
                                                          @EmployeeId       INT = 0,
                                                          @ReportAccessRole INT = 0,
                                                          @AllReport        INT = 0)
AS
     BEGIN
	DECLARE @viewpermission BIT= 0;

         IF(@AllReport > 0)
             BEGIN
                 SELECT Users.UserName AS ReportCreatorUser,
                        MSD.Descriptor AS ShortDescriptorName,
                        EmployeeIncidents.Status AS Status,
                        CAST(description AS NVARCHAR) AS textdesc,
                        mn.nature AS noi,
                        EmployeeIncidents.CreatedDate AS CreatedDate,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EmployeePicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EPV.MediaType = 'EmpReport'
                           AND EPV.IncidentID = EmployeeIncidents.IncidentID
                 ) AS ImagePath,
                        CASE
                            WHEN isnull(MN.NatureImage, '') <> ''
                            THEN MN.NatureImage
                            ELSE
                 (
                     SELECT ImagePath
                     FROM ReportLogoImage
                     WHERE SetImage = 1
                 )
                        END AS DefaultImage,
                        --(Select ImagePath from ReportLogoImage where SetImage=1) as DefaultImage,
                        EmployeeIncidents.IncidentID,
                        EmployeeIncidents.IncidentNumber,
                 (
                     SELECT LinkWithReport
                     FROM EmpReportsLink
                     WHERE ReportLinkWith = @EmployeeId
                           AND FetchDetailsBy = 'Employee'
                           AND ReportID = IncidentID
                 ) AS LinkWithReport,
                 (
                     SELECT EmployeeID
                     FROM EmpReportsLink
                     WHERE ReportLinkWith = @EmployeeId
                           AND FetchDetailsBy = 'Employee'
                           AND ReportID = IncidentID
                 ) AS LinkByEmpID,
                 (
                     SELECT Employees.FirstName+' '+Employees.LastName
                     FROM EmpReportsLink
                          LEFT JOIN Employees ON EmpReportsLink.EmployeeID = Employees.EmployeeID
                     WHERE EmpReportsLink.ReportLinkWith = @EmployeeId
                           AND EmpReportsLink.FetchDetailsBy = 'Employee'
                           AND EmpReportsLink.ReportID = IncidentID
                 ) AS LinkEmployeeName,
                        'Employee' AS LinkFile
                 FROM EmployeeIncidents
                      INNER JOIN Users ON Users.ID = EmployeeIncidents.CreatedBy
                      LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = EmployeeIncidents.ShortDescriptor
                      LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                             AND NatureType = 2
                 UNION
                 SELECT Users.UserName AS ReportCreatorUser,
                        MSD.Descriptor AS ShortDescriptorName,
                        MS.Status AS Status,
                        CAST(description AS NVARCHAR) AS textdesc,
                        '' AS noi,
                        Incidents.CreatedDate AS CreatedDate,
                        '' AS ImagePath,
                        --'' as DefaultImage
                        CASE
                            WHEN isnull(MN.NatureImage, '') <> ''
                            THEN MN.NatureImage
                            ELSE
                 (
                     SELECT ImagePath
                     FROM ReportLogoImage
                     WHERE SetImage = 1
                 )
                        END AS DefaultImage,
                        Incidents.IncidentID,
                        Incidents.IncidentNumber,
                 (
                     SELECT LinkWithReport
                     FROM SubReportsLink
                     WHERE ReportLinkWith = @EmployeeId
                           AND FetchDetailsBy = '1'
                           AND ReportID = IncidentID
                 ) AS LinkWithReport,
                 (
                     SELECT SubjectID
                     FROM SubReportsLink
                     WHERE ReportLinkWith = @EmployeeId
                           AND FetchDetailsBy = '1'
                           AND ReportID = IncidentID
                 ) AS LinkByEmpID,
                 (
                     SELECT Subjects.FirstName+' '+Subjects.LastName
                     FROM SubReportsLink
                          LEFT JOIN Subjects ON SubReportsLink.SubjectID = Subjects.SubjectID
                     WHERE SubReportsLink.ReportLinkWith = @EmployeeId
                           AND SubReportsLink.FetchDetailsBy = '1'
                           AND SubReportsLink.ReportID = IncidentID
                 ) AS LinkEmployeeName,
                        'Subject' AS LinkFile
                 FROM Incidents
                      INNER JOIN Users ON Users.ID = Incidents.CreatedBy
                      LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = Incidents.ShortDescriptor
                      LEFT JOIN MasterStatus MS ON MS.ID = Incidents.Status
                      LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                             AND NatureType = 2
                 WHERE Incidents.IncidentID IN
                 (
                     SELECT ReportID
                     FROM SubReportsLink
                     WHERE ReportLinkWith = @EmployeeId
                           AND FetchDetailsBy = '1'
                 );
             END;
         ELSE

             BEGIN

			 IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
             END; 

                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM EmpReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND EmployeeID = @EmployeeId
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM EmpReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND EmployeeID = @EmployeeId
                                   AND ReportID <> 0
                                   AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
                      SELECT Users.UserName AS ReportCreatorUser,
                             MSD.Descriptor AS ShortDescriptorName,
                             EmployeeIncidents.Status AS Status,
                             CAST(description AS NVARCHAR) AS textdesc,
                             mn.nature AS noi,
                             EmployeeIncidents.CreatedDate AS CreatedDate,
                      (
                          SELECT TOP (1) PV.FilePath
                          FROM EmployeePicturesVideos EPV
                               LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                          WHERE EPV.MediaType = 'EmpReport'
                                AND EPV.IncidentID = EmployeeIncidents.IncidentID
                      ) AS ImagePath,
                             --(Select ImagePath from ReportLogoImage where SetImage=1) as DefaultImage,
                             CASE
                                 WHEN isnull(MN.NatureImage, '') <> ''
                                 THEN MN.NatureImage
                                 ELSE
                      (
                          SELECT ImagePath
                          FROM ReportLogoImage
                          WHERE SetImage = 1
                      )
                             END AS DefaultImage,
                             EmployeeIncidents.IncidentID,
                             EmployeeIncidents.IncidentNumber,
                      (
                          SELECT LinkWithReport
                          FROM EmpReportsLink
                          WHERE ReportLinkWith = @EmployeeId
                                AND FetchDetailsBy = 'Employee'
                                AND ReportID = IncidentID
                      ) AS LinkWithReport,
                      (
                          SELECT EmployeeID
                          FROM EmpReportsLink
                          WHERE ReportLinkWith = @EmployeeId
                                AND FetchDetailsBy = 'Employee'
                                AND ReportID = IncidentID
                      ) AS LinkByEmpID,
                      (
                          SELECT Employees.FirstName+' '+Employees.LastName
                          FROM EmpReportsLink
                               LEFT JOIN Employees ON EmpReportsLink.EmployeeID = Employees.EmployeeID
                          WHERE EmpReportsLink.ReportLinkWith = @EmployeeId
                                AND EmpReportsLink.FetchDetailsBy = 'Employee'
                                AND EmpReportsLink.ReportID = IncidentID
                      ) AS LinkEmployeeName,
                             'Employee' AS LinkFile
                      FROM EmployeeIncidents
                           INNER JOIN Users ON Users.ID = EmployeeIncidents.CreatedBy
                           LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = EmployeeIncidents.ShortDescriptor
                           LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                                  AND NatureType = 2
                      WHERE(CreatedBy = @UserID
                            AND ReportView = '1'
                            AND IncidentID IN
                           (
                               SELECT IncidentID
                               FROM EmpEmployeeIncidents
                               WHERE EmployeeID = @EmployeeId
                           ))
                           OR (IncidentID IN
                              (
                                  SELECT ReportID
                                  FROM EmpReportsLink
                                  WHERE ReportLinkWith = @EmployeeId
                                        AND FetchDetailsBy = 'Employee'
                              )
                               OR IncidentID IN
                              (
                                  SELECT ReportID
                                  FROM cteReportPermission
                              )
						OR (@viewpermission = 1 AND IncidentID IN
                           (
                               SELECT IncidentID
                               FROM EmpEmployeeIncidents
                               WHERE EmployeeID = @EmployeeId
                           ))
                           --(
                           --SELECT ReportID
                           --FROM EmpReportsAccessUsers
                           --WHERE ReportAccessBy = @UserID
                           --	 AND EmployeeID = @EmployeeId
                           --	 AND ViewReport = '1'
                           --	 AND ReportID <> 0
                           --)
                           --  OR IncidentID IN
                           --(
                           --SELECT ReportID
                           --FROM EmpReportsAccessByRole
                           --WHERE ReportAccessRole = @ReportAccessRole
                           --	 AND EmployeeID = @EmployeeId
                           --	 AND ViewReport = '1'
                           --	 AND ReportID <> 0
                           --)
                           )
                      UNION
                      SELECT Users.UserName AS ReportCreatorUser,
                             MSD.Descriptor AS ShortDescriptorName,
                             MS.Status AS Status,
                             CAST(description AS NVARCHAR) AS textdesc,
                             '' AS noi,
                             Incidents.CreatedDate AS CreatedDate,
                             '' AS ImagePath,
                             --'' as DefaultImage
                             CASE
                                 WHEN isnull(MN.NatureImage, '') <> ''
                                 THEN MN.NatureImage
                                 ELSE
                      (
                          SELECT ImagePath
                          FROM ReportLogoImage
                          WHERE SetImage = 1
                      )
                             END AS DefaultImage,
                             Incidents.IncidentID,
                             Incidents.IncidentNumber,
                      (
                          SELECT LinkWithReport
                          FROM SubReportsLink
                          WHERE ReportLinkWith = @EmployeeId
                                AND FetchDetailsBy = '1'
                                AND ReportID = IncidentID
                      ) AS LinkWithReport,
                      (
                          SELECT SubjectID
                          FROM SubReportsLink
                          WHERE ReportLinkWith = @EmployeeId
                                AND FetchDetailsBy = '1'
                                AND ReportID = IncidentID
                      ) AS LinkByEmpID,
                      (
                          SELECT Subjects.FirstName+' '+Subjects.LastName
                          FROM SubReportsLink
                               LEFT JOIN Subjects ON SubReportsLink.SubjectID = Subjects.SubjectID
                          WHERE SubReportsLink.ReportLinkWith = @EmployeeId
                                AND SubReportsLink.FetchDetailsBy = '1'
                                AND SubReportsLink.ReportID = IncidentID
                      ) AS LinkEmployeeName,
                             'Subject' AS LinkFile
                      FROM Incidents
                           INNER JOIN Users ON Users.ID = Incidents.CreatedBy
                           LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = Incidents.ShortDescriptor
                           LEFT JOIN MasterStatus MS ON MS.ID = Incidents.Status
                           LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                                  AND NatureType = 2
                      WHERE Incidents.IncidentID IN
                      (
                          SELECT ReportID
                          FROM SubReportsLink
                          WHERE ReportLinkWith = @EmployeeId
                                AND FetchDetailsBy = '1'
                      );
             END
     END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeIncident_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeIncident_LoadByIncidentID]  
@IncidentId int=0 ,
@UserID int,
@ReportAccessRole int 
As
DECLARE @viewpermission BIT= 0;
DECLARE @editpermission BIT= 0;
DECLARE @deletepermission BIT= 0;

BEGIN  

IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
                 SET @editpermission = 1;
			  SET @deletepermission = 1;
             END; 

WITH 
cteviewPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM EmpReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM EmpReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                                  AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
						  OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
,ctePermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,EditReport,DeleteReport,
                                    1 AS ByRole
                             FROM EmpReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,EditReport,DeleteReport,
                                    2 ByUser
                             FROM EmpReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                         ) AS UP ON RP.ReportID = UP.ReportID
                        )
,cteeditPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    EditReport,
                                    1 AS ByRole
                             FROM EmpReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND EditReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    EditReport,
                                    2 ByUser
                             FROM EmpReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                                   AND (EditReport = '1' OR EditReport IS NULL OR EditReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.EditReport = 1
                               AND UP.EditReport = 1)
						  OR (RP.EditReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.EditReport = 1
                                  AND RP.ReportID IS NULL))
,ctedeletePermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    DeleteReport,
                                    1 AS ByRole
                             FROM EmpReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND DeleteReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    DeleteReport,
                                    2 ByUser
                             FROM EmpReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                                   AND (DeleteReport = '1' OR DeleteReport IS NULL OR DeleteReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.DeleteReport = 1
                               AND UP.DeleteReport = 1)
						 OR (RP.DeleteReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.DeleteReport = 1
                                  AND RP.ReportID IS NULL))

 Select
 (CASE
    WHEN @viewpermission = 1
    THEN @viewpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteviewPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS viewpermission, 
 (CASE
    WHEN @editpermission = 1
    THEN @editpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteeditPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS editpermission,
(CASE
    WHEN @deletepermission = 1
    THEN @deletepermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM ctedeletePermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS deletepermission,
 Users.UserName as ReportCreatorUser,Users.FirstName as ReportCreatorFirstName,
  Users.LastName as ReportCreatorLastName,EmployeeIncidents.* from EmployeeIncidents  
  inner join Users on Users.ID=EmployeeIncidents.CreatedBy
 where IncidentID=@IncidentId
END

GO
/****** Object:  StoredProcedure [dbo].[EmployeeIncidentsMax_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE procedure [dbo].[EmployeeIncidentsMax_Load]  -- 1  

AS             
BEGIN   
declare @IncidentID int
  Begin Try            
   Begin Transaction 
    Begin 
   
	  select @IncidentID=Max(IncidentID)+1 from EmployeeIncidents

	   if(@IncidentID is null)
	   begin
	  set @IncidentID=1
	   end 

	  SELECT RIGHT('00000'+ CONVERT(VARCHAR(6),@IncidentID),5)
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EmployeeInvolve_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeeInvolve_I]
(  
@IncidentId int=0,  
@EmployeeID int=0,  
@InvolvedID int=0,  
@MediaID int=0,  
@InvolvedRole nvarchar(100),
@FetchDetailsBy nvarchar(100),
@CreatedBy int
)  
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
    declare @set1 int 
	declare @set2 int  
	 Begin   
	  set @set1=(Select COUNT(*) from EmployeeInvolved WHERE InvolvedID =@InvolvedID and IncidentID = @IncidentId and EmployeeID=@EmployeeID and FetchDetailsBy=@FetchDetailsBy)
	  if(@set1>0)  
	   begin  
	    DELETE FROM EmployeeInvolved WHERE InvolvedID =@InvolvedID and IncidentID = @IncidentId and EmployeeID=@EmployeeID and FetchDetailsBy=@FetchDetailsBy
	   END
	    Insert into EmployeeInvolved(EmployeeID,IncidentID,InvolvedID,MediaID,InvolvedRole,FetchDetailsBy) 
		 values(@EmployeeID,@IncidentId,@InvolvedID,@MediaID,@InvolvedRole,@FetchDetailsBy)             
	    select @@IDENTITY

		set @set2=(Select COUNT(*) from EmpReportsLink WHERE EmployeeID =@EmployeeID and ReportID = @IncidentId and ReportLinkWith=@InvolvedID and FetchDetailsBy=@FetchDetailsBy)
	  if(@set2>0)  
	   begin  
	    DELETE FROM EmpReportsLink WHERE EmployeeID =@EmployeeID and ReportID = @IncidentId and ReportLinkWith=@InvolvedID and FetchDetailsBy=@FetchDetailsBy
	   END            
		insert into EmpReportsLink(EmployeeID,ReportID,ReportLinkWith,CreatedBy,ModifiedDate,LinkWithReport,FetchDetailsBy)
			values(@EmployeeID,@IncidentId,@InvolvedID,@CreatedBy,getdate(),1,@FetchDetailsBy)
		select @@IDENTITY
	  End           
    COMMIT TRANSACTION           
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[EmployeeInvolved_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeInvolved_Delete]
@ID int=0,
@ReportID int
AS
BEGIN
	Delete from EmployeeInvolved where ID=@ID
	Delete from EmpReportsLink where ReportID=@ReportID
	Select @@RowCount
END

GO
/****** Object:  StoredProcedure [dbo].[EmployeeInvolved_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeInvolved_LoadByIncidentID]  
@IncidentId int=0  
As  
BEGIN  
 Select ei.ID,ei.InvolvedID,ei.EmployeeID,e.FirstName,e.LastName,e.Sex,e.Race,mr.Id as RoleID,mr.Role as RoleName from Employees e  
  inner join EmployeeInvolved ei on ei.InvolvedID=e.EmployeeID 
  left join MasterRole mr on mr.Id=ei.InvolvedRole
  where ei.IncidentID=@IncidentId and FetchDetailsBy='Employee'
 UNION
 Select ei.ID,ei.InvolvedID,ei.EmployeeID,s.FirstName,s.LastName,s.Sex,s.Race,mr.Id as RoleID,mr.Role as RoleName from Subjects s  
  inner join EmployeeInvolved ei on ei.InvolvedID=s.SubjectID 
  left join MasterRole mr on mr.Id=ei.InvolvedRole
  where ei.IncidentID=@IncidentId and FetchDetailsBy='Subject'
END

GO
/****** Object:  StoredProcedure [dbo].[EmployeeLicense_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[EmployeeLicense_AddEdit]  
 (    
 @LicenseID int,  
 @EmployeeID int,  
 @DateOfHire datetime,  
 @TerminationDate datetime,  
 @LicenseExpirationDate datetime,  
 @Department nvarchar(50),  
 @LicenseType nvarchar(50),  
 @LicenseStatus nvarchar(50),  
 @ReasonForLeaving ntext  
 )  
 as  
 BEGIN  
  
 IF EXISTS (SELECT * FROM  EmployeeLicense WHERE LicenseID=@LicenseID)  
 BEGIN  
 UPDATE EmployeeLicense SET   
   EmployeeID=@EmployeeID,DateOfHire=@DateOfHire, TerminationDate=@TerminationDate, LicenseExpirationDate=@LicenseExpirationDate, Department=@Department, LicenseType=@LicenseType, LicenseStatus=@LicenseStatus, ReasonForLeaving=@ReasonForLeaving  
      WHERE LicenseID=@LicenseID  
   SELECT @@ROWCOUNT AS Result  
 END  
 ELSE  
 BEGIN  
 
 DELETE FROM EmployeeLicense WHERE EmployeeID =@EmployeeID
 
  INSERT INTO EmployeeLicense(EmployeeID, DateOfHire, TerminationDate, LicenseExpirationDate, Department, LicenseType, LicenseStatus, ReasonForLeaving)   
     VALUES (@EmployeeID, @DateOfHire, @TerminationDate, @LicenseExpirationDate, @Department, @LicenseType, @LicenseStatus, @ReasonForLeaving)  
     SELECT @@Identity AS Result  
 END  
  
 END  
  
 
GO
/****** Object:  StoredProcedure [dbo].[EmployeeLicense_LoadByEmployeeID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeLicense_LoadByEmployeeID]  --2
@EmployeeID int =0   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *  from EmployeeLicense where EmployeeID = @EmployeeID 
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeLinked_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmployeeLinked_DeleteById]     
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from EmployeeLinked where ID = @ID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeLinked_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeLinked_IU]   
@ID int =0,
@IncidentID int =0,  
@EmployeeID int=0,
@Description nvarchar(max) = null,
@FilePath nvarchar(max) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@ID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update EmployeeLinked set
			EmployeeID = @EmployeeID,
			IncidentID = @IncidentID,
			Description = @Description,
			FilePath = ISNULL(@FilePath,FilePath)  
			where ID = @ID 
			select @ID  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into EmployeeLinked(EmployeeID ,IncidentID ,Description ,FilePath) 
			values (@EmployeeID,@IncidentID ,@Description ,@FilePath)          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeLinked_LoadByEmployeeID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeLinked_LoadByEmployeeID]    
@EmployeeID int =0,
@IncidentId int=-1
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
  select *  from EmployeeLinked 
  where EmployeeID = @EmployeeID  
  and IncidentID=@IncidentId 
  select @@RowCount  
 End   
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeLinked_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmployeeLinked_LoadById]  -- 1  
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from EmployeeLinked where ID = @ID 
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeePaceAudit_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeePaceAudit_IU]
(
@IncidentId int=0,
@Game nvarchar(30)=null,
@ShuffleShoe nvarchar(10)=null,
@TimeTaken nvarchar(25)=null,
@DisplayName nvarchar(50)=null,
@StartTime nvarchar(25)=null,
@EndTime nvarchar(25)=null,
@Descripton ntext=null,
@PaceAuditPositionsPlayed int=0,
@PaceAuditHandsPlayed int=0,
@PaceAuditHandsPerHour int=0,
@Observation int=0
)
AS
BEGIN
	If exists(Select * from EmployeePaceAuditShuffleShoe where 
	IncidentID=@IncidentId and 
	Game=@Game and 
	Observation=@Observation and
	ShuffleShoe=@ShuffleShoe and 
	DisplayName=@DisplayName)
	Begin
		update EmployeePaceAuditShuffleShoe set 
		TimeTaken=@TimeTaken,
		StartTime=@StartTime,
		EndTime=@EndTime,
		Description=@Descripton,
		PaceAuditPositionsPlayed=@PaceAuditPositionsPlayed,
		PaceAuditHandsPlayed=@PaceAuditHandsPlayed,
		PaceAuditHandsPerHour=@PaceAuditHandsPerHour
		where 
		IncidentID=@IncidentId and 
		Game=@Game and 
		Observation=@Observation and
		ShuffleShoe=@ShuffleShoe and 
		DisplayName=@DisplayName
		
		select @@Rowcount
	End
	
	else
	begin
		Insert into EmployeePaceAuditShuffleShoe
		values(
		@IncidentId,
		@Game,
		@ShuffleShoe,
		@TimeTaken,
		@DisplayName ,
		@StartTime,
		@EndTime,
		@Descripton,
		@PaceAuditPositionsPlayed,
		@PaceAuditHandsPlayed,
		@PaceAuditHandsPerHour, 
		 @Observation
		)
		select @@Rowcount
	end
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeePersonal_Add]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[EmployeePersonal_Add]
 (     
 @EmployeeID int,   
 @IDType1 nvarchar(50), 
 @IDNumber1 nvarchar(50), 
 @IDDefault1 bit,
 @IDType2 nvarchar(50), 
 @IDNumber2 nvarchar(50), 
 @IDDefault2 bit,
 @IDType3 nvarchar(50), 
 @IDNumber3 nvarchar(50), 
 @IDDefault3 bit,  
 @DateOfBirth datetime 
 )  
 as  
 BEGIN  
 
 DELETE FROM EmployeePersonal WHERE EmployeeID =@EmployeeID
 
  INSERT INTO EmployeePersonal(EmployeeID,IDType1, IDNumber1, IDDefault1, IDType2, IDNumber2, IDDefault2, IDType3, IDNumber3, IDDefault3, DateOfBirth)   
     VALUES (@EmployeeID,@IDType1, @IDNumber1, @IDDefault1, @IDType2, @IDNumber2, @IDDefault2, @IDType3, @IDNumber3, @IDDefault3, @DateOfBirth)  
     SELECT @@Identity AS Result  
 END   
  
 
GO
/****** Object:  StoredProcedure [dbo].[EmployeePersonal_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeePersonal_IU]      
@EmployeeID int=0,       
@UD10 nvarchar(50) = null,    
@UD11 nvarchar(50) = null,    
@UD12 nvarchar(50) = null,    
@UD13 nvarchar(50) = null,    
@UD14 nvarchar(50) = null,    
@UD15 nvarchar(50) = null,    
@IDType1 nvarchar(200) = null,    
@IDNumber1 nvarchar(200) = null,    
@IDDefault1 int = 0,    
@IDType2 nvarchar(200) = null,    
@IDNumber2 nvarchar(200) = null,    
@IDDefault2 bit = 'false',    
@IDType3 nvarchar(200) = null,    
@IDNumber3 nvarchar(200)= null,    
@IDDefault3 bit = 'false',    
@DateOfBirth datetime= null    
AS                 
BEGIN       
  Begin Try                
   Begin Transaction     
 --  If(exists (select * from EmployeePersonal where EmployeeID = @EmployeeID ))    
 --   Begin     
 --  update EmployeePersonal set    
 --  UD10 = @UD10,    
 --  UD11 =@UD11,    
 --  UD12 = @UD12,    
 --  UD13 = @UD13,    
 --  UD14 =@UD14,    
 --  UD15 = @UD15,    
 --  IDType1 = @IDType1,    
 --  IDNumber1 = @IDNumber1,    
 --  IDDefault1 =  @IDDefault1,    
 --  IDType2 = @IDType2,    
 --  IDNumber2 = @IDNumber2,    
 --  IDDefault2 = @IDDefault2,    
 --  IDType3 = @IDType3,    
 --  IDNumber3 = @IDNumber3,    
 --  IDDefault3 = @IDDefault3,    
 --  DateOfBirth = @DateOfBirth where EmployeeID = @EmployeeID     
 --  select @EmployeeID      
 --End     
 --   Else    
 Begin    
 DELETE FROM EmployeePersonal WHERE EmployeeID =@EmployeeID    
    
   Insert into EmployeePersonal(EmployeeID,UD10,UD11,UD12,UD13,UD14,UD15,IDType1,    
   IDNumber1,IDDefault1,IDType2,IDNumber2,IDDefault2,IDType3,IDNumber3,IDDefault3,DateOfBirth)     
   values (@EmployeeID,@UD10,@UD11,@UD12,@UD13,@UD14,@UD15,@IDType1,@IDNumber1,@IDDefault1,@IDType2,    
   @IDNumber2,@IDDefault2,@IDType3,@IDNumber3,@IDDefault3,@DateOfBirth)      
   select @@IDENTITY    
 End     
  COMMIT TRANSACTION     
 End try        
 Begin Catch             
  IF @@TRANCOUNT >0             
          Select ERROR_MESSAGE()    
    Rollback Transaction      
    EXECUTE [uspLogError]               
 End Catch                
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeePersonal_LoadByEmployeeID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EmployeePersonal_LoadByEmployeeID]  
@EmployeeID int =0   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *  from EmployeePersonal where EmployeeID = @EmployeeID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeePosition_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[EmployeePosition_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from EmployeePosition where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END  
GO
/****** Object:  StoredProcedure [dbo].[EmployeePosition_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeePosition_IU](        
@Id int,        
@Position nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM EmployeePosition  where Id=@Id)          
   begin          
   update EmployeePosition set Position=@Position where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into EmployeePosition(Position) values(@Position)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END  
GO
/****** Object:  StoredProcedure [dbo].[EmployeePosition_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[EmployeePosition_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from EmployeePosition        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END      
GO
/****** Object:  StoredProcedure [dbo].[EmployeeReportEventsLink_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeReportEventsLink_Delete]     
@EmployeeID int =0,
@IncidentID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			DELETE FROM EventEmployeeIncidents WHERE EmployeeID = @EmployeeID AND IncidentID = @IncidentID; 
			SELECT @@ROWCOUNT;   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[Employees_dashboard]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employees_dashboard](@UserID           INT,
                                            @ReportAccessRole INT = 0)
AS
     BEGIN
         --SELECT TOP (10) Employees.EmployeeID,
         --                Employees.FirstName,
         --                Employees.MiddleName,
         --                Employees.LastName,
         --                Employees.CreatedDate,
         --                Users.FirstName+' '+Users.LastName AS CreatedByUser,
         --(
         --    SELECT COUNT(*)
         --    FROM Employees
         --) AS TotalEmployees,
         --(
         --    SELECT TOP (1) PV.FilePath
         --    FROM EmployeePicturesVideos EPV
         --         LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
         --    WHERE EmployeeID = Employees.EmployeeID
         --) AS FilePath
         --FROM Employees
         --     LEFT JOIN Users ON Users.ID = Employees.UserID
         --ORDER BY Employees.EmployeeID DESC;

         IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
                 SELECT TOP (10) Employees.EmployeeID,
                                 Employees.FirstName,
                                 Employees.MiddleName,
                                 Employees.LastName,
                                 Employees.CreatedDate,
                                 Users.FirstName+' '+Users.LastName AS CreatedByUser,
                 (
                     SELECT COUNT(*)
                     FROM Employees
                 ) AS TotalEmployees,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EmployeePicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EmployeeID = Employees.EmployeeID
                 ) AS FilePath
                 FROM Employees
                      LEFT JOIN Users ON Users.ID = Employees.UserID
                 ORDER BY Employees.EmployeeID DESC;
             END;
         ELSE
             BEGIN
                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.EmployeeID, UP.EmployeeID) AS EmployeeID
                         FROM
                         (
                             SELECT EmployeeID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM EmployeeAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ViewReport = '1'
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT EmployeeID,
                                    ViewReport,
                                    2 ByUser
                             FROM EmployeeAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                         ) AS UP ON RP.EmployeeID = UP.EmployeeID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.EmployeeID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.EmployeeID IS NULL))
                      SELECT TOP (10) Employees.EmployeeID,
                                      Employees.FirstName,
                                      Employees.MiddleName,
                                      Employees.LastName,
                                      Employees.CreatedDate,
                                      Users.FirstName+' '+Users.LastName AS CreatedByUser,
                      (
                          SELECT COUNT(*)
                          FROM Employees
                          WHERE UserID = @UserID
                                OR EmployeeID IN
                          (
                              SELECT EmployeeID
                              FROM cteReportPermission
                          )
                      ) AS TotalEmployees,
                      (
                          SELECT TOP (1) PV.FilePath
                          FROM EmployeePicturesVideos EPV
                               LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                          WHERE EmployeeID = Employees.EmployeeID
                      ) AS FilePath
                      FROM Employees
                           INNER JOIN Users ON Users.ID = Employees.UserID
                      WHERE UserID = @UserID
                            OR EmployeeID IN
                      (
                          SELECT EmployeeID
                          FROM cteReportPermission
                      )
                      ORDER BY Employees.EmployeeID DESC;
             END;
     END;
GO
/****** Object:  StoredProcedure [dbo].[Employees_FirstNameSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Employees_FirstNameSearch]
(  
 @FirstName nvarchar(25) = ''                  
)                  
AS                  
BEGIN                  
 BEGIN TRY                                                      
  BEGIN TRANSACTION
  DECLARE @query NVARCHAR(1000);      
    SET @query='SELECT (FirstName + '' '' + LastName) AS FirstName,EmployeeID FROM Employees WHERE FirstName LIKE ''' + @FirstName + '%'' GROUP BY FirstName,LastName,EmployeeID ORDER BY FirstName' ;   
    --EXEC(@query)  
     DECLARE @ParameterDefinition AS NVARCHAR(100);
    SET @ParameterDefinition =  '@FirstName nvarchar(25)';
    Execute sp_Executesql @query,@ParameterDefinition,@FirstName;     
  COMMIT TRANSACTION                  
 END TRY                                                    
 BEGIN CATCH                                                      
  IF @@TRANCOUNT >0                                       
   ROLLBACK TRANSACTION;              
	SELECT 1 AS result                   
    SELECT ERROR_MESSAGE() AS ErrorNumber; 
 END CATCH;                   
END




GO
/****** Object:  StoredProcedure [dbo].[Employees_Insert]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Employees_Insert]
(   @UserID int,
	@EmpNumber nvarchar(25)=NULL,
	@Age float =NULL,
	@Sex nvarchar(10)= NULL,
	@Race nvarchar(25)= NULL,
	@LastName nvarchar(25) =NULL,
	@FirstName nvarchar(25)= NULL,
	@MiddleName nvarchar(20)= NULL,
	@Height nvarchar(25)= NULL,
	@Weight nvarchar(25)= NULL,
	@DateOfBirth datetime= NULL,
	@StaffPosition nvarchar(50)= NULL,
	@Eyes nvarchar(10)=NULL,
	@Complexion nvarchar(15)=NULL,
	@Build nvarchar(15) =NULL,
	@Glasses nvarchar(10) =NULL,
	@Restricted bit,
	@Status nvarchar(50)=NULL,
	@RoleName nvarchar(50) =NULL,
	@UD9 nvarchar(50)= NULL
	)
as
begin
INSERT INTO Employees (UserID, EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight,DateOfBirth, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9,CreatedDate)
values (@UserID,@EmpNumber, @Age, @Sex, @Race, @LastName, @FirstName, @MiddleName, @Height, @Weight,@DateOfBirth, @StaffPosition, @Eyes, @Complexion, @Build, @Glasses, @Restricted, @RoleName, @UD9,getdate())
Select @@IDENTITY as Result
End


GO
/****** Object:  StoredProcedure [dbo].[Employees_LastNameSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Employees_LastNameSearch]
(  
  @FirstName nvarchar(25) = null,
 @LastName nvarchar(25) = ''                    
)                  
AS                  
BEGIN                  
 BEGIN TRY                                                      
  BEGIN TRANSACTION
  DECLARE @query NVARCHAR(1000);      
   IF(@FirstName IS NULL)
	  BEGIN
		 SET @query='SELECT LastName FROM Employees WHERE LastName LIKE ''' + 
			   @LastName + '%'' GROUP BY LastName ORDER BY LastName' ; 
	  END
	  ELSE
	  BEGIN
		 SET @query='SELECT LastName FROM Employees WHERE FirstName LIKE ''' + @FirstName + '%'' AND LastName LIKE ''' + 
			 @LastName + '%'' GROUP BY LastName ORDER BY LastName' ;   
	  END	    
    --EXEC(@query)       
      DECLARE @ParameterDefinition AS NVARCHAR(100);
    SET @ParameterDefinition =  '@FirstName nvarchar(25),@LastName nvarchar(25)';
    Execute sp_Executesql @query,@ParameterDefinition,@FirstName,@LastName;
  COMMIT TRANSACTION                  
 END TRY                                                    
 BEGIN CATCH                                                      
  IF @@TRANCOUNT >0                                       
   ROLLBACK TRANSACTION;              
	SELECT 1 AS result                   
    SELECT ERROR_MESSAGE() AS ErrorNumber; 
 END CATCH;                   
END




GO
/****** Object:  StoredProcedure [dbo].[Employees_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employees_Load](@employeeID       INT,
                                       @ReportAccessRole INT,
                                       @UserID           INT)
AS
     DECLARE @editpermission BIT= 0;
	DECLARE @deletepermission BIT= 0;
     BEGIN
         IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
                 SET @editpermission = 1;
			  SET @deletepermission = 1;
             END;
         WITH cteeditPermission
              AS (SELECT ISNULL(RP.EmployeeID, UP.EmployeeID) AS EmployeeID
                  FROM
                  (
                      SELECT EmployeeID,
                             EditReport,
                             1 AS ByRole
                      FROM EmployeeAccessByRole
                      WHERE ReportAccessRole = @ReportAccessRole
                            AND EditReport = '1'
                            AND EmployeeID = @employeeID
                  ) AS RP
                  FULL JOIN
                  (
                      SELECT EmployeeID,
                             EditReport,
                             2 ByUser
                      FROM EmployeeAccessUsers
                      WHERE ReportAccessBy = @UserID
                            AND EditReport = '1'
                            AND EmployeeID = @employeeID
                  ) AS UP ON RP.EmployeeID = UP.EmployeeID
                  WHERE(RP.EditReport = 1
                        AND UP.EditReport = 1)
                       --OR (RP.EditReport = 1
                       --    AND UP.EmployeeID IS NULL)
                       OR (UP.EditReport = 1
                           AND RP.EmployeeID IS NULL)),
			  ctedeletePermission
              AS (SELECT ISNULL(RP.EmployeeID, UP.EmployeeID) AS EmployeeID
                  FROM
                  (
                      SELECT EmployeeID,
                             DeleteReport,
                             1 AS ByRole
                      FROM EmployeeAccessByRole
                      WHERE ReportAccessRole = @ReportAccessRole
                            AND DeleteReport = '1'
                            AND EmployeeID = @employeeID
                  ) AS RP
                  FULL JOIN
                  (
                      SELECT EmployeeID,
                             DeleteReport,
                             2 ByUser
                      FROM EmployeeAccessUsers
                      WHERE ReportAccessBy = @UserID
                            AND EditReport = '1'
                            AND EmployeeID = @employeeID
                  ) AS UP ON RP.EmployeeID = UP.EmployeeID
                  WHERE(RP.DeleteReport = 1
                        AND UP.DeleteReport = 1)
                       --OR (RP.EditReport = 1
                       --    AND UP.EmployeeID IS NULL)
                       OR (UP.DeleteReport = 1
                           AND RP.EmployeeID IS NULL))

              SELECT Users.UserName AS CreatorUser,
                     Users.FirstName AS CreatorFirstName,
                     Users.LastName AS CreatorLastName,
                     (CASE
                          WHEN @editpermission = 1
                          THEN @editpermission
                          ELSE(CASE
                                   WHEN
                              (
                                  SELECT COUNT(*)
                                  FROM cteeditPermission
                              ) > 0
                                   THEN 1
                                   ELSE 0
                               END)
                      END) AS editpermission,
				  (CASE
                          WHEN @deletepermission = 1
                          THEN @deletepermission
                          ELSE(CASE
                                   WHEN
                              (
                                  SELECT COUNT(*)
                                  FROM ctedeletePermission
                              ) > 0
                                   THEN 1
                                   ELSE 0
                               END)
                      END) AS deletepermission,
                     Employees.*,
              (
                  SELECT TOP (1) PV.FilePath
                  FROM EmployeePicturesVideos EPV
                       LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                  WHERE EPV.MediaType = 'Employee'
                        AND EmployeeID = Employees.EmployeeID
              ) AS FilePath
              FROM Employees
                   INNER JOIN Users ON Users.ID = Employees.UserID
              WHERE employeeID = @employeeID;
     END;
GO
/****** Object:  StoredProcedure [dbo].[Employees_Update]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Employees_Update]
(   @UserID int,
    @empID int,
	@EmpNumber nvarchar(25)=NULL,
	@Age float =NULL,
	@Sex nvarchar(10)= NULL,
	@Race nvarchar(25)= NULL,
	@LastName nvarchar(25) =NULL,
	@FirstName nvarchar(25)= NULL,
	@MiddleName nvarchar(20)= NULL,
	@Height nvarchar(25)= NULL,
	@Weight nvarchar(25)= NULL,
	@DateOfBirth datetime =null,
	@StaffPosition nvarchar(50)= NULL,
	@Eyes nvarchar(10)=NULL,
	@Complexion nvarchar(15)=NULL,
	@Build nvarchar(15) =NULL,
	@Glasses nvarchar(10) =NULL,	
	@UD9 nvarchar(50) =NULL
	)
as
begin
UPDATE Employees Set  UserID=@UserID, EmpNumber =@EmpNumber, Age = @Age, Sex = @Sex, Race = @Race, LastName = @LastName, FirstName = @FirstName,
 MiddleName = @MiddleName, Height = @Height, Weight = @Weight,DateOfBirth =@DateOfBirth, StaffPosition = @StaffPosition, Eyes = @Eyes, Complexion = @Complexion,
 Build = @Build, Glasses = @Glasses, UD9 = @UD9 WHERE EmployeeID = @empID
Select @@ROWCOUNT  as Result
End

GO
/****** Object:  StoredProcedure [dbo].[EmployeesInvolved_InsertUpdate]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmployeesInvolved_InsertUpdate]
(
@ID int=0,   
@UserID int=0,
@EmployeeId int=0,  
@InvolvedId int=0,
@IncidentID int=0,  
@Sex nvarchar(10)= NULL,  
@Race nvarchar(25)= NULL,  
@LastName nvarchar(25) =NULL,  
@FirstName nvarchar(25)= NULL, 
@RoleName nvarchar(50) =NULL
 )  
as  
begin 
 if(@ID>0)
  begin
   update Employees set UserID=@UserID,Sex=@Sex,Race=@Race,LastName=@LastName,FirstName=@FirstName where EmployeeID=@InvolvedId
    select @@RowCount
   update EmployeeInvolved set InvolvedRole=@RoleName where ID=@ID
	select @@RowCount
  end
 else
  begin 
   INSERT INTO Employees (UserID, Sex, Race, LastName, FirstName, RoleName,CreatedDate,EmpNumber) values (@UserID, @Sex, @Race, @LastName, @FirstName , @RoleName,getdate(),DATEDIFF(second,{d '1970-01-01'},getdate()))  
    Select @InvolvedId=@@IDENTITY 
   Insert into  EmployeeInvolved (EmployeeId,IncidentID,InvolvedId,InvolvedRole,FetchDetailsBy) values(@EmployeeId,@IncidentID,@InvolvedId,@RoleName,'Employee')
    Select @@IDENTITY 
 end 
End 

GO
/****** Object:  StoredProcedure [dbo].[EmployeeStatus_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[EmployeeStatus_Delete](          
@Id int          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Delete from EmployeeStatus where Id=@Id           
   Select @@RowCount as RESULT           
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 
GO
/****** Object:  StoredProcedure [dbo].[EmployeeStatus_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[EmployeeStatus_IU](          
@Id int,          
@EmpStatus nvarchar(200)          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM EmployeeStatus  where Id=@Id)            
   begin            
   update EmployeeStatus set EmpStatus=@EmpStatus where Id=@Id            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into EmployeeStatus(EmpStatus) values(@EmpStatus)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[EmployeeStatus_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[EmployeeStatus_Load]          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Select * from EmployeeStatus          
   Select @@RowCount as RESULT          
  End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[EmployeeVariance_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CReate procedure [dbo].[EmployeeVariance_IU]      
   
@Id int=0 , 
@VarianceDescription ntext=null,  
@VarianceType nvarchar(50)=null,
@Resolution nvarchar(50)=null,
@Amount float=null,
@AmountType int=0
AS                 
BEGIN       
  Begin Try                
   Begin Transaction     
   
 Begin    
   if exists(Select * from EmployeeVariance where IncidentID=@Id)
   begin
	update EmployeeVariance set 
	Resolution=@Resolution,
	Amount=@Amount,
	VarianceType=@VarianceType,
	Description=@VarianceDescription,
	AmountType=@AmountType
	where IncidentID=@Id  
   end
     
  else  
  begin  
    
    Insert into EmployeeVariance(  
   IncidentID,
   Resolution,
   Amount,
   VarianceType,
   Description,
   AmountType
    )     
    values (  
   @Id,
   @Resolution,
   @Amount,
   @VarianceType,
   @VarianceDescription,
   @AmountType
    )      
        
    select @@IDENTITY      
   end  
 End     
  COMMIT TRANSACTION     
 End try        
 Begin Catch             
  IF @@TRANCOUNT >0             
          Select ERROR_MESSAGE()    
    Rollback Transaction      
    EXECUTE [uspLogError]               
 End Catch                
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeVariance_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EmployeeVariance_LoadByIncidentID]
@IncidentId int=0
As
BEGIN
	Select * from EmployeeVariance where IncidentID=@IncidentId
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeVariance_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[EmployeeVariance_print] --'Short','',''
(
@Type nvarchar(100),
@StartDate datetime,
@EndDate datetime
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' (EmployeeVariance.AmountShort = 1) AND IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+' (EmployeeVariance.AmountShort = 1) AND IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' (EmployeeVariance.AmountShort = 1) AND IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 

	  if(@Type='Short')
		set @SQL='SELECT Employees.LastName + '' '' + Employees.FirstName AS Employee,
				EmployeeIncidents.ShortDescriptor, COUNT(*) AS IncidentCount, 
				SUM(EmployeeVariance.Amount) AS SumAmount FROM EmployeeVariance
				INNER JOIN EmployeeIncidents ON EmployeeVariance.IncidentID = EmployeeIncidents.IncidentID
				INNER JOIN EmpEmployeeIncidents ON EmployeeIncidents.IncidentID = EmpEmployeeIncidents.IncidentID
				INNER JOIN Employees ON EmpEmployeeIncidents.EmployeeID = Employees.EmployeeID 
				'+ @Where+'
				GROUP BY Employees.LastName, Employees.FirstName, EmployeeIncidents.ShortDescriptor 
				ORDER BY Employees.LastName, Employees.FirstName'
	  else
		set @SQL='SELECT Employees.LastName + '' '' + Employees.FirstName AS Employee,
				EmployeeIncidents.ShortDescriptor, COUNT(*) AS IncidentCount, 
				SUM(EmployeeVariance.Amount) AS SumAmount FROM EmployeeVariance 
				INNER JOIN EmployeeIncidents ON EmployeeVariance.IncidentID = EmployeeIncidents.IncidentID 
				INNER JOIN EmpEmployeeIncidents ON EmployeeIncidents.IncidentID = EmpEmployeeIncidents.IncidentID 
				INNER JOIN Employees ON EmpEmployeeIncidents.EmployeeID = Employees.EmployeeID 
				'+ @Where+'
				GROUP BY Employees.LastName, Employees.FirstName, EmployeeIncidents.ShortDescriptor 
				ORDER BY Employees.LastName, Employees.FirstName'
execute(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[EmpReportAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmpReportAccessPermission]
(
@ID int,
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EmpReportsAccessUsers set ViewReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EmpReportsAccessUsers set EditReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EmpReportsAccessUsers set DeleteReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EmpReportAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmpReportAccessPermissionByRole]
(
@ID int,
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EmpReportsAccessByRole set ViewReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EmpReportsAccessByRole set EditReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EmpReportsAccessByRole set DeleteReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EmpReportCreatorPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmpReportCreatorPermission]
(
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EmployeeIncidents set ReportView=@Permission where IncidentID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EmployeeIncidents set ReportEdit=@Permission where IncidentID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EmployeeIncidents set ReportDelete=@Permission where IncidentID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EmpReportProofread_add]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmpReportProofread_add](
@ProofreadID int,
@EmployeeID int,
@ReportID int,
@ReportProofread bit,
@UserID int
)
AS  
BEGIN             
  Begin Try  
	if(@ProofreadID>0)
	 Begin
	  Update EmpReportProofread set ReportProofread=@ReportProofread,UserID=@UserID,CreatedDate=getdate() where EmployeeID=@EmployeeID and ReportID=@ReportID;
	   
	   Insert into EmpReportProofread_log(EmployeeID,ReportID,ReportProofread,UserID,CreatedDate)
		values(@EmployeeID,@ReportID,@ReportProofread,@UserID,getdate());

	  Select @@identity as Result
	 End
	Else
	 Begin
	  Insert into EmpReportProofread(EmployeeID,ReportID,ReportProofread,UserID,CreatedDate)
		values(@EmployeeID,@ReportID,@ReportProofread,@UserID,getdate());
	   
	   Insert into EmpReportProofread_log(EmployeeID,ReportID,ReportProofread,UserID,CreatedDate)
		values(@EmployeeID,@ReportID,@ReportProofread,@UserID,getdate());

	  Select @@identity as Result
	 End
     
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 


GO
/****** Object:  StoredProcedure [dbo].[EmpReportProofread_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmpReportProofread_Bind](
@EmployeeID int,
@ReportID int
)
AS  
BEGIN             
  Begin Try                      
     select Users.UserName,Users.FirstName,Users.LastName,EmpReportProofread.* from EmpReportProofread 
	 left join Users on Users.ID=EmpReportProofread.UserID
	 where EmployeeID=@EmployeeID and ReportID=@ReportID
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[EmpReportProofread_Check]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmpReportProofread_Check](
@EmployeeID int,
@ReportID int
)
AS  
BEGIN             
  Begin Try   
	select * from EmpReportProofread where EmployeeID=@EmployeeID and ReportID=@ReportID
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[EmpReportProofread_Log_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmpReportProofread_Log_Bind](
    @EmployeeID int,
    @ReportID int
)
AS  
BEGIN             
  Begin Try                      
     SELECT Users.UserName,Users.FirstName,Users.LastName
	,CASE EL.ReportProofread WHEN 1 THEN 'Yes' ELSE 'No' END AS ReportProofread
	,EL.CreatedDate
	FROM EmpReportProofread_Log AS EL
	 LEFT JOIN Users on Users.ID = EL.UserID
	 WHERE EmployeeID = @EmployeeID and ReportID=@ReportID
   End try              
 Begin Catch                   
  IF @@TRANCOUNT > 0                   
    SELECT ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[EmpReportsAccessPermission_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EmpReportsAccessPermission_AddEdit] --0,28,52,16,'true','true','true',1
(
@ID int=0,
@EmployeeID int=0,
@ReportID int=0,
@ReportAccessBy int=0,
@ReportView bit = 'false',
@ReportEdit bit = 'false',
@ReportDelete bit = 'false',
@CreatedBy int=0
)
as
begin
	if(Not Exists(select * from EmpReportsAccessPermission where ID=@ID))
	begin
		Insert into EmpReportsAccessPermission(EmployeeID,ReportID,ReportAccessBy,ReportView,
			ReportEdit,ReportDelete,CreatedBy,ModifyDate) values(@EmployeeID,@ReportID,
			@ReportAccessBy,@ReportView,@ReportEdit,@ReportDelete,@CreatedBy,getdate())		
		SELECT @@IDENTITY AS RESULT 
	end
	else
	begin
		Update EmpReportsAccessPermission
			set ReportView=@ReportView,ReportEdit=@ReportEdit,ReportDelete=@ReportDelete,
			ModifyDate=getdate() where ID=@ID
		SELECT @@ROWCOUNT AS RESULT
	end
end

GO
/****** Object:  StoredProcedure [dbo].[EquipmentAction_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[EquipmentAction_Delete](            
@Id int            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Delete from EquipmentAction where Id=@Id             
   Select @@RowCount as RESULT             
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 
GO
/****** Object:  StoredProcedure [dbo].[EquipmentAction_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE Procedure [dbo].[EquipmentAction_IU](  
@Id int,            
@Actions nvarchar(200)            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
  if exists(SELECT *  FROM EquipmentAction  where Id=@Id)              
   begin              
   update EquipmentAction set Actions=@Actions where Id=@Id              
   select @@RowCount as RESULT          
   end              
  ELSE              
  begin              
   insert into EquipmentAction(Actions) values(@Actions)              
   select @@Identity as RESULT            
  end              
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[EquipmentAction_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[EquipmentAction_Load]            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Select * from EquipmentAction            
   Select @@RowCount as RESULT            
  End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[EquipmentProblems_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure  [dbo].[EquipmentProblems_AddEdit] 
(    @userID int,
	 @ProblemID int,
	 @ProblemType nvarchar (50),
	 @EquipNumber nvarchar (50),
	 @Problem  nvarchar (50),
	 @Details  ntext ,
	 @Corrected bit,
	 @Solution nvarchar(50),
	 @Replacement nvarchar(50),
	 @StatusTime datetime,
	 @CompletedTime datetime
 )

 AS
 BEGIN
  IF EXISTS (SELECT * FROM EquipmentProblems WHERE ProblemID=@ProblemID)
  BEGIN
    UPDATE EquipmentProblems SET ProblemType=@ProblemType,EquipNumber=@EquipNumber,Problem=@Problem,Details=@Details,Corrected=@Corrected,
	Solution=@Solution,Replacement=@Replacement,StatusTime=@StatusTime,CompletedTime=@CompletedTime  WHERE ProblemID=@ProblemID
	SELECT @@ROWCOUNT AS RESULT 
  END
  ELSE
  BEGIN
   INSERT INTO EquipmentProblems (ProblemType,EquipNumber,Problem,Details,Corrected,Solution,Replacement,StatusTime,CompletedTime,userID)
   VALUES (@ProblemType,@EquipNumber,@Problem,@Details,@Corrected,@Solution,@Replacement,@StatusTime,@CompletedTime,@userID)
    SELECT @@IDENTITY AS RESULT 
  END

 END




GO
/****** Object:  StoredProcedure [dbo].[EquipmentProblems_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Procedure  [dbo].[EquipmentProblems_Delete] 
(   
	 @ProblemID int	
 )

 AS
 BEGIN 
    Delete FROM EquipmentProblems WHERE ProblemID=@ProblemID
	SELECT @@ROWCOUNT AS RESULT
  END
GO
/****** Object:  StoredProcedure [dbo].[EquipmentProblems_Filter]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [dbo].[EquipmentProblems_Filter] --'1',null,null,1  
(  
@isCorrected bit,  
@StartDate DATETIME,        
@EndDate DATETIME,  
@userID int      
)  
as  
 declare @SQL varchar(max)          
 declare @Where varchar(max)   
 set @Where =' 1=1'  
begin  
  
--convert(varchar, @inputDate, 106)-  
  set @Where=' Where UserID = '''+convert(varchar(20),@userID)+''''  
        
  if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+'AND StatusTime Between ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
  if (@StartDate  <>'' AND @EndDate  ='')        
    set @Where=@Where+'AND StatusTime >= '''+convert(varchar,@EndDate,101)+''''               
   if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+'AND CompletedTime <= '''+convert(varchar,@EndDate,101)+''''      
     IF(@isCorrected =1)  
   Set @Where=@Where+' and isnull(Corrected,0)= '+convert(nvarchar(10),@isCorrected)+' '   
  ELSE  
 Set @Where=@Where+' and isnull(Corrected,0)= '+convert(nvarchar(10),@isCorrected)+' '       
            
    SET @SQL ='Select * from EquipmentProblems'+ @Where  
  
 exec(@SQL)  
    
end  
  
  
  
  

GO
/****** Object:  StoredProcedure [dbo].[EquipmentProblems_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create  Procedure  [dbo].[EquipmentProblems_Load] 
(   
	 @ProblemID int	
 )

 AS
 BEGIN 
    SELECT * FROM EquipmentProblems WHERE ProblemID=@ProblemID
  END


GO
/****** Object:  StoredProcedure [dbo].[EquipmentProblems_LoadByUserID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  Procedure  [dbo].[EquipmentProblems_LoadByUserID] 
(   
	 @userID int	
 )

 AS
 BEGIN 
    SELECT * FROM EquipmentProblems WHERE userID=@userID
  END
GO
/****** Object:  StoredProcedure [dbo].[EquipmentStatus_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[EquipmentStatus_Delete](            
@Id int            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Delete from EquipmentStatus where Id=@Id             
   Select @@RowCount as RESULT             
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 
GO
/****** Object:  StoredProcedure [dbo].[EquipmentStatus_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[EquipmentStatus_IU](  
@Id int,            
@Problems nvarchar(200)            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
  if exists(SELECT *  FROM EquipmentStatus  where Id=@Id)              
   begin              
   update EquipmentStatus set Problems=@Problems where Id=@Id              
   select @@RowCount as RESULT          
   end              
  ELSE              
  begin              
   insert into EquipmentStatus(Problems) values(@Problems)              
   select @@Identity as RESULT            
  end              
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[EquipmentStatus_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[EquipmentStatus_Load]            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Select * from EquipmentStatus            
   Select @@RowCount as RESULT            
  End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[Event_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Event_DeleteById]
(
@EventID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from EventLog where EventID=@EventID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End

GO
/****** Object:  StoredProcedure [dbo].[Event_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[Event_LoadById] 3,17
CREATE PROCEDURE [dbo].[Event_LoadById](@UserID           INT,
                                       @ReportAccessRole INT)
AS
     BEGIN
         BEGIN TRY
             BEGIN TRANSACTION;
             BEGIN
		   IF(
                   (
                       SELECT COUNT(*)
                       FROM Users
                       WHERE IsAdmin = 1
                             AND ID = @UserID
                   ) > 0)
                     BEGIN
                          SELECT EventLog.*,IB.Initiated,NC.Code AS NatureOfCode,
					(
					    SELECT TOP (1) PV.FilePath
					    FROM EventPicturesVideos EPV
						    LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
					    WHERE EventID = EventLog.EventID
					) AS FilePath
					FROM EventLog
					 LEFT JOIN InitiatedBy  AS IB ON EventLog.FromCode = IB.Id
				    LEFT JOIN NatureCodes  AS NC ON EventLog.NatureCode = NC.Id
                         ORDER BY EventLog.EventID DESC;
                     END;
		  ELSE
		  BEGIN
                         WITH cteReportPermission
                              AS(SELECT ISNULL(RP.EventID, UP.EventID) AS EventID
                                 FROM
                                 (
                                     SELECT EventID,
                                            ViewEvent,
                                            1 AS ByRole
                                     FROM EventsAccessByRole
                                     WHERE EventAccessRole = @ReportAccessRole
                                           AND ViewEvent = '1'
                                 ) AS RP
                                 FULL JOIN
                                 (
                                     SELECT EventID,
                                            ViewEvent,
                                            2 ByUser
                                     FROM EventsAccessUsers
                                     WHERE EventAccessBy = @UserID
                                           AND ViewEvent = '1'
                                 ) AS UP ON RP.EventID = UP.EventID
                                 WHERE(RP.ViewEvent = 1
                                       AND UP.ViewEvent = 1)
							    OR (RP.ViewEvent = 1 AND UP.EventID IS NULL)
                                      OR (UP.ViewEvent = 1
                                          AND RP.EventID IS NULL))

                             SELECT EventLog.*,IB.Initiated,NC.Code AS NatureOfCode,
					(
					    SELECT TOP (1) PV.FilePath
					    FROM EventPicturesVideos EPV
						    LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
					    WHERE EventID = EventLog.EventID
					) AS FilePath
					FROM EventLog
					 LEFT JOIN InitiatedBy  AS IB ON EventLog.FromCode = IB.Id
				    LEFT JOIN NatureCodes  AS NC ON EventLog.NatureCode = NC.Id
                              WHERE CreatedBy = @UserID
                                    OR EventID IN
                              (
                                  SELECT EventID
                                  FROM cteReportPermission
                              )
                              ORDER BY EventLog.EventID DESC;
                     END;
     --            DECLARE @userName VARCHAR(200)= '';
     --            SELECT @userName = UserName
     --            FROM Users
     --            WHERE ID = @UserID;

     --            SELECT EL.*,IB.Initiated,NC.Code AS NatureOfCode FROM
     --            (SELECT EventLog.*,
     --            (
     --                SELECT TOP (1) PV.FilePath
     --                FROM EventPicturesVideos EPV
     --                     LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
     --                WHERE EventID = EventLog.EventID
     --            ) AS FilePath
     --            FROM EventLog
     --            WHERE UserID = @userName
     --                  OR EventID IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessUsers
     --                WHERE ReportAccessBy = @UserID
     --                      AND ViewReport = '1'
     --            )
     --                  OR EventID IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessByRole
     --                WHERE ReportAccessRole = @ReportAccessRole
     --                      AND ViewReport = '1'
     --            )
     --            UNION
     --            SELECT EventLog.*,
     --            (
     --                SELECT TOP (1) PV.FilePath
     --                FROM EventPicturesVideos EPV
     --                     LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
     --                WHERE EventID = EventLog.EventID
     --            ) AS FilePath
     --            FROM EventLog
     --            WHERE EventID IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessByRole
     --                WHERE isnull(ViewReport, 0) = 0
     --                      AND isnull(EditReport, 0) = 0
     --                      AND isnull(DeleteReport, 0) = 0
     --            )
     --                  AND EventID IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessUsers
     --                WHERE isnull(ViewReport, 0) = 0
     --                      AND isnull(EditReport, 0) = 0
     --                      AND isnull(DeleteReport, 0) = 0
     --            )
     --            UNION
     --            SELECT EventLog.*,
     --            (
     --                SELECT TOP (1) PV.FilePath
     --                FROM EventPicturesVideos EPV
     --                     LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
     --                WHERE EventID = EventLog.EventID
     --            ) AS FilePath
     --            FROM EventLog
     --            WHERE EventID NOT IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessByRole
     --            )
     --                  AND EventID NOT IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessUsers
     --            )
     --            UNION
     --            SELECT EventLog.*,
     --            (
     --                SELECT TOP (1) PV.FilePath
     --                FROM EventPicturesVideos EPV
     --                     LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
     --                WHERE EventID = EventLog.EventID
     --            ) AS FilePath
     --            FROM EventLog
     --            WHERE EventID NOT IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessByRole
     --            )
     --                  AND EventID IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessUsers
     --                WHERE isnull(ViewReport, 0) = 0
     --                      AND isnull(EditReport, 0) = 0
     --                      AND isnull(DeleteReport, 0) = 0
     --            )
     --            UNION
     --            SELECT EventLog.*,
     --            (
     --                SELECT TOP (1) PV.FilePath
     --                FROM EventPicturesVideos EPV
     --                     LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
     --                WHERE EventID = EventLog.EventID
     --            ) AS FilePath
     --            FROM EventLog
     --            WHERE EventID NOT IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessUsers
     --            )
     --                  AND EventID IN
     --            (
     --                SELECT EventID
     --                FROM EventReportsAccessByRole
     --                WHERE isnull(ViewReport, 0) = 0
     --                      AND isnull(EditReport, 0) = 0
     --                      AND isnull(DeleteReport, 0) = 0
     --            )) AS EL
			  --LEFT JOIN InitiatedBy  AS IB ON EL.FromCode = IB.Id
			  --LEFT JOIN NatureCodes  AS NC ON EL.NatureCode = NC.Id
			  --;
             END;
             COMMIT TRANSACTION;
         END TRY
         BEGIN CATCH
             IF @@TRANCOUNT > 0
                 SELECT ERROR_MESSAGE();
             ROLLBACK TRANSACTION;
             EXECUTE [uspLogError];
         END CATCH;
     END;
GO
/****** Object:  StoredProcedure [dbo].[EventData_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  procedure [dbo].[EventData_LoadById]  -- 1  
@EventID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from EventLog  where EventID=@EventID
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EventEmployeeLink_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[EventEmployeeLink_Load] 1,41,56,19
CREATE PROCEDURE [dbo].[EventEmployeeLink_Load](@UserID           INT,
                                               @EmployeeID        INT,
                                               @IncidentID       INT,
                                               @ReportAccessRole INT)
AS
     BEGIN
         BEGIN TRY
             BEGIN TRANSACTION;
             BEGIN
                 DECLARE @userName VARCHAR(200)= '';
                 SELECT @userName = UserName
                 FROM Users
                 WHERE ID = @UserID;

			  SELECT EL.*,IB.Initiated,NC.Code AS NatureOfCode FROM
                 (SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			  LEFT JOIN EventEmployeeIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.EmployeeID= @EmployeeID
                 WHERE UserID = @userName
                       OR EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE ReportAccessBy = @UserID
                           AND ViewReport = '1'
                 )
                       OR EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE ReportAccessRole = @ReportAccessRole
                           AND ViewReport = '1'
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventEmployeeIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.EmployeeID= @EmployeeID
                 WHERE EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventEmployeeIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.EmployeeID= @EmployeeID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                 )
                       AND EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventEmployeeIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.EmployeeID= @EmployeeID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventEmployeeIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.EmployeeID= @EmployeeID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )) AS EL
			  LEFT JOIN InitiatedBy  AS IB ON EL.FromCode = IB.Id
			  LEFT JOIN NatureCodes  AS NC ON EL.NatureCode = NC.Id
			  ORDER BY EL.ESIID DESC 
			  ;
             END;
             COMMIT TRANSACTION;
         END TRY
         BEGIN CATCH
             IF @@TRANCOUNT > 0
                 SELECT ERROR_MESSAGE();
             ROLLBACK TRANSACTION;
             EXECUTE [uspLogError];
         END CATCH;
     END;

GO
/****** Object:  StoredProcedure [dbo].[EventEmployeeReportLink_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventEmployeeReportLink_Delete]     
@EventID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			DELETE FROM EventEmployeeIncidents WHERE EventID = @EventID;    
			SELECT @@ROWCOUNT;
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EventEmployeeReportLink_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventEmployeeReportLink_IU]     
@EventID int =0,  
@EmployeeID int=0,
@IncidentID int=0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			Insert into EventEmployeeIncidents(EventID,IncidentID,EmployeeID) 
			values (@EventID,@IncidentID,@EmployeeID)          
			select @@IDENTITY
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EventFilter_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EventFilter_print]  --'EventDate',8,'EventDate'
(  
@datacolumn nvarchar(Max),
@EventID int , 
@sortValue varchar(max)

)  
AS  
Begin  
Declare @SQL nvarchar(max)
  Begin Try                        
   Begin Transaction   
 
 Begin  
 Set @SQL= 'select '+@datacolumn+' from EventLog where EventID='+Convert(nvarchar(50),@EventID)+' Order By '+ @sortValue +''
 
   print(@SQL)
  execute(@SQL)
 End  
   
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  
GO
/****** Object:  StoredProcedure [dbo].[EventGeneralReportLink_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventGeneralReportLink_Delete]     
@EventID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			DELETE FROM EventGeneralReports WHERE EventID = @EventID;    
			SELECT @@ROWCOUNT;
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EventGeneralReportLink_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventGeneralReportLink_IU]     
@EventID int =0,  
@ReportID int=0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			Insert into EventGeneralReports(EventID,ReportID) 
			values (@EventID,@ReportID)          
			select @@IDENTITY
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EventGeneralReportsLink_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EventGeneralReportsLink_Load](@UserID           INT,
                                               @ReportID       INT,
                                               @ReportAccessRole INT)
AS
     BEGIN
         BEGIN TRY
             BEGIN TRANSACTION;
             BEGIN
                 DECLARE @userName VARCHAR(200)= '';
                 SELECT @userName = UserName
                 FROM Users
                 WHERE ID = @UserID;

                 SELECT EL.*,IB.Initiated,NC.Code AS NatureOfCode FROM
                 (SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			  LEFT JOIN EventGeneralReports AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.ReportID = @ReportID 
                 WHERE UserID = @userName
                       OR EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE ReportAccessBy = @UserID
                           AND ViewReport = '1'
                 )
                       OR EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE ReportAccessRole = @ReportAccessRole
                           AND ViewReport = '1'
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventGeneralReports AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.ReportID = @ReportID
                 WHERE EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			    LEFT JOIN EventGeneralReports AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.ReportID = @ReportID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                 )
                       AND EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			    LEFT JOIN EventGeneralReports AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.ReportID = @ReportID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			    LEFT JOIN EventGeneralReports AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.ReportID = @ReportID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )) AS EL
			  LEFT JOIN InitiatedBy  AS IB ON EL.FromCode = IB.Id
			  LEFT JOIN NatureCodes  AS NC ON EL.NatureCode = NC.Id
			  ORDER BY EL.ESIID DESC 
			  ;
             END;
             COMMIT TRANSACTION;
         END TRY
         BEGIN CATCH
             IF @@TRANCOUNT > 0
                 SELECT ERROR_MESSAGE();
             ROLLBACK TRANSACTION;
             EXECUTE [uspLogError];
         END CATCH;
     END;

GO
/****** Object:  StoredProcedure [dbo].[EventMedia_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EventMedia_IU]  --0,1,-1,'sgsgs','sdfsd,dfgdfg,dgdfg'
(  
@EventMediaID int,  
@EventID int,   
@MediaID int,
@Details nvarchar(Max),
@BanTypeTable dbo.EventMediaType READONLY

)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
 if(@EventMediaID>0)  
 Begin  
  Update EventMedia set 
  EventID=@EventID, 
  MediaID=@MediaID, 
 
  Details=@Details 
  where EventMediaID=@EventMediaID  
    
  select @@RowCount   
 End  
 else  
 Begin  
 Insert into EventMedia
	SELECT  @MediaID,Description ,@Details,@EventID 
	FROM @BanTypeTable
  --INSERT INTO EventMedia (EventID, MediaID, Description, Details) Values(@EventID,@MediaID,@Description,@Details)
    select @@IDENTITY    
 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  
GO
/****** Object:  StoredProcedure [dbo].[EventNumber_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EventNumber_LoadAll]  -- 1  

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT EventNumber  FROM EventLog
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EventPermission_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventPermission_LoadById]     
@EventID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select EventLog.EventID, Users.UserName as EventCreatorUser,Users.FirstName as EventCreatorFirstName,
		  Users.LastName as EventCreatorLastName,CreatedBy,createddate
		from EventLog 
		 inner join Users on Users.ID=EventLog.CreatedBy
		where EventID = @EventID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EventPermissionCheck_User]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [dbo].[GenReportPermissionCheck_User]  3,8,17
CREATE procedure [dbo].[EventPermissionCheck_User] 
(
    @EventAccessBy int,
    @EventID int,
    @EventAccessRole int 
)
as
begin
DECLARE @viewpermission BIT= 0;
DECLARE @editpermission BIT= 0;
DECLARE @deletepermission BIT= 0;  

IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @EventAccessBy
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
                 SET @editpermission = 1;
			  SET @deletepermission = 1;
             END; 

WITH 
cteviewPermission
                      AS(SELECT ISNULL(RP.EventID, UP.EventID) AS EventID
                         FROM
                         (
                             SELECT EventID,
                                    ViewEvent,
                                    1 AS ByRole
                             FROM EventsAccessByRole
                             WHERE EventAccessRole = @EventAccessRole
                                   AND EventID = @EventID
                                   AND ViewEvent = '1'
                                   AND EventID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT EventID,
                                    ViewEvent,
                                    2 ByUser
                             FROM EventsAccessUsers
                             WHERE EventAccessBy = @EventAccessBy
                                   AND EventID = @EventID
                                   AND EventID <> 0
                                   AND (ViewEvent = '1' OR ViewEvent IS NULL OR ViewEvent = 0)
                         ) AS UP ON RP.EventID = UP.EventID
                         WHERE(RP.ViewEvent = 1
                               AND UP.ViewEvent = 1)
						  OR (RP.ViewEvent = 1
                                  AND UP.EventID IS NULL)
                              OR (UP.ViewEvent = 1
                                  AND RP.EventID IS NULL))
,cteeditPermission
                      AS(SELECT ISNULL(RP.EventID, UP.EventID) AS EventID
                         FROM
                         (
                             SELECT EventID,
                                    EditEvent,
                                    1 AS ByRole
                             FROM EventsAccessByRole
                             WHERE EventAccessRole = @EventAccessRole
                                   AND EventID = @EventID
                                   AND EditEvent = '1'
                                   AND EventID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT EventID,
                                    EditEvent,
                                    2 ByUser
                             FROM EventsAccessUsers
                             WHERE EventAccessBy = @EventAccessBy
                                   AND EventID = @EventID
                                   AND EventID <> 0
                                   AND (EditEvent = '1' OR EditEvent IS NULL OR EditEvent = 0)
                         ) AS UP ON RP.EventID = UP.EventID
                         WHERE(RP.EditEvent = 1
                               AND UP.EditEvent = 1)
						  OR (RP.EditEvent = 1
                                  AND UP.EventID IS NULL)
                              OR (UP.EditEvent = 1
                                  AND RP.EventID IS NULL))
,ctedeletePermission
                      AS(SELECT ISNULL(RP.EventID, UP.EventID) AS EventID
                         FROM
                         (
                             SELECT EventID,
                                    DeleteEvent,
                                    1 AS ByRole
                             FROM EventsAccessByRole
                             WHERE EventAccessRole = @EventAccessRole
                                   AND EventID = @EventID
                                   AND DeleteEvent = '1'
                                   AND EventID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT EventID,
                                    DeleteEvent,
                                    2 ByUser
                             FROM EventsAccessUsers
                             WHERE EventAccessBy = @EventAccessBy
                                   AND EventID = @EventID
                                   AND EventID <> 0
							AND (DeleteEvent = '1' OR DeleteEvent IS NULL OR DeleteEvent = 0)
                         ) AS UP ON RP.EventID = UP.EventID
                         WHERE(RP.DeleteEvent = 1
                               AND UP.DeleteEvent = 1)
						 OR (RP.DeleteEvent = 1
                                  AND UP.EventID IS NULL)
                              OR (UP.DeleteEvent = 1
                                  AND RP.EventID IS NULL))

						    Select 
 (CASE
    WHEN @viewpermission = 1
    THEN @viewpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteviewPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS EventView, 
 (CASE
    WHEN @editpermission = 1
    THEN @editpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteeditPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS EventEdit,
(CASE
    WHEN @deletepermission = 1
    THEN @deletepermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM ctedeletePermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS EventDelete

	--SELECT * FROM GenReportsAccessPermission 
	--WHERE EventAccessBy = @EventAccessBy AND EventID=@EventID
end


GO
/****** Object:  StoredProcedure [dbo].[EventPicture_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EventPicture_DeleteById]
(
@EventMediaID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from EventMedia where EventMediaID=@EventMediaID
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End

GO
/****** Object:  StoredProcedure [dbo].[EventPicture_LoadByEventID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EventPicture_LoadByEventID]  --1
@EventID int=0  
As  
BEGIN  
 SELECT EventMediaID, MediaID, Description, Details  FROM EventMedia WHERE EventID = @EventID ORDER BY EventMediaID
 
END
GO
/****** Object:  StoredProcedure [dbo].[EventReportAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportAccessPermission]
(
@ID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EventReportsAccessUsers set ViewReport=@Permission where ID=@ID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EventReportsAccessUsers set EditReport=@Permission where ID=@ID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EventReportsAccessUsers set DeleteReport=@Permission where ID=@ID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[EventReportAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportAccessPermissionByRole]
(
@ID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EventReportsAccessByRole set ViewReport=@Permission where ID=@ID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EventReportsAccessByRole set EditReport=@Permission where ID=@ID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EventReportsAccessByRole set DeleteReport=@Permission where ID=@ID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EventReportPermissionCheck_User]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportPermissionCheck_User] 
(
@ReportAccessBy int,
@EventID int,
@ReportAccessRole int
)
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
    declare @set1 int
	declare @set2 Bit 
	 Begin 		  
	  set @set1=(select COUNT(*) from EventReportsAccessUsers where ReportAccessBy=@ReportAccessBy and EventID=@EventID)
	  if(@set1>0)  
	   begin  
	    set @set2=(select ViewReport from EventReportsAccessUsers where ReportAccessBy=@ReportAccessBy and EventID=@EventID)
		if(@set2='1')
		 Begin
	      select * from EventReportsAccessUsers where ReportAccessBy=@ReportAccessBy  and EventID=@EventID
		 End
		Else
		 Begin           
		  select * from EventReportsAccessByRole where ReportAccessRole=@ReportAccessRole and EventID=@EventID
		 End
	   END 
	  ELSE
	   Begin           
	    select * from EventReportsAccessByRole where ReportAccessRole=@ReportAccessRole and EventID=@EventID
	   End
	  End           
    COMMIT TRANSACTION           
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[EventReportsAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportsAccessPermission_ByRole]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EventReportsAccessByRole where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EventReportsAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportsAccessPermission_ByUser]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EventReportsAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EventReportsAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportsAccessRoles_Bind]
(
@UserID int,
@EventID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select ManageRoles.RoleName,
		EventReportsAccessByRole.* from EventReportsAccessByRole
		left join ManageRoles on ManageRoles.RoleId=EventReportsAccessByRole.ReportAccessRole
		where EventID=@EventID and CreatedBy=@UserID;
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EventReportsAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventReportsAccessUsers_Bind]
(
@UserID int,
@EventID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		EventReportsAccessUsers.* from EventReportsAccessUsers
		left join Users on Users.ID=EventReportsAccessUsers.ReportAccessBy
		where EventID=@EventID and CreatedBy=@UserID;
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[EventReview_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EventReview_DeleteById]
(
@EventReviewID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from Review where ReviewID=@EventReviewID
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End

GO
/****** Object:  StoredProcedure [dbo].[EventReview_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EventReview_I]  --0,1,-1,'sgsgs','sdfsd,dfgdfg,dgdfg'
(  
@ReviewID int=0,
 @ItemNumber varchar(50)=null,
 @ReplacedBy varchar(50)=null,
 @FromHoursMinutes varchar(10)=null,
 @ToHoursMinutes varchar(10)=null,
 @Reason varchar(50)=null,
@EventID int=0,   
@Description ntext,
@ReviewTable dbo.ReviewTableType READONLY

)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
 if(@ReviewID>0)  
		 Begin  
		  Update Review set 
		  ItemNumber=@ItemNumber,
		  ReplacedBy=@ReplacedBy,
		  FromHoursMinutes=@FromHoursMinutes,
		  ToHoursMinutes=@ToHoursMinutes,
		  Reason=@Reason,
		  EventID=@EventID, 

		  Description=@Description 
		  where ReviewID=@ReviewID  
		    
		  select @@RowCount   
		 End  
 else  
		 Begin  
		 DELETE FROM Review WHERE EventID=@EventID
		 Insert into Review
			SELECT ItemNumber,ReplacedBy,@Description,FromHoursMinutes,ToHoursMinutes,Reason,@EventID  
			FROM @ReviewTable
		  
			select @@IDENTITY    
		 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  
GO
/****** Object:  StoredProcedure [dbo].[Events_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Events_IU]-- 0,'08/04/2016',1,0,'','','','','','','',true,'','','','','','','','','','','',''
(
@EventID int=0,
@EventDate  datetime, 
@EventTime nvarchar(15),
@FromCode nvarchar(50), 
@NatureCode nvarchar(50), 
@NatureDesc nvarchar(1000), 
@DutyDesc nvarchar(1000),
@Camera nvarchar(255), 
@UserID nvarchar(25),
@KeyEvent bit,
@FromForm  nvarchar(25),
@FromNumber nvarchar(25),
@RoleName nvarchar(50), 
@UD20 nvarchar(50), 
@UD21 nvarchar(50), 
@UD22 nvarchar(50),  
@UD23 nvarchar(50), 
@UD24 nvarchar(50),  
@UD25 nvarchar(50), 
@Location nvarchar(50), 
@EndTime nvarchar(15), 
@Site nvarchar(50),
@Comments nvarchar(4000),
@CreatedBy int
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
      declare @EventNumber int=0, @AttachedEvent int=0
 Begin  
 if(@EventID >0)
   begin
   update EventLog set EventDate=@EventDate, EventTime=@EventTime, FromCode=@FromCode, NatureCode=@NatureCode
   ,NatureDesc=@NatureDesc,Comments=@Comments,DutyDesc=@DutyDesc,Camera=@Camera, UserID=@UserID, KeyEvent=@KeyEvent, FromForm=@FromForm
   , FromNumber=@FromNumber, RoleName=@RoleName, UD20=@UD20, UD21=@UD21, UD22=@UD22, UD23=@UD23, UD24=@UD24, UD25=@UD25, Location=@Location, EndTime=@EndTime, Site=@Site where EventID=@EventID
    --select @@RowCount 
    SELECT @EventID;
   end
 else
     begin
     Select @EventNumber=count(*)+ 1 from EventLog
    
       INSERT INTO EventLog(EventDate, EventNumber, AttachedEvent, EventTime, FromCode, NatureCode,NatureDesc,Comments, DutyDesc, Camera, UserID, KeyEvent, FromForm, FromNumber, RoleName, UD20, UD21, UD22, UD23, UD24, UD25, Location, EndTime, Site,CreatedBy) 
                VALUES (@EventDate, @EventNumber, null, @EventTime, @FromCode, @NatureCode,@NatureDesc,@Comments, @DutyDesc, @Camera, @UserID, @KeyEvent, @FromForm, @FromNumber, @RoleName, @UD20, @UD21, @UD22, @UD23, @UD24, @UD25, @Location, @EndTime, @Site,@CreatedBy) 
		    select @@IDENTITY    
     end
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    --EXECUTE [uspLogError]  
    select 1                 
 End Catch                    
END
GO
/****** Object:  StoredProcedure [dbo].[Events_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Events_print] --'EventDate','EventDate'
(  
@datacolumn nvarchar(Max),
@sortValue varchar(max)
)  
AS  
Begin  
Declare @SQL nvarchar(max)
  Begin Try                        
   Begin Transaction   
 
 Begin  
 Set @SQL= 'select '+@datacolumn+' from EventLog Order By '+ @sortValue +''
 
   print(@SQL)
  execute(@SQL)
 End  
   
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 
GO
/****** Object:  StoredProcedure [dbo].[EventsAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[EventsAccessPermission]
(
@ID int,
@EventID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EventsAccessUsers set ViewEvent=@Permission where ID=@ID and EventID=@EventID
	 End
	 if(@Type='Edit')
	 Begin
	  Update EventsAccessUsers set EditEvent=@Permission where ID=@ID and EventID=@EventID
	 End
	 if(@Type='Delete')
	 Begin
	  Update EventsAccessUsers set DeleteEvent=@Permission where ID=@ID and EventID=@EventID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END




GO
/****** Object:  StoredProcedure [dbo].[EventsAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EventsAccessPermission_ByRole]
(
@ID int,
@EventID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		SELECT * FROM EventsAccessByRole where ID=@ID and EventID=@EventID
		SELECT @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT > 0         
    SELECT ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EventsAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[EventsAccessPermission_ByUser]
(
@ID int,
@EventID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EventsAccessUsers where ID=@ID and EventID=@EventID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[EventsAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventsAccessPermissionByRole]
(
    @ID int,
    @EventID int,
    @Type nvarchar(10),
    @Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update EventsAccessByRole set ViewEvent = @Permission where ID = @ID and EventID  = @EventID 
	 End
	 if(@Type='Edit')
	 Begin
	  Update EventsAccessByRole set EditEvent = @Permission where ID = @ID and EventID  = @EventID 
	 End
	 if(@Type='Delete')
	 Begin
	  Update EventsAccessByRole set DeleteEvent = @Permission where ID = @ID and EventID  = @EventID 
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[EventsAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[EventsAccessRoles_Bind]
(
@UserID int,
@EventID int
)
AS             
BEGIN   
  Begin Try           
    Begin 

	   SELECT ManageRoles.RoleName,
	   EventsAccessByRole.* 
	   FROM EventsAccessByRole
	   left join ManageRoles on ManageRoles.RoleId=EventsAccessByRole.EventAccessRole
	   where EventID=@EventID and CreatedBy=@UserID AND RoleName <> 'Administrator';

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[EventsAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventsAccessUsers_Bind]
(
    @UserID int,
    @EventID int
)
AS             
BEGIN   
  Begin Try           
    Begin 

	   SELECT Users.UserName,Users.FirstName + ' ' + Users.LastName as FullName,
	   EventsAccessUsers.* 
	   FROM EventsAccessUsers
	   LEFT JOIN Users on Users.ID =  EventsAccessUsers.EventAccessBy
	   WHERE EventID = @EventID and CreatedBy = @UserID
	   AND Users.ID NOT IN (SELECT UR.UserId 
	   FROM UserInRole AS UR
	   INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
	   WHERE MR.RoleName = 'Administrator');

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[EventSubjectLink_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EventSubjectLink_Load](@UserID           INT,
                                               @SubjectID        INT,
                                               @IncidentID       INT,
                                               @ReportAccessRole INT)
AS
     BEGIN
         BEGIN TRY
             BEGIN TRANSACTION;
             BEGIN
                 DECLARE @userName VARCHAR(200)= '';
                 SELECT @userName = UserName
                 FROM Users
                 WHERE ID = @UserID;

                  SELECT EL.*,IB.Initiated,NC.Code AS NatureOfCode FROM
                 (SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			  LEFT JOIN EventSubjectIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.SubjectID= @SubjectID
                 WHERE UserID = @userName
                       OR EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE ReportAccessBy = @UserID
                           AND ViewReport = '1'
                 )
                       OR EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE ReportAccessRole = @ReportAccessRole
                           AND ViewReport = '1'
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventSubjectIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.SubjectID= @SubjectID
                 WHERE EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventSubjectIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.SubjectID= @SubjectID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                 )
                       AND EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventSubjectIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.SubjectID= @SubjectID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
                 UNION
                 SELECT EventLog.*,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM EventPicturesVideos EPV
                          LEFT JOIN PicturesVideos PV ON EPV.MediaID = PV.MediaID
                     WHERE EventID = EventLog.EventID
                 ) AS FilePath
			  ,CASE WHEN ESI.ID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
			  ,ESI.ID AS ESIID
                 FROM EventLog
			   LEFT JOIN EventSubjectIncidents AS ESI ON EventLog.EventID = ESI.EventID
			  AND ESI.IncidentID = @IncidentID AND ESI.SubjectID= @SubjectID
                 WHERE EventLog.EventID NOT IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessUsers
                 )
                       AND EventLog.EventID IN
                 (
                     SELECT EventID
                     FROM EventReportsAccessByRole
                     WHERE isnull(ViewReport, 0) = 0
                           AND isnull(EditReport, 0) = 0
                           AND isnull(DeleteReport, 0) = 0
                 )
			  ) AS EL
			  LEFT JOIN InitiatedBy  AS IB ON EL.FromCode = IB.Id
			  LEFT JOIN NatureCodes  AS NC ON EL.NatureCode = NC.Id
			  ORDER BY EL.ESIID DESC 
			  ;
             END;
             COMMIT TRANSACTION;
         END TRY
         BEGIN CATCH
             IF @@TRANCOUNT > 0
                 SELECT ERROR_MESSAGE();
             ROLLBACK TRANSACTION;
             EXECUTE [uspLogError];
         END CATCH;
     END;

GO
/****** Object:  StoredProcedure [dbo].[EventSubjectReportLink_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventSubjectReportLink_Delete]     
@EventID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			DELETE FROM EventSubjectIncidents WHERE EventID = @EventID;
			SELECT @@ROWCOUNT;    
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[EventSubjectReportLink_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EventSubjectReportLink_IU]     
@EventID int =0,  
@SubjectID int=0,
@IncidentID int=0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			Insert into EventSubjectIncidents(EventID,IncidentID,SubjectID) 
			values (@EventID,@IncidentID,@SubjectID)          
			select @@IDENTITY
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[ExecuteReport_Sql]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ExecuteReport_Sql]-- 'Select Setting ,Description ,DataType From ApplicationSettings'
(  
@datacolumn nvarchar(Max)

)  
AS  
Begin  
Declare @SQL nvarchar(max),@HTML NVARCHAR(MAX)
  

 Set @SQL= Replace(@datacolumn,'From','into NewTable From')
 print @SQL
 execute(@SQL)
 --Select * from NewTable
 --drop table new_table
 --Select * into new_table  from  NewTable
 --select * from new_table
  EXEC SpCustomTable2HTML 'NewTable', @HTML OUTPUT,
   'style="font:8pt" class="AltListBorder" id="AltListBorder" cellpadding="2" cellspacing="1"',
        'class="RowHeader" id="1"'
  select @HTML
 drop table NewTable
End 

GO
/****** Object:  StoredProcedure [dbo].[FacialHair_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[FacialHair_Delete](    
@Id int    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Delete from FacialHair where Id=@Id     
   Select @@RowCount as RESULT     
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  
GO
/****** Object:  StoredProcedure [dbo].[FacialHair_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[FacialHair_IU](    
@Id int,    
@FacialHair nvarchar(200)    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
  if exists(SELECT *  FROM FacialHair  where Id=@Id)      
   begin      
   update FacialHair set FacialHair=@FacialHair where Id=@Id      
   select @@RowCount as RESULT  
   end      
  ELSE      
  begin      
   insert into FacialHair(FacialHair) values(@FacialHair)      
   select @@Identity as RESULT    
  end      
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   


GO
/****** Object:  StoredProcedure [dbo].[FacialHair_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[FacialHair_Load]    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Select * from FacialHair    
   Select @@RowCount as RESULT    
  End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  

GO
/****** Object:  StoredProcedure [dbo].[FeatureLocation_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[FeatureLocation_Delete](  
@Id int  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Delete from FeatureLocation where Id=@Id   
	  Select @@RowCount as RESULT   
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[FeatureLocation_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[FeatureLocation_IU](  
@Id int,  
@FLocation nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM FeatureLocation  where Id=@Id)    
   begin    
   update FeatureLocation set FLocation=@FLocation where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into FeatureLocation(FLocation) values(@FLocation)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[FeatureLocation_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[FeatureLocation_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from FeatureLocation  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 
GO
/****** Object:  StoredProcedure [dbo].[FeatureType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FeatureType_Delete](
@Id int
)
as               
BEGIN       
  Begin Try                
   Begin Transaction     
    Begin     
		Delete from FeatureType where Id=@Id 
		Select @@RowCount as RESULT 
	End     
   COMMIT TRANSACTION     
  End try        
 Begin Catch             
  IF @@TRANCOUNT >0             
          Select ERROR_MESSAGE()    
    Rollback Transaction      
    EXECUTE [uspLogError]               
 End Catch                
END 
GO
/****** Object:  StoredProcedure [dbo].[FeatureType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[FeatureType_IU](
@Id int,
@FeatureType  nvarchar(200)
)
as               
BEGIN       
  Begin Try                
   Begin Transaction     
    Begin     
  if exists(SELECT *  FROM FeatureType  where Id=@Id)  
   begin  
   update FeatureType set FeatureType=@FeatureType where Id=@Id  
   select @@RowCount as RESULT  
   end  
  ELSE  
  begin  
   insert into FeatureType(FeatureType) values(@FeatureType)  
   select @@Identity as RESULT
  end  
 End     
   COMMIT TRANSACTION     
  End try        
 Begin Catch             
  IF @@TRANCOUNT >0             
          Select ERROR_MESSAGE()    
    Rollback Transaction      
    EXECUTE [uspLogError]               
 End Catch                
END  
GO
/****** Object:  StoredProcedure [dbo].[FeatureType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[FeatureType_Load]
as               
BEGIN       
  Begin Try                
   Begin Transaction     
    Begin     
		Select * from FeatureType
		Select @@RowCount as RESULT
	End     
   COMMIT TRANSACTION     
  End try        
 Begin Catch             
  IF @@TRANCOUNT >0             
          Select ERROR_MESSAGE()    
    Rollback Transaction      
    EXECUTE [uspLogError]               
 End Catch                
END 
GO
/****** Object:  StoredProcedure [dbo].[ForeignExchangeRates_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[ForeignExchangeRates_Delete](            
@Id int            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Delete from ForeignExchangeRates where Id=@Id             
   Select @@RowCount as RESULT             
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   
GO
/****** Object:  StoredProcedure [dbo].[ForeignExchangeRates_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE Procedure [dbo].[ForeignExchangeRates_IU](  
@Id int,            
@Country nvarchar(200),
@Rate nvarchar(10)           
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
  if exists(SELECT *  FROM ForeignExchangeRates  where Id=@Id)              
   begin              
   update ForeignExchangeRates set Country=@Country, Rate=@Rate where Id=@Id              
   select @@RowCount as RESULT          
   end              
  ELSE              
  begin              
   insert into ForeignExchangeRates(Country,Rate) values(@Country,@Rate)              
   select @@Identity as RESULT            
  end              
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[ForeignExchangeRates_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[ForeignExchangeRates_Load]            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Select * from ForeignExchangeRates            
   Select @@RowCount as RESULT            
  End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END

GO
/****** Object:  StoredProcedure [dbo].[ForeignExchangeRates_LoadByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ForeignExchangeRates_LoadByID]
@id int =0
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Select * from ForeignExchangeRates where Id=@Id   
   Select @@RowCount as RESULT            
  End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END
GO
/****** Object:  StoredProcedure [dbo].[ForeignRates_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[ForeignRates_LoadAll]

as
begin
SELECT ForeignCountry, Rate FROM ForeignRates ORDER BY ForeignCountry
End

GO
/****** Object:  StoredProcedure [dbo].[GeneralReport_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneralReport_AddEdit] --5,'00002','General','Select',true,'Wanted By Police','2016-10-27 00:00:00.000','','sdfsdf','Associate','','1 : 4','','','','',0,1
( 
@Id int=0,  
@ReportNumber nvarchar(20),   
@NatureOfEvent nvarchar(50),   
@ShortDescriptor nvarchar(25),   
@ActiveStatus bit,   
@Status nvarchar(25),   
@IncidentDate datetime,  
@Description ntext,   
@Location nvarchar(50),   
@IncidentRole nvarchar(50),   
@OccurrenceNumber nvarchar(50),   
@IncidentTime nvarchar(10),   
@RoleName nvarchar(50),   
@UD51 nvarchar(50),   
@UD52 nvarchar(50),   
@UD53 nvarchar(50),   
@EventID int=0,
@CreatedBy int
)
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
         
 Begin      
  if(@Id>0)        
  begin        
  update GeneralReport set      
    ReportNumber=@ReportNumber,   
    NatureOfEvent=@NatureOfEvent,   
    ShortDescriptor=@ShortDescriptor,   
    ActiveStatus=@ActiveStatus,   
    Status=@Status,   
    IncidentDate=@IncidentDate,   
    Description=@Description,   
    Location=@Location,   
    IncidentRole=@IncidentRole,   
    OccurrenceNumber=@OccurrenceNumber,   
    IncidentTime=@IncidentTime,   
    RoleName=@RoleName,   
    UD51=@UD51,   
    UD52=@UD52,   
    UD53=@UD53,   
    EventID=@EventID       
  where ReportID=@Id        
         
  SELECT @@ROWCOUNT AS Result      
  end        
  else        
  begin     
          
    Insert into GeneralReport(ReportNumber,NatureOfEvent,ShortDescriptor,ActiveStatus,Status,IncidentDate,   
		Description,Location,IncidentRole,OccurrenceNumber,IncidentTime,RoleName,UD51,UD52,UD53,EventID,
		CreatedBy) values ( @ReportNumber,@NatureOfEvent,@ShortDescriptor,@ActiveStatus,@Status,@IncidentDate,   
		@Description,@Location,   
    @IncidentRole,   
    @OccurrenceNumber,   
    @IncidentTime,   
    @RoleName,   
    @UD51,   
    @UD52,   
    @UD53,   
    @EventID,
	@CreatedBy    
    )            
    SELECT @@Identity AS Result

   end        
 End           
  COMMIT TRANSACTION           
 End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[GeneralReport_LoadALL]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneralReport_LoadALL](@UserID INT,@EventId INT = 0,@ReportAccessRole INT)
AS
     BEGIN
	DECLARE @viewpermission BIT= 0;

	IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
             END; 

                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM GenSubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM GenSubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
							AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                                   AND ReportID <> 0
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))

         SELECT Users.UserName,
                MSD.Descriptor AS ShortDescriptorName,
                MS.Status AS StatusName,
                MN.NatureImage,
			 MN.nature AS NatureOfEvent,
                CASE
                    WHEN isnull(MN.NatureImage, '') <> ''
                    THEN MN.NatureImage
                    ELSE
         (
             SELECT ImagePath
             FROM ReportLogoImage
             WHERE SetImage = 1
         )
                END AS DefaultImage,
                GeneralReport.*
			 ,EGR.ID AS EventReportID
			 ,CASE WHEN EGR.ReportID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
         FROM GeneralReport
              INNER JOIN Users ON Users.ID = GeneralReport.CreatedBy
              LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = GeneralReport.ShortDescriptor
              LEFT JOIN MasterStatus MS ON MS.ID = GeneralReport.Status
              LEFT OUTER JOIN MasterNatureofIncident MN ON MN.Id = GeneralReport.NatureOfEvent
                                                           AND NatureType = 3
			LEFT JOIN EventGeneralReports AS EGR ON GeneralReport.ReportID = EGR.ReportID AND EGR.EventID = @EventId											  
         WHERE CreatedBy = @UserID
               OR GeneralReport.ReportID IN
                              (
                                  SELECT ReportID
                                  FROM cteReportPermission
                              )
	   ORDER BY EGR.ReportID DESC;
         SELECT @@RowCount;
     END;
GO
/****** Object:  StoredProcedure [dbo].[GeneralReport_LoadByReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneralReport_LoadByReportID]
@ReportID int=0    
As    
BEGIN    
 Select Users.UserName,Users.FirstName as ReportCreatorFirstName,
  Users.LastName as ReportCreatorLastName,GeneralReport.* from GeneralReport    
 inner join Users on Users.ID=GeneralReport.CreatedBy
 where ReportID=@ReportID 
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReport_LoadByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneralReport_LoadByUser](@UserID INT,@ReportAccessRole INT)
AS
     BEGIN
	DECLARE @viewpermission BIT= 0;

	IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
             END; 

                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM GenSubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM GenSubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
							AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                                   AND ReportID <> 0
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))

         SELECT Users.UserName,
                MSD.Descriptor AS ShortDescriptorName,
                MS.Status AS StatusName,
                MN.NatureImage,
                CASE
                    WHEN isnull(MN.NatureImage, '') <> ''
                    THEN MN.NatureImage
                    ELSE
         (
             SELECT ImagePath
             FROM ReportLogoImage
             WHERE SetImage = 1
         )
                END AS DefaultImage,
                GeneralReport.*
         FROM GeneralReport
              INNER JOIN Users ON Users.ID = GeneralReport.CreatedBy
              LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = GeneralReport.ShortDescriptor
              LEFT JOIN MasterStatus MS ON MS.ID = GeneralReport.Status
              LEFT OUTER JOIN MasterNatureofIncident MN ON MN.Id = GeneralReport.NatureOfEvent
                                                           AND NatureType = 3
         WHERE CreatedBy = @UserID
               OR ReportID IN
                              (
                                  SELECT ReportID
                                  FROM cteReportPermission
                              );
         SELECT @@RowCount;
     END;
GO
/****** Object:  StoredProcedure [dbo].[GeneralReportBanned_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GeneralReportBanned_IU]
(
@ReportID int,
@StartDate nvarchar(50),
@EndDate nvarchar(50), 
@EntryDate nvarchar(50),
@AuthorizedBy nvarchar(50),
@Description ntext,
@BanYears int, 
@BanMonths int,
@BanDays int
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM GeneralReportBanned WHERE ReportID = @ReportID
		Insert into GeneralReportBanned(      
		ReportID, StartDate, EndDate, EntryDate, AuthorizedBy, Description, BanYears, BanMonths, BanDays)         
		values (  
		@ReportID, @StartDate, @EndDate, @EntryDate, @AuthorizedBy, @Description, @BanYears, @BanMonths, @BanDays)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReportBanned_LoadByReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GeneralReportBanned_LoadByReportID]  
@ReportID int=0    
As    
BEGIN    
SELECT StartDate, EndDate, EntryDate, AuthorizedBy, 
Description, BanYears, BanMonths, BanDays FROM GeneralReportBanned WHERE ReportID=@ReportID  
END
GO
/****** Object:  StoredProcedure [dbo].[GeneralReportEventsLink_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneralReportEventsLink_Delete]     
@ReportID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			DELETE FROM EventGeneralReports WHERE ReportID = @ReportID;  
			SELECT @@ROWCOUNT;  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReportInvolve_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GeneralReportInvolve_I]
(
@ReportID int=0,
@InvolvedID int=0,  
@MediaID int=0,
@InvolvedRole int=0,
@IsEmployee bit
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
    declare @set int
	 Begin 
	  set @set=(Select Count(*) FROM GeneralReportInvolved WHERE ReportID = @ReportID and InvolvedID=@InvolvedID and IsEmployee=@IsEmployee);
	   if(@set>0)
		begin
		 DELETE FROM GeneralReportInvolved WHERE ReportID = @ReportID and InvolvedID=@InvolvedID and IsEmployee=@IsEmployee
		END
         Insert into GeneralReportInvolved (ReportID,InvolvedID,MediaID,InvolvedRole,IsEmployee)
	      values(@ReportID,@InvolvedID,@MediaID,@InvolvedRole,@IsEmployee)
	   select @@IDENTITY  
      End         
    COMMIT TRANSACTION         
   End try            
  Begin Catch                 
  IF @@TRANCOUNT >0                 
   Select ERROR_MESSAGE()        
   Rollback Transaction          
   EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReportLinked_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneralReportLinked_DeleteById]     
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from GeneralReportLinked where ID = @ID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[GeneralReportLinked_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneralReportLinked_IU]
@ID int =0,
@ReportID int =0,  
@Description nvarchar(max) = null,
@FilePath nvarchar(max) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@ID > 0)
    Begin 
			update GeneralReportLinked set
			ReportID = @ReportID,
			Description = @Description,
			FilePath = @FilePath  where ID = @ID 
			select @ID AS Result          
	End 
    Else
	Begin

			Insert into GeneralReportLinked(ReportID ,Description ,FilePath) 
			values (@ReportID ,@Description ,@FilePath)          
			select @@IDENTITY AS Result

	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[GeneralReportLinked_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GeneralReportLinked_LoadById]
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from GeneralReportLinked where ID = @ID 
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[GeneralReportsBanType_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GeneralReportsBanType_I]
(
@ReportID int=0,
@ReportsBanTypeTable dbo.BanTypeTable READONLY
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM GeneralReportsBanType WHERE ReportID = @ReportID
        Insert into GeneralReportsBanType
	SELECT @ReportID,BanName  
	FROM @ReportsBanTypeTable         
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReportsBanType_LoadByReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GeneralReportsBanType_LoadByReportID]
@ReportID int=0  
As    
BEGIN    
Select BanName From GeneralReportsBanType Where ReportID =@ReportID
END
GO
/****** Object:  StoredProcedure [dbo].[GeneralReportsDisputes_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GeneralReportsDisputes_IU]
(
@ReportID int=0,
@DisputeType nvarchar(50), 
@Resolution nvarchar(50), 
@Amount nvarchar(50),
@Description ntext,
@RecoveredMoney  bit
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM GeneralReportsDisputes WHERE ReportID = @ReportID
		Insert into GeneralReportsDisputes(      
		ReportID, 
		DisputeType, 
		Resolution, 
		Amount,
		Description,
		RecoveredMoney    
		)         
		values (  
		@ReportID,    
		@DisputeType, 
		@Resolution, 
		@Amount,
		@Description,
		@RecoveredMoney  
	   
		)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReportsMax_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[GeneralReportsMax_Load]  -- 1  

AS             
BEGIN   
declare @ReportNumber int
  Begin Try            
   Begin Transaction 
    Begin 
   
	  select @ReportNumber=Max(ReportNumber)+1 from GeneralReport
	   if(@ReportNumber is null)
	   begin
	  set @ReportNumber=1
	   end 

	  SELECT RIGHT('00000'+ CONVERT(VARCHAR(6),@ReportNumber),5)
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[GeneralReportsServices_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GeneralReportsServices_IU]
(
@ReportID int=0,
@CallTime datetime, 
@ArriveTime datetime, 
@ServiceBy varchar(50),
@ServiceFor varchar(50),
@Description ntext
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM GeneralReportsServices WHERE ReportID = @ReportID
		Insert into GeneralReportsServices(   
		ReportID,
		CallTime, 
		ArriveTime, 
		ServiceBy,  
		ServiceFor,  
		Description
		)         
		values ( 
		@ReportID,   
		@CallTime, 
		@ArriveTime, 
		@ServiceBy,
		@ServiceFor,
		@Description
	   
		)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTCashCall_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenRepLCTCashCall_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from GenReportLCTCashCall where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTCashCall_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenRepLCTCashCall_LoadById]
@ReportID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select CashierName.CashierName ,GenReportLCTCashCall.*  from GenReportLCTCashCall 
		left join CashierName on CashierName.ID=GenReportLCTCashCall.Cashier
		where ReportID = @ReportID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTCashOuts_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenRepLCTCashOuts_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from GenReportLCTCashOuts where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTCashOuts_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenRepLCTCashOuts_LoadById]  
@ReportID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *  from GenReportLCTCashOuts where ReportID = @ReportID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTForeignExchange_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenRepLCTForeignExchange_LoadById]
@ReportID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select ForeignExchangeRates.Country as ForeignCountryName,GenReportLCTForeignExchange.*  from GenReportLCTForeignExchange 
		left join ForeignExchangeRates on ForeignExchangeRates.ID=GenReportLCTForeignExchange.ForeignCountry
		where ReportID = @ReportID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTPitTransactions_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenRepLCTPitTransactions_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from GenReportLCTPitTransactions where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[GenRepLCTPitTransactions_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenRepLCTPitTransactions_LoadById]  
@ReportID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select MasterGame.Game as GameName,GenReportLCTPitTransactions.*  from GenReportLCTPitTransactions 
		left join MasterGame on MasterGame.ID=GenReportLCTPitTransactions.Game
		where ReportID = @ReportID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[GenReportLCTForeignExchange_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenReportLCTForeignExchange_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from GenReportLCTForeignExchange where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[GenReportLinked_LoadByReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenReportLinked_LoadByReportID]    
@ReportID int=0    
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
  
     select *  from GeneralReportLinked where ReportID = @ReportID
  
  select @@RowCount  
 End   
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END

GO
/****** Object:  StoredProcedure [dbo].[GenReportPermissionCheck_User]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [dbo].[GenReportPermissionCheck_User]  3,8,17
CREATE procedure [dbo].[GenReportPermissionCheck_User] 
(
    @ReportAccessBy int,
    @ReportID int,
    @ReportAccessRole int 
)
as
begin
DECLARE @viewpermission BIT= 0;
DECLARE @editpermission BIT= 0;
DECLARE @deletepermission BIT= 0;  

IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @ReportAccessBy
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
                 SET @editpermission = 1;
			  SET @deletepermission = 1;
             END; 

WITH 
cteviewPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM GenSubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @ReportID
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM GenSubReportsAccessUsers
                             WHERE ReportAccessBy = @ReportAccessBy
                                   AND ReportID = @ReportID
                                   AND ReportID <> 0
                                   AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
						  OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
,cteeditPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    EditReport,
                                    1 AS ByRole
                             FROM GenSubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @ReportID
                                   AND EditReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    EditReport,
                                    2 ByUser
                             FROM GenSubReportsAccessUsers
                             WHERE ReportAccessBy = @ReportAccessBy
                                   AND ReportID = @ReportID
                                   AND ReportID <> 0
                                   AND (EditReport = '1' OR EditReport IS NULL OR EditReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.EditReport = 1
                               AND UP.EditReport = 1)
						  OR (RP.EditReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.EditReport = 1
                                  AND RP.ReportID IS NULL))
,ctedeletePermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    DeleteReport,
                                    1 AS ByRole
                             FROM GenSubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @ReportID
                                   AND DeleteReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    DeleteReport,
                                    2 ByUser
                             FROM GenSubReportsAccessUsers
                             WHERE ReportAccessBy = @ReportAccessBy
                                   AND ReportID = @ReportID
                                   AND ReportID <> 0
							AND (DeleteReport = '1' OR DeleteReport IS NULL OR DeleteReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.DeleteReport = 1
                               AND UP.DeleteReport = 1)
						 OR (RP.DeleteReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.DeleteReport = 1
                                  AND RP.ReportID IS NULL))

						    Select 
 (CASE
    WHEN @viewpermission = 1
    THEN @viewpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteviewPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS ReportView, 
 (CASE
    WHEN @editpermission = 1
    THEN @editpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteeditPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS ReportEdit,
(CASE
    WHEN @deletepermission = 1
    THEN @deletepermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM ctedeletePermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS ReportDelete

	--SELECT * FROM GenReportsAccessPermission 
	--WHERE ReportAccessBy = @ReportAccessBy AND ReportID=@ReportID
end


GO
/****** Object:  StoredProcedure [dbo].[GenReportsAccessPermission_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenReportsAccessPermission_AddEdit]
(
@ID int=0,
@ReportID int=0,
@ReportAccessBy int=0,
@ReportView bit = 'false',
@ReportEdit bit = 'false',
@ReportDelete bit = 'false',
@CreatedBy int=0
)
as
begin
	if(Not Exists(select * from GenReportsAccessPermission where ID=@ID))
	begin
		Insert into GenReportsAccessPermission(ReportID,ReportAccessBy,ReportView,
			ReportEdit,ReportDelete,CreatedBy,ModifyDate) values(@ReportID,
			@ReportAccessBy,@ReportView,@ReportEdit,@ReportDelete,@CreatedBy,getdate())		
		SELECT @@IDENTITY AS RESULT 
	end
	else
	begin
		Update GenReportsAccessPermission
			set ReportView=@ReportView,ReportEdit=@ReportEdit,ReportDelete=@ReportDelete,
			ModifyDate=getdate() where ID=@ID
		SELECT @@ROWCOUNT AS RESULT
	end
end

GO
/****** Object:  StoredProcedure [dbo].[GenReportsDisputes_LoadByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GenReportsDisputes_LoadByID]   
@ReportID int=0    
As    
BEGIN    
 Select * from GeneralReportsDisputes    
 where ReportID=@ReportID  
END
GO
/****** Object:  StoredProcedure [dbo].[GenReportServices_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GenReportServices_IU]
(
@ReportID int=0,
@CallTime datetime, 
@ArriveTime datetime, 
@ServiceBy varchar(50),
@ServiceFor varchar(50),
@Description ntext
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM GeneralReportsServices WHERE ReportID = @ReportID
		Insert into GeneralReportsServices( 
		ReportID, 
		CallTime, 
		ArriveTime, 
		ServiceBy,  
		ServiceFor,  
		Description
		)         
		values ( 
		@ReportID,    
		@CallTime, 
		@ArriveTime, 
		@ServiceBy,
		@ServiceFor,
		@Description
	   
		)          
		  select @@IDENTITY  AS RESULT  
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GenReportServices_LoadbyReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GenReportServices_LoadbyReportID]
@ReportID int=0     
As    
BEGIN    
	SELECT CallTime, ArriveTime, ServiceBy, ServiceFor, Description FROM GeneralReportsServices  Where ReportID =@ReportID    
END
GO
/****** Object:  StoredProcedure [dbo].[GenReportServicesOffered_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenReportServicesOffered_I]
(
@ReportID int=0,
@ServiceName varchar(50),
@Offered bit,
@Declined bit
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin 
   --     if Exists(select ServiceName,ReportID from GeneralReportsServicesOffered WHERE ReportID = @ReportID and ServiceName=@ServiceName)
			--begin
			
			--update GeneralReportsServicesOffered set Offered=@Offered,Declined=@Declined WHERE ReportID = @ReportID
			-- sElect @@Rowcount
			--end
   --     else
   --       begin
			DELETE FROM GeneralReportsServicesOffered WHERE ReportID = @ReportID  and ServiceName = @ServiceName
				Insert into GeneralReportsServicesOffered(
				ReportID, 
				ServiceName, 
				Offered, 
				Declined
				)         
				values (  
				@ReportID,    
				@ServiceName,
				@Offered,
				@Declined
				)          
				  select @@IDENTITY  AS RESULT  
       --end
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[GenReportsInvolved_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenReportsInvolved_AddEdit]    
(  
@ID int=0,
@CreatedBy Int=0,
@InvolvedID int=0,    
@ReportID int=0,   
@FirstName nvarchar(25)=null,   
@LastName nvarchar(25)=Null,   
@Race nvarchar(25)=Null,   
@Sex nvarchar(10)=null,   
@RoleName nvarchar(50)=null,   
@MediaID int=0
)    
AS    
Begin    
  Begin Try                          
   Begin Transaction 
    if(@ID > 0)
     begin
	  update Subjects set FirstName=@FirstName, LastName=@LastName, Race=@Race, Sex=@Sex, Restricted=0, RoleName=@RoleName  where SubjectID=@InvolvedID 
	   Select @@Rowcount
	  update  SubjectInvolved set InvolvedRole=@RoleName where InvolvedID=@InvolvedID 
	   Select @@Rowcount
     end   
    else
     begin
	  INSERT INTO Subjects (FirstName, LastName, Race, Sex, Restricted, RoleName,CreatedBy,ModifiedDate,VIP)   
	   VALUES(@FirstName,@LastName,@Race,@Sex,0,@RoleName,@CreatedBy,getdate(),DATEDIFF(second,{d '1970-01-01'},getdate()))  	   
	   select @InvolvedID=@@IDENTITY  	
	  Insert Into GeneralReportInvolved(ReportID, InvolvedID, MediaID, InvolvedRole, IsEmployee)
	   values(@ReportID, @InvolvedID, @MediaID, @RoleName, 0)    
	  select @@IDENTITY  
     end
   Commit Transaction    
  End Try     
  Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
  End Catch     
End 


GO
/****** Object:  StoredProcedure [dbo].[GenReportsInvolved_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GenReportsInvolved_Delete]
(
@InvolvedID int=0,
@ReportID int=0
)
AS
Begin
  Begin Try                      
   Begin Transaction  

		Delete from GenReportsInvolved where InvolvedID=@InvolvedID and ReportID=@ReportID
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End

GO
/****** Object:  StoredProcedure [dbo].[GenReportsInvolved_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenReportsInvolved_LoadAll]
(
@ReportID int
)
AS
Begin 
	SELECT GeneralReportInvolved.ID,GeneralReportInvolved.InvolvedID, Subjects.FirstName, Subjects.LastName, Subjects.Sex, Subjects.Race,
	MasterRole.Id as RoleID,MasterRole.Role as RoleName, GeneralReportInvolved.IsEmployee FROM Subjects 
	INNER JOIN GeneralReportInvolved ON Subjects.SubjectID = GeneralReportInvolved.InvolvedID 
	LEFT JOIN MasterRole on MasterRole.Id=GeneralReportInvolved.InvolvedRole
	WHERE GeneralReportInvolved.ReportID = @ReportID And GeneralReportInvolved.IsEmployee = 0 
	UNION
	SELECT GeneralReportInvolved.ID,GeneralReportInvolved.InvolvedID, Employees.FirstName, Employees.LastName, Employees.Sex, Employees.Race, 
	MasterRole.Id as RoleID,MasterRole.Role as RoleName, GeneralReportInvolved.IsEmployee FROM Employees 
	INNER JOIN GeneralReportInvolved ON Employees.EmployeeID = GeneralReportInvolved.InvolvedID 
	LEFT JOIN MasterRole on MasterRole.Id=GeneralReportInvolved.InvolvedRole
	WHERE GeneralReportInvolved.ReportID = @ReportID AND GeneralReportInvolved.IsEmployee = 1
End

GO
/****** Object:  StoredProcedure [dbo].[GenReportsServicesOffered_LoadbyReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GenReportsServicesOffered_LoadbyReportID]
@ReportID int=0     
As    
BEGIN    
	SELECT ServiceName, Offered, Declined FROM GeneralReportsServicesOffered Where ReportID =@ReportID    
END
GO
/****** Object:  StoredProcedure [dbo].[GenReportsVehicles_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GenReportsVehicles_AddEdit]  
(  
@VehicleID int=0,  
@VehicleVIN nvarchar(50),   
@VehicleColor nvarchar(50),   
@VehicleYear nvarchar(50),   
@VehicleModel nvarchar(50),   
@VehicleMake nvarchar(50),   
@IssuedIn nvarchar(50),   
@LicensePlate nvarchar(50),   
@ReportID int=0  
)  
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
         
 Begin    
         
  if(@VehicleID>0)        
  begin        
  update GenReportsVehicles set        
    LicensePlate=@LicensePlate,   
    IssuedIn=@IssuedIn,   
    VehicleMake=@VehicleMake,   
    VehicleModel=@VehicleModel,   
    VehicleYear=@VehicleYear,   
    VehicleColor=@VehicleColor,   
    VehicleVIN=@VehicleVIN  
    where VehicleID=@VehicleID        
         
  select @@RowCount AS Result     
  end        
  else        
  begin     
          
    Insert into GenReportsVehicles(        
    LicensePlate,   
    IssuedIn,   
    VehicleMake,   
    VehicleModel,   
    VehicleYear,   
    VehicleColor,   
    VehicleVIN,
	ReportID
    )           
    values (        
    @LicensePlate,   
    @IssuedIn,   
    @VehicleMake,   
    @VehicleModel,   
    @VehicleYear,   
    @VehicleColor,   
    @VehicleVIN,
	@ReportID
    )            
    select @VehicleID=@@IDENTITY 
	select @VehicleID        
                  
   end        
 End           
  COMMIT TRANSACTION           
 End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 
GO
/****** Object:  StoredProcedure [dbo].[GenReportsVehicles_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenReportsVehicles_Delete]
@Id int=0  
AS  
BEGIN  
 Delete from GenReportsVehicles where VehicleID=@Id  
   
 select @@rowcount  as Result
END

GO
/****** Object:  StoredProcedure [dbo].[GenReportsVehicles_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenReportsVehicles_LoadById]    
@ReportID int =0   

AS             
BEGIN   
  Select * from GenReportsVehicles    
 where ReportID=@ReportID
		
	
END
GO
/****** Object:  StoredProcedure [dbo].[GenSubReportAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenSubReportAccessPermission]
(
@ID int,
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update GenSubReportsAccessUsers set ViewReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update GenSubReportsAccessUsers set EditReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update GenSubReportsAccessUsers set DeleteReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[GenSubReportAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenSubReportAccessPermissionByRole]
(
    @ID int,
    @ReportID int,
    @Type nvarchar(10),
    @Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update GenSubReportsAccessByRole set ViewReport = @Permission where ID = @ID and ReportID = @ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update GenSubReportsAccessByRole set EditReport = @Permission where ID = @ID and ReportID = @ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update GenSubReportsAccessByRole set DeleteReport = @Permission where ID = @ID and ReportID = @ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[GenSubReportsAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenSubReportsAccessPermission_ByRole]
(
@ID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from GenSubReportsAccessByRole where ID=@ID and ReportID=@ReportID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[GenSubReportsAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenSubReportsAccessPermission_ByUser]
(
@ID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from GenSubReportsAccessUsers where ID=@ID and ReportID=@ReportID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[GenSubReportsAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenSubReportsAccessRoles_Bind]
(
@UserID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 

	   select ManageRoles.RoleName,
	   GenSubReportsAccessByRole.* 
	   from GenSubReportsAccessByRole
	   left join ManageRoles on ManageRoles.RoleId=GenSubReportsAccessByRole.ReportAccessRole
	   where ReportID=@ReportID and CreatedBy=@UserID AND RoleName <> 'Administrator';

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[GenSubReportsAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenSubReportsAccessUsers_Bind]
(
    @UserID int,
    @ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 

	   SELECT Users.UserName,Users.FirstName + ' ' + Users.LastName as FullName,
	   GenSubReportsAccessUsers.* 
	   FROM GenSubReportsAccessUsers
	   LEFT JOIN Users on Users.ID =  GenSubReportsAccessUsers.ReportAccessBy
	   WHERE ReportID = @ReportID and CreatedBy = @UserID
	   AND Users.ID NOT IN (SELECT UR.UserId 
	   FROM UserInRole AS UR
	   INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
	   WHERE MR.RoleName = 'Administrator');

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[GenUsersSubReportsAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GenUsersSubReportsAccessRole]
(
@ReportID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	
	   Select RoleId,RoleName from ManageRoles 
	   where RoleId not in (select ReportAccessRole from GenSubReportsAccessByRole where ReportID=@ReportID and ReportID <> 0)
	   AND RoleName <> 'Administrator';
		
	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[Get_NextLCTIDSequential]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Get_NextLCTIDSequential] 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select SettingValue from ApplicationSettings where Setting = 'NextLCTIDSequential'
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuditQuestionById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAuditQuestionById] --1,5
(
    @QuestionID int =0
)
AS
BEGIN
if(@QuestionID>0)
begin
	Select aq.QuestionID,au.QuestionID AS AuditID,aq.Question,aq.QuestionType,au.AuditType AS [Audit] ,aq.ToolTip
	from AuditsQuestions aq
	INNER JOIN AuditQuestions AS au ON aq.AuditID = au.QuestionID
	where aq.QuestionID = @QuestionID
end

END
GO
/****** Object:  StoredProcedure [dbo].[GetAudits]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CReate procedure [dbo].[GetAudits]
AS
BEGIN
	SELECT  QuestionID AS AuditID, AuditType FROM AuditQuestions ORDER BY AuditType
END

GO
/****** Object:  StoredProcedure [dbo].[GetAuthorName]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAuthorName] 
(
 @UserID int,
    @ReportID int,
    @SubjectID int = 0
) 
AS    
BEGIN    
 --SELECT LastName + ',  ' + FirstName, UserName FROM Users Order By LastName 
  Begin Try           
    Begin 

	if(@SubjectID > 0)
	begin

		select Users.LastName + ',  ' + Users.FirstName, Users.UserName
		from SubReportsAccessUsers
		left join Users on Users.ID=SubReportsAccessUsers.ReportAccessBy
		where ReportID = 0 and SubjectID = @SubjectID
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
	end
	else
	begin

		select Users.LastName + ',  ' + Users.FirstName, Users.UserName
		from SubReportsAccessUsers
		left join Users on Users.ID=SubReportsAccessUsers.ReportAccessBy
		where ReportID=@ReportID and CreatedBy=@UserID
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
		end

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch  
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerPermissions_ByRoleId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[GetCustomerPermissions_ByRoleId] --1
(  
@Id int=0  
)  
AS  
BEGIN  

if exists(select * from ManageCustomerPermissions where RoleId=@Id)  
begin  
 select mn.Id,mn.MenuName,mn.ParentId,  
 p.RoleId  
  from ManageMenus mn  
 left join ManageCustomerPermissions p   
 on mn.Id=p.MenuId  
 where p.RoleId=@Id 
 union
 select mn.Id,mn.MenuName,mn.ParentId,  
 p.RoleId  
  from ManageMenus mn  
 left join ManageCustomerPermissions p   
 on mn.Id=p.MenuId  
 
 group by  mn.Id,mn.MenuName,mn.ParentId,  
 p.RoleId
 end  
 else  
 begin  
  select mn.Id,mn.MenuName,mn.ParentId,  
 0 as RoleId  
  from ManageMenus mn  
 left join ManageCustomerPermissions p  
 on mn.Id=p.MenuId  
 group by mn.Id,mn.MenuName,mn.ParentId
 end  
END
GO
/****** Object:  StoredProcedure [dbo].[GetDisplayNames]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetDisplayNames]
AS
BEGIN
	Select distinct(DisplayName) from EmployeePaceAuditShuffleShoe
	--select '' as DisplayName
END
GO
/****** Object:  StoredProcedure [dbo].[GetDisplayNames_ByGame]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDisplayNames_ByGame] --'1'  
@Game Varchar(10)    ,
@IncidentId int=0  
As    
BEGIN    
 SELECT DISTINCT DisplayName 
 FROM EmployeePaceAuditShuffleShoe    
 WHERE Game = '' + @Game   + ''
 AND IncidentId=@IncidentId 
 AND Observation IS NOT NULL 
END

GO
/****** Object:  StoredProcedure [dbo].[GetMenuNames]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetMenuNames]
AS
BEGIN
	Select Id,MenuName,ParentId,0 as PermissionType from ManageMenus
END
GO
/****** Object:  StoredProcedure [dbo].[GetNatureImage]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetNatureImage](
@NatureType int,
@Nature nvarchar(200)
)
AS
Begin
	Select * From MasterNatureofIncident where Id=@NatureType and Nature=@Nature
End


--exec GetNatureImage '7','Abc'
GO
/****** Object:  StoredProcedure [dbo].[GetObservation_ByAuditType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetObservation_ByAuditType] --'1'  
@AuditType nvarchar(50)=null  ,
@IncidentId int=0  
As    
BEGIN    
 Select distinct Observation from EmployeeGameAuditScore    
 where AuditType=@AuditType  
 and IncidentId=@IncidentId  
END
GO
/****** Object:  StoredProcedure [dbo].[GetObservation_ByAuditTypeNew]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetObservation_ByAuditTypeNew] --'1'  
@AuditID int=0    ,
@IncidentId int=0  
As    
BEGIN    
 SELECT DISTINCT Observation 
 FROM EmployeeAuditReport    
 WHERE AuditID=@AuditID  
 AND IncidentId=@IncidentId  
END

GO
/****** Object:  StoredProcedure [dbo].[GetPaceAudit_ByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetPaceAudit_ByIncidentID]  
(  
@IncidentId int=0,  
@Game nvarchar(30)=null,  
@ShuffleShoe nvarchar(10)=null,  
@DisplayName nvarchar(50)=null  
)  
AS  
BEGIN  
if(@DisplayName is not null)
begin
 Select * from EmployeePaceAuditShuffleShoe where   
 IncidentID=@IncidentId and   
 Game=@Game and   
 --ShuffleShoe=@ShuffleShoe and   
 DisplayName=@DisplayName  
 end
 else
  begin
	 Select * from EmployeePaceAuditShuffleShoe where   
 IncidentID=@IncidentId and   
 Game=@Game 
 --and   ShuffleShoe=@ShuffleShoe 
 end
END
GO
/****** Object:  StoredProcedure [dbo].[GetPermissions_ByRoleId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetPermissions_ByRoleId] --0,1,'Employees'
(    
@Id int=0 ,
@UserId int=0,
@MenuId nvarchar(100)=null   
)    
AS    
BEGIN    
  if(@MenuId is not null and @UserId>0)
  begin
	Select max(PermissionType) as PermissionType  from ManagePermissions mp
	join UserInRole ur on ur.RoleId=mp.RoleId
	join ManageMenus mm on mm.Id=mp.MenuId
	where ur.userId=@UserId and mm.MenuName=@MenuId
  end
  else
  begin
  
Select MenuId as Id,PermissionType from ManagePermissions where RoleId=@Id
end
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuestionAuditTypes]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CReate procedure [dbo].[GetQuestionAuditTypes]
AS
BEGIN
	SELECT DISTINCT AuditType FROM AuditQuestions ORDER BY AuditType
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuestions_ByAuditType]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetQuestions_ByAuditType] --1,5
(
@AuditType nvarchar(50)=null,
@Observation int=0,
@IncidentId int =0
)
AS
BEGIN
if(@Observation>0)
begin
	Select aq.QuestionID,aq.QuestionGroup,aq.Question,gac.AuditScore,gac.AuditComment,aq.ScoreType 
	into #tempTable
	from AuditQuestions aq
	left join EmployeeGameAuditScore gac
	on aq.QuestionID=gac.QuestionID
	where aq.AuditType=@AuditType
	and gac.Observation=@Observation
	and IncidentId=@IncidentId 
	
	if((Select count(*) from #tempTable)=0)
	begin
		Select aq.QuestionID,aq.QuestionGroup,aq.Question,'' as AuditScore,'' as AuditComment,aq.ScoreType 
		from AuditQuestions aq
		left join EmployeeGameAuditScore gac
		on aq.QuestionID=gac.QuestionID
		where aq.AuditType=@AuditType
		--and IncidentId=@IncidentId 
		 
	end
	else
	Select * from #tempTable
	
end
else
begin
	Select aq.QuestionID,aq.QuestionGroup,aq.Question,'' as AuditScore,'' as AuditComment,aq.ScoreType 
	from AuditQuestions aq
	left join EmployeeGameAuditScore gac
	on aq.QuestionID=gac.QuestionID
	where aq.AuditType=@AuditType
	
	end
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuestions_ByAuditTypeNew]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetQuestions_ByAuditTypeNew] --1,5
(
@AuditID int=0,
@Observation int=0,
@IncidentId int =0
)
AS
BEGIN
if(@Observation>0)
begin
    SELECT au.QuestionID AS AuditID ,aq.QuestionID,aq.Question,aq.QuestionType,gac.AnswerOrScore,gac.Comment
    into #tempTable
    FROM AuditQuestions AS au
    INNER JOIN AuditsQuestions AS aq ON au.QuestionID = aq.AuditID
    LEFT JOIN EmployeeAuditReport AS gac
    ON aq.QuestionID = gac.QuestionID
    WHERE au.QuestionID = @AuditID
    AND gac.Observation = @Observation
    AND IncidentId = @IncidentId 
	
	if((Select count(*) from #tempTable)=0)
	begin
		Select au.QuestionID AS AuditID ,aq.QuestionID,aq.Question,aq.QuestionType,'' AS AnswerOrScore, '' AS Comment
		FROM AuditQuestions AS au
		  INNER JOIN AuditsQuestions AS aq ON au.QuestionID = aq.AuditID
		where au.QuestionID = @AuditID
		--and IncidentId=@IncidentId 
		 
	end
	else
	Select * from #tempTable
	
end
else
begin
	Select au.QuestionID AS AuditID ,aq.QuestionID,aq.Question,aq.QuestionType,'' AS AnswerOrScore, '' AS Comment
		FROM AuditQuestions AS au
		  INNER JOIN AuditsQuestions AS aq ON au.QuestionID = aq.AuditID
		where au.QuestionID = @AuditID
	
	end
END

GO
/****** Object:  StoredProcedure [dbo].[HairColor_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[HairColor_Delete](  
@Id int  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Delete from HairColor where Id=@Id   
	  Select @@RowCount as RESULT   
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[HairColor_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[HairColor_IU](  
@Id int,  
@HairColor nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM HairColor  where Id=@Id)    
   begin    
   update HairColor set HairColor=@HairColor where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into HairColor(HairColor) values(@HairColor)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[HairColor_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[HairColor_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from HairColor  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[HairLength_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[HairLength_Delete](  
@Id int  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Delete from HairLength where Id=@Id   
	  Select @@RowCount as RESULT   
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[HairLength_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[HairLength_IU](  
@Id int,  
@HairLength nvarchar(200),
@ImagePath nvarchar(200) = null   
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM HairLength  where Id=@Id)    
   begin    
   update HairLength set HairLength = @HairLength,ImagePath=@ImagePath where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into HairLength(HairLength,ImagePath) values(@HairLength,@ImagePath)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[HairLength_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[HairLength_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from HairLength  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[HeightUnit_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[HeightUnit_Delete](  
@id int=0
)  
as  
begin  
	Delete from MasterHeightUnit where id=@id
	select @@RowCount as Result
end


GO
/****** Object:  StoredProcedure [dbo].[HeightUnit_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[HeightUnit_IU](
@id int=0,
@HeightUnit nvarchar(100)=Null,
@IsDefault bit = NULL
)
as
begin
	if exists(Select * from MasterHeightUnit where id=@id)
	begin
		IF @IsDefault = 1
			BEGIN
				UPDATE MasterHeightUnit SET IsDefault = 0 WHERE id <> @id
			END
		UPDATE MasterHeightUnit SET HeightUnitName=@HeightUnit, IsDefault =@IsDefault WHERE id=@id
		select @@Rowcount as RESULT
	end
	else
	begin 
		IF @IsDefault = 1
		BEGIN
			UPDATE MasterHeightUnit SET IsDefault = 0 
		END
		INSERT INTO MasterHeightUnit(HeightUnitName,IsDefault) values(@HeightUnit,@IsDefault)
		select @@Identity as RESULT
	end
end


GO
/****** Object:  StoredProcedure [dbo].[ImageCount]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ImageCount]

as
begin
	SELECT COUNT(*) AS TotalImages,
	(SELECT COUNT(*) AS PicCount FROM PicturesVideos WHERE MediaExtention = 'jpg' AND PicType = 0) AS SubjectImages ,
	(SELECT COUNT(*) AS PicCount FROM PicturesVideos WHERE MediaExtention = 'jpg' AND EncodeState > 1) AS EncodedImages,
	(SELECT COUNT(*) AS PicCount FROM PicturesVideos WHERE MediaExtention = 'jpg' AND EncodeState = 1) AS RejectedImages,
	(SELECT COUNT(*) AS PicCount FROM PicturesVideos WHERE MediaExtention = 'jpg' AND PicType = 1) AS EmployeeImages,
	(SELECT COUNT(*) AS PicCount FROM PicturesVideos WHERE MediaExtention = 'jpg' AND ((EncodeState = 0) OR (EncodeState Is Null))) AS NotEncodedImages
	 FROM PicturesVideos WHERE MediaExtention = 'jpg'
end
GO
/****** Object:  StoredProcedure [dbo].[IncidentAudit_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[IncidentAudit_IU]
(
@IncidentId int=0,
@QuestionId int=0,
@AuditType varchar(50)=null,
@AuditScore varchar(10)=null,
@AuditComment ntext=null,
@Observation int=0
)
AS
BEGIN
	if exists(Select * from EmployeeGameAuditScore 
	where IncidentID=@IncidentId 
	and Observation=@Observation
	 and AuditType=@AuditType 
	 and QuestionID=@QuestionId)
	 begin
		update EmployeeGameAuditScore set
		 AuditScore=@AuditScore, 
		 AuditComment=@AuditComment 

		 where IncidentID=@IncidentId 
			and Observation=@Observation
			 and AuditType=@AuditType 
			 and QuestionID=@QuestionId

 
	 end
else
begin

INSERT INTO EmployeeGameAuditScore 
(IncidentID,
 QuestionID, 
 AuditType, 
 AuditScore, 
 AuditComment, 
 Observation) 
 VALUES (
 @IncidentId,
 @QuestionId,
 @AuditType,
 @AuditScore,
 @AuditComment,
 @Observation)
 
 end
 
 if exists(Select * from EmployeeGameAuditScores 
	 where IncidentID=@IncidentId 
			and AuditSequence=@Observation
			 and AuditType=@AuditType 
			 and QuestionID=@QuestionId)
	 begin
		update EmployeeGameAuditScores set
		 AuditScore=@AuditScore 		

		 where IncidentID=@IncidentId 
			and AuditSequence=@Observation
			 and AuditType=@AuditType 
			 and QuestionID=@QuestionId

 
	 end
else
begin
 
 INSERT INTO EmployeeGameAuditScores 
(IncidentID,
 QuestionID, 
 AuditType,
 AuditSequence, 
 AuditScore) 
 VALUES (
 @IncidentId,
 @QuestionId,
 @AuditType,
 @Observation,
 @AuditScore)
 
 end
 
 sElect @@Rowcount
END

GO
/****** Object:  StoredProcedure [dbo].[IncidentAudit_IUNew]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[IncidentAudit_IUNew]
(
@IncidentId int=0,
@QuestionId int=0,
@AuditId int=0,
@AnswerOrScore varchar(6)=null,
@Comment varchar(2000)=null,
@Observation int=0
)
AS
BEGIN
	if exists(Select * from EmployeeAuditReport 
	where IncidentID=@IncidentId 
	and Observation=@Observation
	 and AuditId=@AuditId 
	 and QuestionID=@QuestionId)
	 begin
		update EmployeeAuditReport set
		 AnswerOrScore=@AnswerOrScore, 
		 Comment=@Comment 
		 where IncidentID=@IncidentId 
			and Observation=@Observation
			 and AuditId=@AuditId 
			 and QuestionID=@QuestionId
	 end
else
begin

INSERT INTO EmployeeAuditReport 
(IncidentID,
 QuestionID, 
 AuditId, 
 AnswerOrScore, 
 Comment, 
 Observation) 
 VALUES (
 @IncidentId,
 @QuestionId,
 @AuditId,
 @AnswerOrScore,
 @Comment,
 @Observation)
 
 end
 
 if exists(Select * from EmployeeAuditReportScores 
	 where IncidentID=@IncidentId 
			and AuditSequence=@Observation
			 and AuditId =@AuditId 
			 and QuestionID=@QuestionId)
	 begin
		update EmployeeAuditReportScores set
		 AnswerOrScore=@AnswerOrScore 		

		 where IncidentID=@IncidentId 
			and AuditSequence=@Observation
			 and AuditId =@AuditId 
			 and QuestionID=@QuestionId

 
	 end
else
begin
 
 INSERT INTO EmployeeAuditReportScores 
(IncidentID,
 QuestionID, 
 AuditId,
 AuditSequence, 
 AnswerOrScore) 
 VALUES (
 @IncidentId,
 @QuestionId,
 @AuditId,
 @Observation,
 @AnswerOrScore)
 
 end
 
 sElect @@Rowcount
END


GO
/****** Object:  StoredProcedure [dbo].[IncidentBanned_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[IncidentBanned_IU]--'1',
(
@BannedId int=0,
@IncidentId int=0,
@StartDate nvarchar(50),
@EndDate nvarchar(50), 
@EntryDate nvarchar(50),
@AuthorizedBy nvarchar(50),
@Description ntext,
@BanYears int, 
@BanMonths int,
@BanDays int,
@BanTypeId int
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        --DELETE FROM Banned WHERE IncidentID = @IncidentId
	   If @BannedId = 0 
	   BEGIN
		Insert into Banned(      
		IncidentID, StartDate, EndDate, EntryDate, AuthorizedBy, Description, BanYears, BanMonths, BanDays
		,BanTypeId   
		)         
		values (  
		@IncidentID, @StartDate, @EndDate, @EntryDate, @AuthorizedBy, @Description, @BanYears, @BanMonths
		, @BanDays,@BanTypeId
	   
		)          
		  select @@IDENTITY    
	   END
	   ELSE
	   BEGIN
		  UPDATE Banned SET
		  StartDate = @StartDate,
		  EndDate = @EndDate,
		  EntryDate = @EntryDate,
		  AuthorizedBy = @AuthorizedBy,
		  Description = @Description,
		  BanYears = @BanYears,
		  BanMonths = @BanMonths,
		  BanDays = @BanDays,
		  BanTypeId = @BanTypeId
		  WHERE BannedID = @BannedId;

		  select @@ROWCOUNT
	   END
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[IncidentBanType_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[IncidentBanType_I]--'1',
(
@IncidentId int=0,
@SubjectID int=0,
@BanTypeTable dbo.BanTypeTable READONLY
)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM SubjectBanType WHERE IncidentID = @IncidentId
        Insert into SubjectBanType
	SELECT @SubjectID, @IncidentID,BanName  
	FROM @BanTypeTable
		--Insert Into SubjectBanType (SubjectID, IncidentID, BanName) Values( @SubjectID,
		--@IncidentId,    
		--@BanName
	   
		--)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[IncidentCount_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[IncidentCount_print] --'Subject','','','Incidents.ShortDescriptor, Incidents.Location'
(
@Type nvarchar(100),
@StartDate datetime,
@EndDate datetime,
@ShortLocation nvarchar(100)
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' AND IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+'AND IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' AND IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 

	  if(@Type='Subject')
		set @SQL='SELECT Incidents.ShortDescriptor, Incidents.Location,
				COUNT(*) AS IncidentCount FROM Incidents 
				'+ @Where+'
			GROUP BY '+@ShortLocation+'
			ORDER BY '+@ShortLocation+''
	  else
		set @SQL='SELECT EmployeeIncidents.ShortDescriptor,EmployeeIncidents.Location,
				COUNT(*) AS IncidentCount FROM EmployeeIncidents 
				'+ @Where+'
				GROUP BY '+@ShortLocation+' 
				ORDER BY '+@ShortLocation+''	
execute(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[IncidentGeneralReports_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[IncidentGeneralReports_IU]
(
@ReportID int=0,
@UserId nvarchar(25), 
@ReportDate datetime, 
@Report ntext

)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM IncidentGeneralReports WHERE ReportID = @ReportID
		Insert into IncidentGeneralReports(      
		ReportID, 
		UserId, 
		ReportDate, 
		Report    
		)         
		values (  
		@ReportID,    
		@UserId, 
		@ReportDate, 
		@Report
	   
		)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[IncidentGenReports_LoadByReportID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[IncidentGenReports_LoadByReportID] 
@ReportID int=0    
As    
BEGIN    
 Select * from IncidentGeneralReports    
 where ReportID=@ReportID 
 Select @@RowCount as Result 
END
GO
/****** Object:  StoredProcedure [dbo].[IncidentList_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[IncidentList_print]
(
@Type nvarchar(100),
@StartDate datetime,
@EndDate datetime
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if(@Type='Subject')
	begin
		if (@StartDate <>'' AND @EndDate <>'')        
				set @Where=@Where+'Incidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
			  if (@StartDate  <>'' AND @EndDate  ='')        
				  set @Where=@Where+' Incidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
			  if (@StartDate ='' AND @EndDate <>'')     
			  set @Where=@Where+'Incidents.IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 

	  
				set @SQL='SELECT SubjectIncidents.SubjectID, SubjectIncidents.IncidentID, Incidents.IncidentDate,
						Subjects.FirstName + '' '' + Subjects.LastName AS Name, Incidents.NatureOfEvent, 
						Incidents.ShortDescriptor, Incidents.Status, Incidents.Location FROM Subjects
						INNER JOIN SubjectIncidents ON Subjects.SubjectID = SubjectIncidents.SubjectID 
						INNER JOIN Incidents ON SubjectIncidents.IncidentID = Incidents.IncidentID 
						'+ @Where+''
	end
else
	begin
	if (@StartDate <>'' AND @EndDate <>'')        
			set @Where=@Where+'EmployeeIncidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
		  if (@StartDate  <>'' AND @EndDate  ='')        
			  set @Where=@Where+' EmployeeIncidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
		  if (@StartDate ='' AND @EndDate <>'')     
		  set @Where=@Where+'EmployeeIncidents.IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 
		  	
		set @SQL='SELECT EmpEmployeeIncidents.EmployeeID, EmpEmployeeIncidents.IncidentID, 
				EmployeeIncidents.IncidentDate, Employees.FirstName + '' '' + Employees.LastName AS Name,
				EmployeeIncidents.NatureOfEvent, EmployeeIncidents.ShortDescriptor, EmployeeIncidents.Status,
				EmployeeIncidents.Location FROM Employees 
				INNER JOIN EmpEmployeeIncidents ON Employees.EmployeeID = EmpEmployeeIncidents.EmployeeID 
				INNER JOIN EmployeeIncidents ON EmpEmployeeIncidents.IncidentID = EmployeeIncidents.IncidentID 
				'+ @Where+''
	end
execute(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[IncidentNatureOfEvent_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[IncidentNatureOfEvent_LoadAll]   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select NatureOfEvent from IncidentType group by NatureOfEvent
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[IncidentReports_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[IncidentReports_IU]--'1',
(
@IncidentId int=0,
@UserId nvarchar(25), 
@ReportDate datetime, 
@Report ntext

)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM IncidentReports WHERE IncidentID = @IncidentId
		Insert into IncidentReports(      
		IncidentID, 
		UserId, 
		ReportDate, 
		Report    
		)         
		values (  
		@IncidentId,    
		@UserId, 
		@ReportDate, 
		@Report
	   
		)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[Incidents_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Incidents_Delete] 
@Id int=0  
AS  
BEGIN  
 DElete from Incidents where IncidentID=@Id  
 DElete from SubjectIncidents where IncidentID=@Id 
 Delete from LCTPitTransactions where IncidentID=@ID 
 Delete from LCTForeignExchange where IncidentID=@ID 
 Delete from LCTCashOuts where IncidentID=@ID 
 Delete from LCTCashCall where IncidentID=@ID 
 select @@rowcount  
END

GO
/****** Object:  StoredProcedure [dbo].[Incidents_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Incidents_IU]  
(  
@SubjectId int=0,  
@Id int=0,  
@IncidentNumber nvarchar(20),   
@NatureOfEvent nvarchar(50),   
@ShortDescriptor nvarchar(25),   
@ActiveStatus bit,   
@Status nvarchar(25),   
@IncidentDate datetime,  
@Description ntext,   
@Location nvarchar(50),   
@IncidentRole nvarchar(50),   
@OccurrenceNumber nvarchar(50),   
@IncidentTime nvarchar(10),   
@EndDate datetime, 
@EndTime varchar(10), 
@RoleName nvarchar(50),   
@UD26 nvarchar(50),   
@UD32 nvarchar(50),   
@UD33 nvarchar(50),   
@EventID int=0,
@CreatedBy int,
@ReportView bit,
@ReportEdit bit,
@ReportDelete bit  
)  
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
         
 Begin    
   
 if(@ActiveStatus=1)      
  begin      
   Update Subjects   
   Set Status = @Status WHERE SubjectID = @SubjectId    
  end   
         
  if(@Id>0)        
  begin        
  update Incidents set        
    IncidentNumber=@IncidentNumber,   
    NatureOfEvent=@NatureOfEvent,   
    ShortDescriptor=@ShortDescriptor,   
    ActiveStatus=@ActiveStatus,   
    Status=@Status,   
    IncidentDate=@IncidentDate,   
    Description=@Description,   
    Location=@Location,   
    IncidentRole=@IncidentRole,   
    OccurrenceNumber=@OccurrenceNumber,   
    IncidentTime=@IncidentTime,   
    RoleName=@RoleName,
    EndDate=@EndDate,
    EndTime=@EndTime,         
    UD26=@UD26,   
    UD32=@UD32,   
    UD33=@UD33,   
    EventID=@EventID,
	ReportDelete=@ReportDelete,
	ReportEdit=@ReportEdit,
	ReportView=@ReportView   
  where IncidentID=@Id        
         
 select @Id     
  end        
  else        
  begin     
          
    Insert into Incidents(        
    IncidentNumber,   
    NatureOfEvent,   
    ShortDescriptor,   
    ActiveStatus,   
    Status,   
    IncidentDate,   
    Description,   
    Location,   
    IncidentRole,   
    OccurrenceNumber,   
    IncidentTime,   
    RoleName,
    EndDate,
    EndTime,   
    UD26,   
    UD32,   
    UD33,   
    EventID,
	CreatedBy,
	CreatedDate,
	ReportView,
	ReportEdit,
	ReportDelete
    )           
    values (        
    @IncidentNumber,   
    @NatureOfEvent,   
    @ShortDescriptor,   
    @ActiveStatus,   
    @Status,   
    @IncidentDate,   
    @Description,   
    @Location,   
    @IncidentRole,   
    @OccurrenceNumber,   
    @IncidentTime,   
    @RoleName,
    @EndDate,
    @EndTime,   
    @UD26,   
    @UD32,   
    @UD33,   
    @EventID,
	@CreatedBy,
	getdate(),
	@ReportView,
	@ReportEdit,
	@ReportDelete
    )            
    select @Id=@@IDENTITY        
            
      update Incidents set      
      IncidentNumber=@IncidentNumber      
      where IncidentID=@Id      
    Insert into SubjectIncidents(SubjectID, IncidentID)           
    values (@SubjectId,@Id)    
      
    select @Id   
   end        
 End           
  COMMIT TRANSACTION           
 End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 


GO
/****** Object:  StoredProcedure [dbo].[Incidents_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Incidents_LoadAll](@UserID           INT,
                                                  --@SubjectId        INT = 0,
										@EventId        INT = 0,
                                                  @ReportAccessRole INT,
                                                  @AllReport        INT = 0)
AS
     BEGIN
	DECLARE @viewpermission BIT= 0;

         IF(@AllReport > 0)
             BEGIN
                 SELECT Users.UserName AS ReportCreatorUser,
                        MSD.Descriptor AS ShortDescriptorName,
                        '' StatusName,
                        CASE
                            WHEN isnull(MN.NatureImage, '') <> ''
                            THEN MN.NatureImage
                            ELSE
                 (
                     SELECT ImagePath
                     FROM ReportLogoImage
                     WHERE SetImage = 1
                 )
                        END AS DefaultImage,
                        CAST(description AS NVARCHAR) AS textdesc,
                        mn.nature AS noi,
                        Incidents.IncidentID,
                        Incidents.IncidentNumber,
                        Incidents.CreatedDate AS CreatedDate,
				    SubjectIncidents.SubjectID
				    ,EI.ID AS EventIncidentID
				    ,S.FirstName
				    ,S.LastName
				    ,CASE WHEN EI.IncidentID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
                 FROM Incidents
                      INNER JOIN Users ON Users.ID = Incidents.CreatedBy
				  INNER JOIN SubjectIncidents ON Incidents.IncidentID = SubjectIncidents.IncidentID
				  INNER JOIN Subjects AS S ON SubjectIncidents.SubjectID = S.SubjectID
                      LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = Incidents.ShortDescriptor
                      LEFT JOIN MasterStatus MS ON MS.ID = Incidents.Status
                      LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                             AND NatureType = 1
				LEFT JOIN EventSubjectIncidents AS EI ON Incidents.IncidentID = EI.IncidentID AND EI.EventID = @EventId 
				ORDER BY EI.IncidentID DESC;
             END;
         ELSE
             BEGIN
			 IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
             END; 

                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM SubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                  -- AND SubjectId = @SubjectId
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM SubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   --AND SubjectId = @SubjectId
							AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                                   AND ReportID <> 0
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
                      SELECT Users.UserName AS ReportCreatorUser,
                             MSD.Descriptor AS ShortDescriptorName,
                             '' StatusName,
                             CASE
                                 WHEN isnull(MN.NatureImage, '') <> ''
                                 THEN MN.NatureImage
                                 ELSE
                      (
                          SELECT ImagePath
                          FROM ReportLogoImage
                          WHERE SetImage = 1
                      )
                             END AS DefaultImage,
                             CAST(description AS NVARCHAR) AS textdesc,
                             mn.nature AS noi,
                             Incidents.IncidentID,
                             Incidents.IncidentNumber,
                             Incidents.CreatedDate AS CreatedDate,
				    SubjectIncidents.SubjectID,EI.ID AS EventIncidentID
				    ,S.FirstName
				    ,S.LastName
				     ,CASE WHEN EI.IncidentID IS NULL THEN 'False' ELSE 'True' END AS isLinkedEvent
                      FROM Incidents
                           INNER JOIN Users ON Users.ID = Incidents.CreatedBy
					  INNER JOIN SubjectIncidents ON Incidents.IncidentID = SubjectIncidents.IncidentID
					  INNER JOIN Subjects AS S ON SubjectIncidents.SubjectID = S.SubjectID
                           LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = Incidents.ShortDescriptor
                           LEFT JOIN MasterStatus MS ON MS.ID = Incidents.Status
                           LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
					  LEFT JOIN EventSubjectIncidents AS EI ON Incidents.IncidentID = EI.IncidentID AND EI.EventID = @EventId 
                      WHERE(Incidents.CreatedBy = @UserID
                            AND ReportView = '1'
                            AND Incidents.IncidentID IN
                           (
                               SELECT IncidentID
                               FROM SubjectIncidents
                               --WHERE SubjectId = @SubjectId
                           ))
                           OR (
					   --IncidentID IN
        --                      (
        --                          SELECT ReportID
        --                          FROM SubReportsLink
        --                          WHERE ReportLinkWith = @SubjectId
        --                                AND FetchDetailsBy = '0'
        --                      )
        --                       OR 
						 Incidents.IncidentID IN
                              (
                                  SELECT ReportID
                                  FROM cteReportPermission
                              )
						OR (@viewpermission = 1 AND Incidents.IncidentID IN
                           (
                               SELECT IncidentID
                               FROM SubjectIncidents
                              -- WHERE SubjectId = @SubjectId
                           ))
                           )
					  ORDER BY EI.IncidentID DESC;
             END;
     END;
GO
/****** Object:  StoredProcedure [dbo].[Incidents_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Incidents_LoadByIncidentID]    
@IncidentId int=0 ,
@UserID int,
@ReportAccessRole int 
As
DECLARE @viewpermission BIT= 0;
DECLARE @editpermission BIT= 0;
DECLARE @deletepermission BIT= 0;   

BEGIN    

IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
                 SET @editpermission = 1;
			  SET @deletepermission = 1;
             END; 

WITH 
cteviewPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM SubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM SubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                                   AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
						  OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
,ctePermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,EditReport,DeleteReport,
                                    1 AS ByRole
                             FROM SubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,EditReport,DeleteReport,
                                    2 ByUser
                             FROM SubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                         ) AS UP ON RP.ReportID = UP.ReportID
                        )
,cteeditPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    EditReport,
                                    1 AS ByRole
                             FROM SubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND EditReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    EditReport,
                                    2 ByUser
                             FROM SubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
                                   AND (EditReport = '1' OR EditReport IS NULL OR EditReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.EditReport = 1
                               AND UP.EditReport = 1)
						  OR (RP.EditReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.EditReport = 1
                                  AND RP.ReportID IS NULL))
,ctedeletePermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    DeleteReport,
                                    1 AS ByRole
                             FROM SubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND ReportID = @IncidentId
                                   AND DeleteReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    DeleteReport,
                                    2 ByUser
                             FROM SubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND ReportID = @IncidentId
                                   AND ReportID <> 0
							AND (DeleteReport = '1' OR DeleteReport IS NULL OR DeleteReport = 0)
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.DeleteReport = 1
                               AND UP.DeleteReport = 1)
						 OR (RP.DeleteReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.DeleteReport = 1
                                  AND RP.ReportID IS NULL))

 Select 
 (CASE
    WHEN @viewpermission = 1
    THEN @viewpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteviewPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS viewpermission, 
 (CASE
    WHEN @editpermission = 1
    THEN @editpermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM cteeditPermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS editpermission,
(CASE
    WHEN @deletepermission = 1
    THEN @deletepermission
    ELSE(CASE
            WHEN
        (
            SELECT COUNT(*)
            FROM ctedeletePermission
        ) > 0
            THEN 1
            ELSE 0
        END)
END) AS deletepermission,
 Users.UserName as ReportCreatorUser,Users.FirstName as ReportCreatorFirstName,
  Users.LastName as ReportCreatorLastName,Incidents.* from Incidents    
 inner join Users on Users.ID=Incidents.CreatedBy
 where IncidentID=@IncidentId  
END




GO
/****** Object:  StoredProcedure [dbo].[Incidents_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Incidents_LoadBySubjectId](@UserID           INT,
                                                  @SubjectId        INT = 0,
                                                  @ReportAccessRole INT,
                                                  @AllReport        INT = 0)
AS
     BEGIN
	DECLARE @viewpermission BIT= 0;

         IF(@AllReport > 0)
             BEGIN
                 SELECT Users.UserName AS ReportCreatorUser,
                        MSD.Descriptor AS ShortDescriptorName,
                        '' StatusName,
                        CASE
                            WHEN isnull(MN.NatureImage, '') <> ''
                            THEN MN.NatureImage
                            ELSE
                 (
                     SELECT ImagePath
                     FROM ReportLogoImage
                     WHERE SetImage = 1
                 )
                        END AS DefaultImage,
                        CAST(description AS NVARCHAR) AS textdesc,
                        mn.nature AS noi,
                        Incidents.IncidentID,
                        Incidents.IncidentNumber,
                        Incidents.CreatedDate AS CreatedDate,
                 (
                     SELECT LinkWithReport
                     FROM SubReportsLink
                     WHERE ReportLinkWith = @SubjectId
                           AND FetchDetailsBy = '0'
                           AND ReportID = IncidentID
                 ) AS LinkWithReport,
                 (
                     SELECT SubjectID
                     FROM SubReportsLink
                     WHERE ReportLinkWith = @SubjectId
                           AND FetchDetailsBy = '0'
                           AND ReportID = IncidentID
                 ) AS LinkByEmpID,
                 (
                     SELECT Subjects.FirstName+' '+Subjects.LastName
                     FROM SubReportsLink
                          LEFT JOIN Subjects ON SubReportsLink.SubjectID = Subjects.SubjectID
                     WHERE SubReportsLink.ReportLinkWith = @SubjectId
                           AND SubReportsLink.FetchDetailsBy = '0'
                           AND SubReportsLink.ReportID = IncidentID
                 ) AS LinkEmployeeName,
                        '0' AS LinkFile
                 FROM Incidents
                      INNER JOIN Users ON Users.ID = Incidents.CreatedBy
                      LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = Incidents.ShortDescriptor
                      LEFT JOIN MasterStatus MS ON MS.ID = Incidents.Status
                      LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                             AND NatureType = 1
                 UNION
                 SELECT Users.UserName AS ReportCreatorUser,
                        MSD.Descriptor AS ShortDescriptorName,
                        '' AS StatusName,
                        CASE
                            WHEN isnull(MN.NatureImage, '') <> ''
                            THEN MN.NatureImage
                            ELSE
                 (
                     SELECT ImagePath
                     FROM ReportLogoImage
                     WHERE SetImage = 1
                 )
                        END AS DefaultImage,
                        CAST(description AS NVARCHAR) AS textdesc,
                        '' AS noi,
                        EmployeeIncidents.IncidentID,
                        EmployeeIncidents.IncidentNumber,
                        EmployeeIncidents.CreatedDate AS CreatedDate,
                 (
                     SELECT LinkWithReport
                     FROM EmpReportsLink
                     WHERE ReportLinkWith = @SubjectId
                           AND FetchDetailsBy = 'Subject'
                           AND ReportID = IncidentID
                 ) AS LinkWithReport,
                 (
                     SELECT EmployeeID
                     FROM EmpReportsLink
                     WHERE ReportLinkWith = @SubjectId
                           AND FetchDetailsBy = 'Subject'
                           AND ReportID = IncidentID
                 ) AS LinkByEmpID,
                 (
                     SELECT Employees.FirstName+' '+Employees.LastName
                     FROM EmpReportsLink
                          LEFT JOIN Employees ON EmpReportsLink.EmployeeID = Employees.EmployeeID
                     WHERE EmpReportsLink.ReportLinkWith = @SubjectId
                           AND EmpReportsLink.FetchDetailsBy = 'Subject'
                           AND EmpReportsLink.ReportID = IncidentID
                 ) AS LinkEmployeeName,
                        '1' AS LinkFile
                 FROM EmployeeIncidents
                      INNER JOIN Users ON Users.ID = EmployeeIncidents.CreatedBy
                      LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = EmployeeIncidents.ShortDescriptor
                      LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                             AND NatureType = 1
                 WHERE EmployeeIncidents.IncidentID IN
                 (
                     SELECT ReportID
                     FROM EmpReportsLink
                     WHERE ReportLinkWith = @SubjectId
                           AND FetchDetailsBy = 'Subject'
                 );
             END;
         ELSE
             BEGIN
			 IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
			 SET @viewpermission = 1;
             END; 

                 WITH cteReportPermission
                      AS(SELECT ISNULL(RP.ReportID, UP.ReportID) AS ReportID
                         FROM
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    1 AS ByRole
                             FROM SubReportsAccessByRole
                             WHERE ReportAccessRole = @ReportAccessRole
                                   AND SubjectId = @SubjectId
                                   AND ViewReport = '1'
                                   AND ReportID <> 0
                         ) AS RP
                         FULL JOIN
                         (
                             SELECT ReportID,
                                    ViewReport,
                                    2 ByUser
                             FROM SubReportsAccessUsers
                             WHERE ReportAccessBy = @UserID
                                   AND SubjectId = @SubjectId
							AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
                                   AND ReportID <> 0
                         ) AS UP ON RP.ReportID = UP.ReportID
                         WHERE(RP.ViewReport = 1
                               AND UP.ViewReport = 1)
                              OR (RP.ViewReport = 1
                                  AND UP.ReportID IS NULL)
                              OR (UP.ViewReport = 1
                                  AND RP.ReportID IS NULL))
                      SELECT Users.UserName AS ReportCreatorUser,
                             MSD.Descriptor AS ShortDescriptorName,
                             '' StatusName,
                             CASE
                                 WHEN isnull(MN.NatureImage, '') <> ''
                                 THEN MN.NatureImage
                                 ELSE
                      (
                          SELECT ImagePath
                          FROM ReportLogoImage
                          WHERE SetImage = 1
                      )
                             END AS DefaultImage,
                             CAST(description AS NVARCHAR) AS textdesc,
                             mn.nature AS noi,
                             Incidents.IncidentID,
                             Incidents.IncidentNumber,
                             Incidents.CreatedDate AS CreatedDate,
                      (
                          SELECT LinkWithReport
                          FROM SubReportsLink
                          WHERE ReportLinkWith = @SubjectId
                                AND FetchDetailsBy = '0'
                                AND ReportID = IncidentID
                      ) AS LinkWithReport,
                      (
                          SELECT SubjectID
                          FROM SubReportsLink
                          WHERE ReportLinkWith = @SubjectId
                                AND FetchDetailsBy = '0'
                                AND ReportID = IncidentID
                      ) AS LinkByEmpID,
                      (
                          SELECT Subjects.FirstName+' '+Subjects.LastName
                          FROM SubReportsLink
                               LEFT JOIN Subjects ON SubReportsLink.SubjectID = Subjects.SubjectID
                          WHERE SubReportsLink.ReportLinkWith = @SubjectId
                                AND SubReportsLink.FetchDetailsBy = '0'
                                AND SubReportsLink.ReportID = IncidentID
                      ) AS LinkEmployeeName,
                             '0' AS LinkFile
                      FROM Incidents
                           INNER JOIN Users ON Users.ID = Incidents.CreatedBy
                           LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = Incidents.ShortDescriptor
                           LEFT JOIN MasterStatus MS ON MS.ID = Incidents.Status
                           LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                      WHERE(CreatedBy = @UserID
                            AND ReportView = '1'
                            AND IncidentID IN
                           (
                               SELECT IncidentID
                               FROM SubjectIncidents
                               WHERE SubjectId = @SubjectId
                           ))
                           OR (IncidentID IN
                              (
                                  SELECT ReportID
                                  FROM SubReportsLink
                                  WHERE ReportLinkWith = @SubjectId
                                        AND FetchDetailsBy = '0'
                              )
                               OR IncidentID IN
                              (
                                  SELECT ReportID
                                  FROM cteReportPermission
                              )
						OR (@viewpermission = 1 AND IncidentID IN
                           (
                               SELECT IncidentID
                               FROM SubjectIncidents
                               WHERE SubjectId = @SubjectId
                           ))
                           --(
                           --SELECT ReportID
                           --FROM SubReportsAccessUsers
                           --WHERE ReportAccessBy = @UserID
                           --	 AND SubjectId = @SubjectId
                           --	 AND ViewReport = '1'
                           --	 AND ReportID <> 0
                           --)
                           --  OR IncidentID IN
                           --(
                           --SELECT ReportID
                           --FROM SubReportsAccessByRole
                           --WHERE ReportAccessRole = @ReportAccessRole
                           --	 AND SubjectId = @SubjectId
                           --	 AND ViewReport = '1'
                           --	 AND ReportID <> 0
                           --)
                           )
                      UNION
                      SELECT Users.UserName AS ReportCreatorUser,
                             MSD.Descriptor AS ShortDescriptorName,
                             '' AS StatusName,
                             CASE
                                 WHEN isnull(MN.NatureImage, '') <> ''
                                 THEN MN.NatureImage
                                 ELSE
                      (
                          SELECT ImagePath
                          FROM ReportLogoImage
                          WHERE SetImage = 1
                      )
                             END AS DefaultImage,
                             CAST(description AS NVARCHAR) AS textdesc,
                             '' AS noi,
                             EmployeeIncidents.IncidentID,
                             EmployeeIncidents.IncidentNumber,
                             EmployeeIncidents.CreatedDate AS CreatedDate,
                      (
                          SELECT LinkWithReport
                          FROM EmpReportsLink
                          WHERE ReportLinkWith = @SubjectId
                                AND FetchDetailsBy = 'Subject'
                                AND ReportID = IncidentID
                      ) AS LinkWithReport,
                      (
                          SELECT EmployeeID
                          FROM EmpReportsLink
                          WHERE ReportLinkWith = @SubjectId
                                AND FetchDetailsBy = 'Subject'
                                AND ReportID = IncidentID
                      ) AS LinkByEmpID,
                      (
                          SELECT Employees.FirstName+' '+Employees.LastName
                          FROM EmpReportsLink
                               LEFT JOIN Employees ON EmpReportsLink.EmployeeID = Employees.EmployeeID
                          WHERE EmpReportsLink.ReportLinkWith = @SubjectId
                                AND EmpReportsLink.FetchDetailsBy = 'Subject'
                                AND EmpReportsLink.ReportID = IncidentID
                      ) AS LinkEmployeeName,
                             '1' AS LinkFile
                      FROM EmployeeIncidents
                           INNER JOIN Users ON Users.ID = EmployeeIncidents.CreatedBy
                           LEFT JOIN MasterShortDescriptor MSD ON MSD.ID = EmployeeIncidents.ShortDescriptor
                           LEFT JOIN MasterNatureofIncident mn ON mn.Id = NatureOfEvent
                                                                  AND NatureType = 1
                      WHERE EmployeeIncidents.IncidentID IN
                      (
                          SELECT ReportID
                          FROM EmpReportsLink
                          WHERE ReportLinkWith = @SubjectId
                                AND FetchDetailsBy = 'Subject'
                      );
             END;
     END;
GO
/****** Object:  StoredProcedure [dbo].[IncidentType_LoadByNatureOfEvent]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[IncidentType_LoadByNatureOfEvent] --Criminal
(
@NatureOfEvent nvarchar(250)
)
As
Begin
SELECT ShortDescriptor FROM IncidentType WHERE NatureOfEvent =@NatureOfEvent ORDER BY ShortDescriptor
End





GO
/****** Object:  StoredProcedure [dbo].[IncidentType_LoadDistinct]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[IncidentType_LoadDistinct] 
As
Begin
SELECT Distinct NatureOFEvent FROM IncidentType ORDER BY NatureOfEvent
End





GO
/****** Object:  StoredProcedure [dbo].[IncidentTypeDescription_LoadByEventName]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[IncidentTypeDescription_LoadByEventName]  
@Event nvarchar(100) = null  
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from IncidentType where NatureOfEvent = @Event
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[InitiatedBy_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[InitiatedBy_Delete](            
@Id int            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Delete from InitiatedBy where Id=@Id             
   Select @@RowCount as RESULT             
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 
GO
/****** Object:  StoredProcedure [dbo].[InitiatedBy_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE Procedure [dbo].[InitiatedBy_IU](  
@Id int,            
@Initiated nvarchar(200)            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
  if exists(SELECT *  FROM InitiatedBy  where Id=@Id)              
   begin              
   update InitiatedBy set Initiated=@Initiated where Id=@Id              
   select @@RowCount as RESULT          
   end              
  ELSE              
  begin              
   insert into InitiatedBy(Initiated) values(@Initiated)              
   select @@Identity as RESULT            
  end              
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[InitiatedBy_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InitiatedBy_Load]            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Select * from InitiatedBy            
   Select @@RowCount as RESULT            
  End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[Insert_AuditsQuestions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Insert_AuditsQuestions](
@QuestionId int,          
@AuditId int,  
@Question varchar(450),
@QuestionType TinyInt,     
@ToolTip varchar(2000)     
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM AuditsQuestions  where QuestionId = @QuestionId)            
   begin            
   update AuditsQuestions set Question=@Question,QuestionType=@QuestionType,ToolTip=@ToolTip where QuestionId = @QuestionId            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into AuditsQuestions(AuditId,Question,QuestionType,ToolTip) values(@AuditId,@Question,@QuestionType,@ToolTip)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[InsertUpdate_incedent_pref]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[InsertUpdate_incedent_pref](
@prefType nvarchar(50),
@prefValue nvarchar(100)
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM incedent_pref WHERE pref_Type = @prefType)
    BEGIN
        INSERT INTO incedent_pref(pref_Type, pref_Value)
        VALUES(@prefType,@prefValue)
    END
    ELSE
    BEGIN
        UPDATE incedent_pref
        SET pref_Value = @prefValue
        WHERE (pref_Type = @prefType)
    END
END
GO
/****** Object:  StoredProcedure [dbo].[LCTAttestation_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTAttestation_AddEdit]
(
@SubjectID int,
@IncidentID int,  
@EmployeeName nvarchar(50),
@EmployeeTitle nvarchar(50),
@EmployeeGPEB nvarchar(20),
@CashierName nvarchar(50), 
@CashierTitle nvarchar(50), 
@CashierGPEB nvarchar(20)
)
as
begin
	IF EXISTS (SELECT * FROM LCTMain WHERE SubjectID=@SubjectID AND IncidentID=@IncidentID)
	BEGIN 
		Update LCTMain set EmployeeName=@EmployeeName, EmployeeTitle=@EmployeeTitle,
		 EmployeeGPEB=@EmployeeGPEB, CashierName=@CashierName, 
		 CashierTitle=@CashierTitle, CashierGPEB=@CashierGPEB
		 WHERE SubjectID=@SubjectID AND IncidentID=@IncidentID
	   SELECT @@RowCount AS RESULT 
	END
END

GO
/****** Object:  StoredProcedure [dbo].[LCTCashCall_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTCashCall_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from LCTCashCall where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[LCTCashCall_GenReports]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTCashCall_GenReports]  
(  
@ID int,  
@ReportID int,   
@CashCallTime nvarchar(15),   
@Cashier nvarchar(50),   
@Amount float 
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
 if(@ID>0)  
 Begin  
  Update GenReportLCTCashCall set  
  CashCallTime=@CashCallTime,   
  Cashier=@Cashier,   
  Amount=@Amount 
  where ID=@ID  
    
  select @@RowCount   
 End  
 else  
 Begin  
  Insert Into GenReportLCTCashCall  
  (ReportID, CashCallTime, Cashier, Amount)  
  values(@ReportID, @CashCallTime, @Cashier, @Amount)  
    
  select @@IDENTITY  
 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 

GO
/****** Object:  StoredProcedure [dbo].[LCTCashCall_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTCashCall_IU]  
(  
@ID int,  
@SubjectID int,   
@IncidentID int,   
@CashCallTime nvarchar(15),   
@Cashier nvarchar(50),   
@Amount float 
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
 if(@ID>0)  
 Begin  
  Update LCTCashCall set  
  CashCallTime=@CashCallTime,   
  Cashier=@Cashier,   
  Amount=@Amount 
  where ID=@ID  
    
  select @@RowCount   
 End  
 else  
 Begin  
  Insert Into LCTCashCall  
  ( SubjectID, IncidentID, CashCallTime, Cashier, Amount)  
  values( @SubjectID, @IncidentID, @CashCallTime, @Cashier, @Amount)  
    
  select @@IDENTITY  
 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End  

GO
/****** Object:  StoredProcedure [dbo].[LCTCashCall_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LCTCashCall_LoadById]   
@IncidentID int =0 ,  
@SubjectID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select CashierName.CashierName ,LCTCashCall.*  from LCTCashCall
		left join CashierName on CashierName.ID=LCTCashCall.Cashier
		where IncidentID = @IncidentID and SubjectID=@SubjectID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[LCTCashOuts_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTCashOuts_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from LCTCashOuts where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[LCTCashOuts_GenReport]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTCashOuts_GenReport]
(  
@ID int,
@ReportID int,   
@Amount float,
@TypeOfWin nvarchar(20), 
@PaymentType nvarchar(20), 
@ChequeNo nvarchar(20), 
@CashOutTime nvarchar(10), 
@TableNumber nvarchar(20)
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
 if(@ID>0)  
 Begin  
  Update GenReportLCTCashOuts set  
  Amount=@Amount,
  TypeOfWin=@TypeOfWin, 
  PaymentType=@PaymentType, 
  ChequeNo=@ChequeNo, 
  CashOutTime=@CashOutTime, 
  TableNumber=@TableNumber
  where ID=@ID  
    
  select @@RowCount AS RESULT
 End  
 else  
 Begin  
  Insert Into GenReportLCTCashOuts  
  (ReportID, Amount, TypeOfWin, PaymentType, ChequeNo, CashOutTime, TableNumber)  
  values( @ReportID, @Amount, @TypeOfWin, @PaymentType, @ChequeNo, @CashOutTime, @TableNumber)  
    
  select @@IDENTITY  AS RESULT
 End       
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 

GO
/****** Object:  StoredProcedure [dbo].[LCTCashOuts_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTCashOuts_IU]  
(  
@ID int,  
@SubjectID int,   
@IncidentID int,   
@Amount float,
@TypeOfWin nvarchar(20), 
@PaymentType nvarchar(20), 
@ChequeNo nvarchar(20), 
@CashOutTime nvarchar(15), 
@TableNumber nvarchar(20)
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
	 if(@ID>0)  
	 Begin  
	  Update LCTCashOuts set  
	  Amount=@Amount,
	  TypeOfWin=@TypeOfWin, 
	  PaymentType=@PaymentType, 
	  ChequeNo=@ChequeNo, 
	  CashOutTime=@CashOutTime, 
	  TableNumber=@TableNumber
	  where ID=@ID  
    
	  select @@RowCount   
	 End  
	 else  
	 Begin  
	  Insert Into LCTCashOuts  
	  (SubjectID, IncidentID, Amount, TypeOfWin, PaymentType, ChequeNo, CashOutTime, TableNumber)  
	  values( @SubjectID, @IncidentID, @Amount, @TypeOfWin, @PaymentType, @ChequeNo, @CashOutTime, @TableNumber)  
    
	  select @@IDENTITY  
	 End  

	if exists(Select * from TransactionsMain WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID)
	begin
		update TransactionsMain set SubjectID=@SubjectID, IncidentID=@IncidentID,
		 TotalCashOut=(select sum(Amount) from LCTCashOuts WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND PaymentType in (1,3)),
		 CashOutMarker=(select sum(Amount) from LCTCashOuts WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND PaymentType=2)
		WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID
		 SELECT @@RowCount AS RESULT
	end
	else
	begin
		INSERT INTO TransactionsMain ( SubjectID, IncidentID, TotalCashOut,CashOutMarker)
		VALUES (@SubjectID, @IncidentID, 
		(select sum(Amount) from LCTCashOuts WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND PaymentType in (1,3)), 
		(select sum(Amount) from LCTCashOuts WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND PaymentType=2))
		 SELECT @@IDENTITY AS RESULT
	end
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 

GO
/****** Object:  StoredProcedure [dbo].[LCTCashOuts_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LCTCashOuts_LoadById]   
@IncidentID int =0 ,  
@SubjectID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *  from LCTCashOuts where IncidentID = @IncidentID and SubjectID=@SubjectID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[LCTForeignExchange_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTForeignExchange_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from LCTForeignExchange where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[LCTForeignExchange_GenReport]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTForeignExchange_GenReport] 
(  
@ID int,   
@ReportID int,
@ForeignCountry nvarchar(50),  
@Amount float,
@ForeignAmount float, 
@Rate float
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
 if(@ID>0)  
 Begin  
  Update GenReportLCTForeignExchange set 
  ForeignCountry=@ForeignCountry, 
  ForeignAmount=@ForeignAmount, 
  Rate=@Rate, 
  Amount=@Amount 
  where ID=@ID  
    
  select @@RowCount AS RESULT 
 End  
 else  
 Begin  
  Insert Into GenReportLCTForeignExchange  
  (ReportID, ForeignCountry, ForeignAmount, Rate, Amount)  
  values(@ReportID, @ForeignCountry, @ForeignAmount, @Rate, @Amount)  
    
  select @@IDENTITY AS RESULT
 End  
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 

GO
/****** Object:  StoredProcedure [dbo].[LCTForeignExchange_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTForeignExchange_IU]  
(  
@ID int,  
@SubjectID int,   
@IncidentID int,
@ForeignCountry nvarchar(50),  
@Amount float,
@ForeignAmount float, 
@Rate float
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction   
	 if(@ID>0)  
	 Begin  
	  Update LCTForeignExchange set 
		  ForeignCountry=@ForeignCountry, 
		  ForeignAmount=@ForeignAmount, 
		  Rate=@Rate, 
		  Amount=@Amount 
		  where ID=@ID 
	  select @@RowCount   
	 End  
	 else  
	 Begin  
	  Insert Into LCTForeignExchange  
	  (SubjectID, IncidentID, ForeignCountry, ForeignAmount, Rate, Amount)  
	  values(@SubjectID, @IncidentID, @ForeignCountry, @ForeignAmount, @Rate, @Amount)      
	  select @@IDENTITY  
	 End  

	if exists(Select * from TransactionsMain WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID)
	begin
		update TransactionsMain set SubjectID=@SubjectID, IncidentID=@IncidentID,
		 TotalExchange=(select sum(Amount) from LCTForeignExchange WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID)
		WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID
		 SELECT @@RowCount AS RESULT
	end
	else
	begin
		INSERT INTO TransactionsMain ( SubjectID, IncidentID, TotalExchange)
		VALUES (@SubjectID, @IncidentID, 
		(select sum(Amount) from LCTForeignExchange WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID))
		 SELECT @@IDENTITY AS RESULT
	end
     
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 

GO
/****** Object:  StoredProcedure [dbo].[LCTForeignExchange_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LCTForeignExchange_LoadById]   
@IncidentID int =0 ,  
@SubjectID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select ForeignExchangeRates.Country as ForeignCountryName,LCTForeignExchange.* from LCTForeignExchange 
		left join ForeignExchangeRates on ForeignExchangeRates.ID=LCTForeignExchange.ForeignCountry
		where IncidentID = @IncidentID and SubjectID=@SubjectID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[LCTIdentification_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTIdentification_AddEdit]
(
@SubjectID int,
@IncidentID int,  
@TransactionDate datetime, 
@FirstName nvarchar(25), 
@MiddleName nvarchar(25), 
@LastName nvarchar(25), 
@DateOfBirth datetime, 
@Occupation nvarchar(50), 
@BusinessName nvarchar(50), 
@TypeOfID nvarchar(25), 
@IDNumber nvarchar(25), 
@Apartment nvarchar(15), 
@Address nvarchar(150), 
@City nvarchar(15), 
@ProvState nvarchar(20), 
@PostalZip nvarchar(10), 
@LCTIDNumber nvarchar(25)
)
as
begin
	IF EXISTS (SELECT * FROM LCTMain WHERE SubjectID=@SubjectID AND IncidentID=@IncidentID )
	BEGIN 
		DELETE FROM LCTMain WHERE SubjectID=@SubjectID AND IncidentID=@IncidentID
		INSERT INTO LCTMain ( SubjectID, IncidentID, TransactionDate, FirstName, MiddleName,
	     LastName, DateOfBirth, Occupation, BusinessName, TypeOfID, IDNumber,Apartment,
		 Address, City, ProvState, PostalZip, LCTIDNumber) VALUES
		 (@SubjectID, @IncidentID, @TransactionDate, @FirstName, @MiddleName,
	     @LastName, @DateOfBirth, @Occupation, @BusinessName, @TypeOfID, @IDNumber,
	 	 @Apartment, @Address, @City, @ProvState, @PostalZip, @LCTIDNumber)
	   SELECT @@RowCount AS RESULT 
	END
	ELSE
	BEGIN
	   INSERT INTO LCTMain ( SubjectID, IncidentID, TransactionDate, FirstName, MiddleName,
	    LastName, DateOfBirth, Occupation, BusinessName, TypeOfID, IDNumber,Apartment,
		Address, City, ProvState, PostalZip, LCTIDNumber) VALUES
		(@SubjectID, @IncidentID, @TransactionDate, @FirstName, @MiddleName,
	    @LastName, @DateOfBirth, @Occupation, @BusinessName, @TypeOfID, @IDNumber,
		@Apartment, @Address, @City, @ProvState, @PostalZip, @LCTIDNumber)
	   SELECT @@RowCount AS RESULT 
	END
END

GO
/****** Object:  StoredProcedure [dbo].[LCTIdentification_ByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LCTIdentification_ByID]
(
@SubjectID int,
@IncidentID int
)
as
begin
if exists(SELECT FirstName, MiddleName,LastName, DateOfBirth, Apartment, Address, City,
	ProvState, PostalZip, MiddleName,TransactionDate, Occupation, BusinessName,
	TypeOfID, IDNumber, LCTIDNumber FROM LCTMain 
	WHERE SubjectID = @SubjectID AND IncidentID = @IncidentID)
	begin
		SELECT FirstName, LastName, DateOfBirth, Apartment, Address, City,
			ProvState, PostalZip, MiddleName,TransactionDate, Occupation, BusinessName,
			TypeOfID, IDNumber, LCTIDNumber,LCTID,EmployeeName, EmployeeTitle, EmployeeGPEB,
			CashierName, CashierTitle, CashierGPEB, Notes,
			'' As IDtype1,'' As IDNumber1, '' As IDDefault1,'' As IDType2,
			'' As IDNumber2, '' As IDDefault2, '' As IDType3, '' As IDNumber3, 
			'' As IDDefault3
			 FROM LCTMain 
		WHERE SubjectID = @SubjectID AND IncidentID = @IncidentID
	end
else
	begin
		SELECT Subjects.FirstName, Subjects.MiddleName,Subjects.LastName, Subjects.DateOfBirth,SubjectAddress.Apartment,
			SubjectAddress.Address, SubjectAddress.City,SubjectAddress.ProvState, 
			SubjectAddress.PostalZip,Subjects.MiddleName,
			getdate() as TransactionDate, '' as TypeOfID, '' as IDNumber,
			'' As EmployeeName, '' As EmployeeTitle, '' As EmployeeGPEB,
			'' As CashierName, '' As CashierTitle, '' As CashierGPEB, '' As Notes,
			SI.Occupation, SI.BusinessName, SI.IDType1, SI.IDNumber1, SI.IDDefault1,
			SI.IDType2, SI.IDNumber2, SI.IDDefault2, SI.IDType3, SI.IDNumber3, SI.IDDefault3,
			SI.LCTID as LCTIDNumber FROM SubjectAddress  
			LEFT JOIN SubjectIdentification as SI ON SI.SubjectID=SubjectAddress.SubjectID
			left JOIN Subjects ON SubjectAddress.SubjectID = Subjects.SubjectID 
			left JOIN LCTMain ON LCTMain.SubjectID = Subjects.SubjectID 

			GROUP BY Subjects.FirstName, Subjects.LastName, Subjects.DateOfBirth,
			SubjectAddress.Apartment, SubjectAddress.Address, SubjectAddress.City,
			SubjectAddress.ProvState, SubjectAddress.PostalZip, Subjects.MiddleName, 
			SubjectAddress.ModifiedDate, SubjectAddress.SubjectID ,
			SI.Occupation, SI.BusinessName, SI.IDType1, SI.IDNumber1, SI.IDDefault1,
			SI.IDType2, SI.IDNumber2, SI.IDDefault2, SI.IDType3, SI.IDNumber3, SI.IDDefault3,
			SI.LCTID		
			HAVING SubjectAddress.ModifiedDate = (SELECT Max(SubjectAddress.ModifiedDate)
			FROM SubjectAddress WHERE SubjectAddress.SubjectID = @SubjectID) 
			AND SubjectAddress.SubjectID = @SubjectID
	end
end

GO
/****** Object:  StoredProcedure [dbo].[LCTNotes_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTNotes_AddEdit]
(
@SubjectID int,
@IncidentID int,
@Notes ntext
)
as
begin
	IF EXISTS (SELECT * FROM LCTMain WHERE SubjectID=@SubjectID AND IncidentID=@IncidentID )
	BEGIN 
	   Update LCTMain set Notes=@Notes WHERE SubjectID=@SubjectID AND IncidentID=@IncidentID
	   SELECT @@RowCount AS RESULT 
	END
END

GO
/****** Object:  StoredProcedure [dbo].[LCTPitTransactions_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTPitTransactions_Delete]
(
@ID int 
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	 
		Delete from LCTPitTransactions where ID=@ID 
		
		select @@IDENTITY  
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[LCTPitTransactions_GeneralReport]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTPitTransactions_GeneralReport]
(
@ID int,
@ReportID int, 
@Pit nvarchar(50), 
@Game nvarchar(50), 
@Amount float, 
@BuyInType nvarchar(50), 
@BuyInTime nvarchar(15)
)
AS
Begin
  Begin Try                      
   Begin Transaction 
	if(@ID>0)
	Begin
		Update GenReportLCTPitTransactions set
		Pit=@Pit, 
		Game=@Game, 
		Amount=@Amount, 
		BuyInType=@BuyInType, 
		BuyInTime=@BuyInTime
		where ID=@ID
		
		select @@RowCount AS Result
	End
	else
	Begin
		Insert Into GenReportLCTPitTransactions
		(ReportID, Pit, Game, Amount, BuyInType, BuyInTime)
		values(@ReportID, @Pit, @Game, @Amount, @BuyInType, @BuyInTime)
		
		select @@IDENTITY AS Result
	End
   
   
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End


GO
/****** Object:  StoredProcedure [dbo].[LCTPitTransactions_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LCTPitTransactions_IU]
(
@ID int,
@SubjectID int, 
@IncidentID int, 
@Pit nvarchar(50), 
@Game nvarchar(50), 
@Amount float, 
@BuyInType nvarchar(50), 
@BuyInTime nvarchar(15),
@BuyInTypePitID int,
@BuyInGameID int
)
AS
Begin
  Begin Try                      
   Begin Transaction 
	if(@ID>0)
	Begin
		Update LCTPitTransactions set
		Pit=@Pit, 
		Game=@Game, 
		Amount=@Amount, 
		BuyInType=@BuyInType, 
		BuyInTime=@BuyInTime,
		BuyInTypePitID = @BuyInTypePitID,
		BuyInGameID = @BuyInGameID
		where ID=@ID
		select @@RowCount 
	End
	else
	Begin
		Insert Into LCTPitTransactions
		(SubjectID, IncidentID, Pit, Game, Amount, BuyInType, BuyInTime,BuyInTypePitID,BuyInGameID)
		values(@SubjectID, @IncidentID, @Pit, @Game, @Amount, @BuyInType, @BuyInTime,@BuyInTypePitID,@BuyInGameID)
		
		select @@IDENTITY
	End

	if exists(Select * from TransactionsMain WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID)
	begin
		update TransactionsMain set SubjectID=@SubjectID, IncidentID=@IncidentID,
		 TotalPit=(select sum(Amount) from LCTPitTransactions WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND BuyInType=1),
		 BuyInMarker=(select sum(Amount) from LCTPitTransactions WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND BuyInType=2)
		WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID
		 SELECT @@RowCount AS RESULT
	end
	else
	begin
		INSERT INTO TransactionsMain ( SubjectID, IncidentID, TotalPit,BuyInMarker)
		VALUES (@SubjectID, @IncidentID, 
		(select sum(Amount) from LCTPitTransactions WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND BuyInType=1), 
		(select sum(Amount) from LCTPitTransactions WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID AND BuyInType=2))
		 SELECT @@IDENTITY AS RESULT
	end
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End

GO
/****** Object:  StoredProcedure [dbo].[LCTPitTransactions_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LCTPitTransactions_LoadById]   
@IncidentID int =0 ,  
@SubjectID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		--select MasterGame.Game as GameName,LCTPitTransactions.*  
		--from LCTPitTransactions 
		--left join MasterGame on MasterGame.ID=LCTPitTransactions.Game
		--where IncidentID = @IncidentID and SubjectID=@SubjectID

		select MasterBuyInGame.Game as GameName,MasterBuyInPitType.BuyInPitType,LCTPitTransactions.*  
		from LCTPitTransactions 
		left join MasterBuyInGame on MasterBuyInGame.ID=LCTPitTransactions.BuyInGameID
		left join MasterBuyInPitType on MasterBuyInPitType.ID=LCTPitTransactions.BuyInTypePitID
		where IncidentID = @IncidentID and SubjectID=@SubjectID

		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[LCTSubjectTotals_Add]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[LCTSubjectTotals_Add]
(
@SubjectID int,
@IncidentID int,
@TotalPit float,
@TotalExchange float, 
@TotalCashOut float, 
@BuyInMarker float, 
@CashOutMarker float
)
as
begin
	if exists(Select * from TransactionsMain WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID)
	begin
		DELETE FROM TransactionsMain WHERE SubjectID = @SubjectID AND IncidentID=@IncidentID
		INSERT INTO TransactionsMain ( SubjectID, IncidentID, TotalPit,
		 TotalExchange, TotalCashOut, BuyInMarker, CashOutMarker)
		VALUES (@SubjectID, @IncidentID, @TotalPit,
		 @TotalExchange, @TotalCashOut, @BuyInMarker, @CashOutMarker)
		 SELECT @@IDENTITY AS RESULT
	end
	else
	begin
		INSERT INTO TransactionsMain ( SubjectID, IncidentID, TotalPit,
		 TotalExchange, TotalCashOut, BuyInMarker, CashOutMarker)
		VALUES (@SubjectID, @IncidentID, @TotalPit,
		 @TotalExchange, @TotalCashOut, @BuyInMarker, @CashOutMarker)
		 SELECT @@IDENTITY AS RESULT
	end
end
GO
/****** Object:  StoredProcedure [dbo].[LCTTotals_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LCTTotals_Load]
(
@SubjectID int=0,
@StartDate date=Null,
@EndDate date=NULL
)
as
	Declare @SQL nvarchar(max)         
	Declare @Where varchar(max) 
	Declare @Having varchar(max) 
	set @Having=''
	set @Where ='where 1=1 '
begin
	if ((@StartDate <>'' or @StartDate IS NOT NULL) AND (@EndDate <>'' or @EndDate IS NOT NULL))        
		set @Having=' AND SubjectID ='+convert(varchar,@SubjectID,101)+' AND Incidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
	else if ((@StartDate <>'' or @StartDate IS NOT NULL) AND (@EndDate ='' or @EndDate IS NULL))        
		set @Having=' AND SubjectID ='+convert(varchar,@SubjectID,101)+' AND Incidents.IncidentDate <= '''+convert(varchar,@StartDate,101)+''''               
	else if ((@StartDate ='' or @StartDate IS NULL) AND (@EndDate <>'' or @EndDate IS NOT NULL))     
		set @Having=' AND SubjectID ='+convert(varchar,@SubjectID,101)+' AND Incidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''
	else if ((@StartDate ='' or @StartDate IS NULL) AND (@EndDate ='' or @EndDate IS NULL))   
		set @Having=' AND SubjectID ='+convert(varchar,@SubjectID,101)+''

	set @Where=@Where+@Having
	set @SQL='SELECT Incidents.IncidentID, Incidents.IncidentNumber, Incidents.IncidentDate,
	 LCTCashOuts.Amount as Amount, ''Cash Out'' AS TransactionType FROM Incidents
	 INNER JOIN LCTCashOuts ON Incidents.IncidentID = LCTCashOuts.IncidentID 
	 '+ @Where+' 
	 UNION SELECT Incidents.IncidentID, Incidents.IncidentNumber, Incidents.IncidentDate, 
	 LCTPitTransactions.Amount AS Amount, ''Buy In'' AS TransactionType FROM Incidents 
	 INNER JOIN LCTPitTransactions ON Incidents.IncidentID = LCTPitTransactions.IncidentID 
	 '+ @Where+'
	 UNION SELECT Incidents.IncidentID, Incidents.IncidentNumber, Incidents.IncidentDate, 
	 LCTCashCall.Amount AS Amount, ''Cash Call'' AS TransactionType FROM Incidents 
	 INNER JOIN LCTCashCall ON Incidents.IncidentID = LCTCashCall.IncidentID 
	 '+ @Where+' ;
	  SELECT Sum(LCTPitTransactions.Amount) AS BuyInCash,
	(SELECT Sum(LCTPitTransactions.Amount) 
	FROM Incidents, LCTPitTransactions 
	WHERE Incidents.IncidentID = LCTPitTransactions.IncidentID AND LCTPitTransactions.BuyInType = ''2''
	'+@Having+') As BuyInMarker,
	(SELECT Sum(LCTCashOuts.Amount) FROM Incidents, LCTCashOuts 
	WHERE Incidents.IncidentID = LCTCashOuts.IncidentID AND LCTCashOuts.PaymentType <> ''2''
	'+@Having+') As CashOutCash,
	(SELECT Sum(LCTCashOuts.Amount) FROM Incidents, LCTCashOuts 
	WHERE Incidents.IncidentID = LCTCashOuts.IncidentID AND LCTCashOuts.PaymentType = ''2''
	'+@Having+') As CashOutMarker,
	(SELECT Sum(LCTCashCall.Amount) FROM Incidents, LCTCashCall 
	WHERE Incidents.IncidentID = LCTCashCall.IncidentID '+@Having+') As CashCall,
	(SELECT Sum(LCTForeignExchange.Amount)FROM Incidents, LCTForeignExchange
	 WHERE Incidents.IncidentID = LCTForeignExchange.IncidentID '+@Having+')  AS ForeignExchange 
	FROM Incidents, LCTPitTransactions 
	WHERE Incidents.IncidentID = LCTPitTransactions.IncidentID AND LCTPitTransactions.BuyInType = ''1''
	'+@Having+''

	--print(@sql)
  execute(@sql)
end

GO
/****** Object:  StoredProcedure [dbo].[LCTTotalsSubject_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[LCTTotalsSubject_Load]
(
@SubjectID int,
@IncidentID int
)
as
begin
	SELECT TotalPit, TotalExchange, TotalCashOut, BuyInMarker, CashOutMarker 
		FROM TransactionsMain WHERE SubjectID = @SubjectID
		AND IncidentID=@IncidentID
end
GO
/****** Object:  StoredProcedure [dbo].[LicensedCustomers_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[LicensedCustomers_IU]    
(    
@Id int=0,    
@FirstName nvarchar(50)=null,    
@LastName nvarchar(50)=null,    
@Roles nvarchar(max)=null,    
@Email nvarchar(500)=null,    
@Password nvarchar(50)=null,    
@Phone nvarchar(25)=null,    
@Country int=0,    
@State int=0,    
@City nvarchar(50)=null,    
@Zip nvarchar(10)=null,    
@LicenseExpiryDate datetime=null,    
@UserName nvarchar(50)=null,    
@CustomerLogo nvarchar(max)=null    
)    
AS    
BEGIN    
 If(@Id>0)    
 begin    
			  update Users set    
			  FirstName=@FirstName,    
			  LastName=@LastName,    
			  UserName=@UserName,
			  Password=@Password,
			  UnitID=1,
			  Email=@Email where Id=@Id  and IsAdmin=1   
			  select @@RowCount   
			 update LicensedCustomers set  
			  Roles=@Roles,      
			   Phone=@Phone,    
			  Country=@Country,    
			  State=@State,    
			  City=@City,    
			  Zip=@Zip,      
			  UpdatedDate=getdate(),    
			  LicenseExpiryDate=@LicenseExpiryDate,    
			  CustomerLogo=@CustomerLogo where UserID=@Id  
			  select @@RowCount   
 end    
 else    
 begin    
		  insert into Users(FirstName,LastName,Email,Password,UserName,IsAdmin,UnitID) values (@FirstName,@LastName,@Email,@Password,@UserName,1,1)    
		  select @Id=@@Identity    
		 insert into LicensedCustomers(Roles,Phone,Country,State,City, Zip,CreatedDate,UpdatedDate,LicenseExpiryDate,CustomerLogo,UserID) values (@Roles,@Phone,@Country,@State,@City,@Zip,    
		  getdate(),    
		  getdate(),    
		  @LicenseExpiryDate,    
		  @CustomerLogo,@Id )  
		  select @@Identity  

  
 end    
END
GO
/****** Object:  StoredProcedure [dbo].[LicensedCustomers_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[LicensedCustomers_LoadAll]
AS
BEGIN
	Select * from LicensedCustomers
END
GO
/****** Object:  StoredProcedure [dbo].[LicensedCustomers_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LicensedCustomers_LoadById]      
@Id int=0      
AS      
BEGIN   

SElect top 1 *,(SELECT Stuff(  
    (  
    SELECT ',' + p1.MenuName  
    FROM ManageMenus p1  
    where p1.Id in (Select * from CSVToTable(lc.Roles))  
    FOR XML PATH('')  
    ), 1, 1, '')) AS MenuNames from Users u
join LicensedCustomers lc  on
u.ID = lc.UserID
where u.IsAdmin=1
  
      
END
GO
/****** Object:  StoredProcedure [dbo].[LicenseExpiry_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LicenseExpiry_print] --'2016-07-20 00:00:00.000','2016-08-31 00:00:00.000','FirstName'
(
@StartDate datetime,
@EndDate datetime,
@SortOrder varchar(max)
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
	if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' AND EmployeeLicense.LicenseExpirationDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+'AND EmployeeLicense.LicenseExpirationDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' AND EmployeeLicense.LicenseExpirationDate <= '''+convert(varchar,@EndDate,101)+'''' 

	set @SQL='SELECT Employees.FirstName,Employees.MiddleName, Employees.LastName, 
	EmployeeLicense.LicenseExpirationDate, Employees.StaffPosition,
	EmployeeLicense.DateOfHire, EmployeeLicense.TerminationDate,
	EmployeeLicense.Department, EmployeeLicense.LicenseType,
	EmployeeLicense.LicenseStatus FROM EmployeeLicense 
	INNER JOIN Employees ON EmployeeLicense.EmployeeID = Employees.EmployeeID
	 '+ @Where+'
	 Order By '+ @SortOrder +''

		--print (@sql)
	execute(@SQL)
end

GO
/****** Object:  StoredProcedure [dbo].[LicenseStatus_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[LicenseStatus_Delete](
@id int
)  
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
		Delete FROM MasterLicenseStatus where id=@id
		select @@RowCount as Result
	End   
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[LicenseStatus_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LicenseStatus_IU]  
(  
@id int,  
@LicenseStatus nvarchar(200)  
)  
AS                 
BEGIN       
  Begin Try                
   Begin Transaction     
    Begin     
  if exists(SELECT *  FROM MasterLicenseStatus  where id=@id)  
   begin  
   update MasterLicenseStatus set LicenseStatus=@LicenseStatus where id=@id  
   select @@RowCount as RESULT  
   end  
  ELSE  
  begin  
   insert into MasterLicenseStatus(LicenseStatus) values(@LicenseStatus)  
   Select @@Identity as Result
  end  
 End     
   COMMIT TRANSACTION     
  End try        
 Begin Catch             
  IF @@TRANCOUNT >0             
          Select ERROR_MESSAGE()    
    Rollback Transaction      
    EXECUTE [uspLogError]               
 End Catch                
END  
GO
/****** Object:  StoredProcedure [dbo].[LicenseType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[LicenseType_Delete]
@id int
as
begin
	Delete from MasterLicenseType where id=@id  
	select @@Rowcount as RESULT  
end
GO
/****** Object:  StoredProcedure [dbo].[LicenseType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[LicenseType_IU](  
@id int=0,  
@LicenseType nvarchar(100)=Null  
)  
as  
begin  
 if exists(Select * from MasterLicenseType where id=@id)  
 begin  
  Update MasterLicenseType set LicenseType=@LicenseType where id=@id  
  select @@Rowcount as RESULT  
 end  
 else  
 begin   
  insert into MasterLicenseType(LicenseType) values(@LicenseType)  
  select @@Identity as RESULT  
 end  
end
GO
/****** Object:  StoredProcedure [dbo].[LoadAuditQuestionsByAuditID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoadAuditQuestionsByAuditID] --1,5
(
@AuditID int =0
)
AS
BEGIN
if(@AuditID>0)
begin
	Select aq.QuestionID,aq.Question,aq.QuestionType,au.AuditType AS [Audit] 
	from AuditsQuestions aq
	INNER JOIN AuditQuestions AS au ON aq.AuditID = au.QuestionID
	where aq.AuditID = @AuditID
	ORDER BY QuestionID;
end

END
GO
/****** Object:  StoredProcedure [dbo].[LoadDataTablesTree_ReportDesign]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoadDataTablesTree_ReportDesign]
@GroupName varchar(max)
as
begin
	SELECT DisplayName, TableName FROM ReportTables WHERE GroupName = @GroupName ORDER BY DisplayName
	SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'AccessCards'
end
GO
/****** Object:  StoredProcedure [dbo].[LoadReportNames_ReportDesigner]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[LoadReportNames_ReportDesigner]
AS
BEGIN
SELECT ReportID,ReportName FROM Reports ORDER BY ReportName
END
GO
/****** Object:  StoredProcedure [dbo].[LoadTableColumnsTreeNode_ReportDesign]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[LoadTableColumnsTreeNode_ReportDesign]
@TableName varchar(max)
as
begin

	
SELECT column_name, data_type FROM information_schema.columns WHERE table_name = @TableName
end
GO
/****** Object:  StoredProcedure [dbo].[Location_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Location_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from Location where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[Location_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[Location_IU](        
@Id int,        
@Location nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM Location  where Id=@Id)          
   begin          
   update Location set Location=@Location where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into Location(Location) values(@Location)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[Location_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Location_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from Location        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[LocationCount_Graph]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[LocationCount_Graph]
(
@ReportType nvarchar(100),
@StartDate datetime,
@EndDate datetime
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if(@ReportType='Subject')
	begin
		if (@StartDate <>'' AND @EndDate <>'')        
				set @Where=@Where+' and Incidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
			  if (@StartDate  <>'' AND @EndDate  ='')        
				  set @Where=@Where+' and Incidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
			  if (@StartDate ='' AND @EndDate <>'')     
			  set @Where=@Where+' and Incidents.IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 
	  
				set @SQL='SELECT TOP 15 Location, COUNT(Location) as results FROM Incidents '+  @Where +' GROUP BY Location ORDER BY 2 DESC'
				
	end
else
	begin
	if (@StartDate <>'' AND @EndDate <>'')        
			set @Where=@Where+' and EmployeeIncidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
		  if (@StartDate  <>'' AND @EndDate  ='')        
			  set @Where=@Where+' and EmployeeIncidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
		  if (@StartDate ='' AND @EndDate <>'')     
		  set @Where=@Where+' and EmployeeIncidents.IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 		  	
		 set @SQL='SELECT TOP 15 Location, COUNT(Location) as results FROM EmployeeIncidents '+  @Where +' GROUP BY Location ORDER BY 2 DESC'
		
	end
exec(@sql)
end








GO
/****** Object:  StoredProcedure [dbo].[Login_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Login_Load]    
(    
@UserName nvarchar(100) = null,    
@Password nvarchar(100) = null,  
@RoleType int=0    
)    
AS     
BEGIN    
 declare @temp int=0    
 Begin Try    
  Begin Transaction   
 
  if(Exists (select * from Users where UserName=@UserName and Password=@Password))    
    Begin     
       set @temp = (SELECT Id FROM Users where UserName=@UserName And Password=@Password )    
         
     if(@temp > 0)    
      Begin    
      select * from Users ui    
      left join UserRoles ur on ui.ID = ur.UserID    
	  left join UserInRole uir on uir.UserId=ui.ID
      where ui.ID = @temp    
      End    
     else    
      select 0    
    End    
   else    
    Begin    
     select -10    
    End    
  COMMIT TRANSACTION            
 End try    
 Begin Catch    
  IF @@TRANCOUNT >0                  
   rollback Transaction    
   EXECUTE [uspLogError]     
 End Catch    
END


GO
/****** Object:  StoredProcedure [dbo].[LU_AgeSearch_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[LU_AgeSearch_Load]    
AS                   
BEGIN           
  BEGIN TRY                    
   BEGIN TRANSACTION         
    BEGIN         
   SELECT AgeRange FROM LU_AgeSearch ORDER BY ID   
   SELECT @@RowCount AS RESULT    
  END         
   COMMIT TRANSACTION         
  END TRY            
 BEGIN CATCH                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  


GO
/****** Object:  StoredProcedure [dbo].[MasterAddressType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[MasterAddressType_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterAddressType
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[MasterBuyInGame_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterBuyInGame_Delete](      
@Id int      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Delete from MasterBuyInGame where Id=@Id       
   Select @@RowCount as RESULT       
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterBuyInGame_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
Create Procedure [dbo].[MasterBuyInGame_IU](      
@Id int,      
@Game nvarchar(200)      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterBuyInGame  where Id=@Id)        
   begin        
   update MasterBuyInGame set Game=@Game where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterBuyInGame(Game) values(@Game)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     


GO
/****** Object:  StoredProcedure [dbo].[MasterBuyInGame_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterBuyInGame_Load]      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   SELECT * from MasterBuyInGame      
   SELECT @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     


GO
/****** Object:  StoredProcedure [dbo].[MasterBuyInPitType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterBuyInPitType_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from MasterBuyInPitType where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 

GO
/****** Object:  StoredProcedure [dbo].[MasterBuyInPitType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

   
Create Procedure [dbo].[MasterBuyInPitType_IU](        
@Id int,        
@BuyInPitType nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM MasterBuyInPitType  where Id=@Id)          
   begin          
   update MasterBuyInPitType set BuyInPitType=@BuyInPitType where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into MasterBuyInPitType(BuyInPitType) values(@BuyInPitType)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       


GO
/****** Object:  StoredProcedure [dbo].[MasterBuyInPitType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[MasterBuyInPitType_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from MasterBuyInPitType        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       


GO
/****** Object:  StoredProcedure [dbo].[MasterCashoutTableNumber_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterCashoutTableNumber_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from MasterCashoutTableNumber where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 

GO
/****** Object:  StoredProcedure [dbo].[MasterCashoutTableNumber_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

   
Create Procedure [dbo].[MasterCashoutTableNumber_IU](        
@Id int,        
@TableNumber nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM MasterCashoutTableNumber  where Id=@Id)          
   begin          
   update MasterCashoutTableNumber set TableNumber=@TableNumber where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into MasterCashoutTableNumber(TableNumber) values(@TableNumber)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       


GO
/****** Object:  StoredProcedure [dbo].[MasterCashoutTableNumber_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[MasterCashoutTableNumber_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from MasterCashoutTableNumber        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       


GO
/****** Object:  StoredProcedure [dbo].[MasterDepartmentType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[MasterDepartmentType_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterDepartmentType
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[MasterDisputeType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterDisputeType_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from MasterDisputeType where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[MasterDisputeType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
Create Procedure [dbo].[MasterDisputeType_IU](        
@Id int,        
@DisputeType nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM MasterDisputeType  where Id=@Id)          
   begin          
   update MasterDisputeType set DisputeType=@DisputeType where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into MasterDisputeType(DisputeType) values(@DisputeType)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[MasterDisputeType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterDisputeType_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from MasterDisputeType        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[MasterEyes_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterEyes_Delete](    
@Id int    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Delete from MasterEyes where Id=@Id     
   Select @@RowCount as RESULT     
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
GO
/****** Object:  StoredProcedure [dbo].[MasterEyes_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterEyes_IU](    
@Id int,    
@Eyes nvarchar(200)    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
  if exists(SELECT *  FROM MasterEyes  where Id=@Id)      
   begin      
   update MasterEyes set Eyes=@Eyes where Id=@Id      
   select @@RowCount as RESULT  
   end      
  ELSE      
  begin      
   insert into MasterEyes(Eyes) values(@Eyes)      
   select @@Identity as RESULT    
  end      
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   


GO
/****** Object:  StoredProcedure [dbo].[MasterEyes_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterEyes_Load]    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Select * from MasterEyes    
   Select @@RowCount as RESULT    
  End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  

GO
/****** Object:  StoredProcedure [dbo].[MasterGame_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterGame_Delete](      
@Id int      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Delete from MasterGame where Id=@Id       
   Select @@RowCount as RESULT       
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     
GO
/****** Object:  StoredProcedure [dbo].[MasterGame_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
Create Procedure [dbo].[MasterGame_IU](      
@Id int,      
@Game nvarchar(200)      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterGame  where Id=@Id)        
   begin        
   update MasterGame set Game=@Game where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterGame(Game) values(@Game)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterGame_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterGame_Load]      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterGame      
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterHeightUnit_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[MasterHeightUnit_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterHeightUnit
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[MasterLicenseStatus_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[MasterLicenseStatus_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterLicenseStatus
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[MasterLicenseType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[MasterLicenseType_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterLicenseType
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[MasterNatureofIncident_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[MasterNatureofIncident_Delete](      
@Id int      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Delete from MasterNatureofIncident where Id=@Id       
   Select @@RowCount as RESULT       
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END       
   
GO
/****** Object:  StoredProcedure [dbo].[MasterNatureofIncident_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE Procedure [dbo].[MasterNatureofIncident_IU](      
@Id int,      
@Nature nvarchar(200),
@NatureType int,
@NatureImage nvarchar(50)
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterNatureofIncident  where Id=@Id)        
   begin        
   update MasterNatureofIncident set NatureImage=@NatureImage where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterNatureofIncident(Nature,NatureType,NatureImage) values(@Nature,@NatureType,@NatureImage)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[MasterNatureofIncident_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[MasterNatureofIncident_Load]  
@NatureType int
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterNatureofIncident where NatureType=@NatureType ORDER BY Nature   
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterRace_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterRace_Delete](    
@Id int    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Delete from MasterRace where Id=@Id     
   Select @@RowCount as RESULT     
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  
GO
/****** Object:  StoredProcedure [dbo].[MasterRace_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterRace_IU](    
@Id int,    
@Race nvarchar(200)    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
  if exists(SELECT *  FROM MasterRace  where Id=@Id)      
   begin      
   update MasterRace set Race=@Race where Id=@Id      
   select @@RowCount as RESULT  
   end      
  ELSE      
  begin      
   insert into MasterRace(Race) values(@Race)      
   select @@Identity as RESULT    
  end      
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   


GO
/****** Object:  StoredProcedure [dbo].[MasterRace_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterRace_Load]    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Select * from MasterRace    
   Select @@RowCount as RESULT    
  End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  

GO
/****** Object:  StoredProcedure [dbo].[MasterRole_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterRole_Delete](      
@Id int      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Delete from MasterRole where Id=@Id       
   Select @@RowCount as RESULT       
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     
GO
/****** Object:  StoredProcedure [dbo].[MasterRole_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterRole_IU](      
@Id int,      
@Role nvarchar(200)      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterRole  where Id=@Id)        
   begin        
   update MasterRole set Role=@Role where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterRole(Role) values(@Role)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterRole_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterRole_Load]      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterRole      
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterSex_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterSex_Delete](    
@Id int    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Delete from MasterSex where Id=@Id     
   Select @@RowCount as RESULT     
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  
GO
/****** Object:  StoredProcedure [dbo].[MasterSex_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterSex_IU](    
@Id int,    
@Sex nvarchar(200)    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
  if exists(SELECT *  FROM MasterSex  where Id=@Id)      
   begin      
   update MasterSex set Sex=@Sex where Id=@Id      
   select @@RowCount as RESULT  
   end      
  ELSE      
  begin      
   insert into MasterSex(Sex) values(@Sex)      
   select @@Identity as RESULT    
  end      
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   


GO
/****** Object:  StoredProcedure [dbo].[MasterSex_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterSex_Load]    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Select * from MasterSex    
   Select @@RowCount as RESULT    
  End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  

GO
/****** Object:  StoredProcedure [dbo].[MasterShortDescriptor_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterShortDescriptor_Delete](    
@Id int    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Delete from MasterShortDescriptor where Id=@Id     
   Select @@RowCount as RESULT     
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
GO
/****** Object:  StoredProcedure [dbo].[MasterShortDescriptor_DestilsbyID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterShortDescriptor_DestilsbyID]
 @Id int
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterShortDescriptor where Id=@Id
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 
GO
/****** Object:  StoredProcedure [dbo].[MasterShortDescriptor_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[MasterShortDescriptor_IU](      
@Id int=0,      
@Descriptor nvarchar(200)=null,
@NatureID int=0,
@ProShortDescriptor nvarchar(max)=null      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterShortDescriptor  where Id=@Id)        
   begin        
   update MasterShortDescriptor set Descriptor=@Descriptor,ProShortDescriptor=@ProShortDescriptor where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterShortDescriptor(Descriptor,NatureID) values(@Descriptor,@NatureID)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END  
GO
/****** Object:  StoredProcedure [dbo].[MasterShortDescriptor_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[MasterShortDescriptor_Load]     
 @NatureID int
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterShortDescriptor where NatureID=@NatureID
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END  
GO
/****** Object:  StoredProcedure [dbo].[MasterStatus_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterStatus_Delete](      
@Id int      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Delete from MasterStatus where Id=@Id       
   Select @@RowCount as RESULT       
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     
GO
/****** Object:  StoredProcedure [dbo].[MasterStatus_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[MasterStatus_IU](      
@Id int,      
@Status nvarchar(200)      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterStatus  where Id=@Id)        
   begin        
   update MasterStatus set Status=@Status where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterStatus(Status) values(@Status)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterStatus_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MasterStatus_Load]      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterStatus      
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     

GO
/****** Object:  StoredProcedure [dbo].[MasterTypeID1_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterTypeID1_IU](  
@Id int,  
@TypeIDName nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM MasterTypeID1  where Id=@Id)    
   begin    
   update MasterTypeID1 set Value=@TypeIDName where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into MasterTypeID1(Value) values(@TypeIDName)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[MasterTypeID1_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterTypeID1_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from MasterTypeID1  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[MasterTypeID2_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterTypeID2_IU](  
@Id int,  
@TypeIDName nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM MasterTypeID2  where Id=@Id)    
   begin    
   update MasterTypeID2 set Value=@TypeIDName where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into MasterTypeID2(Value) values(@TypeIDName)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[MasterTypeID2_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterTypeID2_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from MasterTypeID2  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[MasterTypeID3_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterTypeID3_IU](  
@Id int,  
@TypeIDName nvarchar(200)  
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
  if exists(SELECT *  FROM MasterTypeID3  where Id=@Id)    
   begin    
   update MasterTypeID3 set Value=@TypeIDName where Id=@Id    
   select @@RowCount as RESULT
   end    
  ELSE    
  begin    
   insert into MasterTypeID3(Value) values(@TypeIDName)    
   select @@Identity as RESULT  
  end    
 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 


GO
/****** Object:  StoredProcedure [dbo].[MasterTypeID3_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterTypeID3_Load]  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Select * from MasterTypeID3  
	  Select @@RowCount as RESULT  
	 End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[Masterwatch_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  
CREATE Procedure [dbo].[Masterwatch_Delete](    
@Id int    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Delete from Masterwatch where Id=@Id     
   Select @@RowCount as RESULT     
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
GO
/****** Object:  StoredProcedure [dbo].[Masterwatch_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[Masterwatch_IU](    
@Id int,    
@watch nvarchar(200)    
)    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
  if exists(SELECT *  FROM Masterwatch  where Id=@Id)      
   begin      
   update Masterwatch set watch=@watch where Id=@Id      
   select @@RowCount as RESULT  
   end      
  ELSE      
  begin      
   insert into Masterwatch(watch) values(@watch)      
   select @@Identity as RESULT    
  end      
 End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   


GO
/****** Object:  StoredProcedure [dbo].[Masterwatch_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  
CREATE Procedure [dbo].[Masterwatch_Load]    
as                   
BEGIN           
  Begin Try                    
   Begin Transaction         
    Begin         
   Select * from Masterwatch    
   Select @@RowCount as RESULT    
  End         
   COMMIT TRANSACTION         
  End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END   
  

GO
/****** Object:  StoredProcedure [dbo].[MasterWeightUnit_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[MasterWeightUnit_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterWeightUnit
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[MediaCopy_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Procedure [dbo].[MediaCopy_IU] -- '4535','3455','3453','435','4543','3455',7
(  
@MediaNumbers nvarchar(255),  
@MediaLabel nvarchar(100),   
@IncidentNumber nvarchar(50),  
@OriginalsHeldBy nvarchar(50),  
@SentToOther nvarchar(50),  
@OriginalsSaved nvarchar(50),  
@EventID int  
  
)  
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
        
    
 Begin    
  declare @MediaCopyID int  
   SELECT @MediaCopyID=MediaCopyID FROM MediaCopy WHERE EventID = @EventID  
   if(@MediaCopyID > 0)  
   begin  
   DELETE FROM MediaCopySentTo WHERE MediaCopyID=@MediaCopyID  
   DELETE FROM MediaCopySentTo WHERE MediaCopyID=@MediaCopyID  
   select @MediaCopyID  
   
   update MediaCopy set MediaNumbers=@MediaNumbers,MediaLabel=@MediaLabel,IncidentNumber=@IncidentNumber,OriginalsHeldBy=@OriginalsHeldBy,SentToOther=@SentToOther,OriginalsSaved=@OriginalsSaved WHERE MediaCopyID=@MediaCopyID 
   end  
   else  
  begin  
  INSERT INTO MediaCopy (EventID, MediaNumbers, MediaLabel, IncidentNumber, OriginalsHeldBy, SentToOther, OriginalsSaved)   
  values(@EventID, @MediaNumbers, @MediaLabel, @IncidentNumber, @OriginalsHeldBy,@SentToOther,@OriginalsSaved)  
  select @MediaCopyID=@@IDENTITY       
  Insert Into MediaCopySentTo (MediaCopyID, CopySentTo) Values (@MediaCopyID, @SentToOther)  
    
  select @MediaCopyID  
  end    
      
   
 End    
  COMMIT TRANSACTION           
 End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END  
GO
/****** Object:  StoredProcedure [dbo].[MediaCopy_LoadByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  Procedure  [dbo].[MediaCopy_LoadByID] 
(   
	 @EventID int	
 )

 AS
 BEGIN 
    SELECT * FROM MediaCopy WHERE EventID=@EventID
  END
GO
/****** Object:  StoredProcedure [dbo].[Menus_LoadForSiteAdministrator]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[Menus_LoadForSiteAdministrator]      
AS      
BEGIN      
Declare @RoleId nvarchar(max)      
      
select  @RoleId=Roles from LicensedCustomers  lc    
join Users u on    
 lc.UserID = u.ID  where IsAdmin=1    
    
 Select ROW_NUMBER() 
        OVER (ORDER BY Id) AS Row,Id,MenuName,ParentId,0 as PermissionType from ManageMenus       
 where Id in(SElect * from CSVTotable(@RoleId      
 ))  or   ParentId in(SElect * from CSVTotable(@RoleId      
 ))  
END
GO
/****** Object:  StoredProcedure [dbo].[Message_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Message_Delete]
(
	@MessageID int
)
as
begin
	Delete FROM Messages WHERE MessageID=@MessageID;
	DELETE FROM MessageRecipients WHERE MessageID=@MessageID
	SELECT @@ROWCOUNT AS RESULT
END
GO
/****** Object:  StoredProcedure [dbo].[Message_Sent]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Message_Sent] --0,'dfsdfdsf','dsfsdfsdfsdfsdfsdf','2016-08-10 11:58:07.000','1','1','0','1'
(
@MessageID int,
@MessageText ntext,
@Description nvarchar(150) ,
@DateSent datetime,
@UserID nvarchar(25),
@SenderID nvarchar(25),
@Draft bit,
@SentToSelf bit
)
AS
BEGIN
 declare @value int;
 IF EXISTS (SELECT * FROM Messages WHERE MessageID=@MessageID)
  Begin
  UPDATE Messages SET MessageText=@MessageText,Description=@Description,DateSent=@DateSent
      WHERE	MessageID=@MessageID;
   Update MessageRecipients set Draft=@Draft,UserID=@UserID,SenderID=@SenderID,SentToSelf=@SentToSelf where MessageID=@MessageID;
   Select @@Identity AS Result
  end
 else
  begin
   INSERT INTO [Messages]([MessageText],[Description],[DateSent]) 
    VALUES (@MessageText,@Description,@DateSent);
    SELECT @value= @@Identity;
    if(@value > 0)
    begin
     INSERT INTO MessageRecipients (UserID, SenderID, MessageID, SentToSelf, Draft) 
      VALUES (@UserID,@SenderID,@value,@SentToSelf,@Draft)
    end
	Select @@Identity AS Result
  END
END
GO
/****** Object:  StoredProcedure [dbo].[MessageGroup_DeleteByUserID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[MessageGroup_DeleteByUserID]
(
 @U_ID int
)
as
begin
   DELETE FROM MessageGroups WHERE U_ID=@U_ID
   Select @@ROWCOUNT as Result
end
GO
/****** Object:  StoredProcedure [dbo].[MessageGroups_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[MessageGroups_AddEdit] --'22','nextolive'
  (
   @GroupName nvarchar(50),
   @GroupNameOld nvarchar(50)
  )
  as
  begin
  if exists (Select * from MessageGroups where GroupName=@GroupNameOld)
  begin
     update MessageGroups set GroupName=@GroupName where GroupName=@GroupNameOld
	 select @@rowcount as result
  end
  else
  begin
       INSERT INTO MessageGroups(GroupName,UserID) VALUES (@GroupName,'')
	   select @@rowcount as result
  end
  end
GO
/****** Object:  StoredProcedure [dbo].[MessageGroups_DeleteByGroup]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[MessageGroups_DeleteByGroup] 
  ( 
    @GroupName nvarchar(50)
  )
  AS
  BEGIN
  declare @sql varchar(max)
  set @sql='DELETE FROM MessageGroups WHERE GroupName='''+@GroupName+''' Select  @@ROWCOUNT  as result'
   exec(@sql)
  END
GO
/****** Object:  StoredProcedure [dbo].[MessageGroups_DeleteByGroupName]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MessageGroups_DeleteByGroupName]  --'1,1','next olive'
  (
  @U_ID nvarchar(max),
  @GroupName nvarchar(50)
  )
  AS
  BEGIN
  declare @sql varchar(max)
  set @sql='DELETE FROM MessageGroups WHERE GroupName='''+@GroupName+''' and U_ID in ('+@U_ID+') Select  @@ROWCOUNT  as result'
  --print @sql
  exec(@sql)
  END
GO
/****** Object:  StoredProcedure [dbo].[MessageGroups_Insert]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MessageGroups_Insert]
 (
 @GroupName nvarchar(50),
 @UserID nvarchar(20),
 @U_ID int

 )
 as
  begin
  INSERT INTO MessageGroups (GroupName, UserID,U_ID) Values(@GroupName,@UserID,@U_ID)
  Select  @@identity as result

  End


GO
/****** Object:  StoredProcedure [dbo].[MessageGroups_LoadByGroupName]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MessageGroups_LoadByGroupName]
(
 @GroupName nvarchar(50)
)
AS
BEGIN
	SELECT U.LastName, U.FirstName, U.ID,  isnull(U.LastName,'')+', '+isnull(U.LastName,'')+'-'+ ISNULL(U.FirstName,'') as FullName,MessageGroups.GroupName
	 FROM MessageGroups INNER JOIN Users U ON MessageGroups.U_ID = U.ID WHERE MessageGroups.GroupName =@GroupName
END
GO
/****** Object:  StoredProcedure [dbo].[MessageGroups_LoadDistinctGroupName]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MessageGroups_LoadDistinctGroupName]
as
begin
SELECT Distinct GroupName FROM MessageGroups ORDER BY GroupName
end

GO
/****** Object:  StoredProcedure [dbo].[MessageRecipients_LoadByMessageID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[MessageRecipients_LoadByMessageID]
(
@MessageID int
)
as 
begin
	SELECT Users.LastName, Users.FirstName FROM MessageRecipients INNER JOIN Users ON MessageRecipients.UserID = Users.ID WHERE MessageRecipients.MessageID =@MessageID AND ((MessageRecipients.SenderID <> MessageRecipients.UserID) OR (MessageRecipients.SentToSelf = 1 AND MessageRecipients.SenderID = MessageRecipients.UserID)) ORDER BY Users.LastName, Users.FirstName
end
GO
/****** Object:  StoredProcedure [dbo].[Messages_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[Messages_AddEdit]
 (
	@MessageID int,
	@MessageText ntext,
	@Description nvarchar(150) ,
	@DateSent datetime
	)
	as
	BEGIN

	IF EXISTS (SELECT * FROM  [Messages] WHERE [MessageID]=@MessageID)
	BEGIN
	UPDATE [Messages] SET 
	  [MessageText]=@MessageText,[Description]=@Description,[DateSent]=@DateSent
      WHERE	[MessageID]=@MessageID 
	  SELECT @@ROWCOUNT AS Result
	END
	ELSE
	BEGIN
		INSERT INTO [Messages]([MessageText],[Description],[DateSent]) 
	    VALUES (@MessageText,@Description,@DateSent)
	    SELECT @@Identity AS Result
	END

	END

	
GO
/****** Object:  StoredProcedure [dbo].[Messages_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Messages_LoadById]
(
@MessageID int
)
as
begin
	SELECT * FROM Messages WHERE MessageID=@MessageID
end
GO
/****** Object:  StoredProcedure [dbo].[Messages_Received]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Messages_Received]
(
@UserID nvarchar(50)
)
as
begin
	SELECT MessageRecipients.SenderID, MessageRecipients.Draft, MessageRecipients.MessageID,
		Messages.DateSent, Users.LastName, Users.FirstName, Messages.Description,Messages.MessageText, 
		MessageRecipients.DateRead, MessageRecipients.SentToSelf FROM MessageRecipients
	INNER JOIN Messages ON MessageRecipients.MessageID = Messages.MessageID 
	INNER JOIN Users ON MessageRecipients.SenderID = Users.ID 
	WHERE MessageRecipients.SenderID = @UserID AND (MessageRecipients.DateDeleted IS NULL) ORDER BY MessageRecipients.MessageID
end
GO
/****** Object:  StoredProcedure [dbo].[MoneyRecovered_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MoneyRecovered_print]
(
@StartDate datetime,
@EndDate datetime,
@ShortLocation nvarchar(100)
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' Disputes.RecoveredMoney = 1 AND IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+' Disputes.RecoveredMoney = 1 AND IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' Disputes.RecoveredMoney = 1 AND IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 

	  set @SQL='SELECT Incidents.ShortDescriptor, Incidents.Location, 
		COUNT(*) AS IncidentCount, SUM(Disputes.Amount) AS SumAmount 
		FROM Disputes INNER JOIN Incidents ON Disputes.IncidentID = Incidents.IncidentID
		'+ @Where+' 
		GROUP BY '+@ShortLocation+'  
		ORDER BY '+@ShortLocation+''
execute(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[MstTypeOfBan_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[MstTypeOfBan_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from MstTypeOfBan where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[MstTypeOfBan_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[MstTypeOfBan_IU](        
@Id int,        
@TypeOfBan nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM MstTypeOfBan  where Id=@Id)          
   begin          
   update MstTypeOfBan set TypeOfBan=@TypeOfBan where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into MstTypeOfBan(TypeOfBan) values(@TypeOfBan)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[MstTypeOfBan_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MstTypeOfBan_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from MSTTypeOfBan        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[NatureCodes_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[NatureCodes_Delete](            
@Id int            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Delete from NatureCodes where Id=@Id             
   Select @@RowCount as RESULT             
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 
GO
/****** Object:  StoredProcedure [dbo].[NatureCodes_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Procedure [dbo].[NatureCodes_IU](  
@Id int,            
@Code nvarchar(20),
@Description nvarchar(50),
@DefaultAction nvarchar(20),
@DefaultCamera nvarchar(20)
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
  if exists(SELECT *  FROM NatureCodes  where Id=@Id)              
   begin              
   update NatureCodes set Code=@Code,Description=@Description,DefaultAction=@DefaultAction,DefaultCamera=@DefaultCamera where Id=@Id
   select @@RowCount as RESULT          
   end              
  ELSE              
  begin              
   insert into NatureCodes(Code,Description,DefaultAction,DefaultCamera) values(@Code,@Description,@DefaultAction,@DefaultCamera)              
   select @@Identity as RESULT            
  end              
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[NatureCodes_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[NatureCodes_LoadAll]     
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
  Select Id,Code, Description,DefaultAction,DefaultCamera From NatureCodes Order By Code  
 End   
    
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[NatureCodes_LoadByID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[NatureCodes_LoadByID] 
@Id int
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
  Select * From NatureCodes where Id=@Id  
 End   
    
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[Permissions_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Permissions_IU]
(
@RoleId int=0,
@PermissionTable dbo.PermissionType READONLY
)
AS
BEGIN
	Delete from ManagePermissions where RoleId=@RoleId
	Insert into ManagePermissions
	SELECT @RoleId, MenuId,PermissionType  
	FROM @PermissionTable
	
	select @@Rowcount 
END
GO
/****** Object:  StoredProcedure [dbo].[PicturesVideos_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PicturesVideos_LoadAll]
(
@PictureType nvarchar(50),
@SubFeatureID int=0,
@SubFeaturesid int=0
)   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   Begin 
		if(@PictureType='Media')
			begin
				select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=@SubFeatureID
			end
		else if(@PictureType='Vehicles')
			begin
				select * from PicturesVideos where PictureType in ('Subject','Media') and SubFeatureID=@SubFeatureID
				UNION All
				select * from PicturesVideos where PictureType in ('Subject','Media') and SubFeatureID=0
			end
		else if(@PictureType='Features')
			begin
				select * from PicturesVideos where PictureType in ('Subject','Media') and SubFeatureID=@SubFeatureID
				UNION All
				select * from PicturesVideos where PictureType in ('Subject','Media') and SubFeatureID=0
			end
		else
			begin
				select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=@SubFeatureID
				UNION All
				select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=0
			end
		--if(@PictureType='Features')
		--begin
		--	select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=@SubFeatureID and SubFeaturesid=@SubFeaturesid
		--	UNION All
		--	select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=0

		--end
		--else
		--	begin
		--		if(@PictureType='Media')
		--			begin
		--				select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=@SubFeatureID
		--			end
		--		else
		--			begin
		--				select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=@SubFeatureID
		--				UNION All
		--				select * from PicturesVideos where PictureType=@PictureType and SubFeatureID=0
		--			end
		--	end
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[PictureVideos_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PictureVideos_Delete] 
@MediaID int =0
AS                   
BEGIN         
  Begin Try                  
   Begin Transaction       
		delete from PicturesVideos where mediaID=@MediaID
		select @@rowcount
  COMMIT TRANSACTION       
 End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END
GO
/****** Object:  StoredProcedure [dbo].[PictureVideos_Insert]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PictureVideos_Insert] 
@Assigned int=0 ,    
@MediaExtention nvarchar(50)=null,    
@MediaName nvarchar(50)=null,
@Description nvarchar(75)=null,
@DefaultPic bit='false',  
@EncodeState int =0,      
@PicType int =0,    
@EncodeFaceValues nvarchar(50)=null,    
@FaceValue float =0,    
@FilePath nvarchar(max)=null,
@PictureType nvarchar(50),
@SubFeatureID int=0,
@SubFeaturesid int=0
AS                   
BEGIN         
  Begin Try                  
   Begin Transaction       
     insert into PicturesVideos(Assigned,MediaExtention,MediaName,Description,MediaDateTime,
		DefaultPic,EncodeArray,EncodeState,PicType,EncodeFaceValues,FaceValue,FilePath,SubFeaturesid,PictureType,SubFeatureID)
	 values (@Assigned,@MediaExtention,@MediaName,@Description,getdate(),@DefaultPic,null,
		@EncodeState,@PicType,@EncodeFaceValues,@FaceValue,@FilePath,@SubFeaturesid,'Media',0)
      select @@identity
  COMMIT TRANSACTION       
 End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesEmployeeAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RemoveRolesEmployeeAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From EmployeeAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesEventReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RemoveRolesEventReportsAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From EventReportsAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesEventsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[RemoveRolesEventsAccess]
(
    @ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From EventsAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesGenSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RemoveRolesGenSubReportsAccess]
(
    @ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From GenSubReportsAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RemoveRolesReportsAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From EmpReportsAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesSubjectAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RemoveRolesSubjectAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From SubjectAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveRolesSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RemoveRolesSubReportsAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
	 Delete From SubReportsAccessByRole where ID=@ID
	 Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersEmployeeAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RemoveUsersEmployeeAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From EmployeeAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersEventReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RemoveUsersEventReportsAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From EventReportsAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersEventsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[RemoveUsersEventsAccess]
(
    @ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From EventsAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersGenSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RemoveUsersGenSubReportsAccess]
(
    @ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From GenSubReportsAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RemoveUsersReportsAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From EmpReportsAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersSubjectAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RemoveUsersSubjectAccess]
(
    @ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From SubjectAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersSubReportsAccess]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RemoveUsersSubReportsAccess]
(
@ID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		Delete From SubReportsAccessUsers where ID=@ID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[ReportDesigner_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ReportDesigner_I]  
(  
@ReportID int=0,
@ReportName nvarchar(15),   
@ReportRole nvarchar(50),   
@ReportLayout nvarchar(max),
@ReportSql varchar(max),
@WholeLayout nvarchar(max)
)  
AS  
Begin  
  Begin Try                        
   Begin Transaction
  if(@ReportID > 0)
  begin
  update Reports set ReportName =@ReportName, ReportRole =@ReportRole, ReportLayout=@ReportLayout,WholeLayout=@WholeLayout where ReportID=@ReportID
    DELETE FROM ReportQueries WHERE ReportID=@ReportID
		  DELETE FROM ReportSQL WHERE ReportID = @ReportID
		  INSERT INTO ReportSQL (ReportID, QueryID, QuerySQL, UserModified) values(@ReportID,0,@ReportSql,0)
			
	select @@Rowcount
  end
  else
   begin   
		 INSERT INTO Reports (ReportName, ReportRole, ReportLayout,WholeLayout) VALUES (@ReportName, @ReportRole, @ReportLayout,@WholeLayout)
		  select @ReportID=@@IDENTITY   
		  DELETE FROM ReportQueries WHERE ReportID=@ReportID
		  DELETE FROM ReportSQL WHERE ReportID = @ReportID
		  INSERT INTO ReportSQL (ReportID, QueryID, QuerySQL, UserModified) values(@ReportID,0,@ReportSql,0)
		    select @@IDENTITY   
		  --INSERT INTO ReportQueries (ReportID, QueryID, FieldSequence, QueryField) values(@ReportID,0,@ReportSql,0)
   
 end
     
   Commit Transaction  
  End Try   
  Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch   
End 
GO
/****** Object:  StoredProcedure [dbo].[ReportLayout_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  Procedure  [dbo].[ReportLayout_Load] 
(   
	 @ReportID int	
 )

 AS
 BEGIN 
    SELECT ReportLayout,WholeLayout FROM Reports WHERE ReportID=@ReportID
  END


GO
/****** Object:  StoredProcedure [dbo].[ReportLogoImage_Add]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ReportLogoImage_Add]
@ImagePath nvarchar(MAX)=null,
@SetImage bit=Null,
@CreatedBy int=0        
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Insert into ReportLogoImage(ImagePath,SetImage,CreatedBy) Values(@ImagePath,@SetImage,@CreatedBy)
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 

GO
/****** Object:  StoredProcedure [dbo].[ReportLogoImage_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ReportLogoImage_Bind]
     
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    select * from ReportLogoImage
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[ReportLogoImage_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ReportLogoImage_Delete]
@ID int=0        
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Delete from ReportLogoImage where ID=@ID
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 




GO
/****** Object:  StoredProcedure [dbo].[ReportLogoImage_SetImage]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ReportLogoImage_SetImage]
@ID int=0     
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Update ReportLogoImage set SetImage=Null
    Update ReportLogoImage set SetImage='true' where ID=@ID 
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[ReportPermissionCheck_User]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ReportPermissionCheck_User] 
(
@ReportAccessBy int,
@ReportID int,
@EmployeeID int,
@ReportAccessRole int
)
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
    declare @set1 int
	declare @set2 Bit 
	 Begin 		  
	  set @set1=(select COUNT(*) from EmpReportsAccessUsers where ReportAccessBy=@ReportAccessBy and ReportID=@ReportID and EmployeeID=@EmployeeID)
	  if(@set1>0)  
	   begin  
	    set @set2=(select ViewReport from EmpReportsAccessUsers where ReportAccessBy=@ReportAccessBy and ReportID=@ReportID and EmployeeID=@EmployeeID)
		if(@set2='1')
		 Begin
	      select * from EmpReportsAccessUsers where ReportAccessBy=@ReportAccessBy and ReportID=@ReportID and EmployeeID=@EmployeeID
		 End
		Else
		 Begin           
		  select * from EmpReportsAccessByRole where ReportAccessRole=@ReportAccessRole and ReportID=@ReportID and EmployeeID=@EmployeeID
		 End
	   END 
	  ELSE
	   Begin           
	    select * from EmpReportsAccessByRole where ReportAccessRole=@ReportAccessRole and ReportID=@ReportID and EmployeeID=@EmployeeID
	   End
	  End           
    COMMIT TRANSACTION           
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[Reports_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Reports_LoadByIncidentID]    
@IncidentId int=0    
As    
BEGIN    
 Select * from IncidentReports    
 where IncidentID=@IncidentId  
END
GO
/****** Object:  StoredProcedure [dbo].[ReportsAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ReportsAccessPermission_ByRole]
(
@ID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EmpReportsAccessByRole where ID=@ID and ReportID=@ReportID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[ReportsAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ReportsAccessPermission_ByUser]
(
@ID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from EmpReportsAccessUsers where ID=@ID and ReportID=@ReportID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[ReportsAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ReportsAccessRoles_Bind]
(
@UserID int,
@ReportID int,
@EmployeeID int = 0
)
AS             
BEGIN   
  Begin Try           
    Begin 


	if(@EmployeeID > 0)
	begin

		select ManageRoles.RoleName,
		EmpReportsAccessByRole.* from EmpReportsAccessByRole
		left join ManageRoles on ManageRoles.RoleId=EmpReportsAccessByRole.ReportAccessRole
		where EmployeeID=@EmployeeID and ReportID=0  AND ManageRoles.RoleName <> 'Administrator';

	end
	else
	begin

		select ManageRoles.RoleName,
		EmpReportsAccessByRole.* from EmpReportsAccessByRole
		left join ManageRoles on ManageRoles.RoleId=EmpReportsAccessByRole.ReportAccessRole
		where ReportID=@ReportID and CreatedBy=@UserID AND  ManageRoles.RoleName <> 'Administrator';

	end

		


	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[ReportsAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ReportsAccessUsers_Bind]
(
@UserID int,
@ReportID int,
@EmployeeID int = 0
)
AS             
BEGIN   
  Begin Try           
    Begin 

	if(@EmployeeID > 0)
	begin

		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		EmpReportsAccessUsers.* 
		from EmpReportsAccessUsers
		left join Users on Users.ID=EmpReportsAccessUsers.ReportAccessBy
		where EmployeeID=@EmployeeID and ReportID = 0
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

	end
	else
	begin

		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		EmpReportsAccessUsers.* 
		from EmpReportsAccessUsers
		left join Users on Users.ID=EmpReportsAccessUsers.ReportAccessBy
		where ReportID=@ReportID and CreatedBy=@UserID
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
	end
		
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[ReportSQL_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create  Procedure  [dbo].[ReportSQL_Load] 
(   
	 @ReportID int	
 )

 AS
 BEGIN 
    SELECT QuerySQL FROM ReportSQL WHERE ReportID=@ReportID
  END


GO
/****** Object:  StoredProcedure [dbo].[Review_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Review_LoadById]
@EventID int=0
As
BEGIN
	SELECT ReviewID, ItemNumber, ReplacedBy, Reason, Description, FromHoursMinutes, ToHoursMinutes FROM Review WHERE EventID = @EventID
END
GO
/****** Object:  StoredProcedure [dbo].[Role_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Role_DeleteById]     
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from SecurityFunctions where ID = @ID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[Role_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Role_IU]     
@ID int =0,  
@RoleName nvarchar(200)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@ID > 0)
    Begin 
	  If(Not Exists(Select * from SecurityFunctions where RoleName=@RoleName and ID != @ID))  
      Begin  
			update SecurityFunctions set RoleName = @RoleName
			select 1  
     End            
      Else  
	 Begin            
        Select -10            
     End            
	End 
    Else
	Begin
		 If(Not Exists(Select * from SecurityFunctions where RoleName=@RoleName))            
		Begin 
			Insert into SecurityFunctions(RoleName) values (@RoleName)          
			select @@IDENTITY
		End
		Else
		Begin
			Select -10         
		End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[Role_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Role_LoadById]     
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from SecurityFunctions where ID = @ID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[RoleAuthorities_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RoleAuthorities_IU]     
@ID int =0,  
@RoleName nvarchar(200),
@WatchListEdit int = 0,
@WatchList int = 0,
@Visitors int = 0,
@Vehicles int = 0,
@Users int = 0,
@TransactionLog int = 0,
@Subjects int = 0,
@SubjectLinked int = 0,
@SharedInformation int = 0,
@SharedEmails int = 0,
@ServicesCodes int = 0,
@Services int = 0,
@RestrictedSubjects int = 0,
@ReportOptions int = 0,
@QuickIncident int = 0,
@Permissions int = 0,
@OccurrenceWrite int = 0,
@OccurrenceAdministration int = 0,
@Occurrence int = 0,
@NatureofIncidentCodes int = 0,
@NatureofCallCodes int = 0,
@MultipleAuthorReports int = 0,
@Messages int = 0,
@MessageGroups int = 0,
@MessageAlerts int = 0,
@MediaReview int = 0,
@MediaCopy int = 0,
@MediaCaptureOptions int = 0,
@MediaCapture int = 0,
@LCTTotals int = 0,
@LCTDetails int = 0,
@LabelNames int = 0,
@Involved int = 0,
@IncidentProtection int = 0,
@IncidentDetails int = 0,
@IncidentDescription int = 0,
@Identification int = 0,
@GameLocations int = 0,
@ForeignRates int = 0,
@Features int = 0,
@EventsMedia int = 0,
@Events int = 0,
@Equipment int = 0,
@EmployeeVariance int = 0,
@EmployeePersonal int = 0,
@EmployeePaceAudit int = 0,
@EmployeeNotes int = 0,
@EmployeeLinked int = 0,
@EmployeeLicense int = 0,
@EmployeeIPVR int = 0,
@EmployeeInvolved int = 0,
@EmployeeIncidentDetails int = 0,
@EmployeeGameAudit int = 0,
@EmployeeAddress int = 0,
@Employee int = 0,
@Emails int = 0,
@DropdownCodes int = 0,
@DisputeOffense int = 0,
@DispatchDispatchers int = 0,
@DispatchCallTakers int = 0,
@DispatchAdministration int = 0,
@DatabaseOptions int = 0,
@CustomReports int = 0,
@CombineSubjects int = 0,
@ChangeRoles int = 0,
@CashTransactions int = 0,
@Banned int = 0,
@Badges int = 0,
@AuditQuestions int = 0,
@ApplicationOptions int = 0,
@Alias int = 0,
@Address int = 0,
@AccessCards int = 0
AS             
BEGIN         
 declare @tempCount int=0           
  Begin Try            
   Begin Transaction 
   If(@ID > 0)
    Begin            
	  If(Not Exists(Select * from SecurityFunctions where RoleName=@RoleName))            
      Begin            
		Insert into SecurityFunctions(            
				[Watch List Edit] , [Watch List] ,  [Visitors] ,
				[Vehicles] ,[Users] , [Transaction Log] ,[Subjects], [Subject Linked] ,[Shared Information] ,[Shared Emails] , [Services Codes] ,
				[Services] , [Restricted Subjects], [Report Options] ,[Quick Incident] , [Permissions] , [Occurrence Write] , [Occurrence Administration] ,
				[Occurrence] , [Nature of Incident Codes] , [Nature of Call Codes] , [Multiple Author Reports] , [Messages] , [Message Groups] ,
				[Message Alerts] , [Media Review] , [Media Copy] , [Media Capture Options] ,  [Media Capture] ,  [LCT Totals] , [LCT Details] ,
				[Label Names] , [Involved] , [Incident Protection] , [Incident Details] ,  [Incident Description] , [Identification] ,  
				[Game Locations] ,  [Foreign Rates] ,  [Features] ,[Events Media] ,   [Events] ,    [Equipment] ,   [Employee Variance] ,
				[Employee Personal] , [Employee Pace Audit] ,  [Employee Notes] ,  [Employee Linked] , [Employee License] ,
				[Employee IPVR] ,  [Employee Involved] , [Employee Incident Details] , [Employee Game Audit] , [Employee Address] ,
				[Employee] , [E-mails] , [Dropdown Codes] , [Dispute/Offense] , [Dispatch Dispatchers] , [Dispatch Call Takers] ,
				[Dispatch Administration], [Database Options] , [Custom Reports] ,[Combine Subjects] ,[Change Roles],[Cash Transactions] , [Banned] ,
				[Badges] ,[Audit Questions] ,[Application Options] ,[Alias] ,[Address] ,[Access Cards] )            
		values(            
				@WatchListEdit , @WatchList ,  @Visitors ,
				@Vehicles ,@Users , @TransactionLog ,@Subjects , @SubjectLinked ,@SharedInformation ,@SharedEmails , @ServicesCodes ,
				@Services , @RestrictedSubjects , @ReportOptions ,@QuickIncident , @Permissions , @OccurrenceWrite , @OccurrenceAdministration ,
				@Occurrence , @NatureofIncidentCodes , @NatureofCallCodes , @MultipleAuthorReports , @Messages , @MessageGroups ,
				@MessageAlerts , @MediaReview , @MediaCopy , @MediaCaptureOptions ,  @MediaCapture ,  @LCTTotals , @LCTDetails ,
				@LabelNames , @Involved , @IncidentProtection , @IncidentDetails ,  @IncidentDescription , @Identification ,  
				@GameLocations ,  @ForeignRates ,  @Features ,@EventsMedia ,   @Events ,    @Equipment ,   @EmployeeVariance ,
				@EmployeePersonal , @EmployeePaceAudit ,  @EmployeeNotes ,  @EmployeeLinked , @EmployeeLicense ,
				@EmployeeIPVR ,  @EmployeeInvolved , @EmployeeIncidentDetails , @EmployeeGameAudit , @EmployeeAddress ,
				@Employee , @Emails , @DropdownCodes , @DisputeOffense , @DispatchDispatchers , @DispatchCallTakers ,
				@DispatchAdministration, @DatabaseOptions , @CustomReports ,@CombineSubjects ,@ChangeRoles ,@CashTransactions , @Banned ,
				@Badges ,@AuditQuestions ,@ApplicationOptions ,@Alias ,@Address ,@AccessCards
		   )          
		select @@IDENTITY
     End            
      Else  
	 Begin            
        Select -10            
     End            
	End 
    Else
	Begin
		If(Not Exists(Select * from SecurityFunctions where RoleName=@RoleName and ID != @ID))            
		Begin 
			update SecurityFunctions set 
				[Watch List Edit] = @WatchListEdit,
				[Watch List] = @WatchList, 
				[Visitors] = @Visitors,
				[Vehicles] = @Vehicles,
				[Users] = @Users,
				[Transaction Log] = @TransactionLog,
				[Subjects] = @Subjects,
				[Subject Linked]  = @SubjectLinked,
				[Shared Information] = @SharedInformation,
				[Shared Emails] = @SharedEmails,
				[Services Codes] = @ServicesCodes,
				[Services] = @Services,
				[Restricted Subjects] = @RestrictedSubjects,
				[Report Options] = @ReportOptions,
				[Quick Incident] = @QuickIncident ,
				[Permissions] = @Permissions,
				[Occurrence Write] = @OccurrenceWrite,
				[Occurrence Administration] = @OccurrenceAdministration,
				[Occurrence] = @Occurrence,
				[Nature of Incident Codes] = @NatureofIncidentCodes, 
				[Nature of Call Codes] = @NatureofCallCodes, 
				[Multiple Author Reports] = @MultipleAuthorReports, 
				[Messages] = @Messages, 
				[Message Groups] = @MessageGroups,
				[Message Alerts] = @MessageAlerts,
				[Media Review] = @MediaReview, 
				[Media Copy] = @MediaCopy,
				[Media Capture Options] = @MediaCaptureOptions,
				[Media Capture] = @MediaCapture, 
				[LCT Totals] =  @LCTTotals , 
				[LCT Details] = @LCTDetails,
				[Label Names] = @LabelNames,
				[Involved] = @Involved, 
				[Incident Protection] = @IncidentProtection,
				[Incident Details] = @IncidentDetails,
				[Incident Description] = @IncidentDescription,
				[Identification] = @Identification,  
				[Game Locations] = @GameLocations, 
				[Foreign Rates] = @ForeignRates, 
				[Features] = @Features,
				[Events Media] = @EventsMedia,  
				[Events] = @Events,   
				[Equipment] = @Equipment,
				[Employee Variance] = @EmployeeVariance,
				[Employee Personal] = @EmployeePersonal,
				[Employee Pace Audit] = @EmployeePaceAudit, 
				[Employee Notes] = @EmployeeNotes, 
				[Employee Linked] = @EmployeeLinked, 
				[Employee License] = @EmployeeLicense,
				[Employee IPVR] = @EmployeeIPVR,
				[Employee Involved] = @EmployeeInvolved,
				[Employee Incident Details] = @EmployeeIncidentDetails,
				[Employee Game Audit] = @EmployeeGameAudit,
				[Employee Address] = @EmployeeAddress,
				[Employee] = @Employee,
				[E-mails] = @Emails, 
				[Dropdown Codes]  = @DropdownCodes,
				[Dispute/Offense] = @DisputeOffense, 
				[Dispatch Dispatchers] = @DispatchDispatchers, 
				[Dispatch Call Takers] = @DispatchCallTakers,
				[Dispatch Administration] = @DispatchAdministration, 
				[Database Options] = @DatabaseOptions,
				[Custom Reports] = @CustomReports,
				[Combine Subjects] = @CombineSubjects,
				[Change Roles] = @ChangeRoles,
				[Cash Transactions] = @CashTransactions,
				[Banned] = @Banned,
				[Badges] = @Badges,
				[Audit Questions] = @AuditQuestions,
				[Application Options] = @ApplicationOptions,
				[Alias] = @Alias,
				[Address] = @Address,
				[Access Cards] = @AccessCards
				select 1
		End
		Else
		Begin
			Select -10         
		End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Roles_LoadAll]   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from SecurityFunctions 
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SearchEmployees]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec [dbo].[SearchEmployees] null,null,null,null,null,null,null,null,null
CREATE procedure [dbo].[SearchEmployees] --'Pooja'
(
@FirstName nvarchar(25)=null,
@LastName nvarchar(25)=null,
@Sex nvarchar(10)=null,
@Race nvarchar(25)=null,
@DOB datetime=null,
@DateOfIncident datetime=null,
@NatureOfEvent nvarchar(50)=null,
@ShortDescriptor nvarchar(25)=null,
@Status nvarchar(25)=null
)
AS
BEGIN
Declare @SQL nvarchar(max)
Set @SQL='Select FirstName,LastName,Status,EmployeeID from Employees
 where EmployeeID>0'
 
 if(@FirstName is not null)
  Set @SQL=@SQL+'and FirstName like ''%'+@FirstName+'%'''
  
 if(@LastName is not null)
  Set @SQL=@SQL+'and LastName like ''%'+@LastName+'%'''
  
   if(@Sex is not null)
  Set @SQL=@SQL+'and Sex ='+@Sex+''
  
  if(@Race is not null)
  Set @SQL=@SQL+'and Race='+@Race+''
  
  if(@DOB is not null)
  Set @SQL=@SQL+'and DateOfBirth='+@DOB+''
  
   if(@DateOfIncident is not null)
  Set @SQL=@SQL+'and IncidentDate='+@DateOfIncident+''
  
   if(@NatureOfEvent is not null)
  Set @SQL=@SQL+'and NatureOfEvent='+@NatureOfEvent+''
  
   if(@ShortDescriptor is not null)
  Set @SQL=@SQL+'and ShortDescriptor like ''%'+@ShortDescriptor+'%'''
  
   if(@Status is not null)
  Set @SQL=@SQL+'and Status like ''%'+@Status+'%'''
  
  print(@SQL)
  execute(@SQL)
 END
GO
/****** Object:  StoredProcedure [dbo].[SearchSubject]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec [dbo].[SearchSubject]   'naina',null,null,null,null,null,null,null,null
CREATE procedure [dbo].[SearchSubject]     
@FirstName nvarchar(200) = null,
@LastName nvarchar(200) = null,
@Sex nvarchar(200) = null,
@Race nvarchar(200) = null,
@DateOfBirth nvarchar(200) = null,
@IncidentDate nvarchar(200) = null,
@NatureOfIncident nvarchar(200) = null,
@ShortDescription nvarchar(200) = null,
@OverallStatus nvarchar(200) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		Declare @sql nvarchar(max) = '' ;
		set @sql = 'select * from Subjects where 1=1 '
		--left join SubjectLinked subLink on sub.SubjectID = subLink.SubjectID
		--left join Incidents as inc on subLink.IncidentID  = inc.IncidentID
		if(@FirstName != '')
		Begin
			set @sql += ' and FirstName like ''%'+@FirstName+'%'''
		End
		if(@LastName != '')
		Begin
			set @sql += ' LastName like ''%'+@LastName+'%'''
		End
		if(@Sex != '')
		Begin
			set @sql += ' and  Sex ='''+@Sex+''''
		End
		if(@Race != '')
		Begin
			set @sql += ' and Race ='''+ @Race +''''
		End
		if(@DateOfBirth != '')
		Begin
			set @sql += ' and DateOfBirth ='''+ @DateOfBirth +''''
		End
		print (@sql)
		exec (@sql)
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SecurityFunctions_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SecurityFunctions_LoadAll]   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		Select RoleName From SecurityFunctions Order By RoleName
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SendEmailLog]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SendEmailLog]
    
AS                             
BEGIN                   
  Begin Try    
   Begin Transaction   
    Select top 1 * from VisitorEmailSend order by ModifiedDate DESC
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 






GO
/****** Object:  StoredProcedure [dbo].[Services_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
Create Procedure [dbo].[Services_Delete](            
@Id int            
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
   Delete from Services where Id=@Id             
   Select @@RowCount as RESULT             
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END
GO
/****** Object:  StoredProcedure [dbo].[Services_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
 CREATE Procedure [dbo].[Services_IU](  
@Id int,            
@ServiceName nvarchar(200),
@DeclinedAvailable nvarchar(10)           
)            
as                           
BEGIN                   
  Begin Try                            
   Begin Transaction                 
    Begin                 
  if exists(SELECT *  FROM Services  where Id=@Id)              
   begin              
   update Services set ServiceName=@ServiceName, DeclinedAvailable=@DeclinedAvailable where Id=@Id              
   select @@RowCount as RESULT          
   end              
  ELSE              
  begin              
   insert into Services(ServiceName,DeclinedAvailable) values(@ServiceName,@DeclinedAvailable)              
   select @@Identity as RESULT            
  end              
 End                 
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END   

GO
/****** Object:  StoredProcedure [dbo].[Services_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Services_LoadAll]   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT Id,ServiceName, DeclinedAvailable FROM Services ORDER BY ServiceName
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[setmetrics_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[setmetrics_Delete]
(
@ID int
)  
as                 
BEGIN         
  Begin Try                  
   Begin Transaction       
    Begin       
	  Delete from setmetrics where ID=@ID   
	  Select @@RowCount as RESULT   
	End       
   COMMIT TRANSACTION       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[setmetrics_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[setmetrics_IU]
(
@ID int=0,
@Type nvarchar(10)=Null,
@metrics nvarchar(20)=Null,
@ActiveMetrics bit=Null
)
as
BEGIN         
  Begin Try      
    Begin       
       if exists(SELECT *  FROM setmetrics  where ID=@ID)
       Begin 
        Update setmetrics set Type=@Type,metrics=@metrics,ActiveMetrics=@ActiveMetrics where ID=@ID
        select @@RowCount as RESULT
       End
       Else 
        Begin
		 Insert into setmetrics(Type,metrics)values(@Type,@metrics)
		 select @@Identity as RESULT
		End	
	End       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[setmetrics_LoadBy]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[setmetrics_LoadBy]
(
@Type nvarchar(10)
)
as
BEGIN         
  Begin Try      
    Begin       
	 Select * from setmetrics where Type=@Type 
	 Select @@RowCount as RESULT  
	End       
  End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END 

GO
/****** Object:  StoredProcedure [dbo].[ShortDescriptor_Graph]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE Procedure [dbo].[ShortDescriptor_Graph] --'Subject','2016-09-01 00:00:00.000','2016-09-01 00:00:00.000'
(
@ReportType nvarchar(100),
@StartDate datetime,
@EndDate datetime
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if(@ReportType='Subject')
	begin
		if (@StartDate <>'' AND @EndDate <>'')        
				set @Where=@Where+' and Incidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
			  if (@StartDate  <>'' AND @EndDate  ='')        
				  set @Where=@Where+' and Incidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
			  if (@StartDate ='' AND @EndDate <>'')     
			  set @Where=@Where+' and Incidents.IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 
	  
				set @SQL='SELECT TOP 15 ShortDescriptor, COUNT(ShortDescriptor) as results FROM Incidents '+  @Where +' GROUP BY ShortDescriptor ORDER BY 2 DESC'
				
	end
else
	begin
	if (@StartDate <>'' AND @EndDate <>'')        
			set @Where=@Where+' and EmployeeIncidents.IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
		  if (@StartDate  <>'' AND @EndDate  ='')        
			  set @Where=@Where+' and EmployeeIncidents.IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
		  if (@StartDate ='' AND @EndDate <>'')     
		  set @Where=@Where+' and EmployeeIncidents.IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 		  	
		 set @SQL='SELECT TOP 15 ShortDescriptor, COUNT(ShortDescriptor) as results FROM EmployeeIncidents '+  @Where +' GROUP BY ShortDescriptor ORDER BY 2 DESC'
		
	end
exec(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPaceAuditReport]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Procedure [dbo].[sp_GetPaceAuditReport]  -----'Blackjack','07/18/2016','08/22/2016','FirstName'    
(    
@Game nvarchar(30),    
@StartDate varchar(25),    
@EndDate varchar(25),    
--@HandsPerHour nvarchar(30),    
@SortBy nvarchar(25)    
)    
As    
Begin        
Declare @SQL nvarchar(max)      
  Begin Try                              
   Begin Transaction         
       
 Begin        
 Set @SQL= 'SELECT Employees.EmployeeID,Employees.StaffPosition,EmployeePaceAuditShuffleShoe.StartTime As ShoeTime, Employees.LastName, Employees.FirstName, COUNT(EmployeePaceAuditShuffleShoe.IncidentID) AS ObservationCount, COUNT(DISTINCT EmpEmployeeIncidents.IncidentID) AS IncidentCount     
,EmployeePaceAuditShuffleShoe.PaceAuditHandsPerHour,EmployeePaceAuditShuffleShoe.TimeTaken FROM  EmployeeIncidents INNER JOIN EmployeePaceAuditShuffleShoe ON EmployeeIncidents.IncidentID = EmployeePaceAuditShuffleShoe.IncidentID     
INNER JOIN EmpEmployeeIncidents ON EmployeeIncidents.IncidentID = EmpEmployeeIncidents.IncidentID     
INNER JOIN Employees ON EmpEmployeeIncidents.EmployeeID = Employees.EmployeeID  where 1=1'    
---IF LEN(ISNULL(@Game, '')) != 0    
IF @Game!=''    
Begin    
Set @SQL +=' and EmployeePaceAuditShuffleShoe.Game=''' +@Game + ''''    
    
End    
IF @StartDate !='' and @EndDate !=''    
BEGIN    
Set @SQL +=' and EmployeeIncidents.IncidentDate BETWEEN ''' +Convert(varchar(10),@StartDate,101) + ''' and ''' + convert(varchar(10),@EndDate,101) +''''   
END    
    
Set @SQL +=' GROUP BY Employees.EmployeeID, Employees.LastName, Employees.FirstName,EmployeePaceAuditShuffleShoe.TimeTaken,EmployeePaceAuditShuffleShoe.PaceAuditHandsPerHour,Employees.StaffPosition,EmployeePaceAuditShuffleShoe.StartTime'    
    
IF(@SortBy !='')    
Begin    
Set @SQL +=' ORDER BY '+ @SortBy    
END    
    
    
print(@SQL)      
execute(@SQL)      
 End        
         
   Commit Transaction        
  End Try         
  Begin Catch                           
  IF @@TRANCOUNT >0                           
          Select ERROR_MESSAGE()                  
    Rollback Transaction                    
    EXECUTE [uspLogError]                             
 End Catch         
End     
    
    
    
GO
/****** Object:  StoredProcedure [dbo].[spCustomTable2HTML]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCustomTable2HTML] (
@TABLENAME  NVARCHAR(500),
@OUTPUT   NVARCHAR(MAX) OUTPUT,
@TBL_STYLE NVARCHAR(1024) = '',
@HDR_STYLE NVARCHAR(1024) = '')
AS


-- Author:		Ian Atkin (ian.atkin@ict.ox.ac.uk)

-- Description 
--				Stored Procedure to take an arbitraty temporary table and return 
--				the equivalent HTML string .

-- Version History
--			1.0 - Initial Release For Symantec Connect (Sept 2011)



-- @exec_str stores the dynamic SQL Query
-- @ParmDefinition stores the parameter definition for the dynamic SQL
DECLARE @exec_str  NVARCHAR(MAX)
DECLARE @ParmDefinition NVARCHAR(500)


--We need to use Dynamic SQL at this point so we can expand the input table name parameter
SET @exec_str= N'
DECLARE @exec_str  NVARCHAR(MAX)
DECLARE @ParmDefinition NVARCHAR(500)

--Make a copy of the original table adding an indexing columnWe need to add an index column to the table to facilitate sorting so we can maintain the
--original table order as we iterate through adding HTML tags to the table fields.
--New column called CustColHTML_ID (unlikely to be used by someone else!)
--

select CustColHTML_ID=0,* INTO #CustomTable2HTML FROM ' + @TABLENAME + ' 

--Now alter the table to add the auto-incrementing index. This will facilitate row finding
DECLARE @COUNTER INT
SET @COUNTER=0
UPDATE #CustomTable2HTML SET @COUNTER = CustColHTML_ID=@COUNTER+1 

-- @HTMLROWS will store all the rows in HTML format
-- @ROW will store each HTML row as fields on each row are iterated through 
-- using dymamic SQL and a cursor
-- @FIELDS will store the header row for the HTML Table

DECLARE @HTMLROWS NVARCHAR(MAX) DECLARE @FIELDS NVARCHAR(MAX) 
SET @HTMLROWS='''' DECLARE @ROW NVARCHAR(MAX) 

-- Create the first HTML row for the table (the table header). Ignore our indexing column!
SET @FIELDS=''<tr ' + @HDR_STYLE + '>''
SELECT @FIELDS=COALESCE(@FIELDS, '' '','''')+''<th>'' + name + ''</th>''
FROM tempdb.sys.Columns
WHERE object_id=object_id(''tempdb..#CustomTable2HTML'')
AND name not like ''CustColHTML_ID''
SET @FIELDS=@FIELDS + ''</tr>''

-- @ColumnName stores the column name as found by the table cursor
-- @maxrows is a count of the rows in the table, and @rownum is for marking the
-- ''current'' row whilst processing

DECLARE @ColumnName  NVARCHAR(500)
DECLARE @maxrows INT
DECLARE @rownum INT

--Find row count of our temporary table
SELECT @maxrows=count(*) FROM  #CustomTable2HTML


--Create a cursor which will look through all the column names specified in the temporary table
--but exclude the index column we added (CustColHTML_ID)
DECLARE col CURSOR FOR
SELECT name FROM tempdb.sys.Columns
WHERE object_id=object_id(''tempdb..#CustomTable2HTML'')
AND name not like ''CustColHTML_ID''
ORDER BY column_id ASC

--For each row, generate dymanic SQL which requests the each column name in turn by 
--iterating through a cursor
SET @rowNum=0
SET @ParmDefinition=N''@ROWOUT NVARCHAR(MAX) OUTPUT,@rowNum_IN INT''

While @rowNum < @maxrows
BEGIN
  SET @HTMLROWS=@HTMLROWS + ''<tr>''

  SET @rowNum=@rowNum +1
  OPEN col
  FETCH NEXT FROM col INTO @ColumnName
  WHILE @@FETCH_STATUS=0
    BEGIN
      --Get nth row from table
      --SET @exec_str=''SELECT @ROWOUT=(select top 1 ['' + @ColumnName + ''] from (select top '' + cast(@rownum as varchar) + '' * from #CustomTable2HTML order by CustColHTML_ID ASC) xxx order by CustColHTML_ID DESC)''
      SET @exec_str=''SELECT @ROWOUT=(select ['' + @ColumnName + ''] from #CustomTable2HTML where CustColHTML_ID=@rowNum_IN)''

	  EXEC	sp_executesql 
			@exec_str,
			@ParmDefinition,
			@ROWOUT=@ROW OUTPUT,
            @rowNum_IN=@rownum

      SET @HTMLROWS =@HTMLROWS +  ''<td>'' + @ROW + ''</td>''
      FETCH NEXT FROM col INTO @ColumnName
    END
  CLOSE col
  SET @HTMLROWS=@HTMLROWS + ''</tr>''
END

SET @OUTPUT=''''
IF @maxrows>0
SET @OUTPUT= ''<table ' + @TBL_STYLE + '>'' + @FIELDS + @HTMLROWS + ''</table>''

DEALLOCATE col
'

DECLARE @ParamDefinition nvarchar(max)
SET @ParamDefinition=N'@OUTPUT NVARCHAR(MAX) OUTPUT'

--Execute Dynamic SQL. HTML table is stored in @OUTPUT which is passed back up (as it's
--a parameter to this SP)
EXEC sp_executesql @exec_str,
@ParamDefinition,
@OUTPUT=@OUTPUT OUTPUT

RETURN 1



GO
/****** Object:  StoredProcedure [dbo].[States_LoadByCountries]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[States_LoadByCountries]
(
@CountryID int=0
)
as
begin
	select * from States where CountryID=@CountryID
end

GO
/****** Object:  StoredProcedure [dbo].[Subject_dashboard]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Subject_dashboard](@UserID           INT,
                                          @ReportAccessRole INT = 0)
AS
     BEGIN
         IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0)
             BEGIN
                 SELECT TOP (10) Subjects.SubjectID,
                                 Subjects.FirstName,
                                 Subjects.MiddleName,
                                 Subjects.LastName,
                                 Subjects.ModifiedDate,
                                 Users.FirstName+' '+Users.LastName AS CreatedByUser,
                 (
                     SELECT COUNT(*)
                     FROM Subjects
                 ) AS TotalSubjects,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM SubjectPicturesVideos SPV
                          LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                     WHERE SubjectID = Subjects.SubjectID
                 ) AS FilePath
                 FROM Subjects
                      LEFT JOIN Users AS Users ON Users.ID = Subjects.CreatedBy
                 ORDER BY Subjects.SubjectID DESC;
             END
		   ELSE
		   BEGIN
			 WITH cteReportPermission
              AS (
		    SELECT ISNULL(RP.SubjectID,UP.SubjectID) AS SubjectID
			 FROM
			 (SELECT SubjectID,ViewReport, 1 AS ByRole
			 FROM SubjectAccessByRole
			 WHERE ReportAccessRole = @ReportAccessRole
				AND ViewReport = '1'
				) AS RP
			 FULL JOIN     
				 (SELECT SubjectID,ViewReport, 2 ByUser
							  FROM SubjectAccessUsers
							  WHERE ReportAccessBy = @UserID
							  AND (ViewReport = '1' OR ViewReport IS NULL OR ViewReport = 0)
								   ) AS UP ON RP.SubjectID = UP.SubjectID
			 WHERE (RP.ViewReport = 1 AND UP.ViewReport = 1) 
			 OR (RP.ViewReport = 1 AND UP.SubjectID IS NULL)
			 OR(UP.ViewReport = 1 AND RP.SubjectID IS NULL))

			 SELECT TOP (10) Subjects.SubjectID,
                                 Subjects.FirstName,
                                 Subjects.MiddleName,
                                 Subjects.LastName,
                                 Subjects.ModifiedDate,
                                 Users.FirstName+' '+Users.LastName AS CreatedByUser,
                 (
                    SELECT COUNT(*)
                     FROM Subjects
                     WHERE CreatedBy = @UserID
				 OR SubjectID IN (
				    SELECT SubjectID FROM cteReportPermission
				 )
                 ) AS TotalSubjects,
                 (
                     SELECT TOP (1) PV.FilePath
                     FROM SubjectPicturesVideos SPV
                          LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                     WHERE SubjectID = Subjects.SubjectID
                 ) AS FilePath
                 FROM Subjects
                      INNER JOIN Users AS Users ON Users.ID = Subjects.CreatedBy
				  WHERE CreatedBy = @UserID
			 OR SubjectID IN (
				    SELECT SubjectID FROM cteReportPermission
				 )
                 ORDER BY Subjects.SubjectID DESC;

		   END
         --if((select count(*) from Users where IsAdmin=1 and ID=@UserID)>0)
         --	begin
         --		select top(10)Subjects.SubjectID,Subjects.FirstName,Subjects.MiddleName,Subjects.LastName,Subjects.ModifiedDate,
         --		Users.FirstName+' '+Users.LastName as CreatedByUser,(select count(*) from Subjects) as TotalSubjects,
         --		(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
         --		left join PicturesVideos PV on SPV.MediaID = PV.MediaID 
         --		where SubjectID = Subjects.SubjectID) as FilePath  from Subjects 
         --		left join Users as Users on Users.ID=Subjects.CreatedBy
         --		order by Subjects.SubjectID desc
         --	end
         --else
         --	begin
         --		select top(10)Subjects.SubjectID,Subjects.FirstName,Subjects.MiddleName,Subjects.LastName,Subjects.ModifiedDate,
         --		Users.FirstName+' '+Users.LastName as CreatedByUser,(select count(*) from Subjects where CreatedBy=@UserID) as TotalSubjects,
         --		(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
         --		left join PicturesVideos PV on SPV.MediaID = PV.MediaID 
         --		where SubjectID = Subjects.SubjectID) as FilePath from Subjects 
         --		left join Users as Users on Users.ID=Subjects.CreatedBy
         --		where CreatedBy=@UserID
         --		order by Subjects.SubjectID desc 
         --	end
     END;
GO
/****** Object:  StoredProcedure [dbo].[Subject_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Subject_DeleteById]     
@SubjectID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from Subjects where SubjectID = @SubjectID
		delete from SubjectAddress where SubjectID = @SubjectID
		delete from SubjectAlias where SubjectID = @SubjectID
		delete from SubjectMarks where SubjectID = @SubjectID
		delete from SubjectIdentification where SubjectID = @SubjectID
		delete from SubjectWatch where SubjectID = @SubjectID
		delete from SubjectLinked where SubjectID = @SubjectID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[Subject_IncidentServices_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Subject_IncidentServices_IU]--'1',
(
@SubjectID int=0,
@IncidentId int=0,
@CallTime datetime, 
@ArriveTime datetime, 
@ServiceBy varchar(50),
@ServiceFor varchar(50),
@Description ntext

)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin  
        DELETE FROM SubjectServices WHERE IncidentID = @IncidentId and SubjectID=@SubjectID
		Insert into SubjectServices(   
		SubjectID,   
		IncidentID, 
		CallTime, 
		ArriveTime, 
		ServiceBy,  
		ServiceFor,  
		Description
		)         
		values ( 
		@SubjectID, 
		@IncidentId,    
		@CallTime, 
		@ArriveTime, 
		@ServiceBy,
		@ServiceFor,
		@Description
	   
		)          
		  select @@IDENTITY    
     
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[Subject_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Subject_IU]-- 1,'68',5,'Female' ,'Asian','verma','naina','singh',5,87,null,'Balck','','','','','Bald' ,'true','false',null,null,'false',0  
@SubjectID int =0,  
@VIP nvarchar(200) = null,
@Age float = 0,
@Sex nvarchar(200) = null,
@Race nvarchar(200) = null,
@LastName nvarchar(200) = null,
@FirstName nvarchar(200) = null,
@MiddleName nvarchar(200) = null,
@Height nvarchar(200) = null,
@Weight nvarchar(200) = null,
@DateOfBirth datetime =null,
@HairColor nvarchar(200)= null,
@Eyes nvarchar(200)= null,
@Complexion nvarchar(200)= null,
@Build nvarchar(200)= null,
@FacialHair nvarchar(200)= null,
@HairLength nvarchar(200)= null,
@Glasses nvarchar(200)= null,
@Restricted bit ='false',
@Status nvarchar(200)= null,
@RoleName nvarchar(200)= null,
@CIDSubject bit ='false',
@CIDPersonID int = 0,
@CreatedBy int=0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@SubjectID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update Subjects set
			VIP = @VIP,
			Age =@Age,
			Sex = @Sex,
			Race = @Race,
			LastName = @LastName,
			FirstName =  @FirstName,
			MiddleName = @MiddleName,
			Height = @Height,
			Weight = @Weight,
			DateOfBirth = @DateOfBirth ,
			HairColor = @HairColor,
			Eyes =@Eyes,
			Complexion = @Complexion,
			Build = @Build,
			FacialHair = @FacialHair,
			HairLength =  @HairLength,
			Glasses = @Glasses,
			Restricted = @Restricted,
			Status = @Status,
			RoleName = @RoleName,
			CIDSubject = @CIDSubject,
			CIDPersonID = @CIDPersonID,
			ModifiedDate = getdate()	
			 where SubjectID = @SubjectID 
			select 1  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into Subjects(VIP ,Sex ,Race ,LastName,FirstName ,MiddleName ,Height,	
									Weight,	Age,DateOfBirth  ,HairColor ,Eyes,	Complexion ,
									Build ,FacialHair ,HairLength ,Glasses ,Restricted ,
									Status ,RoleName ,CIDSubject ,CIDPersonID ,ModifiedDate,CreatedBy) 
			values (@VIP,@Sex ,@Race ,@LastName,@FirstName ,@MiddleName ,@Height,	
									@Weight,	@Age,@DateOfBirth, @HairColor ,@Eyes,	@Complexion ,
									@Build ,@FacialHair ,@HairLength ,@Glasses ,@Restricted ,
									@Status ,@RoleName ,@CIDSubject ,@CIDPersonID ,getdate(),@CreatedBy)          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[Subject_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Subject_LoadById]     
@SubjectID int ,@ReportAccessRole INT,@UserID INT
AS             
BEGIN   
DECLARE @editpermission bit = 0;
DECLARE @deletepermission BIT= 0;
  Begin Try            
   Begin Transaction 
    Begin 
     IF(
           (
               SELECT COUNT(*)
               FROM Users
               WHERE IsAdmin = 1
                     AND ID = @UserID
           ) > 0) 
		 BEGIN 
		 SET @editpermission = 1;
		 SET @deletepermission = 1; 
		 END;

		 WITH cteeditPermission
              AS (
		    SELECT ISNULL(RP.SubjectID,UP.SubjectID) AS SubjectID
			 FROM
			 (SELECT SubjectID,EditReport, 1 AS ByRole
			 FROM SubjectAccessByRole
			 WHERE ReportAccessRole = @ReportAccessRole
				AND EditReport = '1' AND SubjectID = @SubjectID
				) AS RP
			 FULL JOIN     
				 (SELECT SubjectID,EditReport, 2 ByUser
							  FROM SubjectAccessUsers
							  WHERE ReportAccessBy = @UserID
							  AND EditReport = '1' AND SubjectID = @SubjectID
								   ) AS UP ON RP.SubjectID = UP.SubjectID
			 WHERE (RP.EditReport = 1 AND UP.EditReport = 1) 
			 --OR (RP.EditReport = 1 AND UP.SubjectID IS NULL)
			 OR(UP.EditReport = 1 AND RP.SubjectID IS NULL)),

			  ctedeletePermission
              AS (
		    SELECT ISNULL(RP.SubjectID,UP.SubjectID) AS SubjectID
			 FROM
			 (SELECT SubjectID,DeleteReport, 1 AS ByRole
			 FROM SubjectAccessByRole
			 WHERE ReportAccessRole = @ReportAccessRole
				AND DeleteReport = '1' AND SubjectID = @SubjectID
				) AS RP
			 FULL JOIN     
				 (SELECT SubjectID,DeleteReport, 2 ByUser
							  FROM SubjectAccessUsers
							  WHERE ReportAccessBy = @UserID
							  AND DeleteReport = '1' AND SubjectID = @SubjectID
								   ) AS UP ON RP.SubjectID = UP.SubjectID
			 WHERE (RP.DeleteReport = 1 AND UP.DeleteReport = 1) 
			 --OR (RP.EditReport = 1 AND UP.SubjectID IS NULL)
			 OR(UP.DeleteReport = 1 AND RP.SubjectID IS NULL))

		select Subjects.*,(CASE WHEN @editpermission = 1 THEN @editpermission ELSE 
			 (CASE WHEN (SELECT COUNT(*) FROM cteeditPermission) > 0 THEN 1 ELSE 0 END) END)
			  AS EditPermission,(CASE
                          WHEN @deletepermission = 1
                          THEN @deletepermission
                          ELSE(CASE
                                   WHEN
                              (
                                  SELECT COUNT(*)
                                  FROM ctedeletePermission
                              ) > 0
                                   THEN 1
                                   ELSE 0
                               END)
                      END) AS deletepermission 
				  from Subjects where SubjectID = @SubjectID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAccessPermission]
(
@ID int,
@SubjectID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update SubjectAccessUsers set ViewReport=@Permission where ID=@ID and SubjectID=@SubjectID
	 End
	 if(@Type='Edit')
	 Begin
	  Update SubjectAccessUsers set EditReport=@Permission where ID=@ID and SubjectID=@SubjectID
	 End
	 if(@Type='Delete')
	 Begin
	  Update SubjectAccessUsers set DeleteReport=@Permission where ID=@ID and SubjectID=@SubjectID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[SubjectAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAccessPermission_ByRole]
(
@ID int,
@SubjectID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from SubjectAccessByRole where ID=@ID and SubjectID=@SubjectID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAccessPermission_ByUser]
(
@ID int,
@SubjectID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from SubjectAccessUsers where ID=@ID and SubjectID=@SubjectID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAccessPermissionByRole]
(
@ID int,
@SubjectID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update SubjectAccessByRole set ViewReport=@Permission where ID=@ID and SubjectID=@SubjectID
	 End
	 if(@Type='Edit')
	 Begin
	  Update SubjectAccessByRole set EditReport=@Permission where ID=@ID and SubjectID=@SubjectID
	 End
	 if(@Type='Delete')
	 Begin
	  Update SubjectAccessByRole set DeleteReport=@Permission where ID=@ID and SubjectID=@SubjectID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAccessRoles_Bind]
(
@UserID int,
@SubjectID int=0
)
AS             
BEGIN   
  Begin Try           
    Begin 
	   select ManageRoles.RoleName,
	   SubjectAccessByRole.* from SubjectAccessByRole
	   left join ManageRoles on ManageRoles.RoleId=SubjectAccessByRole.ReportAccessRole
	   where SubjectID=@SubjectID and RoleName <> 'Administrator';
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAccessUsers_Bind]
(
@UserID int,
@SubjectID int = 0
)
AS             
BEGIN   
  Begin Try           
    Begin 

		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		SubjectAccessUsers.* from SubjectAccessUsers
		left join Users on Users.ID=SubjectAccessUsers.ReportAccessBy
		where SubjectID = @SubjectID
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectAddress_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAddress_DeleteById]     
@AddressID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from SubjectAddress where AddressID = @AddressID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectAddress_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectAddress_IU]     
@AddressID int =0,  
@SubjectID int=0,
@IncidentID int= 0,
@Apartment nvarchar(200) = null,
@Address nvarchar(200) = null,
@CountryID int=0,
@City nvarchar(200) = null,
@ProvState nvarchar(200) = null,
@PostalZip nvarchar(200) = null,
@AddressType nvarchar(200) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@AddressID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update SubjectAddress set
			SubjectID = @SubjectID,
			IncidentID =@IncidentID,
			Apartment = @Apartment,
			CountryID=@CountryID,
			City = @City,
			ProvState = @ProvState,
			PostalZip =  @PostalZip,
			AddressType = @AddressType,
			Address = @Address,
			ModifiedDate = getdate() where AddressID = @AddressID 
			select 1  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into SubjectAddress(SubjectID ,IncidentID ,Apartment ,City,ProvState ,PostalZip ,AddressType,Address,ModifiedDate,CountryID) 
			values (@SubjectID,@IncidentID,@Apartment ,@City ,@ProvState,@PostalZip ,@AddressType ,@Address,getdate(),@CountryID)          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectAddress_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAddress_LoadById]     
@AddressID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *  from SubjectAddress where AddressID = @AddressID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectAddress_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAddress_LoadBySubjectId]  
@SubjectID int =0   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select AT.AddressType as AddressTypeName,SA.* from SubjectAddress as SA
		left join AddressType as AT on AT.Id=SA.AddressType
		where SubjectID = @SubjectID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectAlias_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAlias_DeleteById]     
@AliasID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from SubjectAlias where AliasID = @AliasID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectAlias_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAlias_IU]     
@AliasID int =0,  
@SubjectID int=0,
@NameType nvarchar(200) = null,
@FirstName nvarchar(200) = null,
@MiddleName nvarchar(200) = null,
@LastName nvarchar(200) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@AliasID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update SubjectAlias set
			SubjectID = @SubjectID,
			NameType = @NameType,
			FirstName =  @FirstName,
			MiddleName = @MiddleName,
			LastName = @LastName,
			DateEntered = getdate() where AliasID = @AliasID 
			select @AliasID  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into SubjectAlias(SubjectID ,NameType ,FirstName ,MiddleName,LastName ,DateEntered) 
			values (@SubjectID,@NameType,@FirstName ,@MiddleName ,@LastName,getdate())          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectAlias_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAlias_LoadById]     
@AliasID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from SubjectAlias where AliasID = @AliasID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectAlias_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectAlias_LoadBySubjectId]  
@SubjectID int =0   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select AliasNameType.NameType as ANameType ,SubjectAlias.* from SubjectAlias
		left join AliasNameType on AliasNameType.ID=SubjectAlias.NameType
		where SubjectID = @SubjectID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectBan_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectBan_DeleteById]     
@BannedID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from Banned 
 where BannedID = @BannedID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectBanType_LoadByIncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SubjectBanType_LoadByIncidentID]    
@IncidentId int=0,
@SubjecID int=0    
As    
BEGIN    
Select BanName From SubjectBanType Where SubjectID = @SubjecID AND IncidentID =@IncidentId
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectEmployeePicture_Insert]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
     
CREATE procedure [dbo].[SubjectEmployeePicture_Insert]
@ID int =0,          
@IncidentID int=0,          
@MediaID int =0,          
@QuestionID int =0,          
@Observation int =0,          
@MediaType nvarchar(200) =null,          
@Type nvarchar(200)=null          
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction                 
  if(@Type = 'Subject')          
  Begin          
   if Exists(Select * from SubjectPicturesVideos where SubjectID=@ID)        
    begin        
     update SubjectPicturesVideos set IncidentID=@IncidentID,MediaID=@MediaID,MediaType=@MediaType where SubjectID=@ID        
     select @@Rowcount as result        
    end        
   else        
    begin        
     insert into SubjectPicturesVideos(SubjectID,IncidentID,MediaID,MediaType)values (@ID,@IncidentID,@MediaID,@MediaType)          
     select @@identity as result          
    End         
  End       
            
  Else if(@Type = 'Employee')          
  Begin          
   if Exists(Select * from EmployeePicturesVideos where EmployeeID=@ID)        
    begin        
     update EmployeePicturesVideos set IncidentID=@IncidentID,MediaID=@MediaID,MediaType=@MediaType where EmployeeID=@ID        
     select @@Rowcount as result        
    end        
   else        
   begin        
    insert into EmployeePicturesVideos (EmployeeID,IncidentID,MediaID,MediaType) values (@ID,@IncidentID,@MediaID,@MediaType)          
    select @@identity as result          
   End           
  End       
           
  Else   if(@Type = 'Event')          
  Begin          
   if Exists(Select * from EventPicturesVideos where EventID=@ID)        
    begin        
     update EventPicturesVideos set MediaID=@MediaID,MediaType=@MediaType where EventID=@ID        
     select @@Rowcount as result        
    end        
   else        
    begin        
     insert into EventPicturesVideos(EventID,MediaID,MediaType)values (@ID,@MediaID,@MediaType)          
     select @@identity as result          
    End         
  End       
           
  Else  if(@Type = 'Features')          
  Begin          
   if Exists(Select * from FeaturePicturesVideos where FeatureID=@ID)        
    begin        
     update FeaturePicturesVideos set IncidentID=@IncidentID,MediaID=@MediaID,MediaType=@MediaType where FeatureID=@ID        
     select @@Rowcount as result        
    end        
   else        
    begin        
     insert into FeaturePicturesVideos(FeatureID,IncidentID,MediaID,MediaType)values (@ID,@IncidentID,@MediaID,@MediaType)          
     select @@identity as result          
    End         
  End   
   
  Else  if(@Type = 'Vehicles')          
  Begin          
   if Exists(Select * from VehiclesPicturesVideos where VehiclesID=@ID)        
    begin        
     update VehiclesPicturesVideos set IncidentID=@IncidentID,MediaID=@MediaID,MediaType=@MediaType where VehiclesID=@ID        
     select @@Rowcount as result        
    end        
   else        
    begin        
     insert into VehiclesPicturesVideos(VehiclesID,IncidentID,MediaID,MediaType)values (@ID,@IncidentID,@MediaID,@MediaType)          
     select @@identity as result          
    End         
  End           
         
  Else if(@Type = 'EmpReport')          
  Begin          
   if Exists(Select * from EmployeePicturesVideos where EmployeeID=@ID  and IncidentID=@IncidentID)        
    begin
     update EmployeePicturesVideos set MediaID=@MediaID,MediaType=@MediaType where EmployeeID=@ID and IncidentID=@IncidentID  
     select @@Rowcount as result        
    end        
   else        
   begin        
    insert into EmployeePicturesVideos (EmployeeID,IncidentID,MediaID,MediaType) values (@ID,@IncidentID,@MediaID,@MediaType)          
    select @@identity as result          
   End           
  End          
          
  COMMIT TRANSACTION                 
End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[SubjectIdentification_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectIdentification_IU]  
@ID int=0,   
@SubjectID int =0,  
@Occupation nvarchar(200) = null,
@BusinessName nvarchar(200)  = null,
@IDType1 nvarchar(200) = null,
@IDNumber1 nvarchar(200) = null,
@IDDefault1 bit = 'false',
@IDType2 nvarchar(200) = null,
@IDNumber2 nvarchar(200) = null,
@IDDefault2 bit = 'false',
@IDType3 nvarchar(200) = null,
@IDNumber3 nvarchar(200)= null,
@IDDefault3 bit = 'false',
@LCTID nvarchar(200)= null
AS             
BEGIN   
  Begin Try            
   Begin Transaction
   if(isnull(@LCTID,'') ='')
   begin
		set @LCTID=	(select convert(nvarchar,convert(int,SettingValue)) + 1 from ApplicationSettings where Setting = 'NextLCTIDSequential')
   end
   If(@ID > 0)
    Begin 
			--update ApplicationSettings set SettingValue = @LCTID  where Setting = 'NextLCTIDSequential'
			update SubjectIdentification set
			SubjectID = @SubjectID,
			Occupation =@Occupation,
			BusinessName = @BusinessName,
			IDType1 = @IDType1,
			IDNumber1 = @IDNumber1,
			IDDefault1 =  @IDDefault1,
			IDType2 = @IDType2,
			IDNumber2 = @IDNumber2,
			IDDefault2 = @IDDefault2,
			IDType3 = @IDType3,
			IDNumber3 = @IDNumber3,
			IDDefault3 = @IDDefault3,
			LCTID = @LCTID where ID = @ID 
			select @ID  
	End 
    Else
	Begin
			update ApplicationSettings set SettingValue = @LCTID  where Setting = 'NextLCTIDSequential'
			Insert into SubjectIdentification(SubjectID,Occupation,BusinessName,IDType1,
			IDNumber1,IDDefault1,IDType2,IDNumber2,IDDefault2,IDType3,IDNumber3,IDDefault3,LCTID) 
			values (@SubjectID,@Occupation,@BusinessName,@IDType1,@IDNumber1,@IDDefault1,@IDType2,
			@IDNumber2,@IDDefault2,@IDType3,@IDNumber3,@IDDefault3,@LCTID)          
			select @@IDENTITY
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectIdentification_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectIdentification_LoadBySubjectId]  
@SubjectID int =0   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select ID as Idss ,*  from SubjectIdentification where SubjectID = @SubjectID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectIDMax_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SubjectIDMax_Load]  -- 1  

AS             
BEGIN   
declare @SubjectID int
  Begin Try            
   Begin Transaction 
    Begin 
   
	  select @SubjectID=Max(SubjectID)+1 from Subjects

	   if(@SubjectID is null)
	   begin
	  set @SubjectID=1
	   end 

	  SELECT RIGHT('00000'+ CONVERT(VARCHAR(6),@SubjectID),5)
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectIncident_Permission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectIncident_Permission]
@Id int=0
AS
BEGIN
	select ReportEdit,ReportDelete from Incidents where IncidentID=@Id
	select @@rowcount
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectIncidentsMax_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SubjectIncidentsMax_Load]  -- 1  

AS             
BEGIN   
declare @IncidentID int
  Begin Try            
   Begin Transaction 
    Begin 
   
	  select @IncidentID=Max(IncidentID)+1 from SubjectIncidents
	   if(@IncidentID is null)
	   begin
	  set @IncidentID=1
	   end 

	  SELECT RIGHT('00000'+ CONVERT(VARCHAR(6),@IncidentID),5)
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectInvolve_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubjectInvolve_I]
(
@IncidentId int=0,
@SubjectID int=0,
@InvolvedID int=0,  
@MediaID int=0,
@InvolvedRole int=0,
@IsEmployee bit,
@CreatedBy int
)
AS
BEGIN           
  Begin Try 
   Begin Transaction         
    declare @set1 int
	declare @set2 int 
	 Begin 
	  set @set1=(Select Count(*) FROM SubjectInvolved WHERE IncidentID = @IncidentId and SubjectID=@SubjectID and InvolvedID=@InvolvedID and IsEmployee=@IsEmployee);
	   if(@set1>0)
		begin
		 DELETE FROM SubjectInvolved WHERE IncidentID = @IncidentId and SubjectID=@SubjectID and InvolvedID=@InvolvedID and IsEmployee=@IsEmployee
		END
       Insert into SubjectInvolved(SubjectID, IncidentID,InvolvedID,MediaID ,InvolvedRole,IsEmployee)
	    values(@SubjectID,@IncidentId,@InvolvedID,@MediaID ,@InvolvedRole,@IsEmployee)      
	   select @@IDENTITY  

	 set @set2=(Select COUNT(*) from SubReportsLink WHERE SubjectID=@SubjectID and ReportID = @IncidentId and ReportLinkWith=@InvolvedID and FetchDetailsBy=@IsEmployee)
	  if(@set2>0)  
	   begin  
		DELETE FROM SubReportsLink WHERE SubjectID=@SubjectID and ReportID = @IncidentId and ReportLinkWith=@InvolvedID and FetchDetailsBy=@IsEmployee
	   END            
		insert into SubReportsLink(SubjectID,ReportID,ReportLinkWith,CreatedBy,ModifiedDate,LinkWithReport,FetchDetailsBy)
			values(@SubjectID,@IncidentId,@InvolvedID,@CreatedBy,getdate(),1,@IsEmployee)
		select @@IDENTITY
      End         
    COMMIT TRANSACTION         
   End try            
  Begin Catch                 
  IF @@TRANCOUNT >0                 
   Select ERROR_MESSAGE()        
   Rollback Transaction          
   EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectInvolved_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubjectInvolved_Delete]
(
@ID int=0,
@ReportID int
)
AS
Begin
  Begin Try                      
   Begin Transaction  
	Delete from SubjectInvolved where ID=@ID
	Delete from SubReportsLink where ReportID=@ReportID
	select @@IDENTITY  
   Commit Transaction
  End Try 
  Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch 
End

GO
/****** Object:  StoredProcedure [dbo].[SubjectInvolved_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubjectInvolved_I]    
(  
@ID int=0,
@CreatedBy Int=0,
@InvolvedID int=0,
@SubjectID int=0,     
@IncidentID int=0,   
@FirstName nvarchar(25)=null,   
@LastName nvarchar(25)=Null,   
@Race nvarchar(25)=Null,   
@Sex nvarchar(10)=null,   
@RoleName nvarchar(50)=null,   
@MediaID int=0
)    
AS    
Begin    
  Begin Try                          
   Begin Transaction 
    if(@ID > 0)
     begin
	  update Subjects set FirstName=@FirstName, LastName=@LastName, Race=@Race, Sex=@Sex, Restricted=0, RoleName=@RoleName  where SubjectID=@InvolvedID 
	   Select @@Rowcount
	  update  SubjectInvolved set InvolvedRole=@RoleName where InvolvedID=@InvolvedID 
	   Select @@Rowcount
     end   
    else
     begin
	  INSERT INTO Subjects (FirstName, LastName, Race, Sex, Restricted, RoleName,CreatedBy,ModifiedDate,VIP)   
	   VALUES(@FirstName,@LastName,@Race,@Sex,0,@RoleName,@CreatedBy,getdate(),DATEDIFF(second,{d '1970-01-01'},getdate()))  	   
	   select @InvolvedID=@@IDENTITY  	
	  Insert Into SubjectInvolved(SubjectID, IncidentID, InvolvedID, MediaID, InvolvedRole, IsEmployee)
	   values(@SubjectID, @IncidentID, @InvolvedID, @MediaID, @RoleName, 0)    
	  select @@IDENTITY  
     end
   Commit Transaction    
  End Try     
  Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
  End Catch     
End 

GO
/****** Object:  StoredProcedure [dbo].[SubjectInvolved_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectInvolved_LoadAll]
(
@SubjectID int=0, 
@IncidentID int=0
)
AS
Begin 
 SELECT SubjectInvolved.ID,SubjectInvolved.InvolvedID, Subjects.FirstName, Subjects.LastName, Subjects.Sex, Subjects.Race,
  MasterRole.Id as RoleID,MasterRole.Role as RoleName , SubjectInvolved.IsEmployee FROM Subjects 
  INNER JOIN SubjectInvolved ON Subjects.SubjectID = SubjectInvolved.InvolvedID 
  LEFT JOIN MasterRole on MasterRole.Id=SubjectInvolved.InvolvedRole
 WHERE SubjectInvolved.SubjectID = @SubjectID And SubjectInvolved.IncidentID = @IncidentID And SubjectInvolved.IsEmployee = 0 
 UNION
 SELECT SubjectInvolved.ID,SubjectInvolved.InvolvedID, Employees.FirstName, Employees.LastName, Employees.Sex, Employees.Race, 
  MasterRole.Id as RoleID,MasterRole.Role as RoleName, SubjectInvolved.IsEmployee FROM Employees 
  INNER JOIN SubjectInvolved ON Employees.EmployeeID = SubjectInvolved.InvolvedID 
  LEFT JOIN MasterRole on MasterRole.Id=SubjectInvolved.InvolvedRole
 WHERE SubjectInvolved.SubjectID = @SubjectID AND SubjectInvolved.IncidentID = @IncidentID AND SubjectInvolved.IsEmployee = 1
End

GO
/****** Object:  StoredProcedure [dbo].[SubjectLCT_CheckAddress]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubjectLCT_CheckAddress]
@SubjectID int
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    SELECT Address, City FROM SubjectAddress 
	WHERE SubjectID=@SubjectID and ModifiedDate = (SELECT Max(ModifiedDate)
	FROM SubjectAddress WHERE SubjectID = @SubjectID) and Address IS NOT NULL and City IS NOT NULL
	SELECT LCTID FROM SubjectIdentification WHERE SubjectID=@SubjectID
	select @@RowCount as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[SubjectLinked_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectLinked_DeleteById]     
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from SubjectLinked where ID = @ID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectLinked_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectLinked_IU]   
@ID int =0,
@IncidentID int =0,  
@SubjectID int=0,
@Description nvarchar(max) = null,
@FilePath nvarchar(max) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@ID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update SubjectLinked set
			SubjectID = @SubjectID,
			IncidentID = @IncidentID,
			Description = @Description,
			FilePath = @FilePath  where ID = @ID 
			select @ID  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into SubjectLinked(SubjectID ,IncidentID ,Description ,FilePath) 
			values (@SubjectID,@IncidentID ,@Description ,@FilePath)          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectLinked_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectLinked_LoadById]  -- 1  
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from SubjectLinked where ID = @ID 
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectLinked_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectLinked_LoadBySubjectId]    
@SubjectID int =0
    
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
  
     select *  from SubjectLinked where SubjectID = @SubjectID 
  
  select @@RowCount  
 End   
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectLinked_LoadBySubjectId_IncidentID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SubjectLinked_LoadBySubjectId_IncidentID]    
@SubjectID int =0,
@IncidentID int=0    
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin   
  
     select *  from SubjectLinked where SubjectID = @SubjectID and IncidentID=@IncidentID
  
  select @@RowCount  
 End   
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectMark_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectMark_IU]   
@MarkID int =0,
@MediaID  int =0,
@SubjectID int=0,
@FeatureType nvarchar(200) = null,
@Description nvarchar(max) = null,
@FeatureLocation nvarchar(max) = null
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@MarkID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update SubjectMarks set
			SubjectID = @SubjectID,
			FeatureType = @FeatureType,
			FeatureLocation = @FeatureLocation,
			Description = @Description ,
			MediaID = @MediaID where MarkID = @MarkID 
			select @MarkID  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into SubjectMarks(SubjectID ,FeatureType ,FeatureLocation ,Description,MediaID) 
			values (@SubjectID,@FeatureType ,@FeatureLocation ,@Description,@MediaID)          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectMarks_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SubjectMarks_DeleteById]     
@MarkID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from SubjectMarks where MarkID = @MarkID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectMarks_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SubjectMarks_LoadById]     
@MarkID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from SubjectMarks where MarkID = @MarkID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectMarks_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectMarks_LoadBySubjectId]  
@SubjectID int =0   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select FT.ID as FeatureID,FT.FeatureType as FeatureType,SM.MarkID,SM.SubjectID,SM.Description,SM.MediaID,
			FL.ID as FLocationID,FL.FLocation as FeatureLocation,
			(select Top(1) PV.FilePath from FeaturePicturesVideos FPV
			left join PicturesVideos PV on FPV.MediaID = PV.MediaID 
			where FeatureID = SM.MarkID) as ImagePath from SubjectMarks as SM
			left join FeatureType as FT on FT.ID=SM.FeatureType
			left join FeatureLocation as FL on FL.ID=SM.FeatureLocation
			where SubjectID = @SubjectID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectPermission_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectPermission_LoadById]     
@SubjectID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select SubjectID, Users.UserName as ReportCreatorUser,Users.FirstName as ReportCreatorFirstName,
		  Users.LastName as ReportCreatorLastName,CreatedBy,createddate
		  ,Subjects.FirstName,Subjects.LastName,Subjects.MiddleName
		from Subjects 
		 inner join Users on Users.ID=Subjects.CreatedBy
		where SubjectID = @SubjectID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectReportEventsLink_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubjectReportEventsLink_Delete]     
@SubjectID int =0,
@IncidentID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
			DELETE FROM EventSubjectIncidents WHERE SubjectID = @SubjectID AND IncidentID = @IncidentID; 
			SELECT @@ROWCOUNT;   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectReportPermissionCheck_User]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectReportPermissionCheck_User] 
(
@ReportAccessBy int,
@ReportID int,
@SubjectID int,
@ReportAccessRole int
)
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
    declare @set1 int
	declare @set2 Bit 
	 Begin 		  
	  set @set1=(select COUNT(*) from SubReportsAccessUsers where ReportAccessBy=@ReportAccessBy and ReportID=@ReportID and SubjectID=@SubjectID)
	  if(@set1>0)  
	   begin  
	    set @set2=(select ViewReport from SubReportsAccessUsers where ReportAccessBy=@ReportAccessBy and ReportID=@ReportID and SubjectID=@SubjectID)
		if(@set2='1')
		 Begin
	      select * from SubReportsAccessUsers where ReportAccessBy=@ReportAccessBy and ReportID=@ReportID and SubjectID=@SubjectID
		 End
		Else
		 Begin           
		  select * from SubReportsAccessByRole where ReportAccessRole=@ReportAccessRole and ReportID=@ReportID and SubjectID=@SubjectID
		 End
	   END 
	  ELSE
	   Begin           
	    select * from SubReportsAccessByRole where ReportAccessRole=@ReportAccessRole and ReportID=@ReportID and SubjectID=@SubjectID
	   End
	  End           
    COMMIT TRANSACTION           
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END 


GO
/****** Object:  StoredProcedure [dbo].[Subjects_AdvancedSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Subjects_AdvancedSearch]                   
(
 @VIP nvarchar(100)=null,       
 @FirstName nvarchar(250)=null,                      
 @MiddleName nvarchar(250)=null,
 @LastName nvarchar(250)=null,                      
 @Sex nvarchar(250)=null,                      
 @Race nvarchar(250)=null, 
 @Eyes nvarchar(10)=null,
 @Build nvarchar(15)=null,
 @Complexion nvarchar(15)=null,                        
 @DateOfBirth datetime =null,   
 @HairLength nvarchar(25)=null,
 @HairColor nvarchar(15)=null,
 @FacialHair nvarchar(25)=null,
 @FromAge int = null,
 @ToAge	int = null
)                    
AS                    
BEGIN                    
    Declare @SQL nvarchar(max)    
	Set @SQL='SELECT SubjectID, FirstName, MiddleName,LastName,VIP,ms.sex as sex,(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath,ModifiedDate FROM Subjects 
		left Outer join MasterSex ms on ms.id = Subjects.Sex
		where SubjectID<>0 '       
   if(@FirstName<>'')          
    begin          
     set @SQL=@SQL + ' and FirstName like '''+@FirstName+'%'''           
    end          
   if(@LastName<>'')          
    begin          
     set @SQL=@SQL+' and LastName like '''+@LastName+'%'''          
    end
   if(@MiddleName<>'')          
    begin          
     set @SQL=@SQL+' and MiddleName like '''+@MiddleName+'%'''          
    end          
   if(@VIP<>'')          
    begin          
     set @SQL=@SQL+' and VIP = '''+@VIP +''''         
    end          
   if(@Sex<>'')          
    begin          
     set @SQL=@SQL+' and Subjects.Sex = '''+@Sex+''''          
    end  
   if(@Race<>'')          
    begin          
     set @SQL=@SQL+' and Race = '''+@Race+''''          
    end 
   if(@Eyes<>'')          
    begin          
     set @SQL=@SQL+' and Eyes = '''+@Eyes+''''          
    end 
   if(@Build<>'')          
    begin          
     set @SQL=@SQL+' and Build = '''+@Build+''''          
    end 
   if(@DateOfBirth<>'')          
    begin          
     set @SQL=@SQL+' and DateOfBirth = '''+@DateOfBirth+''''          
    end 
   if(@HairLength <> '' )          
    begin          
     set @SQL=@SQL+' and HairLength = '''+@HairLength+''''          
    end 
    --if(@HairLength IS NULL)          
    --begin          
    -- set @SQL=@SQL+' and HairLength IS NULL '          
    --end 
   if(@HairColor<>'')          
    begin          
     set @SQL=@SQL+' and DateOfBirth = '''+@HairColor+''''          
    end 
   if(@FacialHair<>'')          
    begin          
     set @SQL=@SQL+' and HairLength = '''+@FacialHair+''''          
    end  
     if(@FromAge IS NOT NULL AND @ToAge IS NOT NULL)          
    begin          
     set @SQL=@SQL+' AND Age BETWEEN ' + CAST (@FromAge AS Varchar) + ' AND ' +   CAST (@ToAge AS Varchar)       
    end  
        print(@SQL)    
      execute(@SQL)                  
END 

GO
/****** Object:  StoredProcedure [dbo].[Subjects_FirstNameSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Subjects_FirstNameSearch]
(  
 @FirstName nvarchar(25) = ''                  
)                  
AS                  
BEGIN                  
 BEGIN TRY                                                      
  BEGIN TRANSACTION
  DECLARE @query NVARCHAR(1000);      
    SET @query='SELECT (FirstName + '' '' + LastName) AS FirstName,SubjectID FROM Subjects WHERE FirstName LIKE ''' + @FirstName + '%'' GROUP BY FirstName,LastName,SubjectID ORDER BY FirstName' ;   
    --EXEC(@query)       
    DECLARE @ParameterDefinition AS NVARCHAR(100);
    SET @ParameterDefinition =  '@FirstName nvarchar(25)';
    Execute sp_Executesql @query,@ParameterDefinition,@FirstName;
  COMMIT TRANSACTION                  
 END TRY                                                    
 BEGIN CATCH                                                      
  IF @@TRANCOUNT >0                                       
   ROLLBACK TRANSACTION;              
	SELECT 1 AS result                   
    SELECT ERROR_MESSAGE() AS ErrorNumber; 
 END CATCH;                   
END



GO
/****** Object:  StoredProcedure [dbo].[Subjects_LastNameSearch]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Subjects_LastNameSearch]
(  
 @FirstName varchar(25) = null,
 @LastName varchar(25) = ''                    
)                  
AS                  
BEGIN                  
 BEGIN TRY                                                      
  BEGIN TRANSACTION
  DECLARE @query NVARCHAR(1000); 
       IF(@FirstName IS NULL)
	  BEGIN
		 SET @query='SELECT LastName FROM Subjects WHERE LastName LIKE ''' + 
			   @LastName + '%'' GROUP BY LastName ORDER BY LastName' ; 
	  END
	  ELSE
	  BEGIN
		 SET @query='SELECT LastName FROM Subjects WHERE FirstName LIKE ''' + @FirstName + '%'' AND LastName LIKE ''' + 
			 @LastName + '%'' GROUP BY LastName ORDER BY LastName' ;   
	  END	   
    --EXEC(@query)     
      DECLARE @ParameterDefinition AS NVARCHAR(100);
    SET @ParameterDefinition =  '@FirstName nvarchar(25),@LastName nvarchar(25)';
    Execute sp_Executesql @query,@ParameterDefinition,@FirstName,@LastName;  
  COMMIT TRANSACTION                  
 END TRY                                                    
 BEGIN CATCH                                                      
  IF @@TRANCOUNT >0                                       
   ROLLBACK TRANSACTION;              
	SELECT 1 AS result                   
    SELECT ERROR_MESSAGE() AS ErrorNumber; 
 END CATCH;                   
END



GO
/****** Object:  StoredProcedure [dbo].[Subjects_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Subjects_LoadAll](@UserID           INT,
                                         @ReportAccessRole INT = 0)
AS
     BEGIN
         BEGIN TRY
             BEGIN TRANSACTION;
             BEGIN
                 IF(
                   (
                       SELECT COUNT(*)
                       FROM Users
                       WHERE IsAdmin = 1
                             AND ID = @UserID
                   ) > 0)
                     BEGIN
                         SELECT *,
                         (
                             SELECT TOP (1) PV.FilePath
                             FROM SubjectPicturesVideos SPV
                                  LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                             WHERE SubjectID = Subjects.SubjectID
                         ) AS FilePath
                         FROM Subjects
                         ORDER BY CreatedDate DESC;
                     END;
                 ELSE
                     BEGIN
                         WITH cteReportPermission
                              AS(SELECT ISNULL(RP.SubjectID, UP.SubjectID) AS SubjectID
                                 FROM
                                 (
                                     SELECT SubjectID,
                                            ViewReport,
                                            1 AS ByRole
                                     FROM SubjectAccessByRole
                                     WHERE ReportAccessRole = @ReportAccessRole
                                           AND ViewReport = '1'
                                 ) AS RP
                                 FULL JOIN
                                 (
                                     SELECT SubjectID,
                                            ViewReport,
                                            2 ByUser
                                     FROM SubjectAccessUsers
                                     WHERE ReportAccessBy = @UserID
                                           AND ViewReport = '1'
                                 ) AS UP ON RP.SubjectID = UP.SubjectID
                                 WHERE(RP.ViewReport = 1
                                       AND UP.ViewReport = 1)
                                      --OR (RP.ViewReport = 1
                                      --    AND UP.SubjectID IS NULL)
                                      OR (UP.ViewReport = 1
                                          AND RP.SubjectID IS NULL))

                              SELECT *,
                              (
                                  SELECT TOP (1) PV.FilePath
                                  FROM SubjectPicturesVideos SPV
                                       LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                                  WHERE SubjectID = Subjects.SubjectID
                              ) AS FilePath
                              FROM Subjects
                              WHERE CreatedBy = @UserID
                                    OR SubjectID IN
                              (
                                  SELECT SubjectID
                                  FROM cteReportPermission
                              )
                              ORDER BY CreatedDate DESC;
                     END;
                         --SELECT *,
                         --(
                         --    SELECT TOP (1) PV.FilePath
                         --    FROM SubjectPicturesVideos SPV
                         --         LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                         --    WHERE SubjectID = Subjects.SubjectID
                         --) AS FilePath
                         --FROM Subjects
                         --WHERE CreatedBy = @UserID
                         --      OR SubjectID IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessUsers
                         --    WHERE ReportAccessBy = @UserID
                         --          AND ViewReport = '1'
                         --          AND ReportID = 0
                         --)
                         --      OR SubjectID IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessByRole
                         --    WHERE ReportAccessRole = @ReportAccessRole
                         --          AND ViewReport = '1'
                         --          AND ReportID = 0
                         --)
                         --UNION
                         --SELECT *,
                         --(
                         --    SELECT TOP (1) PV.FilePath
                         --    FROM SubjectPicturesVideos SPV
                         --         LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                         --    WHERE SubjectID = Subjects.SubjectID
                         --) AS FilePath
                         --FROM Subjects
                         --WHERE subjectID IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessByRole
                         --    WHERE isnull(ViewReport, 0) = 0
                         --          AND isnull(EditReport, 0) = 0
                         --          AND isnull(DeleteReport, 0) = 0
                         --          AND ReportID = 0
                         --)
                         --      AND subjectID IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessUsers
                         --    WHERE isnull(ViewReport, 0) = 0
                         --          AND isnull(EditReport, 0) = 0
                         --          AND isnull(DeleteReport, 0) = 0
                         --          AND ReportID = 0
                         --)
                         --UNION
                         --SELECT *,
                         --(
                         --    SELECT TOP (1) PV.FilePath
                         --    FROM SubjectPicturesVideos SPV
                         --         LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                         --    WHERE SubjectID = Subjects.SubjectID
                         --) AS FilePath
                         --FROM Subjects
                         --WHERE subjectID NOT IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessByRole
                         --)
                         --      AND subjectID NOT IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessUsers
                         --)
                         --UNION
                         --SELECT *,
                         --(
                         --    SELECT TOP (1) PV.FilePath
                         --    FROM SubjectPicturesVideos SPV
                         --         LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                         --    WHERE SubjectID = Subjects.SubjectID
                         --) AS FilePath
                         --FROM Subjects
                         --WHERE subjectID NOT IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessByRole
                         --)
                         --      AND subjectID IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessUsers
                         --    WHERE isnull(ViewReport, 0) = 0
                         --          AND isnull(EditReport, 0) = 0
                         --          AND isnull(DeleteReport, 0) = 0
                         --          AND ReportID = 0
                         --)
                         --UNION
                         --SELECT *,
                         --(
                         --    SELECT TOP (1) PV.FilePath
                         --    FROM SubjectPicturesVideos SPV
                         --         LEFT JOIN PicturesVideos PV ON SPV.MediaID = PV.MediaID
                         --    WHERE SubjectID = Subjects.SubjectID
                         --) AS FilePath
                         --FROM Subjects
                         --WHERE subjectID NOT IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessUsers
                         --)
                         --      AND subjectID IN
                         --(
                         --    SELECT SubjectID
                         --    FROM SubReportsAccessByRole
                         --    WHERE isnull(ViewReport, 0) = 0
                         --          AND isnull(EditReport, 0) = 0
                         --          AND isnull(DeleteReport, 0) = 0
                         --          AND ReportID = 0
                         --)
                         ----if((select count(*) from Users where IsAdmin=1 and ID=@UserID)>0)
                         ----	begin
                         ----		select *,
                         ----		(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
                         ----		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath  from Subjects
                         ----	end
                         ----else
                         ----	begin
                         ----		select *,
                         ----		(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
                         ----		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath  from Subjects where CreatedBy=@UserID
                         ----	end
                         --ORDER BY ModifiedDate DESC;
             END;
             COMMIT TRANSACTION;
         END TRY
         BEGIN CATCH
             IF @@TRANCOUNT > 0
                 SELECT ERROR_MESSAGE();
             ROLLBACK TRANSACTION;
             EXECUTE [uspLogError];
         END CATCH;
     END;
GO
/****** Object:  StoredProcedure [dbo].[Subjects_LoadAllBackup]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Subjects_LoadAllBackup]   
(@UserID int,
@ReportAccessRole int = 0
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *,
			(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath  from Subjects
	 where	CreatedBy=@UserID or 
			SubjectID in (Select SubjectID from SubReportsAccessUsers    
	  where ReportAccessBy=@UserID and ViewReport='1' and ReportID = 0)
	  or SubjectID in (Select SubjectID from SubReportsAccessByRole    
	  where ReportAccessRole=@ReportAccessRole and ViewReport='1' and ReportID = 0)
	  union
		select *,
			(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath from Subjects where subjectID in (Select SubjectID from SubReportsAccessByRole where isnull(ViewReport,0) = 0 and isnull(EditReport,0) =0  and isnull(DeleteReport,0)=0 and ReportID = 0)
		and subjectID in (Select SubjectID from SubReportsAccessUsers where isnull(ViewReport,0) = 0 and isnull(EditReport,0) =0  and isnull(DeleteReport,0)=0 and ReportID = 0)
		union
		select *,
			(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath from Subjects where subjectID not in (Select SubjectID from SubReportsAccessByRole) and subjectID not in (Select SubjectID from SubReportsAccessUsers) 
		union 
		select *,
			(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath from Subjects where subjectID not in (Select SubjectID from SubReportsAccessByRole) and subjectID in (Select SubjectID from SubReportsAccessUsers where isnull(ViewReport,0) = 0 and isnull(EditReport,0) =0  and isnull(DeleteReport,0)=0 and ReportID = 0)
		union 
	    select *,
			(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath from Subjects where subjectID not in (Select SubjectID from SubReportsAccessUsers) and subjectID in (Select SubjectID from SubReportsAccessByRole where isnull(ViewReport,0) = 0 and isnull(EditReport,0) =0  and isnull(DeleteReport,0)=0 and ReportID = 0)

		--if((select count(*) from Users where IsAdmin=1 and ID=@UserID)>0)
		--	begin
		--		select *,
		--		(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		--		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath  from Subjects
		--	end
		--else
		--	begin
		--		select *,
		--		(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		--		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath  from Subjects where CreatedBy=@UserID
		--	end
		order By ModifiedDate desc
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[Subjects_Search]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Subjects_Search]
(  
 @FirstName nvarchar(250),                    
 @LastName nvarchar(250),                    
 @Sex nvarchar(250),                    
 @Race nvarchar(250)             
)                  
AS                  
BEGIN                  
 BEGIN TRY                                                      
  BEGIN TRANSACTION
       
    declare @query nvarchar(max);      
    declare @where nvarchar(max);     
    set @where='Where 1=1'     
                     
      if(@FirstName<>'')        
	   begin        
	    set @where=@where + ' and FirstName like '''+@FirstName+'%'''         
	   end        
      if(@LastName<>'')        
       begin        
        set @where=@where+' and LastName like '''+@LastName+'%'''        
       end        
	  if(@Sex<>'')        
       begin        
        set @where=@where+' and Sex = '''+@Sex +''''
       end        
      if(@Race<>'')        
       begin        
        set @where=@where+' and Race = '''+@Race+''''       
       end 
     
     set @query='SELECT SubjectID, FirstName, MiddleName, LastName, Status FROM Subjects '+@Where+''    
     --print @query
     exec(@query)       
  COMMIT TRANSACTION                  
 END TRY                                                    
 BEGIN CATCH                                                      
  IF @@TRANCOUNT >0                                       
   ROLLBACK TRANSACTION;              
	select 1 as result                   
    SELECT ERROR_MESSAGE() AS ErrorNumber; 
 END CATCH;                   
END


GO
/****** Object:  StoredProcedure [dbo].[SubjectServices_LoadbyIncidentSubjectID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SubjectServices_LoadbyIncidentSubjectID]  --1  
@SubjectId int=0,
@IncidentID int=0     
As    
BEGIN    
	SELECT CallTime, ArriveTime, ServiceBy, ServiceFor, Description FROM SubjectServices  Where SubjectID = @SubjectID And IncidentID =@IncidentID    
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectServicesOffered_I]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubjectServicesOffered_I]  --'14','17','WebServiceService','1','0'
(
@SubjectID int=0,
@IncidentId int=0,
@ServiceName varchar(50),
@Offered bit,
@Declined bit

)
AS
BEGIN           
  Begin Try                    
   Begin Transaction         
       
 Begin 
 --declare @ServiceName1 varchar(50),@SubjectID int=0,@IncidentId int=0

        --DELETE FROM SubjectServicesOffered WHERE IncidentID = @IncidentId and SubjectID=@SubjectID and ServiceName != @ServiceName
   --     if Exists(select ServiceName,IncidentID,SubjectID from SubjectServicesOffered WHERE IncidentID = @IncidentId and SubjectID=@SubjectID)
			--begin
			
			--update SubjectServicesOffered set Offered=@Offered,Declined=@Declined WHERE IncidentID = @IncidentId and SubjectID=@SubjectID and ServiceName=@ServiceName
			-- sElect @@Rowcount
			--end
   --     else
   --       begin
			DELETE FROM SubjectServicesOffered WHERE IncidentID = @IncidentId and SubjectID=@SubjectID and ServiceName = @ServiceName
				Insert into SubjectServicesOffered(   
				SubjectID,   
				IncidentID, 
				ServiceName, 
				Offered, 
				Declined
				)         
				values ( 
				@SubjectID, 
				@IncidentId,    
				@ServiceName,
				@Offered,
				@Declined
			   
				)          
				  select 1 as result    
       --end
 End         
  COMMIT TRANSACTION         
 End try            
 Begin Catch                 
  IF @@TRANCOUNT >0                 
          Select ERROR_MESSAGE()        
    Rollback Transaction          
    EXECUTE [uspLogError]                   
 End Catch                    
END

GO
/****** Object:  StoredProcedure [dbo].[SubjectServicesOffered_LoadbyIncidentSubjectID]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SubjectServicesOffered_LoadbyIncidentSubjectID]  --1  
@SubjectId int=0,
@IncidentID int=0     
As    
BEGIN    
	SELECT ServiceName, Offered, Declined FROM SubjectServicesOffered Where SubjectID = @SubjectID And IncidentID =@IncidentID    
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectWatch_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubjectWatch_IU]   
@xml XML=null ,  
@SubjectID int =0,  
@IsDelete bit='false'
AS             
BEGIN 
Declare @TempTable TABLE(    
Id int,  
WatchName nvarchar(200) 
);      
Declare @Id int      
Declare @WatchName nvarchar(200)   
  Begin Try            
   Begin Transaction 
   If(@IsDelete = 'false')  
      Begin          
       DECLARE cur cursor  for                   
		   SELECT tab.col.value('(Id/text())[1]', 'int'),              
		   tab.col.value('(watchId/text())[1]', 'nvarchar(200)')     
	       FROM @xml.nodes('//watchInfo') tab(col)                   
       open cur;                  
	   Fetch next from cur into @Id,@WatchName    
	   While 0=@@fetch_status    
		Begin    
			insert into @TempTable (Id,WatchName) values (@Id,@WatchName)  
			Fetch next from cur into @Id,@WatchName    
		End    
	   Close cur;                          
  Deallocate cur;     
   MERGE INTO SubjectWatch AS SW                         
   USING @TempTable AS temp ON ISNULL(SW.Id,0) = ISNULL(temp.Id,0)                 
                             
	   WHEN NOT MATCHED  THEN                   
		INSERT (WatchName,SubjectID)                  
		VALUES (temp.WatchName,@SubjectID)                     
	                   
	   WHEN MATCHED AND (temp.Id <> '' and                          
	   temp.Id =SW.Id) THEN    
		UPDATE SET SW.WatchName = temp.WatchName  
	  
	   WHEN  NOT MATCHED By SOURCE and SW.SubjectID = @SubjectID THEN     
	   DELETE   ;         
   select 1   
   
   End   
   Else  
	   Begin  
		   Delete from SubjectWatch where SubjectID = @SubjectID 
		   select 1   
	   End  

  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectWatch_LoadBySubjectId]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SubjectWatch_LoadBySubjectId]     
@SubjectID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from SubjectWatch where SubjectID = @SubjectID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[SubMenu_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
Create procedure [dbo].[SubMenu_LoadAll]
as
Begin
	Select * from SubMenu
end
GO
/****** Object:  StoredProcedure [dbo].[SubMenuPermission_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubMenuPermission_IU]
(
@SubMenus nvarchar(100),
@ParentID int,
@RoleID int
)
as 
Begin
	
	 Delete from ManageSubMenuPermissions where RoleID=@RoleID and ParentID=@ParentID
 Insert into ManageSubMenuPermissions (SubMenus,ParentID,RoleID) values(@SubMenus,@ParentID,@RoleID)
   
 select @@Rowcount
End
GO
/****** Object:  StoredProcedure [dbo].[SubMenuPermissions]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubMenuPermissions]
(@RoleID int)
as
Begin
	select * from ManageSubMenuPermissions where RoleID=@RoleID
END 
GO
/****** Object:  StoredProcedure [dbo].[SubReportAccessPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubReportAccessPermission]
(
@ID int,
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update SubReportsAccessUsers set ViewReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update SubReportsAccessUsers set EditReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update SubReportsAccessUsers set DeleteReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[SubReportAccessPermissionByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubReportAccessPermissionByRole]
(
@ID int,
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update SubReportsAccessByRole set ViewReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update SubReportsAccessByRole set EditReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update SubReportsAccessByRole set DeleteReport=@Permission where ID=@ID and ReportID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubReportCreatorPermission]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SubReportCreatorPermission]
(
@ReportID int,
@Type nvarchar(10),
@Permission bit
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	 if(@Type='View')
	 Begin
	  Update Incidents set ReportView=@Permission where IncidentID=@ReportID
	 End
	 if(@Type='Edit')
	 Begin
	  Update Incidents set ReportEdit=@Permission where IncidentID=@ReportID
	 End
	 if(@Type='Delete')
	 Begin
	  Update Incidents set ReportDelete=@Permission where IncidentID=@ReportID
	 End
	 select @@ROWCOUNT as Result
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubReportProofread_add]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubReportProofread_add](
@ProofreadID int,
@SubjectID int,
@ReportID int,
@ReportProofread bit,
@UserID int
)
AS  
BEGIN             
  Begin Try  
	if(@ProofreadID>0)
	 Begin
	  Update SubReportProofread set ReportProofread=@ReportProofread,UserID=@UserID,CreatedDate=getdate() 
	  where SubjectID=@SubjectID and ReportID=@ReportID;

	  Insert into SubReportProofread_log(SubjectID,ReportID,ReportProofread,UserID,CreatedDate)
	   values(@SubjectID,@ReportID,@ReportProofread,@UserID,getdate());

	  Select @@identity as Result
	 End
	Else
	 Begin
	  Insert into SubReportProofread(SubjectID,ReportID,ReportProofread,UserID,CreatedDate)
		values(@SubjectID,@ReportID,@ReportProofread,@UserID,getdate());

	   Insert into SubReportProofread_log(SubjectID,ReportID,ReportProofread,UserID,CreatedDate)
	   values(@SubjectID,@ReportID,@ReportProofread,@UserID,getdate());

	  Select @@identity as Result
	 End
	                    
     
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[SubReportProofread_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubReportProofread_Bind](
@SubjectID int,
@ReportID int
)
AS  
BEGIN             
  Begin Try                      
     select Users.UserName,Users.FirstName,Users.LastName,SubReportProofread.* from SubReportProofread 
	 left join Users on Users.ID=SubReportProofread.UserID
	 where SubjectID=@SubjectID and ReportID=@ReportID
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[SubReportProofread_Check]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubReportProofread_Check](
@SubjectID int,
@ReportID int
)
AS  
BEGIN             
  Begin Try   
	select * from SubReportProofread where SubjectID=@SubjectID and ReportID=@ReportID
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 

GO
/****** Object:  StoredProcedure [dbo].[SubReportProofread_Log_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SubReportProofread_Log_Bind](
@SubjectID int,
@ReportID int
)
AS  
BEGIN             
  Begin Try                      
     select Users.UserName,Users.FirstName,Users.LastName
	,CASE SL.ReportProofread WHEN 1 THEN 'Yes' ELSE 'No' END AS ReportProofread
	,SL.CreatedDate
	from SubReportProofread_Log AS SL
	 left join Users on Users.ID=SL.UserID
	 where SubjectID=@SubjectID and ReportID=@ReportID
   End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
    Select ERROR_MESSAGE()        
    EXECUTE [uspLogError]                     
 End Catch                      
END 


GO
/****** Object:  StoredProcedure [dbo].[SubReportsAccessPermission_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SubReportsAccessPermission_AddEdit] --0,28,52,16,'true','true','true',1
(
@ID int=0,
@SubjectID int=0,
@ReportID int=0,
@ReportAccessBy int=0,
@ReportView bit = 'false',
@ReportEdit bit = 'false',
@ReportDelete bit = 'false',
@CreatedBy int=0
)
as
begin
	if(Not Exists(select * from SubReportsAccessPermission where ID=@ID))
	begin
		Insert into SubReportsAccessPermission(SubjectID,ReportID,ReportAccessBy,ReportView,
			ReportEdit,ReportDelete,CreatedBy,ModifyDate) values(@SubjectID,@ReportID,
			@ReportAccessBy,@ReportView,@ReportEdit,@ReportDelete,@CreatedBy,getdate())		
		SELECT @@IDENTITY AS RESULT 
	end
	else
	begin
		Update SubReportsAccessPermission
			set ReportView=@ReportView,ReportEdit=@ReportEdit,ReportDelete=@ReportDelete,
			ModifyDate=getdate() where ID=@ID
		SELECT @@ROWCOUNT AS RESULT
	end
end


GO
/****** Object:  StoredProcedure [dbo].[SubReportsAccessPermission_ByRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubReportsAccessPermission_ByRole]
(
@ID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from SubReportsAccessByRole where ID=@ID and ReportID=@ReportID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubReportsAccessPermission_ByUser]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubReportsAccessPermission_ByUser]
(
@ID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try           
    Begin 
		select * from SubReportsAccessUsers where ID=@ID and ReportID=@ReportID
		Select @@RowCount as Result
	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubReportsAccessRoles_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubReportsAccessRoles_Bind]
(
@UserID int,
@ReportID int,
@SubjectID int=0
)
AS             
BEGIN   
  Begin Try           
    Begin 

	if(@SubjectID > 0)
	begin

		
		select ManageRoles.RoleName,
		SubReportsAccessByRole.* from SubReportsAccessByRole
		left join ManageRoles on ManageRoles.RoleId=SubReportsAccessByRole.ReportAccessRole
		where SubjectID=@SubjectID and ReportID = 0 AND RoleName <> 'Administrator';

	end
	else
	begin

		
		select ManageRoles.RoleName,
		SubReportsAccessByRole.* from SubReportsAccessByRole
		left join ManageRoles on ManageRoles.RoleId=SubReportsAccessByRole.ReportAccessRole
		where ReportID=@ReportID and CreatedBy=@UserID AND RoleName <> 'Administrator';

	end

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SubReportsAccessUsers_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubReportsAccessUsers_Bind]
(
@UserID int,
@ReportID int,
@SubjectID int = 0
)
AS             
BEGIN   
  Begin Try           
    Begin 

	if(@SubjectID > 0)
	begin

		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		SubReportsAccessUsers.* from SubReportsAccessUsers
		left join Users on Users.ID=SubReportsAccessUsers.ReportAccessBy
		where ReportID = 0 and SubjectID = @SubjectID
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
	end
	else
	begin

		select Users.UserName,Users.FirstName+' '+ Users.LastName as FullName,
		SubReportsAccessUsers.* from SubReportsAccessUsers
		left join Users on Users.ID=SubReportsAccessUsers.ReportAccessBy
		where ReportID=@ReportID and CreatedBy=@UserID
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
		end

	End 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
    Select ERROR_MESSAGE()
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[SuperAdminLogin]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SuperAdminLogin]    
(    
@UserName nvarchar(200),    
@Password nvarchar(50)    
)    
AS    
BEGIN    
 if exists(select * from SuperAdmin     
 where UserName=@UserName    
 and Password=@Password )  
 BEGIN  
 select *,1 AS Role from SuperAdmin     
 where UserName=@UserName    
 and Password=@Password 

 END   
 ELSE  
 BEGIN  
 SElect top 1 *,(SELECT Stuff(  
    (  
    SELECT ',' + p1.MenuName  
    FROM ManageMenus p1  
    where p1.Id in (Select * from CSVToTable(lc.Roles))  
    FOR XML PATH('')  
    ), 1, 1, '')) AS MenuNames,2 AS Role
     from Users u
join LicensedCustomers lc  on
u.ID = lc.UserID       
        
      where u.UserName=@UserName and u.Password=@Password  
       and u.IsAdmin=1 
 END  
END
GO
/****** Object:  StoredProcedure [dbo].[User_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[User_DeleteById]     
@ID int =0 
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from Users where ID = @ID
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[User_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[User_LoadById]       
@ID int =0   
AS               
BEGIN     
  Begin Try              
   Begin Transaction   
    Begin 
    Declare @Roles nvarchar(max) 
  select @Roles=COALESCE(''+@Roles + ',', '') + Convert(varchar(50),ur.RoleId) from  UserInRole ur   
   where ur.UserId = @ID 
     
  select *,@Roles as Roles from Users
   where ID = @ID  
 End   
    
  COMMIT TRANSACTION   
 End try      
 Begin Catch           
  IF @@TRANCOUNT >0           
          Select ERROR_MESSAGE()  
    Rollback Transaction    
    EXECUTE [uspLogError]             
 End Catch              
END
GO
/****** Object:  StoredProcedure [dbo].[UserGenReportsAccess_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UserGenReportsAccess_LoadAll]
(
@UserID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select
		(select ID from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as RepPerID,
		(select ReportId from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportId,
		(select ReportAccessBy from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportAccessBy,
		(select ReportView from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportView,
		(select ReportEdit from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportEdit,
		(select ReportDelete from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportDelete,
		(select CreatedBy from [dbo].[GenReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as CreatedBy,
		 id as UserID,FirstName,LastName,UserName from users where ID<>@UserID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[UserRole_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UserRole_DeleteById]
@ID int=0
AS
BEGIN
	If exists(Select * from UserInRole
	 where RoleId=@ID)
	 select -10
	 else 
	 begin
		DElete from ManagePermissions where RoleId=@ID
		DElete from ManageRoles  where RoleId=@ID
		
		select @@RowCount
	 end
END
GO
/****** Object:  StoredProcedure [dbo].[UserRoles_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[UserRoles_IU] 'Security Manger', 0
CREATE procedure [dbo].[UserRoles_IU]
(
@RoleName nvarchar(500)=null,
@Id int=0
)
AS
BEGIN
BEGIN TRY
BEGIN Transaction
	If(@Id>0)
	begin
		update ManageRoles 
		set RoleName=@RoleName
		where RoleId=@Id
		
		select @@RowCount
	end
	else
		if exists(Select * from ManageRoles where RoleName=@RoleName)
			select -10
			else
			begin
				Insert into ManageRoles
				values(@RoleName)

				Declare @newroleid int = (SELECT @@Identity);
				DECLARE @adminid int = (select top 1 ID from Users where IsAdmin = 1);

				--Insert all default view permissions for new role
				INSERT INTO ManagePermissions 
				SELECT @newroleid AS RoleId, Id AS MenuId, 2 AS PermissionType
				FROM ManageMenus;

				INSERT INTO EmployeeAccessByRole (EmployeeID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
				SELECT EmployeeID,@newroleid,@adminid,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
				FROM Employees;

				INSERT INTO EmpReportsAccessByRole (EmployeeID,ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
				SELECT EmployeeID,IncidentID,@newroleid,@adminid,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
				FROM EmpEmployeeIncidents;

				INSERT INTO SubjectAccessByRole (SubjectID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
				SELECT SubjectID,@newroleid,@adminid,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
				FROM Subjects;
				
				INSERT INTO SubReportsAccessByRole (SubjectID,ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
				SELECT SubjectID,IncidentID,@newroleid,@adminid,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
				FROM SubjectIncidents;

				INSERT INTO GenSubReportsAccessByRole (ReportID,ReportAccessRole,CreatedBy,CreatedDate,ViewReport,EditReport,DeleteReport)
				SELECT ReportID,@newroleid,@adminid,getdate() AS CreatedDate,1 AS ViewReport,0 AS EditReport, 0 AS DeleteReport
				FROM GeneralReport;

				SELECT @newroleid;
			end
		COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]   
		END CATCH	
END
GO
/****** Object:  StoredProcedure [dbo].[UserRoles_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UserRoles_LoadAll]
AS
BEGIN
	Select * from ManageRoles
END
GO
/****** Object:  StoredProcedure [dbo].[Users_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Users_IU]           
@ID int =0,        
@Password nvarchar(200) = null,      
@FirstName nvarchar(200)  = null,      
@LastName nvarchar(200) = null,      
@Initials nvarchar(200) = null,      
@UnitID int =0,      
@IsDispatchable bit = 'false',      
@UserCanChangePassword bit = 'false',      
@PasswordDate datetime = mull,      
@Email nvarchar(200) = null,      
@Skills nvarchar(200)= null,      
@RegNumber nvarchar(200)= null,    
@UserName nvarchar(50)=null , 
@UserGuid nvarchar(50)=null ,
  @Roles dbo.RolesType  READONLY    
AS                   
BEGIN         
  Begin Try                  
   Begin Transaction       
   If(@ID > 0)      
    Begin       
   If(Not Exists(Select * from Users where FirstName=@FirstName and ID != @ID))        
      Begin        
   update Users set   
       
   FirstName =@FirstName,      
   LastName = @LastName,      
   Initials = @Initials,      
   UnitID = @UnitID,      
   Skills =  @Skills,      
   IsDispatchable = @IsDispatchable,  
   [Password] = @Password,    
   PasswordDate = @PasswordDate,      
   UserCanChangePassword = @UserCanChangePassword, 
   UserGuid=@UserGuid,     
   Email = @Email where ID = @ID       
   select 1        
     End                  
      Else        
  Begin                  
        Select -10                  
     End                  
 End       
    Else      
 Begin      
   If(Not Exists(Select * from Users where FirstName = @FirstName))                  
  Begin       
   Insert into Users(Password,FirstName,LastName,Initials,      
   UnitID,Skills,IsDispatchable,PasswordDate,UserCanChangePassword,EMail,UserName,UserGuid   )       
   values (@Password,@FirstName,@LastName,@Initials,@UnitID,@Skills,@IsDispatchable,      
   @PasswordDate,@UserCanChangePassword,@Email,@UserName,@UserGuid)                
   select @ID=@@IDENTITY      
  End      
  Else      
  Begin      
   Select -10               
  End      
 End      
     
 Delete  from UserInRole where UserId=@ID    
 Insert into  UserInRole    
 Select @ID,RoleId from @Roles    
 Select @ID    
  COMMIT TRANSACTION       
 End try          
 Begin Catch               
  IF @@TRANCOUNT >0               
          Select ERROR_MESSAGE()      
    Rollback Transaction        
    EXECUTE [uspLogError]                 
 End Catch                  
END
GO
/****** Object:  StoredProcedure [dbo].[Users_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Users_LoadAll]   
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select *, isnull(Username,'')+', '+ isnull(firstname,'')+ '-'+ ISNULL(LastName,'') as FullName from Users 
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[UsersEmployeeAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersEmployeeAccess_Bind]
(
@UserID int,
@EmployeeID int 
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 

		Select id as UserID,FirstName+''+ LastName as FullName,UserName 
		from users 
		where ID<>@UserID and ID not in (
		Select ReportAccessBy from EmployeeAccessUsers where EmployeeID=@EmployeeID ) 
		AND ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

		
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[UsersEmployeeAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UsersEmployeeAccessRole]
(

@EmployeeID int=0
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 


		Select RoleId,RoleName from ManageRoles 
		where RoleId not in (select ReportAccessRole from EmployeeAccessByRole where EmployeeID=@EmployeeID )
		AND ManageRoles.RoleName <> 'Administrator'

	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[UsersEventReportsAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersEventReportsAccess_Bind]
(
@UserID int,
@EventID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		Select id as UserID,FirstName+''+ LastName as FullName,UserName from users where ID<>@UserID and ID not in (Select ReportAccessBy from EventReportsAccessUsers  where EventID=@EventID) 
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[UsersEventReportsAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersEventReportsAccessRole]
(
@EventID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		Select RoleId,RoleName from ManageRoles where RoleId not in (select ReportAccessRole from EventReportsAccessByRole where EventID=@EventID)
	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[UsersEventsAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UsersEventsAccess_Bind]
(
    @UserID int,
    @EventID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	
		Select id as UserID,FirstName + '' + LastName as FullName,UserName 
		from users 
		where ID <> @UserID and ID not in (Select EventAccessBy 
		from EventsAccessUsers 
		where EventID = @EventID and EventID <> 0) 
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[UsersEventsAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UsersEventsAccessRole]
(
@EventID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	
	   Select RoleId,RoleName from ManageRoles 
	   where RoleId not in (select EventAccessRole from EventsAccessByRole where EventID=@EventID and EventID <> 0)
	   AND RoleName <> 'Administrator';
		
	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END



GO
/****** Object:  StoredProcedure [dbo].[UsersGenSubReportsAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UsersGenSubReportsAccess_Bind]
(
    @UserID int,
    @ReportID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
	
		Select id as UserID,FirstName + '' + LastName as FullName,UserName 
		from users 
		where ID <> @UserID and ID not in (Select ReportAccessBy 
		from GenSubReportsAccessUsers 
		where ReportID = @ReportID and ReportID <> 0) 
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[UsersReportsAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersReportsAccess_Bind]
(
@UserID int,
@ReportID int,
@EmployeeID int = 0
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 

	if(@EmployeeID > 0)
	begin

		Select id as UserID,FirstName+''+ LastName as FullName,UserName 
		from users 
		where ID<>@UserID and ID not in (Select ReportAccessBy from EmpReportsAccessUsers where EmployeeID=@EmployeeID and reportid = 0) 
		AND ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
	end
	else
	begin

		Select id as UserID,FirstName+''+ LastName as FullName,UserName 
		from users 
		where ID<>@UserID and ID not in (Select ReportAccessBy from EmpReportsAccessUsers where ReportID=@ReportID and reportid <> 0) 
		AND ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

	end

		
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[UsersReportsAccess_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UsersReportsAccess_LoadAll]  
(
@UserID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select
		(select ID from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as RepPerID,
		(select EmployeeID from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as EmployeeID,
		(select ReportId from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportId,
		(select ReportAccessBy from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportAccessBy,
		(select ReportView from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportView,
		(select ReportEdit from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportEdit,
		(select ReportDelete from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportDelete,
		(select CreatedBy from [dbo].[EmpReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as CreatedBy,
		 id as UserID,FirstName,LastName,UserName from users where ID<>@UserID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[UsersReportsAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersReportsAccessRole]
(
@ReportID int,
@EmployeeID int=0
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 

	if @EmployeeID > 0
	begin

		Select RoleId,RoleName from ManageRoles 
		where RoleId not in (select ReportAccessRole from EmpReportsAccessByRole where EmployeeID=@EmployeeID and ReportID =0)
		AND ManageRoles.RoleName <> 'Administrator'
	end
	else
	begin

		Select RoleId,RoleName from ManageRoles 
		where RoleId not in (select ReportAccessRole from EmpReportsAccessByRole where ReportID=@ReportID)
		AND ManageRoles.RoleName <> 'Administrator'
	end

	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[UsersSubjectAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersSubjectAccess_Bind](@UserID    INT,
                                                 @SubjectID INT = 0)
AS
     BEGIN
         BEGIN TRY
             BEGIN TRANSACTION;
             BEGIN
                 SELECT id AS UserID,
                        FirstName+''+LastName AS FullName,
                        UserName
                 FROM users
                 WHERE ID <> @UserID
                       AND ID NOT IN
                 (
                     SELECT ReportAccessBy
                     FROM SubjectAccessUsers
                     WHERE SubjectID = @SubjectID
                 )
                       AND Users.ID NOT IN
                 (
                     SELECT UR.UserId
                     FROM UserInRole AS UR
                          INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId
                     WHERE MR.RoleName = 'Administrator'
                 );
             END;
             COMMIT TRANSACTION;
         END TRY
         BEGIN CATCH
             IF @@TRANCOUNT > 0
                 SELECT ERROR_MESSAGE();
             ROLLBACK TRANSACTION;
             EXECUTE [uspLogError];
         END CATCH;
     END;

GO
/****** Object:  StoredProcedure [dbo].[UsersSubjectAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UsersSubjectAccessRole]
(
    @SubjectID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 

		Select RoleId,RoleName from ManageRoles 
		where RoleId not in (select ReportAccessRole from SubjectAccessByRole where SubjectID=@SubjectID )
		AND RoleName <> 'Administrator';
	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END


GO
/****** Object:  StoredProcedure [dbo].[UsersSubjectReportsAccess_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersSubjectReportsAccess_LoadAll]  
(
@UserID int,
@ReportID int
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select
		(select ID from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as RepPerID,
		(select SubjectID from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as SubjectID,
		(select ReportId from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportId,
		(select ReportAccessBy from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportAccessBy,
		(select ReportView from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportView,
		(select ReportEdit from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportEdit,
		(select ReportDelete from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as ReportDelete,
		(select CreatedBy from [dbo].[SubReportsAccessPermission] E where Users.ID = E.[ReportAccessBy] and E.ReportID=@ReportID) as CreatedBy,
		 id as UserID,FirstName,LastName,UserName from users where ID<>@UserID
	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[UsersSubReportsAccess_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersSubReportsAccess_Bind]
(
@UserID int,
@ReportID int,
@SubjectID int = 0
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 

	if(@SubjectID > 0)
	begin

		Select id as UserID,FirstName+''+ LastName as FullName,UserName from users 
		where ID<>@UserID and ID not in (Select ReportAccessBy from SubReportsAccessUsers where SubjectID=@SubjectID and ReportID = 0) 
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');
	end
	else
	begin

		Select id as UserID,FirstName+''+ LastName as FullName,UserName from users 
		where ID<>@UserID and ID not in (Select ReportAccessBy from SubReportsAccessUsers where ReportID=@ReportID and ReportID <> 0) 
		AND Users.ID NOT IN (SELECT UR.UserId 
		  FROM UserInRole AS UR
		  INNER JOIN ManageRoles AS MR ON UR.RoleId = MR.RoleId 
		  WHERE MR.RoleName = 'Administrator');

	end

	End 
  
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[UsersSubReportsAccessRole]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsersSubReportsAccessRole]
(
@ReportID int,
@SubjectID int=0
)
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 

	if(@SubjectID > 0)
	begin
		Select RoleId,RoleName from ManageRoles 
		where RoleId not in (select ReportAccessRole from SubReportsAccessByRole where SubjectID=@SubjectID  and ReportID = 0)
		AND RoleName <> 'Administrator';
	end
	else
	begin
		Select RoleId,RoleName from ManageRoles 
		where RoleId not in (select ReportAccessRole from SubReportsAccessByRole where ReportID=@ReportID and ReportID <> 0)
		AND RoleName <> 'Administrator';
	end
		
	End   
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
/****** Object:  StoredProcedure [dbo].[USP_S_Master_tblState]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CReate PROCEDURE [dbo].[USP_S_Master_tblState]
@CountryId	int
AS
BEGIN
	SELECT * FROM Master_tblState where CountryID=@CountryId	
END

GO
/****** Object:  StoredProcedure [dbo].[USP_S_Mater_tblCountry]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CReate PROCEDURE [dbo].[USP_S_Mater_tblCountry]

AS
BEGIN
	SELECT * FROM Mater_tblCountry
END

GO
/****** Object:  StoredProcedure [dbo].[uspLogError]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- uspLogError logs error information in the ErrorLog table about the 
-- error that caused execution to jump to the CATCH block of a 
-- TRY...CATCH construct. This should be executed from within the scope 
-- of a CATCH block otherwise it will return without inserting error 
-- information. 
CREATE PROCEDURE [dbo].[uspLogError] 
    @ErrorLogID [int] = 0 OUTPUT -- contains the ErrorLogID of the row inserted
AS                               -- by uspLogError in the ErrorLog table
BEGIN
    SET NOCOUNT ON;

    -- Output parameter value of 0 indicates that error 
    -- information was not logged
    SET @ErrorLogID = 0;

    BEGIN TRY
        -- Return if there is no error information to log
        IF ERROR_NUMBER() IS NULL
            RETURN;

        -- Return if inside an uncommittable transaction.
        -- Data insertion/modification is not allowed when 
        -- a transaction is in an uncommittable state.
        IF XACT_STATE() = -1
        BEGIN
            PRINT 'Cannot log error since the current transaction is in an uncommittable state. ' 
                + 'Rollback the transaction before executing uspLogError in order to successfully log error information.';
            RETURN;
        END

        INSERT [dbo].[ErrorLog] 
            (
            [UserName], 
            [ErrorNumber], 
            [ErrorSeverity], 
            [ErrorState], 
            [ErrorProcedure], 
            [ErrorLine], 
            [ErrorMessage]
            ) 
        VALUES 
            (
            CONVERT(sysname, CURRENT_USER), 
            ERROR_NUMBER(),
            ERROR_SEVERITY(),
            ERROR_STATE(),
            ERROR_PROCEDURE(),
            ERROR_LINE(),
            ERROR_MESSAGE()
            );

        -- Pass back the ErrorLogID of the row inserted
        SET @ErrorLogID = @@IDENTITY;
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred in stored procedure uspLogError: ';
        EXECUTE [dbo].[uspPrintError];
        RETURN -1;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[uspPrintError]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- uspPrintError prints error information about the error that caused 
-- execution to jump to the CATCH block of a TRY...CATCH construct. 
-- Should be executed from within the scope of a CATCH block otherwise 
-- it will return without printing any error information.
CREATE PROCEDURE [dbo].[uspPrintError] 
AS
BEGIN
    SET NOCOUNT ON;

    -- Print error information. 
    PRINT 'Error ' + CONVERT(varchar(50), ERROR_NUMBER()) +
          ', Severity ' + CONVERT(varchar(5), ERROR_SEVERITY()) +
          ', State ' + CONVERT(varchar(5), ERROR_STATE()) + 
          ', Procedure ' + ISNULL(ERROR_PROCEDURE(), '-') + 
          ', Line ' + CONVERT(varchar(5), ERROR_LINE());
    PRINT ERROR_MESSAGE();
END;

GO
/****** Object:  StoredProcedure [dbo].[VarianceByLocation_print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VarianceByLocation_print] --'Subject','','','Incidents.ShortDescriptor, Incidents.Location'
(
@Type nvarchar(100),
@StartDate datetime,
@EndDate datetime,
@ShortLocation nvarchar(100)
)
as
	Declare @SQL nvarchar(max)         
	declare @Where varchar(max)   
	set @Where ='where 1=1 '
begin
if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' EmployeeVariance.AmountShort = 1 AND IncidentDate BETWEEN ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+'EmployeeVariance.AmountShort = 1 AND IncidentDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' EmployeeVariance.AmountShort = 1 AND IncidentDate <= '''+convert(varchar,@EndDate,101)+'''' 

	  if(@Type='Short')
		set @SQL='SELECT EmployeeIncidents.ShortDescriptor, EmployeeIncidents.Location,
				COUNT(*) AS IncidentCount, SUM(EmployeeVariance.Amount) AS SumAmount FROM EmployeeVariance
				INNER JOIN EmployeeIncidents ON EmployeeVariance.IncidentID = EmployeeIncidents.IncidentID
				'+ @Where+'
				GROUP BY '+@ShortLocation+'
				ORDER BY '+@ShortLocation+''
	  else
		set @SQL='SELECT EmployeeIncidents.ShortDescriptor, EmployeeIncidents.Location, 
				COUNT(*) AS IncidentCount, SUM(EmployeeVariance.Amount) AS SumAmount FROM EmployeeVariance
				INNER JOIN EmployeeIncidents ON EmployeeVariance.IncidentID = EmployeeIncidents.IncidentID
				'+ @Where+'
				GROUP BY '+@ShortLocation+'
				ORDER BY '+@ShortLocation+''	
execute(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[VarianceResolution_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[VarianceResolution_Delete](          
@Id int          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Delete from VarianceResolution where Id=@Id           
   Select @@RowCount as RESULT           
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 
GO
/****** Object:  StoredProcedure [dbo].[VarianceResolution_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[VarianceResolution_IU](
@Id int,          
@Resolution nvarchar(200)          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM VarianceResolution  where Id=@Id)            
   begin            
   update VarianceResolution set Resolution=@Resolution where Id=@Id            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into VarianceResolution(Resolution) values(@Resolution)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[VarianceResolution_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[VarianceResolution_Load]          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Select * from VarianceResolution          
   Select @@RowCount as RESULT          
  End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[VarianceType_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[VarianceType_Delete](          
@Id int          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Delete from VarianceType where Id=@Id           
   Select @@RowCount as RESULT           
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 
GO
/****** Object:  StoredProcedure [dbo].[VarianceType_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[VarianceType_IU](
@Id int,          
@VarianceType nvarchar(200)          
)          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
  if exists(SELECT *  FROM VarianceType  where Id=@Id)            
   begin            
   update VarianceType set VarianceType=@VarianceType where Id=@Id            
   select @@RowCount as RESULT        
   end            
  ELSE            
  begin            
   insert into VarianceType(VarianceType) values(@VarianceType)            
   select @@Identity as RESULT          
  end            
 End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[VarianceType_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[VarianceType_Load]          
as                         
BEGIN                 
  Begin Try                          
   Begin Transaction               
    Begin               
   Select * from VarianceType          
   Select @@RowCount as RESULT          
  End               
   COMMIT TRANSACTION               
  End try                  
 Begin Catch                       
  IF @@TRANCOUNT >0                       
          Select ERROR_MESSAGE()              
    Rollback Transaction                
    EXECUTE [uspLogError]                         
 End Catch                          
END 

GO
/****** Object:  StoredProcedure [dbo].[VehicleColor_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VehicleColor_Delete](        
@Id int        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Delete from VehicleColor where Id=@Id         
   Select @@RowCount as RESULT         
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END 
GO
/****** Object:  StoredProcedure [dbo].[VehicleColor_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
Create Procedure [dbo].[VehicleColor_IU](        
@Id int,        
@Color nvarchar(200)        
)        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
  if exists(SELECT *  FROM VehicleColor  where Id=@Id)          
   begin          
   update VehicleColor set Color=@Color where Id=@Id          
   select @@RowCount as RESULT      
   end          
  ELSE          
  begin          
   insert into VehicleColor(Color) values(@Color)          
   select @@Identity as RESULT        
  end          
 End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[VehicleColor_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[VehicleColor_Load]        
as                       
BEGIN               
  Begin Try                        
   Begin Transaction             
    Begin             
   Select * from VehicleColor        
   Select @@RowCount as RESULT        
  End             
   COMMIT TRANSACTION             
  End try                
 Begin Catch                     
  IF @@TRANCOUNT >0                     
          Select ERROR_MESSAGE()            
    Rollback Transaction              
    EXECUTE [uspLogError]                       
 End Catch                        
END       

GO
/****** Object:  StoredProcedure [dbo].[Vehicles_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Vehicles_Delete] --2  
@Id int=0  
AS  
BEGIN  
 DElete from Vehicles where VehicleID=@Id  
 DElete from SubjectVehicles where VehicleID=@Id  
   
 select @@rowcount  
END
 
GO
/****** Object:  StoredProcedure [dbo].[Vehicles_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Vehicles_IU]  
(  
@SubjectId int=0,  
@VehicleID int=0,  
@VehicleVIN nvarchar(50),   
@VehicleColor nvarchar(50),   
@VehicleYear nvarchar(50),   
@VehicleModel nvarchar(50),   
@VehicleMake nvarchar(50),   
@IssuedIn nvarchar(50),   
@LicensePlate nvarchar(50),   
@IncidentID int=0  
)  
AS  
BEGIN             
  Begin Try                      
   Begin Transaction           
         
 Begin    
         
  if(@VehicleID>0)        
  begin        
  update Vehicles set        
    LicensePlate=@LicensePlate,   
    IssuedIn=@IssuedIn,   
    VehicleMake=@VehicleMake,   
    VehicleModel=@VehicleModel,   
    VehicleYear=@VehicleYear,   
    VehicleColor=@VehicleColor,   
    VehicleVIN=@VehicleVIN  
    where VehicleID=@VehicleID        
         
  select @@RowCount        
  end        
  else        
  begin     
          
    Insert into Vehicles(        
    LicensePlate,   
    IssuedIn,   
    VehicleMake,   
    VehicleModel,   
    VehicleYear,   
    VehicleColor,   
    VehicleVIN 
    )           
    values (        
    @LicensePlate,   
    @IssuedIn,   
    @VehicleMake,   
    @VehicleModel,   
    @VehicleYear,   
    @VehicleColor,   
    @VehicleVIN
   
    )            
    select @VehicleID=@@IDENTITY        
            
      --update Incidents set      
      --IncidentNumber=@Id      
      --where IncidentID=@Id      
    Insert into SubjectVehicles(SubjectID, IncidentID,VehicleID)           
    values (@SubjectId,@IncidentID,@VehicleID)    
      
    select @VehicleID            
   end        
 End           
  COMMIT TRANSACTION           
 End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END  
GO
/****** Object:  StoredProcedure [dbo].[Vehicles_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Vehicles_LoadById]     
@SubjectId int =0,    
@IncidentID int =0     
  
AS               
BEGIN     
  Select *,(select Top(1) PV.FilePath from PicturesVideos PV   
   where SubFeatureID = VehicleID and PictureType = 'vehicle' order by MediaID desc) as ImagePath from Vehicles      
 where VehicleID in(Select VehicleID from SubjectVehicles       
 where SubjectId=@SubjectId and IncidentID=@IncidentID)  
      
END

GO
/****** Object:  StoredProcedure [dbo].[VerifyAccount]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[VerifyAccount] --'naina@nextolive.com',123456      
(      
@UserGuid nvarchar(100) = null      
)      
AS       
BEGIN      
declare @Status bit      
 Begin Try      
  Begin Transaction      
       
  begin      
   if(Exists (select * from Users where UserGuid=@UserGuid))      
    Begin       
    set @Status=(select IsEmailVerify from Users where UserGuid=@UserGuid)      
    if(@Status=0)      
    begin      
      update Users set IsEmailVerify=1 where UserGuid=@UserGuid      
     select 1     
     end      
     else      
     begin      
     select -1    
     end      
    End      
   else      
    Begin      
     select -10      
    End      
   end       
         
         
  COMMIT TRANSACTION              
 End try      
 Begin Catch      
  IF @@TRANCOUNT >0                    
   rollback Transaction      
 End Catch      
END
GO
/****** Object:  StoredProcedure [dbo].[Visitor_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Visitor_AddEdit]
(
@VisitorID int,
@VisitorName nvarchar(50),
@Description ntext,
@FromHoursMinutes nvarchar(10),
@ToHoursMinutes nvarchar(10),
@VisitorDate datetime,
@GroupIdentifier nvarchar(50),
@CreatedBy int
)
as
Begin
	IF EXISTS (SELECT * FROM Visitor WHERE VisitorID=@VisitorID)
	BEGIN 
		UPDATE Visitor SET VisitorName=@VisitorName,Description=@Description,FromHoursMinutes=@FromHoursMinutes,ToHoursMinutes=@ToHoursMinutes,
		VisitorDate=@VisitorDate,GroupIdentifier=@GroupIdentifier WHERE VisitorID=@VisitorID
		SELECT @@ROWCOUNT AS RESULT 
	END
	ELSE
	BEGIN
	   INSERT INTO Visitor (VisitorName,Description,FromHoursMinutes,ToHoursMinutes,VisitorDate,GroupIdentifier,CreatedBy,CreatedDate)
	   VALUES (@VisitorName,@Description,@FromHoursMinutes,@ToHoursMinutes,@VisitorDate,@GroupIdentifier,@CreatedBy,getdate())
	   SELECT @@IDENTITY AS RESULT 
	  END
 END

GO
/****** Object:  StoredProcedure [dbo].[Visitor_dashboard]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Visitor_dashboard]

as
begin
	select top(10)visit.VisitorID,visit.VisitorName,visit.CreatedDate,
	Users.FirstName+' '+Users.LastName as CreatedByUser,
	(select ImagePath from VistorLogoImage where SetImage=1) as ImagePath,
	(select count(*) from Visitor) as TotalVisit from Visitor as visit
	left join Users as Users on Users.ID=visit.CreatedBy 
	order by visit.VisitorID desc 
end

GO
/****** Object:  StoredProcedure [dbo].[Visitor_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Visitor_Delete]
(
	@VisitorID int
)
as
begin
	Delete FROM Visitor WHERE VisitorID=@VisitorID
	SELECT @@ROWCOUNT AS RESULT
END
GO
/****** Object:  StoredProcedure [dbo].[Visitor_Filter]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visitor_Filter] --'2016-08-05 19:27:19.480',''
(
@StartDate datetime,
@EndDate datetime
)
as  
 declare @SQL varchar(max)          
 declare @Where varchar(max)   
 set @Where ='where 1=1 '  
begin  
      if (@StartDate <>'' AND @EndDate <>'')        
        set @Where=@Where+' AND VisitorDate Between ''' +convert(varchar,@StartDate,101) +''' and  '''+convert(varchar,@EndDate,101)+''''  
      if (@StartDate  <>'' AND @EndDate  ='')        
          set @Where=@Where+'AND VisitorDate >= '''+convert(varchar,@EndDate,101)+''''               
      if (@StartDate ='' AND @EndDate <>'')     
      set @Where=@Where+' AND VisitorDate <= '''+convert(varchar,@EndDate,101)+'''' 
     
            
    SET @SQL ='Select * from Visitor '+ @Where  
  
 -- print(@SQL) 
 exec(@SQL)  

 end
GO
/****** Object:  StoredProcedure [dbo].[Visitor_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visitor_Load]
(
	@VisitorID int
)
as
begin
	select * from Visitor where VisitorID=@VisitorID
end
GO
/****** Object:  StoredProcedure [dbo].[VisitorEmailSend_AddEdit]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VisitorEmailSend_AddEdit]
@ID int=0,
@Email nvarchar(50)=null,
@SMTP nvarchar(5)=Null,
@Password nvarchar(50),
@CreatedBy int=0      
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    if(@ID>0)
	 begin
		update VisitorEmailSend set Email=@Email,SMTP=@SMTP,Password=@Password,ModifiedDate=getDate() where ID=@ID
	 End
	Else
	 begin
	  insert into VisitorEmailSend(Email,SMTP,Password,CreatedBy,CreatedDate,ModifiedDate)values(@Email,@SMTP,@Password,@CreatedBy,getdate(),getdate())
	 end
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 

GO
/****** Object:  StoredProcedure [dbo].[VisitorEmailSend_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VisitorEmailSend_Bind]
    
AS                             
BEGIN                   
  Begin Try    
   Begin Transaction   
    Select * from VisitorEmailSend order by ModifiedDate DESC
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 

GO
/****** Object:  StoredProcedure [dbo].[VisitorEmailSend_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VisitorEmailSend_Delete]
@ID int=0        
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Delete from VisitorEmailSend where ID=@ID
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 

GO
/****** Object:  StoredProcedure [dbo].[VistorLogoImage_Add]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VistorLogoImage_Add]
@ImagePath nvarchar(MAX)=null,
@SetImage bit=Null,
@CreatedBy int=0        
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Insert into VistorLogoImage(ImagePath,SetImage,CreatedBy) Values(@ImagePath,@SetImage,@CreatedBy)
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[VistorLogoImage_Bind]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VistorLogoImage_Bind]
     
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    select * from VistorLogoImage
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[VistorLogoImage_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VistorLogoImage_Delete]
@ID int=0        
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Delete from VistorLogoImage where ID=@ID
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[VistorLogoImage_SetImage]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[VistorLogoImage_SetImage]
@ID int=0     
AS                             
BEGIN                   
  Begin Try                            
   Begin Transaction
    Update VistorLogoImage set SetImage=Null
    Update VistorLogoImage set SetImage='true' where ID=@ID 
	select @@Identity as Result
   COMMIT TRANSACTION                 
  End try                    
 Begin Catch                         
  IF @@TRANCOUNT >0                         
          Select ERROR_MESSAGE()                
    Rollback Transaction                  
    EXECUTE [uspLogError]                           
 End Catch                            
END 


GO
/****** Object:  StoredProcedure [dbo].[WatchList_LoadAll]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[WatchList_LoadAll]    
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from WatchNames 
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[WatchList_Print]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[WatchList_Print]
(
@WatchName nvarchar(100)
)
as
begin
	SELECT Subjects.SubjectID, Subjects.LastName, Subjects.FirstName,
	Subjects.MiddleName, Subjects.Sex, Subjects.Race, Subjects.Status,
	(SELECT TOP 1 PicturesVideos.FilePath
	FROM PicturesVideos, SubjectPicturesVideos
	WHERE PicturesVideos.MediaID = SubjectPicturesVideos.MediaID
	AND (NOT SubjectPicturesVideos.MediaType IN ('Involved', 'Dispute', 'Vehicles'))
	AND PicturesVideos.MediaExtention = 'jpg'
	AND SubjectPicturesVideos.SubjectID =Subjects.SubjectID 
	ORDER BY PicturesVideos.DefaultPic DESC, SubjectPicturesVideos.MediaType DESC) As Picture
	FROM SubjectWatch
	INNER JOIN Subjects ON SubjectWatch.SubjectID = Subjects.SubjectID
	WHERE SubjectWatch.WatchName = @WatchName ORDER BY Subjects.LastName
end
GO
/****** Object:  StoredProcedure [dbo].[WatchName_DeleteById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[WatchName_DeleteById]     
@WatchID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		delete from WatchNames where WatchID = @WatchID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[WatchName_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[WatchName_IU]   
@WatchName nvarchar(200) = null,
@WatchID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@WatchID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update WatchNames set
			WatchName = @WatchName where WatchID = @WatchID 
			select @WatchID  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into WatchNames(WatchName) values (@WatchName)          
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[WatchName_LoadById]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[WatchName_LoadById]     
@WatchID int =0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		select * from WatchNames where WatchID = @WatchID 
		select @@RowCount
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END
GO
/****** Object:  StoredProcedure [dbo].[WatchNames_Load]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WatchNames_Load]

as
begin
	Select WatchID,WatchName From WatchNames ORDER BY WatchID;
end

GO
/****** Object:  StoredProcedure [dbo].[WeightUnit_Delete]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[WeightUnit_Delete](  
@id int=0
)  
as  
begin  
	Delete from MasterWeightUnit where id=@id
	select @@RowCount as Result
end


GO
/****** Object:  StoredProcedure [dbo].[WeightUnit_IU]    Script Date: 01/28/2018 9:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WeightUnit_IU](
@id int=0,
@WeightUnit nvarchar(100)=Null,
@IsDefault bit = NULL
)
as
begin
	if exists(Select * from MasterWeightUnit where id=@id)
	begin
		IF @IsDefault = 1
			BEGIN
				UPDATE MasterWeightUnit SET IsDefault = 0 WHERE id <> @id
			END
		UPDATE MasterWeightUnit SET WeightUnitName=@WeightUnit, IsDefault =@IsDefault WHERE id=@id
		select @@Rowcount as RESULT
	end
	else
	begin 
		IF @IsDefault = 1
		BEGIN
			UPDATE MasterWeightUnit SET IsDefault = 0 
		END
		INSERT INTO MasterWeightUnit(WeightUnitName,IsDefault) values(@WeightUnit,@IsDefault)
		select @@Identity as RESULT
	end
end


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key for ErrorLog records.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorLogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time at which the error occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The user who executed the batch in which the error occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The error number of the error that occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The severity of the error that occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorSeverity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The state number of the error that occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the stored procedure or trigger where the error occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorProcedure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The line number at which the error occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorLine'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The message text of the error that occurred.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key (clustered) constraint' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ErrorLog', @level2type=N'CONSTRAINT',@level2name=N'PK_ErrorLog_ErrorLogID'
GO
USE [master]
GO
ALTER DATABASE [CIMS] SET  READ_WRITE 
GO
