ALTER TABLE Books
ALTER COLUMN YearPublication DATETIME2;

SELECT * FROM Books;

DROP table Books;

CREATE TABLE Books(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255) NOT NULL,
	Author varchar(255) NOT NULL,
	YearPublication DATETIME2 NOT NULL
)

INSERT INTO Books values('fdsf', 'gdfgf', '1320-01-01T00:00:00');