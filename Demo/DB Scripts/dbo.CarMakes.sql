CREATE TABLE [dbo].[CarMakes] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CarMakes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

