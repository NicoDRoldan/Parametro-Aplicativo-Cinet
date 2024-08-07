﻿namespace Parametro.Desings.SubDesings
{
    partial class QuerysBackofficeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuerysBackofficeForm));
            panel5 = new Panel();
            txtPassBotones = new TextBox();
            btnAceptarPassBtn = new Button();
            fechaHasta = new DateTimePicker();
            fechaDesde = new DateTimePicker();
            labelPass = new Label();
            label4 = new Label();
            label3 = new Label();
            panelMesa = new Panel();
            panel1 = new Panel();
            btnCorregirZetasEnCero = new Button();
            label2 = new Label();
            btnVerZetasEnCero = new Button();
            panel2 = new Panel();
            label20 = new Label();
            panel3 = new Panel();
            panelMantenimiento = new Panel();
            btnVerificarSizeTables = new Button();
            button1 = new Button();
            btnVerificarCaja = new Button();
            btnConsultaConexion = new Button();
            btnReducirLogs = new Button();
            panel6 = new Panel();
            label5 = new Label();
            btnVerificarVersionCaja = new Button();
            panel7 = new Panel();
            panelVersiones = new Panel();
            btnVerificarVersionLocal = new Button();
            label7 = new Label();
            comboBoxAplicativo = new ComboBox();
            label6 = new Label();
            panel9 = new Panel();
            label1 = new Label();
            panelBackup = new Panel();
            panel11 = new Panel();
            label8 = new Label();
            btnBackup = new Button();
            panelParaguay = new Panel();
            label10 = new Label();
            panel13 = new Panel();
            label9 = new Label();
            corregirPmixBtn = new Button();
            panel5.SuspendLayout();
            panelMesa.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panelMantenimiento.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panelVersiones.SuspendLayout();
            panel9.SuspendLayout();
            panelBackup.SuspendLayout();
            panel11.SuspendLayout();
            panelParaguay.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlLight;
            panel5.Controls.Add(txtPassBotones);
            panel5.Controls.Add(btnAceptarPassBtn);
            panel5.Controls.Add(fechaHasta);
            panel5.Controls.Add(fechaDesde);
            panel5.Controls.Add(labelPass);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(649, 68);
            panel5.TabIndex = 34;
            // 
            // txtPassBotones
            // 
            txtPassBotones.Location = new Point(238, 31);
            txtPassBotones.Name = "txtPassBotones";
            txtPassBotones.PasswordChar = '#';
            txtPassBotones.Size = new Size(95, 23);
            txtPassBotones.TabIndex = 3;
            txtPassBotones.UseSystemPasswordChar = true;
            // 
            // btnAceptarPassBtn
            // 
            btnAceptarPassBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptarPassBtn.Location = new Point(338, 31);
            btnAceptarPassBtn.Name = "btnAceptarPassBtn";
            btnAceptarPassBtn.Size = new Size(68, 23);
            btnAceptarPassBtn.TabIndex = 4;
            btnAceptarPassBtn.Text = "ACEPTAR";
            btnAceptarPassBtn.UseVisualStyleBackColor = true;
            btnAceptarPassBtn.Click += btnAceptarPassBtn_Click;
            // 
            // fechaHasta
            // 
            fechaHasta.CustomFormat = "";
            fechaHasta.Format = DateTimePickerFormat.Short;
            fechaHasta.Location = new Point(99, 29);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(81, 23);
            fechaHasta.TabIndex = 2;
            fechaHasta.Value = new DateTime(2023, 12, 12, 0, 0, 0, 0);
            // 
            // fechaDesde
            // 
            fechaDesde.CustomFormat = "";
            fechaDesde.Format = DateTimePickerFormat.Short;
            fechaDesde.Location = new Point(12, 29);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(81, 23);
            fechaDesde.TabIndex = 1;
            fechaDesde.Value = new DateTime(2023, 12, 11, 0, 0, 0, 0);
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelPass.ForeColor = SystemColors.ActiveCaptionText;
            labelPass.Location = new Point(238, 11);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(79, 17);
            labelPass.TabIndex = 29;
            labelPass.Text = "PASSWORD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(99, 9);
            label4.Name = "label4";
            label4.Size = new Size(46, 17);
            label4.TabIndex = 27;
            label4.Text = "HASTA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(48, 17);
            label3.TabIndex = 25;
            label3.Text = "DESDE";
            // 
            // panelMesa
            // 
            panelMesa.BackColor = Color.White;
            panelMesa.Controls.Add(panel1);
            panelMesa.Controls.Add(panel2);
            panelMesa.Enabled = false;
            panelMesa.Location = new Point(743, 81);
            panelMesa.Name = "panelMesa";
            panelMesa.Size = new Size(206, 104);
            panelMesa.TabIndex = 32;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCorregirZetasEnCero);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnVerZetasEnCero);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 79);
            panel1.TabIndex = 1;
            // 
            // btnCorregirZetasEnCero
            // 
            btnCorregirZetasEnCero.Enabled = false;
            btnCorregirZetasEnCero.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCorregirZetasEnCero.Location = new Point(106, 27);
            btnCorregirZetasEnCero.Name = "btnCorregirZetasEnCero";
            btnCorregirZetasEnCero.Size = new Size(92, 44);
            btnCorregirZetasEnCero.TabIndex = 6;
            btnCorregirZetasEnCero.Text = "CORREGIR Z's en 0";
            btnCorregirZetasEnCero.UseVisualStyleBackColor = true;
            btnCorregirZetasEnCero.Visible = false;
            btnCorregirZetasEnCero.Click += btnCorregirZetasEnCero_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(8, 3);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 23;
            label2.Text = "Z's en 0 (cero)";
            // 
            // btnVerZetasEnCero
            // 
            btnVerZetasEnCero.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerZetasEnCero.Location = new Point(8, 27);
            btnVerZetasEnCero.Name = "btnVerZetasEnCero";
            btnVerZetasEnCero.Size = new Size(92, 44);
            btnVerZetasEnCero.TabIndex = 5;
            btnVerZetasEnCero.Text = "VER Z's EN 0";
            btnVerZetasEnCero.UseVisualStyleBackColor = true;
            btnVerZetasEnCero.Click += btnVerZetasEnCero_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label20);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(206, 25);
            panel2.TabIndex = 0;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label20.ForeColor = SystemColors.ButtonHighlight;
            label20.Location = new Point(83, 4);
            label20.Name = "label20";
            label20.Size = new Size(41, 17);
            label20.TabIndex = 1;
            label20.Text = "ZETAS";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panelMantenimiento);
            panel3.Controls.Add(panel6);
            panel3.Location = new Point(12, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(206, 247);
            panel3.TabIndex = 33;
            // 
            // panelMantenimiento
            // 
            panelMantenimiento.Controls.Add(btnVerificarSizeTables);
            panelMantenimiento.Controls.Add(button1);
            panelMantenimiento.Controls.Add(btnVerificarCaja);
            panelMantenimiento.Controls.Add(btnConsultaConexion);
            panelMantenimiento.Controls.Add(btnReducirLogs);
            panelMantenimiento.Dock = DockStyle.Fill;
            panelMantenimiento.Location = new Point(0, 25);
            panelMantenimiento.Name = "panelMantenimiento";
            panelMantenimiento.Size = new Size(206, 222);
            panelMantenimiento.TabIndex = 1;
            // 
            // btnVerificarSizeTables
            // 
            btnVerificarSizeTables.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarSizeTables.Location = new Point(8, 57);
            btnVerificarSizeTables.Name = "btnVerificarSizeTables";
            btnVerificarSizeTables.Size = new Size(92, 44);
            btnVerificarSizeTables.TabIndex = 30;
            btnVerificarSizeTables.Text = "Tamaño de Tablas";
            btnVerificarSizeTables.UseVisualStyleBackColor = true;
            btnVerificarSizeTables.Click += btnVerificarSizeTables_Click;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(106, 173);
            button1.Name = "button1";
            button1.Size = new Size(92, 44);
            button1.TabIndex = 29;
            button1.Text = "Reorg";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // btnVerificarCaja
            // 
            btnVerificarCaja.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarCaja.Location = new Point(106, 7);
            btnVerificarCaja.Name = "btnVerificarCaja";
            btnVerificarCaja.Size = new Size(92, 44);
            btnVerificarCaja.TabIndex = 8;
            btnVerificarCaja.Text = "Verificar Caja";
            btnVerificarCaja.UseVisualStyleBackColor = true;
            btnVerificarCaja.Click += btnVerificarCaja_Click;
            // 
            // btnConsultaConexion
            // 
            btnConsultaConexion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnConsultaConexion.Location = new Point(8, 7);
            btnConsultaConexion.Name = "btnConsultaConexion";
            btnConsultaConexion.Size = new Size(92, 44);
            btnConsultaConexion.TabIndex = 7;
            btnConsultaConexion.Text = "Consulta Conexiones";
            btnConsultaConexion.UseVisualStyleBackColor = true;
            btnConsultaConexion.Click += btnConsultaConexion_Click;
            // 
            // btnReducirLogs
            // 
            btnReducirLogs.Enabled = false;
            btnReducirLogs.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnReducirLogs.Location = new Point(8, 173);
            btnReducirLogs.Name = "btnReducirLogs";
            btnReducirLogs.Size = new Size(92, 44);
            btnReducirLogs.TabIndex = 28;
            btnReducirLogs.Text = "Reducir Log's";
            btnReducirLogs.UseVisualStyleBackColor = true;
            btnReducirLogs.Visible = false;
            btnReducirLogs.Click += btnReducirLogs_Click;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.MenuHighlight;
            panel6.Controls.Add(label5);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(206, 25);
            panel6.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(51, 4);
            label5.Name = "label5";
            label5.Size = new Size(104, 17);
            label5.TabIndex = 1;
            label5.Text = "MANTENIMIENTO";
            // 
            // btnVerificarVersionCaja
            // 
            btnVerificarVersionCaja.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarVersionCaja.Location = new Point(107, 25);
            btnVerificarVersionCaja.Name = "btnVerificarVersionCaja";
            btnVerificarVersionCaja.Size = new Size(92, 23);
            btnVerificarVersionCaja.TabIndex = 10;
            btnVerificarVersionCaja.Text = "Aceptar";
            btnVerificarVersionCaja.UseVisualStyleBackColor = true;
            btnVerificarVersionCaja.Click += btnVerificarVersionCaja_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(panelVersiones);
            panel7.Controls.Add(panel9);
            panel7.Location = new Point(224, 81);
            panel7.Name = "panel7";
            panel7.Size = new Size(206, 135);
            panel7.TabIndex = 34;
            // 
            // panelVersiones
            // 
            panelVersiones.Controls.Add(btnVerificarVersionLocal);
            panelVersiones.Controls.Add(label7);
            panelVersiones.Controls.Add(comboBoxAplicativo);
            panelVersiones.Controls.Add(btnVerificarVersionCaja);
            panelVersiones.Controls.Add(label6);
            panelVersiones.Dock = DockStyle.Fill;
            panelVersiones.Location = new Point(0, 25);
            panelVersiones.Name = "panelVersiones";
            panelVersiones.Size = new Size(206, 110);
            panelVersiones.TabIndex = 1;
            // 
            // btnVerificarVersionLocal
            // 
            btnVerificarVersionLocal.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarVersionLocal.Location = new Point(107, 59);
            btnVerificarVersionLocal.Name = "btnVerificarVersionLocal";
            btnVerificarVersionLocal.Size = new Size(92, 23);
            btnVerificarVersionLocal.TabIndex = 12;
            btnVerificarVersionLocal.Text = "Aceptar";
            btnVerificarVersionLocal.UseVisualStyleBackColor = true;
            btnVerificarVersionLocal.Click += btnVerificarVersionLocal_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(3, 62);
            label7.Name = "label7";
            label7.Size = new Size(101, 17);
            label7.TabIndex = 11;
            label7.Text = "Versión - Local";
            // 
            // comboBoxAplicativo
            // 
            comboBoxAplicativo.FormattingEnabled = true;
            comboBoxAplicativo.Items.AddRange(new object[] { "ActualizaDatos", "Centralizador", "CentralizadorComanda", "PantallaComanda", "Omnicanal", "Costos", "DescargaLocal", "Informes", "Informes|Version", "Profit", "CinetEF-OCX", "CinetFiscalManager", "ZonaEntrega", "ZonaLlamador", "TotemAPI", "InterfaceTotem", "Totem.EXE", "PanelDVY", "PanelMTZ", "PanelRappi" });
            comboBoxAplicativo.Location = new Point(3, 26);
            comboBoxAplicativo.Name = "comboBoxAplicativo";
            comboBoxAplicativo.Size = new Size(98, 23);
            comboBoxAplicativo.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(3, 6);
            label6.Name = "label6";
            label6.Size = new Size(98, 17);
            label6.TabIndex = 34;
            label6.Text = "Versión - Caja\r\n";
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.MenuHighlight;
            panel9.Controls.Add(label1);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(206, 25);
            panel9.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(67, 4);
            label1.Name = "label1";
            label1.Size = new Size(72, 17);
            label1.TabIndex = 1;
            label1.Text = "VERSIONES";
            // 
            // panelBackup
            // 
            panelBackup.BackColor = Color.White;
            panelBackup.Controls.Add(panel11);
            panelBackup.Controls.Add(btnBackup);
            panelBackup.Location = new Point(224, 222);
            panelBackup.Name = "panelBackup";
            panelBackup.Size = new Size(106, 105);
            panelBackup.TabIndex = 35;
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.MenuHighlight;
            panel11.Controls.Add(label8);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(106, 25);
            panel11.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(26, 4);
            label8.Name = "label8";
            label8.Size = new Size(55, 17);
            label8.TabIndex = 1;
            label8.Text = "BACKUP";
            // 
            // btnBackup
            // 
            btnBackup.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBackup.Location = new Point(6, 39);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(95, 52);
            btnBackup.TabIndex = 13;
            btnBackup.Text = "BACKUP BACKOFFICE";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // panelParaguay
            // 
            panelParaguay.BackColor = Color.White;
            panelParaguay.Controls.Add(label10);
            panelParaguay.Controls.Add(panel13);
            panelParaguay.Controls.Add(corregirPmixBtn);
            panelParaguay.Location = new Point(436, 81);
            panelParaguay.Name = "panelParaguay";
            panelParaguay.Size = new Size(205, 136);
            panelParaguay.TabIndex = 36;
            panelParaguay.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(3, 31);
            label10.Name = "label10";
            label10.Size = new Size(172, 17);
            label10.TabIndex = 35;
            label10.Text = "Corregir generación PMIX";
            // 
            // panel13
            // 
            panel13.BackColor = SystemColors.MenuHighlight;
            panel13.Controls.Add(label9);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(205, 25);
            panel13.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(66, 4);
            label9.Name = "label9";
            label9.Size = new Size(74, 17);
            label9.TabIndex = 1;
            label9.Text = "PARAGUAY";
            // 
            // corregirPmixBtn
            // 
            corregirPmixBtn.Enabled = false;
            corregirPmixBtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            corregirPmixBtn.Location = new Point(3, 52);
            corregirPmixBtn.Name = "corregirPmixBtn";
            corregirPmixBtn.Size = new Size(92, 23);
            corregirPmixBtn.TabIndex = 13;
            corregirPmixBtn.Text = "Corregir";
            corregirPmixBtn.UseVisualStyleBackColor = true;
            corregirPmixBtn.Click += corregirPmixBtn_Click;
            // 
            // QuerysBackofficeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(646, 334);
            Controls.Add(panelParaguay);
            Controls.Add(panelBackup);
            Controls.Add(panel7);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panelMesa);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "QuerysBackofficeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Querys - Backoffice";
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panelMesa.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panelMantenimiento.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panelVersiones.ResumeLayout(false);
            panelVersiones.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panelBackup.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panelParaguay.ResumeLayout(false);
            panelParaguay.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private TextBox txtPassBotones;
        private Button btnAceptarPassBtn;
        public DateTimePicker fechaHasta;
        public DateTimePicker fechaDesde;
        private Label labelPass;
        private Label label4;
        private Label label3;
        private Panel panelMesa;
        private Button btnCorregirZetasEnCero;
        private Label label2;
        private Button btnVerZetasEnCero;
        private Panel panel2;
        private Label label20;
        private Panel panel1;
        private Panel panel3;
        private Panel panelMantenimiento;
        private Button btnReducirLogs;
        private Button btnConsultaConexion;
        private Panel panel6;
        private Label label5;
        private Button btnVerificarCaja;
        private Button btnVerificarVersionCaja;
        private Panel panel7;
        private Panel panelVersiones;
        private Label label7;
        private ComboBox comboBoxAplicativo;
        private Label label6;
        private Panel panel9;
        private Label label1;
        private Button btnVerificarVersionLocal;
        private Panel panelBackup;
        private Panel panel11;
        private Label label8;
        private Button btnBackup;
        private Panel panelParaguay;
        private Panel panel13;
        private Label label9;
        private Button corregirPmixBtn;
        private Button button1;
        private Label label10;
        private Button btnVerificarSizeTables;
    }
}