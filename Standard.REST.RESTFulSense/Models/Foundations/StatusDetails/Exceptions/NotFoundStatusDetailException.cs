// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions
{
    public class NotFoundStatusDetailException : Xeption
    {
        public NotFoundStatusDetailException(int statusCode)
            : base(message: $"Couldn't find a status detail with code: {statusCode}.")
        { }
    }
}