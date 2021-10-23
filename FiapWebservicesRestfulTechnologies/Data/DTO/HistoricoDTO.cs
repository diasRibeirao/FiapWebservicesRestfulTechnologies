using FiapWebservicesRestfulTechnologies.Model;

namespace FiapWebservicesRestfulTechnologies.Data.DTO
{
    public class HistoricoDTO
    {
        public long Id { get; set; }

        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }

        public string Anotacoes { get; set; }

        public string Data { get; set; }
    }
}
