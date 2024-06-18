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
CREATE PROCEDURE spListStoresByUser
	@userId int	
AS
BEGIN
	SELECT id, name, description, userId, state
	FROM STORES
	WHERE userId = @userId
END
GO
