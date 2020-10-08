using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace del
{
    class Name
    {
        public static int Sum(int x, int y)
        {
            return x + y;
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var actual = Name.Sum(2, 3);
            var expected = 5;

            Assert.AreEqual(expected, actual);
        }
    }
}