// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Brokers.Storages;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

namespace Standard.REST.RESTFulSense.Services.Foundations.StatusDetails
{
    internal partial class StatusDetailService : IStatusDetailService
    {
        private readonly IStorageBroker storageBroker;

        public StatusDetailService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public IQueryable<StatusDetail> RetrieveAllStatusDetails() =>
            storageBroker.SelectAllStatusDetails();
    }
}
