using System;

namespace vectorCode
{

    public class Point : ICloneable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point(Point p1)
        {
            this.X = p1.X;
            this.Y = p1.Y;
        }

        public Point()
        {

        }

        public object Clone()
        {
            return new Point(this);
        }

        public string ToString(string format)
        {
            return format.Replace("{X}", X.ToString()).Replace("{Y}", Y.ToString());
        }

        /// <summary>
        /// Sobrecar do Operador + para adição de vetor a um ponto.
        /// </summary>
        /// <param name="a">Ponto</param>
        /// <param name="b">Vetor</param>
        /// <returns>Ponto com a translação dada pelo vetor</returns>
        public static Point operator +(Point a, Vector b) => new Point(a.X + b.X, a.Y + b.Y);
    }

}

