using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;

public class Absences
{
    public DateOnly Date {get;set;}
    public List<Unpassing> AbsencesUsers { get; set; }
}
