namespace DylanLettersApp
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.cboIPAddresses = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(120, 287);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 27);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(26, 287);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 27);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "This Computer\'s Name:";
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(223, 25);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(90, 13);
            this.lblComputerName.TabIndex = 4;
            this.lblComputerName.Text = "lblComputerName";
            // 
            // cboIPAddresses
            // 
            this.cboIPAddresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIPAddresses.FormattingEnabled = true;
            this.cboIPAddresses.Location = new System.Drawing.Point(226, 57);
            this.cboIPAddresses.Name = "cboIPAddresses";
            this.cboIPAddresses.Size = new System.Drawing.Size(121, 21);
            this.cboIPAddresses.TabIndex = 5;
            this.cboIPAddresses.SelectedIndexChanged += new System.EventHandler(this.cboIPAddresses_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "This Computer\'s Eligible IP addresses:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port to use for connection:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(226, 96);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "13000";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblStatus.Location = new System.Drawing.Point(28, 139);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(233, 24);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Service is: NOT RUNNING";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(32, 183);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtError.Size = new System.Drawing.Size(344, 77);
            this.txtError.TabIndex = 10;
            this.txtError.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 336);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboIPAddresses);
            this.Controls.Add(this.lblComputerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Name = "FormMain";
            this.Text = "Dylan Letters Communication Application";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.ComboBox cboIPAddresses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Timer timer1;
    }
}

