namespace Proyecto
{
    partial class AgreagrExedienteAltas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgreagrExedienteAltas));
            this.BuscarPaciente = new System.Windows.Forms.Button();
            this.Pacientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtCurpPaciente = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Id_doc = new System.Windows.Forms.TextBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.texNombr = new System.Windows.Forms.TextBox();
            this.NombrePac = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // BuscarPaciente
            // 
            this.BuscarPaciente.BackColor = System.Drawing.Color.PaleGreen;
            this.BuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BuscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarPaciente.Location = new System.Drawing.Point(32, 372);
            this.BuscarPaciente.Name = "BuscarPaciente";
            this.BuscarPaciente.Size = new System.Drawing.Size(123, 31);
            this.BuscarPaciente.TabIndex = 0;
            this.BuscarPaciente.Text = "Buscar";
            this.BuscarPaciente.UseVisualStyleBackColor = false;
            this.BuscarPaciente.Click += new System.EventHandler(this.BuscarPaciente_Click);
            // 
            // Pacientes
            // 
            this.Pacientes.AutoSize = true;
            this.Pacientes.BackColor = System.Drawing.Color.Transparent;
            this.Pacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pacientes.Location = new System.Drawing.Point(65, 228);
            this.Pacientes.Name = "Pacientes";
            this.Pacientes.Size = new System.Drawing.Size(162, 20);
            this.Pacientes.TabIndex = 1;
            this.Pacientes.Text = "CURP del Paciente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doctor";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor.Location = new System.Drawing.Point(42, 176);
            this.txtDoctor.MaxLength = 30;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(202, 24);
            this.txtDoctor.TabIndex = 3;
            // 
            // txtCurpPaciente
            // 
            this.txtCurpPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurpPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurpPaciente.Location = new System.Drawing.Point(42, 251);
            this.txtCurpPaciente.MaxLength = 18;
            this.txtCurpPaciente.Name = "txtCurpPaciente";
            this.txtCurpPaciente.Size = new System.Drawing.Size(202, 24);
            this.txtCurpPaciente.TabIndex = 4;
            this.txtCurpPaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurp_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(213, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Id_doc
            // 
            this.Id_doc.Location = new System.Drawing.Point(55, 59);
            this.Id_doc.Name = "Id_doc";
            this.Id_doc.ReadOnly = true;
            this.Id_doc.Size = new System.Drawing.Size(100, 20);
            this.Id_doc.TabIndex = 7;
            this.Id_doc.Visible = false;
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(55, 33);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.ReadOnly = true;
            this.textDireccion.Size = new System.Drawing.Size(100, 20);
            this.textDireccion.TabIndex = 8;
            this.textDireccion.Visible = false;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(55, 85);
            this.buscar.Name = "buscar";
            this.buscar.ReadOnly = true;
            this.buscar.Size = new System.Drawing.Size(100, 20);
            this.buscar.TabIndex = 9;
            this.buscar.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(338, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(635, 169);
            this.dataGridView1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Thistle;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(624, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 31);
            this.button2.TabIndex = 11;
            this.button2.Text = "Buscar paciente";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // texNombr
            // 
            this.texNombr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texNombr.Location = new System.Drawing.Point(584, 141);
            this.texNombr.MaxLength = 30;
            this.texNombr.Name = "texNombr";
            this.texNombr.Size = new System.Drawing.Size(204, 24);
            this.texNombr.TabIndex = 12;
            this.texNombr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // NombrePac
            // 
            this.NombrePac.AutoSize = true;
            this.NombrePac.BackColor = System.Drawing.Color.Transparent;
            this.NombrePac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombrePac.Location = new System.Drawing.Point(600, 116);
            this.NombrePac.Name = "NombrePac";
            this.NombrePac.Size = new System.Drawing.Size(175, 20);
            this.NombrePac.TabIndex = 13;
            this.NombrePac.Text = "Nombre del Paciente";
            // 
            // AgreagrExedienteAltas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.NombrePac);
            this.Controls.Add(this.texNombr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.Id_doc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCurpPaciente);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pacientes);
            this.Controls.Add(this.BuscarPaciente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AgreagrExedienteAltas";
            this.Text = "Agregar Exediente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuscarPaciente;
        private System.Windows.Forms.Label Pacientes;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDoctor;
        public System.Windows.Forms.TextBox txtCurpPaciente;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textDireccion;
        public System.Windows.Forms.TextBox buscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label NombrePac;
        private System.Windows.Forms.TextBox texNombr;
        public System.Windows.Forms.TextBox Id_doc;
    }
}