using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestfulClient.DTO;

namespace RestfulClient.Adapter
{
    public interface IAdapter<T>
    {
        string ConvertDtoToJson(T dto);

        T ConvertJsonToDto(string json);

        List<T> ConvertJsonToDtoList(string json);
    }
}
