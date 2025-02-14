CREATE TABLE [dbo].[perfil]
(
	[id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [nombre] VARCHAR(100) NULL, 
    [estado] VARCHAR(100) NULL, 
    [FechaCreacion] DATETIME NULL, 
    [FechaActualizacion] DATETIME NULL, 
    [id_datos_personales] INT NOT NULL 
)
