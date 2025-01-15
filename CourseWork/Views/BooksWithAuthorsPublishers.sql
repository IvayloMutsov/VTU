CREATE VIEW vw_BooksWithAuthorsPublishers AS
SELECT 
    B.BookID,
    B.BookName,
    B.BookGenre,
    B.PublishDate,
    B.PricePerMonth,
    A.AuthorName,
    P.PublisherName,
    P.PublisherAdress,
    P.PublisherContactPhone
FROM Books B
JOIN Authors A ON B.AuthorID = A.AuthorID
JOIN Publishers P ON B.PublisherID = P.PublisherID;