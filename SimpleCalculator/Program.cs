using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator myCalculator = new Calculator();
            myCalculator.Inputs = new List<string>();
            myCalculator.Constants = new Dictionary<char, int>();

            myCalculator.GetInput();
        }
    }
}
