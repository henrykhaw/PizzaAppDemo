CREATE TABLE [dbo].[PizzaData] (
    [Id]  INT            IDENTITY (1, 1) NOT NULL,
    [lat] DECIMAL (9, 6) NOT NULL,
    [lng] DECIMAL (9, 6) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

