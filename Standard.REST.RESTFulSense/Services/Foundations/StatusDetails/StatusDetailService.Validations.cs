// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails.Exceptions;

namespace Standard.REST.RESTFulSense.Services.Foundations.StatusDetails
{
    internal partial class StatusDetailService
    {
        private static void ValidateStorageStatusDetail(StatusDetail maybeStatusDetail, int statusCode)
        {
            if (maybeStatusDetail is null)
            {
                throw new NotFoundStatusDetailException(statusCode);
            }
        }
    }
}
