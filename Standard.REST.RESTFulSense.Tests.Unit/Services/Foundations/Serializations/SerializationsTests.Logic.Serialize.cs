// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using FluentAssertions;
using Moq;
using Standard.REST.RESTFulSense.Tests.Unit.Models.Tests;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.Serializations
{
    public partial class SerializationsTests
    {
        [Fact]
        public void ShouldSerializeObject()
        {
            // given
            Person randomPerson = CreateRandomPerson();
            Person inputPerson = randomPerson;

            string outputString = "{\"Id\": " + inputPerson.Name
                + ", \"Name\": \"" + inputPerson.Name
                + "\",\"Surname\": \"" + inputPerson.Surname + "\"}";

            string expectedResult = outputString;

            this.serializationBrokerMock.Setup(broker =>
                broker.Serialize<Person>(inputPerson, null))
                    .Returns(outputString);

            // when
            string actualResult = this.serializationService.Serialize(inputPerson);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);

            this.serializationBrokerMock.Verify(broker =>
                broker.Serialize<Person>(inputPerson, null),
                    Times.Once());

            this.serializationBrokerMock.VerifyNoOtherCalls();
        }
    }
}
