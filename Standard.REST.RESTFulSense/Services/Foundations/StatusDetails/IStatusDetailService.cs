// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;

internal interface IStatusDetailService
{
    IQueryable<StatusDetail> RetrieveAllStatusDetails();
    StatusDetail RetrieveStatusDetailByCode(int statusCode);
    StatusDetail RetrieveStatusDetailByCode(HttpStatusCode httpStatusCode);
}