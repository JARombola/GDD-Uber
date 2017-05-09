sqlcmd -S LOCALHOST\SQLSERVER2012 -U gd -P gd2017 -i DropTriggers.sql, DropSP.sql, DropFunciones.sql, ^
DropEsquema.sql ^
-a 32767 -o resultado_output.txt