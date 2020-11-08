using System;

namespace vectorCode
{
    public class Vector : Point, ICloneable
    {
        public Vector(Point p1, Point p2)
        {
            X = p2.X - p1.X;
            Y = p2.Y - p1.Y;
        }

        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Vector(Vector v1)
        {
            this.X = v1.X;
            this.Y = v1.Y;
        }

        public object Clone()
        {
            return new Vector(this);
        }

        /// <summary>
        /// Calculo o tamanho do vetor
        /// </summary>
        /// <returns>Retorna o tamanho do vetor na mesma unidade de medida das cordenadas do mesmo</returns>
        public double size()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        /// <summary>
        /// Calcula o vetor de mesma direção mas de tamanho unitário.
        /// </summary>
        /// <returns>Vetor unitário</returns>
        public Vector unitario()
        {
            return this / size();
        }

        /// <summary>
        /// Sobrecarga do Operador /
        /// </summary>
        /// <param name="a">Vetor</param>
        /// <param name="b">Vetor</param>
        /// <returns>Vetor resultante</returns>
        public static Vector operator /(Vector a, double b) => new Vector(a.X / b, a.Y / b);

        /// <summary>
        /// Sborecarga do Operador *
        /// </summary>
        /// <param name="a">Vetor</param>
        /// <param name="b">Vetor</param>
        /// <returns>Vetor resultante</returns>
        public static Vector operator *(Vector a, double b) => new Vector(a.X * b, a.Y * b);
    }
}

