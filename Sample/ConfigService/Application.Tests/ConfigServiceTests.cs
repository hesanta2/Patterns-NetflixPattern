using NUnit.Framework;
using FluentAssertions;
using ConfigService.Infrastructure;
using Moq;
using ConfigService.Domain;

namespace ConfigService.Application.Tests
{
    public class Tests
    {
        private IConfigurationRepository configurationRepository;

        [SetUp]
        public void Setup()
        {
            this.configurationRepository = new ConfigurationRepositoryStub();
        }

        [Test]
        public void Get_ServiceName_Configuration()
        {
            //Arrange
            string serviceName = "MicroserviceTest";
            var configService = new ConfigurationService(configurationRepository);
            configService.AddConfiguration(new Configuration(serviceName));

            //Act
            var configuration = configService.Get(serviceName);

            //Asert
            configuration.ServiceName.Should().Be("MicroserviceTest");
        }



    }
}