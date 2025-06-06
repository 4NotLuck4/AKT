-- ������� 1
SELECT *
FROM Book;

-- ������� 2
SELECT Surname + ' ' + Name
FROM Author;

-- ������� 3
SELECT DISTINCT Country
FROM Author;

-- ������� 4
SELECT BookId AS '������������� �����', Title AS '�������� �����', Price * 0.95 AS '���� �� ������� 5%'
FROM Book
ORDER BY Price DESC, Title;

-- ������� 5
SELECT AuthorId, Title, COUNT(*) Count
FROM Book
GROUP BY AuthorId, Title

-- ������� 6
SELECT COUNT(*) '����������� ����'
	, MIN(Price) '����������� ��������� ����'
	, MAX(Price) '������������ ��������� ����'
	, AVG(Price) '������� ��������� ����'
FROM Book;

-- ������� 7
SELECT Genre, MAX(Price) '������������ ��������� ���� � ������ �����', MIN(Price) '����������� ��������� ���� � ������ �����', COUNT(*) '����������� ���� � ������ �����' 
FROM Book
GROUP BY Genre