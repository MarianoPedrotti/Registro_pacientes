namespace Registro_pacientes.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sintomas { get; set; }
        public int ObraSocialId { get; set; }
        public ObraSocial? obraSocial { get; set; }
    }
}
