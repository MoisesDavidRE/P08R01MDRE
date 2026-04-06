@echo off
set SERVER=(localdb)\MSSQLLocalDB

sqlcmd -S %SERVER% -E -i P08R01MDRE_01CrearDB.sql
sqlcmd -S %SERVER% -E -i P08R01MDRE_02CrearTablas.sql
sqlcmd -S %SERVER% -E -i P08R01MDRE_03CargaInicial.sql

pause