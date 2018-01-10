using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonWayWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonWayWS.Tests
{
    [TestClass()]
    public class FibonacciTests
    {
        [TestMethod()]
        public void FibonacciTest()
        {
            LemonWayWS ws = new LemonWayWS();
            Assert.AreEqual("1", ws.Fibonacci(1, false));
            Assert.AreEqual("1", ws.Fibonacci(2, false));
            Assert.AreEqual("2", ws.Fibonacci(3, false));
            Assert.AreEqual("3", ws.Fibonacci(4, false));
            Assert.AreEqual("5", ws.Fibonacci(5, false));
            Assert.AreEqual("8", ws.Fibonacci(6, false));
            Assert.AreEqual("354224848179261915075", ws.Fibonacci(100, false));
            Assert.AreEqual("-1", ws.Fibonacci(-101, false));
            Assert.AreEqual("-1", ws.Fibonacci(1000, false));
        }


    }
}
