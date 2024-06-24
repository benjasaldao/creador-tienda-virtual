USE [CREADOR_TIENDA_VIRTUAL]
GO
/****** Object:  StoredProcedure [dbo].[spListCategories]    Script Date: 23/6/2024 20:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spListCategories] 
	@storeId int
AS
BEGIN
	SELECT id, description, imageUrl, state, storeId 
	FROM CATEGORIES WHERE storeId = @storeId
END
