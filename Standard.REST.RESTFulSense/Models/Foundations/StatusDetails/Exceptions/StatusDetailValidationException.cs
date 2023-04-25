// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions
{
    public class StatusDetailValidationException : Xeption
    {
        public StatusDetailValidationException(Xeption innerException)
            : base(message: "Status detail validation errors occurred, please try again.",
                  innerException)
        { }
    }
}