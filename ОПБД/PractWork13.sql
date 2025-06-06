-- ������� 1
SELECT *
FROM Book
WHERE Genre = '�����' AND Price >= 500 AND Price <= 1000;

-- ������� 2
SELECT Surname, Name, Phone
FROM Customer
WHERE Phone IS NOT NULL;

-- ������� 3
SELECT *
FROM Book
WHERE Title LIKE '%������%';

-- ������� 4
SELECT *
FROM Book
WHERE Title LIKE '�%';

-- ������� 5
SELECT Country, COUNT(*) '���������� �������'
FROM Author
GROUP BY Country
HAVING COUNT(*) > 0;

-- ������� 6
SELECT OrderId, Quantity
FROM OrderedBook
GROUP BY OrderId, Quantity
HAVING COUNT(*) > 5;