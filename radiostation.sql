--
-- Файл сгенерирован с помощью SQLiteStudio v3.2.1 в Ср ноя 11 23:03:31 2020
--
-- Использованная кодировка текста: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Таблица: График_работы
CREATE TABLE График_работы
(
  дата DATE NOT NULL,
  время_ INT NOT NULL,
  код_сотрудника NODATATYPE NOT NULL,
  код_записи NODATATYPE NOT NULL,
  FOREIGN KEY (код_сотрудника) REFERENCES Сотрудники(код_сотрудника),
  FOREIGN KEY (код_записи) REFERENCES Записи(код_записи)
);

-- Таблица: Должности
CREATE TABLE Должности
(
  наименование_должности CHAR(15) NOT NULL,
  оклад INT NOT NULL,
  обязанности VARCHAR(500) NOT NULL,
  требования VARCHAR(500) NOT NULL,
  код_должности NODATATYPE NOT NULL,
  PRIMARY KEY (код_должности)
);

-- Таблица: Жанры
CREATE TABLE Жанры
(
  наименование VARCHAR(50) NOT NULL,
  описание VARCHAR(120) NOT NULL,
  код_жанра NODATATYPE NOT NULL,
  PRIMARY KEY (код_жанра),
  UNIQUE (описание)
);

-- Таблица: Записи
CREATE TABLE Записи
(
  год DATE NOT NULL,
  альбом CHAR(10) NOT NULL,
  код_записи NODATATYPE NOT NULL,
  рейтинг INT NOT NULL,
  дата_записи DATE NOT NULL,
  длительность CHAR(10) NOT NULL,
  наименование CHAR(10) NOT NULL,
  код_исполнителя NODATATYPE NOT NULL,
  код_жанра NODATATYPE NOT NULL,
  PRIMARY KEY (код_записи),
  FOREIGN KEY (код_исполнителя) REFERENCES Исполнители(код_исполнителя),
  FOREIGN KEY (код_жанра) REFERENCES Жанры(код_жанра),
  UNIQUE (наименование)
);

-- Таблица: Исполнители
CREATE TABLE Исполнители
(
  наименование VARCHAR(50) NOT NULL,
  описание VARCHAR(120) NOT NULL,
  код_исполнителя NODATATYPE NOT NULL,
  PRIMARY KEY (код_исполнителя),
  UNIQUE (описание)
);

-- Таблица: Сотрудники
CREATE TABLE Сотрудники
(
  ФИО VARCHAR(100) NOT NULL,
  код_сотрудника NODATATYPE NOT NULL,
  Возраст INT NOT NULL,
  пол CHAR(10) NOT NULL,
  телефон INT NOT NULL,
  адрес VARCHAR(100) NOT NULL,
  паспортные_данны VARCHAR(500) NOT NULL,
  код_должности NODATATYPE NOT NULL,
  PRIMARY KEY (код_сотрудника),
  FOREIGN KEY (код_должности) REFERENCES Должности(код_должности),
  UNIQUE (телефон),
  UNIQUE (адрес),
  UNIQUE (паспортные_данны)
);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
