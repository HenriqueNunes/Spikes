using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FizzBuzz;

namespace FizzBuzzUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void FizzBuzzTestBasic()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            var expectedResult = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            var actualResult =
                Enumerable.Range(1, 20)
                    .Select(a => fizzBuzzProcessor.Write(a))
                    .Aggregate((a, b) => a + " " + b);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void FizzBuzzNotMultiplesof3or5()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            var notMultiplesOf3or5 = new[] { 1, 2, 4, 7, 8, 11, 88 };
            foreach (var item in notMultiplesOf3or5)
                Assert.AreEqual(item.ToString(), fizzBuzzProcessor.Write(item));
        }

        [TestMethod]
        public void FizzBuzzMultiplesof3and5()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            var multiplesOf3and5 = new[] { 15, 45, 60, 75, 90 };
            foreach (var item in multiplesOf3and5)
                Assert.AreEqual("fizzbuzz", fizzBuzzProcessor.Write(item));
        }

        [TestMethod]
        public void FizzBuzzMultiplesof5()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            var multiplesOf5only = new[] { 5, 10, 20, 25 };
            foreach (var item in multiplesOf5only)
                Assert.AreEqual("buzz", fizzBuzzProcessor.Write(item));
        }

        [TestMethod]
        public void FizzBuzzMultiplesof3()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            var multiplesOf3only = new[] { 6, 9, 12, 54 };
            foreach (var item in multiplesOf3only)
                Assert.AreEqual("fizz", fizzBuzzProcessor.Write(item));
        }

        [TestMethod]
        public void FizzBuzzNumberContains3()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();
            Assert.AreEqual("lucky", fizzBuzzProcessor.Write(3));
            Assert.AreEqual("lucky", fizzBuzzProcessor.Write(1243));
            Assert.AreEqual("lucky", fizzBuzzProcessor.Write(243556));
            Assert.AreEqual("lucky", fizzBuzzProcessor.Write(333));
            Assert.AreEqual("lucky", fizzBuzzProcessor.Write(2434353));
            Assert.AreNotEqual("lucky", fizzBuzzProcessor.Write(124567890));
        }


    }
}
