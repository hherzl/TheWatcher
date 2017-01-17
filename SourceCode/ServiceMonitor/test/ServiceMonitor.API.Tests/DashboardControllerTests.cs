using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Controllers;
using ServiceMonitor.Responses;
using ServiceMonitor.ViewModels;
using Xunit;

namespace ServiceMonitor.API.Tests
{
    public class DashboardControllerTests
    {
        [Fact]
        public async Task GetServiceWatcherItemsTestAsync()
        {
            // Arrange
            var businessObject = BusinessObjectMocker.GetDashboardBusinessObject();
            var controller = new DashboardController(businessObject);

            // Act
            var response = await controller.GetServiceWatcherItems() as ObjectResult;

            // Assert
            var value = response.Value as IListViewModelResponse<ServiceWatcherItemViewModel>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task GetServiceStatusDetailsTestAsync()
        {
            // Arrange
            var businessObject = BusinessObjectMocker.GetDashboardBusinessObject();
            var controller = new DashboardController(businessObject);
            var userName = "DefaultUser";

            // Act
            var response = await controller.GetServiceStatusDetails(userName) as ObjectResult;

            // Assert
            var value = response.Value as IListViewModelResponse<ServiceStatusDetailViewModel>;

            Assert.False(value.DidError);
        }
    }
}
