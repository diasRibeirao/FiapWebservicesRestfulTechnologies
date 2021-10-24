using FiapWebservicesRestfulTechnologies.Model;
using System;

namespace FiapWebservicesRestfulTechnologies.Data.DTO
{
    public class HistoricoDTO
    {
        public long Id { get; set; }

        public long PacienteID { get; set; }

        public long MedicoID { get; set; }

        public string Anotacoes { get; set; }

        public DateTime Data { get; set; }
    }
}
