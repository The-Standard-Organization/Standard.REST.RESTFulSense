// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using Newtonsoft.Json;
using Standard.REST.RESTFulSense.Brokers.Storages;
using Standard.REST.RESTFulSense.Models.Foundations.StatusDetails;
using Standard.REST.RESTFulSense.Services.Foundations.StatusDetails;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.StatusDetails
{
    public partial class StatusDetailServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IStatusDetailService statusDetailService;

        public StatusDetailServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.statusDetailService = new StatusDetailService(storageBroker: this.storageBrokerMock.Object);
        }

        public static TheoryData DependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;

            return new TheoryData<Exception>
            {
                new JsonReaderException(exceptionMessage),
                new JsonSerializationException(exceptionMessage),
                new JsonException(exceptionMessage),
                new ArgumentNullException(exceptionMessage),
                new ArgumentException(exceptionMessage),
                new PathTooLongException(exceptionMessage),
                new DirectoryNotFoundException(exceptionMessage),
                new FileNotFoundException(exceptionMessage),
                new UnauthorizedAccessException(exceptionMessage),
                new NotSupportedException(exceptionMessage),
                new IOException(exceptionMessage),
            };
        }

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static int GetRandomNumber(int min = 2, int max = 8) =>
            new IntRange(min, max).GetValue();

        private static IQueryable<StatusDetail> CreateRandomStatusDetails(int randomNumber)
        {
            List<StatusDetail> statusDetails = new List<StatusDetail>();

            for (int i = 0; i < randomNumber; i++)
            {
                int statusCode = 400 + i;
                statusDetails.Add(CreateStatusDetailFiller(statusCode).Create());
            }

            return statusDetails.AsQueryable();
        }

        private static Filler<StatusDetail> CreateStatusDetailFiller(int statusCode)
        {
            var filler = new Filler<StatusDetail>();
            filler.Setup();

            return filler;
        }
    }
}
