using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Controllers;
using ServiceMonitor.Responses;
using ServiceMonitor.ViewModels;
using Xunit;

namespace ServiceMonitor.API.Tests
{
    public class AdministrationControllerTests
    {
        [Fact]
        public async Task CreateServiceStatusLogTestAsync()
        {
            // Arrange
            var businessObject = BusinessObjectMocker.GetAdministrationBusinessObject();
            var controller = new AdministrationController(businessObject);
            var viewModel = new ServiceStatusLogViewModel
            {
                ServiceID = 1,
                Target = "192.168.1.1",
                ActionName = "Ping",
                Success = true,
                Date = DateTime.Now
            };

            // Act
            var response = await controller.CreateServiceStatusLog(viewModel) as ObjectResult;

            // Assert
            var value = response.Value as ISingleViewModelResponse<ServiceStatusLogViewModel>;

            Assert.False(value.DidError);
        }
    }
}
