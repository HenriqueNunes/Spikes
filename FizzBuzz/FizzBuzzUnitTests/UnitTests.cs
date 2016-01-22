using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FizzBuzz;
using System.Collections.Generic;

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

        [TestMethod]
        public void FizzBuzzCounters()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            Assert.IsNotNull(fizzBuzzProcessor.fizzCounter);
            Assert.IsInstanceOfType(fizzBuzzProcessor.fizzCounter, typeof(int));

            Assert.IsTrue(fizzBuzzProcessor.fizzCounter == 0
                            && fizzBuzzProcessor.buzzCounter == 0
                            && fizzBuzzProcessor.fizzbuzzCounter == 0
                            && fizzBuzzProcessor.luckyCounter == 0
                            && fizzBuzzProcessor.integerCounter == 0);

            fizzBuzzProcessor.Write(1);
            Assert.AreEqual(1, fizzBuzzProcessor.integerCounter);
            fizzBuzzProcessor.Write(5);

            Assert.IsTrue(fizzBuzzProcessor.fizzCounter == 0
                && fizzBuzzProcessor.buzzCounter == 1
                && fizzBuzzProcessor.fizzbuzzCounter == 0
                && fizzBuzzProcessor.luckyCounter == 0
                && fizzBuzzProcessor.integerCounter == 1);

        }
        [TestMethod]
        public void FizzBuzzluckyCounter()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            Assert.IsTrue(fizzBuzzProcessor.fizzCounter == 0
                            && fizzBuzzProcessor.buzzCounter == 0
                            && fizzBuzzProcessor.fizzbuzzCounter == 0
                            && fizzBuzzProcessor.luckyCounter == 0
                            && fizzBuzzProcessor.integerCounter == 0);

            fizzBuzzProcessor.Write(333);

            Assert.IsTrue(fizzBuzzProcessor.fizzCounter == 0
                          && fizzBuzzProcessor.buzzCounter == 0
                          && fizzBuzzProcessor.fizzbuzzCounter == 0
                          && fizzBuzzProcessor.luckyCounter == 1
                          && fizzBuzzProcessor.integerCounter == 0);
        }

        [TestMethod]
        public void FizzBuzz1through20CounterTest()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            Enumerable.Range(1, 20)
               .Select(a => fizzBuzzProcessor.Write(a)).ToList();

            if (fizzBuzzProcessor.fizzCounter != 4
                  || fizzBuzzProcessor.buzzCounter != 3
                  || fizzBuzzProcessor.fizzbuzzCounter != 1
                  || fizzBuzzProcessor.luckyCounter != 2
                  || fizzBuzzProcessor.integerCounter != 10)
                Assert.Fail("Generated Counter values are not the expected value.");

        }

        [TestMethod]
        public void FizzBuzzluckyResetCounters()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            Enumerable.Range(1, 100).Select(a => fizzBuzzProcessor.Write(a)).ToList();

            Assert.IsTrue(fizzBuzzProcessor.fizzCounter != 0
                            && fizzBuzzProcessor.buzzCounter != 0
                            && fizzBuzzProcessor.fizzbuzzCounter != 0
                            && fizzBuzzProcessor.luckyCounter != 0
                            && fizzBuzzProcessor.integerCounter != 0);

            fizzBuzzProcessor.ResetCounters();

            if (fizzBuzzProcessor.fizzCounter != 0
                          || fizzBuzzProcessor.buzzCounter != 0
                          || fizzBuzzProcessor.fizzbuzzCounter != 0
                          || fizzBuzzProcessor.luckyCounter != 0
                          || fizzBuzzProcessor.integerCounter != 0)
                Assert.Fail("Failed to reset the counters");
        }



        [TestMethod]
        public void FizzBuzzWriteReport()
        {
            var fizzBuzzProcessor = new FizzBuzzWriter();

            Enumerable.Range(1, 20)
               .Select(a => fizzBuzzProcessor.Write(a)).ToList();

            var expectedReport = "fizz: 4\nbuzz: 3\nfizzbuzz: 1\nlucky: 2\ninteger: 10\n";
            string report = fizzBuzzProcessor.GenerateReport();

            Assert.AreEqual(expectedReport, report);

        }


    }
}
