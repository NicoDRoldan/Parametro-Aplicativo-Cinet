using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parametro.Class;

namespace Parametro.Desings.SubDesings
{
    public partial class LaposUyForm : Form
    {
        Querys querys = new Querys();
        QuerysParametros querysParametros = new QuerysParametros();
        ConexionDB conexionDB = new ConexionDB();
        CinetPdvForm cinetPdvForm = new CinetPdvForm();

        public LaposUyForm()
        {
            InitializeComponent();

            string[] nombreParametros = { LAPOSUY.Name, IDCLIENTE.Name, TERMINAL.Name };
            cinetPdvForm.CargarDatosParametros(this, nombreParametros);
        }

        private void LaposActivoBtn_Click(object sender, EventArgs e)
        {
            querysParametros.HabilitarOUpdatearParametro("LAPOSNET", "Usa posnet Integrado", LAPOSUY.Text);
            querysParametros.HabilitarOUpdatearParametro("LAPOSUY", "Usa posnet Integrado", LAPOSUY.Text);
            LAPOSUY.Text = conexionDB.ObtenerValorDesdeBD($"Select para_valor from {conexionDB.VerificarLinkedServer()}parametros where para_codigo = 'LAPOSNET'");
        }

        private void btnTERMINAL_Click(object sender, EventArgs e)
        {
            btnTERMINAL.Tag = TERMINAL;
            cinetPdvForm.EventoClickTxt(sender, e);
        }

        private void btnIDCLIENTE_Click(object sender, EventArgs e)
        {
            btnIDCLIENTE.Tag = IDCLIENTE;
            cinetPdvForm.EventoClickTxt(sender, e);
        }
    }
}
