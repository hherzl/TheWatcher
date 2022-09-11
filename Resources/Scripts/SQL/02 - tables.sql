if object_id('dbo.ResourceWatchParameter') is not null
	drop table [dbo].[ResourceWatchParameter]
go

if object_id('dbo.ResourceWatch') is not null
	drop table [dbo].[ResourceWatch]
go

if object_id('dbo.Environment') is not null
	drop table [dbo].[Environment]
go

if object_id('dbo.Resource') is not null
	drop table [dbo].[Resource]
go

if object_id('dbo.ResourceCategory') is not null
	drop table [dbo].[ResourceCategory]
go

if object_id('dbo.WatcherParameter') is not null
	drop table [dbo].[WatcherParameter]
go

if object_id('dbo.Watcher') is not null
	drop table [dbo].[Watcher]
go

create table [dbo].[Watcher]
(
	[Id] smallint not null identity(1, 1),
	[AssemblyQualifiedName] nvarchar(511) not null,
	[Name] nvarchar(100) not null,
	[Description] nvarchar(max) null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[WatcherParameter]
(
	[Id] smallint not null identity(1, 1),
	[WatcherId] smallint not null,
	[Parameter] nvarchar(100) not null,
	[Value] nvarchar(max) null,
	[IsDefault] bit not null,
	[Description] nvarchar(max) null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[ResourceCategory]
(
	[Id] smallint not null identity(1, 1),
	[Name] nvarchar(100) not null,
	[WatcherId] smallint null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[Resource]
(
	[Id] smallint not null identity(1, 1),
	[Name] nvarchar(100) null,
	[ResourceCategoryId] smallint not null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[Environment]
(
	[Id] smallint not null identity(1, 1),
	[Name] nvarchar(100) not null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[ResourceWatch]
(
	[Id] smallint not null identity(1, 1),
	[ResourceId] smallint not null,
	[EnvironmentId] smallint not null,
	[Interval] int not null,
	[Description] nvarchar(max) null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[ResourceWatchParameter]
(
	[Id] smallint not null identity(1, 1),
	[ResourceWatchId] smallint not null,
	[Parameter] nvarchar(100) not null,
	[Value] nvarchar(max) null,
	[Description] nvarchar(max) null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go
