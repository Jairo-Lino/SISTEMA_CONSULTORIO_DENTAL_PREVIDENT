namespace SISTEMA_CONSULTORIO_DENTAL_PREVIDENT.Vistas.Formularios.M_Pagos
{
    partial class Agregar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.txt_vuelto = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_codigoservicio = new System.Windows.Forms.TextBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.dgv_servicios = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.cbo_ServicioNombre = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_codigoOdontologo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_generoOdo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_odontologo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_dniOdo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_apellidosOdo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_nombreOdo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_codigoPaciente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_busqueda = new System.Windows.Forms.ComboBox();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_busqueda = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbo_genero = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_apellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_calcularvuelto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_servicios)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 55);
            this.panel1.TabIndex = 38;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.AutoSize = true;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(949, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 25);
            this.btnCerrar.TabIndex = 81;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(353, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(268, 45);
            this.label7.TabIndex = 80;
            this.label7.Text = "AGREGAR PAGO";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(744, 691);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 25);
            this.label24.TabIndex = 147;
            this.label24.Text = "Vuelto:";
            // 
            // txt_vuelto
            // 
            this.txt_vuelto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vuelto.Location = new System.Drawing.Point(821, 688);
            this.txt_vuelto.MaxLength = 9;
            this.txt_vuelto.Name = "txt_vuelto";
            this.txt_vuelto.Size = new System.Drawing.Size(124, 33);
            this.txt_vuelto.TabIndex = 146;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(737, 609);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 25);
            this.label23.TabIndex = 145;
            this.label23.Text = "Monto:";
            // 
            // txt_monto
            // 
            this.txt_monto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_monto.Location = new System.Drawing.Point(815, 601);
            this.txt_monto.MaxLength = 9;
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(124, 33);
            this.txt_monto.TabIndex = 144;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.FlatAppearance.BorderSize = 0;
            this.btn_salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(538, 804);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(233, 40);
            this.btn_salir.TabIndex = 143;
            this.btn_salir.Text = "Cancelar";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_registrar
            // 
            this.btn_registrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_registrar.FlatAppearance.BorderSize = 0;
            this.btn_registrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_registrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registrar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registrar.ForeColor = System.Drawing.Color.White;
            this.btn_registrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_registrar.Location = new System.Drawing.Point(260, 804);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(230, 40);
            this.btn_registrar.TabIndex = 142;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = false;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(753, 570);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 25);
            this.label22.TabIndex = 141;
            this.label22.Text = "Total:";
            // 
            // txt_total
            // 
            this.txt_total.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(815, 562);
            this.txt_total.MaxLength = 9;
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(124, 33);
            this.txt_total.TabIndex = 140;
            this.txt_total.Text = "0";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.txt_codigoservicio);
            this.groupBox5.Controls.Add(this.btn_agregar);
            this.groupBox5.Controls.Add(this.dgv_servicios);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.cbo_ServicioNombre);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.txt_precio);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(31, 505);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(652, 281);
            this.groupBox5.TabIndex = 139;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Servicios";
            // 
            // txt_codigoservicio
            // 
            this.txt_codigoservicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigoservicio.Location = new System.Drawing.Point(463, 23);
            this.txt_codigoservicio.MaxLength = 9;
            this.txt_codigoservicio.Name = "txt_codigoservicio";
            this.txt_codigoservicio.Size = new System.Drawing.Size(36, 29);
            this.txt_codigoservicio.TabIndex = 32;
            this.txt_codigoservicio.Visible = false;
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.FlatAppearance.BorderSize = 0;
            this.btn_agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar.ForeColor = System.Drawing.Color.White;
            this.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_agregar.Location = new System.Drawing.Point(507, 18);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(127, 40);
            this.btn_agregar.TabIndex = 31;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // dgv_servicios
            // 
            this.dgv_servicios.AllowUserToAddRows = false;
            this.dgv_servicios.AllowUserToDeleteRows = false;
            this.dgv_servicios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_servicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_servicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_servicios.Location = new System.Drawing.Point(6, 65);
            this.dgv_servicios.Name = "dgv_servicios";
            this.dgv_servicios.ReadOnly = true;
            this.dgv_servicios.Size = new System.Drawing.Size(628, 210);
            this.dgv_servicios.TabIndex = 24;
            this.dgv_servicios.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_servicios_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Descripción";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 360;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Precio";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Eliminar";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DiagnosticoId";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(242, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 25);
            this.label20.TabIndex = 22;
            this.label20.Text = "Precio:";
            // 
            // cbo_ServicioNombre
            // 
            this.cbo_ServicioNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ServicioNombre.FormattingEnabled = true;
            this.cbo_ServicioNombre.Location = new System.Drawing.Point(90, 23);
            this.cbo_ServicioNombre.Name = "cbo_ServicioNombre";
            this.cbo_ServicioNombre.Size = new System.Drawing.Size(146, 29);
            this.cbo_ServicioNombre.TabIndex = 19;
            this.cbo_ServicioNombre.Text = "SELECCIONAR";
            this.cbo_ServicioNombre.SelectedIndexChanged += new System.EventHandler(this.cbo_ServicioNombre_SelectedIndexChanged);
            this.cbo_ServicioNombre.Click += new System.EventHandler(this.cbo_ServicioNombre_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 25);
            this.label21.TabIndex = 17;
            this.label21.Text = "Nombre:";
            // 
            // txt_precio
            // 
            this.txt_precio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_precio.Location = new System.Drawing.Point(317, 23);
            this.txt_precio.MaxLength = 9;
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(123, 29);
            this.txt_precio.TabIndex = 18;
            // 
            // txt_dni
            // 
            this.txt_dni.Enabled = false;
            this.txt_dni.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dni.Location = new System.Drawing.Point(732, 29);
            this.txt_dni.MaxLength = 8;
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.Size = new System.Drawing.Size(168, 33);
            this.txt_dni.TabIndex = 137;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(689, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 25);
            this.label19.TabIndex = 138;
            this.label19.Text = "DNI:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(753, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 25);
            this.label18.TabIndex = 136;
            this.label18.Text = "Fecha:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(37, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(570, 65);
            this.groupBox4.TabIndex = 134;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(27, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 38);
            this.label5.TabIndex = 19;
            this.label5.Text = "CONSULTORIO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label17.Location = new System.Drawing.Point(258, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(202, 38);
            this.label17.TabIndex = 18;
            this.label17.Text = "\"PREVIDENT\"";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.txt_codigoOdontologo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_generoOdo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbo_odontologo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_dniOdo);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_apellidosOdo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txt_nombreOdo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(31, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(946, 169);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Odontólogo";
            // 
            // txt_codigoOdontologo
            // 
            this.txt_codigoOdontologo.Enabled = false;
            this.txt_codigoOdontologo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigoOdontologo.Location = new System.Drawing.Point(559, 35);
            this.txt_codigoOdontologo.Name = "txt_codigoOdontologo";
            this.txt_codigoOdontologo.Size = new System.Drawing.Size(63, 29);
            this.txt_codigoOdontologo.TabIndex = 122;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(478, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 25);
            this.label9.TabIndex = 121;
            this.label9.Text = "Código:";
            // 
            // txt_generoOdo
            // 
            this.txt_generoOdo.Enabled = false;
            this.txt_generoOdo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_generoOdo.Location = new System.Drawing.Point(292, 121);
            this.txt_generoOdo.MaxLength = 8;
            this.txt_generoOdo.Name = "txt_generoOdo";
            this.txt_generoOdo.Size = new System.Drawing.Size(157, 29);
            this.txt_generoOdo.TabIndex = 118;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 117;
            this.label2.Text = "Buscar Por Apellidos:";
            // 
            // cbo_odontologo
            // 
            this.cbo_odontologo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbo_odontologo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbo_odontologo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_odontologo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_odontologo.FormattingEnabled = true;
            this.cbo_odontologo.Location = new System.Drawing.Point(198, 32);
            this.cbo_odontologo.Name = "cbo_odontologo";
            this.cbo_odontologo.Size = new System.Drawing.Size(268, 29);
            this.cbo_odontologo.TabIndex = 116;
            this.cbo_odontologo.Text = "SELECCIONAR";
            this.cbo_odontologo.SelectedIndexChanged += new System.EventHandler(this.cbo_odontologo_SelectedIndexChanged);
            this.cbo_odontologo.Click += new System.EventHandler(this.cbo_odontologo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Género:";
            // 
            // txt_dniOdo
            // 
            this.txt_dniOdo.Enabled = false;
            this.txt_dniOdo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dniOdo.Location = new System.Drawing.Point(46, 121);
            this.txt_dniOdo.MaxLength = 8;
            this.txt_dniOdo.Name = "txt_dniOdo";
            this.txt_dniOdo.Size = new System.Drawing.Size(157, 29);
            this.txt_dniOdo.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "Dni:";
            // 
            // txt_apellidosOdo
            // 
            this.txt_apellidosOdo.Enabled = false;
            this.txt_apellidosOdo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apellidosOdo.Location = new System.Drawing.Point(100, 77);
            this.txt_apellidosOdo.Name = "txt_apellidosOdo";
            this.txt_apellidosOdo.Size = new System.Drawing.Size(291, 29);
            this.txt_apellidosOdo.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "Apellidos:";
            // 
            // txt_nombreOdo
            // 
            this.txt_nombreOdo.Enabled = false;
            this.txt_nombreOdo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreOdo.Location = new System.Drawing.Point(488, 77);
            this.txt_nombreOdo.Name = "txt_nombreOdo";
            this.txt_nombreOdo.Size = new System.Drawing.Size(248, 29);
            this.txt_nombreOdo.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(397, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 25);
            this.label13.TabIndex = 13;
            this.label13.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txt_codigoPaciente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_busqueda);
            this.groupBox1.Controls.Add(this.txt_direccion);
            this.groupBox1.Controls.Add(this.txt_busqueda);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbo_genero);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_dni);
            this.groupBox1.Controls.Add(this.txt_apellidos);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_nombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 163);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Paciente";
            // 
            // txt_codigoPaciente
            // 
            this.txt_codigoPaciente.Enabled = false;
            this.txt_codigoPaciente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigoPaciente.Location = new System.Drawing.Point(552, 34);
            this.txt_codigoPaciente.Name = "txt_codigoPaciente";
            this.txt_codigoPaciente.Size = new System.Drawing.Size(63, 29);
            this.txt_codigoPaciente.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 119;
            this.label1.Text = "Historia Clinica:";
            // 
            // cbo_busqueda
            // 
            this.cbo_busqueda.BackColor = System.Drawing.Color.White;
            this.cbo_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbo_busqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_busqueda.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_busqueda.FormattingEnabled = true;
            this.cbo_busqueda.Items.AddRange(new object[] {
            "DNI",
            "HISTORIA CLINICA"});
            this.cbo_busqueda.Location = new System.Drawing.Point(17, 32);
            this.cbo_busqueda.Name = "cbo_busqueda";
            this.cbo_busqueda.Size = new System.Drawing.Size(203, 29);
            this.cbo_busqueda.TabIndex = 118;
            this.cbo_busqueda.Text = "SELECCIONAR";
            this.cbo_busqueda.SelectedIndexChanged += new System.EventHandler(this.cbo_busqueda_SelectedIndexChanged);
            // 
            // txt_direccion
            // 
            this.txt_direccion.Enabled = false;
            this.txt_direccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_direccion.Location = new System.Drawing.Point(385, 121);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(515, 29);
            this.txt_direccion.TabIndex = 24;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.BackColor = System.Drawing.Color.White;
            this.txt_busqueda.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_busqueda.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_busqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_busqueda.HintForeColor = System.Drawing.Color.Empty;
            this.txt_busqueda.HintText = "";
            this.txt_busqueda.isPassword = false;
            this.txt_busqueda.LineFocusedColor = System.Drawing.Color.Blue;
            this.txt_busqueda.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_busqueda.LineMouseHoverColor = System.Drawing.Color.DimGray;
            this.txt_busqueda.LineThickness = 4;
            this.txt_busqueda.Location = new System.Drawing.Point(229, 32);
            this.txt_busqueda.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(166, 31);
            this.txt_busqueda.TabIndex = 112;
            this.txt_busqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_busqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Dirección:";
            // 
            // cbo_genero
            // 
            this.cbo_genero.Enabled = false;
            this.cbo_genero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_genero.FormattingEnabled = true;
            this.cbo_genero.Location = new System.Drawing.Point(90, 121);
            this.cbo_genero.Name = "cbo_genero";
            this.cbo_genero.Size = new System.Drawing.Size(161, 29);
            this.cbo_genero.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Género:";
            // 
            // txt_apellidos
            // 
            this.txt_apellidos.Enabled = false;
            this.txt_apellidos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apellidos.Location = new System.Drawing.Point(100, 77);
            this.txt_apellidos.Name = "txt_apellidos";
            this.txt_apellidos.Size = new System.Drawing.Size(399, 29);
            this.txt_apellidos.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Apellidos:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(633, 78);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(267, 29);
            this.txt_nombre.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre:";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Enabled = false;
            this.dtp_fecha.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(813, 122);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(148, 33);
            this.dtp_fecha.TabIndex = 149;
            this.dtp_fecha.Value = new System.DateTime(2020, 11, 7, 17, 10, 17, 0);
            // 
            // txt_calcularvuelto
            // 
            this.txt_calcularvuelto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.txt_calcularvuelto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txt_calcularvuelto.FlatAppearance.BorderSize = 0;
            this.txt_calcularvuelto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txt_calcularvuelto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_calcularvuelto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_calcularvuelto.ForeColor = System.Drawing.Color.White;
            this.txt_calcularvuelto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_calcularvuelto.Location = new System.Drawing.Point(803, 647);
            this.txt_calcularvuelto.Name = "txt_calcularvuelto";
            this.txt_calcularvuelto.Size = new System.Drawing.Size(136, 30);
            this.txt_calcularvuelto.TabIndex = 33;
            this.txt_calcularvuelto.Text = "Calcular Vuelto";
            this.txt_calcularvuelto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txt_calcularvuelto.UseVisualStyleBackColor = false;
            this.txt_calcularvuelto.Click += new System.EventHandler(this.txt_calcularvuelto_Click);
            // 
            // Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 788);
            this.Controls.Add(this.txt_calcularvuelto);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txt_vuelto);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txt_monto);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Agregar";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.Agregar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_servicios)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt_vuelto;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_monto;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.DataGridView dgv_servicios;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbo_ServicioNombre;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_odontologo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_dniOdo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_apellidosOdo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_nombreOdo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_direccion;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_busqueda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbo_genero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_apellidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_generoOdo;
        private System.Windows.Forms.ComboBox cbo_busqueda;
        private System.Windows.Forms.TextBox txt_codigoOdontologo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_codigoPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.TextBox txt_codigoservicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button txt_calcularvuelto;
    }
}