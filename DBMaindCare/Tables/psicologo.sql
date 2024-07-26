CREATE TABLE [dbo].[psicologo]
(
	[id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [descripcion] VARCHAR(100) NULL, 
    [estado] VARCHAR(100) NULL, 
    [validado] VARCHAR(100) NULL, 
    [id_datos_personales] INT NOT NULL 
    CONSTRAINT [FK_psicologo_datos_personales] FOREIGN KEY ([id_datos_personales]) REFERENCES datos_personales(id)
)
