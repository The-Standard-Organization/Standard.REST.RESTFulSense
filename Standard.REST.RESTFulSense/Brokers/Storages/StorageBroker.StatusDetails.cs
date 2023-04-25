// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

namespace Standard.REST.RESTFulSense.Brokers.Storages
{
    internal partial class StorageBroker
    {
        private IQueryable<StatusDetail> statusDetails { get; set; }

        public IQueryable<StatusDetail> SelectAllStatusDetails() =>
            statusDetails;
    }
}
