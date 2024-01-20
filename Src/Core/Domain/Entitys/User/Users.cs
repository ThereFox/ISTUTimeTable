namespace ISTUTimeTable.Src.Core.Domain.Entitys;

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