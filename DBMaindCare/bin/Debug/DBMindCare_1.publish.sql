/*
Script de implementación para DBMindCare

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DBMindCare"
:setvar DefaultFilePrefix "DBMindCare"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
El tipo de la columna municipio en la tabla [dbo].[municipios] es  VARCHAR (255) NOT NULL, pero se va a cambiar a  VARCHAR (250) NOT NULL. Si la columna contiene datos no compatibles con el tipo  VARCHAR (250) NOT NULL, podrían producirse pérdidas de datos y errores en la implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[municipios])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 70e507da-d953-4d70-aec2-bf92addf1718 se ha omitido; no se cambiará el nombre del elemento [dbo].[departamentos].[Id] (SqlSimpleColumn) a id_departamento';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 6cc94bfe-b0b3-4394-bf07-88d183ea9bb0 se ha omitido; no se cambiará el nombre del elemento [dbo].[municipios].[Id] (SqlSimpleColumn) a id_municipio';


GO
PRINT N'Quitando Restricción DEFAULT restricción sin nombre en [dbo].[departamentos]...';


GO
ALTER TABLE [dbo].[departamentos] DROP CONSTRAINT [DF__departame__depar__34C8D9D1];


GO
PRINT N'Quitando Restricción DEFAULT restricción sin nombre en [dbo].[municipios]...';


GO
ALTER TABLE [dbo].[municipios] DROP CONSTRAINT [DF__municipio__munic__3A81B327];


GO
PRINT N'Modificando Tabla [dbo].[datos_personales]...';


GO
ALTER TABLE [dbo].[datos_personales]
    ADD [municipio_id] INT NULL;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[departamentos]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_departamentos] (
    [id_departamento] INT             NOT NULL,
    [departamento]    VARBINARY (250) NULL,
    PRIMARY KEY CLUSTERED ([id_departamento] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[departamentos])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_departamentos] ([id_departamento], [departamento])
        SELECT   [id_departamento],
                 CAST ([departamento] AS VARBINARY (250))
        FROM     [dbo].[departamentos]
        ORDER BY [id_departamento] ASC;
    END

DROP TABLE [dbo].[departamentos];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_departamentos]', N'departamentos';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Modificando Tabla [dbo].[municipios]...';


GO
ALTER TABLE [dbo].[municipios] ALTER COLUMN [municipio] VARCHAR (250) NOT NULL;


GO
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '70e507da-d953-4d70-aec2-bf92addf1718')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('70e507da-d953-4d70-aec2-bf92addf1718')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6cc94bfe-b0b3-4394-bf07-88d183ea9bb0')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6cc94bfe-b0b3-4394-bf07-88d183ea9bb0')

GO

GO
PRINT N'Actualización completada.';


GO
