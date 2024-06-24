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
CREATE PROCEDURE spDeleteFavorite
	@storeUserId int,
	@productId int
AS
BEGIN
	DELETE FAVORITES 
	WHERE storeUserId = @storeUserId 
	AND productId = @productId
END
GO
