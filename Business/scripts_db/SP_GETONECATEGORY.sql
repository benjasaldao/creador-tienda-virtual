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
CREATE PROCEDURE spGetOneCategory 
	@id int
AS
BEGIN
	SELECT id, description, imageUrl, state, storeId
	FROM CATEGORIES WHERE id = @id
END
GO
