namespace FiapWebservicesRestfulTechnologies.Data.DTO
{
    public class EnderecoDTO
    {
        public long Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public long CidadeID { get; set; }
    }
}
