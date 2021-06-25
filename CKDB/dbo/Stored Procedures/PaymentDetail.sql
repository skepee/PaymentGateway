-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PaymentDetail]
(
@bankIdentifier uniqueidentifier 
)
AS
BEGIN
	SET NOCOUNT ON;

	select  od.OrderDetailId,
			b.BankOperationId as BankIdentifier, 
			b.[Status], 
			o.DateOrder, 
			o.[Description],
			od.Product, 
			od.Price, 
			od.Quantity 
	from dbo.[Order] o 
	left join OrderDetail od on od.Orderid=o.Orderid
	left join dbo.BankOperation b on o.orderid=b.orderid
	where b.BankOperationId=@bankIdentifier

END
