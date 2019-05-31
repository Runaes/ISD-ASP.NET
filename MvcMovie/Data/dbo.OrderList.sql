CREATE TABLE [dbo].[Order] (
    [ID]     INT        NOT NULL,
    [MovieID] NCHAR (10) NULL,
    [Quantity] INT NULL, 
    PRIMARY KEY CLUSTERED ([ID])
);

