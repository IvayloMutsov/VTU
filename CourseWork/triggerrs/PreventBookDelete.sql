CREATE TRIGGER trg_PreventBookDelete
ON Books
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @BookID INT;
    
    SELECT @BookID = deleted.BookID
    FROM deleted;

    IF EXISTS (SELECT 1 FROM Orders WHERE BookID = @BookID AND ReturnDate >= GETDATE())
    BEGIN
        RAISERROR('Cannot delete the book as there are active orders associated with it.', 16, 1);
    END
    ELSE
    BEGIN
        DELETE FROM Books WHERE BookID = @BookID;
    END
END;