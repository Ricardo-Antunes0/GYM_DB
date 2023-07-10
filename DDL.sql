

USE Workouts;
GO

CREATE TABLE Treinos(
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	dia_semana VARCHAR(13) NOT NULL,		
	Tipo_treino VARCHAR(50) NOT NULL,		-- EX: Treino de peito, costas, pernas, ombro, etc
	Treino VARCHAR(500) NOT NULL,			--Dados sobre o treino
);
GO



INSERT INTO  Treinos VALUES ('segunda-feira', 'Treino de peito', '4X12....');

SELECT Treino FROM Treinos;