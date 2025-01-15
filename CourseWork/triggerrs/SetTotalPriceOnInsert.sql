CREATE TRIGGER trg_SetTotalPriceOnInsert
ON Orders
AFTER INSERT
AS
BEGIN
    DECLARE @OrderID INT, @BookID INT, @DateTaken DATE, @ReturnDate DATE, @PricePerMonth DECIMAL(5,2);

    SELECT @OrderID = inserted.OrderID, @BookID = inserted.BookID, @DateTaken = inserted.DateTaken, @ReturnDate = inserted.ReturnDate
    FROM inserted;

    SELECT @PricePerMonth = PricePerMonth FROM Books WHERE BookID = @BookID;

    UPDATE Orders
    SET TotalPrice = DATEDIFF(MONTH, @DateTaken, @ReturnDate) * @PricePerMonth
    WHERE OrderID = @OrderID;
END;