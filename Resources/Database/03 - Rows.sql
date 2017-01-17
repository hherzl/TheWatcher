insert into ServiceCategory values ('Database')
insert into ServiceCategory values ('Rest API')
insert into ServiceCategory values ('Server')
insert into ServiceCategory values ('URL')
insert into ServiceCategory values ('Web Service')

insert into Service (ServiceCategoryID, Name, Interval, ConnectionString, Description, Active)
    values (100, 'Northwind Database', 15000, 'server=(local);database=Northwind;user id=johnd;password=SqlServer2017$', 'SQL Server Local Instance', 1)

insert into Service (ServiceCategoryID, Name, Interval, Address, Description, Active)
    values (300, 'DNS', 3000, '192.168.1.1', 'DNS gateway', 1)

insert into Service (ServiceCategoryID, Name, Interval, Url, Description, Active)
    values (200, 'Sample API', 5000, 'http://localhost:5612/api/values', 'Sample Rest API', 1)

insert into ServiceWatcher (ServiceID, TypeName)
    values (1, 'ServiceMonitor.Common.DatabaseWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null')
insert into ServiceWatcher (ServiceID, TypeName)
    values (2, 'ServiceMonitor.Common.PingWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null')
insert into ServiceWatcher (ServiceID, TypeName)
    values (3, 'ServiceMonitor.Common.HttpWebRequestWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null')

insert into [User] ([UserName]) values('DefaultUser')

insert into [ServiceUser] values (1, 1)
insert into [ServiceUser] values (2, 1)
insert into [ServiceUser] values (3, 1)
