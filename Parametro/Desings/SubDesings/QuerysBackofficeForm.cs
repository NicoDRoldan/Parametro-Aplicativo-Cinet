using Parametro.Class;
using Parametro.Desings.SubDesings.QuerysGrid;
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
        DataGridBackoffice dataGridBackoffice = new DataGridBackoffice();

        public static string numVentaRut { get; set; }
        public static string numRutCorrecto { get; set; }
        public static string nroAnteriorCbtee { get; set; }

        public QuerysBackofficeForm()
        {
            InitializeComponent();
            VerificarPais();
            fechaHasta.Value = DateTime.Today;

        }

        private void VerificarPais()
        {
            Querys querys = new Querys();

            switch (ConexionDB.pais)
            {
                case "URUGUAY":
                    MostrarDatos();
                    break;
                case "PARAGUAY":
                    MostrarDatos();
                    break;
                case "BOLIVIA":
                    MostrarDatos();
                    break;
                default:
                    labelPass.Location = new Point(238, 9);
                    txtPassBotones.Location = new Point(238, 29);
                    btnAceptarPassBtn.Location = new Point(339, 29);
                    break;
            }
        }

        private void MostrarDatos()
        {
            //if (ConexionDB.pais == "URUGUAY")
            //{
            //    panelUruguay.Visible = true;
            //    btnFEAuto.Visible = true;
            //    checkConsumidorFinal.Visible = true;
            //    txtVeneNumeroRut.Visible = true;
            //    labelCorregirRut.Visible = true;
            //    btnCorregirClienteRut.Visible = true;
            //    txtRutCorrecto.Visible = true;
            //}
            if (ConexionDB.pais == "PARAGUAY")
            {
                panelParaguay.Visible = true;
                corregirPmixBtn.Enabled = true;
                //panelParaguay.Location = new Point(413, 74);
            }
            //else if (ConexionDB.pais == "BOLIVIA")
            //{
            //    panelBolivia.Location = new Point(413, 74);
            //    panelBolivia.Visible = true;
            //    CorregirCbtBo.Visible = true;
            //    btnFEAutoBo.Visible = true;
            //}
        }

        private bool ValidarPassBotones()
        {
            return (txtPassBotones.Text == "onichanfurry");
        }

        private void HabilitarBotones()
        {
            if (ValidarPassBotones() && !string.IsNullOrEmpty(txtPassBotones.Text))
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
            if (dataGridBackoffice != null && dataGridBackoffice.Visible)
            {
                dataGridBackoffice.Close();
            }
            dataGridBackoffice = new DataGridBackoffice();

            DataTable resultados = querys.ConsultaConexiones();

            dataGridBackoffice.dataGridBko.DataSource = resultados;

            dataGridBackoffice.Size = new Size(650, 300);
            dataGridBackoffice.labelResultadoQuery.Text = "Consulta de Conexiones";

            dataGridBackoffice.Show();
        }

        private void btnVerificarCaja_Click(object sender, EventArgs e)
        {
            if (dataGridBackoffice != null && dataGridBackoffice.Visible)
            {
                dataGridBackoffice.Close();
            }
            dataGridBackoffice = new DataGridBackoffice();

            DataTable resultados = querys.VerificarCaja();

            dataGridBackoffice.dataGridBko.DataSource = resultados;
            dataGridBackoffice.labelResultadoQuery.Text = "Verificar Caja";

            dataGridBackoffice.Show();
        }

        private void btnVerificarVersionLocal_Click(object sender, EventArgs e)
        {
            if (dataGridBackoffice != null && dataGridBackoffice.Visible)
            {
                dataGridBackoffice.Close();
            }
            dataGridBackoffice = new DataGridBackoffice();

            DataTable resultados = querys.VerificarVersionLocal();

            dataGridBackoffice.dataGridBko.DataSource = resultados;

            dataGridBackoffice.Size = new Size(430, 400);
            dataGridBackoffice.labelResultadoQuery.Text = "Versión de Aplicativos";

            dataGridBackoffice.Show();
        }

        private void btnVerificarVersionCaja_Click(object sender, EventArgs e)
        {
            if (vistaQuerys != null && vistaQuerys.Visible)
            {
                vistaQuerys.Close();
            }

            if (comboBoxAplicativo.Text.Length == 0)
            {
                MessageBox.Show("Seleccionar o escribir un aplicativo.");
            }
            else
            {
                vistaQuerys = new VistaQuerys();

                string aplicativo = "";

                switch (comboBoxAplicativo.Text)
                {
                    case "ActualizaDatos":
                        aplicativo = "ActualizaDatos|VERSION";
                        break;
                    case "Centralizador":
                        aplicativo = "Centralizador";
                        break;
                    case "CentralizadorComanda":
                        aplicativo = "CentralizadorComanda|Version";
                        break;
                    case "PantallaComanda":
                        aplicativo = "PantallaComanda|Version";
                        break;
                    case "Costos":
                        aplicativo = "COSTOS";
                        break;
                    case "DescargaLocal":
                        aplicativo = "DescargaLocal|VERSION";
                        break;
                    case "Informes":
                        aplicativo = "Informes";
                        break;
                    case "Informes|Version":
                        aplicativo = "Informes|Version";
                        break;
                    case "Profit":
                        aplicativo = "VERSION";
                        break;
                    case "CinetEF-OCX":
                        aplicativo = "CFOCXVERSI";
                        break;
                    case "CinetFiscalManager":
                        aplicativo = "CinetFiscalManager";
                        break;
                    case "ZonaEntrega":
                        aplicativo = "ZonaEntrega|Version";
                        break;
                    case "ZonaLlamador":
                        aplicativo = "ZonaLlamador|Version";
                        break;
                    case "TotemAPI":
                        aplicativo = "TOTEM_VERSION";
                        break;
                    case "InterfaceTotem":
                        aplicativo = "InterfaceTotem|Version";
                        break;
                    case "Totem.EXE":
                        aplicativo = "VERSIONT";
                        break;
                    case "PanelDVY":
                        aplicativo = "PanelDVY|VERSION";
                        break;
                    case "PanelMTZ":
                        aplicativo = "PanelMTZ|VERSION";
                        break;
                    case "PanelRappi":
                        aplicativo = "PanelRappi|VERSION";
                        break;
                    default:
                        aplicativo = comboBoxAplicativo.Text;
                        break;
                }

                if (dataGridBackoffice != null && dataGridBackoffice.Visible)
                {
                    dataGridBackoffice.Close();
                }
                dataGridBackoffice = new DataGridBackoffice();

                DataTable resultados = querys.VerificarVersionPorCaja(aplicativo);

                dataGridBackoffice.dataGridBko.DataSource = resultados;

                dataGridBackoffice.Size = new Size(430, 300);
                dataGridBackoffice.labelResultadoQuery.Text = $"Versión de {comboBoxAplicativo.Text}";

                dataGridBackoffice.Show();
            }
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Functions.HacerBackup();
        }

        private void corregirPmixBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("¿Seguro de qué querés ejecutar esto? Por favor, verificar antes de hacerlo." 
                , "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                querys.CorregirGeneracionPmix();
                MessageBox.Show("Corrección realizada. ¡Regenerar Product Mix!");
            }

        }
    }
}
