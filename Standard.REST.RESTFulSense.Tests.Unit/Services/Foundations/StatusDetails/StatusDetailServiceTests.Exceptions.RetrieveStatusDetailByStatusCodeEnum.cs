// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnRetrieveStatusDetailByCodeEnumIfErrorOccurs(
            Exception dependancyException)
        {
            // given
            int randomNumber = GetRandomNumber();
            int someStatusCode = 200 + randomNumber;
            HttpStatusCode someHttpStatusCode = (HttpStatusCode)(someStatusCode);

            var failedStorageException =
                new FailedStatusDetailStorageException(dependancyException);

            var expectedStatusDetailDependencyException =
                new StatusDetailDependencyException(failedStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Throws(dependancyException);

            // when
            Action retrieveStatusDetailByCodeAction = () =>
                this.statusDetailService.RetrieveStatusDetailByCode(someHttpStatusCode);

            StatusDetailDependencyException actualStatusDetailDependencyException =
                Assert.Throws<StatusDetailDependencyException>(retrieveStatusDetailByCodeAction);

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
