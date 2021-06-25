CREATE TABLE [dbo].[Customer] (
    [CustomerId]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (100) NULL,
    [Surname]           VARCHAR (100) NULL,
    [DateOfBirth]       DATETIME      NULL,
    [Email]             VARCHAR (100) NULL,
    [CustomerPaymentId] INT           NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customer_CustomerPayment] FOREIGN KEY ([CustomerPaymentId]) REFERENCES [dbo].[CustomerPayment] ([CustomerPaymentId])
);

