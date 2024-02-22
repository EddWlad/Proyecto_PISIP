﻿namespace UI.Windows.Formularios
{
    partial class FrmPagosMiembros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagosMiembros));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboBuscarPago = new System.Windows.Forms.ComboBox();
            this.txtTipoCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMembresia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtListaPagosMiembros = new System.Windows.Forms.DataGridView();
            this.btnSeleccionarPago = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_pago_diario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBusquedaPagos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgClientesMiembros = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_membresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo_membresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_asistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.txtIndice2 = new System.Windows.Forms.TextBox();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReporte = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiarPagos = new System.Windows.Forms.Button();
            this.btnBuscarPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtListaPagosMiembros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesMiembros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombre.Location = new System.Drawing.Point(204, 297);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(199, 23);
            this.txtNombre.TabIndex = 155;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(201, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 154;
            this.label11.Text = "Nombre";
            // 
            // cboBuscarPago
            // 
            this.cboBuscarPago.FormattingEnabled = true;
            this.cboBuscarPago.Location = new System.Drawing.Point(788, 239);
            this.cboBuscarPago.Name = "cboBuscarPago";
            this.cboBuscarPago.Size = new System.Drawing.Size(128, 21);
            this.cboBuscarPago.TabIndex = 153;
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTipoCliente.BackColor = System.Drawing.Color.White;
            this.txtTipoCliente.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTipoCliente.Location = new System.Drawing.Point(204, 351);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(199, 23);
            this.txtTipoCliente.TabIndex = 152;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(201, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 151;
            this.label10.Text = "Tipo Membresia";
            // 
            // txtMembresia
            // 
            this.txtMembresia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMembresia.BackColor = System.Drawing.Color.White;
            this.txtMembresia.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembresia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMembresia.Location = new System.Drawing.Point(204, 405);
            this.txtMembresia.Name = "txtMembresia";
            this.txtMembresia.ReadOnly = true;
            this.txtMembresia.Size = new System.Drawing.Size(199, 23);
            this.txtMembresia.TabIndex = 149;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(201, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 148;
            this.label9.Text = "Membresia";
            // 
            // dtListaPagosMiembros
            // 
            this.dtListaPagosMiembros.AllowUserToAddRows = false;
            this.dtListaPagosMiembros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtListaPagosMiembros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtListaPagosMiembros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtListaPagosMiembros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListaPagosMiembros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionarPago,
            this.id_pago_diario,
            this.cedula_pago,
            this.nombre_pago,
            this.fecha,
            this.costo,
            this.cliente_tipo});
            this.dtListaPagosMiembros.Location = new System.Drawing.Point(434, 286);
            this.dtListaPagosMiembros.MultiSelect = false;
            this.dtListaPagosMiembros.Name = "dtListaPagosMiembros";
            this.dtListaPagosMiembros.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtListaPagosMiembros.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtListaPagosMiembros.RowTemplate.Height = 28;
            this.dtListaPagosMiembros.Size = new System.Drawing.Size(709, 256);
            this.dtListaPagosMiembros.TabIndex = 147;
            this.dtListaPagosMiembros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListaPagosMiembros_CellContentClick);
            this.dtListaPagosMiembros.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtListaPagosMiembros_CellPainting);
            // 
            // btnSeleccionarPago
            // 
            this.btnSeleccionarPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnSeleccionarPago.FillWeight = 13.11036F;
            this.btnSeleccionarPago.HeaderText = "";
            this.btnSeleccionarPago.Name = "btnSeleccionarPago";
            this.btnSeleccionarPago.ReadOnly = true;
            this.btnSeleccionarPago.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnSeleccionarPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnSeleccionarPago.Width = 38;
            // 
            // id_pago_diario
            // 
            this.id_pago_diario.HeaderText = "ID";
            this.id_pago_diario.Name = "id_pago_diario";
            this.id_pago_diario.ReadOnly = true;
            this.id_pago_diario.Visible = false;
            // 
            // cedula_pago
            // 
            this.cedula_pago.HeaderText = "Cedula";
            this.cedula_pago.Name = "cedula_pago";
            this.cedula_pago.ReadOnly = true;
            // 
            // nombre_pago
            // 
            this.nombre_pago.HeaderText = "Nombre";
            this.nombre_pago.Name = "nombre_pago";
            this.nombre_pago.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            // 
            // cliente_tipo
            // 
            this.cliente_tipo.HeaderText = "Tipo Cliente";
            this.cliente_tipo.Name = "cliente_tipo";
            this.cliente_tipo.ReadOnly = true;
            // 
            // txtBusquedaPagos
            // 
            this.txtBusquedaPagos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBusquedaPagos.BackColor = System.Drawing.Color.White;
            this.txtBusquedaPagos.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusquedaPagos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBusquedaPagos.Location = new System.Drawing.Point(928, 238);
            this.txtBusquedaPagos.Name = "txtBusquedaPagos";
            this.txtBusquedaPagos.Size = new System.Drawing.Size(114, 23);
            this.txtBusquedaPagos.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(717, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 145;
            this.label5.Text = "Buscar por:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(434, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(709, 43);
            this.label8.TabIndex = 144;
            this.label8.Text = "Lista de pagos";
            // 
            // txtCedula
            // 
            this.txtCedula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCedula.BackColor = System.Drawing.Color.White;
            this.txtCedula.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCedula.Location = new System.Drawing.Point(204, 245);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.ReadOnly = true;
            this.txtCedula.Size = new System.Drawing.Size(199, 23);
            this.txtCedula.TabIndex = 143;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(201, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 142;
            this.label3.Text = "Cedula";
            // 
            // dtgClientesMiembros
            // 
            this.dtgClientesMiembros.AllowUserToAddRows = false;
            this.dtgClientesMiembros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgClientesMiembros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgClientesMiembros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgClientesMiembros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesMiembros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.id_cliente,
            this.cedula,
            this.nombre,
            this.membresia,
            this.fecha_inicio,
            this.fecha_fin,
            this.tipo_membresia,
            this.costo_membresia,
            this.id_asistencia});
            this.dtgClientesMiembros.Location = new System.Drawing.Point(434, 70);
            this.dtgClientesMiembros.MultiSelect = false;
            this.dtgClientesMiembros.Name = "dtgClientesMiembros";
            this.dtgClientesMiembros.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgClientesMiembros.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgClientesMiembros.RowTemplate.Height = 28;
            this.dtgClientesMiembros.Size = new System.Drawing.Size(709, 145);
            this.dtgClientesMiembros.TabIndex = 141;
            this.dtgClientesMiembros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgClientesMiembros_CellContentClick);
            this.dtgClientesMiembros.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgClientesMiembros_CellPainting);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnSeleccionar.FillWeight = 13.11036F;
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnSeleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnSeleccionar.Width = 38;
            // 
            // id_cliente
            // 
            this.id_cliente.HeaderText = "ID";
            this.id_cliente.Name = "id_cliente";
            this.id_cliente.ReadOnly = true;
            this.id_cliente.Visible = false;
            // 
            // cedula
            // 
            this.cedula.HeaderText = "Cedula";
            this.cedula.Name = "cedula";
            this.cedula.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // membresia
            // 
            this.membresia.HeaderText = "Membresia";
            this.membresia.Name = "membresia";
            this.membresia.ReadOnly = true;
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.HeaderText = "Fecha Inicio";
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.ReadOnly = true;
            // 
            // fecha_fin
            // 
            this.fecha_fin.HeaderText = "Fecha Fin";
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.ReadOnly = true;
            // 
            // tipo_membresia
            // 
            this.tipo_membresia.HeaderText = "Tipo Membresia";
            this.tipo_membresia.Name = "tipo_membresia";
            this.tipo_membresia.ReadOnly = true;
            // 
            // costo_membresia
            // 
            this.costo_membresia.HeaderText = "Costo";
            this.costo_membresia.Name = "costo_membresia";
            this.costo_membresia.ReadOnly = true;
            // 
            // id_asistencia
            // 
            this.id_asistencia.HeaderText = "ID_Registro";
            this.id_asistencia.Name = "id_asistencia";
            this.id_asistencia.ReadOnly = true;
            this.id_asistencia.Visible = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBusqueda.Location = new System.Drawing.Point(928, 19);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(114, 23);
            this.txtBusqueda.TabIndex = 138;
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(798, 20);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(124, 21);
            this.cboBusqueda.TabIndex = 137;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(727, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 136;
            this.label7.Text = "Buscar por:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(434, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(709, 43);
            this.label6.TabIndex = 135;
            this.label6.Text = "Detalle clientes miembros";
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFechaRegistro.BackColor = System.Drawing.Color.White;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFechaRegistro.Location = new System.Drawing.Point(204, 156);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.ReadOnly = true;
            this.txtFechaRegistro.Size = new System.Drawing.Size(199, 23);
            this.txtFechaRegistro.TabIndex = 130;
            // 
            // txtCosto
            // 
            this.txtCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCosto.BackColor = System.Drawing.Color.White;
            this.txtCosto.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCosto.Location = new System.Drawing.Point(204, 198);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(199, 23);
            this.txtCosto.TabIndex = 132;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(201, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Costo";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblNombre.Location = new System.Drawing.Point(201, 140);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(32, 13);
            this.lblNombre.TabIndex = 129;
            this.lblNombre.Text = "Fecha";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(188, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 554);
            this.label4.TabIndex = 128;
            // 
            // txtId2
            // 
            this.txtId2.Location = new System.Drawing.Point(202, 59);
            this.txtId2.Name = "txtId2";
            this.txtId2.ReadOnly = true;
            this.txtId2.Size = new System.Drawing.Size(26, 20);
            this.txtId2.TabIndex = 160;
            this.txtId2.Text = "0";
            this.txtId2.Visible = false;
            // 
            // txtIndice2
            // 
            this.txtIndice2.Location = new System.Drawing.Point(202, 85);
            this.txtIndice2.Name = "txtIndice2";
            this.txtIndice2.ReadOnly = true;
            this.txtIndice2.Size = new System.Drawing.Size(26, 20);
            this.txtIndice2.TabIndex = 159;
            this.txtIndice2.Text = "0";
            this.txtIndice2.Visible = false;
            // 
            // txtIndice
            // 
            this.txtIndice.Location = new System.Drawing.Point(375, 59);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.ReadOnly = true;
            this.txtIndice.Size = new System.Drawing.Size(26, 20);
            this.txtIndice.TabIndex = 157;
            this.txtIndice.Text = "0";
            this.txtIndice.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(375, 85);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(26, 20);
            this.txtId.TabIndex = 156;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(191, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 25);
            this.label2.TabIndex = 161;
            this.label2.Text = "Detalle de pago miembros";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::UI.Windows.Properties.Resources.pagoMiembro;
            this.pictureBox1.Location = new System.Drawing.Point(234, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 158;
            this.pictureBox1.TabStop = false;
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.White;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.btnReporte.IconColor = System.Drawing.Color.Green;
            this.btnReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReporte.IconSize = 20;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(585, 236);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(114, 26);
            this.btnReporte.TabIndex = 150;
            this.btnReporte.Text = "Descargar Excel";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(1092, 16);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(38, 27);
            this.btnLimpiar.TabIndex = 140;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(1048, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(38, 27);
            this.btnBuscar.TabIndex = 139;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(204, 487);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(199, 32);
            this.btnEliminar.TabIndex = 134;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Image = global::UI.Windows.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(204, 450);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(199, 31);
            this.btnGuardar.TabIndex = 133;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiarPagos
            // 
            this.btnLimpiarPagos.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLimpiarPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarPagos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiarPagos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnLimpiarPagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLimpiarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarPagos.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarPagos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpiarPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarPagos.Image")));
            this.btnLimpiarPagos.Location = new System.Drawing.Point(1092, 236);
            this.btnLimpiarPagos.Name = "btnLimpiarPagos";
            this.btnLimpiarPagos.Size = new System.Drawing.Size(38, 27);
            this.btnLimpiarPagos.TabIndex = 163;
            this.btnLimpiarPagos.UseVisualStyleBackColor = false;
            this.btnLimpiarPagos.Click += new System.EventHandler(this.btnLimpiarPagos_Click);
            // 
            // btnBuscarPago
            // 
            this.btnBuscarPago.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnBuscarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarPago.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.btnBuscarPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnBuscarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPago.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPago.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscarPago.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPago.Image")));
            this.btnBuscarPago.Location = new System.Drawing.Point(1048, 236);
            this.btnBuscarPago.Name = "btnBuscarPago";
            this.btnBuscarPago.Size = new System.Drawing.Size(38, 27);
            this.btnBuscarPago.TabIndex = 162;
            this.btnBuscarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPago.UseVisualStyleBackColor = false;
            this.btnBuscarPago.Click += new System.EventHandler(this.btnBuscarPago_Click);
            // 
            // FrmPagosMiembros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1155, 554);
            this.Controls.Add(this.btnLimpiarPagos);
            this.Controls.Add(this.btnBuscarPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId2);
            this.Controls.Add(this.txtIndice2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtIndice);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboBuscarPago);
            this.Controls.Add(this.txtTipoCliente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.txtMembresia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtListaPagosMiembros);
            this.Controls.Add(this.txtBusquedaPagos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgClientesMiembros);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cboBusqueda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtFechaRegistro);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPagosMiembros";
            this.Text = "FrmPagosMiembros";
            this.Load += new System.EventHandler(this.FrmPagosMiembros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtListaPagosMiembros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesMiembros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboBuscarPago;
        private System.Windows.Forms.TextBox txtTipoCliente;
        private System.Windows.Forms.Label label10;
        private FontAwesome.Sharp.IconButton btnReporte;
        private System.Windows.Forms.TextBox txtMembresia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dtListaPagosMiembros;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionarPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pago_diario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_tipo;
        private System.Windows.Forms.TextBox txtBusquedaPagos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgClientesMiembros;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.TextBox txtIndice2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiarPagos;
        private System.Windows.Forms.Button btnBuscarPago;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn membresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_membresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo_membresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_asistencia;
    }
}