namespace Parametro.Desings
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            textBoxUser = new TextBox();
            btnConnect = new Button();
            textBoxPass = new TextBox();
            textBoxIp = new TextBox();
            textBoxPort = new TextBox();
            comboBoxDataBase = new ComboBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            checkBoxLinkedServer = new CheckBox();
            textBoxPortLS = new TextBox();
            btnConnectLinkedServer = new Button();
            textBoxEquipoLinkedServer = new TextBox();
            btnQueryActivate = new Button();
            cbEquipoLinkedServer = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(22, 94);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(118, 23);
            textBoxUser.TabIndex = 1;
            textBoxUser.Text = "10";
            textBoxUser.TextChanged += textBoxUser_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(22, 245);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(82, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "CONECTAR";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(22, 138);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.Size = new Size(118, 23);
            textBoxPass.TabIndex = 2;
            textBoxPass.UseSystemPasswordChar = true;
            textBoxPass.TextChanged += textBoxPass_TextChanged;
            // 
            // textBoxIp
            // 
            textBoxIp.Location = new Point(22, 187);
            textBoxIp.Name = "textBoxIp";
            textBoxIp.Size = new Size(118, 23);
            textBoxIp.TabIndex = 3;
            textBoxIp.TextChanged += textBoxIp_TextChanged;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(22, 216);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(43, 23);
            textBoxPort.TabIndex = 4;
            textBoxPort.Text = "1433";
            textBoxPort.TextChanged += textBoxPort_TextChanged;
            // 
            // comboBoxDataBase
            // 
            comboBoxDataBase.FormattingEnabled = true;
            comboBoxDataBase.Location = new Point(22, 382);
            comboBoxDataBase.Name = "comboBoxDataBase";
            comboBoxDataBase.Size = new Size(118, 23);
            comboBoxDataBase.TabIndex = 10;
            comboBoxDataBase.SelectedIndexChanged += comboBoxDataBase_SelectedIndexChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(146, 382);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(73, 23);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "INGRESAR";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(22, 71);
            label1.Name = "label1";
            label1.Size = new Size(82, 18);
            label1.TabIndex = 12;
            label1.Text = "USUARIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(22, 359);
            label2.Name = "label2";
            label2.Size = new Size(140, 18);
            label2.TabIndex = 13;
            label2.Text = "BASE DE DATOS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(21, 164);
            label3.Name = "label3";
            label3.Size = new Size(84, 18);
            label3.TabIndex = 14;
            label3.Text = "IP / HOST";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(21, 120);
            label4.Name = "label4";
            label4.Size = new Size(121, 18);
            label4.TabIndex = 15;
            label4.Text = "CONTRASEÑA";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(49, 117, 162);
            pictureBox1.Location = new Point(-6, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(245, 56);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(49, 117, 162);
            label5.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(79, 32);
            label5.TabIndex = 17;
            label5.Text = "CINET\r\n";
            // 
            // checkBoxLinkedServer
            // 
            checkBoxLinkedServer.AutoSize = true;
            checkBoxLinkedServer.BackColor = Color.FromArgb(49, 117, 162);
            checkBoxLinkedServer.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxLinkedServer.ForeColor = SystemColors.ControlLightLight;
            checkBoxLinkedServer.Location = new Point(22, 274);
            checkBoxLinkedServer.Name = "checkBoxLinkedServer";
            checkBoxLinkedServer.Size = new Size(125, 22);
            checkBoxLinkedServer.TabIndex = 6;
            checkBoxLinkedServer.Text = "LinkedServer";
            checkBoxLinkedServer.UseVisualStyleBackColor = false;
            checkBoxLinkedServer.CheckedChanged += checkBoxLinkedServer_CheckedChanged;
            // 
            // textBoxPortLS
            // 
            textBoxPortLS.Location = new Point(97, 304);
            textBoxPortLS.Name = "textBoxPortLS";
            textBoxPortLS.Size = new Size(43, 23);
            textBoxPortLS.TabIndex = 8;
            textBoxPortLS.Text = "1433";
            textBoxPortLS.TextChanged += textBoxPortLS_TextChanged;
            // 
            // btnConnectLinkedServer
            // 
            btnConnectLinkedServer.Location = new Point(22, 333);
            btnConnectLinkedServer.Name = "btnConnectLinkedServer";
            btnConnectLinkedServer.Size = new Size(118, 23);
            btnConnectLinkedServer.TabIndex = 9;
            btnConnectLinkedServer.Text = "CONECTAR";
            btnConnectLinkedServer.UseVisualStyleBackColor = true;
            btnConnectLinkedServer.Click += btnConnectLinkedServer_Click;
            // 
            // textBoxEquipoLinkedServer
            // 
            textBoxEquipoLinkedServer.Location = new Point(262, 9);
            textBoxEquipoLinkedServer.Name = "textBoxEquipoLinkedServer";
            textBoxEquipoLinkedServer.Size = new Size(69, 23);
            textBoxEquipoLinkedServer.TabIndex = 7;
            textBoxEquipoLinkedServer.Visible = false;
            textBoxEquipoLinkedServer.TextChanged += textBoxEquipoLinkedServer_TextChanged;
            // 
            // btnQueryActivate
            // 
            btnQueryActivate.BackColor = Color.FromArgb(49, 117, 162);
            btnQueryActivate.FlatStyle = FlatStyle.Flat;
            btnQueryActivate.ForeColor = Color.FromArgb(49, 117, 162);
            btnQueryActivate.Location = new Point(314, 38);
            btnQueryActivate.Name = "btnQueryActivate";
            btnQueryActivate.Size = new Size(17, 29);
            btnQueryActivate.TabIndex = 18;
            btnQueryActivate.UseMnemonic = false;
            btnQueryActivate.UseVisualStyleBackColor = false;
            btnQueryActivate.Click += btnQueryActivate_Click;
            // 
            // cbEquipoLinkedServer
            // 
            cbEquipoLinkedServer.Enabled = false;
            cbEquipoLinkedServer.FormattingEnabled = true;
            cbEquipoLinkedServer.Location = new Point(22, 304);
            cbEquipoLinkedServer.Name = "cbEquipoLinkedServer";
            cbEquipoLinkedServer.Size = new Size(69, 23);
            cbEquipoLinkedServer.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(49, 117, 162);
            label6.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(186, 9);
            label6.Name = "label6";
            label6.Size = new Size(55, 13);
            label6.TabIndex = 20;
            label6.Text = "7.5.2.0(B)";
            label6.Click += label6_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(236, 418);
            Controls.Add(label6);
            Controls.Add(cbEquipoLinkedServer);
            Controls.Add(btnQueryActivate);
            Controls.Add(textBoxEquipoLinkedServer);
            Controls.Add(btnConnectLinkedServer);
            Controls.Add(textBoxPortLS);
            Controls.Add(checkBoxLinkedServer);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(comboBoxDataBase);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIp);
            Controls.Add(btnConnect);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxUser);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CINET";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxUser;
        private Button btnConnect;
        private TextBox textBoxPass;
        private TextBox textBoxIp;
        private TextBox textBoxPort;
        private Button btnLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        public ComboBox comboBoxDataBase;
        private Button btnConnectLinkedServer;
        public CheckBox checkBoxLinkedServer;
        public TextBox textBoxPortLS;
        public TextBox textBoxEquipoLinkedServer;
        private Button btnQueryActivate;
        private ComboBox cbEquipoLinkedServer;
        private Label label6;
    }
}