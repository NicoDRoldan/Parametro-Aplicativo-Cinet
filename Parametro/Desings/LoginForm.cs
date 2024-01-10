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

namespace Parametro.Desings
{
    public partial class LoginForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();

        private bool isSuccess = false;
        public static bool checkLinkedServer = false;
        public static string baseDatosLinkedServer;
        public static bool queryActivate = true;

        public LoginForm()
        {
            InitializeComponent();
            textBoxEquipoLinkedServer.Enabled = false;
            textBoxPortLS.Enabled = false;
            btnConnectLinkedServer.Enabled = false;
            checkBoxLinkedServer.Enabled = false;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            traerBases();
            if (comboBoxDataBase.Items.Count > 0)
            {
                isSuccess = true;
                checkBoxLinkedServer.Enabled = true;
            }
        }

        private void btnConnectLinkedServer_Click(object sender, EventArgs e)
        {
            traerBasesLinkedServer();
            checkLinkedServer = true;
        }

        private void traerBases()
        {
            ConexionDB.usuarioBase = textBoxUser.Text;
            ConexionDB.connectionPass = textBoxPass.Text;
            ConexionDB.direccionIP = textBoxIp.Text;
            ConexionDB.puertoSql = textBoxPort.Text;

            conexionDB.CargarNombresBasesDeDatos(comboBoxDataBase);
        }

        private void traerBasesLinkedServer()
        {
            ConexionDB.usuarioBase = textBoxUser.Text;
            ConexionDB.connectionPass = textBoxPass.Text;
            ConexionDB.direccionIP = textBoxIp.Text;
            ConexionDB.puertoSql = textBoxPort.Text;

            ConexionDB.equipoLinkedServer = textBoxEquipoLinkedServer.Text;
            ConexionDB.puertoLinkedServer = textBoxPortLS.Text;

            conexionDB.CargarNombresBasesDeDatos(comboBoxDataBase, textBoxEquipoLinkedServer.Text, textBoxPortLS.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConexionDB.baseDatos = comboBoxDataBase.Text.Trim();
            baseDatosLinkedServer = comboBoxDataBase.Text.Trim();

            ValidarBaseDeDatos();
        }

        private void ValidarBaseDeDatos()
        {
            CinetPdvForm cinetPdvForm = new CinetPdvForm();
            BackofficeForm backofficeForm = new BackofficeForm();

            var opcion = comboBoxDataBase.Text.Trim();

            switch (opcion.ToLower())
            {
                case "backoffice":
                    backofficeForm.Show();
                    this.Hide();
                    break;
                case "cinet_pdv":
                    cinetPdvForm.Show();
                    this.Hide();
                    break;
                case "cinet_pdv_auto":
                    cinetPdvForm.Show();
                    this.Hide();
                    break;
                case "cinet_pdv_totem":
                    cinetPdvForm.Show();
                    this.Hide();
                    break;
                default:
                    cinetPdvForm.Show();
                    this.Hide();
                    break;
            }
        }

        private void textBoxIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPortLS_TextChanged(object sender, EventArgs e)
        {

        }

        public void checkBoxLinkedServer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLinkedServer.Checked is true && isSuccess == true)
            {
                textBoxEquipoLinkedServer.Enabled = true;
                textBoxPortLS.Enabled = true;
                btnConnectLinkedServer.Enabled = true;
            }
            else
            {
                textBoxEquipoLinkedServer.Enabled = false;
                textBoxPortLS.Enabled = false;
                btnConnectLinkedServer.Enabled = false;
            }
        }

        private void textBoxEquipoLinkedServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnQueryActivate_Click(object sender, EventArgs e)
        {
            if (textBoxIp.Text == "onichanfurri2.0")
            {
                queryActivate = true;
            }
        }

    }
}
