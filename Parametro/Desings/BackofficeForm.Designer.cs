namespace Parametro.Desings
{
    partial class BackofficeForm
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
            CheckTiendaCafe = new CheckBox();
            STOREIDRAP = new TextBox();
            BtnConfigurarRap = new Button();
            panel3 = new Panel();
            label6 = new Label();
            panel4 = new Panel();
            label19 = new Label();
            btnQuerysBko = new Button();
            panel1 = new Panel();
            label5 = new Label();
            btnCodLocal = new Button();
            NOMLOCAL = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            label7 = new Label();
            label4 = new Label();
            UNAME_MTZ = new TextBox();
            btnUNAME_MTZ = new Button();
            label3 = new Label();
            btnPASS_MTZ = new Button();
            PASS_MTZ = new TextBox();
            panel6 = new Panel();
            label2 = new Label();
            panel9 = new Panel();
            panel11 = new Panel();
            btnMAXARQUEOF = new Button();
            btnFAMAXVALOR = new Button();
            btnUPDRUTA = new Button();
            label10 = new Label();
            label9 = new Label();
            label26 = new Label();
            MAXARQUEOF = new TextBox();
            FAMAXVALOR = new TextBox();
            UPDRUTA = new TextBox();
            EQUIPOUPD = new TextBox();
            label18 = new Label();
            btnEQUIPOUPD = new Button();
            panel10 = new Panel();
            label24 = new Label();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // CheckTiendaCafe
            // 
            CheckTiendaCafe.AutoSize = true;
            CheckTiendaCafe.BackColor = Color.FromArgb(0, 0, 192);
            CheckTiendaCafe.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CheckTiendaCafe.ForeColor = SystemColors.ControlLightLight;
            CheckTiendaCafe.Location = new Point(3, 54);
            CheckTiendaCafe.Name = "CheckTiendaCafe";
            CheckTiendaCafe.Size = new Size(194, 22);
            CheckTiendaCafe.TabIndex = 2;
            CheckTiendaCafe.Text = "Usa Tienda Cafetería?";
            CheckTiendaCafe.UseVisualStyleBackColor = false;
            // 
            // STOREIDRAP
            // 
            STOREIDRAP.Location = new Point(3, 85);
            STOREIDRAP.Name = "STOREIDRAP";
            STOREIDRAP.Size = new Size(100, 23);
            STOREIDRAP.TabIndex = 3;
            STOREIDRAP.TextChanged += STOREIDRAP_TextChanged;
            // 
            // BtnConfigurarRap
            // 
            BtnConfigurarRap.Location = new Point(110, 85);
            BtnConfigurarRap.Name = "BtnConfigurarRap";
            BtnConfigurarRap.Size = new Size(75, 23);
            BtnConfigurarRap.TabIndex = 4;
            BtnConfigurarRap.Text = "ACEPTAR";
            BtnConfigurarRap.UseVisualStyleBackColor = true;
            BtnConfigurarRap.Click += BtnConfigurarRap_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(CheckTiendaCafe);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(STOREIDRAP);
            panel3.Controls.Add(BtnConfigurarRap);
            panel3.Location = new Point(12, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(216, 117);
            panel3.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(3, 28);
            label6.Name = "label6";
            label6.Size = new Size(172, 20);
            label6.TabIndex = 23;
            label6.Text = "Configurar Rappi V2";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.MenuHighlight;
            panel4.Controls.Add(label19);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(216, 25);
            panel4.TabIndex = 0;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = SystemColors.ButtonHighlight;
            label19.Location = new Point(78, 4);
            label19.Name = "label19";
            label19.Size = new Size(60, 17);
            label19.TabIndex = 1;
            label19.Text = "RAPPI V2";
            // 
            // btnQuerysBko
            // 
            btnQuerysBko.BackgroundImage = Properties.Resources.SqlServerLogo;
            btnQuerysBko.BackgroundImageLayout = ImageLayout.Zoom;
            btnQuerysBko.Enabled = false;
            btnQuerysBko.Location = new Point(385, 324);
            btnQuerysBko.Name = "btnQuerysBko";
            btnQuerysBko.Size = new Size(75, 65);
            btnQuerysBko.TabIndex = 32;
            btnQuerysBko.UseVisualStyleBackColor = true;
            btnQuerysBko.Click += btnQuerysBko_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnCodLocal);
            panel1.Controls.Add(NOMLOCAL);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(216, 86);
            panel1.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(3, 28);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 20;
            label5.Text = "Código Local";
            // 
            // btnCodLocal
            // 
            btnCodLocal.Location = new Point(69, 51);
            btnCodLocal.Name = "btnCodLocal";
            btnCodLocal.Size = new Size(63, 23);
            btnCodLocal.TabIndex = 22;
            btnCodLocal.Text = "Cambiar";
            btnCodLocal.UseVisualStyleBackColor = true;
            btnCodLocal.Click += btnCodLocal_Click;
            // 
            // NOMLOCAL
            // 
            NOMLOCAL.Location = new Point(3, 51);
            NOMLOCAL.Name = "NOMLOCAL";
            NOMLOCAL.Size = new Size(60, 23);
            NOMLOCAL.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(216, 25);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(78, 4);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 1;
            label1.Text = "LOCAL";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(UNAME_MTZ);
            panel5.Controls.Add(btnUNAME_MTZ);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(btnPASS_MTZ);
            panel5.Controls.Add(PASS_MTZ);
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(12, 227);
            panel5.Name = "panel5";
            panel5.Size = new Size(216, 162);
            panel5.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(3, 28);
            label7.Name = "label7";
            label7.Size = new Size(192, 20);
            label7.TabIndex = 24;
            label7.Text = "Credenciales APP MTZ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(3, 108);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 38;
            label4.Text = "Password MTZ";
            // 
            // UNAME_MTZ
            // 
            UNAME_MTZ.Location = new Point(3, 131);
            UNAME_MTZ.Name = "UNAME_MTZ";
            UNAME_MTZ.Size = new Size(100, 23);
            UNAME_MTZ.TabIndex = 36;
            // 
            // btnUNAME_MTZ
            // 
            btnUNAME_MTZ.Location = new Point(110, 82);
            btnUNAME_MTZ.Name = "btnUNAME_MTZ";
            btnUNAME_MTZ.Size = new Size(75, 23);
            btnUNAME_MTZ.TabIndex = 37;
            btnUNAME_MTZ.Text = "ACEPTAR";
            btnUNAME_MTZ.UseVisualStyleBackColor = true;
            btnUNAME_MTZ.Click += btnUNAME_MTZ_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(3, 59);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 35;
            label3.Text = "User MTZ";
            // 
            // btnPASS_MTZ
            // 
            btnPASS_MTZ.Location = new Point(110, 130);
            btnPASS_MTZ.Name = "btnPASS_MTZ";
            btnPASS_MTZ.Size = new Size(75, 23);
            btnPASS_MTZ.TabIndex = 34;
            btnPASS_MTZ.Text = "ACEPTAR";
            btnPASS_MTZ.UseVisualStyleBackColor = true;
            btnPASS_MTZ.Click += btnPASS_MTZ_Click;
            // 
            // PASS_MTZ
            // 
            PASS_MTZ.Location = new Point(3, 82);
            PASS_MTZ.Name = "PASS_MTZ";
            PASS_MTZ.Size = new Size(100, 23);
            PASS_MTZ.TabIndex = 33;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.MenuHighlight;
            panel6.Controls.Add(label2);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(216, 25);
            panel6.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(78, 4);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 1;
            label2.Text = "APP MTZ";
            // 
            // panel9
            // 
            panel9.AutoScrollMargin = new Size(0, 10);
            panel9.BackColor = Color.White;
            panel9.Controls.Add(panel11);
            panel9.Controls.Add(panel10);
            panel9.Location = new Point(234, 12);
            panel9.Name = "panel9";
            panel9.Size = new Size(226, 209);
            panel9.TabIndex = 33;
            // 
            // panel11
            // 
            panel11.AutoScroll = true;
            panel11.AutoScrollMargin = new Size(0, 10);
            panel11.Controls.Add(btnMAXARQUEOF);
            panel11.Controls.Add(btnFAMAXVALOR);
            panel11.Controls.Add(btnUPDRUTA);
            panel11.Controls.Add(label10);
            panel11.Controls.Add(label9);
            panel11.Controls.Add(label26);
            panel11.Controls.Add(MAXARQUEOF);
            panel11.Controls.Add(FAMAXVALOR);
            panel11.Controls.Add(UPDRUTA);
            panel11.Controls.Add(EQUIPOUPD);
            panel11.Controls.Add(label18);
            panel11.Controls.Add(btnEQUIPOUPD);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 25);
            panel11.Name = "panel11";
            panel11.Size = new Size(226, 184);
            panel11.TabIndex = 1;
            // 
            // btnMAXARQUEOF
            // 
            btnMAXARQUEOF.Location = new Point(126, 182);
            btnMAXARQUEOF.Name = "btnMAXARQUEOF";
            btnMAXARQUEOF.Size = new Size(63, 23);
            btnMAXARQUEOF.TabIndex = 35;
            btnMAXARQUEOF.Text = "Cambiar";
            btnMAXARQUEOF.UseVisualStyleBackColor = true;
            btnMAXARQUEOF.Click += btnMAXARQUEOF_Click;
            // 
            // btnFAMAXVALOR
            // 
            btnFAMAXVALOR.Location = new Point(126, 130);
            btnFAMAXVALOR.Name = "btnFAMAXVALOR";
            btnFAMAXVALOR.Size = new Size(63, 23);
            btnFAMAXVALOR.TabIndex = 32;
            btnFAMAXVALOR.Text = "Cambiar";
            btnFAMAXVALOR.UseVisualStyleBackColor = true;
            btnFAMAXVALOR.Click += btnFAMAXVALOR_Click;
            // 
            // btnUPDRUTA
            // 
            btnUPDRUTA.Location = new Point(126, 79);
            btnUPDRUTA.Name = "btnUPDRUTA";
            btnUPDRUTA.Size = new Size(63, 23);
            btnUPDRUTA.TabIndex = 32;
            btnUPDRUTA.Text = "Cambiar";
            btnUPDRUTA.UseVisualStyleBackColor = true;
            btnUPDRUTA.Click += btnUPDRUTA_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(3, 159);
            label10.Name = "label10";
            label10.Size = new Size(145, 20);
            label10.TabIndex = 33;
            label10.Text = "Límite de Arqueo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(3, 105);
            label9.Name = "label9";
            label9.Size = new Size(135, 20);
            label9.TabIndex = 33;
            label9.Text = "Límite de Cobro";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label26.Location = new Point(3, 54);
            label26.Name = "label26";
            label26.Size = new Size(112, 20);
            label26.TabIndex = 33;
            label26.Text = "Ruta Update";
            // 
            // MAXARQUEOF
            // 
            MAXARQUEOF.Location = new Point(3, 184);
            MAXARQUEOF.Name = "MAXARQUEOF";
            MAXARQUEOF.Size = new Size(113, 23);
            MAXARQUEOF.TabIndex = 34;
            // 
            // FAMAXVALOR
            // 
            FAMAXVALOR.Location = new Point(3, 130);
            FAMAXVALOR.Name = "FAMAXVALOR";
            FAMAXVALOR.Size = new Size(113, 23);
            FAMAXVALOR.TabIndex = 34;
            // 
            // UPDRUTA
            // 
            UPDRUTA.Location = new Point(3, 79);
            UPDRUTA.Name = "UPDRUTA";
            UPDRUTA.Size = new Size(113, 23);
            UPDRUTA.TabIndex = 34;
            // 
            // EQUIPOUPD
            // 
            EQUIPOUPD.Location = new Point(3, 28);
            EQUIPOUPD.Name = "EQUIPOUPD";
            EQUIPOUPD.Size = new Size(113, 23);
            EQUIPOUPD.TabIndex = 22;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(3, 3);
            label18.Name = "label18";
            label18.Size = new Size(111, 20);
            label18.TabIndex = 21;
            label18.Text = "Host Update";
            // 
            // btnEQUIPOUPD
            // 
            btnEQUIPOUPD.Location = new Point(126, 28);
            btnEQUIPOUPD.Name = "btnEQUIPOUPD";
            btnEQUIPOUPD.Size = new Size(63, 23);
            btnEQUIPOUPD.TabIndex = 21;
            btnEQUIPOUPD.Text = "Cambiar";
            btnEQUIPOUPD.UseVisualStyleBackColor = true;
            btnEQUIPOUPD.Click += btnEQUIPOUPD_Click;
            // 
            // panel10
            // 
            panel10.BackColor = SystemColors.MenuHighlight;
            panel10.Controls.Add(label24);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(226, 25);
            panel10.TabIndex = 0;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label24.ForeColor = SystemColors.ButtonHighlight;
            label24.Location = new Point(46, 4);
            label24.Name = "label24";
            label24.Size = new Size(134, 17);
            label24.TabIndex = 1;
            label24.Text = "PARAMETROS VARIOS";
            // 
            // BackofficeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(470, 396);
            Controls.Add(panel9);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(btnQuerysBko);
            Controls.Add(panel3);
            MaximizeBox = false;
            Name = "BackofficeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BackofficeForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel9.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button BtnConfigurarRap;
        private TextBox STOREIDRAP;
        public CheckBox CheckTiendaCafe;
        private Panel panel3;
        private Panel panel4;
        private Label label19;
        private Button btnQuerysBko;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label5;
        private Button btnCodLocal;
        private TextBox NOMLOCAL;
        private Panel panel5;
        private Panel panel6;
        private Label label2;
        private Label label4;
        private TextBox UNAME_MTZ;
        private Button btnUNAME_MTZ;
        private Label label3;
        private TextBox PASS_MTZ;
        private Button btnPASS_MTZ;
        private Label label6;
        private Label label7;
        private Panel panel9;
        private Panel panel11;
        private Button button3;
        private Button btnUPDRUTA;
        private Label label10;
        private Label label26;
        private TextBox MAXARQUEOF;
        private TextBox textBox2;
        private TextBox UPDRUTA;
        private TextBox EQUIPOUPD;
        private Label label18;
        private Button btnEQUIPOUPD;
        private Panel panel10;
        private Label label24;
        private Button btnFAMAXVALOR;
        private Label label9;
        private TextBox FAMAXVALOR;
        private Button btnMAXARQUEOF;
    }
}