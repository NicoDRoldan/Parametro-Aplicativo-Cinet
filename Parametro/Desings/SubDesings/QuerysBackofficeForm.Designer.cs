namespace Parametro.Desings.SubDesings
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
            panel4 = new Panel();
            btnVerificarCaja = new Button();
            btnConsultaConexion = new Button();
            panel6 = new Panel();
            label5 = new Label();
            btnReducirLogs = new Button();
            btnVerificarVersionCaja = new Button();
            panel7 = new Panel();
            panel8 = new Panel();
            btnVerificarVersionLocal = new Button();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            panel9 = new Panel();
            label1 = new Label();
            panel5.SuspendLayout();
            panelMesa.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
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
            panel5.Size = new Size(440, 68);
            panel5.TabIndex = 34;
            // 
            // txtPassBotones
            // 
            txtPassBotones.Location = new Point(238, 31);
            txtPassBotones.Name = "txtPassBotones";
            txtPassBotones.PasswordChar = '#';
            txtPassBotones.Size = new Size(95, 23);
            txtPassBotones.TabIndex = 33;
            txtPassBotones.UseSystemPasswordChar = true;
            // 
            // btnAceptarPassBtn
            // 
            btnAceptarPassBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptarPassBtn.Location = new Point(338, 31);
            btnAceptarPassBtn.Name = "btnAceptarPassBtn";
            btnAceptarPassBtn.Size = new Size(68, 23);
            btnAceptarPassBtn.TabIndex = 29;
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
            fechaHasta.TabIndex = 32;
            fechaHasta.Value = new DateTime(2023, 12, 12, 0, 0, 0, 0);
            // 
            // fechaDesde
            // 
            fechaDesde.CustomFormat = "";
            fechaDesde.Format = DateTimePickerFormat.Short;
            fechaDesde.Location = new Point(12, 29);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(81, 23);
            fechaDesde.TabIndex = 31;
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
            panelMesa.Location = new Point(12, 81);
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
            btnCorregirZetasEnCero.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCorregirZetasEnCero.Location = new Point(106, 27);
            btnCorregirZetasEnCero.Name = "btnCorregirZetasEnCero";
            btnCorregirZetasEnCero.Size = new Size(92, 44);
            btnCorregirZetasEnCero.TabIndex = 28;
            btnCorregirZetasEnCero.Text = "CORREGIR Z's en 0";
            btnCorregirZetasEnCero.UseVisualStyleBackColor = true;
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
            btnVerZetasEnCero.TabIndex = 22;
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
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel6);
            panel3.Location = new Point(12, 191);
            panel3.Name = "panel3";
            panel3.Size = new Size(206, 104);
            panel3.TabIndex = 33;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnVerificarCaja);
            panel4.Controls.Add(btnConsultaConexion);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(206, 79);
            panel4.TabIndex = 1;
            // 
            // btnVerificarCaja
            // 
            btnVerificarCaja.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarCaja.Location = new Point(106, 17);
            btnVerificarCaja.Name = "btnVerificarCaja";
            btnVerificarCaja.Size = new Size(92, 44);
            btnVerificarCaja.TabIndex = 29;
            btnVerificarCaja.Text = "Verificar Caja";
            btnVerificarCaja.UseVisualStyleBackColor = true;
            btnVerificarCaja.Click += btnVerificarCaja_Click;
            // 
            // btnConsultaConexion
            // 
            btnConsultaConexion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnConsultaConexion.Location = new Point(8, 17);
            btnConsultaConexion.Name = "btnConsultaConexion";
            btnConsultaConexion.Size = new Size(92, 44);
            btnConsultaConexion.TabIndex = 22;
            btnConsultaConexion.Text = "Consulta Conexiones";
            btnConsultaConexion.UseVisualStyleBackColor = true;
            btnConsultaConexion.Click += btnConsultaConexion_Click;
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
            // btnReducirLogs
            // 
            btnReducirLogs.Enabled = false;
            btnReducirLogs.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnReducirLogs.Location = new Point(12, 301);
            btnReducirLogs.Name = "btnReducirLogs";
            btnReducirLogs.Size = new Size(92, 44);
            btnReducirLogs.TabIndex = 28;
            btnReducirLogs.Text = "Reducir Log's";
            btnReducirLogs.UseVisualStyleBackColor = true;
            btnReducirLogs.Visible = false;
            btnReducirLogs.Click += btnReducirLogs_Click;
            // 
            // btnVerificarVersionCaja
            // 
            btnVerificarVersionCaja.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarVersionCaja.Location = new Point(107, 25);
            btnVerificarVersionCaja.Name = "btnVerificarVersionCaja";
            btnVerificarVersionCaja.Size = new Size(92, 23);
            btnVerificarVersionCaja.TabIndex = 31;
            btnVerificarVersionCaja.Text = "Aceptar";
            btnVerificarVersionCaja.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(panel9);
            panel7.Location = new Point(224, 81);
            panel7.Name = "panel7";
            panel7.Size = new Size(206, 135);
            panel7.TabIndex = 34;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnVerificarVersionLocal);
            panel8.Controls.Add(label7);
            panel8.Controls.Add(comboBox1);
            panel8.Controls.Add(btnVerificarVersionCaja);
            panel8.Controls.Add(label6);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 25);
            panel8.Name = "panel8";
            panel8.Size = new Size(206, 110);
            panel8.TabIndex = 1;
            // 
            // btnVerificarVersionLocal
            // 
            btnVerificarVersionLocal.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarVersionLocal.Location = new Point(107, 59);
            btnVerificarVersionLocal.Name = "btnVerificarVersionLocal";
            btnVerificarVersionLocal.Size = new Size(92, 23);
            btnVerificarVersionLocal.TabIndex = 37;
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
            label7.TabIndex = 36;
            label7.Text = "Versión - Local";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(98, 23);
            comboBox1.TabIndex = 35;
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
            // QuerysBackofficeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(440, 300);
            Controls.Add(panel7);
            Controls.Add(panel3);
            Controls.Add(btnReducirLogs);
            Controls.Add(panel5);
            Controls.Add(panelMesa);
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
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
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
        private Panel panel4;
        private Button btnReducirLogs;
        private Button btnConsultaConexion;
        private Panel panel6;
        private Label label5;
        private Button btnVerificarCaja;
        private Button btnVerificarVersionCaja;
        private Panel panel7;
        private Panel panel8;
        private Label label7;
        private ComboBox comboBox1;
        private Label label6;
        private Panel panel9;
        private Label label1;
        private Button btnVerificarVersionLocal;
    }
}