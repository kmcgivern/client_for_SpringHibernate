using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using RestfulClient.Client;
using RestfulClient.Manager;
using RestfulClient.DTO;
using Spring.Context;
using Spring.Context.Support;


namespace RestfulClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();

            IPersonManager manager = (IPersonManager)ctx.GetObject("PersonManager");

            PersonDTO createdPerson = manager.CreatePerson();

            PersonDTO retrievedPerson = manager.GetPerson(createdPerson.id);

            List<PersonDTO> allPeople = manager.GetAllPeople();


        }

    }
}
