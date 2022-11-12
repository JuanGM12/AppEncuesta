USE MASTER
GO
CREATE DATABASE Encuesta
GO
USE Encuesta
GO
CREATE TABLE ROLES (IDRol INT PRIMARY KEY, Rol varchar(30))
GO
CREATE TABLE USUARIOS (Cedula bigint primary key, Nombre varchar(30), Voto bit , IDRol int FOREIGN KEY REFERENCES ROLES(IDRol))
GO
INSERT INTO ROLES VALUES
(1, 'Administrador'),
(2, 'Usuario')
GO
INSERT INTO USUARIOS VALUES
(1000087873,'El Pepe',0, 2),
(1000087872,'Juan',0, 1),
(1001250749, 'Pepito', 0, 2)
GO

