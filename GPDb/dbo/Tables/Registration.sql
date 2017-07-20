CREATE TABLE [dbo].[Registration]
(
	[Id]                  INT             IDENTITY (1, 1) NOT NULL,
	[RegistrationType] int,
	[AttendeeId] int,
	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] NVARCHAR(256) NOT NULL DEFAULT 'SYSTEM', 
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedBy] NVARCHAR(256) NOT NULL DEFAULT 'SYSTEM', 
    [Status] INT NOT NULL DEFAULT 1,
	    CONSTRAINT [PK_Registrations] PRIMARY KEY CLUSTERED ([Id] ASC)


)
