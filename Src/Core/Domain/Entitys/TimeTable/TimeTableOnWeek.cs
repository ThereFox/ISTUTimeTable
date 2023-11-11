using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class TimeTableOnWeek
    {
        public int id { get; set; }
        public Group Group { get; set; }
        public TimeTableOnDay Monday { get; set; }
        public TimeTableOnDay Tuesday { get; set; }
        public TimeTableOnDay Wensday { get; set; }
        public TimeTableOnDay Thusday { get; set; }
        public TimeTableOnDay Friday { get; set; }

    }
}
