using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcsesLayer.Entitys;

public class Comments
{
    public int Id { get; private set; }
    public int SenderId { get; private set; }
    public DateTime Date { get; private set; }
    public string Message { get; private set; }
    public int TypeId { get; private set; }
    public int LessonNumId { get;private set; }

    public User Sender { get; private set; }
    public CommentType Type { get; private set; }
    public LessonNums LessonNum { get; private set; }

}
