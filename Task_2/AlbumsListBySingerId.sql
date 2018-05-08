USE [MusicDB]
GO
/****** Object:  StoredProcedure [dbo].[AlbumsListBySingerId]    Script Date: 08.05.2018 22:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AlbumsListBySingerId] 
	@singerId int
AS
SELECT Albums.Id, Albums.Name, Albums.SingerId FROM Albums 
WHERE @singerId = Albums.SingerId