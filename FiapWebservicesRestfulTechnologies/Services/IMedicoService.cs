using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IMedicoService
    {
        Medico ValidateCredentials(LoginDTO login);

        Medico ValidateCredentials(string login);

        bool RevokeToken(string login);

        Medico RefreshInfo(Medico medico);

        MedicoDTO Create(MedicoDTO user);

        MedicoDTO FindById(long id);

        List<MedicoDTO> FindAll();

        MedicoDTO Update(MedicoDTO user);

        void Delete(long id);

    }
}
