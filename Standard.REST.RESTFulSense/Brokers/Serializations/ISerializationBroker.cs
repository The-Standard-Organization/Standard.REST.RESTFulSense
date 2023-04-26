// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Newtonsoft.Json;

namespace Standard.REST.RESTFulSense.Brokers.Serializations
{
    internal interface ISerializationBroker
    {
        string Serialize<T>(T obj, JsonSerializerSettings settings = null);
    }
}
