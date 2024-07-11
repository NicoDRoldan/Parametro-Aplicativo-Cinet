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
        ToolTip toolTip = new ToolTip();
        Querys querys = new Querys();

        public CinetPdvForm()
        {
            InitializeComponent();

            ConexionDB.pais = querys.BasePais();

            if (ConexionDB.pais == "PARAGUAY" || ConexionDB.pais == "BOLIVIA")
            {
                btnPayWay.Enabled = false;
                btnPayWay.FlatStyle = FlatStyle.Flat;
                btnMerPago.Enabled = false;
                btnMerPago.FlatStyle = FlatStyle.Flat;
            }

            string[] nombreParametros = { SERV_DVY.Name, PEDIDOSYA.Name,
                RAPPI.Name, APP_MTZ.Name, BANDEJAS.Name, MARCHA.Name,
                DUALPOINT.Name, DNFCOPFI.Name, USATURNO1.Name, ELIGECOMA.Name,
                QRCupon.Name, SINBANDA.Name, TOTEM.Name, ZONALOCAL.Name,
                USAREMOTO.Name, ZONACAFE.Name, NOMLOCAL.Name, NUMCAJA.Name, VTAPUNTO.Name,
                CODPUERTA.Name, FAMAXVALOR.Name, RECOMANDA.Name };

            CargarDatosParametros(this, nombreParametros);
            ImagenPais();

            this.Text = conexionDB.TraerDatosEquipo(this.Text, ConexionDB.baseDatos, ConexionDB.equipoLinkedServer);

            this.FormClosed += MainForm_FormClosed;
            btnQuerys.Enabled = LoginForm.queryActivate;

            if (querysParametros.VerificarOmnicanal())
            {
                lblOmnicanalCheck.ForeColor = Color.Chartreuse;
                toolTip.SetToolTip(this.lblOmnicanalCheck, $"ACTIVADO\n" +
                    $"PARAMETRO: {conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'WSMARPATH';")}");
            }
            else
            {
                lblOmnicanalCheck.ForeColor = Color.Red;
                toolTip.SetToolTip(this.lblOmnicanalCheck, "CORROBORAR CONFIGURACIÓN\n" +
                    $"PARAMETRO: {conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'WSMARPATH';")}");
            }

            ParametrosModels.sucFiscal = VTAPUNTO.Text;
            VerificarTipoPdv();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {

        }

        public void CargarDatosParametros(Form form, string[] nombreParametros)
        {
            foreach (string nombreParametro in nombreParametros)
            {
                // Buscar el control por nombre.
                Control control = form.Controls.Find(nombreParametro, true).FirstOrDefault();
                if (control != null && control is Button) // Verificar que se encontró el control y que es un botón.
                {
                    (control as Button).Text = conexionDB.ObtenerValorDesdeBD
                            ($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{nombreParametro}'");
                }
                else if (control != null && control is TextBox) // Verificar que se encontró el control y que es un cuadro de texto.
                {
                    (control as TextBox).Text = conexionDB.ObtenerValorDesdeBD
                            ($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{nombreParametro}'");
                }
                else if (control != null && control is Label)
                {
                    (control as Label).Text = conexionDB.ObtenerValorDesdeBD
                            ($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{nombreParametro}'");
                }
            }
        }

        private void CinetPdvForm_Load(object sender, EventArgs e)
        {

        }

        public void EventoClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            querysParametros.HabilitarOUpdatearParametro(btn.Name, "", btn.Text, "UPDATE");
            btn.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{btn.Name}'");
            MessageBox.Show($"Se actualizó el parametro {btn.Name}");
        }

        public void EventoClickTxt(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)((Button)sender).Tag;

            if (txt.Text is null || txt.Text.Length == 0)
            {
                MessageBox.Show("No puede dejar el campo vacío.");
            }
            else
            {
                querysParametros.HabilitarOUpdatearParametro(txt.Name, "", txt.Text, "UPDATE");
                txt.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = '{txt.Name}'");
                MessageBox.Show($"Se actualizó el parametro {txt.Name}");
            }
        }

        public void ImagenPais()
        {
            switch (ConexionDB.pais)
            {
                case "URUGUAY":
                    btnPayWay.BackgroundImage = Properties.Resources.fiservgeocom;
                    txtConfigAuto.Enabled = true;
                    cbTipoPdv.Enabled = true;
                    btnAutoConfig.Enabled = true;
                    break;
                default:
                    break;
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

            if (VTAPUNTO.Text is null || VTAPUNTO.Text.Length == 0)
            {
                MessageBox.Show("No puede dejar el campo vacío.");
            }
            else if ((ConexionDB.pais != "PARAGUAY" && ConexionDB.pais != "BOLIVIA") && VTAPUNTO.Text.Length > 4)
            {
                MessageBox.Show("El número de punto de venta no puede ser mayor a 4.");
            }
            else
            {
                ParametrosModels.sucFiscal = VTAPUNTO.Text;
                querysParametros.ConfigurarPuntoDeVenta();

                querysParametros.ConfigurarMercadoPago();
            }
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

        #region Vistas

        private void btnPayWay_Click(object sender, EventArgs e)
        {
            switch (ConexionDB.pais)
            {
                case "URUGUAY":
                    LaposUyForm laposUyForm = new LaposUyForm();
                    laposUyForm.Show();
                    break;
                default:
                    LaposForm laposForm = new LaposForm();
                    laposForm.Show();
                    break;
            }
        }

        private void btnMerPago_Click(object sender, EventArgs e)
        {
            MercadoPagoForm mercadoPagoForm = new MercadoPagoForm();
            mercadoPagoForm.Show();
        }

        private void btnQuerys_Click(object sender, EventArgs e)
        {
            QuerysForm querysForm = new QuerysForm();
            querysForm.Show();
        }

        #endregion

        private void ZONALOCAL_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
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

        private void ZONACAFE_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void RECOMANDA_Click(object sender, EventArgs e)
        {
            EventoClick(sender, e);
        }

        private void btnAutoConfig_Click(object sender, EventArgs e)
        {
            string opcion = cbTipoPdv.Text;
            string tipoPdv;

            switch (opcion)
            {
                case "Mostrador":
                    tipoPdv = "Mostrador";
                    break;
                case "Auto - Facturador":
                    tipoPdv = "Facturador";
                    break;
                case "Auto - Tomador":
                    tipoPdv = "Tomador";
                    break;
                default:
                    MessageBox.Show("¡Seleccionar una opción valida >:L!"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            
            querys.ConfigurarAuto(tipoPdv.ToLower().Trim());
        }

        private void VerificarTipoPdv()
        {
            cbTipoPdv.Text = "Mostrador";

            if (querysParametros.VerificarExistenciaParametro("AUTOMOS")){
                string query = $"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'BOTOAUTO'";

                switch (conexionDB.ObtenerValorDesdeBD(query))
                {
                    case "1":
                        cbTipoPdv.Text = "Auto - Tomador";
                        break;
                    case "2":
                        cbTipoPdv.Text = "Auto - Facturador";
                        break;
                    default:
                        cbTipoPdv.Text = "Mostrador";
                        break;
                }
            }
        }
    }
}