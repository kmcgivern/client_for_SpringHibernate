using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestfulClient.DTO
{
    class PersonDTO : BaseDTO
    {
        public String firstName
        {
            get;
            set;
        }

        public String middleName
        {
            get;
            set;
        }

        public String lastName
        {
            get;
            set;
        }

        public DateTime birthDate
        {
            get;
            set;
        }

    }
}
