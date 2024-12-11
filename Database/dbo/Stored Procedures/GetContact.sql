CREATE PROCEDURE [dbo].[GetContact]
	@Id int
AS
BEGIN
	SELECT   [ID]
			,[FirstName]
			,[lastName]
			,[Email]
			,[Company]
			,[Title]
	FROM [dbo].[Contacts]
	WHERE Id = @Id;

END