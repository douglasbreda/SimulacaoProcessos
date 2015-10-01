using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace SimulacaoProcessos
{
    public class CalcularDistribuicao
    {
        #region [Atributos]
        #endregion Fim [Atributos]

        #region [Métodos]
        public double DistribuicaoUniforme(double min, double max)
        {
            List<VariaveisDistribuicao> probabilidades = calculaUniforme(min, max);
            Random rand = new Random();
            double probAcum = probabilidades[0].Probabilidade;
            double numero = rand.Next(1, 100);

            for (int i = 0; i < probabilidades.Count; i++)
            {
                if (numero < probAcum)
                    return probabilidades[i].Numero;
                probAcum = probAcum + probabilidades[i + 1].Probabilidade;
            }
            return probabilidades[probabilidades.Count - 1].Numero;
        }
        public List<VariaveisDistribuicao> calculaUniforme(double a, double b)
        {
            List<VariaveisDistribuicao> variaveis = new List<VariaveisDistribuicao>();
            VariaveisDistribuicao v;
            double x;

            for (x = a; x < b + 1; x++)
            {
                v = new VariaveisDistribuicao();
                v.Numero = x;
                v.Probabilidade = 100 / (b - a + 1);
                variaveis.Add(v);
            }

            return variaveis;
        }

        public double DistribuicaoNormal(double media, double desvio)
        {
            List<VariaveisDistribuicao> probabilidades = calculaNormal(media, desvio);
            Random rand = new Random();
            double probAcum = probabilidades[0].Probabilidade;
            double numero = 0;
            double total = 0;

            for (int i = 0; i < probabilidades.Count; i++)
            {
                total = probabilidades[i].Probabilidade + total;
            }
            numero = rand.Next(1, (int)total + 1);

            for (int i = 0; i < probabilidades.Count; i++)
            {
                if (numero < probAcum)
                    return probabilidades[i].Numero;
                probAcum = probAcum + probabilidades[i + 1].Probabilidade;
            }
            return probabilidades[probabilidades.Count - 1].Numero;
        }
        public List<VariaveisDistribuicao> calculaNormal(double u, double o)
        {
            List<VariaveisDistribuicao> variaveis = new List<VariaveisDistribuicao>();
            VariaveisDistribuicao v;
            int min = (int)(u - o);
            int max = (int)(u + o);
            double exp;
            double x;

            for (x = min; x < max + 1; x++)
            {
                v = new VariaveisDistribuicao();
                exp = (Math.Pow((x - u), 2) / (2 * o * o)) * -1;
                v.Numero = x;
                v.Probabilidade = ((1 / Math.Sqrt(2 * Math.PI * o * o)) * (Math.Pow(Math.E, exp))) * 100;
                variaveis.Add(v);
            }

            return variaveis;
        }

        public double DistribuicaoExponencial(double min, double max, double var)
        {
            List<VariaveisDistribuicao> probabilidades = calculaExponencial(min, max, var);
            Random rand = new Random();
            double probAcum = probabilidades[0].Probabilidade;
            double numero = 0;
            double total = 0;

            for (int i = 0; i < probabilidades.Count; i++)
            {
                total = probabilidades[i].Probabilidade + total;
            }
            numero = rand.Next(1, (int)total + 1);

            for (int i = 0; i < probabilidades.Count - 1; i++)
            {
                if (numero < probAcum)
                    return probabilidades[i].Numero;
                probAcum = probAcum + probabilidades[i + 1].Probabilidade;
            }
            return probabilidades[probabilidades.Count - 1].Numero;
        }
        public List<VariaveisDistribuicao> calculaExponencial(double a, double b, double y)
        {
            List<VariaveisDistribuicao> variaveis = new List<VariaveisDistribuicao>();
            VariaveisDistribuicao v;
            double x;

            for (x = a; x < b + 1; x++)
            {
                v = new VariaveisDistribuicao();
                v.Numero = x;
                v.Probabilidade = (y * (Math.Pow(Math.E, -1 * y * x))) * 100;
                variaveis.Add(v);
            }

            return variaveis;
        }

        public double DistribuicaoTriangular(double min, double max, double moda)
        {
            List<VariaveisDistribuicao> probabilidades = calculaTriangular(min, max, moda);
            Random rand = new Random();
            double probAcum = probabilidades[0].Probabilidade;
            double numero = rand.Next(1, 100);

            for (int i = 0; i < probabilidades.Count; i++)
            {
                if (numero < probAcum)
                    return probabilidades[i].Numero;
                probAcum = probAcum + probabilidades[i + 1].Probabilidade;
            }
            return probabilidades[probabilidades.Count - 1].Numero;
        }
        public List<VariaveisDistribuicao> calculaTriangular(double a, double b, double c)
        {
            List<VariaveisDistribuicao> variaveis = new List<VariaveisDistribuicao>();
            VariaveisDistribuicao v;
            double x;

            for (x = a; x < b + 1; x++)
            {
                v = new VariaveisDistribuicao();
                v.Numero = x;
                v.Probabilidade = (x == c) ? (2 / (b - a)) : (x < c) ? ((2 * (x - a)) / ((b - a) * (c - a))) : ((2 * (b - x)) / ((b - a) * (b - c)));
                v.Probabilidade = v.Probabilidade * 100;
                variaveis.Add(v);
            }

            return variaveis;
        }
        #endregion Fim [Métodos]
    }
}
