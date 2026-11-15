namespace Generala_DAS
{
    partial class frmVisorXML
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
            this.lblArchivo = new System.Windows.Forms.Label();
            this.cmbArchivosXml = new System.Windows.Forms.ComboBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(16, 19);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(102, 13);
            this.lblArchivo.TabIndex = 0;
            this.lblArchivo.Text = "Partida XML:";
            // 
            // cmbArchivosXml
            // 
            this.cmbArchivosXml.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArchivosXml.FormattingEnabled = true;
            this.cmbArchivosXml.Location = new System.Drawing.Point(95, 15);
            this.cmbArchivosXml.Name = "cmbArchivosXml";
            this.cmbArchivosXml.Size = new System.Drawing.Size(340, 21);
            this.cmbArchivosXml.TabIndex = 1;
            this.cmbArchivosXml.SelectedIndexChanged += new System.EventHandler(this.cmbArchivosXml_SelectedIndexChanged);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(445, 13);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(115, 25);
            this.btnExaminar.TabIndex = 2;
            this.btnExaminar.Text = "Abrir archivo...";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(568, 13);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(105, 25);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Actualizar lista";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(16, 48);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(657, 365);
            this.dgvMovimientos.TabIndex = 4;
            // 
            // frmVisorXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 428);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.cmbArchivosXml);
            this.Controls.Add(this.lblArchivo);
            this.Name = "frmVisorXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visor de Movimientos XML";
            this.Load += new System.EventHandler(this.frmVisorXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.ComboBox cmbArchivosXml;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvMovimientos;
    }
}
