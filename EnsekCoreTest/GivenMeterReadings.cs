using EnsekCore;
using EnsekCore.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace EnsekCoreTest
{
    public class GivenMeterReadings
    {
        private MeterReadingResults _result;

        [SetUp]
        public void WhenTheMeterReadingsAreStored()
        {
            var repository = new Mock<IRepository>();

            repository.Setup(x => x.Add(It.Is<MeterReading>(z => z.MeterReadValue != ""))).Returns(true);

            repository.Setup(x => x.Get(It.IsAny<int>())).Returns(new User());

            var subject = new MeterReadingEngine(repository.Object);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "MeterReadings.txt");

            _result = subject.Parse(File.ReadAllText(path));
        }

        [Test]
        public void ThenThirtyFiveIsProccessed()
        {
            Assert.That(_result.MeterReadings.Count, Is.EqualTo(35));
        }

        [Test]
        public void ThenThrityThreeIsSuccesful()
        {
            Assert.That(_result.Successful, Is.EqualTo(30));
        }

        [Test]
        public void ThenTwoFailed()
        {
            Assert.That(_result.Failed, Is.EqualTo(5));
        }
    }
}