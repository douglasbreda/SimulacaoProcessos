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
using System.Threading;

namespace SimulacaoProcessos
{
    public partial class formSimulacao : Form
    {

        #region [Atributos]

        private ConfiguracaoGraficos oConfiguracao = new ConfiguracaoGraficos();

        private CalcularDistribuicao distribuicao;

        private int iNumProcessosEmFila = 0;

        private int idExecutados = 0;

        private double numero = 0;

        private int id = 0;

        private int tc_i = 0;

        private int ts_i = 0;

        private int ts_fim = 0;

        private int iNumPaineisCriados = 0;

        private int iTempoTotalProcesso = 0;

        private int iContadorTempo = -1;

        public int iTempoSimulacao
        {
            get { return Convert.ToInt32(txtTempoSimulacao.Text); }
        }
        private bool bContinuarSimulacao = true;

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
        private void ConfigurarTec()
        {
            if (radExponencialTec.Checked)
            {
                EsconderPaineisTec();
                pnlA.Visible = true;
                pnlB.Visible = true;
                pnlLambda.Visible = true;
                pnlC.Visible = false;
                pnlDesvio.Visible = false;
                pnlMedia.Visible = false;
            }
            else if (radNormalTec.Checked)
            {
                EsconderPaineisTec();
                pnlA.Visible = false;
                pnlB.Visible = false;
                pnlC.Visible = false;
                pnlLambda.Visible = false;
                pnlMedia.Visible = true;
                pnlDesvio.Visible = true;
            }
            else if (radTriangularTec.Checked)
            {
                EsconderPaineisTec();
                pnlA.Visible = true;
                pnlB.Visible = true;
                pnlC.Visible = true;
                pnlLambda.Visible = false;
                pnlMedia.Visible = false;
                pnlDesvio.Visible = false;
            }
            else if (radUniformeTec.Checked)
            {
                EsconderPaineisTec();
                pnlA.Visible = true;
                pnlB.Visible = true;
                pnlC.Visible = false;
                pnlLambda.Visible = false;
                pnlMedia.Visible = false;
                pnlDesvio.Visible = false;
            }
            else
            {
                EsconderPaineisTec();
                pnlA.Visible = false;
                pnlB.Visible = false;
                pnlC.Visible = false;
                pnlLambda.Visible = false;
                pnlMedia.Visible = false;
                pnlDesvio.Visible = false;
            }

        }
        private void ConfigurarTs()
        { 
            if (radExponencialTs.Checked)
            {
                EsconderPaineisTs();
                pnlTempoA.Visible = true;
                pnlTempoB.Visible = true;
                pnlTempoLambda.Visible = true;
                pnlTempoC.Visible = false;
                pnlTempoDesvio.Visible = false;
                pnlTempoMedia.Visible = false;
            }
            else if (radNormalTs.Checked)
            {
                EsconderPaineisTs();
                pnlTempoA.Visible = false;
                pnlTempoB.Visible = false;
                pnlTempoC.Visible = false;
                pnlTempoLambda.Visible = false;
                pnlTempoMedia.Visible = true;
                pnlTempoDesvio.Visible = true;
            }

            else if (radTriangularTs.Checked)
            {
                EsconderPaineisTs();
                pnlTempoA.Visible = true;
                pnlTempoB.Visible = true;
                pnlTempoC.Visible = true;
                pnlTempoLambda.Visible = false;
                pnlTempoMedia.Visible = false;
                pnlTempoDesvio.Visible = false;
            }

            else if (radUniformeTs.Checked)
            {
                EsconderPaineisTs();
                pnlTempoA.Visible = true;
                pnlTempoB.Visible = true;
                pnlTempoC.Visible = false;
                pnlTempoLambda.Visible = false;
                pnlTempoMedia.Visible = false;
                pnlTempoDesvio.Visible = false;
            }
            else
            {
                EsconderPaineisTs();
                pnlTempoA.Visible = false;
                pnlTempoB.Visible = false;
                pnlTempoC.Visible = false;
                pnlTempoLambda.Visible = false;
                pnlTempoMedia.Visible = false;
                pnlTempoDesvio.Visible = false;
            }
        }

        private void EsconderPaineisTs()
        {
            pnlTempoA.Visible = false;
            pnlTempoB.Visible = false;
            pnlTempoC.Visible = false;
            pnlTempoLambda.Visible = false;
            pnlTempoMedia.Visible = false;
            pnlTempoDesvio.Visible = false;
        }
        private void EsconderPaineisTec()
        { 
            pnlA.Visible = false;
            pnlB.Visible = false;
            pnlC.Visible = false;
            pnlLambda.Visible = false;
            pnlMedia.Visible = false;
            pnlDesvio.Visible = false;
        }

        private void IniciarSimulacao()
        {
            pnlObjetoExecutando.Visible = true;
            lblInfo.Visible = true;
            int iNumIncrementaFila = 0;
            foreach (DataRow drwLinha in dtsTabela.TABELA.Rows)
            {
                idExecutados++;
                AtualizarEstatisticas();
                if (drwLinha["TEC"] != DBNull.Value)
                {
                    if (Convert.ToDouble(drwLinha["TEC"]) > 0)
                    {
                        lblInfo.Text = "ID: " + drwLinha["ID"].ToString();
                        this.Refresh();
                        Thread.Sleep(1000);
                        if (Convert.ToInt32(drwLinha["FILA"]) > 0)
                        {

                            iNumIncrementaFila = CalcularDiferencaFila(Convert.ToInt32(drwLinha["FILA"]));
                            if (iNumIncrementaFila > 0)
                            {
                                iNumProcessosEmFila++;
                                barraProgresso.Increment(iNumIncrementaFila);
                                this.AtualizarEstatisticas();
                            }
                            else
                            {
                                iNumProcessosEmFila--;
                                barraProgresso.Value = Convert.ToInt32(drwLinha["FILA"]);
                                this.AtualizarEstatisticas();
                            }
                            barraProgresso.Refresh();

                        }
                        this.ExecutarProcesso(Convert.ToInt32(drwLinha["TS"]));
                    }
                }

            }
        }

        private void ExecutarProcesso(int pTempo)
        {
            iTempoTotalProcesso = pTempo;

            while (pTempo >= 0)
            {
                iContadorTempo++;
                lblTempo.Text = iContadorTempo.ToString();
                AtualizarCoresProcessoExecucao(pTempo);
                Panel panel = new Panel();
                iNumPaineisCriados++;
                LimparPaineis();
                panel.Width = 56;
                panel.Height = 35;
                panel.BackColor = pnlCorAtual.BackColor;
                pnlExecutando.Controls.Add(panel);
                this.Refresh();
                pTempo--;
                Thread.Sleep(100);
                panel.BackColor = Color.Transparent;
            }
        }

        private int CalcularDiferencaFila(int pValorFilaCalcular)
        {
            int iRetorno = 0;
            iRetorno = pValorFilaCalcular - barraProgresso.Value;
            return iRetorno;
        }

        private void SetarTotalBarraProgresso()
        {
            barraProgresso.Maximum = (Convert.ToInt32(dtsTabela.TABELA.AsEnumerable().Max(item => item["FILA"])) * 2);
        }

        private void AtualizarEstatisticas()
        {
            lblTotalProcessosV.Text = dtsTabela.TABELA.Rows.Count.ToString();
            lblProcessosFilaV.Text = iNumProcessosEmFila.ToString();
            lblProcessosExecutadosV.Text = idExecutados.ToString();
        }

        private void MontarTabela()
        {
            DataRow drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 0;
            drwNovaLinha["TEC"] = 0;
            drwNovaLinha["TC_I"] = 0;
            drwNovaLinha["TS_I"] = 0;
            drwNovaLinha["TS"] = 5;
            drwNovaLinha["TS_FIM"] = 5;
            drwNovaLinha["FILA"] = 0;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 1;
            drwNovaLinha["TEC"] = 0;
            drwNovaLinha["TC_I"] = 7;
            drwNovaLinha["TS_I"] = 7;
            drwNovaLinha["TS"] = 1;
            drwNovaLinha["TS_FIM"] = 8;
            drwNovaLinha["FILA"] = 0;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 2;
            drwNovaLinha["TEC"] = 7;
            drwNovaLinha["TC_I"] = 14;
            drwNovaLinha["TS_I"] = 14;
            drwNovaLinha["TS"] = 3;
            drwNovaLinha["TS_FIM"] = 17;
            drwNovaLinha["FILA"] = 0;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 3;
            drwNovaLinha["TEC"] = 6;
            drwNovaLinha["TC_I"] = 20;
            drwNovaLinha["TS_I"] = 20;
            drwNovaLinha["TS"] = 6;
            drwNovaLinha["TS_FIM"] = 26;
            drwNovaLinha["FILA"] = 0;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 4;
            drwNovaLinha["TEC"] = 3;
            drwNovaLinha["TC_I"] = 23;
            drwNovaLinha["TS_I"] = 26;
            drwNovaLinha["TS"] = 10;
            drwNovaLinha["TS_FIM"] = 36;
            drwNovaLinha["FILA"] = 3;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 5;
            drwNovaLinha["TEC"] = 9;
            drwNovaLinha["TC_I"] = 32;
            drwNovaLinha["TS_I"] = 36;
            drwNovaLinha["TS"] = 11;
            drwNovaLinha["TS_FIM"] = 47;
            drwNovaLinha["FILA"] = 4;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 6;
            drwNovaLinha["TEC"] = 7;
            drwNovaLinha["TC_I"] = 39;
            drwNovaLinha["TS_I"] = 67;
            drwNovaLinha["TS"] = 20;
            drwNovaLinha["TS_FIM"] = 0;
            drwNovaLinha["FILA"] = 8;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 7;
            drwNovaLinha["TEC"] = 5;
            drwNovaLinha["TC_I"] = 44;
            drwNovaLinha["TS_I"] = 67;
            drwNovaLinha["TS"] = 15;
            drwNovaLinha["TS_FIM"] = 82;
            drwNovaLinha["FILA"] = 23;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 8;
            drwNovaLinha["TEC"] = 17;
            drwNovaLinha["TC_I"] = 61;
            drwNovaLinha["TS_I"] = 82;
            drwNovaLinha["TS"] = 7;
            drwNovaLinha["TS_FIM"] = 89;
            drwNovaLinha["FILA"] = 21;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 9;
            drwNovaLinha["TEC"] = 11;
            drwNovaLinha["TC_I"] = 72;
            drwNovaLinha["TS_I"] = 89;
            drwNovaLinha["TS"] = 2;
            drwNovaLinha["TS_FIM"] = 91;
            drwNovaLinha["FILA"] = 17;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            drwNovaLinha = dtsTabela.TABELA.NewRow();
            drwNovaLinha["ID"] = 10;
            drwNovaLinha["TEC"] = 8;
            drwNovaLinha["TC_I"] = 80;
            drwNovaLinha["TS_I"] = 91;
            drwNovaLinha["TS"] = 4;
            drwNovaLinha["TS_FIM"] = 95;
            drwNovaLinha["FILA"] = 11;
            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
            bsoTabela.EndEdit();
        }

        private void ConfigurarTela()
        {
            //if (radNormal.Checked)
            //{
            //    radExponencial.Checked = false;
            //    radTriangular.Checked = false;
            //    radUniforme.Checked = false;
            //}
            //else if (radUniforme.Checked)
            //{
            //    radNormal.Checked = false;
            //    radTriangular.Checked = false;
            //    radExponencial.Checked = false;
            //}
            //else if (radTriangular.Checked)
            //{
            //    radNormal.Checked = false;
            //    radUniforme.Checked = false;
            //    radExponencial.Checked = false;
            //}
            //else if (radExponencial.Checked)
            //{
            //    radNormal.Checked = false;
            //    radTriangular.Checked = false;
            //    radUniforme.Checked = false;
            //}
        }

        private bool ValidarSimulacao()
        {
            StringBuilder sbMensagem = new StringBuilder();
            bool bRetorno = true;

            if (txtTempoSimulacao.Text == "")
            {
                sbMensagem.AppendLine("- É necessário informar o tempo para a simulação");
                bRetorno = false;
            }

            if (cboUnidadeTempo.SelectedIndex == -1)
            {
                sbMensagem.AppendLine("- É necessário informar uma unidade de tempo para a simulação");
                bRetorno = false;
            }

            if (radTriangularTec.Checked)
            {
                if (txtEntradaA.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para A");
                    bRetorno = false;
                }
                if (txtEntradaB.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para B");
                    bRetorno = false;
                }
                if (txtEntradaC.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para C");
                    bRetorno = false;
                }
            }
            if (radTriangularTs.Checked) {

                if (txtTempoA.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para A");
                    bRetorno = false;
                }

                if (txtTempoB.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para B");
                    bRetorno = false;
                }
                if (txtTempoC.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para C");
                    bRetorno = false;
                }
            }

            if (radNormalTec.Checked)
            {
                if (txtEntradaMedia.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para a média");
                    bRetorno = false;
                }
                if (txtEntradaDesvioPadrao.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para o desvio padrão");
                    bRetorno = false;
                }
            }

            if (radNormalTs.Checked)
            {
                if (txtTempoMedia.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para a média");
                    bRetorno = false;
                }
                if (txtTempoDesvio.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para o desvio padrão");
                    bRetorno = false;
                }
            }

            if (radUniformeTec.Checked)
            {
                if (txtEntradaA.Text == "")
                {
                    sbMensagem.AppendLine("Deve ser informado um valor de entrada para A");
                    bRetorno = false;
                }

                if (txtEntradaB.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para B");
                    bRetorno = false;
                }
            }

            if (radUniformeTs.Checked)
            {
                if (txtTempoA.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para A");
                    bRetorno = false;
                }

                if (txtTempoB.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para B");
                    bRetorno = false;
                }
            }

            if (radExponencialTec.Checked)
            {
                if (txtEntradaA.Text == "")
                {
                    sbMensagem.AppendLine("Deve ser informado um valor de entrada para A");
                    bRetorno = false;
                }

                if (txtEntradaB.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de entrada para B");
                    bRetorno = false;
                }

                if (txtEntradaLambda.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor lambda de entrada");
                    bRetorno = false;
                }
            }

            if (radExponencialTs.Checked)
            {

                if (txtTempoA.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para A");
                    bRetorno = false;
                }

                if (txtTempoB.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor de processamento para B");
                    bRetorno = false;
                }

                if (txtTempoLambda.Text == "")
                {
                    sbMensagem.AppendLine("- Deve ser informado um valor lambda de processamento");
                    bRetorno = false;
                }
            }

            if (!bRetorno)
                MessageBox.Show("Devem ser verificadas as seguintes informações: \n" + sbMensagem.ToString());

            return bRetorno;
        }

        private double CalcularDistribuicaoNormal(bool pEntrada)
        {
            if (pEntrada)
            {
                double media = Convert.ToDouble(txtEntradaMedia.Text);
                double desvio = Convert.ToDouble(txtEntradaDesvioPadrao.Text);
                numero = distribuicao.DistribuicaoNormal(media, desvio);
            }
            else
            {
                double media = Convert.ToDouble(txtTempoMedia.Text);
                double desvio = Convert.ToDouble(txtTempoDesvio.Text);
                numero = distribuicao.DistribuicaoNormal(media, desvio);
            }

            return numero;
        }

        private double CalcularDistribuicaoUniforme(bool pEntrada)
        {
            if (pEntrada)
            {
                double min = Convert.ToDouble(txtEntradaA.Text);
                double max = Convert.ToDouble(txtEntradaB.Text);
                numero = distribuicao.DistribuicaoUniforme(min, max);
            }
            else
            {
                double min = Convert.ToDouble(txtTempoA.Text);
                double max = Convert.ToDouble(txtTempoB.Text);
                numero = distribuicao.DistribuicaoUniforme(min, max);
            }

            return numero;
        }

        private double CalcularDistribuicaoTriangular(bool pEntrada)
        {
            if (pEntrada)
            {
                double min = Convert.ToDouble(txtEntradaA.Text);
                double max = Convert.ToDouble(txtEntradaB.Text);
                double moda = Convert.ToDouble(txtEntradaC.Text);
                numero = distribuicao.DistribuicaoTriangular(min, max, moda);
            }
            else
            {
                double min = Convert.ToDouble(txtTempoA.Text);
                double max = Convert.ToDouble(txtTempoB.Text);
                double moda = Convert.ToDouble(txtTempoC.Text);
                numero = distribuicao.DistribuicaoTriangular(min, max, moda);
            }

            return numero;
        }

        private double CalcularDistribuicaoExponencial(bool pEntrada)
        {
            if (pEntrada)
            {
                double min = Convert.ToDouble(txtEntradaA.Text);
                double max = Convert.ToDouble(txtEntradaB.Text);
                double var = Convert.ToDouble(txtEntradaLambda.Text);
                numero = distribuicao.DistribuicaoExponencial(min, max, var);
            }
            else
            {
                double min = Convert.ToDouble(txtTempoA.Text);
                double max = Convert.ToDouble(txtTempoB.Text);
                double var = Convert.ToDouble(txtTempoLambda.Text);
                numero = distribuicao.DistribuicaoExponencial(min, max, var);
            }

            return numero;
        }

        private void ConfigurarPrimeiraTupla(double pTs)
        {
            DataRow drwPrimeiraLinha = dtsTabela.TABELA.NewRow();
            drwPrimeiraLinha["ID"] = id;
            drwPrimeiraLinha["TC_I"] = 0;
            drwPrimeiraLinha["TS_I"] = 0;
            drwPrimeiraLinha["TS"] = pTs;
            if (pTs > iTempoSimulacao) {
                drwPrimeiraLinha["TS_FIM"] = iTempoSimulacao;
                bContinuarSimulacao = false;
            }
            else
            {
                drwPrimeiraLinha["TS_FIM"] = pTs;
            }

            ts_i = Convert.ToInt32(drwPrimeiraLinha["TS_I"]);
            ts_fim = Convert.ToInt32(drwPrimeiraLinha["TS_FIM"]);
            id++;
            drwPrimeiraLinha["FILA"] = 0; //Convert.ToInt32(drwPrimeiraLinha["TS_FIM"]) - Convert.ToInt32(drwPrimeiraLinha["TC_I"]);

            dtsTabela.TABELA.Rows.Add(drwPrimeiraLinha);
        }

        private void ConfigurarNovaTupla(double pValorTec, double pValorTs)
        {
            DataRow drwNovaLinha = dtsTabela.TABELA.NewRow();

            drwNovaLinha["ID"] = id;
            drwNovaLinha["TEC"] = pValorTec;
            drwNovaLinha["TC_I"] = tc_i + pValorTec;
            if (ts_fim < Convert.ToInt32(drwNovaLinha["TC_I"]))
                drwNovaLinha["TS_I"] = drwNovaLinha["TC_I"];
            else
                drwNovaLinha["TS_I"] = ts_fim;// + pValorTs;

            drwNovaLinha["TS"] = pValorTs;
            drwNovaLinha["TS_FIM"] = Convert.ToInt32(drwNovaLinha["TS_I"]) + Convert.ToInt32(drwNovaLinha["TS"]);

            if(Convert.ToInt32(drwNovaLinha["TS_FIM"]) > iTempoSimulacao)
            {
                drwNovaLinha["TS_FIM"] = iTempoSimulacao;
                bContinuarSimulacao = false;
            }

            tc_i = Convert.ToInt32(drwNovaLinha["TC_I"]);
            ts_i = Convert.ToInt32(drwNovaLinha["TS_I"]);
            ts_fim = Convert.ToInt32(drwNovaLinha["TS_FIM"]);
            id++;
            drwNovaLinha["FILA"] = Convert.ToInt32(drwNovaLinha["TS_FIM"]) - Convert.ToInt32(drwNovaLinha["TC_I"]);

            dtsTabela.TABELA.Rows.Add(drwNovaLinha);
        }

        private void BloquearCaracteres(KeyPressEventArgs pEvento)
        {
            if (!char.IsDigit(pEvento.KeyChar) && !(pEvento.KeyChar == (char)Keys.Enter) && !(pEvento.KeyChar == (char)Keys.Back))
            {
                pEvento.Handled = true;
            }
        }

        private void LimparPaineis()
        {
            if(iNumPaineisCriados > 100)
            {
                pnlExecutando.Controls.Clear();
                iNumPaineisCriados = 0;
            }
        }

        private void AtualizarCoresProcessoExecucao(int pTempoAtual)
        {
            double nCalculoTempo = ((iTempoTotalProcesso * pTempoAtual) / 100);
            if (nCalculoTempo > 0 && nCalculoTempo < 10)
                pnlObjetoExecutando.BackColor = Color.Ivory;
            else if (nCalculoTempo > 10 && nCalculoTempo < 20)
                pnlObjetoExecutando.BackColor = Color.LightGoldenrodYellow;
            else if (nCalculoTempo > 20 && nCalculoTempo < 35)
                pnlObjetoExecutando.BackColor = Color.LightYellow;
            else if (nCalculoTempo > 35 && nCalculoTempo < 50)
                pnlObjetoExecutando.BackColor = Color.Yellow;
            else if (nCalculoTempo > 50 && nCalculoTempo < 75)
                pnlObjetoExecutando.BackColor = Color.PaleGreen;
            else if (nCalculoTempo > 75 && nCalculoTempo < 100)
                pnlObjetoExecutando.BackColor = Color.LightGreen;
            else
                pnlObjetoExecutando.BackColor = Color.GreenYellow;

        }

        private string BuscarFormatoTempo()
        {
            string sRetorno = "";
            if ((Enumerados.eTempo)cboUnidadeTempo.SelectedIndex == Enumerados.eTempo.segundos)
                sRetorno = "s";
            else if ((Enumerados.eTempo)cboUnidadeTempo.SelectedIndex == Enumerados.eTempo.nanosegundo)
                sRetorno = "ns";
            else if ((Enumerados.eTempo)cboUnidadeTempo.SelectedIndex == Enumerados.eTempo.dia)
                sRetorno = "dia(s)";
            else if ((Enumerados.eTempo)cboUnidadeTempo.SelectedIndex == Enumerados.eTempo.horas)
                sRetorno = "h";
            else if ((Enumerados.eTempo)cboUnidadeTempo.SelectedIndex == Enumerados.eTempo.milisiegundos)
                sRetorno = "ms";
            else if ((Enumerados.eTempo)cboUnidadeTempo.SelectedIndex == Enumerados.eTempo.minutos)
                sRetorno = "min";

            return sRetorno;
        }

        private void ResetarValores()
        {
            bContinuarSimulacao = true;
            dtsTabela.TABELA.Clear();
            id = 0;
            ts_fim = 0;
            ts_i = 0;
            iNumProcessosEmFila = 0;
            idExecutados = 0;
            barraProgresso.Value = 0;
            lblInfo.Text = "-";
            pnlObjetoExecutando.Visible = false;
            lblTempo.Text = "-";
            lblTipoTempo.Text = ".";
            iContadorTempo = 0;

        }

        private void DefinirCorSimulacao()
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
                pnlCorAtual.BackColor = colorDialog1.Color;
        }

        private void DefinirDirecao()
        {
            if(cboDirecaoSimulacao.SelectedIndex != -1)
            {
                if (cboDirecaoSimulacao.SelectedIndex == 0)
                    pnlExecutando.FlowDirection = FlowDirection.TopDown;
                else if (cboDirecaoSimulacao.SelectedIndex == 1)
                    pnlExecutando.FlowDirection = FlowDirection.LeftToRight;
                else if (cboDirecaoSimulacao.SelectedIndex == 2)
                    pnlExecutando.FlowDirection = FlowDirection.RightToLeft;
                else
                    pnlExecutando.FlowDirection = FlowDirection.BottomUp;
            }else
            {
                pnlExecutando.FlowDirection = FlowDirection.TopDown;
            }
        }

        #endregion Fim [Métodos]

        #region [Eventos]
        private void radUniforme_CheckedChanged(object sender, EventArgs e)
        {
            //this.ConfigurarTela();
            //this.ConfigurarAbaSimulacao();
        }

        private void formSimulacao_Load(object sender, EventArgs e)
        {
            this.ConfigurarGrafico();
            this.ConfigurarTec();
            this.ConfigurarTs();
            //this.MontarTabela();
            this.SetarTotalBarraProgresso();
            this.AtualizarEstatisticas();
            this.DefinirDirecao();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            ResetarValores();
            lblTipoTempo.Text = BuscarFormatoTempo();
            DefinirDirecao();
            double nValorTec = 0;
            double nValorTs = 0;

            if (ValidarSimulacao())
            {
                while (bContinuarSimulacao)
                {
                    distribuicao = new CalcularDistribuicao();

                    if (radUniformeTec.Checked)
                        nValorTec = CalcularDistribuicaoUniforme(true);

                    if (radUniformeTs.Checked)
                   {
                        nValorTs = CalcularDistribuicaoUniforme(false);
                        if (id > 0)
                            ConfigurarNovaTupla(nValorTec, nValorTs);
                        else
                            ConfigurarPrimeiraTupla(nValorTs);
                    }

                    if (radNormalTec.Checked)
                        nValorTec = CalcularDistribuicaoNormal(true);

                    if (radNormalTs.Checked)
                    {
                        nValorTs = CalcularDistribuicaoNormal(false);
                        if (id > 0)
                            ConfigurarNovaTupla(nValorTec, nValorTs);
                        else
                            ConfigurarPrimeiraTupla(nValorTs);
                    }

                    if (radExponencialTec.Checked)
                        nValorTec = CalcularDistribuicaoExponencial(true);
                    if (radExponencialTs.Checked)
                    {
                        nValorTs = CalcularDistribuicaoExponencial(false);
                        if (id > 0)
                            ConfigurarNovaTupla(nValorTec, nValorTs);
                        else
                            ConfigurarPrimeiraTupla(nValorTs);
                    }

                    if (radTriangularTec.Checked)
                        nValorTec = CalcularDistribuicaoTriangular(true);
                    if (radTriangularTs.Checked)
                    {
                        nValorTs = CalcularDistribuicaoTriangular(false);
                        if (id > 0)
                            ConfigurarNovaTupla(nValorTec, nValorTs);
                        else
                            ConfigurarPrimeiraTupla(nValorTs);
                    }
                }

                this.SetarTotalBarraProgresso();
                this.IniciarSimulacao();
            }

        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            //oThreadSimulacao.Abort();
        }

        private void txtEntradaLambda_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtEntradaC_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtEntradaMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtEntradaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtEntradaDesvioPadrao_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtEntradaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoLambda_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoA_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoDesvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoB_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void txtTempoSimulacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloquearCaracteres(e);
        }

        private void radNormalTec_CheckedChanged(object sender, EventArgs e)
        {
            if (radNormalTec.Checked)
                ConfigurarTec();
        }

        private void radExponencialTec_CheckedChanged(object sender, EventArgs e)
        {
            if (radExponencialTec.Checked)
                ConfigurarTec();
        }

        private void radUniformeTec_CheckedChanged(object sender, EventArgs e)
        {
            if (radUniformeTec.Checked)
                ConfigurarTec();
        }

        private void radTriangularTec_CheckedChanged(object sender, EventArgs e)
        {
            if (radTriangularTec.Checked)
                ConfigurarTec();
        }

        private void radNormalTs_CheckedChanged(object sender, EventArgs e)
        {
            if (radNormalTs.Checked)
                ConfigurarTs();
        }

        private void radUniformeTs_CheckedChanged(object sender, EventArgs e)
        {
            if (radUniformeTs.Checked)
                ConfigurarTs();
        }
        private void radExponencialTs_CheckedChanged(object sender, EventArgs e)
        {
            if (radExponencialTs.Checked)
                ConfigurarTs();
        }

        private void radTriangularTs_CheckedChanged(object sender, EventArgs e)
        {
            if (radTriangularTs.Checked)
                ConfigurarTs();
        }

        private void btnEscolherCor_Click(object sender, EventArgs e)
        {
            DefinirCorSimulacao();
        }
        #endregion Fim [Eventos]


    }
}
