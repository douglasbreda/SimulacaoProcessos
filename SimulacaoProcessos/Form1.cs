using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Distributions;


namespace SimulacaoProcessos
{
    public partial class formSimulacao : Form
    {

        #region [Atributos]

        ConfiguracaoGraficos oConfiguracao = new ConfiguracaoGraficos();

        #endregion Fim [Atributos]

        #region [Construtores]
        public formSimulacao()
        {
            InitializeComponent();
        }

        #endregion Fim [Construtores]

        #region [Métodos]

        /// <summary>
        /// Configura os gráficos do inicio do sistema
        /// </summary>
        public void ConfigurarGrafico()
        {
            //Gráfico Uniforme
            DataTable dtbDistUniforme = oConfiguracao.ConfigurarGraficoUniforme();
            bsoUniforme.DataSource = dtbDistUniforme;
            grfUniforme.DataBind();

            //Gráfico Normal
            DataTable dtbDistNormal = oConfiguracao.ConfigurarGraficoNormal();
            bsoNormal.DataSource = dtbDistNormal;
            grfNormal.DataBind();

            //Gráfico Triangular
            DataTable dtbDistTriangular = oConfiguracao.ConfigurarGraficoTriangular();
            bsoTriangular.DataSource = dtbDistTriangular;
            grfTriangular.DataBind();

            //Gráfico Exponencial
            DataTable dtbDistExponencial = oConfiguracao.ConfigurarGraficoExponencial();
            bsoExponencial.DataSource = dtbDistExponencial;
            grfExponencial.DataBind();
        }

        /// <summary>
        /// Configura os campos de entrada do usuário conforme o tipo de gráfico selecionado
        /// </summary>
        private void ConfigurarAbaSimulacao()
        {
            if (radExponencial.Checked)
            {
                pnlA.Visible = true;
                pnlB.Visible = true;
                pnlLambda.Visible = true;
                pnlC.Visible = false;
                pnlDesvio.Visible = false;
                pnlMedia.Visible = false;
            }
            else if (radNormal.Checked)
            {
                pnlA.Visible = false;
                pnlB.Visible = false;
                pnlC.Visible = false;
                pnlLambda.Visible = false;
                pnlMedia.Visible = true;
                pnlDesvio.Visible = true;
            }
            else if (radTriangular.Visible)
            {
                pnlA.Visible = true;
                pnlB.Visible = true;
                pnlC.Visible = true;
                pnlLambda.Visible = false;
                pnlMedia.Visible = false;
                pnlDesvio.Visible = false;
            }
            else if (radUniforme.Visible)
            {
                pnlA.Visible = true;
                pnlB.Visible = true;
                pnlC.Visible = false;
                pnlLambda.Visible = false;
                pnlMedia.Visible = false;
                pnlDesvio.Visible = false;
            }
        }
        #endregion Fim [Métodos]

        #region [Eventos]
        private void radUniforme_CheckedChanged(object sender, EventArgs e)
        {
            if (radUniforme.Checked)
            {
                radNormal.Checked = false;
                radTriangular.Checked = false;
                radExponencial.Checked = false;
            }
            this.ConfigurarAbaSimulacao();
        }

        private void formSimulacao_Load(object sender, EventArgs e)
        {
            this.ConfigurarGrafico();
            this.ConfigurarAbaSimulacao();
        }

        private void radNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (radNormal.Checked)
            {
                radExponencial.Checked = false;
                radTriangular.Checked = false;
                radUniforme.Checked = false;
            }
            this.ConfigurarAbaSimulacao();
        }

        private void radExponencial_CheckedChanged(object sender, EventArgs e)
        {
            if (radExponencial.Checked)
            {
                radNormal.Checked = false;
                radTriangular.Checked = false;
                radUniforme.Checked = false;
            }
            this.ConfigurarAbaSimulacao();
        }
        private void radTriangular_CheckedChanged(object sender, EventArgs e)
        {
            if(radTriangular.Checked)
            {
                radNormal.Checked = false;
                radUniforme.Checked = false;
                radExponencial.Checked = false;
            }

            this.ConfigurarAbaSimulacao();
        }



        #endregion Fim [Eventos]
    }
}
