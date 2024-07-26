CREATE TABLE [dbo].[paciente]
(
	[id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [estado] VARCHAR(100) NULL,
    [id_datos_personales] INT NULL
	CONSTRAINT [FK_paciente_datos_personales] FOREIGN KEY ([id_datos_personales]) REFERENCES datos_personales(id), 

)
