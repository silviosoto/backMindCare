CREATE TABLE [dbo].[psicologo_especialidad]
(
	[id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [id_psicologo] INT NULL, 
    [id_especialidad] INT NULL, 
    [validado] VARCHAR(100) NULL 
    CONSTRAINT [FK_psicologo_especialidad_psicologo] FOREIGN KEY ([id_psicologo]) REFERENCES psicologo(id)
    CONSTRAINT [FK_psicologo_especialidad_especialidad] FOREIGN KEY ([id_especialidad]) REFERENCES especialidad(id)

)
