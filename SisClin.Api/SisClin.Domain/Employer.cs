using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisClin.Domain
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
        public float EmployerRg { get; set; }
        public float EmployerCpf { get; set; }
        public List<Tipe> Tipe { get; set; }
    }
}
