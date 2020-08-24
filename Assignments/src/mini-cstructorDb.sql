USE [mini-cstructor]
GO

/****** Object:  Table [dbo].[User]    Script Date: 4/13/2016 10:13:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[UserIsAdmin] [bit] NOT NULL CONSTRAINT [DF_User_UserIsAdmin]  DEFAULT ((0)),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Class]    Script Date: 4/13/2016 9:56:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
	[ClassDescription] [varchar](50) NOT NULL,
	[ClassPrice] [smallmoney] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[UserClass]    Script Date: 4/13/2016 9:57:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserClass](
	[ClassId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserClass] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserClass]  WITH CHECK ADD  CONSTRAINT [FK_UserClass_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO

ALTER TABLE [dbo].[UserClass] CHECK CONSTRAINT [FK_UserClass_Class]
GO

ALTER TABLE [dbo].[UserClass]  WITH CHECK ADD  CONSTRAINT [FK_UserClass_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[UserClass] CHECK CONSTRAINT [FK_UserClass_User]
GO


insert into [User] (UserEmail, UserPassword, UserIsAdmin)
		values ('admin', 'admin', 1)

insert into [User] (UserEmail, UserPassword)
		values ('mike', 'mike')

insert into [User] (UserEmail, UserPassword)
		values ('lisa', 'lisa')

insert into [Class] (ClassName, ClassDescription, ClassPrice)
		values ('C#', 'Learn C#', 200)

insert into [Class] (ClassName, ClassDescription, ClassPrice)
		values ('ASP.NET MVC', 'Learn how to create websites', 250)

insert into [Class] (ClassName, ClassDescription, ClassPrice)
		values ('Android', 'Learn how to write Android applications', 500)

insert into [Class] (ClassName, ClassDescription, ClassPrice)
		values ('Design Patterns', 'Learn how to write code better', 300)

GO