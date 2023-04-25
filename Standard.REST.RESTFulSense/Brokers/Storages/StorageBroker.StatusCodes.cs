// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

namespace Standard.REST.RESTFulSense.Brokers.Storages
{
    internal partial class StorageBroker
    {
        private IQueryable<StatusDetail> statusCodes { get; set; }

        public IQueryable<StatusDetail> SelectAllStatusCodes() =>
            statusCodes;
    }
}
