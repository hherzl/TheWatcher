if object_id('dbo.ResourceWatcher') is not null
	drop table [dbo].[ResourceWatcher]
go

if object_id('dbo.Watcher') is not null
	drop table [dbo].[Watcher]
go

if object_id('dbo.ResourceWatcherParameter') is not null
	drop table [dbo].[ResourceWatcherParameter]
go

if object_id('dbo.ResourceWatch') is not null
	drop table [dbo].[ResourceWatch]
go

if object_id('dbo.Resource') is not null
	drop table [dbo].[Resource]
go

if object_id('dbo.Environment') is not null
	drop table [dbo].[Environment]
go

if object_id('dbo.ResourceCategory') is not null
	drop table [dbo].[ResourceCategory]
go

create table [dbo].[ResourceCategory]
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

create table [dbo].[ResourceWatch]
(
	[Id] smallint not null identity(1, 1),
	[ResourceId] smallint not null,
	[EnvironmentId] smallint not null,
	[Interval] int not null,
	[Description] nvarchar(max) not null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[ResourceWatcherParameter]
(
	[Id] smallint not null identity(1, 1),
	[ResourceId] smallint not null,
	[Parameter] nvarchar(100) not null,
	[Description] nvarchar(max) not null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[Watcher]
(
	[Id] smallint not null identity(1, 1),
	[AssemblyQualifiedName] nvarchar(511) not null,
	[Name] nvarchar(100) not null,
	[Description] nvarchar(max) not null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go

create table [dbo].[ResourceWatcher]
(
	[Id] smallint not null identity(1, 1),
	[ResourceId] smallint not null,
	[WatcherId] smallint not null,
	[Active] bit not null,
	[CreationUser] nvarchar(50) not null,
	[CreationDateTime] datetime not null,
	[LastUpdateUser] nvarchar(50) null,
	[LastUpdateDateTime] datetime null,
	[Version] rowversion null
)
go
