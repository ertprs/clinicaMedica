using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaAPI.Models
{
     public class Atendimento
    {
        public int id { get; set; }
    
        public int pacienteId { get; set; }
        public Paciente paciente { get; set;}
        public string prontuario { get; set; }
    }
}