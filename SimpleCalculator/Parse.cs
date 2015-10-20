using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Parse
    {
        private string textToParse { get; set; }

        public Parse()
        {

        }
        public Parse(string text)
        {
            this.textToParse = text.Trim();
            this.textToParse = Regex.Replace(this.textToParse, @"\s+", " ");
        }

        public void SetTextToParse(string input)
        {
            this.textToParse = input.Trim();
            this.textToParse = Regex.Replace(this.textToParse, @"\s+", " ");
        }

        public bool IsKeywordEntered()
        {            
            string firstValue = this.textToParse.Split(' ')[0].ToLower();            
            return (firstValue == "last" || firstValue == "lastq") ? true : false;                        
        }

        public int GetFirstValue()
        {
            string firstValue = this.textToParse.Split(' ')[0];
            try
            {
                
                return int.Parse(firstValue);
            }
            // if the second value is not an integer, throw exception
            catch (FormatException)
            {
                throw;
            }            
            
        }

        public int GetSecondValue()
        {
            try
            {
                return int.Parse(this.textToParse.Split(' ')[2]);
            }
            // if the second value is not an integer, throw exception
            catch (FormatException)
            {                
                throw;
            }
        }

        public string GetOperation()
        {
            string validOperations = "+-*/%";
            string valueToTest = this.textToParse.Split(' ')[1];

            if (validOperations.Contains(valueToTest))
            {
                return valueToTest;
            }
            else
            {
                throw new FormatException();
            }
            
        }

        public string GetKeyword()
        {
            string keyword = this.textToParse.Split(' ')[0].ToLower();
            return keyword;
        }
    }
}
