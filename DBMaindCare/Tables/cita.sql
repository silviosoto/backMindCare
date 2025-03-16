CREATE TABLE [dbo].[cita]
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Idpsicologo INT NOT NULL,
    Idpaciente INT NOT NULL,
    fecha datetime NOT NULL,
    Hora TIME NOT NULL,
    [FechaCreacion] DATETIME NULL, 
    [FechaActualizacion] DATETIME NULL, 
  
    CONSTRAINT [FK_cita_psicologo] FOREIGN KEY ([Idpsicologo]) REFERENCES psicologo(id)

)
