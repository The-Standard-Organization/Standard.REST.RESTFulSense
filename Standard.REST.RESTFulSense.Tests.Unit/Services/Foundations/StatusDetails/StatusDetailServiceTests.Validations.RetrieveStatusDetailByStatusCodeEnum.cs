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
        public void ShouldThrowNotFoundExceptionOnRetrieveByHttpStatusCodeIfStatusDetailIsNotFound()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomStatusCode = randomNumber;
            int someStatusCode = 200 + randomStatusCode;
            HttpStatusCode someHttpStatusCode = (HttpStatusCode)(someStatusCode);
            IQueryable<StatusDetail> randomStatusDetails = CreateRandomStatusDetails(randomNumber);
            IQueryable<StatusDetail> storageStatusDetails = randomStatusDetails;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Returns(storageStatusDetails);

            var notFoundStatusDetailException =
                new NotFoundStatusDetailException(someStatusCode);

            var expectedStatusDetailValidationException =
                new StatusDetailValidationException(notFoundStatusDetailException);

            // when
            Action retrieveStatusDetailByCodeAction = () =>
                this.statusDetailService.RetrieveStatusDetailByCode(someHttpStatusCode);

            StatusDetailValidationException actualStatusDetailValidationException =
                Assert.Throws<StatusDetailValidationException>(retrieveStatusDetailByCodeAction);

            // then
            actualStatusDetailValidationException.Should().BeEquivalentTo(expectedStatusDetailValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
