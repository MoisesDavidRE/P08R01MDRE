-- =========================================================================
-- Author: Moisés David Ramón Esteban
-- Create Date: 2026-04-04
-- Description: Contingencia de Base de datos
-- P08R01_BD_MDRE: B_DropDatabase
-- =========================================================================

-- Cambiar el contexto antes de eliminar la BD GenMar
USE master;
GO

-- Eliminar la BD ControlPlagasDB
BEGIN TRY
    -- Cerrar todas las conexiones a excepción de la propia, cerrar todas las transacciones
    ALTER DATABASE ControlPlagasDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE IF EXISTS ControlPlagasDB;
    PRINT 'Base de datos eliminada correctamente.';
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
    THROW;
END CATCH;
GO