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
        private int value1, value2;
        private string constant;
        private int constantValue;

        enum Action
        {
            EXIT, LAST, LASTQ, ADD, SUBTRACT, MULTIPLY, DIVIDE, MODULUS, CONSTANT
        }

        public int Value1
        {
            get { return value1; }
        }

        public int Value2
        {
            get { return value2; }
        }

        public List<string> Inputs;
        public Dictionary<char, int> Constants;

        public Calculator()
        {
            
        }

        public int GetCounter()
        {
            return this.counter;
        }

        public void RunCalculator()
        {
            int actionCode;
            string lastInput = "", input;
            int lastAnswer = 0, answer = 0;
            
            do
            {
                input = GetInput();
                actionCode = ValidateInput(input);
                switch (actionCode)
                {
                    case 0: // exit or quit
                        Console.WriteLine("Bye!");
                        break;
                    case 1: // last
                        Console.WriteLine(Print("Last answer", lastAnswer));
                        break;
                    case 2: // lastq
                        Console.WriteLine(Print("Last expression", lastInput));
                        break;
                    case 3: // addition
                        answer = this.value1 + this.value2;
                        Print("", answer);
                        break;
                    case 4: // subtraction
                        answer = this.value1 - this.value2;
                        Console.WriteLine(Print("", answer));
                        break;
                    case 5: // multiplication
                        answer = this.value1 * this.value2;
                        Console.WriteLine(Print("", answer));
                        break;
                    case 6: // division
                        answer = this.value1 / this.value2;
                        Console.WriteLine(Print("", answer));
                        break;
                    case 7: // modulus
                        answer = this.value1 % this.value2;
                        Console.WriteLine(Print("", answer));
                        break;
                    case 8:
                        // assign constant
                        break;

                }
                
                // if actionCode = math code, then save answer to lastAnswer
                if (actionCode >= 3 && actionCode <= 7)
                {
                    lastAnswer = answer;
                    lastInput = input;
                }
                
            } while (actionCode != 0);


        }

        public string Print(string message, string answer)
        {
            return String.Format("{0} = {1}", message, answer);
        }

        public string Print(string message, int answer)
        {
            return String.Format("{0} = {1}", message, answer);
        }

        public string GetInput()
        {
            Console.Write("[{0}]> ", GetCounter());
            string currentInput = Console.ReadLine();
            return currentInput;
        }

        public int ValidateInput(string currentInput)
        {
            int actionCode = -1;

            String mathPattern = @"(\d+)\s*([-+*/%])\s*(\d+)";
            String keywordPattern = @"\bexit\b|\bquit\b|\blast\b|\blastq\b";
            String constantPattern = @"([a-zA-Z])\s*([=])\s*(\d+)";

            Match mathMatch = Regex.Match(currentInput, mathPattern);
            Match keywordMatch = Regex.Match(currentInput, keywordPattern);
            Match constantMatch = Regex.Match(currentInput, constantPattern);

            string keyword = keywordMatch.Groups[0].Value;
            if (keywordMatch.Success)
            {
                switch (keyword)
                {
                    case "exit":
                    case "quit":
                        actionCode = 0;
                        break;
                    case "last":
                        actionCode = 1;
                        break;
                    case "lastq":
                        actionCode = 2;
                        break;
                }
            }
            else if (mathMatch.Success)
            {

                this.value1 = Int32.Parse(mathMatch.Groups[1].Value);
                this.value2 = Int32.Parse(mathMatch.Groups[3].Value);
                string operation = mathMatch.Groups[2].Value;

                switch (operation)
                {
                    case "+":
                        actionCode = 3;
                        break;
                    case "-":
                        actionCode = 4;
                        break;
                    case "*":
                        actionCode = 5;
                        break;
                    case "/":
                        actionCode = 6;
                        break;
                    case "%":
                        actionCode = 7;
                        break;
                }
            }
            else if (constantMatch.Success)
            {
                this.constant = constantMatch.Groups[1].Value;
                this.constantValue = int.Parse(constantMatch.Groups[3].Value);
                actionCode = 8;
            }
            else
            {
                Console.WriteLine("Not a valid expression");
            }
            this.counter++;
            return actionCode;

        }
    }
}