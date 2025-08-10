CREATE TABLE [dbo].[sala]
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Idcita INT NOT NULL,
    [fechahora] datetime NOT NULL,
    [UrlHost] VARCHAR(MAX) NOT NULL,
    [UrlHuesped] VARCHAR(MAX) NOT NULL, 
    [FechaActualizacion] DATETIME NULL,

    CONSTRAINT [FK_sala_cita] FOREIGN KEY ([Idcita]) REFERENCES cita(id)

)

