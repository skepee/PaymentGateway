CREATE TABLE [dbo].[Order] (
    [OrderId]     INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]  INT            NULL,
    [Status]      VARCHAR (1000) NULL,
    [DateOrder]   DATETIME       NULL,
    [Description] VARCHAR (1000) NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId])
);

