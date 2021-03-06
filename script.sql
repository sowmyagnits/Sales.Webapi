USE [SiriusIQ]
GO
/****** Object:  StoredProcedure [dbo].[GetMemberRoles]    Script Date: 1/30/2017 4:07:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMemberRoles] 
	@memberid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT R.Id,R.Name FROM dbo.MemberRole MR
	INNER JOIN Role R ON R.Id=MR.RoleId
	 WHERE MemberId = @memberid
END

GO
/****** Object:  StoredProcedure [dbo].[GetProductDetails]    Script Date: 1/30/2017 4:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProductDetails]
(@productID int)
AS
BEGIN

SELECT P.Description, P.Brand, R.Comments, R.ReviewDate, R.ReviewerName , R.RATINGS
FROM Product P
INNER JOIN Review R ON P.ProductID = R.ProductID
WHERE P.ProductID = @productID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 1/30/2017 4:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN

Select P.PRODUCTID,P.Description, P.Brand, P.ProductID, R.Comments, R.[RATINGS]
FROM Product P
INNER JOIN  Review R 
ON P.ProductID = R.ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 1/30/2017 4:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUser] 
	@emailtovalidate nvarchar(256),
	@passwordtovalidate nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Member where Email = @emailtovalidate and PasswordHash = @passwordtovalidate
END

GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 1/30/2017 4:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[CATEGORYID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [nvarchar](50) NULL,
	[CREATEDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CATEGORYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberClaim]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MemberClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberLogin]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MemberLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberRole]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberRole](
	[MemberId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MemberRoles] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ORDER]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER](
	[ORDERID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [nvarchar](50) NULL,
	[CREATEDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ORDERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ORDERDETAIL]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERDETAIL](
	[ORDERDETAILID] [int] IDENTITY(1,1) NOT NULL,
	[ORDERID] [int] NOT NULL,
	[PRODUCTID] [int] NOT NULL,
	[DESCRIPTION] [nvarchar](50) NULL,
	[CREATEDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ORDERDETAILID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[PRODUCTID] [int] IDENTITY(1,1) NOT NULL,
	[CATEGORYID] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[CREATEDDATE] [datetime] NULL,
	[Brand] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PRODUCTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[REVIEW]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REVIEW](
	[PRODUCTREVIEWID] [int] IDENTITY(1,1) NOT NULL,
	[PRODUCTID] [int] NULL,
	[COMMENTS] [nvarchar](1000) NULL,
	[REVIEWDATE] [datetime] NULL,
	[REVIEWERNAME] [nvarchar](100) NULL,
	[RATINGS] [int] NULL,
	[CREATEDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PRODUCTREVIEWID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/30/2017 4:08:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CATEGORY] ON 

INSERT [dbo].[CATEGORY] ([CATEGORYID], [DESCRIPTION], [CREATEDDATE]) VALUES (1, N'Electronics', CAST(0x0000A70300000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[CATEGORY] OFF
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (3, N'sowmya.siriusiq.com', 1, N'9bc34549d565d9505b287de0cd20ac77be1d3f2c', N'', N'', 1, 0, NULL, 0, 0, N'sowmya siriusiq')
SET IDENTITY_INSERT [dbo].[Member] OFF
SET IDENTITY_INSERT [dbo].[MemberClaim] ON 

INSERT [dbo].[MemberClaim] ([Id], [MemberId], [ClaimType], [ClaimValue]) VALUES (1, 3, N'User', N'User')
INSERT [dbo].[MemberClaim] ([Id], [MemberId], [ClaimType], [ClaimValue]) VALUES (2, 3, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[MemberClaim] OFF
INSERT [dbo].[MemberRole] ([MemberId], [RoleId]) VALUES (3, 1)
INSERT [dbo].[MemberRole] ([MemberId], [RoleId]) VALUES (3, 2)
SET IDENTITY_INSERT [dbo].[ORDER] ON 

INSERT [dbo].[ORDER] ([ORDERID], [DESCRIPTION], [CREATEDDATE]) VALUES (1, N'ElectronicsOrder', NULL)
SET IDENTITY_INSERT [dbo].[ORDER] OFF
SET IDENTITY_INSERT [dbo].[ORDERDETAIL] ON 

INSERT [dbo].[ORDERDETAIL] ([ORDERDETAILID], [ORDERID], [PRODUCTID], [DESCRIPTION], [CREATEDDATE]) VALUES (1, 1, 1, N'TV', NULL)
INSERT [dbo].[ORDERDETAIL] ([ORDERDETAILID], [ORDERID], [PRODUCTID], [DESCRIPTION], [CREATEDDATE]) VALUES (3, 1, 1, N'CAMERA', NULL)
SET IDENTITY_INSERT [dbo].[ORDERDETAIL] OFF
SET IDENTITY_INSERT [dbo].[PRODUCT] ON 

INSERT [dbo].[PRODUCT] ([PRODUCTID], [CATEGORYID], [Description], [CREATEDDATE], [Brand]) VALUES (1, 1, N'TV', CAST(0x0000A70300000000 AS DateTime), N'Samsung')
INSERT [dbo].[PRODUCT] ([PRODUCTID], [CATEGORYID], [Description], [CREATEDDATE], [Brand]) VALUES (4, 1, N'Camera', CAST(0x0000A70300000000 AS DateTime), N'Sony')
SET IDENTITY_INSERT [dbo].[PRODUCT] OFF
SET IDENTITY_INSERT [dbo].[REVIEW] ON 

INSERT [dbo].[REVIEW] ([PRODUCTREVIEWID], [PRODUCTID], [COMMENTS], [REVIEWDATE], [REVIEWERNAME], [RATINGS], [CREATEDDATE]) VALUES (1, 1, N'Very Good TV', CAST(0x0000A70300000000 AS DateTime), N'Niks', 3, CAST(0x0000A70300000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[REVIEW] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
ALTER TABLE [dbo].[MemberClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MemberClaim_dbo.Member_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberClaim] CHECK CONSTRAINT [FK_dbo.MemberClaim_dbo.Member_MemberId]
GO
ALTER TABLE [dbo].[MemberLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MemberLogin_dbo.Member_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberLogin] CHECK CONSTRAINT [FK_dbo.MemberLogin_dbo.Member_MemberId]
GO
ALTER TABLE [dbo].[MemberRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MemberRoles_dbo.Member_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberRole] CHECK CONSTRAINT [FK_dbo.MemberRoles_dbo.Member_MemberId]
GO
ALTER TABLE [dbo].[MemberRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MemberRoles_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberRole] CHECK CONSTRAINT [FK_dbo.MemberRoles_dbo.Roles_RoleId]
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD  CONSTRAINT [FK_ORDERDETAIL_ORDER] FOREIGN KEY([ORDERID])
REFERENCES [dbo].[ORDER] ([ORDERID])
GO
ALTER TABLE [dbo].[ORDERDETAIL] CHECK CONSTRAINT [FK_ORDERDETAIL_ORDER]
GO
ALTER TABLE [dbo].[ORDERDETAIL]  WITH CHECK ADD  CONSTRAINT [FK_ORDERDETAIL_PRODUCT] FOREIGN KEY([PRODUCTID])
REFERENCES [dbo].[PRODUCT] ([PRODUCTID])
GO
ALTER TABLE [dbo].[ORDERDETAIL] CHECK CONSTRAINT [FK_ORDERDETAIL_PRODUCT]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_CATEGORY] FOREIGN KEY([CATEGORYID])
REFERENCES [dbo].[CATEGORY] ([CATEGORYID])
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_CATEGORY]
GO
ALTER TABLE [dbo].[REVIEW]  WITH CHECK ADD  CONSTRAINT [FK_REVIEW_CATEGORY] FOREIGN KEY([PRODUCTID])
REFERENCES [dbo].[PRODUCT] ([PRODUCTID])
GO
ALTER TABLE [dbo].[REVIEW] CHECK CONSTRAINT [FK_REVIEW_CATEGORY]
GO
