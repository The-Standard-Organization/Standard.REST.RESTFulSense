// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
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

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static IQueryable<StatusDetail> CreateRandomStatusDetails()
        {
            return CreateStatusDetailFiller()
                .Create(count: GetRandomNumber())
                    .AsQueryable();
        }

        private static Filler<StatusDetail> CreateStatusDetailFiller()
        {
            var filler = new Filler<StatusDetail>();
            filler.Setup();

            return filler;
        }
    }
}
