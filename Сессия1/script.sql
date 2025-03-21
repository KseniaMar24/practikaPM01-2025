USE [master]
GO
/****** Object:  Database [Accounting]    Script Date: 03.03.2025 10:57:09 ******/
CREATE DATABASE [Accounting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Accounting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Accounting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Accounting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Accounting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Accounting] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Accounting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Accounting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Accounting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Accounting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Accounting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Accounting] SET ARITHABORT OFF 
GO
ALTER DATABASE [Accounting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Accounting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Accounting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Accounting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Accounting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Accounting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Accounting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Accounting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Accounting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Accounting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Accounting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Accounting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Accounting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Accounting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Accounting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Accounting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Accounting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Accounting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Accounting] SET  MULTI_USER 
GO
ALTER DATABASE [Accounting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Accounting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Accounting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Accounting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Accounting] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Accounting] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Accounting] SET QUERY_STORE = ON
GO
ALTER DATABASE [Accounting] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Accounting]
GO
/****** Object:  Table [dbo].[Действия_пользователей]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Действия_пользователей](
	[ID_действия] [int] IDENTITY(1,1) NOT NULL,
	[ID_пользователя] [int] NULL,
	[Действие] [text] NOT NULL,
	[Дата_время] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_действия] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Инвентаризация]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Инвентаризация](
	[ID_инвентаризации] [int] IDENTITY(1,1) NOT NULL,
	[Дата_проведения] [date] NOT NULL,
	[Ответственный] [varchar](255) NOT NULL,
	[Результаты] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_инвентаризации] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователи]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователи](
	[ID_пользователя] [int] IDENTITY(1,1) NOT NULL,
	[Имя_пользователя] [varchar](100) NOT NULL,
	[Роль] [varchar](50) NOT NULL,
	[Пароль] [varchar](255) NOT NULL,
	[Контактные_данные] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_пользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Поставщики]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Поставщики](
	[ID_поставщика] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](255) NOT NULL,
	[ИНН_КПП] [varchar](20) NOT NULL,
	[Контактные_данные] [text] NULL,
	[Адрес] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_поставщика] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Приходные_накладные]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Приходные_накладные](
	[ID_накладной] [int] IDENTITY(1,1) NOT NULL,
	[Номер_накладной] [varchar](50) NOT NULL,
	[Дата_поступления] [date] NOT NULL,
	[ID_поставщика] [int] NULL,
	[Общая_сумма] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_накладной] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Расходные_накладные]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Расходные_накладные](
	[ID_накладной] [int] IDENTITY(1,1) NOT NULL,
	[Номер_накладной] [varchar](50) NOT NULL,
	[Дата_отгрузки] [date] NOT NULL,
	[Клиент] [varchar](255) NOT NULL,
	[Общая_сумма] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_накладной] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Склады]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Склады](
	[ID_склада] [int] IDENTITY(1,1) NOT NULL,
	[Название_склада] [varchar](255) NOT NULL,
	[Адрес] [varchar](255) NOT NULL,
	[Тип_склада] [varchar](50) NOT NULL,
	[Зоны_хранения] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_склада] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары](
	[ID_товара] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](255) NOT NULL,
	[Артикул] [varchar](50) NOT NULL,
	[Штрихкод] [varchar](50) NOT NULL,
	[Категория] [varchar](100) NULL,
	[Единица_измерения] [varchar](20) NOT NULL,
	[Цена_за_единицу] [decimal](10, 2) NOT NULL,
	[Серийный_номер] [varchar](100) NULL,
	[Минимальный_остаток] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_товара] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары_в_приходной]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары_в_приходной](
	[ID_записи] [int] IDENTITY(1,1) NOT NULL,
	[ID_накладной] [int] NULL,
	[ID_товара] [int] NULL,
	[Количество] [int] NOT NULL,
	[Цена] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_записи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары_в_расходной]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары_в_расходной](
	[ID_записи] [int] IDENTITY(1,1) NOT NULL,
	[ID_накладной] [int] NULL,
	[ID_товара] [int] NULL,
	[Количество] [int] NOT NULL,
	[Цена] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_записи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары_на_складе]    Script Date: 03.03.2025 10:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары_на_складе](
	[ID_записи] [int] IDENTITY(1,1) NOT NULL,
	[ID_товара] [int] NULL,
	[ID_склада] [int] NULL,
	[Количество] [int] NOT NULL,
	[Зона_хранения] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_записи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Приходны__08E068C69243BD72]    Script Date: 03.03.2025 10:57:09 ******/
ALTER TABLE [dbo].[Приходные_накладные] ADD UNIQUE NONCLUSTERED 
(
	[Номер_накладной] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Расходны__08E068C6760D896A]    Script Date: 03.03.2025 10:57:09 ******/
ALTER TABLE [dbo].[Расходные_накладные] ADD UNIQUE NONCLUSTERED 
(
	[Номер_накладной] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Товары__2AF1CF032A801235]    Script Date: 03.03.2025 10:57:09 ******/
ALTER TABLE [dbo].[Товары] ADD UNIQUE NONCLUSTERED 
(
	[Штрихкод] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Товары__F333AABF40A51DAD]    Script Date: 03.03.2025 10:57:09 ******/
ALTER TABLE [dbo].[Товары] ADD UNIQUE NONCLUSTERED 
(
	[Артикул] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Действия_пользователей]  WITH CHECK ADD FOREIGN KEY([ID_пользователя])
REFERENCES [dbo].[Пользователи] ([ID_пользователя])
GO
ALTER TABLE [dbo].[Приходные_накладные]  WITH CHECK ADD FOREIGN KEY([ID_поставщика])
REFERENCES [dbo].[Поставщики] ([ID_поставщика])
GO
ALTER TABLE [dbo].[Товары_в_приходной]  WITH CHECK ADD FOREIGN KEY([ID_накладной])
REFERENCES [dbo].[Приходные_накладные] ([ID_накладной])
GO
ALTER TABLE [dbo].[Товары_в_приходной]  WITH CHECK ADD FOREIGN KEY([ID_товара])
REFERENCES [dbo].[Товары] ([ID_товара])
GO
ALTER TABLE [dbo].[Товары_в_расходной]  WITH CHECK ADD FOREIGN KEY([ID_накладной])
REFERENCES [dbo].[Расходные_накладные] ([ID_накладной])
GO
ALTER TABLE [dbo].[Товары_в_расходной]  WITH CHECK ADD FOREIGN KEY([ID_товара])
REFERENCES [dbo].[Товары] ([ID_товара])
GO
ALTER TABLE [dbo].[Товары_на_складе]  WITH CHECK ADD FOREIGN KEY([ID_склада])
REFERENCES [dbo].[Склады] ([ID_склада])
GO
ALTER TABLE [dbo].[Товары_на_складе]  WITH CHECK ADD FOREIGN KEY([ID_товара])
REFERENCES [dbo].[Товары] ([ID_товара])
GO
USE [master]
GO
ALTER DATABASE [Accounting] SET  READ_WRITE 
GO
