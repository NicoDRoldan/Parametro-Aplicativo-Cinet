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

            string[] nombreParametros = { EXTERIDMP.Name, TOKENMP.Name, MERPAGO.Name, CASHOUT.Name, IPN.Name };
            cinetPdvForm.CargarDatosParametros(this, nombreParametros);

            if (ConexionDB.usuarioBase == "dukissj")
            {
                IPN.Enabled = true;
            }

            toolTip.SetToolTip(this.labelIPNMp, "URL IPN: " + 
                conexionDB.ObtenerValorDesdeBD($"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS " +
                                                $"WHERE PARA_CODIGO = 'MP_URL_IPN'"));
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
