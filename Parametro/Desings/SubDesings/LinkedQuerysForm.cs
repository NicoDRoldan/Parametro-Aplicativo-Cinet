using Parametro.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Parametro.Desings.SubDesings
{
    public partial class LinkedQuerysForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();
        QuerysParametros querysParametros = new QuerysParametros();

        private string BaseMaster;

        public LinkedQuerysForm()
        {
            BaseMaster = BackofficeForm.BaseMaster;
            InitializeComponent();
            conexionDB.CargarEquiposLinkedServer(lQuerysEquipoLinked);

            if (ConexionDB.usuarioBase == "dukissj") panelLinked.BackgroundImage = Properties.Resources.Reiplu;

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
                LaposForm laposForm = new LaposForm();
                laposForm.CargarNumerosComercio(this);

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
            radioLapos.Checked = false;
            radioParametros.Checked = false;

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
            radioLapos.Checked = false;

            if (lQuerysBaseDatos.Text.Length > 0)
            {
                ConexionDB.baseDatos = "master";
                ConexionDB.baseLinkedServer = lQuerysBaseDatos.Text;

                LoginForm.checkLinkedServer = true;

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

        private void lAccionParametro(string accion)
        {
            ltxtBoxParaCodigo.Clear();
            ltxtBoxParaDescripcion.Clear();
            ltxtBoxParaValor.Clear();

            switch (accion)
            {
                case "lBUSQUEDA":
                    if (!string.IsNullOrWhiteSpace(ltxtParaCodigo.Text) ||
                        !string.IsNullOrWhiteSpace(ltxtParaDescripcion.Text) ||
                        !string.IsNullOrWhiteSpace(ltxtParaValor.Text))
                    {
                        StringBuilder queryBuilder = new StringBuilder($"FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO IS NOT NULL");

                        if (checkActiveLike.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(ltxtParaCodigo.Text))
                            {
                                queryBuilder.Append($" AND PARA_CODIGO LIKE '%{ltxtParaCodigo.Text}%'");
                            }
                            if (!string.IsNullOrWhiteSpace(ltxtParaDescripcion.Text))
                            {
                                queryBuilder.Append($" AND PARA_DESCRIPCION LIKE '%{ltxtParaDescripcion.Text}%'");
                            }
                            if (!string.IsNullOrWhiteSpace(ltxtParaValor.Text))
                            {
                                queryBuilder.Append($" AND PARA_VALOR LIKE '%{ltxtParaValor.Text}%'");
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(ltxtParaCodigo.Text))
                            {
                                queryBuilder.Append($" AND PARA_CODIGO = '{ltxtParaCodigo.Text}'");
                            }
                            if (!string.IsNullOrWhiteSpace(ltxtParaDescripcion.Text))
                            {
                                queryBuilder.Append($" AND PARA_DESCRIPCION = '{ltxtParaDescripcion.Text}'");
                            }
                            if (!string.IsNullOrWhiteSpace(ltxtParaValor.Text))
                            {
                                queryBuilder.Append($" AND PARA_VALOR = '{ltxtParaValor.Text}'");
                            }
                        }

                        string query = queryBuilder.ToString();

                        if (conexionDB.ObtenerValorDesdeBD($"SELECT PARA_CODIGO {query}") != "NE"
                            && !string.IsNullOrWhiteSpace(conexionDB.ObtenerValorDesdeBD($"SELECT PARA_CODIGO {query}")))
                        {
                            ltxtBoxParaCodigo.Text = conexionDB
                                .ObtenerValorDesdeBD($"SELECT PARA_CODIGO {query}");
                            ltxtBoxParaDescripcion.Text = conexionDB
                                .ObtenerValorDesdeBD($"SELECT PARA_DESCRIPCION {query}");
                            ltxtBoxParaValor.Text = conexionDB
                                .ObtenerValorDesdeBD($"SELECT PARA_VALOR {query}");
                        }
                        else
                        {
                            MessageBox.Show("¡El parametro indicado no existe!"
                                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Completar el valor por el que queres filtrar!"
                            , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "lUPDATE":
                    if (!string.IsNullOrWhiteSpace(ltxtParaCodigo.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(ltxtParaValor.Text))
                        {
                            if (conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = '{ltxtParaCodigo.Text}';") == "NE")
                            {
                                MessageBox.Show($"No existe el párametro: {ltxtParaCodigo.Text.ToUpper()}."
                                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            querysParametros.HabilitarOUpdatearParametro(ltxtParaCodigo.Text, ltxtParaDescripcion.Text, ltxtParaValor.Text, "lUPDATE");

                            MessageBox.Show("¡Parametro Modificado!"
                                , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ltxtBoxParaCodigo.Text = conexionDB
                                .ObtenerValorDesdeBD($"select para_codigo from {conexionDB.VerificarLinkedServer()}parametros where para_codigo like '%{ltxtParaCodigo.Text}%'");
                            ltxtBoxParaValor.Text = conexionDB
                                .ObtenerValorDesdeBD($"select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo like '%{ltxtParaCodigo.Text}%'");
                            ltxtBoxParaDescripcion.Text = conexionDB
                                .ObtenerValorDesdeBD($"select para_descripcion from {conexionDB.VerificarLinkedServer()}parametros where para_codigo like '%{ltxtParaCodigo.Text}%'");
                        }
                        else
                        {
                            MessageBox.Show("¡Completar el PARA_VALOR a asignar!"
                                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Completar el PARA_CODIGO del párametro a modificar!"
                            , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "lCREATE":
                    if (!string.IsNullOrWhiteSpace(ltxtParaCodigo.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(ltxtParaValor.Text))
                        {

                            if (conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = '{ltxtParaCodigo.Text}';") != "NE")
                            {
                                MessageBox.Show($"¡El párametro {ltxtParaCodigo.Text.ToUpper()} ya existe!"
                                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            querysParametros.HabilitarOUpdatearParametro(ltxtParaCodigo.Text, ltxtParaDescripcion.Text, ltxtParaValor.Text, "lCREATE");

                            MessageBox.Show("¡Parametro Creado!"
                                , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ltxtBoxParaCodigo.Text = conexionDB
                                .ObtenerValorDesdeBD($"select para_codigo from {conexionDB.VerificarLinkedServer()}parametros where para_codigo like '%{ltxtParaCodigo.Text}%'");
                            ltxtBoxParaValor.Text = conexionDB
                                .ObtenerValorDesdeBD($"select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo like '%{ltxtParaCodigo.Text}%'");
                            ltxtBoxParaDescripcion.Text = conexionDB
                                .ObtenerValorDesdeBD($"select para_descripcion from {conexionDB.VerificarLinkedServer()}parametros where para_codigo like '%{ltxtParaCodigo.Text}%'");
                        }
                        else
                        {
                            MessageBox.Show("¡Completar el PARA_VALOR para el párametro a crear!"
                                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Completar el PARA_CODIGO del párametro a crear!"
                            , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "lDELETE":
                    if (!string.IsNullOrWhiteSpace(ltxtParaCodigo.Text))
                    {
                        if (conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = '{ltxtParaCodigo.Text}';") == "NE")
                        {
                            MessageBox.Show($"No existe el párametro: {ltxtParaCodigo.Text.ToUpper()}."
                                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        querysParametros.HabilitarOUpdatearParametro(ltxtParaCodigo.Text, ltxtParaDescripcion.Text, ltxtParaValor.Text, "lDELETE");

                        MessageBox.Show("¡Parametro Eliminado!"
                            , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("¡Completar el PARA_CODIGO del párametro a eliminar!"
                            , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }

        private void lBtnBuscarParametro_Click(object sender, EventArgs e)
        {
            lAccionParametro("lBUSQUEDA");
        }

        private void lBtnUpdaterParametro_Click(object sender, EventArgs e)
        {
            lAccionParametro("lUPDATE");
        }

        private void lBtnCreateParametro_Click(object sender, EventArgs e)
        {
            lAccionParametro("lCREATE");
        }

        private void lBtnDeleteParametro_Click(object sender, EventArgs e)
        {
            lAccionParametro("lDELETE");
        }

        private void LinkedQuerysForm_Load(object sender, EventArgs e)
        {

        }
    }
}
