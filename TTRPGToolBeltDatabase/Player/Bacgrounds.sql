﻿CREATE TABLE [dbo].[Bacgrounds]
(
	[backgroundID] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NULL, 
    [description] VARCHAR(MAX) NULL, 
    [free_skill] INT NULL FOREIGN KEY REFERENCES Skills(skillID),
    [quick_skill] NUMERIC(2) NULL, --FOREIGN KEY REFERENCES Skills(skillID),
    [growth] INT NULL, --FOREIGN KEY REFERENCES Skills(skillID),
    [learning] INT NULL, --FOREIGN KEY REFERENCES Skills(skillID),
)