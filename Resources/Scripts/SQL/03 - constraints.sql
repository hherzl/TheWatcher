alter table [dbo].[ResourceCategory] add constraint [PK_dbo_ResourceCategory]
	primary key ([Id])
go

alter table [dbo].[ResourceCategory] add constraint [UQ_dbo_ResourceCategory_Name]
	unique ([Name])
go

alter table [dbo].[Environment] add constraint [PK_dbo_Environment]
	primary key ([Id])
go

alter table [dbo].[Resource] add constraint [PK_dbo_Resource]
	primary key ([Id])
go

alter table [dbo].[Resource] add constraint [FK_dbo_Resource_ResourceCategoryId_dbo_ResourceCategory]
	foreign key ([ResourceCategoryId]) references [dbo].[ResourceCategory]
go

alter table [dbo].[ResourceWatch] add constraint [PK_dbo_ResourceWatch]
	primary key ([Id])
go

alter table [dbo].[ResourceWatch] add constraint [UQ_dbo_ResourceWatch_ResourceId_EnvironmentId]
	unique ([ResourceId], [EnvironmentId])
go

alter table [dbo].[ResourceWatch] add constraint [FK_dbo_ResourceWatch_ResourceId_dbo_Resource]
	foreign key ([ResourceId]) references [dbo].[Resource]
go

alter table [dbo].[ResourceWatch] add constraint [FK_dbo_ResourceWatch_EnvironmentId_dbo_Environment]
	foreign key ([EnvironmentId]) references [dbo].[Environment]
go

alter table [dbo].[ResourceWatcherParameter] add constraint [PK_dbo_ResourceWatcherParameter]
	primary key ([Id])
go

alter table [dbo].[ResourceWatcherParameter] add constraint [UQ_dbo_ResourceWatcherParameter_ResourceId_Parameter]
	unique ([ResourceId], [Parameter])
go

alter table [dbo].[ResourceWatcherParameter] add constraint [FK_dbo_ResourceWatcherParameter_ResourceId_dbo_Resource]
	foreign key ([ResourceId]) references [dbo].[Resource]
go

alter table [dbo].[Watcher] add constraint [PK_dbo_Watcher]
	primary key ([Id])
go

alter table [dbo].[Watcher] add constraint [UQ_dbo_Watcher_AssemblyQualifiedName]
	unique ([AssemblyQualifiedName])
go

alter table [dbo].[Watcher] add constraint [UQ_dbo_Watcher_Name]
	unique ([Name])
go

alter table [dbo].[ResourceWatcher] add constraint [PK_dbo_ResourceWatcher]
	primary key ([Id])
go

alter table [dbo].[ResourceWatcher] add constraint [UQ_dbo_ResourceWatcher_ResourceId_WatcherId]
	unique ([ResourceId], [WatcherId])
go

alter table [dbo].[ResourceWatcher] add constraint [FK_dbo_ResourceWatcher_ResourceId_dbo_Resource]
	foreign key ([ResourceId]) references [dbo].[Resource]
go

alter table [dbo].[ResourceWatcher] add constraint [FK_dbo_ResourceWatcher_WatcherId_dbo_Watcher]
	foreign key ([WatcherId]) references [dbo].[Watcher]
go
