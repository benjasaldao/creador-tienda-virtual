USE [CREADOR_TIENDA_VIRTUAL]
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
CREATE PROCEDURE spDeleteUser
	@id int
AS
BEGIN
	DELETE USERS where id = @id
END
GO
