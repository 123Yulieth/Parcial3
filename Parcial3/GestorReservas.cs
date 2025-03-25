using System;
using System.Collections.Generic;

namespace Parcial3
{
    public class GestorReservas
    {
        private static GestorReservas _instancia;
        private List<Reserva> reservas;

        private GestorReservas()
        {
            reservas = new List<Reserva>();
        }

        public static GestorReservas Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GestorReservas();
                }
                return _instancia;
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservas;
        }

        public void AgregarReserva(Reserva reserva)
        {
            // Validar que no se duplique la reserva en la misma habitación en fechas solapadas
            foreach (var r in reservas)
            {
                DateTime fechaFinExistente = r.FechaInicio.AddDays(r.Duracion);
                DateTime fechaFinNueva = reserva.FechaInicio.AddDays(reserva.Duracion);

                bool fechasSolapadas = reserva.FechaInicio < fechaFinExistente && fechaFinNueva > r.FechaInicio;

                if (r.NumeroHabitacion == reserva.NumeroHabitacion && fechasSolapadas)
                {
                    throw new InvalidOperationException($"La habitación {reserva.NumeroHabitacion} ya está reservada entre {r.FechaInicio.ToShortDateString()} y {fechaFinExistente.ToShortDateString()}.");
                }
            }

            reservas.Add(reserva);
        }


        public void EliminarReserva(int index)
        {
            if (index < 0 || index >= reservas.Count)
                throw new ArgumentOutOfRangeException("Índice de reserva inválido.");

            reservas.RemoveAt(index);
        }
        public bool EsHabitacionDisponible(int numeroHabitacion, DateTime fechaInicio, int duracion, Reserva reservaActual = null)
        {
            DateTime fechaFin = fechaInicio.AddDays(duracion);

            foreach (var reserva in reservas)
            {
                // Omitir la reserva actual (en caso de edición)
                if (reservaActual != null && reserva == reservaActual)
                    continue;

                DateTime reservaInicio = reserva.FechaInicio;
                DateTime reservaFin = reservaInicio.AddDays(reserva.Duracion);

                // Verificar si la nueva reserva se superpone con una existente
                if (reserva.NumeroHabitacion == numeroHabitacion &&
                    !(fechaFin <= reservaInicio || fechaInicio >= reservaFin))
                {
                    return false; // No disponible
                }
            }
            return true; // Disponible
        }

    }
}

