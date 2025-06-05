-- Задание 1
INSERT INTO [dbo].[Book]
           ([AuthorId]
		   ,[Title])
     VALUES
           (1, 'Рабство нашего времени');

-- Задание 2
 DELETE FROM [dbo].[Customer]
	   WHERE Phone is null;

-- Задание 3
INSERT INTO [dbo].[Book]
           ([AuthorId]
		   ,[Title]
		   ,[Price])
     VALUES
           (1, 'Сказки нашего времени', 200);

UPDATE [dbo].[Book]
   SET [Price] -= 100
 WHERE Title LIKE '%Сказки%';

-- Задание 4
SELECT Author.Surname, Author.Name, Book.Title, Book.Price, Book.PublicationYear
INTO Prose
FROM Book
INNER JOIN Author ON Book.AuthorId = Author.AuthorId
WHERE Book.Genre = 'проза';

-- Задание 5
 DELETE FROM [dbo].[Order]
 WHERE OrderId NOT IN (SELECT OrderId
					FROM OrderedBook);

-- Задание 6
UPDATE [dbo].[Book]
SET Book.Price += 100
FROM Book
	INNER JOIN Author ON Author.AuthorId = Book.AuthorId
WHERE Author.Country = 'Россия';

-- Задание 7
UPDATE [dbo].[Book]
SET Price = CASE
	WHEN Genre = 'проза' THEN Price * 0.9
	WHEN Genre = 'поэзия' THEN Price + 100
	ELSE Price
END