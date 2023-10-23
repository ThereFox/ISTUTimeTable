using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class Student
    {
        public int id;
        public Guid Code;
        public FullName Name;
        public Group group;
    }
}
