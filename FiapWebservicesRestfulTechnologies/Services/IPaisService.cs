using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.PaisesService
{
    public interface IPaisService
    {

        Pais Create(Pais pais);

        Pais FindById(long id);

        List<Pais> FindAll();

        Pais Update(Pais pais);

        void Delete(long id);

    }
}
