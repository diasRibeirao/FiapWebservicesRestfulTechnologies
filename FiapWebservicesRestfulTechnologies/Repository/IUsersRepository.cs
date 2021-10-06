using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Repository
{
    public interface IUsersRepository
    {
        Users Create(Users user);

        Users FindById(long id);

        List<Users> FindAll();

        Users Update(Users user);

        void Delete(long id);

        bool Exists(long id);
    }
}
