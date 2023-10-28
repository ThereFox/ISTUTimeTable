using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys.TimeTable.Comments;

namespace ISTUTimeTable.Entitys.TimeTable
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