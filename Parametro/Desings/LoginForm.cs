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
            traerBases(); // Llama a método para mostrar base de datos al usuario.

            // Si los items del ComboBox son mayor a 0, se cumple:
            if (comboBoxDataBase.Items.Count > 0)
            {
                isSuccess = true; // Boolean en true para confirmar la conexión.
                checkBoxLinkedServer.Enabled = true; // Se habilita Cheack Box para el usuario.
            }
        }

        private void btnConnectLinkedServer_Click(object sender, EventArgs e)
        {
            traerBasesLinkedServer();
        }

        private void traerBases()
        {
            // Las propiedades toman valor del texto escrito por el usuario.
            ConexionDB.usuarioBase = textBoxUser.Text;
            ConexionDB.connectionPass = textBoxPass.Text;
            ConexionDB.direccionIP = textBoxIp.Text;
            ConexionDB.puertoSql = textBoxPort.Text;

            cbEquipoLinkedServer.Items.Clear(); // Se limpia ComboBox.

            // Se llama al metodo para mostrar las bases de datos en el ComboBox correspondiente.
            conexionDB.CargarNombresBasesDeDatos(comboBoxDataBase);
        }

        private void traerBasesLinkedServer()
        {
            // Las propiedades toman valor del texto escrito por el usuario.
            ConexionDB.usuarioBase = textBoxUser.Text;
            ConexionDB.connectionPass = textBoxPass.Text;
            ConexionDB.direccionIP = textBoxIp.Text;
            ConexionDB.puertoSql = textBoxPort.Text;

            ConexionDB.equipoLinkedServer = cbEquipoLinkedServer.Text;
            ConexionDB.puertoLinkedServer = textBoxPortLS.Text;
            // Se llama al metodo para mostrar las bases de datos en el ComboBox correspondiente.
            conexionDB.CargarNombresBasesDeDatos(comboBoxDataBase, cbEquipoLinkedServer.Text, textBoxPortLS.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConexionDB.baseDatos = comboBoxDataBase.Text.Trim();
            ConexionDB.baseLikedServer = comboBoxDataBase.Text.Trim();
            baseDatosLinkedServer = comboBoxDataBase.Text.Trim();

            if (checkBoxLinkedServer.Checked)
            {
                ConexionDB.baseDatos = "master";
                checkLinkedServer = true;
            }
            else
                checkLinkedServer = false;

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
            // Si el Check Box es true y la conexión fue exitosa.
            if (checkBoxLinkedServer.Checked is true && isSuccess == true)
            {
                // Se traen las bases de datos del servidor "Linkeado".
                conexionDB.CargarEquiposLinkedServer(cbEquipoLinkedServer);
                // Se habilitan opciones del diseño.
                cbEquipoLinkedServer.Enabled = true;
                textBoxPortLS.Enabled = true;
                btnConnectLinkedServer.Enabled = true;
            }
            else
            {
                // Se deshabilitan opciones y se limpia el Combo Box correspondiente.
                cbEquipoLinkedServer.Enabled = false;
                textBoxPortLS.Enabled = false;
                btnConnectLinkedServer.Enabled = false;
                cbEquipoLinkedServer.Text = string.Empty;
                comboBoxDataBase.Text = string.Empty;
                comboBoxDataBase.Items.Clear();
                cbEquipoLinkedServer.Items.Clear ();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
