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
CREATE PROCEDURE spCreateStoreUser
	@email varchar(100),
	@pass varchar(20),
	@name varchar(50),
	@surname varchar(50),
	@adress varchar(100),
	@city varchar(20),
	@storeId int
AS
BEGIN
	INSERT INTO STOREUSERS (email, pass, name, surname, adress, city, storeId) 
	VALUES ( @email, @pass, @name, @surname, @adress, @city, @storeId)
END
GO
