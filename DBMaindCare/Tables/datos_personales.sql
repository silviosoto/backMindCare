CREATE TABLE [dbo].[datos_personales]
(
	[id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [nombre] VARCHAR(100) NULL, 
    [apellidos] VARCHAR(100) NULL, 
    [fecha_nacimiento] VARCHAR(100) NULL, 
    [email] VARCHAR(100) NULL, 
    [telefono] NCHAR(10) NULL, 
    [tipo_id] VARCHAR(5) NULL, 
    [numero_id] VARCHAR(50) NULL, 
    [municipio_id] INT NULL
)
