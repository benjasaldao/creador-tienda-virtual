-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spCreateUser 
	@email varchar(100),
	@pass varchar(20),
	@name varchar(50),
	@surname varchar(50)
AS
BEGIN
	INSERT INTO USERS (email, pass, name, surname) 
	VALUES ( @email, @pass, @name, @surname)
END
GO
