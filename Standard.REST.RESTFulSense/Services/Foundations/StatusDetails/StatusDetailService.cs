// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Brokers.Storages;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;

namespace Standard.REST.RESTFulSense.Services.Foundations.StatusDetails
{
    internal partial class StatusDetailService : IStatusDetailService
    {
        private readonly IStorageBroker storageBroker;

        public StatusDetailService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public IQueryable<StatusDetail> RetrieveAllStatusDetails() =>
            TryCatch(() => this.storageBroker.SelectAllStatusDetails());

        public StatusDetail RetrieveStatusDetailByCode(int statusCode) =>
            TryCatch(() =>
            {
                StatusDetail maybeStatusDetail = this.storageBroker.SelectAllStatusDetails()
                    .FirstOrDefault(statusDetail => statusDetail.Code == statusCode);

                ValidateStorageStatusDetail(maybeStatusDetail, statusCode);

                return maybeStatusDetail;
            });

        public StatusDetail RetrieveStatusDetailByCode(HttpStatusCode statusCode) =>
            throw new System.NotImplementedException();
    }
}
