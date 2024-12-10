using System;

namespace GestorCursosAPI.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDeClases { get; set; }
        public double HorasPorClase { get; set; }
        public bool Sincronico { get; set; }
        public DateTime? FechaInicio { get; set; } // Null si es asincronico
        public DateTime? FechaFin { get; set; }    // Null si es asincronico
        public decimal Precio { get; set; }
        public int Oferta { get; set; } // Porcentaje de descuento
    }
}
