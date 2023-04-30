// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions
{
    public class StatusDetailServiceException : Xeption
    {
        public StatusDetailServiceException(Exception innerException)
            : base(message: "Status detail service error occurred, contact support.", innerException)
        { }
    }
}