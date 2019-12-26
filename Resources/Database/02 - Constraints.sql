alter table [dbo].[ServiceCategory]
	add constraint [PK_ServiceCategory] primary key([ID])

alter table [dbo].[Service]
	add constraint [PK_Service] primary key([ID])

alter table [dbo].[Environment]
	add constraint [PK_Environment] primary key([ID])

alter table [dbo].[ServiceEnvironment]
	add constraint [PK_ServiceEnvironment] primary key([ID])

alter table [dbo].[ServiceEnvironment]
	add constraint [U_ServiceEnvironment] unique([ServiceID], [EnvironmentID])

alter table [dbo].[ServiceWatcher]
	add constraint [PK_ServiceWatcher] primary key([ID])

alter table [dbo].[ServiceEnvironmentStatus]
	add constraint [PK_ServiceEnvironmentStatus] primary key([ID])

alter table [dbo].[ServiceEnvironmentStatusLog]
	add constraint [PK_ServiceEnvironmentStatusLog] primary key([ID])

alter table [dbo].[Service]
	add constraint [FK_Service_ServiceCategory] foreign key([ServiceCategoryID])
		references [dbo].[ServiceCategory]

alter table [dbo].[ServiceUser]
	add constraint [FK_ServiceUser_Service] foreign key([ServiceID])
		references [dbo].[Service]

alter table [dbo].[ServiceUser]
	add constraint [U_ServiceUser] unique([ServiceID], [UserID])

alter table [dbo].[ServiceWatcher]
	add constraint [FK_ServiceWatcher_Service] foreign key([ServiceID])
		references [dbo].[Service]

alter table [dbo].[ServiceEnvironment]
	add constraint [FK_ServiceEnvironment_Environment] foreign key([EnvironmentID])
		references [dbo].[Environment]

alter table [dbo].[ServiceEnvironment]
	add constraint [FK_ServiceEnvironment_Service] foreign key([ServiceID])
		references [dbo].[Service]

alter table [dbo].[ServiceEnvironmentStatus]
	add constraint [FK_ServiceEnvironmentStatus_ServiceEnvironment] foreign key([ServiceEnvironmentID])
		references [dbo].[ServiceEnvironment]

alter table [dbo].[ServiceEnvironmentStatusLog]
	add constraint [FK_ServiceEnvironmentStatusLog_ServiceEnvironmentStatus] foreign key([ServiceEnvironmentStatusID])
		references [dbo].[ServiceEnvironmentStatus]
go
