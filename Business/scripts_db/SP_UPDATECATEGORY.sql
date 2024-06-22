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
CREATE PROCEDURE spUpdateCategory 
	@id int,
	@description varchar(50),
	@imageUrl varchar(1000)
AS
BEGIN
	update CATEGORIES 
	set description = @description, imageUrl =  @imageUrl 
	where id = @id
END
GO
