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
        public void ShouldThrowDependencyExceptionOnRetrieveStatusDetailByCodeIfErrorOccurs(
            Exception dependancyException)
        {
            // given
            int someCode = GetRandomNumber();

            var failedStorageException =
                new FailedStatusDetailStorageException(dependancyException);

            var expectedStatusDetailDependencyException =
                new StatusDetailDependencyException(failedStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Throws(dependancyException);

            // when
            Action retrieveAllStatusDetailsAction = () =>
                this.statusDetailService.RetrieveStatusDetailByCode(someCode);

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
    }
}
