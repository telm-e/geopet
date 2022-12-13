USE master;
GO

DROP DATABASE IF EXISTS Geopet;
GO

CREATE DATABASE Geopet;
GO

USE Geopet;

CREATE TABLE Users(
  UserId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  Email VARCHAR(50) NOT NULL,
  Phone VARCHAR(50) NOT NULL,
  Cep VARCHAR(50) NOT NULL,
  Password VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Pets (
  PetId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  Birth DATE NOT NULL,
  Size VARCHAR(50) NOT NULL,
  Breed VARCHAR(50) NOT NULL,
  Hash VARCHAR(50) NOT NULL,
  UserId INT,
  FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

INSERT INTO
  Users(Name, Email, Phone, Cep, Password)
VALUES
  ('Telme', 'falecomtelme@gmail.com', '31999999999', '30140903', 'agnesvarda'),
  ('Jessica', 'jess@example.com.br', '34999999999', '30140903', 'minhasenha'),
  ('Clovis', 'clovis@example.com.br', '81999999999', '30140903', 'cruzeiro'),
  ('Ian', 'ian@example.com.br', '21999999999', '30140903', 'mutha'),
  ('Gabriel', 'gabriel@exemple.com.br', '11999999999', '31890003', 'futebol'),
  ('Alvaro', 'alvaro@example.com.br', '41999999999', '30140903', 'minhasenha');
GO

INSERT INTO
  Pets (Name, Birth, Size, Breed, Hash, UserId)
VALUES
  ('Varda', '2015-01-10', 'medium', 'mixed', 'fasdfs', 1),
  ('Cabuloso', '2022-04-13', 'medium', 'caramelo', 'fasdfs', 3),
  ('Fifito', '2010-07-20', 'medium', 'mixed', 'fasdfs', 4),
  ('Paçoca', '2021-10-07', 'medium', 'mixed', 'fasdfs', 5),
  ('Favela', '2020-08-30', 'medium', 'mixed', 'fasdfs', 5);
GO
