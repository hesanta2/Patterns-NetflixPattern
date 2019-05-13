using Cloud.Discovery.Application;
using Cloud.Discovery.Infrastructure;
using Cloud.Shared.Web.Dto;
using DiscoveryService.Application.Tests;
using NUnit.Framework;
using System.Linq;
using FluentAssertions;
using System;
using System.Diagnostics.CodeAnalysis;
using Moq;
using Moq.Protected;
using Microsoft.Extensions.Logging;

namespace Cloud.Discovery.Tests
{
    [ExcludeFromCodeCoverage]
    public class InstanceServiceTests
    {
        private string category = "Cloud.Discovery.Application";
        private IInstanceService instanceService;
        private IInstanceRepository instanceRepository;
        private Instance applicationOneInstance1;
        private ILogger<InstanceService> logger;

        [SetUp]
        public void Setup()
        {
            this.logger = Mock.Of<ILogger<InstanceService>>();
            this.instanceRepository = new InstanceRepositoryStub();
            this.instanceService = new InstanceService(instanceRepository, logger);
            this.applicationOneInstance1 = new Instance()
            {
                App = "ApplicationTest",
                HostName = "hostNameTest",
                IpAddr = "0.0.0.0",
                Port = 6969,
                HealthCheckUrl = "",
                HomePageUrl = "",
                Status = "",
                StatusPageUrl = ""
            };
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void Register_Returns_OneInstance()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            this.instanceService.Register(applicationOneInstance1);

            //Act
            var result = this.instanceService.GetByAppID(appID);

            //Assert
            result.Count().Should().Be(1);
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void Register_SameApplicationInstance_ThrowException()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            this.instanceService.Register(applicationOneInstance1);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.instanceService.Register(applicationOneInstance1));
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void GetByAppID_Return_TwoRegisteredInstances()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            var applicationOneInstance2 = new Instance()
            {
                App = "ApplicationTest",
                HostName = "hostNameTest2",
                IpAddr = "0.0.0.0",
                Port = 6969,
                HealthCheckUrl = "",
                HomePageUrl = "",
                Status = "",
                StatusPageUrl = ""
            };

            //Act
            this.instanceService.Register(applicationOneInstance1);
            this.instanceService.Register(applicationOneInstance2);

            var result = this.instanceService.GetByAppID(appID);

            //Assert
            result.Count().Should().Be(2);
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void GetByAppID_Return_AllInstances()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            string appID2 = "ApplicationTest2";
            var applicationOneInstance2 = new Instance()
            {
                App = appID2,
                HostName = "hostNameTest2",
                IpAddr = "0.0.0.0",
                Port = 6969,
                HealthCheckUrl = "",
                HomePageUrl = "",
                Status = "",
                StatusPageUrl = ""
            };

            //Act
            this.instanceService.Register(applicationOneInstance1);
            this.instanceService.Register(applicationOneInstance2);

            var result = this.instanceService.GetAll();

            //Assert
            result.Count().Should().Be(2);
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void Get_Returns_RegisteredInstance()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            this.instanceService.Register(applicationOneInstance1);
            string instanceId = $"{applicationOneInstance1.HostName}:{applicationOneInstance1.Port}";

            //Act
            var result = this.instanceService.GetByInstanceID(instanceId);

            //Assert
            Assert.NotNull(result);
            result.HostName.Should().Equals(applicationOneInstance1.HostName);
            result.Port.Should().Equals(applicationOneInstance1.Port);
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void GetByInstanceID_Returns_RegisteredInstance()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            this.instanceService.Register(applicationOneInstance1);
            string instanceId = $"{applicationOneInstance1.HostName}:{applicationOneInstance1.Port}";

            //Act
            var result = this.instanceService.GetByInstanceID(instanceId);

            //Assert
            Assert.NotNull(result);
            result.HostName.Should().Equals(applicationOneInstance1.HostName);
            result.Port.Should().Equals(applicationOneInstance1.Port);
        }

        [Test]
        [Category(nameof(InstanceServiceTests))]
        public void Heartbeat_Should_RenewInstanceTimestamp()
        {
            //Arrange
            string appID = "ApplicationTest";
            applicationOneInstance1.App = appID;
            Shared.Domain.Instance instance = (Instance)applicationOneInstance1;
            instance.SetHeartbeat(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 10);
            this.instanceService.Register(instance);
            string instanceId = $"{applicationOneInstance1.HostName}:{applicationOneInstance1.Port}";

            //Act
            var prevTimestamp = instance.HeartbeatTimestamp;
            this.instanceService.Heartbeat(instanceId);
            var result = this.instanceService.GetByInstanceID(instanceId);

            //Assert
            result.HeartbeatTimestamp.Should().BeGreaterThan(prevTimestamp);
        }


    }
}