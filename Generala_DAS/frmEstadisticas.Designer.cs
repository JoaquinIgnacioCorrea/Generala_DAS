namespace Generala_DAS
{
    partial class frmEstadisticas
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
            this.lblUser = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblTie = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblProm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(12, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(164, 25);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Estadisticas de:";
            // 
            // lblWins
            // 
            this.lblWins.AutoSize = true;
            this.lblWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWins.Location = new System.Drawing.Point(12, 74);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(107, 25);
            this.lblWins.TabIndex = 1;
            this.lblWins.Text = "Victorias: ";
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLosses.Location = new System.Drawing.Point(168, 74);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(100, 25);
            this.lblLosses.TabIndex = 2;
            this.lblLosses.Text = "Derrotas:";
            // 
            // lblTie
            // 
            this.lblTie.AutoSize = true;
            this.lblTie.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTie.Location = new System.Drawing.Point(317, 74);
            this.lblTie.Name = "lblTie";
            this.lblTie.Size = new System.Drawing.Size(102, 25);
            this.lblTie.TabIndex = 3;
            this.lblTie.Text = "Empates:";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.Location = new System.Drawing.Point(12, 123);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(184, 25);
            this.lblTiempo.TabIndex = 4;
            this.lblTiempo.Text = "Tiempo de juego: ";
            // 
            // lblProm
            // 
            this.lblProm.AutoSize = true;
            this.lblProm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProm.Location = new System.Drawing.Point(12, 172);
            this.lblProm.Name = "lblProm";
            this.lblProm.Size = new System.Drawing.Size(198, 25);
            this.lblProm.TabIndex = 5;
            this.lblProm.Text = "Promedio Victorias:";
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 206);
            this.Controls.Add(this.lblProm);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblTie);
            this.Controls.Add(this.lblLosses);
            this.Controls.Add(this.lblWins);
            this.Controls.Add(this.lblUser);
            this.Name = "frmEstadisticas";
            this.Text = "frmEstadisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblTie;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblProm;
    }
}