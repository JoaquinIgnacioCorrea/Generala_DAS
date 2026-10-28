namespace Generala_DAS
{
    partial class ucTableroPuntaje
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
            this.Tablero = new System.Windows.Forms.DataGridView();
            this.btn_tirar_dados = new System.Windows.Forms.Button();
            this.btn_bloquear_dados = new System.Windows.Forms.Button();
            this.btn_terminar_turno = new System.Windows.Forms.Button();
            this.dado5 = new System.Windows.Forms.PictureBox();
            this.dado4 = new System.Windows.Forms.PictureBox();
            this.dado3 = new System.Windows.Forms.PictureBox();
            this.dado2 = new System.Windows.Forms.PictureBox();
            this.dado1 = new System.Windows.Forms.PictureBox();
            this.lbl_mensaje_select_casilla = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tablero
            // 
            this.Tablero.AllowUserToAddRows = false;
            this.Tablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tablero.Location = new System.Drawing.Point(17, 38);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(730, 187);
            this.Tablero.TabIndex = 0;
            // 
            // btn_tirar_dados
            // 
            this.btn_tirar_dados.Location = new System.Drawing.Point(202, 256);
            this.btn_tirar_dados.Name = "btn_tirar_dados";
            this.btn_tirar_dados.Size = new System.Drawing.Size(108, 23);
            this.btn_tirar_dados.TabIndex = 1;
            this.btn_tirar_dados.Text = "Tirar";
            this.btn_tirar_dados.UseVisualStyleBackColor = true;
            this.btn_tirar_dados.Click += new System.EventHandler(this.btn_tirar_dados_Click);
            // 
            // btn_bloquear_dados
            // 
            this.btn_bloquear_dados.Location = new System.Drawing.Point(316, 256);
            this.btn_bloquear_dados.Name = "btn_bloquear_dados";
            this.btn_bloquear_dados.Size = new System.Drawing.Size(108, 23);
            this.btn_bloquear_dados.TabIndex = 2;
            this.btn_bloquear_dados.Text = "Bloquear dados";
            this.btn_bloquear_dados.UseVisualStyleBackColor = true;
            this.btn_bloquear_dados.Click += new System.EventHandler(this.btn_bloquear_dados_Click);
            // 
            // btn_terminar_turno
            // 
            this.btn_terminar_turno.Location = new System.Drawing.Point(430, 256);
            this.btn_terminar_turno.Name = "btn_terminar_turno";
            this.btn_terminar_turno.Size = new System.Drawing.Size(110, 23);
            this.btn_terminar_turno.TabIndex = 3;
            this.btn_terminar_turno.Text = "Terminar turno";
            this.btn_terminar_turno.UseVisualStyleBackColor = true;
            this.btn_terminar_turno.Click += new System.EventHandler(this.btn_terminar_turno_Click);
            // 
            // dado5
            // 
            this.dado5.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado5.Location = new System.Drawing.Point(559, 300);
            this.dado5.Name = "dado5";
            this.dado5.Size = new System.Drawing.Size(118, 117);
            this.dado5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado5.TabIndex = 8;
            this.dado5.TabStop = false;
            this.dado5.Click += new System.EventHandler(this.dado_Click);
            // 
            // dado4
            // 
            this.dado4.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado4.Location = new System.Drawing.Point(435, 300);
            this.dado4.Name = "dado4";
            this.dado4.Size = new System.Drawing.Size(118, 117);
            this.dado4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado4.TabIndex = 7;
            this.dado4.TabStop = false;
            this.dado4.Click += new System.EventHandler(this.dado_Click);
            // 
            // dado3
            // 
            this.dado3.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado3.Location = new System.Drawing.Point(311, 300);
            this.dado3.Name = "dado3";
            this.dado3.Size = new System.Drawing.Size(118, 117);
            this.dado3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado3.TabIndex = 6;
            this.dado3.TabStop = false;
            this.dado3.Click += new System.EventHandler(this.dado_Click);
            // 
            // dado2
            // 
            this.dado2.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado2.Location = new System.Drawing.Point(187, 300);
            this.dado2.Name = "dado2";
            this.dado2.Size = new System.Drawing.Size(118, 117);
            this.dado2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado2.TabIndex = 5;
            this.dado2.TabStop = false;
            this.dado2.Click += new System.EventHandler(this.dado_Click);
            // 
            // dado1
            // 
            this.dado1.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado1.Location = new System.Drawing.Point(63, 300);
            this.dado1.Name = "dado1";
            this.dado1.Size = new System.Drawing.Size(118, 117);
            this.dado1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado1.TabIndex = 4;
            this.dado1.TabStop = false;
            this.dado1.Click += new System.EventHandler(this.dado_Click);
            // 
            // lbl_mensaje_select_casilla
            // 
            this.lbl_mensaje_select_casilla.AutoSize = true;
            this.lbl_mensaje_select_casilla.Location = new System.Drawing.Point(313, 240);
            this.lbl_mensaje_select_casilla.Name = "lbl_mensaje_select_casilla";
            this.lbl_mensaje_select_casilla.Size = new System.Drawing.Size(0, 13);
            this.lbl_mensaje_select_casilla.TabIndex = 9;
            // 
            // ucTableroPuntaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_mensaje_select_casilla);
            this.Controls.Add(this.dado5);
            this.Controls.Add(this.dado4);
            this.Controls.Add(this.dado3);
            this.Controls.Add(this.dado2);
            this.Controls.Add(this.dado1);
            this.Controls.Add(this.btn_terminar_turno);
            this.Controls.Add(this.btn_bloquear_dados);
            this.Controls.Add(this.btn_tirar_dados);
            this.Controls.Add(this.Tablero);
            this.Name = "ucTableroPuntaje";
            this.Size = new System.Drawing.Size(764, 431);
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Tablero;
        private System.Windows.Forms.Button btn_tirar_dados;
        private System.Windows.Forms.Button btn_bloquear_dados;
        private System.Windows.Forms.Button btn_terminar_turno;
        private System.Windows.Forms.PictureBox dado1;
        private System.Windows.Forms.PictureBox dado2;
        private System.Windows.Forms.PictureBox dado4;
        private System.Windows.Forms.PictureBox dado3;
        private System.Windows.Forms.PictureBox dado5;
        private System.Windows.Forms.Label lbl_mensaje_select_casilla;
    }
}
