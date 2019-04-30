using DiscoveryService.Domain;
using DiscoveryService.Infrastructure;
using NUnit.Framework;
using FluentAssertions;
using Moq;

namespace DiscoveryService.Application.Tests
{
    public class DiscoveryServiceTests
    {
        private Mock<IDiscoveryRepository> discoveryRepositoryMock;

        [SetUp]
        public void Setup()
        {
            discoveryRepositoryMock = new Mock<IDiscoveryRepository>();
        }

        [Test]
        public void AddService_Should_AddTheServiceCorrectly()
        {
            //Arrange
            string serviceName = "MicroServiceTest";
            var entity = new DiscoveredInstance(serviceName, new System.Uri("http://microservice.com"));

            this.discoveryRepositoryMock.Setup(repository => repository.Add(It.IsAny<DiscoveredInstance>()));
            this.discoveryRepositoryMock.Setup(repository => repository.Get(It.IsAny<string>())).Returns(entity);
            var discoveryService = new DiscoveryService(discoveryRepositoryMock.Object);

            //Act
            discoveryService.Add(entity);
            var discoveredInstance = discoveryService.Get(serviceName);

            //Assert
            discoveredInstance.Name.Should().Be("MicroServiceTest");
            this.discoveryRepositoryMock.Verify(repository => repository.Add(It.IsAny<DiscoveredInstance>()));
            this.discoveryRepositoryMock.Verify(repository => repository.Get(It.IsAny<string>()));
        }
    }
}