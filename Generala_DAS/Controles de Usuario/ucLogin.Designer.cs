namespace Generala_DAS.Controles_de_Usuario
{
    partial class ucLogin
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_nombre_usuario = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_registrarse = new System.Windows.Forms.Button();
            this.btn_iniciar_sesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_pass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_nombre_usuario
            // 
            this.tb_nombre_usuario.Location = new System.Drawing.Point(264, 161);
            this.tb_nombre_usuario.Name = "tb_nombre_usuario";
            this.tb_nombre_usuario.Size = new System.Drawing.Size(183, 20);
            this.tb_nombre_usuario.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(264, 230);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 20);
            this.textBox2.TabIndex = 1;
            // 
            // btn_registrarse
            // 
            this.btn_registrarse.Location = new System.Drawing.Point(264, 297);
            this.btn_registrarse.Name = "btn_registrarse";
            this.btn_registrarse.Size = new System.Drawing.Size(183, 23);
            this.btn_registrarse.TabIndex = 2;
            this.btn_registrarse.Text = "Registrarse";
            this.btn_registrarse.UseVisualStyleBackColor = true;
            this.btn_registrarse.Click += new System.EventHandler(this.btn_registrarse_Click);
            // 
            // btn_iniciar_sesion
            // 
            this.btn_iniciar_sesion.Location = new System.Drawing.Point(264, 346);
            this.btn_iniciar_sesion.Name = "btn_iniciar_sesion";
            this.btn_iniciar_sesion.Size = new System.Drawing.Size(183, 23);
            this.btn_iniciar_sesion.TabIndex = 3;
            this.btn_iniciar_sesion.Text = "Iniciar Sesion";
            this.btn_iniciar_sesion.UseVisualStyleBackColor = true;
            this.btn_iniciar_sesion.Click += new System.EventHandler(this.btn_iniciar_sesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre Usuario";
            // 
            // tb_pass
            // 
            this.tb_pass.AutoSize = true;
            this.tb_pass.Location = new System.Drawing.Point(261, 214);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(61, 13);
            this.tb_pass.TabIndex = 5;
            this.tb_pass.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Generala";
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_iniciar_sesion);
            this.Controls.Add(this.btn_registrarse);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tb_nombre_usuario);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(733, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_nombre_usuario;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_registrarse;
        private System.Windows.Forms.Button btn_iniciar_sesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tb_pass;
        private System.Windows.Forms.Label label3;
    }
}
