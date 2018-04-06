using FizzBuzz.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Core
{
    public class ProcessingReporter : IReporter
    {
        private const string INTEGER_KEY = "integer";
        Dictionary<string, int> _report = new Dictionary<string, int>();

        private ILogger _loggerMock;

        public ProcessingReporter(ILogger loggerMock)
        {
            _loggerMock = loggerMock;
        }

        public void Increment(string key)
        {
            int number;
            if (int.TryParse(key, out number))
            {
                key = INTEGER_KEY;
            }

            if (!_report.ContainsKey(key))
                _report.Add(key, 0);

            _report[key]++;
        }

        public void Print()
        {
            foreach (var item in _report)
            {
                _loggerMock.LogLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
