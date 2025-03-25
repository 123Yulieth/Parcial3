using System;
using System.Windows.Forms;

namespace Parcial3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listViewReservas.SelectedIndexChanged += ListViewReservas_SelectedIndexChanged;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar datos del formulario
                string cliente = txtCliente.Text;
                int numeroHabitacion = int.Parse(txtNumeroHabitacion.Text);
                DateTime fechaInicio = dtpFechaInicio.Value;
                int duracion = int.Parse(txtDuracion.Text);
                string tipoHabitacion = cmbTipoHabitacion.SelectedItem.ToString();

                // Crear reserva con Factory
                Reserva nuevaReserva = ReservaFactory.CrearReserva(cliente, numeroHabitacion, fechaInicio, duracion, tipoHabitacion);

                // Agregar reserva con Singleton
                GestorReservas.Instancia.AgregarReserva(nuevaReserva);

                // Actualizar lista
                ActualizarListaReservas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewReservas.SelectedItems.Count > 0)
                {
                    int index = listViewReservas.SelectedItems[0].Index;
                    GestorReservas.Instancia.EliminarReserva(index);
                    ActualizarListaReservas();
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Seleccione una reserva para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewReservas.SelectedItems.Count > 0)
            {
                try
                {
                    int index = listViewReservas.SelectedItems[0].Index;
                    Reserva reservaModificada = GestorReservas.Instancia.ObtenerReservas()[index];

                    // Capturar nuevos valores
                    string nuevoCliente = txtCliente.Text;
                    int nuevoNumeroHabitacion = int.Parse(txtNumeroHabitacion.Text);
                    DateTime nuevaFechaInicio = dtpFechaInicio.Value;
                    int nuevaDuracion = int.Parse(txtDuracion.Text);
                    string nuevoTipoHabitacion = cmbTipoHabitacion.SelectedItem.ToString();

                    // Validar disponibilidad de la habitación
                    if (!GestorReservas.Instancia.EsHabitacionDisponible(nuevoNumeroHabitacion, nuevaFechaInicio, nuevaDuracion, reservaModificada))
                    {
                        MessageBox.Show("La habitación no está disponible en las nuevas fechas seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Actualizar datos en la reserva
                    reservaModificada.Cliente = nuevoCliente;
                    reservaModificada.NumeroHabitacion = nuevoNumeroHabitacion;
                    reservaModificada.FechaInicio = nuevaFechaInicio;
                    reservaModificada.Duracion = nuevaDuracion;
                    reservaModificada.TipoHabitacion = nuevoTipoHabitacion;

                    // Recalcular precio basado en el nuevo tipo de habitación y duración
                    reservaModificada.CalcularPrecio();

                    // Actualizar lista
                    ActualizarListaReservas();
                    LimpiarCampos();

                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ListViewReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewReservas.SelectedItems.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

                int index = listViewReservas.SelectedItems[0].Index;
                Reserva reservaSeleccionada = GestorReservas.Instancia.ObtenerReservas()[index];

                txtCliente.Text = reservaSeleccionada.Cliente;
                txtNumeroHabitacion.Text = reservaSeleccionada.NumeroHabitacion.ToString();
                dtpFechaInicio.Value = reservaSeleccionada.FechaInicio;
                txtDuracion.Text = reservaSeleccionada.Duracion.ToString();
                cmbTipoHabitacion.SelectedItem = reservaSeleccionada.TipoHabitacion;
            }
        }

        private void ActualizarListaReservas()
        {
            listViewReservas.Items.Clear();
            foreach (var reserva in GestorReservas.Instancia.ObtenerReservas())
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    reserva.Cliente,
                    reserva.NumeroHabitacion.ToString(),
                    reserva.FechaInicio.ToShortDateString(),
                    reserva.Duracion.ToString(),
                    reserva.TipoHabitacion,
                    reserva.PrecioTotal.ToString("C")
                });
                listViewReservas.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            txtCliente.Clear();
            txtNumeroHabitacion.Clear();
            dtpFechaInicio.Value = DateTime.Today;
            txtDuracion.Clear();
            cmbTipoHabitacion.SelectedIndex = -1;
        }
    }
}
