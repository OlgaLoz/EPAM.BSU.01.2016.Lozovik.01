using System;
using static NewtonMethod.Newton;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewtonMethod.Tests
{
    [TestClass]
    public class NewtonTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_NegativeRower_ReturnedException()
        {
            Root(78, -3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_AccuracyLessThanZero_ReturnedException()
        {
            Root(78, 15, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_NegativeNumberEvenPower_ReturnedException()
        {
            Root(-98, 6);
        }

        [TestMethod]
        public void Root_NumberEqualsToZero_ReturnedZero()
        {
            double arrangeResult = 0;
            double actResult = Root(0, 852);
            Assert.AreEqual(arrangeResult, actResult);
        }

        [TestMethod]
        public void Root_SqrtOf64_Returned8()
        {
            double arrangeResult = 8;
            double actResult = Root(64, 2);
            Assert.AreEqual(arrangeResult, actResult);
		}

        [TestMethod]
        public void Root_CubeRootOfMinus64_ReturnedMinus4()
        {
            double arrangeResult = -4;
            double actResult = Root(-64, 3);
            Assert.AreEqual(arrangeResult, actResult);
		}

    }
}
