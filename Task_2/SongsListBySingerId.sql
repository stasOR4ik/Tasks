USE [MusicDB]
GO
/****** Object:  StoredProcedure [dbo].[SongsListBySingerId]    Script Date: 08.05.2018 22:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SongsListBySingerId] 
	@singerId int
AS
SELECT * FROM Songs 
WHERE @singerId = Songs.SingerId