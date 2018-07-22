alter table [dbo].[ServiceCategory]
	add constraint [PK_ServiceCategory] primary key([ServiceCategoryID])

alter table [dbo].[Service]
	add constraint [PK_Service] primary key([ServiceID])

alter table [dbo].[EnvironmentCategory]
	add constraint [PK_EnvironmentCategory] primary key([EnvironmentCategoryID])

alter table [dbo].[ServiceEnvironment]
	add constraint [PK_ServiceEnvironment] primary key([ServiceEnvironmentID])

alter table [dbo].[ServiceEnvironment]
	add constraint [U_ServiceEnvironment] unique([ServiceID], [EnvironmentCategoryID])

alter table [dbo].[ServiceWatcher]
	add constraint [PK_ServiceWatcher] primary key([ServiceWatcherID])

alter table [dbo].[ServiceEnvironmentStatus]
	add constraint [PK_ServiceEnvironmentStatus] primary key([ServiceEnvironmentStatusID])

alter table [dbo].[ServiceEnvironmentStatusLog]
	add constraint [PK_ServiceEnvironmentStatusLog] primary key([ServiceEnvironmentStatusLogID])

alter table [dbo].[Owner]
	add constraint [PK_Owner] primary key([OwnerID])

alter table [dbo].[Owner]
	add constraint [U_Owner_UserName] unique([UserName])

alter table [dbo].[ServiceOwner]
	add constraint [PK_ServiceOwner] primary key([ServiceOwnerID])

alter table [dbo].[ServiceOwner]
	add constraint [U_ServiceOwner_Owner] unique([ServiceID], [OwnerID])

alter table [dbo].[User]
	add constraint [PK_User] primary key([UserID])

alter table [dbo].[ServiceUser]
	add constraint [PK_ServiceUser] primary key([ServiceUserID])

alter table [dbo].[ServiceUser]
	add constraint [U_ServiceUser_Service_User] unique([ServiceID], [UserID])

alter table [dbo].[Service]
	add constraint [FK_Service_ServiceCategory] foreign key([ServiceCategoryID]) references [dbo].[ServiceCategory]

alter table [dbo].[ServiceWatcher]
	add constraint [FK_ServiceWatcher_Service] foreign key([ServiceID]) references [dbo].[Service]

alter table [dbo].[ServiceEnvironment]
	add constraint [FK_ServiceEnvironment_EnvironmentCategory] foreign key([EnvironmentCategoryID]) references [dbo].[EnvironmentCategory]

alter table [dbo].[ServiceEnvironment]
	add constraint [FK_ServiceEnvironment_Service] foreign key([ServiceID]) references [dbo].[Service]

alter table [dbo].[ServiceEnvironmentStatus]
	add constraint [FK_ServiceEnvironmentStatus_ServiceEnvironment] foreign key([ServiceEnvironmentID]) references [dbo].[ServiceEnvironment]

alter table [dbo].[ServiceEnvironmentStatusLog]
	add constraint [FK_ServiceEnvironmentStatusLog_ServiceEnvironmentStatus] foreign key([ServiceEnvironmentStatusID]) references [dbo].[ServiceEnvironmentStatus]

alter table [dbo].[ServiceOwner]
	add constraint [FK_ServiceOwner_Service] foreign key([ServiceID]) references [dbo].[Service]

alter table [dbo].[ServiceOwner]
	add constraint [FK_ServiceOwner_Owner] foreign key([OwnerID]) references [dbo].[Owner]

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_Service] foreign key([ServiceID]) references [dbo].[Service]

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_User] foreign key([UserID]) references [dbo].[User]
