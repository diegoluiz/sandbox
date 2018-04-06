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
    public class FizzBuzzProcessorShould
    {
        private ILogger _loggerMock;
        private IReporter _processingReporterMock;
        private FizzBuzzProcessor _sut;

        private const string FIZZ = "fizz";
        private const string BUZZ = "buzz";
        private const string FIZZBUZZ = "fizzbuzz";
        private const string LUCKY = "lucky";

        [SetUp]
        public void Setup()
        {
            _loggerMock = Substitute.For<ILogger>();
            _processingReporterMock = Substitute.For<IReporter>();

            _sut = new FizzBuzzProcessor(_loggerMock, _processingReporterMock);
        }

        [TestCase(1, 3, 3)]
        [TestCase(5, 100, 96)]
        [TestCase(5, 1, 0)]
        public void Print_Correct_Numbers_Count(int initialNumber, int finalNumber, int totalCalls)
        {
            _sut.Process(initialNumber, finalNumber);

            _loggerMock.Received(totalCalls).Log(Arg.Any<string>());
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        public void Print_Received_Number_When_Not_Fitting_Fizz_Buzz(int number)
        {
            _sut.Process(number, number);

            _loggerMock.Received(1).Log(number.ToString());
        }

        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        public void Print_Fizz(int number)
        {
            _sut.Process(number, number);

            _loggerMock.Received(1).Log(FIZZ);
        }

        [TestCase(5)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(40)]
        public void Print_Buzz(int number)
        {
            _sut.Process(number, number);

            _loggerMock.Received(1).Log(BUZZ);
        }

        [TestCase(15)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(75)]
        public void Print_FizzBuzz(int number)
        {
            _sut.Process(number, number);

            _loggerMock.Received(1).Log(FIZZBUZZ);
        }

        [TestCase(3)]
        [TestCase(13)]
        [TestCase(23)]
        [TestCase(30)]
        [TestCase(31)]
        public void Print_Lucky(int number)
        {
            _sut.Process(number, number);

            _loggerMock.Received(1).Log(LUCKY);
        }


        [TestCase(1, 3, 3)]
        [TestCase(5, 100, 96)]
        [TestCase(5, 1, 0)]
        public void Call_Reporting_For_Each_Number(int initialNumber, int finalNumber, int totalCalls)
        {
            _sut.Process(initialNumber, finalNumber);

            _processingReporterMock.Received(totalCalls).Increment(Arg.Any<string>());
        }

        [Test]
        public void Call_Reporting_Print()
        {
            _sut.Process(0, 1);

            _processingReporterMock.Received().Print();
        }

    }
}
