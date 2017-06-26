sqlcmd -S LOCALHOST\SQLSERVER2012 -U gd -P gd2017 -i ScriptCreacionBD.sql, ^
Functions.sql, StoredProcedures.sql, Triggers.sql, Migracion.sql -a 32767 -o resultado_output.txt