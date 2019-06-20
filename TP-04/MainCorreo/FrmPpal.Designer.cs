namespace MainCorreo
{
    partial class FrmPpal
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
            this.components = new System.ComponentModel.Container();
            this.lstEstadoIngresado = new System.Windows.Forms.ListBox();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.lstEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lblEnViaje = new System.Windows.Forms.Label();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.groupBoxEstadoPaquete = new System.Windows.Forms.GroupBox();
            this.groupBoxPaquete = new System.Windows.Forms.GroupBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.maskedTextBoxTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxEstadoPaquete.SuspendLayout();
            this.groupBoxPaquete.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEstadoIngresado
            // 
            this.lstEstadoIngresado.FormattingEnabled = true;
            this.lstEstadoIngresado.Location = new System.Drawing.Point(20, 64);
            this.lstEstadoIngresado.Name = "lstEstadoIngresado";
            this.lstEstadoIngresado.Size = new System.Drawing.Size(227, 225);
            this.lstEstadoIngresado.TabIndex = 1;
            // 
            // lblIngresado
            // 
            this.lblIngresado.AutoSize = true;
            this.lblIngresado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblIngresado.Location = new System.Drawing.Point(17, 37);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(62, 15);
            this.lblIngresado.TabIndex = 2;
            this.lblIngresado.Text = "Ingresado";
            // 
            // lstEstadoEnViaje
            // 
            this.lstEstadoEnViaje.FormattingEnabled = true;
            this.lstEstadoEnViaje.Location = new System.Drawing.Point(279, 64);
            this.lstEstadoEnViaje.Name = "lstEstadoEnViaje";
            this.lstEstadoEnViaje.Size = new System.Drawing.Size(227, 225);
            this.lstEstadoEnViaje.TabIndex = 3;
            // 
            // lblEnViaje
            // 
            this.lblEnViaje.AutoSize = true;
            this.lblEnViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblEnViaje.Location = new System.Drawing.Point(289, 37);
            this.lblEnViaje.Name = "lblEnViaje";
            this.lblEnViaje.Size = new System.Drawing.Size(52, 15);
            this.lblEnViaje.TabIndex = 4;
            this.lblEnViaje.Text = "En Viaje";
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.ContextMenuStrip = this.contextMenuStrip1;
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(543, 64);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(227, 225);
            this.lstEstadoEntregado.TabIndex = 5;
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = true;
            this.lblEntregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblEntregado.Location = new System.Drawing.Point(556, 37);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(64, 15);
            this.lblEntregado.TabIndex = 6;
            this.lblEntregado.Text = "Entregado";
            // 
            // groupBoxEstadoPaquete
            // 
            this.groupBoxEstadoPaquete.Controls.Add(this.lblIngresado);
            this.groupBoxEstadoPaquete.Controls.Add(this.lstEstadoIngresado);
            this.groupBoxEstadoPaquete.Controls.Add(this.lstEstadoEnViaje);
            this.groupBoxEstadoPaquete.Controls.Add(this.lstEstadoEntregado);
            this.groupBoxEstadoPaquete.Controls.Add(this.lblEntregado);
            this.groupBoxEstadoPaquete.Controls.Add(this.lblEnViaje);
            this.groupBoxEstadoPaquete.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEstadoPaquete.Name = "groupBoxEstadoPaquete";
            this.groupBoxEstadoPaquete.Size = new System.Drawing.Size(789, 307);
            this.groupBoxEstadoPaquete.TabIndex = 7;
            this.groupBoxEstadoPaquete.TabStop = false;
            this.groupBoxEstadoPaquete.Text = "Estado Paquetes";
            // 
            // groupBoxPaquete
            // 
            this.groupBoxPaquete.Controls.Add(this.btnMostrarTodos);
            this.groupBoxPaquete.Controls.Add(this.btnAgregar);
            this.groupBoxPaquete.Controls.Add(this.textBoxDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblDireccion);
            this.groupBoxPaquete.Controls.Add(this.maskedTextBoxTrackingID);
            this.groupBoxPaquete.Controls.Add(this.lblTrackingID);
            this.groupBoxPaquete.Location = new System.Drawing.Point(459, 334);
            this.groupBoxPaquete.Name = "groupBoxPaquete";
            this.groupBoxPaquete.Size = new System.Drawing.Size(342, 139);
            this.groupBoxPaquete.TabIndex = 8;
            this.groupBoxPaquete.TabStop = false;
            this.groupBoxPaquete.Text = "Paquete";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(216, 77);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(107, 36);
            this.btnMostrarTodos.TabIndex = 5;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(216, 27);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 36);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(6, 94);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(180, 20);
            this.textBoxDireccion.TabIndex = 3;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(15, 77);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Direccion";
            // 
            // maskedTextBoxTrackingID
            // 
            this.maskedTextBoxTrackingID.Location = new System.Drawing.Point(6, 43);
            this.maskedTextBoxTrackingID.Mask = "000-000-0000";
            this.maskedTextBoxTrackingID.Name = "maskedTextBoxTrackingID";
            this.maskedTextBoxTrackingID.Size = new System.Drawing.Size(180, 20);
            this.maskedTextBoxTrackingID.TabIndex = 1;
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(15, 27);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(60, 13);
            this.lblTrackingID.TabIndex = 0;
            this.lblTrackingID.Text = "TrackingID";
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Enabled = false;
            this.rtbMostrar.Location = new System.Drawing.Point(12, 334);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(431, 139);
            this.rtbMostrar.TabIndex = 9;
            this.rtbMostrar.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 485);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.groupBoxPaquete);
            this.Controls.Add(this.groupBoxEstadoPaquete);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Gabriel.Saliba.2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPpal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPpal_Load);
            this.groupBoxEstadoPaquete.ResumeLayout(false);
            this.groupBoxEstadoPaquete.PerformLayout();
            this.groupBoxPaquete.ResumeLayout(false);
            this.groupBoxPaquete.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstEstadoIngresado;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.ListBox lstEstadoEnViaje;
        private System.Windows.Forms.Label lblEnViaje;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.GroupBox groupBoxEstadoPaquete;
        private System.Windows.Forms.GroupBox groupBoxPaquete;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTrackingID;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

