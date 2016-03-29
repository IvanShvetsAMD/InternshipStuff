USE [Aviation]

EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"

EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
