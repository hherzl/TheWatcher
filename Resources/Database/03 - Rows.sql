-- insert into [ServiceCategory] values ('Database')
-- insert into [ServiceCategory] values ('Rest API')
-- insert into [ServiceCategory] values ('Server')
-- insert into [ServiceCategory] values ('URL')
-- insert into [ServiceCategory] values ('Web Service')

-- insert into [EnvironmentCategory] values ('Development')
-- insert into [EnvironmentCategory] values ('QA')
-- insert into [EnvironmentCategory] values ('Production')

-- insert into [Service] ([ServiceCategoryID], [Name])
--     values (100, 'Northwind Database')

-- insert into [ServiceEnvironment] ([ServiceID], [EnvironmentCategoryID], [Interval], [ConnectionString], [Description], [Active])
--     values (1, 1, 15000, 'server=(local);database=Northwind;user id=johnd;password=SqlServer2018$', 'SQL Server Local Instance', 1)

-- insert into [ServiceEnvironment] ([ServiceID], [EnvironmentCategoryID], [Interval], [ConnectionString], [Description], [Active])
--     values (1, 2, 15000, 'server=(local);database=Northwind;user id=johnd;password=SqlServer', 'SQL Server Local Instance', 1)

-- insert into [Service] ([ServiceCategoryID], [Name])
--     values (300, 'DNS')

-- insert into [ServiceEnvironment] ([ServiceID], [EnvironmentCategoryID], [Interval], [Address], [Description], [Active])
--     values(2, 1, 3000, '192.168.1.1', 'DNS gateway', 1)

-- insert into [Service] ([ServiceCategoryID], [Name])
--     values (200, 'Sample API')

-- insert into [ServiceEnvironment] ([ServiceID], [EnvironmentCategoryID], [Interval], [Url], [Description], [Active])
--     values(3, 1, 5000, 'http://localhost:5612/api/values', 'Sample Rest API', 1)

-- insert into [ServiceWatcher] ([ServiceID], [TypeName])
--     values (1, 'ServiceMonitor.Common.DatabaseWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null')
-- insert into [ServiceWatcher] ([ServiceID], [TypeName])
--     values (2, 'ServiceMonitor.Common.PingWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null')
-- insert into [ServiceWatcher] ([ServiceID], [TypeName])
--     values (3, 'ServiceMonitor.Common.HttpRequestWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null')

-- insert into [User] ([UserName]) values('DefaultUser')

-- insert into [ServiceUser] values (1, 1)
-- insert into [ServiceUser] values (2, 1)
-- insert into [ServiceUser] values (3, 1)
