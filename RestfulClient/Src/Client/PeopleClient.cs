using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestfulClient.DTO;

namespace RestfulClient.Client
{
    public interface PeopleClient
    {
        string GetPerson(long id);

        string CreatePerson(string json);

        string GetAllPeople();
    }
}
