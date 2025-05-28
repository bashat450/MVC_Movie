CREATE DATABASE MovieBookingDB;

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    MobileNumber CHAR(10) NOT NULL UNIQUE
);

CREATE TABLE Movies (
    MovieId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    DurationMinutes INT NOT NULL,
    ReleaseDate DATE NOT NULL
);
--composite primary key
CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    MovieId INT FOREIGN KEY REFERENCES Movies(MovieId),
    NumberOfSeats INT NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETDATE()
);

Use [MovieBookingDB];

