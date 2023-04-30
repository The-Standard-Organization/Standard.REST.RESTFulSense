// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    internal class SerializationDependencyException : Xeption
    {
        public SerializationDependencyException(Xeption innerException)
            : base(message: "Serialization dependency errors occurred, please try again.",
                  innerException)
        { }
    }
}
