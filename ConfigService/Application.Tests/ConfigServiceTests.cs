using NUnit.Framework;
using FluentAssertions;
using ConfigService.Infrastructure;
using Moq;

namespace ConfigService.Application.Tests
{
    public class Tests
    {
        private Mock<IConfigurationRepository> configurationRepositoryMock;

        [SetUp]
        public void Setup()
        {
            this.configurationRepositoryMock = new Mock<IConfigurationRepository>();
        }

        [Test]
        public void Get_ServiceName_Configuration()
        {
            //Arrange
            string serviceName = "MicroserviceTest";
            this.configurationRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<string>()))
                .Returns(new Domain.Configuration(serviceName));
            var configService = new ConfigurationService(configurationRepositoryMock.Object);

            //Act
            var configuration = configService.Get(serviceName);

            //Asert
            configuration.ServiceName.Should().Be("MicroserviceTest");
        }
    }
}