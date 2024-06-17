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
CREATE PROCEDURE spUpdateUser 
	@email varchar(100),
	@name varchar(50),
	@surname varchar(50),
	@id int
AS
BEGIN
	Update USERS set email = @email, name = @name, 
	surname = @surname where Id = @id
END
GO
