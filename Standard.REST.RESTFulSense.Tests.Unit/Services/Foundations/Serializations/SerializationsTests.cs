// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using System;
using Moq;
using Newtonsoft.Json;
using Standard.REST.RESTFulSense.Brokers.Serializations;
using Standard.REST.RESTFulSense.Services.Foundations.Serializations;
using Standard.REST.RESTFulSense.Tests.Unit.Models.Tests;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.REST.RESTFulSense.Tests.Unit.Services.Foundations.Serializations
{
    public partial class SerializationsTests
    {
        private readonly Mock<ISerializationBroker> serializationBrokerMock;
        private readonly ISerializationService serializationService;

        public SerializationsTests()
        {
            this.serializationBrokerMock = new Mock<ISerializationBroker>();

            this.serializationService = new SerializationService(
                serializationBroker: this.serializationBrokerMock.Object);
        }

        public static TheoryData DependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;

            return new TheoryData<Exception>
            {
                new JsonSerializationException(exceptionMessage),
                new JsonReaderException(exceptionMessage),
                new JsonWriterException(exceptionMessage),
                new JsonException(exceptionMessage),
            };
        }

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static int GetRandomNumber(int min = 2, int max = 8) =>
            new IntRange(min, max).GetValue();

        private static Person CreateRandomPerson() =>
            CreatePersonFiller().Create();

        private static Filler<Person> CreatePersonFiller()
        {
            var filler = new Filler<Person>();
            filler.Setup();

            return filler;
        }
    }
}
