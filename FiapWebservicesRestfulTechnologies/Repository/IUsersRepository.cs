using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Repository
{
    public interface IUsersRepository
    {
        User Create(User user);

        User FindById(long id);

        List<User> FindAll();

        User Update(User user);

        void Delete(long id);

        bool Exists(long id);
    }
}
