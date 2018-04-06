using System;
using FizzBuzz.Core.Abstract;

namespace FizzBuzz.Console
{
    class Logger : ILogger
    {
        public void Log(string text)
        {
            System.Console.Write(text + " ");
        }

        public void LogLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
