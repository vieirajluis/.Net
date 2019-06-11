USE [Training]
GO

/****** Object: Table [dbo].[UserInfo] Script Date: 2019-06-11 2:52:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserInfo] (
    [userId]    INT          IDENTITY (1, 1) NOT NULL,
    [firstName] VARCHAR (50) NULL,
    [lastName]  VARCHAR (50) NULL,
    [city]      VARCHAR (50) NULL,
    [state]     VARCHAR (50) NULL,
    [country]   VARCHAR (50) NULL
);