CREATE TABLE [dbo].[Class]
(
	[classID] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NULL, 
    [description] VARCHAR(MAX) NULL, 
    [abilities] VARCHAR(50) NULL,
    [ability_description] VARCHAR(MAX) NULL, 
    [health_points_dice] INT NULL,
    [health_points_description] VARCHAR(MAX) NULL, 
    [background_fk_id] INT NULL FOREIGN KEY REFERENCES Background(skillID),
)
