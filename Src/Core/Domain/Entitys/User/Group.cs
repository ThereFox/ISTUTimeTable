﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;

namespace ISTUTimeTable.Entitys
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public string Speciality { get; set; }
        public List<User> Students { get; set; }
        public List<TimeTableOnWeek> TimeTablesOnWeeks { get; set; }
    }
}
