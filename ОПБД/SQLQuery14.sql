--Task 1
SELECT Book.BookId, Book.Title, Author.[Name], Author.Surname, Book.Price
FROM Book
	JOIN Author ON Book.AuthorId = Author.AuthorId;

--Task 2
SELECT OrderedBook.OrderId, 
	Book.BookId, 
	Book.Title, 
	Author.[Name], 
	Author.Surname, 
	Book.Price, 
	OrderedBook.Quantity, 
	Book.Price * OrderedBook.Quantity 'Cost'
FROM Book
	JOIN Author ON Book.AuthorId = Author.AuthorId
	JOIN OrderedBook ON Book.BookId = OrderedBook.BookId;

--Task 3
SELECT [Order].OrderId,
	[Order].OrderDate,
	Book.Price * OrderedBook.Quantity 'Total price'
FROM OrderedBook
	JOIN Book ON Book.BookId = OrderedBook.BookId
	JOIN [Order] ON [Order].OrderId = OrderedBook.OrderId
ORDER BY OrderDate DESC;

--Task 4
SELECT Customer.CustomerId, 
	Customer.[Login],
	COUNT([Order].OrderId)
FROM Customer	
	LEFT JOIN [Order] ON Customer.CustomerId = [Order].OrderId
GROUP BY Customer.CustomerId, Customer.[Login];

--Task 5
SELECT *
FROM [Order]
WHERE [Order].OrderId NOT IN (SELECT DISTINCT  OrderId
							  FROM [Order])