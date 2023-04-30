// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions
{
    public class FailedStatusDetailServiceException : Xeption
    {
        public FailedStatusDetailServiceException(Exception innerException)
            : base(message: "Failed status detail service occurred, please contact support", innerException)
        { }
    }
}