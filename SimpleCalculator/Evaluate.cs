using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Evaluate
    {
        private int val1, val2;
        private string operation;

        public Evaluate(int val1, string operation, int val2)
        {
            this.val1 = val1;
            this.val2 = val2;
            this.operation = operation;
        }

        public int ReturnAnswer()
        {
            int answer = 0;
            switch (this.operation)
            {
                case "+":
                    answer = this.val1 + this.val2;
                    break;
                case "-":
                    answer = this.val1 - this.val2;
                    break;
                case "*":
                    answer = this.val1 * this.val2;
                    break;
                case "/":
                    answer = this.val1 / this.val2;
                    break;
                case "%":
                    answer = this.val1 % this.val2;
                    break;
                default:
                    break;
            }
            return answer;
        }
    }
}
