using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacaoProcessos
{
    public class ConfiguracaoGraficos
    {
        #region [Construtores]

        public ConfiguracaoGraficos()
        {

        }

        #endregion Fim [Construtores]

        #region [Métodos]

        /// <summary>
        /// Monta o gráfico Uniforme
        /// </summary>
        /// <returns></returns>
        public DataTable ConfigurarGraficoUniforme()
        {
            DataTable dtbDistUniforme = new DataTable();
            DataColumn eixoX = new DataColumn("X", typeof(double));
            DataColumn eixoY = new DataColumn("Y", typeof(double));
            dtbDistUniforme.Columns.Add(eixoX);
            dtbDistUniforme.Columns.Add(eixoY);
            DataRow drwNovalinha = dtbDistUniforme.NewRow();
            drwNovalinha["X"] = 2;
            drwNovalinha["Y"] = 40;
            dtbDistUniforme.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistUniforme.NewRow();
            drwNovalinha["X"] = 6;
            drwNovalinha["Y"] = 40;
            dtbDistUniforme.Rows.Add(drwNovalinha);

            return dtbDistUniforme;
        }

        public DataTable ConfigurarGraficoNormal()
        {
            DataTable dtbDistNormal = new DataTable();
            DataColumn eixoX = new DataColumn("X", typeof(double));
            DataColumn eixoY = new DataColumn("Y", typeof(double));
            dtbDistNormal.Columns.Add(eixoX);
            dtbDistNormal.Columns.Add(eixoY);
            DataRow drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 0;
            drwNovalinha["Y"] = 1;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 1;
            drwNovalinha["Y"] = 1;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 2;
            drwNovalinha["Y"] = 1.1;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3;
            drwNovalinha["Y"] = 1.5;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.4;
            drwNovalinha["Y"] = 2.3;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.5;
            drwNovalinha["Y"] = 3;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.5;
            drwNovalinha["Y"] = 3.8;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.5;
            drwNovalinha["Y"] = 4;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.5;
            drwNovalinha["Y"] = 4;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.5;
            drwNovalinha["Y"] = 4.8;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.5;
            drwNovalinha["Y"] = 5.6;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 3.6;
            drwNovalinha["Y"] = 6;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 4.1;
            drwNovalinha["Y"] = 6.5;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 4.9;
            drwNovalinha["Y"] = 6.9;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 5.9;
            drwNovalinha["Y"] = 6.5;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.2;
            drwNovalinha["Y"] = 6;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.3;
            drwNovalinha["Y"] = 5.6;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.3;
            drwNovalinha["Y"] = 4.8;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.3;
            drwNovalinha["Y"] = 4;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.3;
            drwNovalinha["Y"] = 3.8;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.3;
            drwNovalinha["Y"] = 3;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.3;
            drwNovalinha["Y"] = 2.8;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 6.6;
            drwNovalinha["Y"] = 1.5;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 7.2;
            drwNovalinha["Y"] = 1.1;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 8.1;
            drwNovalinha["Y"] = 1.1;
            dtbDistNormal.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistNormal.NewRow();
            drwNovalinha["X"] = 9;
            drwNovalinha["Y"] = 1;
            dtbDistNormal.Rows.Add(drwNovalinha);

            return dtbDistNormal;
        }

        public DataTable ConfigurarGraficoTriangular()
        {
            DataTable dtbDistTriagular = new DataTable();
            DataColumn eixoX = new DataColumn("X", typeof(double));
            DataColumn eixoY = new DataColumn("Y", typeof(double));
            dtbDistTriagular.Columns.Add(eixoX);
            dtbDistTriagular.Columns.Add(eixoY);
            DataRow drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1;
            drwNovalinha["Y"] = 0;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.1;
            drwNovalinha["Y"] = 1;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.2;
            drwNovalinha["Y"] = 2;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.3;
            drwNovalinha["Y"] = 3;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.4;
            drwNovalinha["Y"] = 4;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.5;
            drwNovalinha["Y"] = 5;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.6;
            drwNovalinha["Y"] = 6;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.7;
            drwNovalinha["Y"] = 7;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.8;
            drwNovalinha["Y"] = 8;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 1.9;
            drwNovalinha["Y"] = 9;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.0;
            drwNovalinha["Y"] = 10;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.1;
            drwNovalinha["Y"] = 9;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.2;
            drwNovalinha["Y"] = 8;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.3;
            drwNovalinha["Y"] = 7;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.4;
            drwNovalinha["Y"] = 6;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.5;
            drwNovalinha["Y"] = 5;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.6;
            drwNovalinha["Y"] = 4;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.7;
            drwNovalinha["Y"] = 3;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.8;
            drwNovalinha["Y"] = 2;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 2.9;
            drwNovalinha["Y"] = 1;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistTriagular.NewRow();
            drwNovalinha["X"] = 3.0;
            drwNovalinha["Y"] = 0;
            dtbDistTriagular.Rows.Add(drwNovalinha);
            return dtbDistTriagular;
        }

        public DataTable ConfigurarGraficoExponencial()
        {
            DataTable dtbDistExponencial = new DataTable();
            DataColumn eixoX = new DataColumn("X", typeof(double));
            DataColumn eixoY = new DataColumn("Y", typeof(double));
            dtbDistExponencial.Columns.Add(eixoX);
            dtbDistExponencial.Columns.Add(eixoY);
            DataRow drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 0;
            drwNovalinha["Y"] = 6;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 0.1;
            drwNovalinha["Y"] = 5;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 0.5;
            drwNovalinha["Y"] = 4;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 1.3;
            drwNovalinha["Y"] = 3;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 2.1;
            drwNovalinha["Y"] = 2.2;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 3;
            drwNovalinha["Y"] = 1.8;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 4;
            drwNovalinha["Y"] = 1.1;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 5;
            drwNovalinha["Y"] = 0.9;
            dtbDistExponencial.Rows.Add(drwNovalinha);
            drwNovalinha = dtbDistExponencial.NewRow();
            drwNovalinha["X"] = 6.5;
            drwNovalinha["Y"] = 0.5;
            dtbDistExponencial.Rows.Add(drwNovalinha);

            return dtbDistExponencial;
        }
        #endregion Fim [Métodos]


    }
}
