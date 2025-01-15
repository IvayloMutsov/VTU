CREATE PROCEDURE GetOrdersByClient
    @ClientID INT
AS
BEGIN
    SELECT 
        O.OrderID,
        B.BookName,
        O.DateTaken,
        O.ReturnDate,
        O.TotalPrice
    FROM Orders O
    JOIN Books B ON O.BookID = B.BookID
    WHERE O.ClientID = @ClientID;
END;