CREATE TABLE [dbo].[Agenda]
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Idpsicologo INT NOT NULL,
    DiaSemana int NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Estado BIT DEFAULT 1,
    [FechaCreacion] DATETIME NULL, 
    [FechaActualizacion] DATETIME NULL, 
    [mes] INT NOT NULL, 
    [anio] INT NOT NULL, 
    CONSTRAINT [FK_agenda_psicologo] FOREIGN KEY ([Idpsicologo]) REFERENCES psicologo(id)

)
