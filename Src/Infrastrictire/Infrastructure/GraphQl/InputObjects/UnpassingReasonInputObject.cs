public class UnpassingReasonInputObject
{
    [GraphQLNonNullType]
    public string Reason {get;set;}
    [GraphQLNonNullType]
    public bool HaveAvaliableDocument {get;set;}
}