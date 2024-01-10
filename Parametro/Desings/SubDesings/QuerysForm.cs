using Parametro.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parametro.Desings.SubDesings
{
    public partial class QuerysForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();
        Querys querys = new Querys();
        VistaQuerys vistaQuerys = new VistaQuerys();
        QuerysParametros querysParametros = new QuerysParametros();

        public static string numVentaRut { get; set; }
        public static string numRutCorrecto { get; set; }
        public static string nroAnteriorCbtee { get; set; }

        public QuerysForm()
        {
            InitializeComponent();

            fechaHasta.Value = DateTime.Today;

            panelMesa.Enabled = false;
            panelUruguay.Enabled = false;
            panelParaguay.Enabled = false;

            VerificarPais();
        }

        private void btnRegCierre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NumCierre.Text))
            {
                if (vistaQuerys != null && vistaQuerys.Visible)
                {
                    vistaQuerys.Close();
                }

                vistaQuerys = new VistaQuerys();
                ConexionDB.numeroCierre = NumCierre.Text.Trim();
                DataTable resultados = querys.RegenerarCierre();

                vistaQuerys.dataGridResultadosQuery.DataSource = resultados.DefaultView;
                vistaQuerys.Show();
            }
            else
            {
                MessageBox.Show("Ingresar número de cierre correspondiente.");
            }
        }

        private bool ValidarPassBotones()
        {
            return (txtPassBotones.Text == "onichanfurry");
        }

        private void HabilitarBotones()
        {
            if (ValidarPassBotones() || !string.IsNullOrEmpty(txtPassBotones.Text))
            {
                panelMesa.Enabled = true;
                panelUruguay.Enabled = true;
                panelParaguay.Enabled = true;
                panelBolivia.Enabled = true;
            }
            else
            {
                panelMesa.Enabled = false;
                MessageBox.Show("Datos incorrectos");
            }
        }

        private void btnVerZetasEnCero_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            vistaQuerys = new VistaQuerys();

            DataSet resultados = querys.VerZetasEnCero(fechaDesde.Value.Date.ToString(), fechaHasta.Value.Date.ToString());

            //vistaQuerys.dataGridResultadosQuery.DataSource = resultados.DefaultView;

            if (resultados.Tables.Count >= 2)
            {
                vistaQuerys.dataGridResultadosQuery.DataSource = resultados.Tables[0].DefaultView;
                vistaQuerys.dataGridResultadosQuery2.DataSource = resultados.Tables[1].DefaultView;
                vistaQuerys.dataGridResultadosQuery2.Enabled = true;
                vistaQuerys.dataGridResultadosQuery2.Visible = true;
            }

            vistaQuerys.Show();
        }

        private void btnCorregirZetasEnCero_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            querys.CorregirZetasEnCero(fechaDesde.Value.Date.ToString(), fechaHasta.Value.Date.ToString());
        }

        private void VerificarPais()
        {
            Querys querys = new Querys();

            var pais = querys.BasePais();

            switch (pais)
            {
                case "URUGUAY":
                    MostrarDatos();
                    break;
                case "PARAGUAY":
                    MostrarDatos();
                    break;
                case "BOLIVIA":
                    MostrarDatos();
                    break;
                default:
                    this.Width = 435;
                    this.Height = 481;
                    labelPass.Location = new Point(238, 9);
                    txtPassBotones.Location = new Point(238, 29);
                    btnAceptarPassBtn.Location = new Point(339, 29);
                    break;
            }
        }

        private void MostrarDatos()
        {
            if (querys.BasePais() == "URUGUAY")
            {
                panelUruguay.Visible = true;
                btnFEAuto.Visible = true;
                checkConsumidorFinal.Visible = true;
                txtVeneNumeroRut.Visible = true;
                labelCorregirRut.Visible = true;
                btnCorregirClienteRut.Visible = true;
                txtRutCorrecto.Visible = true;
            }
            else if (querys.BasePais() == "PARAGUAY")
            {
                panelParaguay.Visible = true;
                panelParaguay.Location = new Point(413, 74);
                labelCorregirTimbrado.Visible = true;
                labelnumcajatim.Visible = true;
                labelnomlocaltim.Visible = true;
                txtTimCaja.Visible = true;
                txtTimLocal.Visible = true;
                btnConfigTim.Visible = true;
            }
            else if (querys.BasePais() == "BOLIVIA")
            {
                panelBolivia.Location = new Point(413, 74);
                panelBolivia.Visible = true;
                CorregirCbtBo.Visible = true;
                btnFEAutoBo.Visible = true;
            }
        }

        #region Botones

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fechaHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelPais_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPais_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnArtPrueba_Click(object sender, EventArgs e)
        {
            querys.ActivarArticuloPrueba();
        }

        private void btnTestConito_Click(object sender, EventArgs e)
        {
            querys.ActivarTestConito();
        }

        private void btnAceptarPassBtn_Click(object sender, EventArgs e)
        {
            HabilitarBotones();
        }

        private void txtRutCorrecto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFEAuto_Click(object sender, EventArgs e)
        {
            querys.FacturaElectronicaAuto();
        }

        private void btnConfigTim_Click(object sender, EventArgs e)
        {
            querys.ConfigurarTimbrado(txtTimLocal.Text, txtTimCaja.Text);
        }
        private void btnFEAutoBo_Click(object sender, EventArgs e)
        {
            querys.FacturaElectronicaAutoBO();
        }

        private void CorregirCbtBo_Click(object sender, EventArgs e)
        {
            querysParametros.ConfigurarComprobantesBO();
        }
        #endregion


        private void btnCorregirClienteRut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVeneNumeroRut.Text) && !string.IsNullOrEmpty(txtRutCorrecto.Text))
            {
                querys.CorregirRutCliente(txtVeneNumeroRut.Text, txtRutCorrecto.Text);
            }
            else
            {
                MessageBox.Show("Llenar los datos correspondientes.");
            }
        }

        private void checkConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkConsumidorFinal.Checked)
            {
                txtRutCorrecto.Enabled = false;
                txtRutCorrecto.Text = "00-00000000-0";
            }
            else
            {
                txtRutCorrecto.Enabled = true;
                txtRutCorrecto.Text = "";
            }
        }

        private void btnCorregirNracion_Click(object sender, EventArgs e)
        {
            labelNroBteAnt.Visible = true;
            txtNumCbteeAnt.Visible = true;

            txtNumCbteeAnt.Text = querys.ConsultarUltimaNumeracion(txtTipoCBTEE.Text);

            querys.CorregirNumeracion(txtTipoCBTEE.Text, txtUltimoNroCorrelativo.Text);
        }

    }
}
