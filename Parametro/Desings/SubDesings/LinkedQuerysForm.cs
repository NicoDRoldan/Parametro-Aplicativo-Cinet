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
    public partial class LinkedQuerysForm : Form
    {
        public LinkedQuerysForm()
        {
            InitializeComponent();
        }

        private void radioParametros_CheckedChanged(object sender, EventArgs e)
        {
            if(radioParametros.Checked)
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
    }
}
