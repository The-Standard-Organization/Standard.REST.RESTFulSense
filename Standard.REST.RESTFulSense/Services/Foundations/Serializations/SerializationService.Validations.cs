// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions;

namespace Standard.REST.RESTFulSense.Services.Foundations.Serializations
{
    internal partial class SerializationService
    {
        private static void ValidateObjectIsNotNull<T>(T @object)
        {
            if (@object == null)
            {
                throw new NullObjectException();
            }
        }
    }
}
