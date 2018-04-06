using FizzBuzz.Core.Abstract;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Core.Test
{
    [TestFixture]
    public class ProcessingReporterShould
    {
        private ILogger _loggerMock;
        private ProcessingReporter _sut;
        
        [SetUp]
        public void Setup()
        {
            _loggerMock = Substitute.For<ILogger>();
            _sut = new ProcessingReporter(_loggerMock);
        }

        [Test]
        public void Print_Counter_For_Numbers()
        {
            _sut.Increment("1");
            _sut.Increment("2");
            _sut.Increment("10");
            _sut.Increment("1000");

            _sut.Print();

            _loggerMock.Received().LogLine("integer: 4");
        }

        [Test]
        public void Print_Counter_For_Non_Numbers()
        {
            _sut.Increment("fizz");
            _sut.Increment("buzz");
            _sut.Increment("fizzbuzz");
            _sut.Increment("lucky");

            _sut.Print();

            _loggerMock.Received().LogLine("fizz: 1");
            _loggerMock.Received().LogLine("buzz: 1");
            _loggerMock.Received().LogLine("fizzbuzz: 1");
            _loggerMock.Received().LogLine("lucky: 1");
        }


        [Test]
        public void Print_Counter_For_Mixed_Integers_And_Non_Integers()
        {
            _sut.Increment("1");
            _sut.Increment("2");
            _sut.Increment("10");
            _sut.Increment("1000");
            _sut.Increment("fizz");
            _sut.Increment("buzz");
            _sut.Increment("fizzbuzz");
            _sut.Increment("lucky");

            _sut.Print();

            _loggerMock.Received().LogLine("integer: 4");
            _loggerMock.Received().LogLine("fizz: 1");
            _loggerMock.Received().LogLine("buzz: 1");
            _loggerMock.Received().LogLine("fizzbuzz: 1");
            _loggerMock.Received().LogLine("lucky: 1");
        }
    }
}
