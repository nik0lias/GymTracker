CREATE SCHEMA [HR] AUTHORIZATION [dbo]
GO

/****** Object:  Table [HR].[Employee]    Script Date: 06/12/2013 11:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[EmployeeReference] [nvarchar](max) NOT NULL,
	[Forename] [nvarchar](max) NOT NULL,
	[HomePhone] [nvarchar](max) NULL,
	[Middlename] [nvarchar](max) NULL,
	[MobilePhone] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[EmploymentEndDate] [datetime2](7) NULL,
	[EmploymentStartDate] [datetime2](7) NULL,
	[NationalInsuranceNumber] [nvarchar](max) NULL,
	[PlaceOfBirth] [nvarchar](max) NULL,
 CONSTRAINT [PK_HR.Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

