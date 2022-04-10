USE [TaskNo1]
GO

ALTER TABLE [dbo].[ORDERS] DROP CONSTRAINT [FK_ORDERS_ORDERS]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MOVIES]') AND type in (N'U'))
DROP TABLE [dbo].[MOVIES]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ORDERS]') AND type in (N'U'))
DROP TABLE [dbo].[ORDERS]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MOVIES](
	[MOVIE_ID] [int] IDENTITY(1, 1) NOT NULL,
	[MOVIE_TITLE] [varchar](100) NOT NULL,
	[RELEASE_DATE] [date] NOT NULL,
	[PRICE] [money] NOT NULL,
	[RATING] [decimal](5, 2) NOT NULL,
	[GENRE] [varchar](20) NULL,
 CONSTRAINT [PK_MOVIES] PRIMARY KEY CLUSTERED ([MOVIE_ID] ASC)
 );
 GO

 CREATE TABLE [dbo].[ORDERS](
	[ORDER_ID] [int] IDENTITY(1, 1) NOT NULL,
	[RENTAL_DATE] [date] NOT NULL,
	[RETURN_DATE] [date] NOT NULL,
	[MOVIE_ID] [int] NOT NULL,
	[NET_AMOUNT] [money] NOT NULL,
	[DISCOUNT] [decimal](5, 2) NULL,
	[GROSS_AMOUNT] [money] NOT NULL,
CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED ([ORDER_ID] ASC)
);
GO

ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD CONSTRAINT [FK_ORDERS_ORDERS] FOREIGN KEY([MOVIE_ID])
REFERENCES [dbo].[MOVIES] ([MOVIE_ID])
GO

SET IDENTITY_INSERT [dbo].[MOVIES] ON
INSERT INTO [dbo].[MOVIES]([MOVIE_ID], [MOVIE_TITLE], [RELEASE_DATE], [PRICE], [RATING], [GENRE])
VALUES
(1, 'The Shawshank Redemption', '1994-09-10', 39.99, 9.25, 'drama'),
(2, 'The Godfather', '1972-03-15', 19.99, 9.15, 'crime'),
(3, 'The Godfather: Part II', '1974-12-12', 16.99, 9.00, 'crime'),
(4, 'The Dark Knight', '2008-07-18', 24.99, 9.00, 'action'),
(5, '12 Angry Men', '1957-04-10', 9.99, 8.95, 'drama'),
(6, 'Schindler''s List', '1993-11-30', 24.99, 8.90, 'biography'),
(7, 'The Lord of the Rings: The Return of the King', '2003-12-17', 6.99, 8.90, 'action'),
(8, 'Pulp Fiction', '1994-10-14', 11.99, 8.85, 'crime'),
(9, 'The Good, the Bad and the Ugly', '1966-12-23', 14.99, 8.80, 'western'),
(10, 'The Lord of the Rings: The Fellowship of the Ring', '2001-12-10', 6.99, 8.80, 'action'),
(11, 'Joker', '2019-08-31', 39.99, 8.40, 'crime'),
(12, 'Parasite', '2019-05-21', 21.99, 8.60, 'comedy')
SET IDENTITY_INSERT [dbo].[MOVIES] OFF
GO

SET IDENTITY_INSERT [dbo].[ORDERS] ON
INSERT INTO [dbo].[ORDERS]([ORDER_ID], [RENTAL_DATE], [RETURN_DATE], [MOVIE_ID], [NET_AMOUNT], [DISCOUNT], [GROSS_AMOUNT])
VALUES
(1, '2019-07-04', '2019-07-11', 4, 24.99, 0.25, 23.053275),
(2, '2020-01-23', '2020-01-30', 7, 6.99, 0.25, 6.448275),
(3, '2020-04-13', '2020-04-20', 9, 16.99, 0.25, 15.673275),
(4, '2020-05-20', '2020-05-23', 11, 39.99, 0, 49.1877),
(5, '2020-07-18', '2020-07-25', 5, 9.99, 0.25, 9.21577),
(6, '2020-09-22', '2020-09-29', 2, 19.99, 0.25, 18.440775),
(7, '2020-12-07', '2020-12-10', 1, 39.99, 0.25, 36.890775),
(8, '2021-03-03', '2021-03-10', 12, 21.99, 0, 27.0477)
SET IDENTITY_INSERT [dbo].[ORDERS] OFF
GO
