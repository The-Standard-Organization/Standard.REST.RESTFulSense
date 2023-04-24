// ---------------------------------------------------------------
// Copyright (c) 2023 - The Standard Community - All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

namespace Standard.REST.RESTFulSense.Brokers.Storages
{
    internal partial interface IStorageBroker
    {
        IQueryable<StatusCode> SelectAllStatusCodes();
        ValueTask<StatusCode> SelectStatusCodeByCodeAsync(int code);
    }
}
