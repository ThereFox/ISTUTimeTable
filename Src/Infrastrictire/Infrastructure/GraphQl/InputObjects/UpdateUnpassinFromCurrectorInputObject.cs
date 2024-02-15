using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.InputObjects;

public class UpdateUnpassingFromCurrectorInputObject
{
    public class UpdateUnpassingForCurrentUserInputObject
    {
        [GraphQLNonNullType]
        public int UnpassingId {get;}
        public List<int> LessonsId {get;}
        public UnpassingReasonInputObject Reason {get;}

        public UpdateUnpassingForCurrentUserInputObject(int unpassingId, List<int> lessonsId, UnpassingReasonInputObject reason)
        {
            UnpassingId = unpassingId;
            LessonsId = lessonsId;
            Reason = reason;
        }
    }
}
