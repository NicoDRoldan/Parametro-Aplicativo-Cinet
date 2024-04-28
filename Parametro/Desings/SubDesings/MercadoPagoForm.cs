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
    public partial class MercadoPagoForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();
        CinetPdvForm cinetPdvForm = new CinetPdvForm();

        ToolTip toolTip = new ToolTip();

        public MercadoPagoForm()
        {
            InitializeComponent();
            CargarDatosBtn();
            CargarDatosTxt();

            if (ConexionDB.usuarioBase == "dukissj")
            {
                IPN.Enabled = true;
            }

            toolTip.SetToolTip(this.labelIPNMp, "URL IPN: " + 
                conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS " +
                                                $"WHERE PARA_CODIGO = 'MP_URL_IPN'"));
        }

        private void CargarDatosBtn()
        {
            string[] nombreParametros = { MERPAGO.Name, CASHOUT.Name, IPN.Name };

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

        private void CargarDatosTxt()
        {
            string[] nombreParametros = { EXTERIDMP.Name, TOKENMP.Name };

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

        private void MERPAGO_Click(object sender, EventArgs e)
        {
            cinetPdvForm.EventoClick(sender, e);
        }

        private void CASHOUT_Click(object sender, EventArgs e)
        {
            cinetPdvForm.EventoClick(sender, e);
        }

        private void btnEXTERIDMP_Click(object sender, EventArgs e)
        {
            btnEXTERIDMP.Tag = EXTERIDMP;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnTOKENMP_Click(object sender, EventArgs e)
        {
            btnTOKENMP.Tag = TOKENMP;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void IPN_Click(object sender, EventArgs e)
        {
            cinetPdvForm.EventoClick(sender, e);
        }

    }
}
