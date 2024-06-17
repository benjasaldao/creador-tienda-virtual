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
CREATE PROCEDURE spUserLogin 
	@email varchar(100),
	@password varchar(20)
AS
BEGIN
	SELECT id, email, surname, name, admin, state from USERS where email = @email AND pass = @password
END
GO
