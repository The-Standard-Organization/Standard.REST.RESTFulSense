// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using FluentAssertions;
using Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions;
using Standard.REST.RESTFulSense.Tests.Unit.Models.Tests;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.Serializations
{
    public partial class SerializationsTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnSerializeIfObjectIsNull()
        {
            // given
            Person nullPerson = null;

            var nullObjectException =
                new NullObjectException();

            var expectedSerializationValidationException =
                new SerializationValidationException(nullObjectException);

            // when
            Action serializeObjectAction = () =>
                this.serializationService.Serialize<Person>(nullPerson);

            SerializationValidationException actualSerializationValidationException =
                Assert.Throws<SerializationValidationException>(serializeObjectAction);

            // then
            actualSerializationValidationException.Should()
                .BeEquivalentTo(expectedSerializationValidationException);

            this.serializationBrokerMock.VerifyNoOtherCalls();
        }
    }
}
