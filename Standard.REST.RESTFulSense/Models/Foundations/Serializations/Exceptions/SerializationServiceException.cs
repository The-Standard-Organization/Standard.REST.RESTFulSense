// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    internal class SerializationServiceException : Xeption
    {
        public SerializationServiceException(Xeption innerException)
            : base(message: "Serialization service errors occurred, please try again.",
                  innerException)
        { }
    }
}
