using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Core.Abstract
{
    public interface IReporter
    {
        void Increment(string key);
        void Print();
    }
}
