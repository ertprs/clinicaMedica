using System;

namespace ClinicaAPI___Copia.Repository.DTO
{
    public class PacienteDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public DateTime dt_nascimento { get; set; }
        public string documento { get; set; }
    }
}