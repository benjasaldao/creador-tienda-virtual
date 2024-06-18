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
CREATE PROCEDURE spUpdateStore 
	@name varchar(50),
	@description varchar(1000),
	@id int 
AS
BEGIN
	UPDATE STORES 
	set name = @name, description = @description 
	where id = @id
END
GO
