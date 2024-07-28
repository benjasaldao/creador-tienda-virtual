USE master;
GO

CREATE DATABASE Gestor_Catalogos_DB
GO

USE [Gestor_Catalogos_DB]
GO

CREATE TABLE Users (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Email varchar(60) UNIQUE NOT NULL,
	Pass varchar(50) NOT NULL,
	Name varchar(30) NULL,
	Surname varchar(30) NULL,
	RecoveryToken varchar(1000) NULL,
	Admin bit NOT NULL DEFAULT 0,
	State bit NOT NULL DEFAULT 1
)
GO
CREATE TABLE Stores(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Description varchar(255) NULL,
	LogoUrl varchar(1000) NULL,
	UserId int NOT NULL,
	State bit NOT NULL DEFAULT 1,
	CONSTRAINT FK_Stores_Users FOREIGN KEY (UserId) REFERENCES Users (Id)
)
GO

CREATE TABLE Categories(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Description varchar(50),
	ImageUrl varchar(1000),
	StoreId int NOT NULL,
	State bit NOT NULL DEFAULT 1,
	CONSTRAINT FK_Categories_Stores FOREIGN KEY (StoreId) REFERENCES Stores (Id)
)
GO

CREATE TABLE Products(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Code varchar(10),
	Name varchar(50) NOT NULL,
	Description varchar(500),
	CategoryId int,
	Price float,
	StoreId int,
	Stock int DEFAULT 0,
	State bit NOT NULL DEFAULT 1,
	CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories (Id),
	CONSTRAINT FK_Products_Stores FOREIGN KEY (StoreId) REFERENCES Stores (Id)
)

CREATE TABLE StoreUsers(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Email varchar(60) UNIQUE NOT NULL,
	Pass varchar(50) NOT NULL,
	Name varchar(30) NULL,
	Surname varchar(30) NULL,
	RecoveryToken varchar(1000) NULL,
	Adress varchar(200),
	City varchar(30),
	StoreId int NOT NULL,
	State bit NOT NULL DEFAULT 1,
	CONSTRAINT FK_StoreUsers_Store FOREIGN KEY (StoreId) REFERENCES Stores(Id)
)
GO

CREATE TABLE Favorites(
	Id int IDENTITY(1,1) PRIMARY KEY,
	StoreUserId int,
	ProductId int,
	StoreId int,
	CONSTRAINT FK_Favorites_StoreUsers FOREIGN KEY (StoreUserId) REFERENCES StoreUsers (Id),
	CONSTRAINT FK_Favorites_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
	CONSTRAINT FK_Favorites_Store FOREIGN KEY (StoreId) REFERENCES Stores (Id)
)
GO

CREATE TABLE Orders(
	Id int IDENTITY(1,1) PRIMARY KEY,
	StoreUserId int,
	StoreId int,
	Comment varchar(200),
	Paid bit NOT NULL DEFAULT 0,
	Canceled bit NOT NULL DEFAULT 0,
	CONSTRAINT FK_Orders_StoreUser FOREIGN KEY (StoreUserId) REFERENCES StoreUsers (Id),
	CONSTRAINT FK_Orders_Store FOREIGN KEY (StoreId) REFERENCES Stores (Id)
)
GO

CREATE TABLE [Orders.Products](
	Id int IDENTITY(1,1) PRIMARY KEY,
	OrderId int,
	ProductId int,
	Amount int DEFAULT 1,
	CONSTRAINT FK_OrdersProducts_Orders FOREIGN KEY (OrderId) REFERENCES Orders (Id),
	CONSTRAINT FK_OrdersProducts_Products FOREIGN KEY (ProductId) REFERENCES Products(Id),
)
GO

CREATE TABLE ProductsImages(
	Id int IDENTITY(1,1) PRIMARY KEY,
	ImageUrl varchar(1000) NOT NULL,
	ProductId int,
	CONSTRAINT FK_ProductsImages_Products FOREIGN KEY (ProductId) REFERENCES Products (Id)
)
GO


