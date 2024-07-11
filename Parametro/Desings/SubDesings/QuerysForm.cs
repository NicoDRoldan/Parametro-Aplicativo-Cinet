using Microsoft.IdentityModel.Tokens;
using Parametro.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Functions functions = new Functions();

        public static string numVentaRut { get; set; }
        public static string numRutCorrecto { get; set; }
        public static string nroAnteriorCbtee { get; set; }

        public QuerysForm()
        {
            InitializeComponent();

            this.Size = new Size(832, 500);

            fechaHasta.Value = DateTime.Today;

            VerificarPais();
        }

        private void btnRegCierre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NumCierre.Text) || NumCierre.Text.Length == 0 || NumCierre.Text is null)
            {
                MessageBox.Show("Ingresar número de cierre correspondiente.");
            }
            else
            {
                if (vistaQuerys != null && vistaQuerys.Visible)
                {
                    vistaQuerys.Close();
                }

                vistaQuerys = new VistaQuerys();
                ConexionDB.numeroCierre = NumCierre.Text.Trim();
                DataTable resultados = querys.RegenerarCierre();

                if (resultados.Rows.Count > 0)
                {
                    vistaQuerys.dataGridResultadosQuery.DataSource = resultados.DefaultView;
                    vistaQuerys.Show();
                }
            }
        }

        public int ValidarPassBotones(string pass)
        {
            int valor = 0;

            switch (pass)
            {
                case "cinetpassadmin":
                    valor = 1;
                    break;
                case "cinetpass":
                    valor = 2;
                    break;
                default:
                    return valor;
            }

            return valor;
        }

        private void HabilitarBotones()
        {
            switch (ValidarPassBotones(txtPassBotones.Text))
            {
                case 1:
                    panelMesa.Enabled = true;
                    panelUruguay.Enabled = true;
                    panelParaguay.Enabled = true;
                    panelBolivia.Enabled = true;
                    break;
                case 2:
                    panelUruguay.Enabled = true;
                    panelParaguay.Enabled = true;
                    panelBolivia.Enabled = true;
                    break;
                default:
                    panelMesa.Enabled = false;
                    panelUruguay.Enabled = false;
                    panelParaguay.Enabled = false;
                    panelBolivia.Enabled = false;
                    MessageBox.Show("¡Datos Incorrectos!");
                    return;
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

            switch (ConexionDB.pais)
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
            if (ConexionDB.pais == "URUGUAY")
            {
                panelUruguay.Visible = true;
                btnFEAuto.Visible = true;
                checkConsumidorFinal.Visible = true;
                txtVeneNumeroRut.Visible = true;
                labelCorregirRut.Visible = true;
                btnCorregirClienteRut.Visible = true;
                txtRutCorrecto.Visible = true;
            }
            else if (ConexionDB.pais == "PARAGUAY")
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
            else if (ConexionDB.pais == "BOLIVIA")
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
            if (ValidarPrueba(out double precio, out string marchaComanda))
            {
                querys.ActivarArticuloPrueba(precio, marchaComanda);
            }
        }

        private void btnTestConito_Click(object sender, EventArgs e)
        {
            if (ValidarPrueba(out double precio, out string marchaComanda))
            {
                querys.ActivarTestConito(precio, marchaComanda);
            }
        }

        private bool ValidarPrueba(out double precio, out string marchaComanda)
        {
            List<string> marchado = new List<string> { "S", "N", "ESTA" };

            marchaComanda = txtMarchaComanda.Text.ToUpper();
            precio = 0;

            if (string.IsNullOrEmpty(txtMontoPrueba.Text) ||
                string.IsNullOrEmpty(marchaComanda) ||
                !marchado.Contains(marchaComanda))
            {
                MessageBox.Show("Completar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var precioString = txtMontoPrueba.Text.Replace(".", ",");
            if (!double.TryParse(precioString, out precio))
            {
                MessageBox.Show("Monto inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
            if (txtTimLocal.Text.Length == 0 || txtTimCaja.Text.Length == 0) MessageBox.Show("Completar los campos.");
            else querys.ConfigurarTimbrado(txtTimLocal.Text, txtTimCaja.Text);
        }
        private void btnFEAutoBo_Click(object sender, EventArgs e)
        {
            querys.FacturaElectronicaAutoBO();
        }

        private void CorregirCbtBo_Click(object sender, EventArgs e)
        {
            if (txtboxNumSucursalBO.Text.Length == 0)
            {
                MessageBox.Show("Ingresar el número de sucursal :)"); return;
            }
            else
            {
                querysParametros.ConfigurarComprobantesBO(txtboxNumSucursalBO.Text);
            }

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
            if (txtTipoCBTEE.Text.Length > 0 &&
                (txtUltimoNroCorrelativo.Text.Length > 0 && Regex.IsMatch(txtUltimoNroCorrelativo.Text, @"^\d+$")))
            {

                labelNroBteAnt.Visible = true;
                txtNumCbteeAnt.Visible = true;

                txtNumCbteeAnt.Text = querys.ConsultarUltimaNumeracion(txtTipoCBTEE.Text);

                querys.CorregirNumeracion(txtTipoCBTEE.Text, txtUltimoNroCorrelativo.Text);
            }
            else
            {
                MessageBox.Show("Verificar los datos ingresados.");
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Functions.HacerBackup();
        }

        private void lblHelpFEBO_MouseHover(object sender, EventArgs e)
        {
            pbPanelFEBO.Location = new Point(428, 160);
            pbPanelFEBO.Visible = true;
        }

        private void lblHelpFEBO_MouseLeave(object sender, EventArgs e)
        {
            pbPanelFEBO.Visible = false;
        }

        private void txtMarchaComanda_Click(object sender, EventArgs e)
        {
            if (txtMarchaComanda.Text == "S")
                txtMarchaComanda.Text = "N";
            else if (txtMarchaComanda.Text == "N")
                txtMarchaComanda.Text = "S";
        }
    }
}
