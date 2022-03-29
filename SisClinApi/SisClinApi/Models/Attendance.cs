using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinApi.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string AttendanceEmployee { get; set; }
        public string AttendancePerson { get; set; }
        public string AttendanceProceeding { get; set; }
    }
}
