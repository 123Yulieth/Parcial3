using System.Windows.Forms;

namespace Parcial3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpReserva;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNumeroHabitacion;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.ComboBox cmbTipoHabitacion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListView listViewReservas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblNumeroHabitacion;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblTipoHabitacion;
        private System.Windows.Forms.Label lblReservas;
        private System.Windows.Forms.ColumnHeader colNombreCliente;
        private System.Windows.Forms.ColumnHeader colNumHabitacion;
        private System.Windows.Forms.ColumnHeader colFechaIngreso;
        private System.Windows.Forms.ColumnHeader colCantidadDias;
        private System.Windows.Forms.ColumnHeader colCategoriaHabitacion;
        private System.Windows.Forms.ColumnHeader colCostoTotal;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpReserva = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNumeroHabitacion = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.cmbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.listViewReservas = new System.Windows.Forms.ListView();
            this.colNombreCliente = new System.Windows.Forms.ColumnHeader();
            this.colNumHabitacion = new System.Windows.Forms.ColumnHeader();
            this.colFechaIngreso = new System.Windows.Forms.ColumnHeader();
            this.colCantidadDias = new System.Windows.Forms.ColumnHeader();
            this.colCategoriaHabitacion = new System.Windows.Forms.ColumnHeader();
            this.colCostoTotal = new System.Windows.Forms.ColumnHeader();

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Reservas Mejorado";
            this.Font = new System.Drawing.Font("Arial", 10);

            // GroupBox - Contenedor de datos de reserva
            this.grpReserva.Text = "Datos de la Reserva";
            this.grpReserva.Location = new System.Drawing.Point(20, 20);
            this.grpReserva.Size = new System.Drawing.Size(700, 150);
            this.grpReserva.Controls.AddRange(new Control[]
            {
                new Label { Text = "Cliente:", Location = new System.Drawing.Point(20, 30), Size = new System.Drawing.Size(100, 20) },
                (this.txtCliente = new TextBox { Location = new System.Drawing.Point(130, 30), Size = new System.Drawing.Size(200, 20) }),

                new Label { Text = "Número de Habitación:", Location = new System.Drawing.Point(20, 60), AutoSize = true },
                (this.txtNumeroHabitacion = new TextBox { Location = new System.Drawing.Point(180, 60), Size = new System.Drawing.Size(150, 20) }),

                new Label { Text = "Fecha de Ingreso:", Location = new System.Drawing.Point(350, 30), Size = new System.Drawing.Size(130, 20) },
                (this.dtpFechaInicio = new DateTimePicker { Location = new System.Drawing.Point(480, 30), Size = new System.Drawing.Size(150, 20) }),

                new Label { Text = "Cantidad de Días:", Location = new System.Drawing.Point(350, 60), Size = new System.Drawing.Size(130, 20) },
                (this.txtDuracion = new TextBox { Location = new System.Drawing.Point(480, 60), Size = new System.Drawing.Size(150, 20) }),

                new Label { Text = "Categoría de Habitación:", Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(170, 20) },
                (this.cmbTipoHabitacion = new ComboBox { Location = new System.Drawing.Point(200, 90), Size = new System.Drawing.Size(170, 20), Items = { "Estándar", "VIP" } })
            });

            // Botones
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(20, 180);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar = new Button
            {
                Text = "Editar",
                Location = new System.Drawing.Point(130, 180),
                Size = new System.Drawing.Size(100, 30),
                Enabled = false
            };
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(250, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.Enabled = false;

            // ListView - Tabla de Reservas
            this.listViewReservas.Location = new System.Drawing.Point(20, 220);
            this.listViewReservas.Size = new System.Drawing.Size(700, 250);
            this.listViewReservas.View = View.Details;
            this.listViewReservas.FullRowSelect = true;
            this.listViewReservas.GridLines = true;
            this.listViewReservas.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader { Text = "Cliente", Width = 150 },
                new ColumnHeader { Text = "Número de Habitación", Width = 140 },
                new ColumnHeader { Text = "Fecha de Ingreso", Width = 120 },
                new ColumnHeader { Text = "Cantidad de Días", Width = 120 },
                new ColumnHeader { Text = "Categoría", Width = 160 },
                new ColumnHeader { Text = "Costo Total", Width = 100 }
            });
            this.listViewReservas.SelectedIndexChanged += new System.EventHandler(this.ListViewReservas_SelectedIndexChanged);

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] { grpReserva, btnAgregar, btnEditar, btnEliminar, listViewReservas });
        }
    }
}