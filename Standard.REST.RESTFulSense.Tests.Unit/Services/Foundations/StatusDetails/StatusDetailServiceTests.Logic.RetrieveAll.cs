// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using FluentAssertions;
using Moq;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        [Fact]
        public void ShouldReturnStatusDetails()
        {
            // given
            IQueryable<StatusDetail> randomStatusDetails = CreateRandomStatusDetails();
            IQueryable<StatusDetail> storageStatusDetails = randomStatusDetails;
            IQueryable<StatusDetail> expectedStatusDetails = storageStatusDetails;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Returns(storageStatusDetails);

            // when
            IQueryable<StatusDetail> actualStatusDetails =
                this.statusDetailService.RetrieveAllStatusDetails();

            // then
            actualStatusDetails.Should().BeEquivalentTo(expectedStatusDetails);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
