// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions
{
    internal class StatusDetailDependencyException : Xeption
    {
        public StatusDetailDependencyException(Xeption innerException) :
            base(message: "Status detail dependency error occurred, contact support.", innerException)
        { }
    }
}