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
CREATE PROCEDURE spGetOneProduct
	@id int,
	@storeId int
AS
BEGIN
	SELECT P.id, code, name, P.description, price, unit, P.storeId, stock, P.state, idCategorie, C.description 
	FROM PRODUCTS P, CATEGORIES C WHERE P.id = @id AND C.storeId = @storeId AND idCategorie = C.id
END
GO

