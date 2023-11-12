using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entitys.Unpassings;

namespace ISTUTimeTable.Entitys
{
    public class User
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public FullName Name { get; private set; }

        public int GroupId {get;private set; }
        public Group group { get; set; }

        public List<Unpassing> Unpassings { get; private set; }
        public List<Comment> Comments {get; private set; }
    }
}
