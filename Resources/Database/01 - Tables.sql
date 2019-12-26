create table [dbo].[ServiceCategory]
(
	[ID] smallint not null identity(100, 100),
	[Name] nvarchar(100) null
)

create table [dbo].[Service]
(
	[ID] smallint not null identity(1000, 1000),
	[ServiceCategoryID] smallint not null,
	[Name] nvarchar(100) not null
)

create table [dbo].[ServiceUser]
(
	[ID] smallint not null identity(1, 1),
	[ServiceID] smallint not null,
	[UserID] uniqueidentifier not null
)

create table [dbo].[Watcher]
(
	[ID] smallint not null identity(1000, 1000),
	[Name] nvarchar(100) not null,
	[Description] nvarchar(max) null,
	[AssemblyQualifiedName] nvarchar(255) not null
)

create table [dbo].[ServiceWatcher]
(
	[ID] smallint not null identity(1, 1),
	[ServiceID] smallint not null,
	[WatcherID] smallint not null,
)

create table [dbo].[Environment]
(
	[ID] smallint not null identity(100, 100),
	[Name] nvarchar(50) not null
)

create table [dbo].[ServiceEnvironment]
(
	[ID] smallint not null identity(1, 1),
	[ServiceID] smallint not null,
	[EnvironmentID] smallint not null,
	[Interval] int not null,
	[Description] nvarchar(max) null,
	[Url] nvarchar(max) null,
	[Address] nvarchar(max) null,
	[ConnectionString] nvarchar(max) null,
	[Active] bit not null
)

create table [dbo].[ServiceEnvironmentStatus]
(
	[ID] int not null identity(1, 1),
	[ServiceEnvironmentID] smallint not null,
	[Successful] bit not null,
	[WatchCount] int not null,
	[LastWatch] datetime not null
)

create table [dbo].[ServiceEnvironmentStatusLog]
(
	[ID] int not null identity(1, 1),
	[ServiceEnvironmentStatusID] int not null,
	[Target] nvarchar(255) null,
	[ActionName] nvarchar(50) null,
	[Successful] bit not null,
	[ShortMessage] nvarchar(max) null,
	[FullMessage] nvarchar(max) null,
	[Date] datetime not null
)



