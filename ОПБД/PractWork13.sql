-- Задание 1
SELECT *
FROM Book
WHERE Genre = 'проза' AND Price >= 500 AND Price <= 1000;

-- Задание 2
SELECT Surname, Name, Phone
FROM Customer
WHERE Phone IS NOT NULL;

-- Задание 3
SELECT *
FROM Book
WHERE Title LIKE '%Сказки%';

-- Задание 4
SELECT *
FROM Book
WHERE Title LIKE 'С%';

-- Задание 5
SELECT Country, COUNT(*) 'Колчиество авторов'
FROM Author
GROUP BY Country
HAVING COUNT(*) > 0;

-- Задание 6
SELECT OrderId, Quantity
FROM OrderedBook
GROUP BY OrderId, Quantity
HAVING COUNT(*) > 5;