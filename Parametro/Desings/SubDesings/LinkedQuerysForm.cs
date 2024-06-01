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
    public partial class LinkedQuerysForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();

        private string BaseMaster;

        public LinkedQuerysForm()
        {
            BaseMaster = BackofficeForm.BaseMaster;
            InitializeComponent();
            conexionDB.CargarEquiposLinkedServer(lQuerysEquipoLinked);
            this.FormClosing += LinkedQuerysForm_FormClosing;
        }

        private void radioParametros_CheckedChanged(object sender, EventArgs e)
        {
            if (radioParametros.Checked)
            {
                panelParametros.Visible = true;
                panelParametros.Enabled = true;
            }
            else
            {
                panelParametros.Visible = false;
                panelParametros.Enabled = false;
            }
        }

        private void radioLapos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLapos.Checked)
            {
                panelLapos.Location = new Point(143, 5);
                panelLapos.Visible = true;
                panelLapos.Enabled = true;
            }
            else
            {
                panelLapos.Visible = false;
                panelLapos.Enabled = false;
            }
        }

        private void btnConnectLinkedServer_Click(object sender, EventArgs e)
        {
            TraerBasesLinkedServer();
        }

        private void TraerBasesLinkedServer()
        {
            if (lQuerysEquipoLinked.Text.Length > 0)
            {
                ConexionDB.equipoLinkedServer = lQuerysEquipoLinked.Text;
                ConexionDB.puertoLinkedServer = lQuerysPuertoLinked.Text;

                lLabelConnectState.Text = "Desconectado";
                lLabelConnectState.ForeColor = Color.Red;

                lQuerysBaseDatos.Text = "";

                // Deshabilitar campos
                radioParametros.Enabled = false;
                radioLapos.Enabled = false;
                LoginForm.checkLinkedServer = false;

                LoginForm.checkLinkedServer = true;

                conexionDB.TraerBasesDeDatos(lQuerysBaseDatos, true);

                if (lQuerysBaseDatos.Items.Count > 0)
                {
                    // Habilitar campos
                    lQuerysBaseDatos.Enabled = true;
                    btnConnectBase.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("¡Elegir un equipo!");
            }
        }

        private void btnConnectBase_Click(object sender, EventArgs e)
        {
            ConectarBaseDeDatos();
        }

        private void ConectarBaseDeDatos()
        {
            if (lQuerysBaseDatos.Text.Length > 0)
            {
                ConexionDB.baseDatos = "master";
                ConexionDB.baseLinkedServer = lQuerysBaseDatos.Text;

                LoginForm.checkLinkedServer = true;

                LaposForm laposForm = new LaposForm();
                laposForm.CargarNumerosComercio(this);

                // Habilitar campos
                radioParametros.Enabled = true;
                radioLapos.Enabled = true;

                lLabelConnectState.Text = $"Conectado {ConexionDB.equipoLinkedServer}";
                lLabelConnectState.ForeColor = Color.Chartreuse;
            }
            else
            {
                MessageBox.Show("¡Elegir una base de datos!");
            }
        }

        private void LinkedQuerysForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (BaseMaster != null) ConexionDB.baseDatos = BaseMaster;
            LoginForm.checkLinkedServer = false;
        }

        private void btnGuardarNrosComercio_Click_1(object sender, EventArgs e)
        {
            LaposForm laposForm = new LaposForm();

            string[,] nombreTarjetas = {
                { "AMEX", AMEX.Text},
                { "VISA", Visa.Text},
                { "MASTER", MASTER.Text},
                { "CABALDEB", CABALDEB.Text},
                { "TNARANJA", TNARANJA.Text}
            };

            laposForm.ConfigurarComercios(nombreTarjetas);
            laposForm.CargarNumerosComercio(this);
        }

        private void LinkedQuerysForm_Load(object sender, EventArgs e)
        {

        }
    }
}
