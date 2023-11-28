using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTImeTable.Common;
using Newtonsoft.Json;
using Src.Core.Common;

namespace Authorise.JWT.DTO;

public class JWTToken<PayloadType> where PayloadType : PayloadBase
{
    public readonly PayloadType Payload;


    protected JWTToken(PayloadType payloadData)
    {
        Payload = payloadData;
    }

    public static Result<JWTToken<PayloadType>> ReadFromString(string input)
    {
        if(input is null)
        {
            return Result.Failure<JWTToken<PayloadType>>(new Error("1", "input is null"));
        }
        
        var parts = input.Split('.');

        if(parts.Length != 3 || parts == null)
        {
            return Result.Failure<JWTToken<PayloadType>>(new Error("2", "Token invalid"));
        }
        if(CheckUnchanging(parts).IsSucsesfull == false)
        {
            return Result.Failure<JWTToken<PayloadType>>(new Error("3", "TokenInfoWosChange"));
        }




    }

    private static Result CheckUnchanging(string[] parts)
    {
        var header = JsonConvert.DeserializeObject<HeaderContent>(parts[0]);

        if(header == null)
        {
            return Result.Failure(new Error("4", "Header uncurrect"));
        }

        if(IsJWTToken(header.Type) == false)
        {
            return Result.Failure(new Error("5", "Is not jwt token"));
        }

        if(HaveAvaliableAlgholitm(header.Algorithm) == false)
        {
            return Result.Failure(new Error("6", "Algholitm not support"));
        }

        var CheckCodeFromToken = parts[2];
        var GeneratedCheckCode = ;



    }

    private static bool IsJWTToken(string type)
    {
        return type == "JWT";
    }
    private static bool HaveAvaliableAlgholitm(string alghoritm)
    {
        return alghoritm == "HS256";
    }

}
