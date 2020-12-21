using System;
using System.Collections.Generic;

namespace ClinicaAPI.Models
{
    public class Paciente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public DateTime dt_nascimento { get; set; }
        public string documento { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
    }
}