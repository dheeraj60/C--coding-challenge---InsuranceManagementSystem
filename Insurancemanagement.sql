CREATE DATABASE InsuranceManagementDB;
GO

USE InsuranceManagementDB;

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

CREATE TABLE Clients (
    ClientId INT PRIMARY KEY IDENTITY(1,1),
    ClientName NVARCHAR(50) NOT NULL,
    ContactInfo NVARCHAR(100),
    PolicyId INT
);

CREATE TABLE Policies (
    PolicyId INT PRIMARY KEY IDENTITY(1,1),
    PolicyName NVARCHAR(100) NOT NULL,
    PolicyDetails NVARCHAR(MAX)
);

CREATE TABLE Claims (
    ClaimId INT PRIMARY KEY IDENTITY(1,1),
    ClaimNumber NVARCHAR(50),
    DateFiled DATE,
    ClaimAmount DECIMAL(10, 2),
    Status NVARCHAR(20),
    PolicyId INT,
    ClientId INT,
    FOREIGN KEY (PolicyId) REFERENCES Policies(PolicyId),
    FOREIGN KEY (ClientId) REFERENCES Clients(ClientId)
);

CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATE,
    PaymentAmount DECIMAL(10, 2),
    ClientId INT,
    FOREIGN KEY (ClientId) REFERENCES Clients(ClientId)
);







