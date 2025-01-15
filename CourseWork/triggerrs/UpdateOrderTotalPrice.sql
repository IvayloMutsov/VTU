CREATE TRIGGER trg_UpdateOrderTotalPrice
ON Books
AFTER UPDATE
AS
BEGIN
    DECLARE @BookID INT, @PricePerMonth DECIMAL(5,2);
    
    SELECT @BookID = inserted.BookID, @PricePerMonth = inserted.PricePerMonth
    FROM inserted;

    UPDATE O
    SET O.TotalPrice = DATEDIFF(MONTH, O.DateTaken, O.ReturnDate) * @PricePerMonth
    FROM Orders O
    WHERE O.BookID = @BookID;
END;