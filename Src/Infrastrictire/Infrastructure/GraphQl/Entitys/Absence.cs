namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Entitys;

public class Absence
{
    public UserInfo User { get; set; }
    [GraphQLNonNullType]
    public string Reason { get; set; }
    public bool IsValidReason{ get; set; }
    public bool NeedConfurm { get; set; }
}
