# Database

*ServiceMonitor* database is a model for service monitor.

To create database in SQL Server instance, run *deploy.bat* script.

## Schemas

	Dbo

All tables have primary key with one column.

## Tables

### Dbo Schema

	dbo.EnvironmentCategory
	dbo.ServiceCategory
	dbo.Service
	dbo.ServiceWatcher
	dbo.ServiceEnvironment
	dbo.ServiceEnvironmentStatus
	dbo.ServiceEnvironmentStatusLog
	dbo.Owner
	dbo.ServiceOwner
	dbo.User
	dbo.ServiceUser

|Table|Description|
|-----|-----------|
|dbo.EnvironmentCategory|Contains all categories for environments: development, qa and production|
|dbo.ServiceCategory|Contains all categories for services: database, rest API, server, URL and web service|
|dbo.Service|Contains all services definitions|
|dbo.ServiceWatcher|Contains all components from C# side to perform watch operations|
|dbo.ServiceEnvironment|Contains the relation for service and environment, for example we can define a service named FinanceService with different environments: development, qa and production|
|dbo.ServiceEnvironmentStatus|Contains the status for each service per environment|
|dbo.ServiceEnvironmentStatusLog|Contains the details for each service environment status|
|dbo.Owner|Contains the user list for application that represents all owners|
|dbo.ServiceOwner|Contains the relation between service and owner|
|dbo.User|Contains all users to watching services|
|dbo.ServiceUser|Contains the relation between service and user|
