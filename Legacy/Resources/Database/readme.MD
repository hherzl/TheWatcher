# Database

*ServiceMonitor* database is a model for service monitor.

To create database in SQL Server instance, run *deploy.bat* script.

## Schemas

	Dbo

All tables have primary key with one column.

## Tables

### Dbo Schema

	dbo.Environment
	dbo.ServiceCategory
	dbo.Service
	dbo.ServiceWatcher
	dbo.ServiceEnvironment
	dbo.ServiceEnvironmentStatus
	dbo.ServiceEnvironmentStatusLog
	dbo.ServiceUser
	dbo.Watcher

|Table|Description|
|-----|-----------|
|dbo.Environment|Contains all environments for services|
|dbo.ServiceCategory|Contains all categories for services|
|dbo.Service|Contains all services definitions|
|dbo.ServiceWatcher|Contains the associations between services and watchers|
|dbo.ServiceEnvironment|Contains the relation for service and environment, for example we can define a service named FinanceService with different environments: DEV, QAQ and PROD|
|dbo.ServiceEnvironmentStatus|Contains the status for each service per environment|
|dbo.ServiceEnvironmentStatusLog|Contains the details for each service environment status|
|dbo.ServiceUser|Contains the relation between service and user|
|dbo.Watcher|Contains all registered watchers: C# classes to perform watch operations|
