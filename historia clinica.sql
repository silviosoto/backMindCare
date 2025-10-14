-- Tabla SIGNOS_FISICOS
CREATE TABLE HISTORIA_CLINICA (
    id INT IDENTITY(1,1) PRIMARY KEY,
    [estado] int NOT NULL,
    [IdPaciente]      INT             NULL,
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    CONSTRAINT [FK_HISTORIA_CLINICA_paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[paciente] ([id]),
    CONSTRAINT [FK_HISTORIA_CLINICA_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_HISTORIA_CLINICA_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])
);



-- Tabla SIGNOS_FISICOS
CREATE TABLE SIGNOS_FISICOS (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    LACERACIONES VARCHAR(500),
    HEMATOMA VARCHAR(500),
    QUEMADURAS VARCHAR(500),
    CICATRICES VARCHAR(500),
    FRACTURAS VARCHAR(500),
    OBSERVACIONES VARCHAR(1000),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_SIGNOS_FISICOS_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_SIGNOS_FISICOS_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])
);

-- Tabla MENTAL_PERSONAL
CREATE TABLE MENTAL_PERSONAL (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    DISCAPACIDAD_COGNITIVA VARCHAR(500),
    EPILEPSIA VARCHAR(500),
    ENFERMEDADES_FAMILIARES_HEREDABLES VARCHAR(500),
    CONSUMO_DE_SUSTANCIAS_PSICOACTIVAS VARCHAR(500),
    CONSUMO_DE_ALCOHOL VARCHAR(500),
    DX_DE_SALUD_MENTAL VARCHAR(500),
    INTENTO_DE_SUICIDIO VARCHAR(500),
    EVENTOS_TRAUMATICOS VARCHAR(500),
    SE_ENCUENTRA_MEDICADO VARCHAR(500),
    ANTECEDENTES_DE_AUTOLESION VARCHAR(500),
    INTERNACIONES_EN_CENTROS_PSIQUIATRICOS VARCHAR(500),
    OBSERVACIONES VARCHAR(1000),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_MENTAL_PERSONAL_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_MENTAL_PERSONAL_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])

);

-- Tabla HISTORIA_ACADEMICA
CREATE TABLE HISTORIA_ACADEMICA (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    EDAD_DE_INGRESO_A_LA_ESCUELA VARCHAR(100),
    ADAPTACION_INICIAL VARCHAR(500),
    DESEMPENO_ACADEMICO VARCHAR(500),
    ANOS_PERDIDOS VARCHAR(100),
    CURSO_ACTUAL VARCHAR(100),
    MATERIA_QUE_SE_FACILITA_Y_LA_QUE_SE_DIFICULTA VARCHAR(500),
    TIEMPO_DIARIO_DE_ESTUDIO_HORAS VARCHAR(100),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_HISTORIA_ACADEMICA_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_HISTORIA_ACADEMICA_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])

);

-- Tabla RAZONES_DE_LOS_SINTOMAS_CONDUCTA
CREATE TABLE RAZONES_DE_SINTOMAS_CONDUCTA (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    RELACIONADOS_AMBIENTES_FAMILIARES VARCHAR(500),
    RELACIONADOS_AMBIENTE_SOCIAL VARCHAR(500),
    RELACIONADOS_AMBIENTES_ACADEMICOS VARCHAR(500),
    RELACIONADOS_CARACTERISTICAS_DEL_INDIVIDUO VARCHAR(500),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_RAZONES_DE_SINTOMAS_CONDUCTA_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_RAZONES_DE_SINTOMAS_CONDUCTA_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])

);

-- Tabla DESARROLLO_PSICOSEXUAL
CREATE TABLE DESARROLLO_PSICOSEXUAL (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    EDAD_DE_DESARROLLO VARCHAR(100),
    IDENTIDAD_SEXUAL VARCHAR(100),
    ORIENTACION_SEXUAL VARCHAR(100),
    EDAD_DE_INICIO_DE_RELACIONES_SEXUALES VARCHAR(100),
    USO_DE_METODOS_DE_PLANIFICACION VARCHAR(100),
    HA_SIDO_VICTIMA_DE_ABUSO_SEXUAL VARCHAR(100),
    ENFERMEDADES_DE_TRANSMISION_SEXUAL VARCHAR(500),
    MADRE_O_PADRE_ADOLESCENTE VARCHAR(100),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_DESARROLLO_PSICOSEXUAL_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_DESARROLLO_PSICOSEXUAL_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])

);

-- Tabla EXAMEN_DE_ESTADO_MENTAL
CREATE TABLE EXAMEN_DE_ESTADO_MENTAL (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    NIVEL_DE_CONCIENCIA VARCHAR(500),
    ATENCION VARCHAR(500),
    SENSOPERCEPCION VARCHAR(500),
    AFECTO VARCHAR(500),
    LENGUAJE VARCHAR(500),
    ORIENTACION VARCHAR(500),
    SUENO VARCHAR(500),
    PENSAMIENTO VARCHAR(500),
    CONDUCTA_MOTORA VARCHAR(500),
    MEMORIA VARCHAR(500),
    PATRON_DE_ALIMENTACION VARCHAR(500),
    INTELIGENCIA VARCHAR(500),
    NIVEL_DE_RAZONAMIENTO VARCHAR(500),
    PORTE_Y_ACTITUD VARCHAR(500),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_EXAMEN_DE_ESTADO_MENTAL_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_EXAMEN_DE_ESTADO_MENTAL_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])

);

-- Tabla CONCEPTO_PSICOLOGICO
CREATE TABLE CONCEPTO_PSICOLOGICO (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_historia_clinica INT NOT NULL,
    DIAGNOSTICO_PRINCIPAL VARCHAR(500),
    DIAGNOSTICO_RELACIONADO_1 VARCHAR(500),
    DIAGNOSTICO_RELACIONADO_2 VARCHAR(500),
    PLAN_DE_TRATAMIENTO VARCHAR(1000),
    OBJETIVOS VARCHAR(1000),
    RECOMENDACIONES VARCHAR(1000),
    COMPROMISOS VARCHAR(1000),
    [IdUsuarioCreacion]      INT             NULL,
    [FechaCreacion]          DATETIME        NULL,
    [FechaActualizacion]     DATETIME        NULL,
    [IdUsuarioActualizacion] INT             NULL,
    FOREIGN KEY (id_historia_clinica) REFERENCES historia_clinica(id),
    CONSTRAINT [FK_CONCEPTO_PSICOLOGICO_usario_creacion] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[User] ([id]),
    CONSTRAINT [FK_CONCEPTO_PSICOLOGICO_usario_actualizacion] FOREIGN KEY ([IdUsuarioActualizacion]) REFERENCES [dbo].[User] ([id])

);