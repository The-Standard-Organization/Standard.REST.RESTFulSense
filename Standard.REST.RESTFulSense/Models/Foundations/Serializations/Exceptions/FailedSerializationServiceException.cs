// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    public class FailedSerializationServiceException : Xeption
    {
        public FailedSerializationServiceException(Exception innerException)
            : base(message: "Failed serialization service error occurred, please contact support", innerException)
        { }
    }
}
