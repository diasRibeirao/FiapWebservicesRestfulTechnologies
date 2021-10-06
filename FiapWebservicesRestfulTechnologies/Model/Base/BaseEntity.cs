using System.ComponentModel.DataAnnotations.Schema;

namespace FiapWebservicesRestfulTechnologies.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

    }
}
