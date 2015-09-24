using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    public class Calculator
    {
        private int counter = 0;
        public List<string> Inputs;
        public Dictionary<char, int> Constants;

        public Calculator() { }

        public int GetCounter()
        {
            return this.counter;
        }

        public void GetInput()
        {

            Console.Write("[{0}]> ", GetCounter());
            string currentInput = Console.ReadLine();

            //char[] operations = { '+', '-', '*', '/', '%' };
            //string[] operands = currentInput.Split(operations);
            //int op1 = int.Parse(operands[0]);
            //int op2 = int.Parse(operands[1]);

            //Console.WriteLine("{0}  {1}  {2}", op1, "+", op2);
            

            String pattern = @"(\d+)\s+([-+*/%])\s+(\d+)";
            String keywords = @"\bexit\b|\bquit\b";
            Match match = Regex.Match(currentInput, pattern);
            Match keywordMatch = Regex.Match(currentInput, keywords);

            if (keywordMatch.Success)
            {
                switch (keywordMatch.Groups[0].Value)
                {
                    case "exit":
                        Console.WriteLine("Exit");
                        break;
                    case "quit":
                        Console.WriteLine("Quit");
                        break;
                }
                Console.ReadLine();
            }

            if (match.Success)
            {

                int value1 = Int32.Parse(match.Groups[1].Value);
                int value2 = Int32.Parse(match.Groups[3].Value);
                switch (match.Groups[2].Value)
                {
                    case "+":
                        Console.WriteLine("{0} + {1}", value1, value2);
                        break;
                    case "-":
                        Console.WriteLine("{0} - {1}", value1, value2);
                        break;
                    case "*":
                        Console.WriteLine("{0} * {1}", value1, value2);
                        break;
                    case "/":
                        Console.WriteLine("{0} / {1}", value1, value2);
                        break;
                    case "%":
                        Console.WriteLine("{0} / {1}", value1, value2);
                        break;
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Not a valid expression");
            }


        }
    }
}