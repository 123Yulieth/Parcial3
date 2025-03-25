using System;

namespace Parcial3
{
    public static class ReservaFactory
    {
        public static Reserva CrearReserva(string cliente, int numeroHabitacion, DateTime fechaInicio, int duracion, string tipoHabitacion)
        {
            if (string.IsNullOrWhiteSpace(cliente))
                throw new ArgumentException("El nombre del cliente es obligatorio.");
            if (duracion < 1)
                throw new ArgumentException("La duración debe ser mayor a 1 noche.");
            if (tipoHabitacion != "VIP" && tipoHabitacion != "Estándar")
                throw new ArgumentException("Tipo de habitación inválido.");

            decimal precioPorNoche = tipoHabitacion == "VIP" ? 150 : 100;

            // Aplicar descuento VIP si es mayor a 5 noches
            if (tipoHabitacion == "VIP" && duracion > 5)
            {
                precioPorNoche *= 0.8m;
            }

            decimal precioTotal = precioPorNoche * duracion;

            return new Reserva(cliente, numeroHabitacion, fechaInicio, duracion, tipoHabitacion, precioTotal);
        }
    }
}
