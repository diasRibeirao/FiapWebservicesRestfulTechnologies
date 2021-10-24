using FiapWebservicesRestfulTechnologies.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiapWebservicesRestfulTechnologies.Model
{
    [Table("historicos")]
    public class Historico : BaseEntity
    {
        [Column("paciente_id")]
        public long PacienteID { get; set; }

        public virtual Paciente Paciente { get; set; }

        [Column("medico_id")]
        public long MedicoID { get; set; }

        public virtual Medico Medico { get; set; }

        [Column("anotacoes")]
        public string Anotacoes { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }
    }
}
