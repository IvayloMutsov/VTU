CREATE PROCEDURE GetBooksByGenre
    @BookGenre NVARCHAR(20)
AS
BEGIN
    SELECT 
        BookID,
        BookName,
        AuthorName,
        PublisherName,
        PricePerMonth
    FROM Books B
    JOIN Authors A ON B.AuthorID = A.AuthorID
    JOIN Publishers P ON B.PublisherID = P.PublisherID
    WHERE B.BookGenre = @BookGenre;
END;