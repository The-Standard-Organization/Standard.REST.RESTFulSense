// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Newtonsoft.Json;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails
{
    internal class StatusDetail
    {
        [JsonProperty("statusCode")]
        public int Code { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
