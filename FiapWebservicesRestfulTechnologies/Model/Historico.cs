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
        [Column("paciente")]
        public Paciente Paciente { get; set; }

        [Column("medico")]
        public Medico Medico { get; set; }

        [Column("anotacoes")]
        public string Anotacoes { get; set; }

        [Column("data")]
        public string data { get; set; }
    }
}
