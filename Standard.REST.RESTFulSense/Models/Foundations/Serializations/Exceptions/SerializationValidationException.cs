// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    internal class SerializationValidationException : Xeption
    {
        public SerializationValidationException(Xeption innerException)
            : base(message: "Serialization validation errors occurred, please try again.",
                  innerException)
        { }
    }
}