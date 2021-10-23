using FiapWebservicesRestfulTechnologies.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapWebservicesRestfulTechnologies.Model
{
    [Table("enderecos")]
    public class Endereco : BaseEntity
    {
        [Column("cep")]
        public string Cep { get; set; }
		
		[Column("logradouro")]
        public string Logradouro { get; set; }
		
		[Column("bairro")]
        public string Bairro { get; set; }

        [Column("cidade_id")]
        public long CidadeID { get; set; }

        public virtual Cidade Cidade { get; set; }

    }
}
