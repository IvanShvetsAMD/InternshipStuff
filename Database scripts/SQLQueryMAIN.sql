IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.TurbineBlade') AND Type = N'U')
BEGIN
   DROP TABLE [TurbineBlade]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Spool') AND Type = N'U')
BEGIN
   DROP TABLE [Spool]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.GasCompartment') AND Type = N'U')
BEGIN
   DROP TABLE [GasCompartment]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Generator') AND Type = N'U')
BEGIN
   DROP TABLE [Generator]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.TurbineBladeStatistics') AND Type = N'U')
BEGIN
   DROP TABLE [TurbineBladeStatistics]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Aircraft') AND Type = N'U')
BEGIN
   DROP TABLE [Aircraft]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.AircraftRegistry') AND Type = N'U')
BEGIN
   DROP TABLE [AircraftRegistry]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Propellant') AND Type = N'U')
BEGIN
   DROP TABLE [Propellant]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.LighterThanAirAircraft') AND Type = N'U')
BEGIN
   DROP TABLE [LighterThanAirAircraft]
END

IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.JetEngine') AND Type = N'U')
BEGIN
   DROP TABLE [JetEngine]
END

CREATE TABLE JetEngine
(
	Id int IDENTITY(1, 1),
	EGT int, 
	Isp int,
	NumberOfCycles int
)

CREATE TABLE LighterThanAirAircraft
(
	[AircraftId] int IDENTITY(1, 1),
	[BallastMass] int,
	[GasType] nvarchar(50)
)

CREATE TABLE Propellant
(
    PropellantId    				int                 NOT NULL,
    PropellantnName  				varchar (50)		NOT NULL,

    CONSTRAINT PK_Propellants PRIMARY KEY CLUSTERED ([PropellantId])
)

CREATE TABLE GasCompartment
(
	[GasCompartmentID] int IDENTITY(1,1),
	[ParentAircraft_id] int,
	[Capacity] float NOT NULL,
	[CurrentVolume] float NOT NULL,
	CONSTRAINT [PK_GasCompartment] PRIMARY KEY ([GasCompartmentID])
);

ALTER TABLE [dbo].[GasCompartment] ADD CONSTRAINT chk_CurrentVolume CHECK([CurrentVolume] <= [Capacity]);

CREATE TABLE Generator 
(
	[GeneratorID] int IDENTITY(1,1),
	[ParentAircraft_id] int,
	[OutputCurrent] float NOT NULL,
	[OutputVoltage] float NOT NULL,
	CONSTRAINT [PK_Generator] PRIMARY KEY ([GeneratorID])
);

CREATE TABLE Spool
(
	[SpoolID] int IDENTITY(1, 1) PRIMARY KEY,
	[SpoolType] nvarchar(50) NOT NULL
);

ALTER TABLE Spool ADD CONSTRAINT unique_spool_ID_Type UNIQUE (SpoolID, SpoolType);
ALTER TABLE [Spool] ADD CONSTRAINT SpoolTypeDefaultValue DEFAULT 'Turbine engine spool' FOR SpoolType

CREATE TABLE TurbineBlade 
(
	[SerialNumber] int IDENTITY(00001, 1),
	[ParentSpoolID] int,	
	[Length] int NOT NULL,
	[MaterialType] nvarchar(50) NOT NULL,
	[MaxTemp] int NOT NULL,
	[HasCoolingChannels] bit DEFAULT 0,
	[Chord] int,
	CONSTRAINT [PK_TurbineBlade] PRIMARY KEY ([SerialNumber])
);

ALTER TABLE [dbo].[TurbineBlade] ADD CONSTRAINT [FK_TurbineBladeID_ParentSpoolID] FOREIGN KEY ([ParentSpoolID]) 
REFERENCES [dbo].[Spool] ([SpoolID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [TurbineBlade] ADD CONSTRAINT TurbineBlade_MaterialType_DefaultValue DEFAULT 'High temp alloy' FOR MaterialType;

CREATE TABLE TurbineBladeStatistics
(
	[MaterialType] nvarchar(50) NOT NULL,
	[MaxTemp] int NOT NULL,
	[HasCoolingChannels] bit NOT NULL,
	[NumberOfBlades] int NOT NULL
);

ALTER TABLE [TurbineBladeStatistics] ADD CONSTRAINT TurbineBladeStatistics_MaterialType_DefaultValue DEFAULT 'High temp alloy' FOR MaterialType;
ALTER TABLE [TurbineBladeStatistics] ADD CONSTRAINT TurbineBladeStatistics_HasCoolingChannels_DefaultValue DEFAULT 0 FOR HasCoolingChannels;

--INSERT INTO [GasCompartment]([ParentAircraft_id], [Capacity], [CurrentVolume])
--VALUES
--	(1, 200, 150), (1, 400, 400), (1, 200, 10),
--	(2, 200, 150), (2, 400, 400), (2, 200, 150),
--	(12, 200, 150), (12, 400, 400), (12, 200, 150);

INSERT INTO [dbo].[Spool]([SpoolType])
VALUES
	(N'LP spool'), ( N'HP Spool'), (N'IP spool'), (N'Fan');


--INSERT INTO [dbo].[Generator]([OutputCurrent], [OutputVoltage])
--VALUES
--	(0.0, 0.0), 
--	(100, 28), 
--	(6, 120);


INSERT INTO [dbo].[TurbineBlade]
(
    [ParentSpoolID],
    [Length],
    [MaterialType],
    [MaxTemp],
    [HasCoolingChannels],
    [Chord]
)
VALUES
(2, 12, N'Ti', 1500, 0, 10), 
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10), 
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10), 
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10), 
(2, 12, N'Ti', 1500, 0, 10),
(2, 12, N'Ti', 1500, 0, 10),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(1, 12, DEFAULT, 1100, 1, 15),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(4, 12, N'Mg', 1000, 1, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'W (tungsten) alloy', 1275, 0, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(3, 11, N'Ceramic plated alloy', 1350, 1, 8),
(null, 11, N'Ceramic plated alloy', 1350, 0, 8);