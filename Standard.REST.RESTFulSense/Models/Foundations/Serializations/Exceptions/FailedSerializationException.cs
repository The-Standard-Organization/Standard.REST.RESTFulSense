// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    public class FailedSerializationException : Xeption
    {
        public FailedSerializationException(Exception innerException)
            : base(message: "Failed serialization errors occurred, please try again.",
                  innerException)
        { }
    }
}