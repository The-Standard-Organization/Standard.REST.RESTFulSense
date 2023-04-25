// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System.Linq;
using Standard.REST.RESTFulSense.Models.HttpStatusCodes;

internal interface IStatusDetailService
{
    IQueryable<StatusDetail> RetrieveAllStatusDetails();
}