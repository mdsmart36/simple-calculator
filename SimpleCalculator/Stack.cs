using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class Stack
    {
        
        public static int lastAnswer = 0;
        public static string lastExpression = "";
        public static Dictionary<string, int> Constants = new Dictionary<string, int>();

        public static void PutAnswerOnStack(int answer)
        {
            lastAnswer = answer;
        }

        public static int GetAnswerFromStack()
        {
            return lastAnswer;
        }

        public static void PutExpressionOnStack(string input)
        {
            lastExpression = input;
        }

        public static string GetExpressionFromStack()
        {
            return lastExpression;
        }

        public static bool AddConstant(string key, int value)
        {
            if (!ConstantIsAssigned(key))
            {
                Constants.Add(key, value);
                return true;
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public static bool ConstantIsAssigned(string key)
        {
            if (Constants.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public static int ReturnConstantValue(string key)
        {
            try
            {
                return Constants[key];
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            
        }
    }
}
