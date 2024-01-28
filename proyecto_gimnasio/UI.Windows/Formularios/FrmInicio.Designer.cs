namespace UI.Windows.Formularios
{
    partial class FrmInicio
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
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerar = new System.Windows.Forms.PictureBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.pnlSubmenuMembresias = new System.Windows.Forms.Panel();
            this.btnNuevaMembresia = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnCostosMembresia = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnTiposMembresia = new System.Windows.Forms.Button();
            this.pnlSubMenuCliente = new System.Windows.Forms.Panel();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnTipoCliente = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.pnlMembresias = new System.Windows.Forms.Panel();
            this.btnMembresias = new System.Windows.Forms.Button();
            this.pnlPagoDiario = new System.Windows.Forms.Panel();
            this.panlPromocion = new System.Windows.Forms.Panel();
            this.btnPagoDiario = new System.Windows.Forms.Button();
            this.btnPromociones = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnSubInicio = new System.Windows.Forms.PictureBox();
            this.panleContenedor = new System.Windows.Forms.Panel();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerar)).BeginInit();
            this.MenuVertical.SuspendLayout();
            this.pnlSubmenuMembresias.SuspendLayout();
            this.pnlSubMenuCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.OrangeRed;
            this.BarraTitulo.Controls.Add(this.lblNombre);
            this.BarraTitulo.Controls.Add(this.pictureBox1);
            this.BarraTitulo.Controls.Add(this.btnRestaurar);
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnMaximizar);
            this.BarraTitulo.Controls.Add(this.btnCerar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1155, 30);
            this.BarraTitulo.TabIndex = 0;
            this.BarraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.BarraTitulo_Paint);
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Wide Latin", 7F);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNombre.Location = new System.Drawing.Point(41, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(260, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "FENIX WORKOUT CENTER";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::UI.Windows.Properties.Resources.pesas;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = global::UI.Windows.Properties.Resources.resturar;
            this.btnRestaurar.Location = new System.Drawing.Point(1091, 3);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(23, 23);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 1;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = global::UI.Windows.Properties.Resources.minus_circle_regular_24;
            this.btnMinimizar.Location = new System.Drawing.Point(1062, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(23, 23);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::UI.Windows.Properties.Resources.maximizar;
            this.btnMaximizar.Location = new System.Drawing.Point(1091, 3);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(23, 23);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 1;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCerar
            // 
            this.btnCerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerar.Image = global::UI.Windows.Properties.Resources.close;
            this.btnCerar.Location = new System.Drawing.Point(1120, 3);
            this.btnCerar.Name = "btnCerar";
            this.btnCerar.Size = new System.Drawing.Size(23, 23);
            this.btnCerar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerar.TabIndex = 0;
            this.btnCerar.TabStop = false;
            this.btnCerar.Click += new System.EventHandler(this.btnCerar_Click);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.SystemColors.Desktop;
            this.MenuVertical.Controls.Add(this.pnlSubmenuMembresias);
            this.MenuVertical.Controls.Add(this.pnlSubMenuCliente);
            this.MenuVertical.Controls.Add(this.pnlMembresias);
            this.MenuVertical.Controls.Add(this.btnMembresias);
            this.MenuVertical.Controls.Add(this.pnlPagoDiario);
            this.MenuVertical.Controls.Add(this.panlPromocion);
            this.MenuVertical.Controls.Add(this.btnPagoDiario);
            this.MenuVertical.Controls.Add(this.btnPromociones);
            this.MenuVertical.Controls.Add(this.lblUsuario);
            this.MenuVertical.Controls.Add(this.label1);
            this.MenuVertical.Controls.Add(this.panel3);
            this.MenuVertical.Controls.Add(this.btnClientes);
            this.MenuVertical.Controls.Add(this.btnSubInicio);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 30);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(188, 554);
            this.MenuVertical.TabIndex = 1;
            // 
            // pnlSubmenuMembresias
            // 
            this.pnlSubmenuMembresias.Controls.Add(this.btnNuevaMembresia);
            this.pnlSubmenuMembresias.Controls.Add(this.panel10);
            this.pnlSubmenuMembresias.Controls.Add(this.btnCostosMembresia);
            this.pnlSubmenuMembresias.Controls.Add(this.panel5);
            this.pnlSubmenuMembresias.Controls.Add(this.panel9);
            this.pnlSubmenuMembresias.Controls.Add(this.btnTiposMembresia);
            this.pnlSubmenuMembresias.Location = new System.Drawing.Point(35, 431);
            this.pnlSubmenuMembresias.Name = "pnlSubmenuMembresias";
            this.pnlSubmenuMembresias.Size = new System.Drawing.Size(152, 95);
            this.pnlSubmenuMembresias.TabIndex = 12;
            this.pnlSubmenuMembresias.Visible = false;
            // 
            // btnNuevaMembresia
            // 
            this.btnNuevaMembresia.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnNuevaMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaMembresia.FlatAppearance.BorderSize = 0;
            this.btnNuevaMembresia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnNuevaMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaMembresia.Font = new System.Drawing.Font("Wide Latin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaMembresia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNuevaMembresia.Image = global::UI.Windows.Properties.Resources.medal_regular_24;
            this.btnNuevaMembresia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaMembresia.Location = new System.Drawing.Point(4, 65);
            this.btnNuevaMembresia.Name = "btnNuevaMembresia";
            this.btnNuevaMembresia.Size = new System.Drawing.Size(150, 25);
            this.btnNuevaMembresia.TabIndex = 6;
            this.btnNuevaMembresia.Text = "                 Nueva";
            this.btnNuevaMembresia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaMembresia.UseVisualStyleBackColor = false;
            this.btnNuevaMembresia.Click += new System.EventHandler(this.btnNuevaMembresia_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.OrangeRed;
            this.panel10.Location = new System.Drawing.Point(-1, 65);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 25);
            this.panel10.TabIndex = 7;
            // 
            // btnCostosMembresia
            // 
            this.btnCostosMembresia.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnCostosMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCostosMembresia.FlatAppearance.BorderSize = 0;
            this.btnCostosMembresia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnCostosMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCostosMembresia.Font = new System.Drawing.Font("Wide Latin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCostosMembresia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCostosMembresia.Image = global::UI.Windows.Properties.Resources.purchase_tag_regular_24;
            this.btnCostosMembresia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCostosMembresia.Location = new System.Drawing.Point(4, 3);
            this.btnCostosMembresia.Name = "btnCostosMembresia";
            this.btnCostosMembresia.Size = new System.Drawing.Size(150, 25);
            this.btnCostosMembresia.TabIndex = 8;
            this.btnCostosMembresia.Text = "                  Costos";
            this.btnCostosMembresia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCostosMembresia.UseVisualStyleBackColor = false;
            this.btnCostosMembresia.Click += new System.EventHandler(this.btnCostosMembresia_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.OrangeRed;
            this.panel5.Location = new System.Drawing.Point(-1, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 25);
            this.panel5.TabIndex = 9;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.OrangeRed;
            this.panel9.Location = new System.Drawing.Point(-1, 34);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(5, 25);
            this.panel9.TabIndex = 11;
            // 
            // btnTiposMembresia
            // 
            this.btnTiposMembresia.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnTiposMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTiposMembresia.FlatAppearance.BorderSize = 0;
            this.btnTiposMembresia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnTiposMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiposMembresia.Font = new System.Drawing.Font("Wide Latin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiposMembresia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTiposMembresia.Image = global::UI.Windows.Properties.Resources.star_half_solid_24;
            this.btnTiposMembresia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTiposMembresia.Location = new System.Drawing.Point(4, 34);
            this.btnTiposMembresia.Name = "btnTiposMembresia";
            this.btnTiposMembresia.Size = new System.Drawing.Size(150, 25);
            this.btnTiposMembresia.TabIndex = 10;
            this.btnTiposMembresia.Text = "                   Tipos";
            this.btnTiposMembresia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTiposMembresia.UseVisualStyleBackColor = false;
            this.btnTiposMembresia.Click += new System.EventHandler(this.btnTiposMembresia_Click);
            // 
            // pnlSubMenuCliente
            // 
            this.pnlSubMenuCliente.Controls.Add(this.btnRegistro);
            this.pnlSubMenuCliente.Controls.Add(this.panel7);
            this.pnlSubMenuCliente.Controls.Add(this.panel8);
            this.pnlSubMenuCliente.Controls.Add(this.btnTipoCliente);
            this.pnlSubMenuCliente.Controls.Add(this.panel6);
            this.pnlSubMenuCliente.Controls.Add(this.btnNuevoCliente);
            this.pnlSubMenuCliente.Location = new System.Drawing.Point(31, 186);
            this.pnlSubMenuCliente.Name = "pnlSubMenuCliente";
            this.pnlSubMenuCliente.Size = new System.Drawing.Size(157, 94);
            this.pnlSubMenuCliente.TabIndex = 0;
            this.pnlSubMenuCliente.Visible = false;
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro.FlatAppearance.BorderSize = 0;
            this.btnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Wide Latin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistro.Image = global::UI.Windows.Properties.Resources.calendar_check_regular_24;
            this.btnRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistro.Location = new System.Drawing.Point(6, 65);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(150, 25);
            this.btnRegistro.TabIndex = 8;
            this.btnRegistro.Text = "Asistencia";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.OrangeRed;
            this.panel7.Location = new System.Drawing.Point(1, 65);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 25);
            this.panel7.TabIndex = 9;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.OrangeRed;
            this.panel8.Location = new System.Drawing.Point(1, 34);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 25);
            this.panel8.TabIndex = 11;
            // 
            // btnTipoCliente
            // 
            this.btnTipoCliente.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnTipoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTipoCliente.FlatAppearance.BorderSize = 0;
            this.btnTipoCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnTipoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipoCliente.Font = new System.Drawing.Font("Wide Latin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipoCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTipoCliente.Image = global::UI.Windows.Properties.Resources.group;
            this.btnTipoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTipoCliente.Location = new System.Drawing.Point(4, 34);
            this.btnTipoCliente.Name = "btnTipoCliente";
            this.btnTipoCliente.Size = new System.Drawing.Size(150, 25);
            this.btnTipoCliente.TabIndex = 10;
            this.btnTipoCliente.Text = "                 Tipo cliente";
            this.btnTipoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTipoCliente.UseVisualStyleBackColor = false;
            this.btnTipoCliente.Click += new System.EventHandler(this.btnTipoCliente_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.OrangeRed;
            this.panel6.Location = new System.Drawing.Point(1, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(5, 25);
            this.panel6.TabIndex = 7;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCliente.FlatAppearance.BorderSize = 0;
            this.btnNuevoCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Wide Latin", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNuevoCliente.Image = global::UI.Windows.Properties.Resources._new;
            this.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoCliente.Location = new System.Drawing.Point(6, 3);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(150, 25);
            this.btnNuevoCliente.TabIndex = 6;
            this.btnNuevoCliente.Text = "        Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // pnlMembresias
            // 
            this.pnlMembresias.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlMembresias.Location = new System.Drawing.Point(2, 392);
            this.pnlMembresias.Name = "pnlMembresias";
            this.pnlMembresias.Size = new System.Drawing.Size(5, 35);
            this.pnlMembresias.TabIndex = 7;
            // 
            // btnMembresias
            // 
            this.btnMembresias.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnMembresias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMembresias.FlatAppearance.BorderSize = 0;
            this.btnMembresias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnMembresias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembresias.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembresias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMembresias.Image = global::UI.Windows.Properties.Resources.star_regular_24;
            this.btnMembresias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembresias.Location = new System.Drawing.Point(5, 392);
            this.btnMembresias.Name = "btnMembresias";
            this.btnMembresias.Size = new System.Drawing.Size(179, 35);
            this.btnMembresias.TabIndex = 6;
            this.btnMembresias.Text = "          Membresias";
            this.btnMembresias.UseVisualStyleBackColor = false;
            this.btnMembresias.Click += new System.EventHandler(this.btnMembresias_Click);
            // 
            // pnlPagoDiario
            // 
            this.pnlPagoDiario.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlPagoDiario.Location = new System.Drawing.Point(2, 340);
            this.pnlPagoDiario.Name = "pnlPagoDiario";
            this.pnlPagoDiario.Size = new System.Drawing.Size(5, 35);
            this.pnlPagoDiario.TabIndex = 11;
            // 
            // panlPromocion
            // 
            this.panlPromocion.BackColor = System.Drawing.Color.OrangeRed;
            this.panlPromocion.Location = new System.Drawing.Point(2, 295);
            this.panlPromocion.Name = "panlPromocion";
            this.panlPromocion.Size = new System.Drawing.Size(5, 35);
            this.panlPromocion.TabIndex = 9;
            // 
            // btnPagoDiario
            // 
            this.btnPagoDiario.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnPagoDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagoDiario.FlatAppearance.BorderSize = 0;
            this.btnPagoDiario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnPagoDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagoDiario.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagoDiario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPagoDiario.Image = global::UI.Windows.Properties.Resources.dollar_circle_regular_24;
            this.btnPagoDiario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagoDiario.Location = new System.Drawing.Point(5, 340);
            this.btnPagoDiario.Name = "btnPagoDiario";
            this.btnPagoDiario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPagoDiario.Size = new System.Drawing.Size(179, 35);
            this.btnPagoDiario.TabIndex = 10;
            this.btnPagoDiario.Text = "          Pago Diario";
            this.btnPagoDiario.UseVisualStyleBackColor = false;
            this.btnPagoDiario.Click += new System.EventHandler(this.btnPagoDiario_Click);
            // 
            // btnPromociones
            // 
            this.btnPromociones.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnPromociones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromociones.FlatAppearance.BorderSize = 0;
            this.btnPromociones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnPromociones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromociones.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromociones.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPromociones.Image = global::UI.Windows.Properties.Resources.bookmark_alt_regular_24;
            this.btnPromociones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromociones.Location = new System.Drawing.Point(5, 295);
            this.btnPromociones.Name = "btnPromociones";
            this.btnPromociones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPromociones.Size = new System.Drawing.Size(179, 35);
            this.btnPromociones.TabIndex = 8;
            this.btnPromociones.Text = "          Promociones";
            this.btnPromociones.UseVisualStyleBackColor = false;
            this.btnPromociones.Click += new System.EventHandler(this.btnPromociones_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUsuario.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsuario.Location = new System.Drawing.Point(59, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(65, 17);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuario: ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.OrangeRed;
            this.panel3.Location = new System.Drawing.Point(2, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 35);
            this.panel3.TabIndex = 5;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClientes.Image = global::UI.Windows.Properties.Resources.user_regular_24;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(5, 148);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(181, 35);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnSubInicio
            // 
            this.btnSubInicio.Image = global::UI.Windows.Properties.Resources.LogoGYM3;
            this.btnSubInicio.Location = new System.Drawing.Point(0, 37);
            this.btnSubInicio.Name = "btnSubInicio";
            this.btnSubInicio.Size = new System.Drawing.Size(167, 98);
            this.btnSubInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSubInicio.TabIndex = 3;
            this.btnSubInicio.TabStop = false;
            this.btnSubInicio.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // panleContenedor
            // 
            this.panleContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(43)))));
            this.panleContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panleContenedor.Location = new System.Drawing.Point(0, 30);
            this.panleContenedor.Name = "panleContenedor";
            this.panleContenedor.Size = new System.Drawing.Size(1155, 554);
            this.panleContenedor.TabIndex = 2;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 584);
            this.Controls.Add(this.MenuVertical);
            this.Controls.Add(this.panleContenedor);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerar)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            this.pnlSubmenuMembresias.ResumeLayout(false);
            this.pnlSubMenuCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSubInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.PictureBox btnCerar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnSubInicio;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMembresias;
        private System.Windows.Forms.Button btnMembresias;
        private System.Windows.Forms.Panel panlPromocion;
        private System.Windows.Forms.Button btnPromociones;
        private System.Windows.Forms.Panel pnlPagoDiario;
        private System.Windows.Forms.Button btnPagoDiario;
        private System.Windows.Forms.Panel pnlSubMenuCliente;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnTipoCliente;
        private System.Windows.Forms.Panel pnlSubmenuMembresias;
        private System.Windows.Forms.Button btnCostosMembresia;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnTiposMembresia;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnNuevaMembresia;
        private System.Windows.Forms.Panel panleContenedor;
    }
}