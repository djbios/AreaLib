using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaLib
{
    public class Figure
    {
        private List<(double X, double Y)> points;

        public Figure(List<(double X, double Y)> points)
        {
            this.points = points;
        }

        public  double CalculateArea()
        {
            points.Add(points[0]);
            return Math.Abs(points.Take(points.Count - 1)
                       .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
                       .Sum() / 2);
        }
    };

    public class Circle:Figure
    {
        double radius;

        public Circle(double radius): base( new List<(double,double)>())
        {
            this.radius = radius;
        }

        public new double CalculateArea()
        {    
            return Math.PI * Math.Pow(radius, 2);  
        }
    }

    public class Triangle : Figure
    {
        double a;
        double b;
        double c;

        public Triangle(List<(double,double)> points) : base(points) // because a b c can be unknown
        { }

        public Triangle(double a, double b, double c) : base(new List<(double, double)>())
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public new double CalculateArea()
        {
            var p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

    }

    public static class AreaHelper
    {
        public static double CalculateCircleArea(double radius)
        {
            var c = new Circle(radius);
            return c.CalculateArea();
        }

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            var t = new Triangle(a, b, c);
            return t.CalculateArea();
        }

        public static double CalculatePolygonArea(List<(double, double)> points)
        {
            var f = new Figure(points);
            return f.CalculateArea();
        }
    };
    
}
