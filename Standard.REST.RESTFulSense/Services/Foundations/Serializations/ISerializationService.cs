// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Newtonsoft.Json;

namespace Standard.REST.RESTFulSense.Services.Foundations.Serializations
{
    internal interface ISerializationService
    {
        string Serialize<T>(T obj, JsonSerializerSettings settings = null);
    }
}
