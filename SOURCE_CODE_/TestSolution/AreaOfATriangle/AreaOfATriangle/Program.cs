using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfATriangle
{
    public class Triangle
    {
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            if (CheckRight(a, b, c) || CheckRight(c, a, b) || CheckRight(b, c, a))
            {
                Console.WriteLine("Right triangle was created! Eps = " + Eps);
            }
            else
            {
                Console.WriteLine("The triangle is not rectangular! Eps = " + Eps);
            }

        }
        public double CalculateArea()
        {
            if (IsRect == true)
            {
                return a * b * 0.5;
            }
            else
            {
                //throw new ArgumentOutOfRangeException("I can't calculate the area");
                Console.WriteLine("I can't calculate the area");
                return 0;
            }
        }
        private bool CheckRight(double cat1, double cat2, double gyp)
        {
            if (Math.Abs(Math.Sqrt(cat1 * cat1 + cat2 * cat2) - gyp) < Eps&&cat1>0&&cat2>0&&gyp>0)
            {
                this.a = cat1;
                this.b = cat2;
                this.c = gyp;
                IsRect = true;      
            }
            else
            {
                IsRect = false;
            }

            return IsRect;
        }

        private double a;
        private double b;
        private double c;
        private bool IsRect;
        private static double Eps = 0.1;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(-2.9, -4.1, 5);
            //Triangle triangle = new Triangle(2.9, 4.1, 5);
            Console.WriteLine(triangle.CalculateArea());
            Console.ReadKey();
        }
    }
}
