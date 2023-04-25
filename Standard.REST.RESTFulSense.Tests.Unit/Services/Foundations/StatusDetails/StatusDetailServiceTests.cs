// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Moq;
using Standard.REST.RESTFulSense.Brokers.Storages;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;
using Standard.REST.RESTFulSense.Services.Foundations.StatusDetails;
using Tynamix.ObjectFiller;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IStatusDetailService statusDetailService;

        public StatusDetailServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.statusDetailService = new StatusDetailService(storageBroker: this.storageBrokerMock.Object);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static IQueryable<StatusDetail> CreateRandomStatusDetails()
        {
            return CreateStatusDetailFiller()
                .Create(count: GetRandomNumber())
                    .AsQueryable();
        }

        private static Filler<StatusDetail> CreateStatusDetailFiller()
        {
            var filler = new Filler<StatusDetail>();
            filler.Setup();

            return filler;
        }
    }
}
