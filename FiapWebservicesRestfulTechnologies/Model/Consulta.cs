using FiapWebservicesRestfulTechnologies.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiapWebservicesRestfulTechnologies.Model
{
    [Table("consultas")]
    public class Consulta : BaseEntity
    {
        [Column("paciente_id")]
        [ForeignKey("Paciente")]
        public long PacienteID { get; set; }
        public Paciente Paciente { get; set; }

        [Column("medico_id")]
        [ForeignKey("Medico")]
        public long MedicoID { get; set; }
        public Medico Medico { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }
    }
}
