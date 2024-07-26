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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 0c4153da-14b3-4d7b-800a-551aeb40fba1 se ha omitido; no se cambiará el nombre del elemento [dbo].[datos_personales].[apellido] (SqlSimpleColumn) a apellidos';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 92a066a0-a7d4-4d48-ae80-ed43f9fe5fc3 se ha omitido; no se cambiará el nombre del elemento [dbo].[datos_personales].[emial] (SqlSimpleColumn) a email';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 307e5dff-f3a3-47b9-bef0-611353612cfd se ha omitido; no se cambiará el nombre del elemento [dbo].[psicologo].[nombre] (SqlSimpleColumn) a descripcion';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 2515b4d9-3bc2-4405-a481-7b6aaa966008 se ha omitido; no se cambiará el nombre del elemento [dbo].[psicologo].[apellidos] (SqlSimpleColumn) a estado';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 17010070-dfbd-409a-ab9a-627ece65d020 se ha omitido; no se cambiará el nombre del elemento [dbo].[psicologo].[fecha_nacimiento] (SqlSimpleColumn) a validado';


GO
PRINT N'Creando Tabla [dbo].[datos_personales]...';


GO
CREATE TABLE [dbo].[datos_personales] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (100) NULL,
    [apellidos]        VARCHAR (100) NULL,
    [fecha_nacimiento] VARCHAR (100) NULL,
    [email]            VARCHAR (100) NULL,
    [telefono]         NCHAR (10)    NULL,
    [tipo_id]          VARCHAR (5)   NULL,
    [numero_id]        VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[especialidad]...';


GO
CREATE TABLE [dbo].[especialidad] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR (100) NULL,
    [descripcion] VARCHAR (100) NULL,
    [validado]    VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[paciente]...';


GO
CREATE TABLE [dbo].[paciente] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [estado]              VARCHAR (100) NULL,
    [id_datos_personales] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[psicologo]...';


GO
CREATE TABLE [dbo].[psicologo] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [descripcion]         VARCHAR (100) NULL,
    [estado]              VARCHAR (100) NULL,
    [validado]            VARCHAR (100) NULL,
    [id_datos_personales] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[psicologo_especialidad]...';


GO
CREATE TABLE [dbo].[psicologo_especialidad] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [id_psicologo]    INT           NULL,
    [id_especialidad] INT           NULL,
    [validado]        VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creando Clave externa [dbo].[FK_paciente_datos_personales]...';


GO
ALTER TABLE [dbo].[paciente] WITH NOCHECK
    ADD CONSTRAINT [FK_paciente_datos_personales] FOREIGN KEY ([id_datos_personales]) REFERENCES [dbo].[datos_personales] ([id]);


GO
PRINT N'Creando Clave externa [dbo].[FK_psicologo_datos_personales]...';


GO
ALTER TABLE [dbo].[psicologo] WITH NOCHECK
    ADD CONSTRAINT [FK_psicologo_datos_personales] FOREIGN KEY ([id_datos_personales]) REFERENCES [dbo].[datos_personales] ([id]);


GO
PRINT N'Creando Clave externa [dbo].[FK_psicologo_especialidad_psicologo]...';


GO
ALTER TABLE [dbo].[psicologo_especialidad] WITH NOCHECK
    ADD CONSTRAINT [FK_psicologo_especialidad_psicologo] FOREIGN KEY ([id_psicologo]) REFERENCES [dbo].[psicologo] ([id]);


GO
PRINT N'Creando Clave externa [dbo].[FK_psicologo_especialidad_especialidad]...';


GO
ALTER TABLE [dbo].[psicologo_especialidad] WITH NOCHECK
    ADD CONSTRAINT [FK_psicologo_especialidad_especialidad] FOREIGN KEY ([id_especialidad]) REFERENCES [dbo].[especialidad] ([id]);


GO
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0c4153da-14b3-4d7b-800a-551aeb40fba1')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0c4153da-14b3-4d7b-800a-551aeb40fba1')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '92a066a0-a7d4-4d48-ae80-ed43f9fe5fc3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('92a066a0-a7d4-4d48-ae80-ed43f9fe5fc3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '307e5dff-f3a3-47b9-bef0-611353612cfd')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('307e5dff-f3a3-47b9-bef0-611353612cfd')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2515b4d9-3bc2-4405-a481-7b6aaa966008')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2515b4d9-3bc2-4405-a481-7b6aaa966008')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '17010070-dfbd-409a-ab9a-627ece65d020')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('17010070-dfbd-409a-ab9a-627ece65d020')

GO

GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[paciente] WITH CHECK CHECK CONSTRAINT [FK_paciente_datos_personales];

ALTER TABLE [dbo].[psicologo] WITH CHECK CHECK CONSTRAINT [FK_psicologo_datos_personales];

ALTER TABLE [dbo].[psicologo_especialidad] WITH CHECK CHECK CONSTRAINT [FK_psicologo_especialidad_psicologo];

ALTER TABLE [dbo].[psicologo_especialidad] WITH CHECK CHECK CONSTRAINT [FK_psicologo_especialidad_especialidad];


GO
PRINT N'Actualización completada.';


GO
