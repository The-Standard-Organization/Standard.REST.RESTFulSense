// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    public class NullObjectException : Xeption
    {
        public NullObjectException()
            : base(message: "Object is null.")
        { }
    }
}