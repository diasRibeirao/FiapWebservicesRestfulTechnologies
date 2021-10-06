using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IUsersService
    {
        Users Create(Users user);

        Users FindById(long id);

        List<Users> FindAll();

        Users Update(Users user);

        void Delete(long id);
    }
}
