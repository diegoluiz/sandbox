using FizzBuzz.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Core.Rules
{
    internal class IntegerRule : IRule
    {
        public string GetValue(int number)
        {
            return number.ToString();
        }

        public bool Matches(int number)
        {
            return true;
        }
    }

    internal class FizzRule : IRule
    {
        private const string FIZZ = "fizz";

        public string GetValue(int number)
        {
            return FIZZ;
        }

        public bool Matches(int number)
        {
            return number % 3 == 0;
        }
    }

    internal class BuzzRule : IRule
    {
        private const string BUZZ = "buzz";

        public string GetValue(int number)
        {
            return BUZZ;
        }

        public bool Matches(int number)
        {
            return number % 5 == 0;
        }
    }

    internal class FizzBuzzRule : IRule
    {
        private const string FIZZBUZZ = "fizzbuzz";

        public string GetValue(int number)
        {
            return FIZZBUZZ;
        }

        public bool Matches(int number)
        {
            return number % 5 == 0 && number % 3 == 0;
        }
    }

    internal class LuckyRule : IRule
    {
        private const string LUCKY_NUMBER = "3";
        private const string LUCKY = "lucky";

        public string GetValue(int number)
        {
            return LUCKY;
        }

        public bool Matches(int number)
        {
            return number.ToString().Contains(LUCKY_NUMBER);
        }
    }
}
