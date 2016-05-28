using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guarder.Tests
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A null value was passed")]
        public void Exception_With_Null_Value()
        {
            Guard.IsNotNull(null, "tmpObj");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A empty string was passed")]
        public void Exception_With_Empty_Value()
        {
            Guard.IsNotNullOrEmpty(string.Empty, "tmpObj");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A greater than int value did not raise an exception")]
        public void Exception_With_Greater_Value_Int()
        {
            Guard.LessThan(32, 12, "numberInt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A greater than double value did not raise an exception")]
        public void Exception_With_Greater_Value_Double()
        {
            Guard.LessThan(32.2, 12.7, "numberDbl");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A out of range int value did not raise an exception")]
        public void Exception_With_Value_Out_Of_Range_Int()
        {
            Guard.ValueIsBetween(51, 25, 50, "numberInt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value entered is not a number")]
        public void Exception_With_Non_Numeric()
        {
            Guard.IsNumeric("asdfasdfsadf", "number");
        }


        [TestMethod]
        public void ValidNumericString()
        {
            Guard.IsNumeric("1,871,001,270.00252", "number");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A null value was passed")]
        public void Exception_With_Any_Null_Value()
        {
            Guard.NotAnyNull(new Guard.GuardObject("string","string"),new Guard.GuardObject(21,"int"),new Guard.GuardObject(null,"Exception value"));
        }
    }
}
