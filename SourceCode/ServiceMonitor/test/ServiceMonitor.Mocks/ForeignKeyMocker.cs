using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceMonitor.Core.EntityLayer;
using Xunit;

namespace ServiceMonitor.Mocks
{
    public class ForeignKeyMocker
    {
        [Fact]
        public async Task CreateServicesAsync()
        {
            var businessObject = BusinessObjectMocker.GetAdministrationBusinessObject();

            var data = new List<Service>()
            {
                new Service
                {
                    ServiceCategoryID = 300,
                    Name = "DNS",
                    Interval = 3000,
                    Address = "192.168.1.1",
                    Description = "DNS gateway",
                    Active = true
                },
                new Service
                {
                    ServiceCategoryID = 100,
                    Name = "Northwind Database",
                    Interval = 30000,
                    ConnectionString = "server=(local);database=Northwind;user id=johnd;password=SqlServer2017$",
                    Description = "SQL Server Local Instance",
                    Active = true
                }
            };

            await Task.Run(() =>
            {
                foreach (var item in data)
                {
                    businessObject.CreateService(item);
                }
            });

            businessObject.Release();
        }

        [Fact]
        public async Task CreateServiceWatchersAsync()
        {
            var businessObject = BusinessObjectMocker.GetAdministrationBusinessObject();

            var data = new List<ServiceWatcher>()
            {
                new ServiceWatcher
                {
                    ServiceID = 1,
                    TypeName = "ServiceMonitor.Common.PingWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                },
                new ServiceWatcher
                {
                    ServiceID = 2,
                    TypeName = "ServiceMonitor.Common.DatabaseWatcher, ServiceMonitor.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                }
            };

            foreach (var item in data)
            {
                await Task.Run(() =>
                {
                    return businessObject.CreateServiceWatcher(item);
                });
            }

            businessObject.Release();
        }

        [Fact]
        public async Task CreateUsersAsync()
        {
            var businessObject = BusinessObjectMocker.GetAdministrationBusinessObject();

            var data = new List<User>()
            {
                new User
                {
                    UserName = "Acme\\carlohansh"
                }
            };

            foreach (var item in data)
            {
                await Task.Run(() =>
                {
                    return businessObject.CreateUser(item);
                });
            }

            businessObject.Release();
        }
    }
}
