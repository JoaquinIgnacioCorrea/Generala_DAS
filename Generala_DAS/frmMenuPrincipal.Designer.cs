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
            this.btnHostear = new System.Windows.Forms.Button();
            this.btnUnirse = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(85, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(174, 25);
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
            this.btnBitacora.Location = new System.Drawing.Point(75, 211);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(230, 38);
            this.btnBitacora.TabIndex = 2;
            this.btnBitacora.Text = "Bitácora de Eventos";
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnVisorXml
            // 
            this.btnVisorXml.Location = new System.Drawing.Point(75, 258);
            this.btnVisorXml.Name = "btnVisorXml";
            this.btnVisorXml.Size = new System.Drawing.Size(230, 38);
            this.btnVisorXml.TabIndex = 3;
            this.btnVisorXml.Text = "Visor de Movimientos XML";
            this.btnVisorXml.UseVisualStyleBackColor = true;
            this.btnVisorXml.Click += new System.EventHandler(this.btnVisorXml_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(75, 349);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(230, 38);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnHostear
            // 
            this.btnHostear.Location = new System.Drawing.Point(75, 119);
            this.btnHostear.Name = "btnHostear";
            this.btnHostear.Size = new System.Drawing.Size(230, 38);
            this.btnHostear.TabIndex = 5;
            this.btnHostear.Text = "Hostear";
            this.btnHostear.UseVisualStyleBackColor = true;
            this.btnHostear.Click += new System.EventHandler(this.btnHostear_Click);
            // 
            // btnUnirse
            // 
            this.btnUnirse.Location = new System.Drawing.Point(75, 165);
            this.btnUnirse.Name = "btnUnirse";
            this.btnUnirse.Size = new System.Drawing.Size(230, 38);
            this.btnUnirse.TabIndex = 6;
            this.btnUnirse.Text = "Unirse";
            this.btnUnirse.UseVisualStyleBackColor = true;
            this.btnUnirse.Click += new System.EventHandler(this.btnUnirse_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(75, 302);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(108, 38);
            this.btnBackup.TabIndex = 7;
            this.btnBackup.Text = "Hacer Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(197, 302);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(108, 38);
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 399);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnUnirse);
            this.Controls.Add(this.btnHostear);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuPrincipal_FormClosed);
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
        private System.Windows.Forms.Button btnHostear;
        private System.Windows.Forms.Button btnUnirse;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestaurar;
    }
}
