using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisClin.Domain
{
    public  class ProcedureAttendance
    {
        public int ProcedureId { get; set; }
        public List<Procedure> procedures { get; set; }
        public int AttendanceId { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
