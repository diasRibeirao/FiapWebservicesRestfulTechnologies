using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IUsersService
    {
        User Create(User user);

        User FindById(long id);

        List<User> FindAll();

        User Update(User user);

        void Delete(long id);
    }
}
