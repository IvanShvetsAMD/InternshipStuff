IF OBJECT_ID ( 'GetMaxRegistrationDate', 'P' ) IS NOT NULL 
    DROP PROCEDURE GetMaxRegistrationDate;
GO
CREATE PROCEDURE dbo.GetMaxRegistrationDate
	@InputSerialNumber int
AS
SELECT TOP 1 ar2.[RegistrationDate] 
FROM [AircraftRegistry] AS ar2
WHERE [ar2].[SerialNumber] = @InputSerialNumber
ORDER BY [ar2].[RegistrationDate] DESC
GO

IF OBJECT_ID ( 'GetMinRegistrationDate', 'P' ) IS NOT NULL 
    DROP PROCEDURE GetMinRegistrationDate;
GO
CREATE PROCEDURE dbo.GetMinRegistrationDate
	@InputSerialNumber int
AS
SELECT TOP 1 ar2.[RegistrationDate] 
FROM [AircraftRegistry] AS ar2
WHERE [ar2].[SerialNumber] = @InputSerialNumber
ORDER BY [ar2].[RegistrationDate] ASC
GO

EXECUTE [GetMaxRegistrationDate]	
	@InputSerialNumber = 1;

EXECUTE [GetMinRegistrationDate]
	@InputSerialNumber = 1;