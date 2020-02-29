namespace Proyecto_Final.Presentacion
{
    partial class FrmGrado
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
            this.txtGrado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarGrado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGrado = new System.Windows.Forms.DataGridView();
            this.btnAgregarGrado = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificarGrado = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGrado
            // 
            this.txtGrado.Location = new System.Drawing.Point(111, 38);
            this.txtGrado.MaxLength = 25;
            this.txtGrado.Name = "txtGrado";
            this.txtGrado.Size = new System.Drawing.Size(178, 20);
            this.txtGrado.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del Grado";
            // 
            // btnEliminarGrado
            // 
            this.btnEliminarGrado.Location = new System.Drawing.Point(12, 93);
            this.btnEliminarGrado.Name = "btnEliminarGrado";
            this.btnEliminarGrado.Size = new System.Drawing.Size(130, 23);
            this.btnEliminarGrado.TabIndex = 2;
            this.btnEliminarGrado.Text = "Eliminar Grado";
            this.btnEliminarGrado.UseVisualStyleBackColor = true;
            this.btnEliminarGrado.Click += new System.EventHandler(this.btnEliminarGrado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGrado);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 338);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grados registrados";
            // 
            // dgvGrado
            // 
            this.dgvGrado.AllowUserToAddRows = false;
            this.dgvGrado.AllowUserToDeleteRows = false;
            this.dgvGrado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvGrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrado.Location = new System.Drawing.Point(6, 19);
            this.dgvGrado.MultiSelect = false;
            this.dgvGrado.Name = "dgvGrado";
            this.dgvGrado.ReadOnly = true;
            this.dgvGrado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrado.Size = new System.Drawing.Size(265, 313);
            this.dgvGrado.TabIndex = 0;
            this.dgvGrado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrado_CellClick);
            // 
            // btnAgregarGrado
            // 
            this.btnAgregarGrado.Location = new System.Drawing.Point(12, 64);
            this.btnAgregarGrado.Name = "btnAgregarGrado";
            this.btnAgregarGrado.Size = new System.Drawing.Size(130, 23);
            this.btnAgregarGrado.TabIndex = 2;
            this.btnAgregarGrado.Text = "Agregar Grado";
            this.btnAgregarGrado.UseVisualStyleBackColor = true;
            this.btnAgregarGrado.Click += new System.EventHandler(this.btnAgregarGrado_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(159, 93);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(58, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(231, 93);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(58, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificarGrado
            // 
            this.btnModificarGrado.Location = new System.Drawing.Point(159, 64);
            this.btnModificarGrado.Name = "btnModificarGrado";
            this.btnModificarGrado.Size = new System.Drawing.Size(130, 23);
            this.btnModificarGrado.TabIndex = 2;
            this.btnModificarGrado.Text = "Modificar Grado";
            this.btnModificarGrado.UseVisualStyleBackColor = true;
            this.btnModificarGrado.Click += new System.EventHandler(this.btnModificarGrado_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(111, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(70, 20);
            this.txtID.TabIndex = 5;
            // 
            // FrmGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 468);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnModificarGrado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnAgregarGrado);
            this.Controls.Add(this.btnEliminarGrado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGrado);
            this.Name = "FrmGrado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grados";
            this.Load += new System.EventHandler(this.FrmGrado_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarGrado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGrado;
        private System.Windows.Forms.Button btnAgregarGrado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificarGrado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
    }
}