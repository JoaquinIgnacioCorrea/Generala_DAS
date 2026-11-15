namespace Generala_DAS
{
    partial class frmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.btnVisorXml = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(85, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(210, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generala - Menú";
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(75, 72);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(230, 38);
            this.btnJugar.TabIndex = 1;
            this.btnJugar.Text = "Jugar Partida";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.Location = new System.Drawing.Point(75, 122);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(230, 38);
            this.btnBitacora.TabIndex = 2;
            this.btnBitacora.Text = "Bitácora de Eventos";
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnVisorXml
            // 
            this.btnVisorXml.Location = new System.Drawing.Point(75, 172);
            this.btnVisorXml.Name = "btnVisorXml";
            this.btnVisorXml.Size = new System.Drawing.Size(230, 38);
            this.btnVisorXml.TabIndex = 3;
            this.btnVisorXml.Text = "Visor de Movimientos XML";
            this.btnVisorXml.UseVisualStyleBackColor = true;
            this.btnVisorXml.Click += new System.EventHandler(this.btnVisorXml_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(75, 222);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(230, 38);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 290);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnVisorXml);
            this.Controls.Add(this.btnBitacora);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal - Generala";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnVisorXml;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
