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
CREATE PROCEDURE spCreateCategory 
	@description varchar(50),
	@imageUrl varchar(1000),
	@storeId int
AS
BEGIN
	INSERT INTO CATEGORIES (description, imageUrl, storeId) 
	VALUES (@description, @imageUrl, @storeId)
END
GO
