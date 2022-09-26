alter table [dbo].[Watcher] add constraint [PK_dbo_Watcher]
	primary key ([Id])
go

alter table [dbo].[Watcher] add constraint [UQ_dbo_Watcher_Guid]
	unique ([Guid])
go

alter table [dbo].[Watcher] add constraint [UQ_dbo_Watcher_AssemblyQualifiedName]
	unique ([AssemblyQualifiedName])
go

alter table [dbo].[Watcher] add constraint [UQ_dbo_Watcher_Name]
	unique ([Name])
go

alter table [dbo].[WatcherParameter] add constraint [PK_dbo_WatcherParameter]
	primary key ([Id])
go

alter table [dbo].[WatcherParameter] add constraint [UQ_dbo_WatcherParameter_WatcherId_Parameter]
	unique ([WatcherId], [Parameter])
go

alter table [dbo].[WatcherParameter] add constraint [FK_dbo_WatcherParameter_WatcherId_dbo_Watcher]
	foreign key ([WatcherId]) references [dbo].[Watcher]
go

alter table [dbo].[ResourceCategory] add constraint [PK_dbo_ResourceCategory]
	primary key ([Id])
go

alter table [dbo].[ResourceCategory] add constraint [UQ_dbo_ResourceCategory_Name]
	unique ([Name])
go

alter table [dbo].[ResourceCategory] add constraint [FK_dbo_ResourceCategory_WatcherId_dbo_Watcher]
	foreign key ([WatcherId]) references [dbo].[Watcher]
go

alter table [dbo].[Resource] add constraint [PK_dbo_Resource]
	primary key ([Id])
go

alter table [dbo].[Resource] add constraint [FK_dbo_Resource_ResourceCategoryId_dbo_ResourceCategory]
	foreign key ([ResourceCategoryId]) references [dbo].[ResourceCategory]
go

alter table [dbo].[Environment] add constraint [PK_dbo_Environment]
	primary key ([Id])
go

alter table [dbo].[Environment] add constraint [UQ_dbo_Environment_Name]
	unique ([Name])
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

alter table [dbo].[ResourceWatchParameter] add constraint [PK_dbo_ResourceWatchParameter]
	primary key ([Id])
go

alter table [dbo].[ResourceWatchParameter] add constraint [UQ_dbo_ResourceWatchParameter_ResourceWatchId_Parameter]
	unique ([ResourceWatchId], [Parameter])
go

alter table [dbo].[ResourceWatchParameter] add constraint [FK_dbo_ResourceWatchParameter_ResourceWatchId_dbo_ResourceWatch]
	foreign key ([ResourceWatchId]) references [dbo].[ResourceWatch]
go

alter table [dbo].[ResourceWatchLog] add constraint [PK_dbo_ResourceWatchLog]
	primary key ([Id])
go

alter table [dbo].[ResourceWatchLog] add constraint [FK_dbo_ResourceWatchLog_ResourceWatchId_dbo_ResourceWatch]
	foreign key ([ResourceWatchId]) references [dbo].[ResourceWatch]
go
