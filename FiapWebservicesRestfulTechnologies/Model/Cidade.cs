using FiapWebservicesRestfulTechnologies.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapWebservicesRestfulTechnologies.Model
{
    [Table("cidades")]
    public class Cidade : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("estado_id")]
        public long EstadoID { get; set; }

        public virtual Estado Estado { get; set; }

    }
}
