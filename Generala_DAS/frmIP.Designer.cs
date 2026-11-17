namespace Generala_DAS
{
    partial class frmIP
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnIPOK = new System.Windows.Forms.Button();
            this.lblP = new System.Windows.Forms.Label();
            this.btnIPCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 36);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(169, 20);
            this.txtIP.TabIndex = 0;
            // 
            // btnIPOK
            // 
            this.btnIPOK.Location = new System.Drawing.Point(106, 62);
            this.btnIPOK.Name = "btnIPOK";
            this.btnIPOK.Size = new System.Drawing.Size(75, 23);
            this.btnIPOK.TabIndex = 1;
            this.btnIPOK.Text = "Ok";
            this.btnIPOK.UseVisualStyleBackColor = true;
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(13, 17);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(152, 13);
            this.lblP.TabIndex = 2;
            this.lblP.Text = "Ingrese la dirección IP del host";
            // 
            // btnIPCancelar
            // 
            this.btnIPCancelar.Location = new System.Drawing.Point(12, 62);
            this.btnIPCancelar.Name = "btnIPCancelar";
            this.btnIPCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnIPCancelar.TabIndex = 3;
            this.btnIPCancelar.Text = "Cancelar";
            this.btnIPCancelar.UseVisualStyleBackColor = true;
            // 
            // frmIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 97);
            this.Controls.Add(this.btnIPCancelar);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.btnIPOK);
            this.Controls.Add(this.txtIP);
            this.Name = "frmIP";
            this.Text = "IP";
            this.Load += new System.EventHandler(this.frmIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnIPOK;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Button btnIPCancelar;
    }
}