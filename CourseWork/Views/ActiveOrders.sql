CREATE VIEW vw_ActiveOrders AS
SELECT 
    O.OrderID,
    C.ClientName,
    B.BookName,
    O.DateTaken,
    O.ReturnDate,
    O.TotalPrice,
    W.WorkerName
FROM Orders O
JOIN Clients C ON O.ClientID = C.ClientID
JOIN Books B ON O.BookID = B.BookID
JOIN Workers W ON O.WorkerID = W.WorkerID
WHERE O.ReturnDate >= GETDATE();