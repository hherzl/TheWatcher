select
	[EnvironmentCategory].[EnvironmentCategoryName],
	[Service].[Name],
	[ServiceEnvironment].[Description],
	[ServiceEnvironmentStatus].[Success],
	[ServiceEnvironmentStatus].[WatchCount],
	[ServiceEnvironmentStatus].[LastWatch]
from
	[ServiceEnvironmentStatus]
inner join [ServiceEnvironment]
	on [ServiceEnvironmentStatus].[ServiceEnvironmentID] = [ServiceEnvironment].[ServiceEnvironmentID]
inner join [Service]
	on [ServiceEnvironment].[ServiceID] = [Service].[ServiceID]
inner join [EnvironmentCategory]
	on [ServiceEnvironment].EnvironmentCategoryID = [EnvironmentCategory].[EnvironmentCategoryID]
