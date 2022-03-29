using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinApi.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public float PersonRg { get; set; }
        public float PersonCpf { get; set; }
        public string PersonAndress { get; set; }
    }
}
