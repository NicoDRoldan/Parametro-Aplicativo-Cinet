namespace Parametro.Desings.SubDesings.QuerysGrid
{
    partial class DataGridBackoffice
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
            dataGridBko = new DataGridView();
            panel3 = new Panel();
            panel4 = new Panel();
            panel6 = new Panel();
            labelResultadoQuery = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridBko).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridBko
            // 
            dataGridBko.AllowUserToAddRows = false;
            dataGridBko.AllowUserToDeleteRows = false;
            dataGridBko.AllowUserToOrderColumns = true;
            dataGridBko.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridBko.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridBko.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBko.Dock = DockStyle.Fill;
            dataGridBko.Location = new Point(0, 0);
            dataGridBko.Name = "dataGridBko";
            dataGridBko.ReadOnly = true;
            dataGridBko.RowTemplate.Height = 25;
            dataGridBko.Size = new Size(331, 232);
            dataGridBko.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(331, 257);
            panel3.TabIndex = 34;
            // 
            // panel4
            // 
            panel4.Controls.Add(dataGridBko);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(331, 232);
            panel4.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.MenuHighlight;
            panel6.Controls.Add(labelResultadoQuery);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(331, 25);
            panel6.TabIndex = 0;
            // 
            // labelResultadoQuery
            // 
            labelResultadoQuery.AutoSize = true;
            labelResultadoQuery.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelResultadoQuery.ForeColor = SystemColors.ButtonHighlight;
            labelResultadoQuery.Location = new Point(12, 5);
            labelResultadoQuery.Name = "labelResultadoQuery";
            labelResultadoQuery.Size = new Size(123, 17);
            labelResultadoQuery.TabIndex = 1;
            labelResultadoQuery.Text = "RESULTADO - QUERY";
            // 
            // DataGridBackoffice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(331, 257);
            Controls.Add(panel3);
            MaximizeBox = false;
            Name = "DataGridBackoffice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RESULTADO - QUERY";
            ((System.ComponentModel.ISupportInitialize)dataGridBko).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public DataGridView dataGridBko;
        private Panel panel3;
        private Panel panel4;
        private Panel panel6;
        public Label labelResultadoQuery;
    }
}