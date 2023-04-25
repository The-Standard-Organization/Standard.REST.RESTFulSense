// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using System.Linq;
using FluentAssertions;
using Moq;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        [Fact]
        public void ShouldThrowNotFoundExceptionOnRetrieveByIdIfStatusDetailIsNotFoundAndLogItAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomStatusCode = randomNumber;
            int someStatusDetailId = randomStatusCode;
            IQueryable<StatusDetail> randomStatusDetails = CreateRandomStatusDetails(randomNumber);
            IQueryable<StatusDetail> storageStatusDetails = randomStatusDetails;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Returns(storageStatusDetails);

            var notFoundStatusDetailException =
                new NotFoundStatusDetailException(someStatusDetailId);

            var expectedStatusDetailValidationException =
                new StatusDetailValidationException(notFoundStatusDetailException);

            // when
            Action retrieveStatusDetailByIdAction = () =>
                this.statusDetailService.RetrieveStatusDetailByCode(someStatusDetailId);

            StatusDetailValidationException actualStatusDetailValidationException =
                Assert.Throws<StatusDetailValidationException>(retrieveStatusDetailByIdAction);

            // then
            actualStatusDetailValidationException.Should().BeEquivalentTo(expectedStatusDetailValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
