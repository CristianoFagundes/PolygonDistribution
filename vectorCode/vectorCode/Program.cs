using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vectorCode
{
    partial class Program
    {
        static List<Point> SubDivisoes(double Division, double Border, Reta reta)
        {
            var aux = new List<Point>();
            var bordaSize = (Division + 1) * Border;
            var utilSize = reta.toVector().size() - bordaSize;
            var tambButton = utilSize / Division;

            for (double i = 0; i < Division; i++)
            {
                aux.Add(reta.startPoint + reta.toVector().unitario() * (Border * (i + 1) + (tambButton) * i));
                aux.Add(reta.startPoint + reta.toVector().unitario() * (Border * (i + 1) + (tambButton) * (i + 1)));
            }
            return aux;
        }

        static void Main(string[] args)
        {

            //Configurações iniciais
            var Total = new Rectangle(new Point(2, 2), new Point(10, 1), new Point(11, 11), new Point(1, 10));
            double xDivision = 3;
            double yDivision = 2;
            double borda = 0.5;

            Point atual = new Point(borda, borda);
            var divP1_P2 = SubDivisoes(xDivision, borda, new Reta(Total.p1, Total.p2));
            var divP2_P3 = SubDivisoes(yDivision, borda, new Reta(Total.p2, Total.p3));
            var divP3_P4 = SubDivisoes(xDivision, borda, new Reta(Total.p4, Total.p3));
            var divP4_P1 = SubDivisoes(yDivision, borda, new Reta(Total.p1, Total.p4));

            List<Reta> hReta = new List<Reta>();
            List<Reta> vReta = new List<Reta>();

            for (int i = 0; i < xDivision; i++)
            {
                hReta.Add(new Reta(divP1_P2[i * 2], divP3_P4[i * 2]));
                hReta.Add(new Reta(divP1_P2[(i * 2) + 1], divP3_P4[(i * 2) + 1]));
            }

            for (int i = 0; i < yDivision; i++)
            {
                vReta.Add(new Reta(divP2_P3[i * 2], divP4_P1[i * 2]));
                vReta.Add(new Reta(divP2_P3[(i * 2) + 1], divP4_P1[(i * 2) + 1]));
            }

            var Parcelas = new List<Rectangle>();

            for (int y_i = 0; y_i < yDivision; y_i++)
            {
                for (int x_i = 0; x_i < xDivision; x_i++)
                {
                    var p1 = hReta[x_i * 2].Intersect(vReta[y_i * 2]);
                    var p2 = hReta[(x_i * 2) +1].Intersect(vReta[y_i * 2]);
                    var p4 = hReta[x_i * 2].Intersect(vReta[(y_i * 2) + 1]);
                    var p3 = hReta[(x_i * 2) + 1].Intersect(vReta[(y_i * 2) + 1]);

                    Parcelas.Add(new Rectangle(p1, p2, p3, p4));
                }
            }

            Console.WriteLine("Descricao;X;Y");
            Console.WriteLine(Total.ToString("Experimento;{X};{Y}"));
            for (int i = 0; i < Parcelas.Count; i++)
            {
                Console.Write(Parcelas[i].ToString("Parcela" + i.ToString() + ";{X};{Y}")+"\n");
            }

            Console.ReadLine();
        }
    }
}

