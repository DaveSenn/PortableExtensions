﻿#region Using

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class EnumExTest
    {
        [TestCase]
        public void GetValueAndStringValueTestCase()
        {
            var actual = EnumEx.GetValueAndStringValue<DayOfWeek>().ToList();
            Assert.AreEqual( 7, actual.Count );

            Assert.AreEqual( "Sunday", actual[0].Value );
            Assert.AreEqual( DayOfWeek.Sunday, actual[0].Key );

            Assert.AreEqual( "Monday", actual[1].Value );
            Assert.AreEqual( DayOfWeek.Monday, actual[1].Key );

            Assert.AreEqual( "Tuesday", actual[2].Value );
            Assert.AreEqual( DayOfWeek.Tuesday, actual[2].Key );

            Assert.AreEqual( "Wednesday", actual[3].Value );
            Assert.AreEqual( DayOfWeek.Wednesday, actual[3].Key );

            Assert.AreEqual( "Thursday", actual[4].Value );
            Assert.AreEqual( DayOfWeek.Thursday, actual[4].Key );

            Assert.AreEqual( "Friday", actual[5].Value );
            Assert.AreEqual( DayOfWeek.Friday, actual[5].Key );

            Assert.AreEqual( "Saturday", actual[6].Value );
            Assert.AreEqual( DayOfWeek.Saturday, actual[6].Key );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentException ) )]
        public void GetValueAndStringValueTestCaseArgumentExceptionCheck()
        {
            EnumEx.GetValueAndStringValue<Int32>().ToList();
        }
    }
}