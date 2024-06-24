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
CREATE PROCEDURE spCreateFavorite
	@productId int,
	@storeUserId int,
	@storeId int
AS
BEGIN
	INSERT INTO FAVORITES (productId, storeId, storeUserId)
	VALUES (@productId, @storeId, @storeUserId)
END
GO
