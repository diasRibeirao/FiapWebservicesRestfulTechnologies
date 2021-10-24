using FiapWebservicesRestfulTechnologies.Model;
using System;

namespace FiapWebservicesRestfulTechnologies.Data.DTO
{
    public class ConsultaDTO
    {
        public long Id { get; set; }

        public long PacienteID { get; set; }

        public long MedicoID { get; set; }

        public string Telefone { get; set; }

        public DateTime Data { get; set; }
    }
}
