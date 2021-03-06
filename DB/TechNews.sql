USE [TechNews2]
GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Korisnik]
GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Kategorija]
GO
ALTER TABLE [dbo].[Ocena] DROP CONSTRAINT [FK_Ocena_Korisnik]
GO
ALTER TABLE [dbo].[Komentar] DROP CONSTRAINT [FK_Komentar_Korisnik]
GO
ALTER TABLE [dbo].[Bookmark] DROP CONSTRAINT [FK_Bookmark_Korisnik]
GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_Dislike_]
GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_Like_]
GO
ALTER TABLE [dbo].[Komentar] DROP CONSTRAINT [DF_Komentar_Allowed]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/22/2020 5:24:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Post]') AND type in (N'U'))
DROP TABLE [dbo].[Post]
GO
/****** Object:  Table [dbo].[Ocena]    Script Date: 12/22/2020 5:24:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ocena]') AND type in (N'U'))
DROP TABLE [dbo].[Ocena]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 12/22/2020 5:24:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Korisnik]') AND type in (N'U'))
DROP TABLE [dbo].[Korisnik]
GO
/****** Object:  Table [dbo].[Komentar]    Script Date: 12/22/2020 5:24:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Komentar]') AND type in (N'U'))
DROP TABLE [dbo].[Komentar]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 12/22/2020 5:24:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Kategorija]') AND type in (N'U'))
DROP TABLE [dbo].[Kategorija]
GO
/****** Object:  Table [dbo].[Bookmark]    Script Date: 12/22/2020 5:24:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bookmark]') AND type in (N'U'))
DROP TABLE [dbo].[Bookmark]
GO
USE [master]
GO
/****** Object:  Database [TechNews2]    Script Date: 12/22/2020 5:24:58 PM ******/
DROP DATABASE [TechNews2]
GO
/****** Object:  Database [TechNews2]    Script Date: 12/22/2020 5:24:58 PM ******/
CREATE DATABASE [TechNews2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TechNews2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TechNews2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TechNews2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TechNews2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechNews2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechNews2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechNews2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechNews2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechNews2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechNews2] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechNews2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechNews2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechNews2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechNews2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechNews2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechNews2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechNews2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechNews2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechNews2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechNews2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TechNews2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechNews2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechNews2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechNews2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechNews2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechNews2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TechNews2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechNews2] SET RECOVERY FULL 
GO
ALTER DATABASE [TechNews2] SET  MULTI_USER 
GO
ALTER DATABASE [TechNews2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechNews2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechNews2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechNews2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechNews2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TechNews2', N'ON'
GO
USE [TechNews2]
GO
/****** Object:  Table [dbo].[Bookmark]    Script Date: 12/22/2020 5:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookmark](
	[BookmarkID] [int] NOT NULL,
	[PostID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
 CONSTRAINT [PK_Bookmark] PRIMARY KEY CLUSTERED 
(
	[BookmarkID] ASC,
	[PostID] ASC,
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 12/22/2020 5:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorija](
	[KategorijaID] [int] NOT NULL,
	[NazivKategorije] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED 
(
	[KategorijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Komentar]    Script Date: 12/22/2020 5:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Komentar](
	[KomentarID] [int] NOT NULL,
	[PostID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[Sadrzaj] [text] NOT NULL,
	[Allowed] [bit] NOT NULL,
	[Datum] [date] NOT NULL,
 CONSTRAINT [PK_Komentar] PRIMARY KEY CLUSTERED 
(
	[KomentarID] ASC,
	[PostID] ASC,
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 12/22/2020 5:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[KorisnikID] [int] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Ime] [nvarchar](50) NULL,
	[Prezime] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Pasword] [nvarchar](50) NOT NULL,
	[Datum] [date] NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocena]    Script Date: 12/22/2020 5:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocena](
	[OcenaID] [int] NOT NULL,
	[PostID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[Ocena] [bit] NULL,
 CONSTRAINT [PK_Ocena] PRIMARY KEY CLUSTERED 
(
	[OcenaID] ASC,
	[PostID] ASC,
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/22/2020 5:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[KategorijaID] [int] NOT NULL,
	[Naslov] [nvarchar](50) NOT NULL,
	[Sadrzaj] [text] NOT NULL,
	[Like_] [int] NULL,
	[Dislike_] [int] NULL,
	[Datum] [date] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC,
	[KorisnikID] ASC,
	[KategorijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Bookmark] ([BookmarkID], [PostID], [KorisnikID]) VALUES (11, 2, 1)
INSERT [dbo].[Bookmark] ([BookmarkID], [PostID], [KorisnikID]) VALUES (111, 1, 1)
GO
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (1, N'Reviews')
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (2, N'OS')
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (3, N'E-Cars')
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (4, N'IOT')
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (5, N'Interviews')
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (6, N'fasdf')
INSERT [dbo].[Kategorija] ([KategorijaID], [NazivKategorije]) VALUES (7, N'Nova Kategorija')
GO
INSERT [dbo].[Komentar] ([KomentarID], [PostID], [KorisnikID], [Sadrzaj], [Allowed], [Datum]) VALUES (1, 2, 1, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. ', 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Komentar] ([KomentarID], [PostID], [KorisnikID], [Sadrzaj], [Allowed], [Datum]) VALUES (2, 1, 2, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. ', 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Komentar] ([KomentarID], [PostID], [KorisnikID], [Sadrzaj], [Allowed], [Datum]) VALUES (3, 1, 1, N'novi komentar
', 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Komentar] ([KomentarID], [PostID], [KorisnikID], [Sadrzaj], [Allowed], [Datum]) VALUES (4, 1, 1, N'nfasdf
', 0, CAST(N'2020-11-11' AS Date))
GO
INSERT [dbo].[Korisnik] ([KorisnikID], [Role], [Ime], [Prezime], [Username], [Email], [Pasword], [Datum]) VALUES (1, N'1', NULL, NULL, N'anna', N'ana.anic@gmail.com', N'123456', CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Korisnik] ([KorisnikID], [Role], [Ime], [Prezime], [Username], [Email], [Pasword], [Datum]) VALUES (2, N'1', NULL, NULL, NULL, N'user2@gmail.com', N'123456', CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Korisnik] ([KorisnikID], [Role], [Ime], [Prezime], [Username], [Email], [Pasword], [Datum]) VALUES (3, N'2', N'Ana', N'Anic', N'anna', N'ana.anic@gmail.com', N'123456', CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Korisnik] ([KorisnikID], [Role], [Ime], [Prezime], [Username], [Email], [Pasword], [Datum]) VALUES (4, N'3', N'Nenad', N'Stanojev', N'nndev', N'nnd.stan@gmail.com', N'12345666', CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Korisnik] ([KorisnikID], [Role], [Ime], [Prezime], [Username], [Email], [Pasword], [Datum]) VALUES (5, N'2', N'Jovan', N'Ilic', N'joca', N'jovan.il@gmail.com', N'123456', CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Korisnik] ([KorisnikID], [Role], [Ime], [Prezime], [Username], [Email], [Pasword], [Datum]) VALUES (6, N'2', N'Zoki', N'Zokic', N'zoki', N'zoki.zokic@gmail.com', N'12345678', CAST(N'2020-11-11' AS Date))
GO
INSERT [dbo].[Ocena] ([OcenaID], [PostID], [KorisnikID], [Ocena]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Ocena] ([OcenaID], [PostID], [KorisnikID], [Ocena]) VALUES (1, 2, 1, 1)
GO
INSERT [dbo].[Post] ([PostID], [KorisnikID], [KategorijaID], [Naslov], [Sadrzaj], [Like_], [Dislike_], [Datum]) VALUES (1, 3, 1, N'Naslov 1', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy', 1, 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Post] ([PostID], [KorisnikID], [KategorijaID], [Naslov], [Sadrzaj], [Like_], [Dislike_], [Datum]) VALUES (2, 4, 2, N'Naslov 2', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy', 1, 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Post] ([PostID], [KorisnikID], [KategorijaID], [Naslov], [Sadrzaj], [Like_], [Dislike_], [Datum]) VALUES (3, 5, 3, N'Naslov 3', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy', 0, 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Post] ([PostID], [KorisnikID], [KategorijaID], [Naslov], [Sadrzaj], [Like_], [Dislike_], [Datum]) VALUES (4, 3, 4, N'Naslov 4', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an', 0, 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Post] ([PostID], [KorisnikID], [KategorijaID], [Naslov], [Sadrzaj], [Like_], [Dislike_], [Datum]) VALUES (5, 4, 1, N'Naslov 5', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an', 0, 0, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[Post] ([PostID], [KorisnikID], [KategorijaID], [Naslov], [Sadrzaj], [Like_], [Dislike_], [Datum]) VALUES (6, 6, 3, N'Naslov 6', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an', 0, 0, CAST(N'2020-11-11' AS Date))
GO
ALTER TABLE [dbo].[Komentar] ADD  CONSTRAINT [DF_Komentar_Allowed]  DEFAULT ((0)) FOR [Allowed]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Like_]  DEFAULT ((0)) FOR [Like_]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Dislike_]  DEFAULT ((0)) FOR [Dislike_]
GO
ALTER TABLE [dbo].[Bookmark]  WITH CHECK ADD  CONSTRAINT [FK_Bookmark_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[Bookmark] CHECK CONSTRAINT [FK_Bookmark_Korisnik]
GO
ALTER TABLE [dbo].[Komentar]  WITH CHECK ADD  CONSTRAINT [FK_Komentar_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[Komentar] CHECK CONSTRAINT [FK_Komentar_Korisnik]
GO
ALTER TABLE [dbo].[Ocena]  WITH CHECK ADD  CONSTRAINT [FK_Ocena_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[Ocena] CHECK CONSTRAINT [FK_Ocena_Korisnik]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Kategorija] FOREIGN KEY([KategorijaID])
REFERENCES [dbo].[Kategorija] ([KategorijaID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Kategorija]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Korisnik]
GO
USE [master]
GO
ALTER DATABASE [TechNews2] SET  READ_WRITE 
GO
