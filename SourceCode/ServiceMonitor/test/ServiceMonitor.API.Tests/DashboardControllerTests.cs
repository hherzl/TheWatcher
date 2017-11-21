using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Controllers;
using ServiceMonitor.Common;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.DataLayer.DataContracts;
using Xunit;

namespace ServiceMonitor.API.Tests
{
    public class DashboardControllerTests
    {
        [Fact]
        public async Task GetServiceWatcherItemsTestAsync()
        {
            // Arrange
            var logger = LoggerHelper.GetLogger<IDashboardService>();
            var service = ServiceMocker.GetDashboardService();
            var controller = new DashboardController(logger, service);

            // Act
            var response = await controller.GetServiceWatcherItemsAsync() as ObjectResult;
            var value = response.Value as IListResponse<ServiceWatcherItemDto>;

            controller.Dispose();

            // Assert
            Assert.False(value.DidError);
        }

        [Fact]
        public async Task GetServiceStatusDetailsTestAsync()
        {
            // Arrange
            var logger = LoggerHelper.GetLogger<IDashboardService>();
            var service = ServiceMocker.GetDashboardService();
            var controller = new DashboardController(logger, service);
            var userName = "DefaultUser";

            // Act
            var response = await controller.GetServiceStatusDetailsAsync(userName) as ObjectResult;
            var value = response.Value as IListResponse<ServiceStatusDetailDto>;

            controller.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}
