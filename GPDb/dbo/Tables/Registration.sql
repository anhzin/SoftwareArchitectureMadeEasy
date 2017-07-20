CREATE TABLE [dbo].[Registration]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[RegistrationTypeId] int,
	[AttendeeId] int,
	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] NVARCHAR(256) NOT NULL DEFAULT 'SYSTEM', 
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedBy] NVARCHAR(256) NOT NULL DEFAULT 'SYSTEM', 
    [Status] INT NOT NULL DEFAULT 1


)
