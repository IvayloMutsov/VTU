CREATE DATABASE LibraryCourseWorkVTU;

CREATE TABLE Workers(
WorkerID int NOT NULL PRIMARY KEY IDENTITY
,WorkerName nvarchar(30) NOT NULL
,WorkRole nvarchar(10) NOT NULL
,WorkerContactNumber nvarchar(10) NOT NULL
,WorkShift nvarchar(11) NOT NULL
,Salary int NOT NULL);

CREATE TABLE Authors(
AuthorID int NOT NULL PRIMARY KEY IDENTITY
,AuthorName nvarchar(30) NOT NULL
,AuthorCountry nvarchar(50));

CREATE TABLE Publishers(
PublisherID int NOT NULL PRIMARY KEY IDENTITY
,PublisherName nvarchar(30) NOT NULL
,PublisherAdress nvarchar(50) NOT NULL
,PublisherContactPhone nvarchar(10)
,PublisherEmail nvarchar(20));

CREATE TABLE Books(
BookID int NOT NULL PRIMARY KEY IDENTITY
,BookName nvarchar(30) NOT NULL
,BookGenre nvarchar(20)
,AuthorID int  FOREIGN KEY REFERENCES Authors(AuthorID)
,PublisherID int FOREIGN KEY REFERENCES Publishers(PublisherID)
,PublishDate DATE
,PricePerMonth decimal(5,2) NOT NULL);

CREATE TABLE Clients(
ClientID int NOT NULL PRIMARY KEY IDENTITY
,CLientName nvarchar(30) NOT NULL
,ClientAdress nvarchar(50)
,ClientPhone nvarchar(10) NOT NULL
,ClientEmail nvarchar(20) NOT NULL);

CREATE TABLE Orders(
OrderID int NOT NULL PRIMARY KEY IDENTITY
,BookID int NOT NULL FOREIGN KEY REFERENCES Books(BookID)
,ClientID int NOT NULL FOREIGN KEY REFERENCES Clients(ClientID)
,DateTaken DATE NOT NULL
,ReturnDate DATE NOT NULL
,WorkerID int NOT NULL FOREIGN KEY REFERENCES Workers(WorkerID));

INSERT INTO Workers (WorkerName, WorkRole, WorkerContactNumber, WorkShift, Salary) VALUES
('Alice Johnson', 'Librarian', '0834567890', '09:00-17:00', 1200),
('Bob Smith', 'Volunteer', '0845678901', '10:30-18:30', 800),
('Charlie Brown', 'Chief', '0856789012', '12:00-20:00', 2000),
('Diana Prince', 'Librarian', '0867890123', '08:00-16:00', 1100),
('Ethan Hunt', 'Volunteer', '0878901234', '08:00-16:00', 700),
('Fiona Apple', 'Librarian', '0889012345', '10:00-18:00', 1300);

INSERT INTO Authors (AuthorName, AuthorCountry) VALUES
('Ernest Hemingway', 'United States'),
('Jane Austen', 'United Kingdom'),
('Gabriel García Márquez', 'Colombia'),
('Haruki Murakami', 'Japan'),
('Hristo Botev', 'Bulgaria'),
('Leo Tolstoy', 'Russia'),
('J.K. Rowling', 'United Kingdom'),
('Ivan Vazov', 'Bulgaria');

INSERT INTO Publishers (PublisherName, PublisherAdress, PublisherContactPhone, PublisherEmail) VALUES
('Penguin Random House', '123 Penguin Way, New York, NY', '1234567890', 'contact@gmail.com'),
('HarperCollins', '195 Broadway, New York, NY', '2345678901', 'info@gmail.com'),
('Simon & Schuster', '1230 Avenue of the Americas, New York, NY', '3456789012', 'support@gmail.com'),
('Hachette Book Group', '1290 Avenue of the Americas, New York, NY', '4567890123', 'supphelp@yahoo.com'),
('Prosveta', 'Simeon Veliki street, Sofia, Bulgaria', '5678901234', 'prosveta@abv.bg');

INSERT INTO Books (BookName, BookGenre, AuthorID, PublisherID, PublishDate, PricePerMonth) VALUES
('The Adventures of Tom Sawyer', 'Fiction', 1, 1, '1876-04-01', 5.99),
('Pride and Prejudice', 'Romance', 2, 2, '1813-01-28', 6.99),
('One Hundred Years of Solitude', 'Magical Realism', 3, 3, '1967-05-30', 7.99),
('Norwegian Wood', 'Fiction', 4, 4, '1987-09-04', 8.99),
('Things Fall Apart', 'Historical Fiction', 5, 5, '1958-06-17', 5.49),
('The Great Gatsby', 'Fiction', 6, 1, '1925-04-10', 6.49),
('Pod Igoto', 'Historical novel', 8, 5, '1894-01-01', 10.50),
('Chichovtsi', 'Comedy', 8, 5, '1896-01-01', 5.49),
('Baladi i stihotvoreniya', 'Poetry', 5, 5, '1870-01-01', 3.99);

INSERT INTO Clients (ClientName, ClientAdress, ClientPhone, ClientEmail) VALUES
('John Doe', '123 Elm St, Springfield', '0834567890', 'john_doe@gmail.com'),
('Jane Smith', '456 Oak St, Metropolis', '0845678901', 'janesmith@gmail.com'),
('Alice Smith', '789 Pine St, Gotham', '0856789012', 'AliceSmith@yahoo.com'),
('Bob Brown', '101 Maple St, Star City', '0867890123', 'Bob_Brown@gmail.com'),
('Ivan Petrov', 'Georgi Rakovski, Pernik', '0878901234', 'vankatapetrov@abv.bg');

INSERT INTO Orders (BookID, ClientID, DateTaken, ReturnDate, WorkerID) VALUES
(1, 1, '2024-01-15', '2024-02-15', 1),
(2, 2, '2024-01-20', '2024-02-20', 2),
(3, 3, '2024-01-25', '2024-02-25', 3),
(4, 4, '2024-01-30', '2024-02-28', 1),
(5, 5, '2024-02-01', '2024-03-01', 2),
(6, 1, '2024-02-05', '2024-03-05', 4),
(7, 3, '2024-02-10', '2024-03-10', 4),
(8, 5, '2024-02-12', '2024-03-12', 4),
(9, 2, '2024-02-15', '2024-03-15', 3),
(3, 4, '2024-02-18', '2024-03-18', 5),
(2, 1, '2024-02-20', '2024-03-20', 6),
(1, 2, '2024-02-22', '2024-03-22', 6),
(9, 3, '2024-02-25', '2024-03-25', 5),
(4, 4, '2024-02-28', '2024-03-28', 5),
(7, 5, '2024-03-01', '2024-04-30', 6),
(5, 2, '2024-03-05', '2024-04-05', 2),
(4, 2, '2024-03-10', '2024-04-10', 2),
(8, 3, '2024-03-15', '2024-04-15', 3),
(6, 1, '2024-03-20', '2024-04-20', 1),
(7, 5, '2024-03-25', '2024-04-25', 2);

ALTER TABLE Orders ADD TotalPrice DECIMAL(5,2) NULL;
UPDATE Orders SET TotalPrice = DATEDIFF(MONTH, DateTaken, ReturnDate) * (SELECT PricePerMonth FROM Books WHERE Books.BookID = Orders.BookID);

SELECT BookName ,PublisherName
FROM Books JOIN Publishers on Books.PublisherID = Publishers.PublisherID
WHERE Books.PublishDate >= '1900-01-01';

SELECT AVG(Salary) as Aveage_Salary FROM Workers WHERE WorkRole NOT LIKE 'Volunteer';

SELECT PublisherName, COUNT(BookID) AS NumberOfBooks
FROM Books JOIN Publishers ON Books.PublisherID = Publishers.PublisherID
GROUP BY PublisherName;

SELECT 
    BookID,
    BookName,
    PricePerMonth,
    CASE 
        WHEN PricePerMonth > 10 THEN 'Expensive'
        WHEN PricePerMonth BETWEEN 6 AND 10 THEN 'Moderate'
        WHEN PricePerMonth BETWEEN 1 AND 5.99 THEN 'Affordable'
        ELSE 'Free'
    END AS PriceCategory FROM Books;

SELECT 
    B.BookID,
    B.BookName,
    A.AuthorName,
    B.PublishDate,
    DATEDIFF(YEAR, B.PublishDate, GETDATE()) AS YearsSincePublished
FROM Books B JOIN Authors A ON B.AuthorID = A.AuthorID
WHERE B.PublishDate <= GETDATE();