CREATE TABLE [dbo].[Skills]
(
	[skillID] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NULL, 
    [description] VARCHAR(MAX) NULL, 
    [combat] BIT NULL, 
    [psychic] BIT NULL,
    [Background_fk_id] INT NULL FOREIGN KEY REFERENCES Background(backgroundID)
)
