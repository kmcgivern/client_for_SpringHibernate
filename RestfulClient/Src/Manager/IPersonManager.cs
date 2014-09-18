using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestfulClient.DTO;

namespace RestfulClient.Manager
{
    interface IPersonManager
    {
        PersonDTO CreatePerson();

        PersonDTO GetPerson(long id);

        List<PersonDTO> GetAllPeople();
    }
}
