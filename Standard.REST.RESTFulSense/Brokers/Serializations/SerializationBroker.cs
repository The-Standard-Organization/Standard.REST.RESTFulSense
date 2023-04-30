// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Newtonsoft.Json;

namespace Standard.REST.RESTFulSense.Brokers.Serializations
{
    internal class SerializationBroker : ISerializationBroker
    {
        public string Serialize<T>(T obj, JsonSerializerSettings settings = null) =>
            JsonConvert.SerializeObject(obj, settings);

        public T Deserialize<T>(string json, JsonSerializerSettings settings = null) =>
            JsonConvert.DeserializeObject<T>(json, settings);
    }
}
