using FiapWebservicesRestfulTechnologies.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapWebservicesRestfulTechnologies.Model
{
    [Table("estados")]
    public class Estado : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }

        [Column("pais_id")]
        public long PaisID { get; set; }

        public virtual Pais Pais { get; set; }

    }
}
