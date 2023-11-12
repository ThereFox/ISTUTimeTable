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

        public int WriterId {get;set;}
        public User Writer;

        public int LessonId {get;set;}
        public Lesson ForLesson;

        public int GroupId {get;set;}
        public Group ForGroup;
        public string Message;
        public CommentType commentType;
    }
}