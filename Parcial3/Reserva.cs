using System;

namespace Parcial3
{
    public class Reserva
    {
        public string Cliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int Duracion { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal PrecioTotal { get; set; }

        public Reserva(string cliente, int numeroHabitacion, DateTime fechaInicio, int duracion, string tipoHabitacion, decimal precioTotal)
        {
            Cliente = cliente;
            NumeroHabitacion = numeroHabitacion;
            FechaInicio = fechaInicio;
            Duracion = duracion;
            TipoHabitacion = tipoHabitacion;
            PrecioTotal = precioTotal;
        }

        public override string ToString()
        {
            return $"Cliente: {Cliente} | Habitación: {NumeroHabitacion} | Fecha: {FechaInicio:dd/MM/yyyy} | " +
                   $"Duración: {Duracion} noches | Tipo: {TipoHabitacion} | Total: ${PrecioTotal}";
        }
        public void CalcularPrecio()
        {
            int precioPorNoche = (TipoHabitacion == "VIP") ? 150 : 100;
            PrecioTotal = Duracion * precioPorNoche;
        }

    }
}
