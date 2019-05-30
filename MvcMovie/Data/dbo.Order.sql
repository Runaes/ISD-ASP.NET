CREATE TABLE [dbo].[Order] (
    [ID]     INT        NOT NULL,
    [UserID]          NCHAR (10) NULL,
    [OrderListID] NCHAR (10) NULL,
    [Payment] BIT NULL, 
    [PaymentAmt] FLOAT NULL, 
    [PurchaseDate] DATE NULL, 
    [PaymentType] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([ID])
);

