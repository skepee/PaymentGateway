CREATE TABLE [dbo].[CustomerPayment] (
    [CustomerPaymentId] INT          IDENTITY (1, 1) NOT NULL,
    [CardNumber]        VARCHAR (20) NULL,
    [ExpiryMonth]       INT          NULL,
    [ExpiryYear]        INT          NULL,
    [Currency]          VARCHAR (3)  NULL,
    [Cvv]               INT          NULL,
    CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED ([CustomerPaymentId] ASC)
);

