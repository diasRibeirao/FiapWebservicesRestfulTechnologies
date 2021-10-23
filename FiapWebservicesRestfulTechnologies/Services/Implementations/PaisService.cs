using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.PaisesService;
using FiapWebservicesRestfulTechnologies.Repository;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services.Implementations
{
    public class PaisService : IPaisService
    {
        private readonly IRepository<Pais> _repository;

        public PaisService(IRepository<Pais> repository)
        {
            _repository = repository;
        }

        // Método responsável por buscar todos os paises
        public List<Pais> FindAll()
        {
            return _repository.FindAll();
        }

        // Método responsável por buscar um pais pelo ID
        public Pais FindById(long id)
        {
            return _repository.FindById(id);
        }

        // Método responsável por adicionar um pais
        public Pais Create(Pais pais)
        {
            return _repository.Create(pais);
        }

        // Método responsável pelo update de um pais
        public Pais Update(Pais pais)
        {
            return _repository.Update(pais);
        }

        // Método responsável por deletar um pais pelo ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        
    }
}
