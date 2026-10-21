namespace Generala_DAS
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucTableroPuntaje1 = new Generala_DAS.ucTableroPuntaje();
            this.SuspendLayout();
            // 
            // ucTableroPuntaje1
            // 
            this.ucTableroPuntaje1.Location = new System.Drawing.Point(2, 3);
            this.ucTableroPuntaje1.Name = "ucTableroPuntaje1";
            this.ucTableroPuntaje1.Size = new System.Drawing.Size(764, 476);
            this.ucTableroPuntaje1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.ucTableroPuntaje1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ucTableroPuntaje ucTableroPuntaje1;
    }
}

