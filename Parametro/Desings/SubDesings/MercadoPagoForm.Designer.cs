namespace Parametro.Desings.SubDesings
{
    partial class MercadoPagoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MercadoPagoForm));
            panel1 = new Panel();
            label2 = new Label();
            CASHOUT = new Button();
            label1 = new Label();
            MERPAGO = new Button();
            label5 = new Label();
            TOKENMP = new TextBox();
            panel2 = new Panel();
            label20 = new Label();
            btnEXTERIDMP = new Button();
            label7 = new Label();
            EXTERIDMP = new TextBox();
            btnTOKENMP = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CASHOUT);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(MERPAGO);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TOKENMP);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnEXTERIDMP);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(EXTERIDMP);
            panel1.Controls.Add(btnTOKENMP);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 181);
            panel1.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(106, 32);
            label2.Name = "label2";
            label2.Size = new Size(70, 21);
            label2.TabIndex = 23;
            label2.Text = "Cashout";
            // 
            // CASHOUT
            // 
            CASHOUT.AutoSize = true;
            CASHOUT.Location = new Point(182, 32);
            CASHOUT.Name = "CASHOUT";
            CASHOUT.Size = new Size(25, 25);
            CASHOUT.TabIndex = 2;
            CASHOUT.UseVisualStyleBackColor = true;
            CASHOUT.Click += CASHOUT_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 21;
            label1.Text = "Activo";
            // 
            // MERPAGO
            // 
            MERPAGO.AutoSize = true;
            MERPAGO.Location = new Point(75, 32);
            MERPAGO.Name = "MERPAGO";
            MERPAGO.Size = new Size(25, 25);
            MERPAGO.TabIndex = 1;
            MERPAGO.UseVisualStyleBackColor = true;
            MERPAGO.Click += MERPAGO_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(12, 64);
            label5.Name = "label5";
            label5.Size = new Size(87, 21);
            label5.TabIndex = 8;
            label5.Text = "External ID";
            // 
            // TOKENMP
            // 
            TOKENMP.Location = new Point(12, 138);
            TOKENMP.Name = "TOKENMP";
            TOKENMP.Size = new Size(431, 23);
            TOKENMP.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label20);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 25);
            panel2.TabIndex = 0;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label20.ForeColor = SystemColors.ButtonHighlight;
            label20.Location = new Point(208, 4);
            label20.Name = "label20";
            label20.Size = new Size(108, 17);
            label20.TabIndex = 1;
            label20.Text = "MERCADO PAGO";
            // 
            // btnEXTERIDMP
            // 
            btnEXTERIDMP.Location = new Point(449, 87);
            btnEXTERIDMP.Name = "btnEXTERIDMP";
            btnEXTERIDMP.Size = new Size(63, 23);
            btnEXTERIDMP.TabIndex = 4;
            btnEXTERIDMP.Text = "Cambiar";
            btnEXTERIDMP.UseVisualStyleBackColor = true;
            btnEXTERIDMP.Click += btnEXTERIDMP_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(12, 114);
            label7.Name = "label7";
            label7.Size = new Size(107, 21);
            label7.TabIndex = 10;
            label7.Text = "Access Token";
            // 
            // EXTERIDMP
            // 
            EXTERIDMP.Location = new Point(12, 88);
            EXTERIDMP.Name = "EXTERIDMP";
            EXTERIDMP.Size = new Size(431, 23);
            EXTERIDMP.TabIndex = 3;
            // 
            // btnTOKENMP
            // 
            btnTOKENMP.Location = new Point(449, 138);
            btnTOKENMP.Name = "btnTOKENMP";
            btnTOKENMP.Size = new Size(63, 23);
            btnTOKENMP.TabIndex = 6;
            btnTOKENMP.Text = "Cambiar";
            btnTOKENMP.UseVisualStyleBackColor = true;
            btnTOKENMP.Click += btnTOKENMP_Click;
            // 
            // MercadoPagoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(528, 181);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MercadoPagoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración - Mercado Pago";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private TextBox TOKENMP;
        private Panel panel2;
        private Label label20;
        private Button btnEXTERIDMP;
        private Label label7;
        private TextBox EXTERIDMP;
        private Button btnTOKENMP;
        private Label label2;
        public Button CASHOUT;
        private Label label1;
        public Button MERPAGO;
    }
}