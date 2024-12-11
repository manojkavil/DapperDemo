CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ContactId] INT NOT NULL, 
    [AddressType] VARCHAR(50) NOT NULL, 
    [StreetAddress] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [StateId] INT NOT NULL, 
    [PostalCode] VARCHAR(50) NOT NULL
)
