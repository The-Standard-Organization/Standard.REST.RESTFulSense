// ---------------------------------------------------------------
// Copyright (c) 2023 - The Standard Community - All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

namespace Standard.REST.RESTFulSense.Brokers.Storages
{
    internal partial class StorageBroker
    {
        private IQueryable<StatusCode> statusCodes { get; set; }

        public IQueryable<StatusCode> SelectAllStatusCodes()
        {
            return this.statusCodes;
        }
    }
}
