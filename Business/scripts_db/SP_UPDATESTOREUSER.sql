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
CREATE PROCEDURE spUpdateStoreUser
	@email varchar(100),
	@name varchar(50),
	@surname varchar(50),
	@adress varchar(100),
	@city varchar(20),
	@id int
AS
BEGIN
	UPDATE STOREUSERS SET email = @email, name = @name, 
	surname = @surname, adress = @adress, city = @city
	WHERE Id = @id
END
GO
