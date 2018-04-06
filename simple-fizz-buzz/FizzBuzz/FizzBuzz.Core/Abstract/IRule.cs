namespace FizzBuzz.Core.Abstract
{
    internal interface IRule
    {
        bool Matches(int number);
        string GetValue(int number);
    }
}