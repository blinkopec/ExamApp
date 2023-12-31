USE [ExamDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 05.07.2023 4:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[idAdmin] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 05.07.2023 4:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[middlename] [varchar](50) NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 05.07.2023 4:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[idManager] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[middlename] [varchar](50) NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05.07.2023 4:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[price] [int] NULL,
	[manufacturer] [varchar](50) NULL,
	[description] [varchar](100) NULL,
	[amount] [int] NULL,
	[imageProduct] [varchar](300) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 05.07.2023 4:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idStorage] [int] NOT NULL,
	[idOrder] [int] NOT NULL,
	[idClient] [int] NOT NULL,
	[amount] [int] NULL,
	[idProduct] [int] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([idClient], [name], [surname], [middlename], [login], [password]) VALUES (2, N'Макар', N'Пономарев', N'Павлович', N'makar', N'makar')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([idProduct], [name], [price], [manufacturer], [description], [amount], [imageProduct]) VALUES (1, N'Карбюратор', 1000, N'КЭМЗ', N'хороший безопасный классный', 23, N'F:\projects\WpfAppExam\WpfAppExam\Images\mike.jpg')
INSERT [dbo].[Product] ([idProduct], [name], [price], [manufacturer], [description], [amount], [imageProduct]) VALUES (2, N'Двигатель', 20000, N'Макар', N'ужасный безобразный клевый', 13, N'F:\projects\WpfAppExam\WpfAppExam\Images\prigojin.jpg')
INSERT [dbo].[Product] ([idProduct], [name], [price], [manufacturer], [description], [amount], [imageProduct]) VALUES (3, N'dd', 0, N'dd', N'dd', 0, N'F:\projects\WpfAppExam\WpfAppExam\Images\minion.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Client]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([idProduct])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Product]
GO
