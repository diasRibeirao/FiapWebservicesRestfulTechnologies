using FiapWebservicesRestfulTechnologies.Data.DTO;
using FiapWebservicesRestfulTechnologies.Model;
using System.Collections.Generic;

namespace FiapWebservicesRestfulTechnologies.Services
{
    public interface IConsultaService
    {

        ConsultaDTO Create(ConsultaDTO historico);

        ConsultaDTO FindById(long id);

        List<ConsultaDTO> FindAll();

        ConsultaDTO Update(ConsultaDTO historico);

        void Delete(long id);
		
		void Sms(long id);

    }
}
