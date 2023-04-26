// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Standard.REST.RESTFulSense.Brokers.Serializations;

namespace Standard.REST.RESTFulSense.Services.Foundations.Serializations
{
    internal partial class SerializationService : ISerializationService
    {
        private readonly ISerializationBroker serializationBroker;

        public SerializationService(ISerializationBroker serializationBroker) =>
            this.serializationBroker = serializationBroker;

        public string Serialize<T>(T obj, JsonSerializerSettings settings = null) =>
            throw new NotImplementedException();
    }
}
