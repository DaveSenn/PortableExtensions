﻿#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void GetAfterTestCase()
        {
            var actual = "test test1".GetAfter("test");
            Assert.AreEqual(" test1", actual);

            actual = "test test1".GetAfter("test", 2);
            Assert.AreEqual("1", actual);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetAfterArgumentOutOfRangeTestCase()
        {
            "test test1".GetAfter("test", 20);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAfterTestCaseNullCheck()
        {
            StringEx.GetAfter(null, "test");
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAfterTestCaseNullCheck1()
        {
            "".GetAfter(null);
        }

        [TestCase]
        public void GetAfterTestCase1()
        {
            var actual = "test test1".GetAfter("test", 0, 10);
            Assert.AreEqual(" test1", actual);

            actual = "test test1".GetAfter("test", 2, 8);
            Assert.AreEqual("1", actual);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetAfterArgumentOutOfRangeTestCase1()
        {
            "test test1".GetAfter("test", 4, 10);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetAfterArgumentOutOfRangeTestCase2()
        {
            "test test1".GetAfter("test", 20, 2);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAfterTestCase1NullCheck()
        {
            StringEx.GetAfter(null, "", 1, 1);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAfterTestCase1NullCheck1()
        {
            "".GetAfter(null, 1, 1);
        }

        [TestCase]
        public void GetAfterOverloadTestCase()
        {
            var actual = "test test1".GetAfter('s');
            Assert.AreEqual("t test1", actual);

            actual = "test test1".GetAfter("t", 5);
            Assert.AreEqual("est1", actual);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetAfterOverloadArgumentOutOfRangeTestCase()
        {
            "test test1".GetAfter('t', 20);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAfterOverloadTestCaseNullCheck()
        {
            StringEx.GetAfter(null, 't');
        }

        [TestCase]
        public void GetAfterOverloadTestCase1()
        {
            var actual = "test test1".GetAfter('e', 0, 6);
            Assert.AreEqual("st t", actual);

            actual = "test test1".GetAfter('t', 2, 8);
            Assert.AreEqual(" test1", actual);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetAfteOverloadrArgumentOutOfRangeTestCase1()
        {
            "test test1".GetAfter('t', 4, 10);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void GetAfterOverloadArgumentOutOfRangeTestCase2()
        {
            "test test1".GetAfter('t', 20, 2);
        }

        [TestCase]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAfterOverloadTestCase1NullCheck()
        {
            StringEx.GetAfter(null, 't', 1, 1);
        }
    }
}