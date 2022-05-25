using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisClin.Domain
{
    public class EmployerAttendance
    {
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }
    }
}
