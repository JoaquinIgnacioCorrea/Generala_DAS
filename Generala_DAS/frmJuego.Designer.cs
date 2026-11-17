namespace Generala_DAS
{
    partial class frmJuego
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
            this.lbl_mensaje_select_casilla = new System.Windows.Forms.Label();
            this.dado5 = new System.Windows.Forms.PictureBox();
            this.dado4 = new System.Windows.Forms.PictureBox();
            this.dado3 = new System.Windows.Forms.PictureBox();
            this.dado2 = new System.Windows.Forms.PictureBox();
            this.dado1 = new System.Windows.Forms.PictureBox();
            this.btn_terminar_turno = new System.Windows.Forms.Button();
            this.btn_bloquear_dados = new System.Windows.Forms.Button();
            this.btn_tirar_dados = new System.Windows.Forms.Button();
            this.Tablero = new System.Windows.Forms.DataGridView();
            this.lb_jugadas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dado5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_mensaje_select_casilla
            // 
            this.lbl_mensaje_select_casilla.AutoSize = true;
            this.lbl_mensaje_select_casilla.Location = new System.Drawing.Point(219, 229);
            this.lbl_mensaje_select_casilla.Name = "lbl_mensaje_select_casilla";
            this.lbl_mensaje_select_casilla.Size = new System.Drawing.Size(0, 13);
            this.lbl_mensaje_select_casilla.TabIndex = 19;
            // 
            // dado5
            // 
            this.dado5.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado5.Location = new System.Drawing.Point(435, 284);
            this.dado5.Name = "dado5";
            this.dado5.Size = new System.Drawing.Size(84, 81);
            this.dado5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado5.TabIndex = 18;
            this.dado5.TabStop = false;
            // 
            // dado4
            // 
            this.dado4.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado4.Location = new System.Drawing.Point(336, 284);
            this.dado4.Name = "dado4";
            this.dado4.Size = new System.Drawing.Size(84, 81);
            this.dado4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado4.TabIndex = 17;
            this.dado4.TabStop = false;
            // 
            // dado3
            // 
            this.dado3.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado3.Location = new System.Drawing.Point(235, 284);
            this.dado3.Name = "dado3";
            this.dado3.Size = new System.Drawing.Size(84, 81);
            this.dado3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado3.TabIndex = 16;
            this.dado3.TabStop = false;
            // 
            // dado2
            // 
            this.dado2.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado2.Location = new System.Drawing.Point(136, 284);
            this.dado2.Name = "dado2";
            this.dado2.Size = new System.Drawing.Size(84, 81);
            this.dado2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado2.TabIndex = 15;
            this.dado2.TabStop = false;
            // 
            // dado1
            // 
            this.dado1.Image = global::Generala_DAS.Properties.Resources.dado_cara_1;
            this.dado1.Location = new System.Drawing.Point(34, 284);
            this.dado1.Name = "dado1";
            this.dado1.Size = new System.Drawing.Size(84, 81);
            this.dado1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dado1.TabIndex = 14;
            this.dado1.TabStop = false;
            // 
            // btn_terminar_turno
            // 
            this.btn_terminar_turno.Location = new System.Drawing.Point(336, 245);
            this.btn_terminar_turno.Name = "btn_terminar_turno";
            this.btn_terminar_turno.Size = new System.Drawing.Size(110, 23);
            this.btn_terminar_turno.TabIndex = 13;
            this.btn_terminar_turno.Text = "Terminar turno";
            this.btn_terminar_turno.UseVisualStyleBackColor = true;
            this.btn_terminar_turno.Click += new System.EventHandler(this.btn_terminar_turno_Click);
            // 
            // btn_bloquear_dados
            // 
            this.btn_bloquear_dados.Location = new System.Drawing.Point(222, 245);
            this.btn_bloquear_dados.Name = "btn_bloquear_dados";
            this.btn_bloquear_dados.Size = new System.Drawing.Size(108, 23);
            this.btn_bloquear_dados.TabIndex = 12;
            this.btn_bloquear_dados.Text = "Bloquear dados";
            this.btn_bloquear_dados.UseVisualStyleBackColor = true;
            this.btn_bloquear_dados.Click += new System.EventHandler(this.btn_bloquear_dados_Click);
            // 
            // btn_tirar_dados
            // 
            this.btn_tirar_dados.Location = new System.Drawing.Point(108, 245);
            this.btn_tirar_dados.Name = "btn_tirar_dados";
            this.btn_tirar_dados.Size = new System.Drawing.Size(108, 23);
            this.btn_tirar_dados.TabIndex = 11;
            this.btn_tirar_dados.Text = "Tirar";
            this.btn_tirar_dados.UseVisualStyleBackColor = true;
            this.btn_tirar_dados.Click += new System.EventHandler(this.btn_tirar_dados_Click);
            // 
            // Tablero
            // 
            this.Tablero.AllowUserToAddRows = false;
            this.Tablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tablero.Location = new System.Drawing.Point(34, 34);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(496, 187);
            this.Tablero.TabIndex = 10;
            // 
            // lb_jugadas
            // 
            this.lb_jugadas.FormattingEnabled = true;
            this.lb_jugadas.Location = new System.Drawing.Point(574, 34);
            this.lb_jugadas.Name = "lb_jugadas";
            this.lb_jugadas.Size = new System.Drawing.Size(234, 329);
            this.lb_jugadas.TabIndex = 20;
            // 
            // frmJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 410);
            this.Controls.Add(this.lb_jugadas);
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
            this.Name = "frmJuego";
            this.Text = "Partida - Generala";
            ((System.ComponentModel.ISupportInitialize)(this.dado5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dado1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mensaje_select_casilla;
        private System.Windows.Forms.PictureBox dado5;
        private System.Windows.Forms.PictureBox dado4;
        private System.Windows.Forms.PictureBox dado3;
        private System.Windows.Forms.PictureBox dado2;
        private System.Windows.Forms.PictureBox dado1;
        private System.Windows.Forms.Button btn_terminar_turno;
        private System.Windows.Forms.Button btn_bloquear_dados;
        private System.Windows.Forms.Button btn_tirar_dados;
        private System.Windows.Forms.DataGridView Tablero;
        private System.Windows.Forms.ListBox lb_jugadas;
    }
}