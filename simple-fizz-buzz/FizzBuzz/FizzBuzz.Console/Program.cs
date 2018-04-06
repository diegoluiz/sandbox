using FizzBuzz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var fizzbuzzProcessor = new FizzBuzzProcessor(logger, new ProcessingReporter(logger));

            fizzbuzzProcessor.Process(int.Parse(args[0]), int.Parse(args[1]));
        }
    }
}
