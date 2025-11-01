CREATE TRIGGER trg_CalculateTotalPrice
ON dbo.OrderDetails
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE od
    SET od.TotalPrice = i.Count * i.UnitPrice
    FROM dbo.OrderDetails od
    INNER JOIN inserted i ON od.OrderDetailId = i.OrderDetailId;
END