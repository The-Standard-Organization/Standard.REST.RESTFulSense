// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

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
        public void ShouldReturnStatusDetailByStatusCodeEnum()
        {
            // given
            IQueryable<StatusDetail> randomStatusDetails = CreateRandomStatusDetails();
            IQueryable<StatusDetail> storageStatusDetails = randomStatusDetails;
            StatusDetail randomStatusDetail = GetRandomStatusDetail(storageStatusDetails);
            StatusDetail inputStatusDetail = randomStatusDetail;
            HttpStatusCode inputHttpStatusCode = (HttpStatusCode)inputStatusDetail.Code;
            StatusDetail expectedStatusDetail = inputStatusDetail.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStatusDetails())
                    .Returns(storageStatusDetails);

            // when
            StatusDetail actualStatusDetail =
                this.statusDetailService.RetrieveStatusDetailByCode(inputHttpStatusCode);

            // then
            actualStatusDetail.Should().BeEquivalentTo(expectedStatusDetail);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStatusDetails(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
