using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Controllers;
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
            var logger = LoggerMocker.GetLogger<IDashboardService>();
            var service = ServiceMocker.GetDashboardBusinessObject();
            var controller = new DashboardController(logger, service);

            // Act
            var response = await controller.GetServiceWatcherItemsAsync() as ObjectResult;

            controller.Dispose();

            // Assert
            var value = response.Value as IListResponse<ServiceWatcherItemDto>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task GetServiceStatusDetailsTestAsync()
        {
            // Arrange
            var logger = LoggerMocker.GetLogger<IDashboardService>();
            var service = ServiceMocker.GetDashboardBusinessObject();
            var controller = new DashboardController(logger, service);
            var userName = "DefaultUser";

            // Act
            var response = await controller.GetServiceStatusDetailsAsync(userName) as ObjectResult;

            controller.Dispose();

            // Assert
            var value = response.Value as IListResponse<ServiceStatusDetailDto>;

            Assert.False(value.DidError);
        }
    }
}
