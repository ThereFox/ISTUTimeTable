using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class User
    {
        public int id;
        public Role role;
        public FullName Name;
        public Group group;
    }
}
