using System;
using NUnit.Framework;

namespace Policeman.Tests
{
    public class GuardTests
    {
        private class TestClass{}

        // This is used to test a null class...
        #pragma warning disable 649
        TestClass _testClassNull;
        #pragma warning restore 649

        private readonly TestClass _testClassOk = new TestClass();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArgumentNullGuard()
        {
            Guard.ArgumentNotNull(_testClassNull, "Expecting Exception");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArgumentNotNullOrEmptyIsNull()
        {
            Guard.ArgumentNotNullOrEmpty(null, "Expecting Exception");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArgumentNotNullOrEmptyIsEmpty()
        {
            Guard.ArgumentNotNullOrEmpty("", "Expecting Exception");
        }

        [Test]
        public void TestArguementNullGuardWithObject()
        {
            Guard.ArgumentNotNull(_testClassOk, "Expecting No Exception");
        }

        [Test]
        public void TestArgumentNotNullOrEmptyNoException()
        {
            Guard.ArgumentNotNullOrEmpty("Good", "Expecting Exception");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRequiresArgumentWithArgumentNullException()
        {
            Guard.Requires<ArgumentNullException>("Expecting Exception of type ArgumentNullException", false);
        }

        [Test]
        public void TestRequiresArgumentWithArgumentNullOk()
        {
            Guard.Requires<ArgumentNullException>("Expecting Exception of type ArgumentNullException", true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRequiresArgumentWithArgumentException()
        {
            Guard.Requires<ArgumentException>("Expecting Exception of type ArgumentNullException", false);
        }

        [Test]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestRequiresArgumentWithArithmeticException()
        {
            Guard.Requires<ArithmeticException>("Expecting Exception of type ArithmeticException", 4 + 4 == 7);
        }

        [Test]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestRequiresArgumentWithArithmeticExceptionNoText()
        {
            Guard.Requires<ArithmeticException>(4 + 4 == 7);
        }

        [Test]
        [ExpectedException(typeof(PolicemanException))]
        public void TestRequiresArgumentWithPolicemanExceptionNoText()
        {
            Guard.Requires<PolicemanException>(4 + 4 == 7);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentGreaterOrEqualThanException()
        {
            Guard.ArgumentGreaterOrEqualThan(4,3,"noParam");
        }

        [Test]
        public void TestArgumentGreaterOrEqualThanNoException()
        {
            Guard.ArgumentGreaterOrEqualThan(4, 6, "noParam");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentLowerOrEqualThanException()
        {
            Guard.ArgumentLowerOrEqualThan(4, 7, "noParam");
        }

        [Test]
        public void TestArgumentLowerOrEqualThanNoException()
        {
            Guard.ArgumentLowerOrEqualThan(4, 4, "noParam");
        }
    }
}
