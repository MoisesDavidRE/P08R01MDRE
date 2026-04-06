@echo off
set SERVER=(localdb)\MSSQLLocalDB

sqlcmd -S %SERVER% -E -i P06R01MDRE_A_DropTables.sql
sqlcmd -S %SERVER% -E -i P06R01MDRE_B_DropDataBase.sql

pause