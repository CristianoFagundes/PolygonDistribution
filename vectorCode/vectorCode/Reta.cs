namespace vectorCode
{
    public class Reta
    {
        public Point startPoint { get; set; }

        public Point endPoint { get; set; }

        public Reta(Point start, Point end)
        {
            startPoint = start;
            endPoint = end;
        }

        /// <summary>
        /// Cacula o Vetor que da força e direção ao seguimento de reta
        /// </summary>
        /// <returns>Vetor</returns>
        public Vector toVector()
        {
            return new Vector(startPoint, endPoint);
        }

        /// <summary>
        /// Calculo de intersecção de retas dados 2 pontos para cada reta. Metodo: Determinante
        /// https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
        /// </summary>
        /// <param name="r">Segunda reta para calculo de intersecção</param>
        /// <returns>Ponto de intersecção das retas</returns>
        public Point Intersect(Reta r)
        {
            var x1 = this.startPoint.X;
            var y1 = this.startPoint.Y;
            var x2 = this.endPoint.X;
            var y2 = this.endPoint.Y;

            var x3 = r.startPoint.X;
            var y3 = r.startPoint.Y;
            var x4 = r.endPoint.X;
            var y4 = r.endPoint.Y;

            return new Point(
                ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / ((x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4))
                ,
                ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / ((x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4))
                );
        }
    }
}

