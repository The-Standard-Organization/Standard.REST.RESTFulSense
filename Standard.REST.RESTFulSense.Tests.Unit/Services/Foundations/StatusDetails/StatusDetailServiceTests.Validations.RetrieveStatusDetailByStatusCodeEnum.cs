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
            int someStatusCode = GetRandomStatusCode(startFrom: 200);
            HttpStatusCode someHttpStatusCode = (HttpStatusCode)(someStatusCode);
            IQueryable<StatusDetail> randomStatusDetails = CreateRandomStatusDetails();
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

        private static int GetRandomStatusCode(int startFrom)
        {
            int randomNumber = GetRandomNumber();
            int randomStatusCode = randomNumber;

            return startFrom + randomStatusCode;
        }
    }
}
