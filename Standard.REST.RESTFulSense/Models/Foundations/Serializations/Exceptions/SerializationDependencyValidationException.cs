// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    internal class SerializationDependencyValidationException : Xeption
    {
        public SerializationDependencyValidationException(Xeption innerException)
            : base(message: "Serialization dependency validation errors occurred, please try again.",
                  innerException)
        { }
    }
}
