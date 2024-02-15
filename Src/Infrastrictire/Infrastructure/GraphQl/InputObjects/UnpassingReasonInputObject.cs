public class UnpassingReasonInputObject
{
    [GraphQLNonNullType]
    public string Reason {get;}
    [GraphQLNonNullType]
    public bool HaveAvaliableDocument {get;}

    public UnpassingReasonInputObject(string reason, bool haveAvaliableDocument)
    {
        Reason = reason;
        HaveAvaliableDocument = haveAvaliableDocument;
    }

}