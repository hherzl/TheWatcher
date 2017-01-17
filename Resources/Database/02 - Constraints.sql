alter table [dbo].[ServiceCategory]
	add constraint [PK_ServiceCategory] primary key([ServiceCategoryID])
go

alter table [dbo].[Service]
	add constraint [PK_Service] primary key([ServiceID])
go

alter table [dbo].[ServiceWatcher]
	add constraint [PK_ServiceWatcher] primary key([ServiceWatcherID])
go

alter table [dbo].[ServiceStatus]
	add constraint [PK_ServiceStatus] primary key([ServiceStatusID])
go

alter table [dbo].[ServiceStatusLog]
	add constraint [PK_ServiceStatusLog] primary key([ServiceStatusLogID])
go

alter table [dbo].[Owner]
	add constraint [PK_Owner] primary key([OwnerID])
alter table [dbo].[Owner]
	add constraint [U_Owner_UserName] unique([UserName])
go

alter table [dbo].[ServiceOwner]
	add constraint [PK_ServiceOwner] primary key([ServiceOwnerID])
alter table [dbo].[ServiceOwner]
	add constraint [U_ServiceOwner_Owner] unique([ServiceID], [OwnerID])
go

alter table [dbo].[User] add constraint [PK_User] primary key([UserID])
go

alter table [dbo].[ServiceUser]
	add constraint [PK_ServiceUser] primary key([ServiceUserID])
alter table [dbo].[ServiceUser]
	add constraint [U_ServiceUser_Service_User] unique([ServiceID], [UserID])
go

if object_id ('FK_Service_ServiceCategory', 'F') is not null
	begin
		alter table [dbo].[Service] drop constraint [FK_Service_ServiceCategory]
	end
go

alter table [dbo].[Service]
	add constraint [FK_Service_ServiceCategory]
		foreign key([ServiceCategoryID]) references [dbo].[ServiceCategory] ([ServiceCategoryID])
go

if object_id ('FK_ServiceWatcher_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceWatcher] drop constraint [FK_ServiceWatcher_Service]
	end
go

alter table [dbo].[ServiceWatcher]
	add constraint [FK_ServiceWatcher_Service]
		foreign key([ServiceID]) references [dbo].[Service] ([ServiceID])
go

if object_id ('FK_ServiceStatus_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceStatus] drop constraint [FK_ServiceStatus_Service]
	end
go

alter table [dbo].[ServiceStatus]
	add constraint [FK_ServiceStatus_Service]
		foreign key([ServiceID]) references [dbo].[Service] ([ServiceID])
go

if object_id ('FK_ServiceStatusLog_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceStatusLog] drop constraint [FK_ServiceStatusLog_Service]
	end
go

alter table [dbo].[ServiceStatusLog]
	add constraint [FK_ServiceStatusLog_Service]
		foreign key([ServiceID]) references [dbo].[Service] ([ServiceID])
go

if object_id ('FK_ServiceOwner_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceOwner] drop constraint [FK_ServiceOwner_Service]
	end
go

alter table [dbo].[ServiceOwner]
	add constraint [FK_ServiceOwner_Service]
		foreign key([ServiceID]) references [dbo].[Service] ([ServiceID])
go

if object_id ('FK_ServiceOwner_Owner', 'F') is not null
	begin
		alter table [dbo].[ServiceOwner] drop constraint [FK_ServiceOwner_Owner]
	end
go

alter table [dbo].[ServiceOwner]
	add constraint [FK_ServiceOwner_Owner]
		foreign key([OwnerID]) references [dbo].[Owner] ([OwnerID])
go

if object_id ('FK_ServiceUser_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceUser] drop constraint [FK_ServiceUser_Service]
	end
go

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_Service]
		foreign key([ServiceID]) references [dbo].[Service] ([ServiceID])
go

if object_id ('FK_ServiceUser_User', 'F') is not null
	begin
		alter table [dbo].[ServiceUser] drop constraint [FK_ServiceUser_User]
	end
go

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_User]
		foreign key([UserID]) references [dbo].[User] ([UserID])
go
