USE ControlPlagasDB
GO
-- =========================================================================
-- Author: Moisés David Ramón Esteban
-- Create Date: 2026-04-04
-- Description: Creación de tablas
-- P08R01_BD_MDRE: 02CrearTablas 
-- =========================================================================

-- Crear la tabla Plagas
BEGIN TRANSACTION
BEGIN TRY
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Plagas')
    BEGIN
        CREATE TABLE Plagas (
    IdPlaga INT IDENTITY(1,1) PRIMARY KEY,
    NombreComun VARCHAR(100) NOT NULL,
    NombreCientifico VARCHAR(150),
    Categoria VARCHAR(50),
    NivelRiesgo VARCHAR(50),
    UrlImage VARCHAR(MAX) NULL
)
    END
    ELSE
        PRINT 'La tabla [dbo].[Plagas] ya existe'
    COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
        THROW;
END CATCH;
GO

-- Crear la tabla Prevención
BEGIN TRANSACTION
BEGIN TRY
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Prevencion')
    BEGIN
        CREATE TABLE Prevencion (
    IdPrevencion INT IDENTITY(1,1) PRIMARY KEY,
    IdPlaga INT FOREIGN KEY REFERENCES Plagas(IdPlaga),
    Titulo VARCHAR(100) NOT NULL,
    Descripcion TEXT NOT NULL
);
    END
    ELSE
        PRINT 'La tabla [dbo].[Prevencion] ya existe'
    COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
        THROW;
END CATCH;
GO

-- Crear la tabla Tratamientos
BEGIN TRANSACTION
BEGIN TRY
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tratamientos')
    BEGIN
    
CREATE TABLE Tratamientos (
    IdTratamiento INT IDENTITY(1,1) PRIMARY KEY,
    IdPlaga INT FOREIGN KEY REFERENCES Plagas(IdPlaga),
    Tipo VARCHAR(50),
    NombreProducto VARCHAR(100),
    Instrucciones TEXT
);
    END
    ELSE
        PRINT 'La tabla [dbo].[Tratamientos] ya existe'
    COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
        THROW;
END CATCH;
GO