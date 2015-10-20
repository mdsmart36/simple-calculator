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
        private string constantKey;
        private int constantValue;

        public enum Action
        {
            INVALID = -1, EXIT, LAST, LASTQ, ADD, SUBTRACT, MULTIPLY, DIVIDE, MODULUS, CONSTANT_ASSIGN, CONSTANT_LOOKUP, CONSTANT_USE, CONSTANT_ERROR, CONSTANT_NOTASSIGNED
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
        public Dictionary<string, int> Constants;

        public Calculator()
        {
            this.Constants = new Dictionary<string, int>();   
        }

        public int GetCounter()
        {
            return this.counter;
        }

        public void RunCalculator()
        {
            Action actionCode;
            string lastInput = "", input;
            int lastAnswer = 0, answer = 0;
            
            do
            {
                input = GetInput();
                actionCode = ValidateInput(input);
                DoAnAction(actionCode, lastAnswer, lastInput, out answer);
                
                // if actionCode = math code, then save answer to lastAnswer
                if (actionCode >= Action.ADD && actionCode <= Action.MODULUS)
                {
                    lastAnswer = answer;
                    lastInput = input;
                }
                
            } while (actionCode != Action.EXIT);


        }

        private void DoAnAction(Action actionCode, int lastAnswer, string lastInput, out int answer)
        {
            answer = 0;
            switch (actionCode)
            {
                case Action.EXIT: // exit or quit
                    Console.WriteLine("Bye!");
                    break;
                case Action.LAST: // last
                    Console.WriteLine(Print("Last answer", lastAnswer));
                    break;
                case Action.LASTQ: // lastq
                    Console.WriteLine(Print("Last expression", lastInput));
                    break;
                case Action.ADD: // addition
                    answer = this.value1 + this.value2;
                    Console.WriteLine(Print("", answer));
                    break;
                case Action.SUBTRACT: // subtraction
                    answer = this.value1 - this.value2;
                    Console.WriteLine(Print("", answer));
                    break;
                case Action.MULTIPLY: // multiplication
                    answer = this.value1 * this.value2;
                    Console.WriteLine(Print("", answer));
                    break;
                case Action.DIVIDE: // division
                    answer = this.value1 / this.value2;
                    Console.WriteLine(Print("", answer));
                    break;
                case Action.MODULUS: // modulus
                    answer = this.value1 % this.value2;
                    Console.WriteLine(Print("", answer));
                    break;
                case Action.CONSTANT_ASSIGN:
                    // assign constant
                    Constants.Add(constantKey, constantValue);
                    Console.WriteLine("  = saved '{0}' as '{1}'", constantKey, constantValue.ToString());
                    break;
                case Action.CONSTANT_LOOKUP:
                    // lookup constant value
                    Console.WriteLine(" = {0}", constantValue);
                    break;
                case Action.CONSTANT_ERROR:
                    // error trying to assign new value to a constant
                    Console.WriteLine("Error! Cannot re-assign constant.");
                    break;
                case Action.CONSTANT_NOTASSIGNED:
                    // error, trying to lookup value which has not been assigned
                    Console.WriteLine("Error! Constant has not been assigned a value;");
                    break;
            }
            
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

        public Action ValidateInput(string currentInput)
        {
            Action actionCode = Action.INVALID; // set the default return value
            
            // string literals to define the patterns of input we are looking for
            String mathPattern = @"(\d+)\s*([-+*/%])\s*(\d+)"; // pattern for a basic math operation
            String keywordPattern = @"\bexit\b|\bquit\b|\blast\b|\blastq\b"; // pattern for entering a keyword
            String constantAssignPattern = @"([a-zA-Z])\s*([=])\s*(\d+)"; // pattern for assigning a constant value
            String constantLookupPattern = @"^\s*([a-zA-Z])\s*$"; // pattern for looking up a pattern that is assigned
            String constantUsePattern1 = @"(\d+)\s*([-+*/%])\s*([a-zA-Z])"; // pattern for using an constant in an expression; i.e., 1 + x
            String constantUsePattern2 = @"([a-zA-Z])\s*([-+*/%])\s*(\d+)"; // pattern for using a constant in an expression; i.e., x + 1

            Match mathMatch, keywordMatch, constantMatch, constantLookupMatch, constantUseMatch1, constantUseMatch2;
            mathMatch = Regex.Match(currentInput, mathPattern);
            keywordMatch = Regex.Match(currentInput, keywordPattern);
            constantMatch = Regex.Match(currentInput, constantAssignPattern);
            constantLookupMatch = Regex.Match(currentInput, constantLookupPattern);
            constantUseMatch1 = Regex.Match(currentInput, constantUsePattern1);
            constantUseMatch2 = Regex.Match(currentInput, constantUsePattern2);

            
            if (keywordMatch.Success)
            {
                string keyword = keywordMatch.Groups[0].Value;
                switch (keyword)
                {
                    case "exit":
                    case "quit":
                        actionCode = Action.EXIT;
                        break;
                    case "last":
                        actionCode = Action.LAST;
                        break;
                    case "lastq":
                        actionCode = Action.LASTQ;
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
                        actionCode = Action.ADD;
                        break;
                    case "-":
                        actionCode = Action.SUBTRACT;
                        break;
                    case "*":
                        actionCode = Action.MULTIPLY;
                        break;
                    case "/":
                        actionCode = Action.DIVIDE;
                        break;
                    case "%":
                        actionCode = Action.MODULUS;
                        break;
                }
            }
            else if (constantMatch.Success)
            {
                this.constantKey = constantMatch.Groups[1].Value;
                if (Constants.ContainsKey(constantKey))
                {   
                    actionCode = Action.CONSTANT_ERROR;
                }
                else
                {
                    this.constantValue = int.Parse(constantMatch.Groups[3].Value);
                    actionCode = Action.CONSTANT_ASSIGN;
                }
                
            }
            else if (constantLookupMatch.Success)
            {
                // check for error, i.e., value not in dictionary
                this.constantKey = constantLookupMatch.Groups[1].Value;
                if (!Constants.ContainsKey(constantKey))
                {
                    actionCode = Action.CONSTANT_NOTASSIGNED;
                }
                else
                {
                    //Console.WriteLine("Inside constantLookup");
                    this.constantValue = Constants[constantKey];
                    actionCode = Action.CONSTANT_LOOKUP;
                }
                
            }
            else if (constantUseMatch1.Success)
            {
                // e.g., 1 + x
                this.constantKey = constantUseMatch1.Groups[3].Value;
                if (!Constants.ContainsKey(constantKey))
                {
                    actionCode = Action.CONSTANT_NOTASSIGNED;
                }
                else
                {
                    this.value1 = int.Parse(constantUseMatch1.Groups[1].Value);
                    this.value2 = Constants[constantKey];
                    switch (constantUseMatch1.Groups[2].Value)
                    {
                        case "+":
                            actionCode = Action.ADD;
                            break;
                        case "-":
                            actionCode = Action.SUBTRACT;
                            break;
                        case "*":
                            actionCode = Action.MULTIPLY;
                            break;
                        case "/":
                            actionCode = Action.DIVIDE;
                            break;
                        case "%":
                            actionCode = Action.MODULUS;
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (constantUseMatch2.Success)
            {
                // e.g., x + 1
                //Console.WriteLine("Inside constantUseMatch2");
                this.constantKey = constantUseMatch2.Groups[1].Value;
                if (!Constants.ContainsKey(constantKey))
                {
                    actionCode = Action.CONSTANT_NOTASSIGNED;
                }
                else
                {
                    this.value2 = int.Parse(constantUseMatch2.Groups[3].Value);
                    this.value1 = Constants[constantKey];
                    switch (constantUseMatch2.Groups[2].Value)
                    {
                        case "+":
                            actionCode = Action.ADD;
                            break;
                        case "-":
                            actionCode = Action.SUBTRACT;
                            break;
                        case "*":
                            actionCode = Action.MULTIPLY;
                            break;
                        case "/":
                            actionCode = Action.DIVIDE;
                            break;
                        case "%":
                            actionCode = Action.MODULUS;
                            break;
                        default:
                            break;
                    }
                }
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