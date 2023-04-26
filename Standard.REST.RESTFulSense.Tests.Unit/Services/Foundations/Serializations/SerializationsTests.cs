// -------------------------------------------------------------
// Copyright (c) - The Standard Community - All rights reserved.
// -------------------------------------------------------------

using Moq;
using Standard.REST.RESTFulSense.Brokers.Serializations;
using Standard.REST.RESTFulSense.Services.Foundations.Serializations;
using Standard.REST.RESTFulSense.Tests.Unit.Models.Tests;
using Tynamix.ObjectFiller;

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
