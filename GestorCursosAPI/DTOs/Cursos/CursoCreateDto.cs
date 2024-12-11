namespace GestorCursosAPI.DTOs.Cursos
{
    public class CursoCreateDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDeClases { get; set; }
        public double HorasPorClase { get; set; }
        public bool Sincronico { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal Precio { get; set; }
        public int Oferta { get; set; }
    }
}
