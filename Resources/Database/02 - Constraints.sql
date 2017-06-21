alter table [dbo].[ServiceCategory]
	add constraint [PK_ServiceCategory] primary key([ServiceCategoryID])
go

alter table [dbo].[Service]
	add constraint [PK_Service] primary key([ServiceID])
go

alter table [dbo].[EnvironmentCategory]
	add constraint [PK_EnvironmentCategory] primary key([EnvironmentCategoryID])
go

alter table [dbo].[ServiceEnvironment]
	add constraint [PK_ServiceEnvironment] primary key([ServiceEnvironmentID])
alter table [dbo].[ServiceEnvironment]
	add constraint [U_ServiceEnvironment] unique([ServiceID], [EnvironmentCategoryID])
go

alter table [dbo].[ServiceWatcher]
	add constraint [PK_ServiceWatcher] primary key([ServiceWatcherID])
go

alter table [dbo].[ServiceEnvironmentStatus]
	add constraint [PK_ServiceEnvironmentStatus] primary key([ServiceEnvironmentStatusID])
go

alter table [dbo].[ServiceEnvironmentStatusLog]
	add constraint [PK_ServiceEnvironmentStatusLog] primary key([ServiceEnvironmentStatusLogID])
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

alter table [dbo].[User]
	add constraint [PK_User] primary key([UserID])
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
		foreign key([ServiceCategoryID]) references [dbo].[ServiceCategory]
go

if object_id ('FK_ServiceWatcher_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceWatcher] drop constraint [FK_ServiceWatcher_Service]
	end
go

alter table [dbo].[ServiceWatcher]
	add constraint [FK_ServiceWatcher_Service]
		foreign key([ServiceID]) references [dbo].[Service]
go

if object_id ('FK_ServiceEnvironment_EnvironmentCategory', 'F') is not null
	begin
		alter table [dbo].[ServiceEnvironment] drop constraint [FK_ServiceEnvironment_EnvironmentCategory]
	end
go

alter table [dbo].[ServiceEnvironment]
	add constraint [FK_ServiceEnvironment_EnvironmentCategory]
		foreign key([EnvironmentCategoryID]) references [dbo].[EnvironmentCategory]
go

if object_id ('FK_ServiceEnvironment_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceEnvironment] drop constraint [FK_ServiceEnvironment_Service]
	end
go

alter table [dbo].[ServiceEnvironment]
	add constraint [FK_ServiceEnvironment_Service]
		foreign key([ServiceID]) references [dbo].[Service]
go

if object_id ('FK_ServiceEnvironmentStatus_ServiceEnvironment', 'F') is not null
	begin
		alter table [dbo].[ServiceEnvironmentStatus] drop constraint [FK_ServiceEnvironmentStatus_ServiceEnvironment]
	end
go

alter table [dbo].[ServiceEnvironmentStatus]
	add constraint [FK_ServiceEnvironmentStatus_ServiceEnvironment]
		foreign key([ServiceEnvironmentID]) references [dbo].[ServiceEnvironment]
go

if object_id ('FK_ServiceEnvironmentStatusLog_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceEnvironmentStatusLog] drop constraint [FK_ServiceStatusLog_Service]
	end
go

alter table [dbo].[ServiceEnvironmentStatusLog]
	add constraint [FK_ServiceEnvironmentStatusLog_ServiceEnvironmentStatus]
		foreign key([ServiceEnvironmentStatusID]) references [dbo].[ServiceEnvironmentStatus]
go

if object_id ('FK_ServiceOwner_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceOwner] drop constraint [FK_ServiceOwner_Service]
	end
go

alter table [dbo].[ServiceOwner]
	add constraint [FK_ServiceOwner_Service]
		foreign key([ServiceID]) references [dbo].[Service]
go

if object_id ('FK_ServiceOwner_Owner', 'F') is not null
	begin
		alter table [dbo].[ServiceOwner] drop constraint [FK_ServiceOwner_Owner]
	end
go

alter table [dbo].[ServiceOwner]
	add constraint [FK_ServiceOwner_Owner]
		foreign key([OwnerID]) references [dbo].[Owner]
go

if object_id ('FK_ServiceUser_Service', 'F') is not null
	begin
		alter table [dbo].[ServiceUser] drop constraint [FK_ServiceUser_Service]
	end
go

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_Service]
		foreign key([ServiceID]) references [dbo].[Service]
go

if object_id ('FK_ServiceUser_User', 'F') is not null
	begin
		alter table [dbo].[ServiceUser] drop constraint [FK_ServiceUser_User]
	end
go

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_User]
		foreign key([UserID]) references [dbo].[User]
go
