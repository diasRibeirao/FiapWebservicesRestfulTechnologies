using FiapWebservicesRestfulTechnologies.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiapWebservicesRestfulTechnologies.Model
{
    [Table("paises")]
    public class Pais : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("sigla")]
        public string sigla { get; set; }
    }
}
