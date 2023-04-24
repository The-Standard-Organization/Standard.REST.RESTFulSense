// ---------------------------------------------------------------
// Copyright (c) 2023 - The Standard Community - All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
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

        public async ValueTask<StatusCode> SelectStatusCodeByCodeAsync(int code) =>
            await Task.FromResult(this.statusCodes.FirstOrDefault(statusCode => statusCode.Code == code));
    }
}
