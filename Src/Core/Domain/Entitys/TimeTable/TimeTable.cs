using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class TimeTable
    {
        public int id;
        public Group Group;
        public TimeTableNode Monday;
        public TimeTableNode Tuesday;
        public TimeTableNode Wensday;
        public TimeTableNode Thusday;
        public TimeTableNode Friday;

    }
}
