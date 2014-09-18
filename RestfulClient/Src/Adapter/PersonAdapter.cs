using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RestfulClient.DTO;
using Newtonsoft.Json.Converters;

namespace RestfulClient.Adapter
{
    class PersonAdapter<PersonDTO> : IAdapter<PersonDTO>
    {
        public string ConvertDtoToJson(PersonDTO dto)
        {
            return JsonConvert.SerializeObject(dto);
        }

        public PersonDTO ConvertJsonToDto(string json)
        {
            return JsonConvert.DeserializeObject<PersonDTO>(json, new MyDateTimeConverter());
        }

        public List<PersonDTO> ConvertJsonToDtoList(string json)
        {
            return JsonConvert.DeserializeObject<List<PersonDTO>>(json, new MyDateTimeConverter());
        }
    }
}
