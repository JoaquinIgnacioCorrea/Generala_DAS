namespace Generala_DAS
{
    partial class frmLoginUsuario
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
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_contraseña = new System.Windows.Forms.Label();
            this.lbl_nombre_usuario = new System.Windows.Forms.Label();
            this.btn_iniciar_sesion = new System.Windows.Forms.Button();
            this.btn_registrarse = new System.Windows.Forms.Button();
            this.tb_contraseña = new System.Windows.Forms.TextBox();
            this.tb_nombre_usuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Generala";
            // 
            // lbl_contraseña
            // 
            this.lbl_contraseña.AutoSize = true;
            this.lbl_contraseña.Location = new System.Drawing.Point(93, 212);
            this.lbl_contraseña.Name = "lbl_contraseña";
            this.lbl_contraseña.Size = new System.Drawing.Size(61, 13);
            this.lbl_contraseña.TabIndex = 19;
            this.lbl_contraseña.Text = "Contraseña";
            // 
            // lbl_nombre_usuario
            // 
            this.lbl_nombre_usuario.AutoSize = true;
            this.lbl_nombre_usuario.Location = new System.Drawing.Point(93, 134);
            this.lbl_nombre_usuario.Name = "lbl_nombre_usuario";
            this.lbl_nombre_usuario.Size = new System.Drawing.Size(83, 13);
            this.lbl_nombre_usuario.TabIndex = 18;
            this.lbl_nombre_usuario.Text = "Nombre Usuario";
            // 
            // btn_iniciar_sesion
            // 
            this.btn_iniciar_sesion.Location = new System.Drawing.Point(96, 277);
            this.btn_iniciar_sesion.Name = "btn_iniciar_sesion";
            this.btn_iniciar_sesion.Size = new System.Drawing.Size(183, 23);
            this.btn_iniciar_sesion.TabIndex = 17;
            this.btn_iniciar_sesion.Text = "Iniciar Sesion";
            this.btn_iniciar_sesion.UseVisualStyleBackColor = true;
            this.btn_iniciar_sesion.Click += new System.EventHandler(this.btn_iniciar_sesion_Click);
            // 
            // btn_registrarse
            // 
            this.btn_registrarse.Location = new System.Drawing.Point(96, 322);
            this.btn_registrarse.Name = "btn_registrarse";
            this.btn_registrarse.Size = new System.Drawing.Size(183, 23);
            this.btn_registrarse.TabIndex = 16;
            this.btn_registrarse.Text = "Registrarse";
            this.btn_registrarse.UseVisualStyleBackColor = true;
            this.btn_registrarse.Click += new System.EventHandler(this.btn_registrarse_Click);
            // 
            // tb_contraseña
            // 
            this.tb_contraseña.Location = new System.Drawing.Point(96, 228);
            this.tb_contraseña.Name = "tb_contraseña";
            this.tb_contraseña.Size = new System.Drawing.Size(183, 20);
            this.tb_contraseña.TabIndex = 15;
            // 
            // tb_nombre_usuario
            // 
            this.tb_nombre_usuario.Location = new System.Drawing.Point(96, 159);
            this.tb_nombre_usuario.Name = "tb_nombre_usuario";
            this.tb_nombre_usuario.Size = new System.Drawing.Size(183, 20);
            this.tb_nombre_usuario.TabIndex = 14;
            // 
            // frmLoginUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_contraseña);
            this.Controls.Add(this.lbl_nombre_usuario);
            this.Controls.Add(this.btn_iniciar_sesion);
            this.Controls.Add(this.btn_registrarse);
            this.Controls.Add(this.tb_contraseña);
            this.Controls.Add(this.tb_nombre_usuario);
            this.Name = "frmLoginUsuario";
            this.Text = "Login - Generala";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_contraseña;
        private System.Windows.Forms.Label lbl_nombre_usuario;
        private System.Windows.Forms.Button btn_iniciar_sesion;
        private System.Windows.Forms.Button btn_registrarse;
        private System.Windows.Forms.TextBox tb_contraseña;
        private System.Windows.Forms.TextBox tb_nombre_usuario;
    }
}