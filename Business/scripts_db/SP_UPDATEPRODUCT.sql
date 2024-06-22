USE CREADOR_TIENDA_VIRTUAL
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spUpdateProduct 
	@id int,
	@code varchar(50),
	@name varchar(50),
	@description varchar(150),
	@idCategory int,
	@price int,
	@unit varchar(15),
	@stock int
AS
BEGIN
	UPDATE PRODUCTS SET code = @code, name = @name, 
	description = @description, idCategorie = @idCategory, 
	price = @price, unit = @unit, stock = @stock
	where id = @id
END
GO
