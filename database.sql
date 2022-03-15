--SQL script to create the Company table in the database. 
--Please note that the data must exist. Default the name is "centisoft" this can be changed in the appsettings.json


CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Street] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[ZipCode] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO

