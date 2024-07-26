CREATE TABLE [dbo].[municipios]
(
	[id_municipio] INT NOT NULL PRIMARY KEY, 
    [municipio] VARCHAR(250) NOT NULL, 
    [estado] INT NOT NULL, 
    [departamento_id] INT NOT NULL
)
