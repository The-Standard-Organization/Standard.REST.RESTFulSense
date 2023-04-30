// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions
{
    public class FailedArgumentException : Xeption
    {
        public FailedArgumentException(Exception innerException)
            : base(message: "Argument errors occurred, please try again.",
                  innerException)
        { }
    }
}
