using TestExecuteBatchRunner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyRegExpTests
{
    
    
    /// <summary>
    ///This is a test class for MyRegeExpTest and is intended
    ///to contain all MyRegeExpTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MyRegeExpTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GenerateRegExpForNumericRange
        ///</summary>
        [TestMethod()]
        public void GenerateRegExpForNumericRangeTest1()
        {
            int min = 13; 
            int max = 57; 
            string expected = "4[0-9]|3[0-9]|2[0-9]|1[3-9]|5[0-7]"; 
            string actual;
            actual = MyRegeExp.GenerateRegExpForNumericRange(min, max);
            Assert.AreEqual(expected, actual);
            for (int i = 0; i < 100; i++)
            {
                if (min <= i && i <= max)
                {
                    Assert.AreEqual(true,System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
                else
                {
                    Assert.AreEqual(false, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
            }
        }

        /// <summary>
        ///A test for GenerateRegExpForNumericRange
        ///</summary>
        [TestMethod()]
        public void GenerateRegExpForNumericRangeTest2()
        {
            int min = 1983;
            int max = 2011;
            string expected = "200[0-9]|199[0-9]|198[3-9]|201[0-1]";
            string actual = "";
            actual = MyRegeExp.GenerateRegExpForNumericRange(min, max);
            Assert.AreEqual(expected, actual);
            for (int i = 1500; i < 2500; i++)
            {
                if (min <= i && i <= max)
                {
                    Assert.AreEqual(true, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
                else
                {
                    Assert.AreEqual(false, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
            }
        }

        /// <summary>
        ///A test for GenerateRegExpForNumericRange
        ///</summary>
        [TestMethod()]
        public void GenerateRegExpForNumericRangeTest3()
        {
            int min = 99;
            int max = 112;
            string expected = "99|10[0-9]|11[0-2]";
            string actual = "";
            actual = MyRegeExp.GenerateRegExpForNumericRange(min, max);
            Assert.AreEqual(expected, actual);
            for (int i = 80; i < 150; i++)
            {
                if (min <= i && i <= max)
                {
                    Assert.AreEqual(true, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
                else
                {
                    Assert.AreEqual(false, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
            }
        }

        /// <summary>
        ///A test for GenerateRegExpForNumericRange
        ///</summary>
        [TestMethod()]
        public void GenerateRegExpForNumericRangeTest4()
        {
            int min = 8800;
            int max = 9000;
            string expected = "89[0-9]{2}|888[0-9]|887[0-9]|886[0-9]|885[0-9]|884[0-9]|883[0-9]|882[0-9]|881[0-9]|880[0-9]|889[0-9]|9000";
            string actual = "";
            actual = MyRegeExp.GenerateRegExpForNumericRange(min, max);
            Assert.AreEqual(expected, actual);
            for (int i = 8700; i < 9100; i++)
            {
                if (min <= i && i <= max)
                {
                    Assert.AreEqual(true, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
                else
                {
                    Assert.AreEqual(false, System.Text.RegularExpressions.Regex.IsMatch(i.ToString(), actual));
                }
            }
        }
    }
}
