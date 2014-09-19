using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RestfulClient.DTO;
using RestfulClient.Adapter;

namespace RestfulClientTests.Test.Adapter
{
    [TestFixture]
    class PersonAdapterTest
    {
        [Test]
        public void ShouldConvertDtoToJson()
        {
            PersonDTO person = CreatePersonDTO();
            PersonAdapter<PersonDTO> classUnderTest = new PersonAdapter<PersonDTO>();
            string json = classUnderTest.ConvertDtoToJson(person);

            Assert.That(json, Is.StringContaining(person.firstName));
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
