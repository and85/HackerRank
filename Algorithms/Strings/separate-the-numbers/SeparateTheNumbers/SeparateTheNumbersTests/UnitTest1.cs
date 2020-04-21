using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeparateTheNumbersTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RunTest(true, "1234");
        }

        [TestMethod]
        public void TestMethod2()
        {
            RunTest(true, "91011");
        }

        [TestMethod]
        public void TestMethod3()
        {
            RunTest(true, "99100");
        }

        [TestMethod]
        public void TestMethod4()
        {
            RunTest(false, "101103");
        }

        [TestMethod]
        public void TestMethod5()
        {
            RunTest(false, "010203");
        }

        [TestMethod]
        public void TestMethod6()
        {
            RunTest(false, "13");
        }

        [TestMethod]
        public void TestMethod7()
        {
            RunTest(false, "1");
        }

        private void RunTest(bool expected, string input)
        {
            bool actual = Solution.IsBeautiful(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
