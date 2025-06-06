-- Задание 1
SELECT *
FROM Book;

-- Здаание 2
SELECT Surname + ' ' + Name
FROM Author;

-- Задание 3
SELECT DISTINCT Country
FROM Author;

-- Задание 4
SELECT BookId AS 'Идентификатор книги', Title AS 'Название книги', Price * 0.95 AS 'Цена со скидкой 5%'
FROM Book
ORDER BY Price DESC, Title;

-- Задание 5
SELECT AuthorId, Title, COUNT(*) Count
FROM Book
GROUP BY AuthorId, Title

-- Задание 6
SELECT COUNT(*) 'Колчичество книг'
	, MIN(Price) 'Минимальная стоимость книг'
	, MAX(Price) 'Максимальная стоимость книг'
	, AVG(Price) 'Средняя стоимость книг'
FROM Book;

-- Задание 7
SELECT Genre, MAX(Price) 'Максимальная стоимость книг в данном жанре', MIN(Price) 'Минимальная стоимость книг в данном жанре', COUNT(*) 'Колчичество книг в данном жанре' 
FROM Book
GROUP BY Genre