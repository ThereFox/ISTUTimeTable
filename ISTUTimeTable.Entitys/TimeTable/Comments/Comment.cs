using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISTUTimeTable.Entitys
{
    public class Comment
    {
        public int Id;
        public DateOnly Date;
        public User Writer;
        public Lesson ForLesson;
        public Group ForGroup;
        public string Message;
        public CommentType commentType;
    }
}