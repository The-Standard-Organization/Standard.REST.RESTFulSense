﻿// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions;
using Standard.REST.RESTFulSense.Tests.Unit.Models.Tests;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.Serializations
{
    public partial class SerializationsTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSerializeIfArgumentErrorOccurs()
        {
            // given
            Person somePerson = CreateRandomPerson();
            JsonSerializerSettings someSettings = null;
            var argumentException = new ArgumentException();

            var failedArgumentException =
                new FailedArgumentException(argumentException);

            var expectedSerializationDependencyValidationException =
                new SerializationDependencyValidationException(failedArgumentException);

            this.serializationBrokerMock.Setup(broker =>
                broker.Serialize(somePerson, someSettings))
                    .Throws(argumentException);

            // when
            Action serializeObjectAction = () =>
                this.serializationService.Serialize(somePerson, someSettings);

            SerializationDependencyValidationException actualSerializationDependencyValidationException =
                Assert.Throws<SerializationDependencyValidationException>(serializeObjectAction);

            // then
            actualSerializationDependencyValidationException.Should()
                .BeEquivalentTo(expectedSerializationDependencyValidationException);

            this.serializationBrokerMock.Verify(broker =>
                broker.Serialize(somePerson, someSettings),
                    Times.Once);

            this.serializationBrokerMock.VerifyNoOtherCalls();
        }
    }
}
