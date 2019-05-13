using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace AddMicroservice.Application.Tests
{
    public class AddServiceTests
    {
        private IAddService addService;

        [SetUp]
        public void Setup()
        {
            this.addService = new AddService();
        }

        [Test]
        public void Five_Add_Three_ShouldReturn_Eight()
        {
            // Arrange:
            //Act:
            var result = this.addService.Add(5, 3);

            //Assert:
            result.Should().Be(8);
        }
    }
}