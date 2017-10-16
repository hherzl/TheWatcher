using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Controllers;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.EntityLayer;
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
            using (var businessObject = BusinessObjectMocker.GetAdministrationBusinessObject())
            {
                var logger = LoggerMocker.GetLogger<IAdministrationService>();
                var controller = new AdministrationController(logger, businessObject);
                var viewModel = new ServiceEnvironmentStatusLogVm
                {
                    ServiceEnvironmentID = 1,
                    Target = "192.168.1.1",
                    ActionName = "Ping",
                    Success = true,
                    Date = DateTime.Now
                };

                // Act
                var response = await controller.CreateServiceStatusLogAsync(viewModel) as ObjectResult;

                // Assert
                var value = response.Value as ISingleResponse<ServiceEnvironmentStatusLog>;

                Assert.False(value.DidError);
            }
        }
    }
}
