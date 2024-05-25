namespace Parametro.Desings.SubDesings
{
    partial class LaposUyForm
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
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnTERMINAL = new Button();
            TERMINAL = new TextBox();
            btnIDCLIENTE = new Button();
            IDCLIENTE = new TextBox();
            LAPOSUY = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            label20 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnTERMINAL);
            panel1.Controls.Add(TERMINAL);
            panel1.Controls.Add(btnIDCLIENTE);
            panel1.Controls.Add(IDCLIENTE);
            panel1.Controls.Add(LAPOSUY);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 153);
            panel1.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(187, 32);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 37;
            label4.Text = "Terminal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(14, 96);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 36;
            label3.Text = "ID Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(11, 32);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 34;
            label1.Text = "Lapos Activo";
            // 
            // btnTERMINAL
            // 
            btnTERMINAL.Location = new Point(299, 58);
            btnTERMINAL.Name = "btnTERMINAL";
            btnTERMINAL.Size = new Size(63, 21);
            btnTERMINAL.TabIndex = 7;
            btnTERMINAL.Text = "Cambiar";
            btnTERMINAL.UseVisualStyleBackColor = true;
            btnTERMINAL.Click += btnTERMINAL_Click;
            // 
            // TERMINAL
            // 
            TERMINAL.Location = new Point(187, 56);
            TERMINAL.Name = "TERMINAL";
            TERMINAL.Size = new Size(106, 23);
            TERMINAL.TabIndex = 6;
            // 
            // btnIDCLIENTE
            // 
            btnIDCLIENTE.Location = new Point(299, 120);
            btnIDCLIENTE.Name = "btnIDCLIENTE";
            btnIDCLIENTE.Size = new Size(63, 21);
            btnIDCLIENTE.TabIndex = 5;
            btnIDCLIENTE.Text = "Cambiar";
            btnIDCLIENTE.UseVisualStyleBackColor = true;
            btnIDCLIENTE.Click += btnIDCLIENTE_Click;
            // 
            // IDCLIENTE
            // 
            IDCLIENTE.Location = new Point(14, 118);
            IDCLIENTE.Name = "IDCLIENTE";
            IDCLIENTE.Size = new Size(279, 23);
            IDCLIENTE.TabIndex = 4;
            // 
            // LAPOSUY
            // 
            LAPOSUY.AutoSize = true;
            LAPOSUY.Location = new Point(14, 54);
            LAPOSUY.Name = "LAPOSUY";
            LAPOSUY.Size = new Size(108, 25);
            LAPOSUY.TabIndex = 1;
            LAPOSUY.UseVisualStyleBackColor = true;
            LAPOSUY.Click += LaposActivoBtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(383, 25);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.MenuHighlight;
            panel3.Controls.Add(label20);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(383, 25);
            panel3.TabIndex = 2;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label20.ForeColor = SystemColors.ButtonHighlight;
            label20.Location = new Point(137, 4);
            label20.Name = "label20";
            label20.Size = new Size(127, 17);
            label20.TabIndex = 2;
            label20.Text = "Configurar GeoCom";
            // 
            // LaposUyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 153);
            Controls.Add(panel1);
            Name = "LaposUyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración - GeoCom";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label1;
        public Button btnTERMINAL;
        public TextBox TERMINAL;
        public Button btnIDCLIENTE;
        public TextBox IDCLIENTE;
        public Button LAPOSUY;
        private Panel panel2;
        private Panel panel3;
        private Label label20;
    }
}