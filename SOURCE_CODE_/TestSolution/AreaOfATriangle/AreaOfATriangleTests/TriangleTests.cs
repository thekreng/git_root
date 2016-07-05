using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaOfATriangle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfATriangle.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void CalculateArea_WithNormalTestData()
        {
            // arrange
            double a = 2.9;
            double b = 4.1;
            double c = 5;
            double expected = 5.9;
            Triangle triangle = new Triangle(a,b,c);

            // act
            double actual = triangle.CalculateArea();

            // assert
           
            Assert.AreEqual(expected, actual, 0.1, "Triangle area not calculate correctly");
            


            //Assert.Fail();
        }

        [TestMethod()]
        public void CalculateArea_WithNegativeTestData()
        {
            // arrange
            double a = -2;
            double b = -2;
            double c = 5;
            double expected = 0;
            Triangle triangle = new Triangle(a, b, c);

            // act
            double actual = triangle.CalculateArea();

            // assert

            Assert.AreEqual(expected, actual, 0.1, "Triangle area not calculate correctly");



            //Assert.Fail();
        }

        [TestMethod()]
        public void CalculateArea_WithNotSupportedTestData()
        {
            // arrange
            double a = 2;
            double b = 2;
            double c = 5;
            double expected = 0;
            Triangle triangle = new Triangle(a, b, c);

            // act
            double actual = triangle.CalculateArea();

            // assert

            Assert.AreEqual(expected, actual, 0.1, "Triangle area not calculate correctly");



            //Assert.Fail();
        }
        
  
    }
}