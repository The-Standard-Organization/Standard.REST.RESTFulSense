// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions
{
    public class FailedStatusDetailStorageException : Xeption
    {
        public FailedStatusDetailStorageException(Exception innerException)
            : base(message: "Failed status detail storage error occurred, contact support.", innerException)
        { }
    }
}