// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Newtonsoft.Json;
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
            catch (JsonSerializationException jsonSerializationException)
            {
                var failedSerializationException =
                    new FailedSerializationException(jsonSerializationException);

                throw CreateAndLogDependencyException(failedSerializationException);
            }
            catch (JsonReaderException jsonReaderException)
            {
                var failedSerializationException =
                    new FailedSerializationException(jsonReaderException);

                throw CreateAndLogDependencyException(failedSerializationException);
            }
            catch (JsonWriterException jsonWriterException)
            {
                var failedSerializationException =
                    new FailedSerializationException(jsonWriterException);

                throw CreateAndLogDependencyException(failedSerializationException);
            }
            catch (JsonException jsonException)
            {
                var failedSerializationException =
                    new FailedSerializationException(jsonException);

                throw CreateAndLogDependencyException(failedSerializationException);
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

        private SerializationDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var serializationDependencyException =
                new SerializationDependencyException(exception);

            return serializationDependencyException;
        }
    }
}
