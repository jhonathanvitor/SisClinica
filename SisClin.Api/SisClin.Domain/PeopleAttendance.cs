using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisClin.Domain
{
    public class PeopleAttendance
    {
        public int PeopleId { get; set; }
        public List<People> Peoples { get; set; }
        public int AttendanceId { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
