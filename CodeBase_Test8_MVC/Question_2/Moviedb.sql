CREATE DATABASE P_MoviesDB;

GO

USE P_MoviesDB;
GO

CREATE TABLE Movie (
    Mid INT PRIMARY KEY,
    Moviename NVARCHAR(255),
    DateofRelease DATE
);

INSERT INTO Movie (Mid, Moviename, DateofRelease)
VALUES
    (1, 'Million Dollar Arm', '2014-05-09'),
    (2, 'Life of Pi', '2012-11-21'),
    (3, 'The Social Network', '2010-11-12');