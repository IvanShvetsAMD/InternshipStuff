--getting the number of compartments whose capacity is less than 300 units of volume and their actual capacity
SELECT COUNT(gc.[GasCompartmentID]) AS NumberOfCompartments, gc.[Capacity]
FROM [GasCompartment] AS gc
GROUP BY gc.[Capacity]
HAVING gc.[Capacity] < 300;

--shows the number of turbineblades with and without cooling channels
SELECT COUNT(s.[SpoolID]) AS numberofspools, [tb].[HasCoolingChannels]
FROM [Spool] AS s FULL OUTER JOIN [TurbineBlade] AS tb
ON [tb].[ParentSpoolID] = [s].[SpoolID]
GROUP BY tb.[HasCoolingChannels]
HAVING COUNT(s.[SpoolType]) > 0;



--populate TurbineBladeStatistics
INSERT INTO [TurbineBladeStatistics]
SELECT [tb].MaterialType, tb.MaxTemp, tb.HasCoolingChannels, Count(tb.SerialNumber) AS numberofblades
FROM [TurbineBlade] AS tb
GROUP BY tb.MaterialType, tb.Maxtemp, tb.HasCoolingChannels;


SELECT * FROM [TurbineBladeStatistics] AS tbs;


--truncate and delete
SELECT * FROM GasCompartment;

TRUNCATE TABLE GasCompartment;

SELECT * FROM GasCompartment;

INSERT INTO [dbo].[GasCompartment]
(
    [ParentAircraftID],
    [Capacity],
    [CurrentVolume]
)
VALUES
(    
    2, -- ParentAircraftID - int
    4.0, -- Capacity - float
    4.0 -- CurrentVolume - float
);

SELECT * FROM GasCompartment;

DELETE FROM [dbo].[GasCompartment];

INSERT INTO [dbo].[GasCompartment]
(
    [ParentAircraftID],
    [Capacity],
    [CurrentVolume]
)
VALUES
(    
    2, -- ParentAircraftID - int
    4.0, -- Capacity - float
    4.0 -- CurrentVolume - float
);

SELECT * FROM GasCompartment;

INSERT INTO [GasCompartment]([ParentAircraftID], [Capacity], [CurrentVolume])
VALUES
	(1, 200, 150), (1, 400, 400), (1, 200, 150),
	(2, 200, 150), (2, 400, 400), (2, 200, 150),
	(12, 200, 150), (12, 400, 400), (12, 200, 150);


--delete with join
DELETE tb
FROM [dbo].[TurbineBlade] AS tb JOIN [dbo].[Spool] AS s
ON [tb].[ParentSpoolID] = [s].[SpoolID]
WHERE [s].[SpoolType] LIKE '%spool';


SELECT * FROM [dbo].[TurbineBlade] AS tb JOIN [dbo].[Spool] AS s  ON [tb].[ParentSpoolID] = [s].[SpoolID];


--update with join
CREATE TABLE Aircraft
(
	[SerialNumber] int IDENTITY(1,1) NOT NULL,
	[Registration] nvarchar(10) NOT NULL,
	[Owner] nvarchar(50),
	[RegistrationDate] date,
	CONSTRAINT [Aircraft_PK] PRIMARY KEY([SerialNumber], [Registration]),
	CONSTRAINT [Aircraft_Registration_UNIQUE] UNIQUE(Registration)
)

CREATE TABLE AircraftRegistry
(
	[EntryID] int IDENTITY(1,1),
	[SerialNumber] int NOT NULL,
	[Registration] nvarchar(10),
	[RegistrationDate] date
)

--ALTER TABLE [dbo].[AircraftRegistry] ADD CONSTRAINT [AircraftRegistry_PK] PRIMARY KEY(EntryID);

INSERT INTO [dbo].[Aircraft]
(
    [Registration],
    [Owner],
	[RegistrationDate]
)
VALUES
(
    N'ER-AXV', -- Registration - nvarchar
    N'Air Moldova', -- Owner - nvarchar
	'2012-10-25'
), (N'ER-AXP', N'Air Moldova', '2010-8-16');

INSERT INTO [dbo].[AircraftRegistry]
(   
    [SerialNumber],
    [Registration],
	[RegistrationDate]
)
VALUES
(
    1, -- SerialNumber - int
    N'ER-AXV', -- Registration - nvarchar
	'2012-10-25'
), (2, N'ER-AXP', '2010-8-16'), (2, N'ER-AEG', '2010-8-16'), (3, N'ER-AXV', '2012-10-25'), (1, N'ER-RMG', '2016-1-1');

UPDATE a
SET a.[Registration] = ar.[Registration]
FROM [dbo].[Aircraft] AS a JOIN [dbo].[AircraftRegistry] AS ar
ON a.[SerialNumber] = [ar].[SerialNumber]
WHERE a.[SerialNumber] = ar.[SerialNumber];

SELECT * FROM [dbo].[Aircraft] AS a;
SELECT * FROM [dbo].[AircraftRegistry] AS ar;


------------------------


TRUNCATE TABLE [dbo].[Aircraft];
TRUNCATE TABLE [dbo].[AircraftRegistry];
INSERT INTO [dbo].[Aircraft]
(
    [Registration],
    [Owner],
	[RegistrationDate]
)
VALUES
(
    N'ER-AXV', -- Registration - nvarchar
    N'Air Moldova', -- Owner - nvarchar
	'2012-10-25'
), (N'ER-AXP', N'Air Moldova', '2010-8-16');

INSERT INTO [dbo].[AircraftRegistry]
(   
    [SerialNumber],
    [Registration],
	[RegistrationDate]
)
VALUES
(
    1, -- SerialNumber - int
    N'ER-AXV', -- Registration - nvarchar
	'2012-10-25'
), (2, N'ER-AXP', '2010-8-16'), (3, N'ER-AXV', '2012-10-25'), (2, N'ER-AEG', '2010-8-16'), (1, N'ER-RMG', '2016-1-1');

CREATE CLUSTERED INDEX [Custom_index_on_aircraftRegistry] ON [dbo].[AircraftRegistry]([SerialNumber] DESC);

UPDATE a
SET a.[Registration] = ar.[Registration]
FROM [dbo].[Aircraft] AS a JOIN [dbo].[AircraftRegistry] AS ar
ON a.[SerialNumber] = [ar].[SerialNumber]
WHERE a.[SerialNumber] = ar.[SerialNumber];

SELECT * FROM [dbo].[Aircraft] AS a;
SELECT * FROM [dbo].[AircraftRegistry] AS ar;

--restoring
TRUNCATE TABLE [dbo].[Aircraft];
TRUNCATE TABLE [dbo].[AircraftRegistry];
INSERT INTO [dbo].[Aircraft]
(
    [Registration],
    [Owner],
	[RegistrationDate]
)
VALUES
(
    N'ER-AXV', -- Registration - nvarchar
    N'Air Moldova', -- Owner - nvarchar
	'2012-10-25'
), (N'ER-AXP', N'Air Moldova', '2010-8-16');

INSERT INTO [dbo].[AircraftRegistry]
(   
    [SerialNumber],
    [Registration],
	[RegistrationDate]
)
VALUES
(
    1, -- SerialNumber - int
    N'ER-AXV', -- Registration - nvarchar
	'2012-10-25'
), (2, N'ER-AXP', '2010-8-16'), (3, N'ER-AXV', '2013-11-11'), (2, N'ER-AEG', '2014-6-30'), (1, N'ER-RMG', '2016-1-1');

DROP INDEX [Custom_index_on_aircraftRegistry] ON [dbo].[AircraftRegistry];
CREATE CLUSTERED INDEX [Custom_index_on_aircraftRegistry] ON [dbo].[AircraftRegistry]([EntryID] ASC);

-----------------------------------
------------------------------------
-------------------------------------
--BEGIN TRY
--    BEGIN TRANSACTION 
--        exec( @sqlHeader)
--        exec(@sqlTotals)
--        exec(@sqlLine)
--    COMMIT
--END TRY
--BEGIN CATCH

--    IF @@TRANCOUNT > 0
--        ROLLBACK
--END CATCH
-----------------------------------
----------------------------------
---------------------------------

SELECT * FROM [dbo].[Aircraft] AS a;
SELECT * FROM [dbo].[AircraftRegistry] AS ar;

MERGE INTO [dbo].[Aircraft] AS a
		USING (SELECT ROW_NUMBER() OVER(PARTITION BY ar.[SerialNumber] ORDER BY ar.[RegistrationDate] DESC) AS RowNum,
				ar.[SerialNumber],
				ar.[Registration],      
				ar.[RegistrationDate]
				FROM [AircraftRegistry] AS ar
				) AS ar
		ON [a].[SerialNumber] = [ar].[SerialNumber]
		WHEN MATCHED AND RowNum = 1
THEN 
	UPDATE SET [a].[Registration] = [ar].[Registration],
				[a].[RegistrationDate] = [ar].[RegistrationDate]
WHEN NOT MATCHED BY SOURCE
THEN
	DELETE;


SELECT * FROM [dbo].[Aircraft] AS a;
SELECT * FROM [dbo].[AircraftRegistry] AS ar;


SELECT * FROM sys.[dm_tran_locks] AS dtl;