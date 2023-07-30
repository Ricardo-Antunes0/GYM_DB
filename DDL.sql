

USE Workouts;
GO

CREATE TABLE Users (
  id INT NOT NULL PRIMARY KEY IDENTITY,
  username VARCHAR(50) UNIQUE,
  password VARCHAR(50)
);

CREATE TABLE Treinos(
	id_treino INT IDENTITY NOT NULL PRIMARY KEY,
	id_atleta INT NOT NULL REFERENCES Users(id),
	dia_semana VARCHAR(13) NOT NULL,		
	Tipo_treino VARCHAR(50) NOT NULL,		-- EX: Treino de peito, costas, pernas, ombro, etc
	Treino VARCHAR(500) NOT NULL,			--Dados sobre o treino
);
GO

DROP TABLE Treinos;
DROP TABLE Users;
DROP PROCEDURE VerifyLogin;



CREATE PROCEDURE VerifyLogin (@username VARCHAR(50), @password VARCHAR(50), @valid INT OUT)
AS
	BEGIN
	  DECLARE @v_count INT;
 
		SELECT @v_count = COUNT(*) FROM Users WHERE username = @username AND password = @password;
		IF @v_count = 1
			SET @valid = 1;
		ELSE
			SET @valid = 0;
		END; 
GO






INSERT INTO Users VALUES ('Ricardo Antunes', 'Ricardo0123');
INSERT INTO  Treinos VALUES (1,'segunda-feira', 'Treino de peito', '..');
SELECT * FROM Users;


DECLARE @valid INT;
EXEC VerifyLogin 'Ricardo Antunes', 'Ricardo0123', @valid OUT;
SELECT @valid AS 'Valid';