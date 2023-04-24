// ---------------------------------------------------------------
// Copyright (c) 2023 - The Standard Community - All rights reserved.
// ---------------------------------------------------------------

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
            this.InitialiseStatusCodes();

        private void InitialiseStatusCodes()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data\\StatusCodes.json");
            string json = File.ReadAllText(path);
            this.statusCodes = JsonConvert.DeserializeObject<List<StatusCode>>(json).AsQueryable();
        }
    }
}
