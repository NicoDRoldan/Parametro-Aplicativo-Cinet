namespace Parametro.Desings
{
    partial class VistaQuerys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            notifyIcon1 = new NotifyIcon(components);
            dataGridResultadosQuery = new DataGridView();
            dataGridResultadosQuery2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridResultadosQuery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridResultadosQuery2).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // dataGridResultadosQuery
            // 
            dataGridResultadosQuery.AllowUserToAddRows = false;
            dataGridResultadosQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridResultadosQuery.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridResultadosQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridResultadosQuery.Dock = DockStyle.Top;
            dataGridResultadosQuery.Location = new Point(0, 0);
            dataGridResultadosQuery.Name = "dataGridResultadosQuery";
            dataGridResultadosQuery.ReadOnly = true;
            dataGridResultadosQuery.RowTemplate.Height = 25;
            dataGridResultadosQuery.Size = new Size(1094, 167);
            dataGridResultadosQuery.TabIndex = 0;
            dataGridResultadosQuery.CellContentClick += dataGridResultadosQuery_CellContentClick;
            // 
            // dataGridResultadosQuery2
            // 
            dataGridResultadosQuery2.AllowUserToAddRows = false;
            dataGridResultadosQuery2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridResultadosQuery2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridResultadosQuery2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridResultadosQuery2.Dock = DockStyle.Bottom;
            dataGridResultadosQuery2.Enabled = false;
            dataGridResultadosQuery2.Location = new Point(0, 167);
            dataGridResultadosQuery2.Name = "dataGridResultadosQuery2";
            dataGridResultadosQuery2.ReadOnly = true;
            dataGridResultadosQuery2.RowTemplate.Height = 25;
            dataGridResultadosQuery2.Size = new Size(1094, 76);
            dataGridResultadosQuery2.TabIndex = 1;
            dataGridResultadosQuery2.Visible = false;
            // 
            // VistaQuerys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1094, 243);
            Controls.Add(dataGridResultadosQuery2);
            Controls.Add(dataGridResultadosQuery);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VistaQuerys";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Querys";
            ((System.ComponentModel.ISupportInitialize)dataGridResultadosQuery).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridResultadosQuery2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        public DataGridView dataGridResultadosQuery;
        public DataGridView dataGridResultadosQuery2;
    }
}