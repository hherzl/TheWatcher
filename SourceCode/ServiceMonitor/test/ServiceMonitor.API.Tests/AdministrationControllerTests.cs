using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceMonitor.API.Controllers;
using ServiceMonitor.API.ViewModels;
using ServiceMonitor.Common;
using ServiceMonitor.Core.BusinessLayer.Contracts;
using ServiceMonitor.Core.BusinessLayer.Responses;
using ServiceMonitor.Core.EntityLayer;
using Xunit;

namespace ServiceMonitor.API.Tests
{
    public class AdministrationControllerTests
    {
        [Fact]
        public async Task CreateServiceStatusLogTestAsync()
        {
            // Arrange
            var logger = LoggerHelper.GetLogger<IAdministrationService>();
            var service = ServiceMocker.GetAdministrationService();
            var controller = new AdministrationController(logger, service);
            var request = new ServiceEnvironmentStatusLogVm
            {
                ServiceEnvironmentID = 1,
                Target = "192.168.1.1",
                ActionName = "Ping",
                Success = true,
                Date = DateTime.Now
            };

            // Act
            var response = await controller.CreateServiceStatusLogAsync(request) as ObjectResult;
            var value = response.Value as ISingleResponse<ServiceEnvironmentStatusLog>;

            controller.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}
