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
  Age INTEGER NOT NULL,
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
  ('Telme', 'falecomtelme@gmail.com', '30140903', '30140903', 'agnesvarda'),
  ('Jessica', 'jess@example.com.br', '30140903', '30140903', 'minhasenha'),
  ('Clovis', 'clovis@example.com.br', '30140903', '30140903', 'cruzeiro'),
  ('Ian', 'ian@example.com.br', '30140903', '30140903', 'mutha'),
  ('Gabriel', 'gabriel@exemple.com.br', '30140903', '31890003', 'futebol'),
  ('Alvaro', 'alvaro@example.com.br', '30140903', '30140903', 'minhasenha');
GO

INSERT INTO
  Pets (Name, Age, Size, Breed, Hash, UserId)
VALUES
  ('Varda', 8, 'medium', 'mixed', 'fasdfs', 1),
  ('Cabuloso', 1, 'medium', 'caramelo', 'fasdfs', 3),
  ('Fifito', 8, 'medium', 'mixed', 'fasdfs', 4),
  ('Paçoca', 8, 'medium', 'mixed', 'fasdfs', 5),
  ('Favela', 8, 'medium', 'mixed', 'fasdfs', 5);
GO
