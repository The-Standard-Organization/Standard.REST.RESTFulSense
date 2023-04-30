// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
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
            catch (ArgumentException argumentException)
            {
                var failedArgumentException =
                    new FailedArgumentException(argumentException);

                throw CreateAndLogDependencyValidationException(failedArgumentException);
            }
        }

        private SerializationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var serializationValidationException =
                new SerializationValidationException(exception);

            return serializationValidationException;
        }

        private SerializationDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var serializationDependencyValidationException =
                new SerializationDependencyValidationException(exception);

            return serializationDependencyValidationException;
        }
    }
}
