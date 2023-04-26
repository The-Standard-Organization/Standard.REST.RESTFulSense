// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Standard.REST.RESTFulSense.Models.Foundations.Serializations.Exceptions;
using Xeptions;

namespace Standard.REST.RESTFulSense.Services.Foundations.Serializations
{
    internal partial class SerializationService
    {
        private delegate T ReturningObjectFunction<T>();

        private T TryCatch<T>(ReturningObjectFunction<T> returningObjectFunction)
        {
            try
            {
                return returningObjectFunction();
            }
            catch (NullObjectException nullObjectException)
            {
                throw CreateAndLogValidationException(nullObjectException);
            }
        }

        private SerializationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var serializationValidationException =
                new SerializationValidationException(exception);

            return serializationValidationException;
        }
    }
}
