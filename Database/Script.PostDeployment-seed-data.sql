/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT [dbo].[States] ([Id],[StateName]) VALUES (1,N'Alabama')
INSERT [dbo].[States] ([Id],[StateName]) VALUES (2,N'Alaska')
INSERT [dbo].[States] ([Id],[StateName]) VALUES (3,N'Arizona')
INSERT [dbo].[States] ([Id],[StateName]) VALUES (4,N'Arkansas')
