USE [CREADOR_TIENDA_VIRTUAL]
GO
/****** Object:  StoredProcedure [dbo].[spListProducts]    Script Date: 19/6/2024 19:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spCreateProduct
	@code varchar(50),
	@name varchar(50),
	@description varchar(150),
	@idCategory int,
	@price int,
	@unit varchar(15),
	@storeId int,
	@stock int
AS
BEGIN
	INSERT INTO PRODUCTS 
	(code, name, description, idCategorie, price, unit, storeId, stock)
	values(@code, @name, @description, @idCategory, @price, @unit, @storeId, @stock)
END
