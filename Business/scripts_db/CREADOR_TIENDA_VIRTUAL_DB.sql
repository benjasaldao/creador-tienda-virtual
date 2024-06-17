use master
go
create database CREADOR_TIENDA_VIRTUAL
go
use CREADOR_TIENDA_VIRTUAL
go
USE [CREADOR_TIENDA_VIRTUAL]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 08/09/2019 10:32:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

create table USERS(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [email] [varchar](100) NOT NULL,
    [pass] [varchar](20) NOT NULL,
    [name] [varchar](50) NULL,
    [surname] [varchar](50) NULL,
	[recoveryToken] [varchar](1000) NULL,
    [admin] [bit] NOT NULL DEFAULT 0,
	[state] [bit] NULL DEFAULT 1,
	CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


create table STORES(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [varchar](50) NULL,
    [description] [varchar](1000) NULL,
	[userId] [int] NOT NULL,
	[state] [bit] NULL DEFAULT 1,
	CONSTRAINT [PK_STORES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[CATEGORIES](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [description] [varchar](50) NULL,
	[imageUrl] [varchar](1000) NULL,
	[storeId] [int] NOT NULL,
	[state] [bit] NOT NULL DEFAULT 1,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 08/09/2019 10:32:24 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTS](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [code] [varchar](50) NULL,
    [name] [varchar](50) NULL,
    [description] [varchar](150) NULL,
    [idCategorie] [int] NULL,
    [price] [money] NULL,
	[unit] [varchar](15) NULL,
	[storeId] [int] NOT NULL,
	[stock] [int] NOT NULL DEFAULT 0,
	[state] [bit] NOT NULL DEFAULT 1,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
create table STOREUSERS(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [email] [varchar](100) NOT NULL,
    [pass] [varchar](20) NOT NULL,
    [name] [varchar](50) NULL,
    [surname] [varchar](50) NULL,
	[recoveryToken] [varchar](1000) NULL,
	[adress] [varchar](100) NULL,
	[city] [varchar](20) NULL,
	[storeId] [int] NOT NULL,
	[state] [bit] NOT NULL DEFAULT 1,
)
go
create table FAVORITES(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [storeUserId] [int] NOT NULL,
    [productId] [int] NOT NULL,
	[storeId] [int] NOT NULL,
)
go
create table ORDERS(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [storeUserId] [int] NOT NULL,
	[storeId] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[comment] [varchar](100) NULL,
	[paid] [bit] NOT NULL DEFAULT 0,
	[canceled] [bit] NOT NULL DEFAULT 0,
)
go
create table ORDERPRODUCT(
    [id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
    [productId] [int] NOT NULL,
	[storeId] [int] NOT NULL,
	[amount] [int] NOT NULL DEFAULT 1,
)
go
create table PRODUCTIMAGES(
    [id] [int] IDENTITY(1,1) NOT NULL,
	[alt] [varchar](50) NULL,
	[imageUrl] [varchar](1000) NOT NULL,
	[productId] [int] NOT NULL,
)
go