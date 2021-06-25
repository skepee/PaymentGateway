CREATE TABLE [dbo].[BankOperation] (
    [BankOperationId] UNIQUEIDENTIFIER NOT NULL,
    [Status]          VARCHAR (100)    NULL,
    [OrderId]         INT              NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([BankOperationId] ASC),
    CONSTRAINT [FK_Invoice_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId])
);

