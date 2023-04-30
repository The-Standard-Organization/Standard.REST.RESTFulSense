// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
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
        public void ShouldThrowDependencyValidationExceptionOnSerializeIfArgumentErrorOccurs()
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

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnSerializeIfArgumentErrorOccurs(
            Exception dependancyException)
        {
            // given
            Person somePerson = CreateRandomPerson();
            JsonSerializerSettings someSettings = null;

            var failedSerializationException =
                new FailedSerializationException(dependancyException);

            var expectedSerializationDependencyException =
                new SerializationDependencyException(failedSerializationException);

            this.serializationBrokerMock.Setup(broker =>
                broker.Serialize(somePerson, someSettings))
                    .Throws(dependancyException);

            // when
            Action serializeObjectAction = () =>
                this.serializationService.Serialize(somePerson, someSettings);

            SerializationDependencyException actualSerializationDependencyException =
                Assert.Throws<SerializationDependencyException>(serializeObjectAction);

            // then
            actualSerializationDependencyException.Should()
                .BeEquivalentTo(expectedSerializationDependencyException);

            this.serializationBrokerMock.Verify(broker =>
                broker.Serialize(somePerson, someSettings),
                    Times.Once);

            this.serializationBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnSerializeIfServiceErrorOccurs()
        {
            // given
            Person somePerson = CreateRandomPerson();
            JsonSerializerSettings someSettings = null;
            string exceptionMessage = GetRandomString();
            var serviceException = new Exception(exceptionMessage);

            var failedSerializationServiceException =
                new FailedSerializationServiceException(serviceException);

            var expectedSerializationServiceException =
                new SerializationServiceException(failedSerializationServiceException);

            this.serializationBrokerMock.Setup(broker =>
                broker.Serialize(somePerson, someSettings))
                    .Throws(serviceException);

            // when
            Action serializeObjectAction = () =>
                this.serializationService.Serialize(somePerson, someSettings);

            SerializationServiceException actualSerializationServiceException =
                Assert.Throws<SerializationServiceException>(serializeObjectAction);

            // then
            actualSerializationServiceException.Should()
                .BeEquivalentTo(expectedSerializationServiceException);

            this.serializationBrokerMock.Verify(broker =>
                broker.Serialize(somePerson, someSettings),
                    Times.Once);

            this.serializationBrokerMock.VerifyNoOtherCalls();
        }
    }
}
