cls
set server=(local)
set database=ServiceMonitor
sqlcmd -S %server% -i "00 - Database.sql"
sqlcmd -S %server% -d %database% -i "01 - Tables.sql"
sqlcmd -S %server% -d %database% -i "02 - Constraints.sql"
sqlcmd -S %server% -d %database% -i "03 - Rows.sql"
pause
