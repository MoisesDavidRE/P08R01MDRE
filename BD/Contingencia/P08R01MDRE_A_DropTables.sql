USE ControlPlagasDB;
GO
-- =========================================================================
-- Author: Moisés David Ramón Esteban
-- Create Date: 2026-03-29
-- Description: Contingencia de vistas
-- P06R01_BD_MDRE: A_DropTables 
-- =========================================================================
BEGIN TRY
    BEGIN TRANSACTION;

    -- Eliminar Tablas
    DROP TABLE IF EXISTS [dbo].[Tratamientos];
    DROP TABLE IF EXISTS [dbo].[Prevencion];
    DROP TABLE IF EXISTS [dbo].[Plagas];

    COMMIT TRANSACTION;
    PRINT 'Objetos eliminados correctamente.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    PRINT ERROR_MESSAGE();
    THROW;
END CATCH;
GO