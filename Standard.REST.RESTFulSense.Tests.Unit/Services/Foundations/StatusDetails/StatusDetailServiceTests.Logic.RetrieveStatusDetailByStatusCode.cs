// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using System.Linq;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        [Fact]
        public void ShouldReturnStatusDetailByStatusCode()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomStatusCode = 400 + randomNumber;
            IQueryable<StatusDetail> randomStatusDetails = CreateRandomStatusDetails(randomNumber);
            IQueryable<StatusDetail> storageStatusDetails = randomStatusDetails;
            Random random = new Random();

            StatusDetail randomStatusDetail = storageStatusDetails
                .OrderBy(statusDetail => random.Next())
                    .Take(1)
                        .SingleOrDefault();

            StatusDetail inputStatusDetail = randomStatusDetail;
            StatusDetail expectedStatusDetail = inputStatusDetail.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Returns(storageStatusDetails);

            // when
            StatusDetail actualStatusDetail =
                this.statusDetailService.RetrieveStatusDetailByCode(inputStatusDetail.Code);

            // then
            actualStatusDetail.Should().BeEquivalentTo(expectedStatusDetail);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
