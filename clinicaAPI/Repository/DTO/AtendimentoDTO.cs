using ClinicaAPI.Models;

namespace ClinicaAPI___Copia.Repository.DTO
{
    public class AtendimentoDTO
    {
        public int id { get; set; }           
        public PacienteDTO paciente { get; set;}
        public string prontuario { get; set; }
        
    }
}