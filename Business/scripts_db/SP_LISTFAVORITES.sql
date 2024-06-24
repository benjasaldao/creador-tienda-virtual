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
CREATE PROCEDURE spListFavorites
	@storeUserId int
AS
BEGIN
	select P.id, code, name, P.description, idCategorie, C.description category, price, unit, P.storeId, stock, P.state 
	FROM PRODUCTS P, CATEGORIES C, FAVORITES F 
	where P.idCategorie = C.Id and F.productId = P.id and F.storeUserId = @storeUserId
END
GO
