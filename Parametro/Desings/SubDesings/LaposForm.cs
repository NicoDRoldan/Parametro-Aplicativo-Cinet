using Parametro.Class;
using Parametro.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parametro.Desings.SubDesings
{
    public partial class LaposForm : Form
    {
        Querys querys = new Querys();
        ConexionDB conexionDB = new ConexionDB();
        CinetPdvForm cinetPdvForm = new CinetPdvForm();

        public LaposForm()
        {
            InitializeComponent();
            CargarNumerosComercio();

            string[] nombreParametros = { TACOCUIT.Name, LPoPuerto.Name, TERMINAL.Name, LAPOSNET.Name };
            cinetPdvForm.CargarDatosParametros(this, nombreParametros);
        }

        public void btnGuardarNrosComercio_Click(object sender, EventArgs e)
        {
            ConfigurarComercios();
        }

        #region basura
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtVisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAmex_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCabal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNaranja_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaster_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void ConfigurarComercios()
        {
            querys = new Querys();
            string[,] nombreTarjetas = {
                { "AMEX", AMEX.Text},
                { "VISA", Visa.Text},
                { "MASTER", MASTER.Text},
                { "CABALDEB", CABALDEB.Text},
                { "TNARANJA", TNARANJA.Text}
            };

            int tarjetas = nombreTarjetas.GetLength(0);
            int columnas = nombreTarjetas.GetLength(0);

            try
            {
                for (int i = 0; i < tarjetas; i++)
                {
                    querys.ConfigurarNumeroComercio(nombreTarjetas[i, 0], nombreTarjetas[i, 1]);
                }
                MessageBox.Show($"Se guardaron los cambios.");
            }
            catch (Exception ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }

        public void CargarNumerosComercio()
        {
            string[] nombreTarjetas = { "AMEX", "VISA", "MASTER", "CABALDEB", "TNARANJA", };

            foreach (string tarjeta in nombreTarjetas)
            {
                Control control = Controls.Find(tarjeta, true).FirstOrDefault();
                if (LoginForm.checkLinkedServer is true)
                {
                    ConexionDB.baseDatos = "master";
                    (control as TextBox).Text = conexionDB.ObtenerValorComercioDesdeBD($"Select lpo_numcomercio from [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.vallapos where val_codigo = '{tarjeta}'").Trim();
                }
                else
                {
                    (control as TextBox).Text = conexionDB.ObtenerValorComercioDesdeBD($"Select lpo_numcomercio from vallapos where val_codigo = '{tarjeta}'").Trim();
                }
            }
        }

        private void LAPOSNET_Click(object sender, EventArgs e)
        {
            cinetPdvForm.EventoClick(sender, e);
        }

        private void btnTACOCUIT_Click(object sender, EventArgs e)
        {
            btnTACOCUIT.Tag = TACOCUIT;
            cinetPdvForm.EventoClickTxt(sender, e);

        }

        private void btnLPoPuerto_Click(object sender, EventArgs e)
        {
            btnLPoPuerto.Tag = LPoPuerto;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnTERMINAL_Click(object sender, EventArgs e)
        {
            btnTERMINAL.Tag = TERMINAL;
            cinetPdvForm.EventoClickTxt(sender, e);
        }
    }
}
