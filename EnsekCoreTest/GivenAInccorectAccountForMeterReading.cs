using EnsekCore;
using EnsekCore.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace EnsekCoreTest
{
    public class GivenAInccorectAccountForMeterReading
    {
        private MeterReadingResults _result;

        [SetUp]
        public void WhenTheMeterReadingsAreStored()
        {
            var repository = new Mock<IRepository>();
           repository.Setup(x => x.Add(It.Is<MeterReading>(z => z.AccountId == 25644344))).Returns(false);

            var subject = new MeterReadingEngine(repository.Object);

            _result = subject.Parse("25644344,4/22/19 9:24,1002,");
        }

        [Test]
        public void ThenNoMeterReadingsAreSaved()
        {
            Assert.That(_result.Successful, Is.EqualTo(0));
        }

        [Test]
        public void ThenFailsToSave()
        {
            Assert.That(_result.Failed, Is.EqualTo(1));
        }
    }
}