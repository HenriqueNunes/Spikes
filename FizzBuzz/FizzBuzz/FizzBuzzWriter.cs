using System;

namespace FizzBuzz
{
    public class FizzBuzzWriter
    {
        public FizzBuzzWriter()
        {
        }

        public string Write(int a)
        {
            if (a.ToString().Contains("3")) return "lucky";
            var isMultipleOf3 = a % 3 == 0;
            var isMultipleOf5 = a % 5 == 0;
            if (isMultipleOf3 && isMultipleOf5) return "fizzbuzz";
            if (isMultipleOf3) return "fizz";
            if (isMultipleOf5) return "buzz";
            return a.ToString();
        }
    }
}