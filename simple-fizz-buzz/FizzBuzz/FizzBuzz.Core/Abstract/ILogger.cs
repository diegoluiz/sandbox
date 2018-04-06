using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Core.Abstract
{
    public interface ILogger
    {
        void Log(string text);
        void LogLine(string text);
    }
}
