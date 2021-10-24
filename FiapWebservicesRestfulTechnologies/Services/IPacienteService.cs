using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IPacienteService
    {
        Paciente ValidateCredentials(LoginDTO login);

        Paciente ValidateCredentials(string login);

        bool RevokeToken(string login);
        
        Paciente RefreshInfo(Paciente paciente);

        PacienteDTO Create(PacienteDTO user);

        PacienteDTO FindById(long id);

        List<PacienteDTO> FindAll();

        PacienteDTO Update(PacienteDTO user);

        void Delete(long id);

    }
}
