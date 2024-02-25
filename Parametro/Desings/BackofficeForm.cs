using Parametro.Class;
using Parametro.Desings.SubDesings;
using Parametro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Parametro.Desings
{
    public partial class BackofficeForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();
        QuerysParametros querysParametros = new QuerysParametros();
        VistaQuerys vista = new VistaQuerys();
        CinetPdvForm cinetPdvForm = new CinetPdvForm();

        public BackofficeForm()
        {
            InitializeComponent();
            CargarDatos();
            CargarDatosTxt();
            ValidarActivoCafe();

            this.Text = conexionDB.TraerDatosEquipo(this.Text, ConexionDB.baseDatos, ConexionDB.equipoLinkedServer);

            btnQuerysBko.Enabled = true;

            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CargarDatos()
        {
            string[] nombreParametros = { "STOREIDRAP" };

            foreach (string nombreParametro in nombreParametros)
            {
                // Buscar el control por nombre.
                Control control = Controls.Find(nombreParametro, true).FirstOrDefault();
                // Verificar que se encontró el control y que es un botón.
                if (LoginForm.checkLinkedServer is true)
                {
                    ConexionDB.baseDatos = "master";
                    (control as TextBox).Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros where para_codigo = '{nombreParametro}'");
                }
                else
                {
                    (control as TextBox).Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from parametros where para_codigo = '{nombreParametro}'");
                }
            }
        }

        public void CargarDatosTxt()
        {
            string[] nombreParametros = {NOMLOCAL.Name, FAMAXVALOR.Name, MAXARQUEOF.Name,
                                            UPDRUTA.Name, EQUIPOUPD.Name, PASS_MTZ.Name, UNAME_MTZ.Name};

            foreach (string nombreParametro in nombreParametros)
            {
                Control control = Controls.Find(nombreParametro, true).FirstOrDefault();
                if (control != null && control is TextBox)
                {
                    (control as TextBox).Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{nombreParametro}'");
                }
            }
        }

        private void EventoClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from parametros where para_codigo = '{btn.Name}'");
        }

        private void BtnConfigurarRap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(STOREIDRAP.Text))
            {
                if (vista != null && vista.Visible)
                {
                    vista.Close();
                }

                vista = new VistaQuerys();

                ParametrosModels.StoreIdRap = STOREIDRAP.Text;

                ValidarTiendaCafe();

                DataTable resultados = querysParametros.ConfigurarRappiV2();

                vista.dataGridResultadosQuery.DataSource = resultados;
                vista.Show();
            }
            else
            {
                MessageBox.Show("Ingresá un ID.");
            }
        }

        private void ValidarTiendaCafe()
        {
            if (CheckTiendaCafe.Checked == true)
            {
                ParametrosModels.UsaCafe = "S";
            }
            else
            {
                ParametrosModels.UsaCafe = "N";
            }
        }

        private void ValidarActivoCafe()
        {
            if (querysParametros.RappiCafeActivo() is true)
            {
                CheckTiendaCafe.Checked = true;
            }
            else
            {
                CheckTiendaCafe.Checked = false;
            }
        }

        #region BOTONES

        private void STOREIDRAP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCodLocal_Click(object sender, EventArgs e)
        {
            btnCodLocal.Tag = NOMLOCAL;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnPASS_MTZ_Click(object sender, EventArgs e)
        {
            btnPASS_MTZ.Tag = PASS_MTZ;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnUNAME_MTZ_Click(object sender, EventArgs e)
        {
            btnUNAME_MTZ.Tag = UNAME_MTZ;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnEQUIPOUPD_Click(object sender, EventArgs e)
        {
            btnEQUIPOUPD.Tag = EQUIPOUPD;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnUPDRUTA_Click(object sender, EventArgs e)
        {
            btnUPDRUTA.Tag = UPDRUTA;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnFAMAXVALOR_Click(object sender, EventArgs e)
        {
            btnFAMAXVALOR.Tag = FAMAXVALOR;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnMAXARQUEOF_Click(object sender, EventArgs e)
        {
            btnMAXARQUEOF.Tag = MAXARQUEOF;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        #endregion

        private void btnQuerysBko_Click(object sender, EventArgs e)
        {
            QuerysBackofficeForm querysBackofficeForm = new QuerysBackofficeForm();
            querysBackofficeForm.Show();
        }
    }
}
