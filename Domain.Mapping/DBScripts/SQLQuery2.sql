SELECT *
FROM [Spool] AS s CROSS JOIN [TurbineBlade] AS tb

SELECT * from
(SELECT [tb].[SerialNumber], [tb].[ParentSpoolID], [tb].[Length], [tb].[MaterialType], [tb].[MaxTemp], [tb].[HasCoolingChannels], [tb].[Chord], s.[SpoolType] FROM 
([TurbineBlade] AS tb 
LEFT JOIN [Spool] AS s 
	ON tb.[ParentSpoolID] = s.[SpoolID])
EXCEPT SELECT [tb2].[SerialNumber], [tb2].[ParentSpoolID], [tb2].[Length], [tb2].[MaterialType], [tb2].[MaxTemp], [tb2].[HasCoolingChannels], [tb2].[Chord], s2.[SpoolType]
			FROM [TurbineBlade] AS tb2 JOIN [Spool] AS s2 ON [s2].[SpoolID]= tb2.ParentSpoolID
			WHERE [tb2].MaterialType LIKE '%tungsten%')AS temp

WHERE temp.MaterialType LIKE '%alloy%' OR temp.MaxTemp > 1200



SELECT * FROM [TurbineBlade] AS tb 