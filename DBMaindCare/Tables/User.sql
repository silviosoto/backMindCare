CREATE TABLE [dbo].[User]
(
	[id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
	[username] VARCHAR(50) NOT NULL,
	[password] VARCHAR(250) NOT NULL,
	[estado] BIT NOT NULL,
	[id_datos_personales] INT NOT NULL,
	[FechaCreacion] DATETIME NULL,
    [FechaActualizacion] DATETIME NULL,
	CONSTRAINT [FK_user_persona] FOREIGN KEY ([id_datos_personales])
	REFERENCES datos_personales(id)
)
