// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnRetrieveAllWhenExceptionOccursAndLogIt(
            Exception dependancyException)
        {
            // given
            var failedStorageException =
                new FailedStatusDetailStorageException(dependancyException);

            var expectedStatusDetailDependencyException =
                new StatusDetailDependencyException(failedStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Throws(dependancyException);

            // when
            Action retrieveAllStatusDetailsAction = () =>
                this.statusDetailService.RetrieveAllStatusDetails();

            StatusDetailDependencyException actualStatusDetailDependencyException =
                Assert.Throws<StatusDetailDependencyException>(retrieveAllStatusDetailsAction);

            // then
            actualStatusDetailDependencyException.Should()
                .BeEquivalentTo(expectedStatusDetailDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogItAsync()
        {
            // given
            string exceptionMessage = GetRandomString();
            var serviceException = new Exception(exceptionMessage);

            var failedStatusDetailServiceException =
                new FailedStatusDetailServiceException(serviceException);

            var expectedStatusDetailServiceException =
                new StatusDetailServiceException(failedStatusDetailServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Throws(serviceException);

            // when
            Action retrieveAllStatusDetailsAction = () =>
                this.statusDetailService.RetrieveAllStatusDetails();

            StatusDetailServiceException actualStatusDetailServiceException =
                Assert.Throws<StatusDetailServiceException>(retrieveAllStatusDetailsAction);

            // then
            actualStatusDetailServiceException.Should()
                .BeEquivalentTo(expectedStatusDetailServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
