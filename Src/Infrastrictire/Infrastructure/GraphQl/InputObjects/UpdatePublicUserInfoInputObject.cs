using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdatePublicUserInfoInputObject
{
    public FullName FullName {get;}
    public string PublicIdentificator {get;}

    public UpdatePublicUserInfoInputObject(FullName fullName, string publicIdentificator)
    {
        FullName = fullName;
        PublicIdentificator = publicIdentificator;
    }

}
