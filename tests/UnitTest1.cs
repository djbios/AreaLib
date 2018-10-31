using System;
using System.Collections.Generic;
using AreaLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCircle()
        {
            var a = AreaHelper.CalculateCircleArea(12);
            Assert.AreEqual(Math.PI * 12 * 12, a);
        }

        [TestMethod]
        public void TestTriangle()
        {
            var a = AreaHelper.CalculateTriangleArea(1,2, Math.Sqrt(5));
            Assert.AreEqual(1, a);
        }

        [TestMethod]
        public void TestPolygon()
        {
            var a = AreaHelper.CalculatePolygonArea(new List<(double, double)>()
            {
                (0,0),
                (0,2),
                (2,0),
            });
            Assert.AreEqual(2, a);
        }
    }
}
