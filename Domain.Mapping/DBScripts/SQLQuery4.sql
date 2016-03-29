--gets aircraft info and number of times each aircraft was reregistered
SELECT [a].[SerialNumber], [a].[Registration], [a].[Owner], (SELECT COUNT(ar.[SerialNumber]) 
															FROM [AircraftRegistry] AS ar 
															WHERE ar.[SerialNumber] = [a].[SerialNumber]) AS NumberOftimesReregistered
FROM [Aircraft] AS a;


--gets all aircraft, that have been reregistered more than a year ago
SELECT *
FROM [Aircraft] AS a
WHERE 1 > (SELECT DATEDIFF(Year, [a].[RegistrationDate], (SELECT MAX(ar.[RegistrationDate]) 
														  FROM [AircraftRegistry] AS ar 
														  WHERE [ar].[RegistrationDate] < (SELECT MAX([ar2].[RegistrationDate]) 
																						   FROM [AircraftRegistry] AS ar2
																						   WHERE [ar2].[SerialNumber] = [a].[SerialNumber]))));

SELECT * FROM [Aircraft] AS a;
SELECT * FROM [AircraftRegistry] AS ar;


--getting the number of compartments whose max actual volume is less than double the average volume
TRUNCATE TABLE [GasCompartment];
INSERT INTO [GasCompartment]([ParentAircraftID], [Capacity], [CurrentVolume])
VALUES
	(1, 200, 10), (1, 400, 4), (1, 200, 100),
	(2, 200, 100), (2, 400, 40), (2, 200, 100),
	(12, 200, 150), (12, 400, 400), (12, 200, 10);


SELECT gc.[ParentAircraftID]
FROM [GasCompartment] AS gc
GROUP BY gc.[ParentAircraftID]
HAVING MAX(gc.[CurrentVolume]) >= ALL(SELECT 2 * AVG(gc2.CurrentVolume) 
								FROM [dbo].[GasCompartment] AS gc2 
								WHERE [gc2].[ParentAircraftID] = [gc].[ParentAircraftID])


--gets all turbine blades whose maximum operating tempearture is either maximum or the average
SELECT * 
FROM [TurbineBlade] AS tb
WHERE [tb].[MaxTemp] IN ((SELECT MAX([tb2].[MaxTemp]) 
							FROM [TurbineBlade] AS tb2), 
						(SELECT AVG([tb3].[MaxTemp]) 
							FROM [TurbineBlade] AS tb3))


--gets all aircraft that have been registered more that 5 uears ago
SELECT * 
FROM [Aircraft] AS a
WHERE a.[SerialNumber] = ANY(SELECT ar.[SerialNumber] 
							FROM [AircraftRegistry] AS ar 
							WHERE YEAR([ar].[RegistrationDate]) < YEAR(GETDATE())-5   )


--selects aircraft that are present in the aircraft registry
SELECT a.[SerialNumber], a.[Registration], a.[Owner], a.[RegistrationDate], CASE WHEN EXISTS(SELECT ar.SerialNumber 
																								FROM [dbo].[AircraftRegistry] AS ar 
																								WHERE ar.[SerialNumber] = [a].[SerialNumber])
																				 THEN 'registered'
																				 ELSE 'not registered' 
																				 END AS Registered
FROM [dbo].[Aircraft] AS a;



--gets aircraft, that have been registered in the DB in 2012 and 2016
DECLARE @start int = 2012;
DECLARE @end int = 2016;

SELECT ar.[SerialNumber]
FROM [dbo].[AircraftRegistry] AS ar
GROUP BY [ar].[SerialNumber]
HAVING SUM(CASE WHEN YEAR(ar.[RegistrationDate]) IN (@start, @end)
				THEN 1
				ELSE 0
				END) >=2
		AND
		MIN(CASE WHEN YEAR(ar.[RegistrationDate]) IN (@start, @end)
				THEN 1 
				ELSE 0
				END) = 1;

SELECT * FROM [dbo].[AircraftRegistry] AS ar;



SELECT ar.[SerialNumber]
FROM [AircraftRegistry] AS ar
GROUP BY [ar].[SerialNumber]
HAVING SUM(CASE WHEN (SELECT TOP 1 ar2.[RegistrationDate] 
						FROM [AircraftRegistry] AS ar2
						WHERE [ar2].[SerialNumber] = [ar].[SerialNumber]
						ORDER BY [ar2].[RegistrationDate] DESC) = 2012
				THEN 1
				WHEN (SELECT TOP 1 ar2.[RegistrationDate] 
						FROM [AircraftRegistry] AS ar2
						WHERE [ar2].[SerialNumber] = [ar].[SerialNumber]
						ORDER BY [ar2].[RegistrationDate] ASC) = 2016
				THEN 1
				ELSE 0 
			END) >= 2
		AND
			MIN(CASE WHEN (SELECT TOP 1 ar2.[RegistrationDate] 
							FROM [AircraftRegistry] AS ar2
							WHERE [ar2].[SerialNumber] = [ar].[SerialNumber]
							ORDER BY [ar2].[RegistrationDate] DESC) = 2012
				THEN 1
				WHEN (SELECT TOP 1 ar2.[RegistrationDate] 
						FROM [AircraftRegistry] AS ar2
						WHERE [ar2].[SerialNumber] = [ar].[SerialNumber]
						ORDER BY [ar2].[RegistrationDate] asc) = 2016
				THEN 1
				ELSE 0 
			END) = 1;