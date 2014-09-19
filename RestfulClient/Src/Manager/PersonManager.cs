﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestfulClient.DTO;
using RestfulClient.Client;
using RestfulClient.Adapter;

namespace RestfulClient.Manager
{
    class PersonManager : IPersonManager
    {
        public PersonManager(IAdapter<PersonDTO> personAdapter, PeopleClient client)
        {
            this.personAdapter = personAdapter;
            this.client = client;
        }

        private IAdapter<PersonDTO> personAdapter
        {
            set;
            get;
        }

        private PeopleClient client
        {
            set;
            get;
        }

        public PersonDTO CreatePerson()
        {
            PersonDTO person = CreatePersonDTO();

            string json = personAdapter.ConvertDtoToJson(person);


            string responseJson = client.CreatePerson(json);
            return personAdapter.ConvertJsonToDto(responseJson);
        }

        public PersonDTO GetPerson(long id)
        {
            string json = client.GetPerson(id);

            return personAdapter.ConvertJsonToDto(json);
        }

        public List<PersonDTO> GetAllPeople()
        {
            string json = client.GetAllPeople();
            return personAdapter.ConvertJsonToDtoList(json);
            
        }

        private PersonDTO CreatePersonDTO()
        {
            PersonDTO person = new PersonDTO();
            person.firstName = "Bob";
            person.lastName = "Jones";
            person.middleName = "M";
            person.birthDate = new DateTime(1977, 11, 11);
            return person;
        }
    }
}
