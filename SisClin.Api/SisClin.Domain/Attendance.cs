using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisClin.Domain
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public List<Employer> Employers { get; set; }
        public List<EmployerAttendance> EmployersAttendances { get; set; }
        public List<People> Peoples { get; set; }
        public List<PeopleAttendance> PeoplesAttendances { get; set; }
        public List<Procedure> Procedures { get; set; }
        public List<ProcedureAttendance> ProceduresAttendances { get; set; }
    }
}
