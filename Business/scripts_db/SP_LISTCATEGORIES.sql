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
CREATE PROCEDURE spListCategories 
	@query varchar(20) = ''
AS
BEGIN
	SELECT id, description, imageUrl, state, storeId 
	FROM CATEGORIES WHERE description = @query
END
GO
