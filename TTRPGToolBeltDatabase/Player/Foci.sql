CREATE TABLE [dbo].[Foci]
(
	[fociID] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NULL, 
    [description] VARCHAR(MAX) NULL, 
    [level1_description] VARCHAR(MAX) NULL,
    [level2_description] VARCHAR(MAX) NULL,
    [skill] INT NULL FOREIGN KEY REFERENCES Skills(skillID),

)
