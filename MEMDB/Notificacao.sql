CREATE TABLE Notificacao
(
	Id INT NOT NULL PRIMARY KEY, 
    fk_Evento_Id INT,
	Hora date,
	FOREIGN KEY(fk_Evento_Id) REFERENCES Evento(Id)
)