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
CREATE PROCEDURE spCreateStore 
	@name varchar(50),
	@description varchar(1000),
	@userId int
AS
BEGIN
	INSERT INTO STORES (name, description, userId) 
	VALUES (@name, @description, @userId) 
END
GO
