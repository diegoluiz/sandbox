using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz.Core.Abstract;
using FizzBuzz.Core.Rules;

namespace FizzBuzz.Core
{
    public class FizzBuzzProcessor
    {
        private static readonly List<IRule> _rules = new List<IRule>();
        private static ILogger _logger;
        private IReporter _processingReporter;

        public FizzBuzzProcessor(ILogger logger, IReporter processingReporter)
        {
            _rules.Add(new LuckyRule());
            _rules.Add(new FizzBuzzRule());
            _rules.Add(new BuzzRule());
            _rules.Add(new FizzRule());
            _rules.Add(new IntegerRule());

            _logger = logger;
            _processingReporter = processingReporter;
        }

        public void Process(int initialNumber, int finalNumber)
        {
            string value = string.Empty;

            for (int i = initialNumber; i <= finalNumber; i++)
            {
                value = Evaluate(i);

                _processingReporter.Increment(value);
                _logger.Log(value);
            }

            _logger.LogLine("");
            _processingReporter.Print();
        }

        private static string Evaluate(int number)
        {
           foreach(var rule in _rules)
            {
                if (rule.Matches(number))
                {
                    return rule.GetValue(number);
                }
            }

            throw new ApplicationException($"No rule was found for the give number. Number: [{number}]");
        }
    }
}
