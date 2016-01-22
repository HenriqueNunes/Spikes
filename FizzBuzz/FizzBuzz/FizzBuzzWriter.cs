using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzWriter
    {

        public FizzBuzzWriter()
        {
        }

        public int fizzCounter { get; private set; }
        public int buzzCounter { get; private set; }
        public int fizzbuzzCounter { get; private set; }
        public int luckyCounter { get; private set; }
        public int integerCounter { get; private set; }

        public string Write(int a)
        {
            if (a.ToString().Contains("3"))
            {
                luckyCounter++;
                return "lucky";
            };
            var isMultipleOf3 = a % 3 == 0;
            var isMultipleOf5 = a % 5 == 0;
            if (isMultipleOf3 && isMultipleOf5)
            {
                fizzbuzzCounter++;
                return "fizzbuzz";
            }
            if (isMultipleOf3)
            {
                fizzCounter++;
                return "fizz";
            }
            if (isMultipleOf5)
            {
                buzzCounter++;
                return "buzz";
            }
            integerCounter++;
            return a.ToString();
        }

        public void ResetCounters()
        {
            fizzCounter = 0;
            buzzCounter = 0;
            fizzbuzzCounter = 0;
            luckyCounter = 0;
            integerCounter = 0;
        }

        public string GenerateReport()
        {
            var outputText = new StringBuilder();

            outputText.AppendFormat("fizz: {0}\n", fizzCounter);
            outputText.AppendFormat("buzz: {0}\n", buzzCounter);
            outputText.AppendFormat("fizzbuzz: {0}\n", fizzbuzzCounter);
            outputText.AppendFormat("lucky: {0}\n", luckyCounter);
            outputText.AppendFormat("integer: {0}\n", integerCounter);

            return outputText.ToString();
        }
    }
}