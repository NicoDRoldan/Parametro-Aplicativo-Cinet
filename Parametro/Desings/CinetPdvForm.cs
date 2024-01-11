using Parametro.Class;
using Parametro.Desings;
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
    public partial class CinetPdvForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();
        QuerysParametros querysParametros = new QuerysParametros();

        public CinetPdvForm()
        {
            InitializeComponent();
            CargarDatosBtn();
            CargarDatosTxt();

            this.Text = conexionDB.TraerDatosEquipo(this.Text, ConexionDB.baseDatos, ConexionDB.equipoLinkedServer);

            this.FormClosed += MainForm_FormClosed;
            btnQuerys.Enabled = LoginForm.queryActivate;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {

        }

        public void CargarDatosBtn()
        {
            string[] nombreParametros = { SERV_DVY.Name, PEDIDOSYA.Name,
                RAPPI.Name, APP_MTZ.Name, BANDEJAS.Name, MARCHA.Name,
                DUALPOINT.Name, DNFCOPFI.Name, USATURNO1.Name, ELIGECOMA.Name,
                QRCupon.Name, SINBANDA.Name, TOTEM.Name, ZONALOCAL.Name,
                USAREMOTO.Name};

            foreach (string nombreParametro in nombreParametros)
            {
                // Buscar el control por nombre.
                Control control = Controls.Find(nombreParametro, true).FirstOrDefault();
                // Verificar que se encontró el control y que es un botón.
                if (control != null && control is Button)
                {
                    if (LoginForm.checkLinkedServer is true)
                    {
                        ConexionDB.baseDatos = "master";
                        (control as Button).Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros where para_codigo = '{nombreParametro}'");
                    }
                    else
                    {
                        (control as Button).Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from parametros where para_codigo = '{nombreParametro}'");
                    }
                }
            }
        }

        public void CargarDatosTxt()
        {
            string[] nombreParametros = {NOMLOCAL.Name, NUMCAJA.Name, VTAPUNTO.Name,
                CODPUERTA.Name, FAMAXVALOR.Name};

            foreach (string nombreParametro in nombreParametros)
            {
                // Buscar el control por nombre.
                Control control = Controls.Find(nombreParametro, true).FirstOrDefault();
                // Verificar que se encontró el control y que es un botón.
                if (control != null && control is TextBox)
                {
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
        }

        private void CinetPdvForm_Load(object sender, EventArgs e)
        {

        }

        public void EventoClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Llamo al metodo con los párametros

            if (LoginForm.checkLinkedServer is true)
            {
                querysParametros.HabilitarParametro(btn.Name, "", btn.Text, ConexionDB.equipoLinkedServer, ConexionDB.puertoLinkedServer, LoginForm.baseDatosLinkedServer);
                btn.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros where para_codigo = '{btn.Name}'");
            }
            else
            {
                querysParametros.HabilitarParametro(btn.Name, "", btn.Text);
                btn.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from parametros where para_codigo = '{btn.Name}'");
            }
        }

        public void EventoClickTxt(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)((Button)sender).Tag;

            // Llamo al metodo con los párametros

            if (LoginForm.checkLinkedServer is true)
            {
                querysParametros.UpdateParametro(txt.Name, "", txt.Text, ConexionDB.equipoLinkedServer, ConexionDB.puertoLinkedServer, LoginForm.baseDatosLinkedServer);
                txt.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros where para_codigo = '{txt.Name}'");
            }
            else
            {
                querysParametros.UpdateParametro(txt.Name, "", txt.Text);
                txt.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from parametros where para_codigo = '{txt.Name}'");
            }
        }

        #region Botones

        private void SERV_DVY_Click_1(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void PEDIDOSYA_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void RAPPI_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void APP_MTZ_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void SucFiscal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSucFiscal_Click(object sender, EventArgs e)
        {
            ParametrosModels.sucFiscal = VTAPUNTO.Text;
            querysParametros.ConfigurarPuntoDeVenta();

            querysParametros.ConfigurarMercadoPago();
        }

        private void btnCodLocal_Click(object sender, EventArgs e)
        {
            btnCodLocal.Tag = NOMLOCAL;
            EventoClickTxt(sender, e);

            querysParametros.ConfigurarMercadoPago();
        }

        private void btnNumCaja_Click(object sender, EventArgs e)
        {
            btnNumCaja.Tag = NUMCAJA;
            EventoClickTxt(sender, e);
        }

        private void btnCODPUERTA_Click(object sender, EventArgs e)
        {
            btnCODPUERTA.Tag = CODPUERTA;
            EventoClickTxt(sender, e);
        }

        private void BANDEJAS_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void MARCHA_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void DUALPOINT_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void DNFCOPFI_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void USATURNO1_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void ELIGECOMA_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void QRCupon_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void SINBANDA_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void TOTEM_Click(object sender, EventArgs e)
        {
            querysParametros.UpdateParametrosTotem();

            TOTEM.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{TOTEM.Name}'");
        }

        private void btnPayWay_Click(object sender, EventArgs e)
        {
            LaposForm laposForm = new LaposForm();
            laposForm.Show();
        }

        private void btnMerPago_Click(object sender, EventArgs e)
        {
            MercadoPagoForm mercadoPagoForm = new MercadoPagoForm();
            mercadoPagoForm.Show();
        }

        private void ZONALOCAL_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void btnQuerys_Click(object sender, EventArgs e)
        {
            QuerysForm querysForm = new QuerysForm();
            querysForm.Show();
        }

        private void USAREMOTO_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void btnFAMAXVALOR_Click(object sender, EventArgs e)
        {
            btnFAMAXVALOR.Tag = FAMAXVALOR;
            EventoClickTxt(sender, e);
        }
        #endregion
    }
}