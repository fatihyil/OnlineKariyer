CREATE TABLE JobAdvertUser (
	Id int IDENTITY(1,1) PRIMARY KEY,
    JobAdvertId int,
	UserId int	
);

	

CREATE TABLE Company(
	Id int IDENTITY(1,1) PRIMARY KEY,
	CompanyName nvarchar(max),
	WorkerCount int,

);

DROP TABLE JobAdvertUser



ALTER TABLE JobAdvertUser
ALTER COLUMN UserId nvarchar(450)

