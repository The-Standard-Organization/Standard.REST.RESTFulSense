// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions;
using Xeptions;

namespace Standard.REST.RESTFulSense.Services.Foundations.StatusDetails
{
    internal partial class StatusDetailService
    {
        private delegate IQueryable<StatusDetail> ReturningStatusDetailsFunction();
        private delegate StatusDetail ReturningStatusDetailFunction();

        private IQueryable<StatusDetail> TryCatch(ReturningStatusDetailsFunction returningStatusDetailsFunction)
        {
            try
            {
                return returningStatusDetailsFunction();
            }
            catch (JsonReaderException jsonReaderException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(jsonReaderException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (JsonSerializationException jsonSerializationException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(jsonSerializationException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (JsonException jsonException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(jsonException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(argumentNullException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (ArgumentException argumentException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(argumentException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (PathTooLongException pathTooLongException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(pathTooLongException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(directoryNotFoundException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(fileNotFoundException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(unauthorizedAccessException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (NotSupportedException notSupportedException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(notSupportedException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (IOException iOException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(iOException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (Exception exception)
            {
                var failedStatusDetailServiceException =
                    new FailedStatusDetailServiceException(exception);

                throw CreateAndLogServiceException(failedStatusDetailServiceException);
            }
        }

        private StatusDetail TryCatch(ReturningStatusDetailFunction returningStatusDetailFunction)
        {
            try
            {
                return returningStatusDetailFunction();
            }
            catch (NotFoundStatusDetailException notFoundStatusDetailException)
            {
                throw CreateAndLogValidationException(notFoundStatusDetailException);
            }
            catch (JsonReaderException jsonReaderException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(jsonReaderException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (JsonSerializationException jsonSerializationException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(jsonSerializationException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (JsonException jsonException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(jsonException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(argumentNullException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (ArgumentException argumentException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(argumentException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (PathTooLongException pathTooLongException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(pathTooLongException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(directoryNotFoundException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(fileNotFoundException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(unauthorizedAccessException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (NotSupportedException notSupportedException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(notSupportedException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
            catch (IOException iOException)
            {
                var failedStatusDetailStorageException =
                    new FailedStatusDetailStorageException(iOException);

                throw CreateAndLogDependencyException(failedStatusDetailStorageException);
            }
        }

        private StatusDetailDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var statusDetailDependencyException =
                new StatusDetailDependencyException(exception);

            return statusDetailDependencyException;
        }

        private StatusDetailValidationException CreateAndLogValidationException(Xeption exception)
        {
            var statusDetailValidationException =
                new StatusDetailValidationException(exception);

            return statusDetailValidationException;
        }

        private StatusDetailServiceException CreateAndLogServiceException(Xeption exception)
        {
            var statusDetailServiceException =
                new StatusDetailServiceException(exception);

            return statusDetailServiceException;
        }
    }
}
