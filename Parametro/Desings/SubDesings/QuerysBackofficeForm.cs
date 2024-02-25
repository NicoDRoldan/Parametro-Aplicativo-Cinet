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
    public partial class QuerysBackofficeForm : Form
    {
        ConexionDB conexionDB = new ConexionDB();
        Querys querys = new Querys();
        VistaQuerys vistaQuerys = new VistaQuerys();

        public static string numVentaRut { get; set; }
        public static string numRutCorrecto { get; set; }
        public static string nroAnteriorCbtee { get; set; }

        public QuerysBackofficeForm()
        {
            InitializeComponent();

            fechaHasta.Value = DateTime.Today;

        }

        private bool ValidarPassBotones()
        {
            return (txtPassBotones.Text == "onichanfurry");
        }

        private void HabilitarBotones()
        {
            if (ValidarPassBotones() || !string.IsNullOrEmpty(txtPassBotones.Text))
            {
                panelMesa.Enabled = true;
            }
            else
            {
                panelMesa.Enabled = false;
                MessageBox.Show("Datos incorrectos");
            }
        }

        private void btnVerZetasEnCero_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            vistaQuerys = new VistaQuerys();

            DataSet resultados = querys.VerZetasEnCero(fechaDesde.Value.Date.ToString(), fechaHasta.Value.Date.ToString());

            //vistaQuerys.dataGridResultadosQuery.DataSource = resultados.DefaultView;

            if (resultados.Tables.Count >= 2)
            {
                vistaQuerys.dataGridResultadosQuery.DataSource = resultados.Tables[0].DefaultView;
                vistaQuerys.dataGridResultadosQuery2.DataSource = resultados.Tables[1].DefaultView;
                vistaQuerys.dataGridResultadosQuery2.Enabled = true;
                vistaQuerys.dataGridResultadosQuery2.Visible = true;
            }

            vistaQuerys.Show();
        }

        private void btnConsultaConexion_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            vistaQuerys = new VistaQuerys();

            DataTable resultados = querys.ConsultaConexiones();

            vistaQuerys.dataGridResultadosQuery.DataSource = resultados;
            vistaQuerys.Size = new Size(610, 50);

            vistaQuerys.Show();
        }

        private void btnAceptarPassBtn_Click(object sender, EventArgs e)
        {
            HabilitarBotones();
        }

        private void btnCorregirZetasEnCero_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            querys.CorregirZetasEnCero(fechaDesde.Value.Date.ToString(), fechaHasta.Value.Date.ToString());
        }

        private void btnReducirLogs_Click(object sender, EventArgs e)
        {
        }

        private void btnVerificarCaja_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            vistaQuerys = new VistaQuerys();

            DataTable resultados = querys.VerificarCaja();

            vistaQuerys.dataGridResultadosQuery.DataSource = resultados;
            vistaQuerys.Size = new Size(390, 50);

            vistaQuerys.Show();
        }

        private void btnVerificarVersionLocal_Click(object sender, EventArgs e)
        {
            if(vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            vistaQuerys = new VistaQuerys();

            DataTable resultados = querys.VerificarVersionLocal();

            vistaQuerys.dataGridResultadosQuery.DataSource = resultados;

            vistaQuerys.dataGridResultadosQuery2.Visible = false;
            vistaQuerys.dataGridResultadosQuery2.Enabled = false;

            // Establecer el alto de la tabla:
            vistaQuerys.dataGridResultadosQuery.Height = 400;

            vistaQuerys.Size = new Size(430, 400);

            // Establecer que la ventana vistaQuerys no se pueda agrandar ni achicar:
            vistaQuerys.FormBorderStyle = FormBorderStyle.FixedDialog;

            vistaQuerys.Show();
        }
    }
}
