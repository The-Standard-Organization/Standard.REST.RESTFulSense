// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

namespace Standard.REST.RESTFulSense.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        public StorageBroker() =>
            statusDetails = InitialiseStatusCodes();

        private static IQueryable<StatusDetail> InitialiseStatusCodes()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data\\StatusCodes.json");
            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<StatusDetail>>(json).AsQueryable();
        }
    }
}
