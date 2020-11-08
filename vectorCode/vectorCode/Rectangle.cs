using System;

namespace vectorCode
{
    public class Rectangle : ICloneable
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public Point p3 { get; set; }
        public Point p4 { get; set; }

        public Rectangle(Point _p1, Point _p2, Point _p3, Point _p4)
        {
            p1 = (Point)_p1.Clone();
            p2 = (Point)_p2.Clone();
            p3 = (Point)_p3.Clone();
            p4 = (Point)_p4.Clone();
        }

        public object Clone()
        {
            return new Rectangle(p1, p2, p3, p4);
        }

        public string ToString(string format)
        {
            return p1.ToString(format) + "\n" + p2.ToString(format) + "\n" + p3.ToString(format) + "\n" + p4.ToString(format) + "\n" + p1.ToString(format);
        }
    }
}

