using NUnit.Framework;
using FluentAssertions;
using System;
using Newtonsoft.Json;

namespace Common.Domain.Tests
{
    public class UniqueIdGeneratorServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateUniqueId_ShouldReturns_56bytesNumber()
        {
            //Arrange
            IUniqueIdGeneratorService uniqueIdGeneratorService = new UniqueIdGeneratorService();

            //Act
            long uniqueId = uniqueIdGeneratorService.GenerateUniqueId();

            //Assert
            uniqueId.ToString().Length.Should().Be(16);
        }
    }
}