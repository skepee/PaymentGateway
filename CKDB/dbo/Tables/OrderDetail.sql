CREATE TABLE [dbo].[OrderDetail] (
    [OrderDetailId] INT           IDENTITY (1, 1) NOT NULL,
    [OrderId]       INT           NULL,
    [Product]       VARCHAR (100) NULL,
    [Price]         MONEY         NULL,
    [Quantity]      INT           NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED ([OrderDetailId] ASC)
);

