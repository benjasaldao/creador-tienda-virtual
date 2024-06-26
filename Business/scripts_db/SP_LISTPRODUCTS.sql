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
ALTER PROCEDURE [dbo].[spListProducts] 
	@storeId int
AS
BEGIN
	SELECT P.id, code, name, P.description, idCategorie, C.description category, price, unit, P.storeId, stock, p.state 
	FROM PRODUCTS P, CATEGORIES C
	where P.storeId = @storeId AND idCategorie = C.id
END

