using System.Security.Cryptography;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using App.token;
using Microsoft.Extensions.Options;
using ISTUTImeTable.Common;
using Src.Core.Common;
using Authorise.JWT.DTO;

namespace Authorise.JWT;

public class JWTTokenSource
{
    private const string Header = "{\"alg\": \"HS256\",\"typ\": \"JWT\"}}";


    private readonly IOptions<AuthSecrets> _secrets;
    private readonly HMACSHA256 _encoder; //add secret key

    public JWTTokenSource(IOptions<AuthSecrets> secrets)
    {
        _secrets = secrets;
        _encoder = new HMACSHA256();
    }


    public AuthBearer Generate(TokenInfo tokenInfo)
    {
        var authTokenLifeTime = DateTime.Now.AddMinutes(tokenInfo.MinutsOfLife);
        var refreshTokenLifeTime = DateTime.Now.AddMinutes(tokenInfo.MinutsForRefresh);

        var authPayload = new AuthPayload(
            tokenInfo.userInfo,
            _secrets.Value.Issuer,
            new NumericDate(DateTime.Now),
            new NumericDate(authTokenLifeTime)
            );
        var refreshPayload = new RefreshPayload(
            _secrets.Value.Issuer,
            new NumericDate(DateTime.Now),
            new NumericDate(refreshTokenLifeTime),
            new NumericDate(authTokenLifeTime)
        );
        var authPayloadJson = getObjectJson(authPayload);
        var refreshPayloadJson = getObjectJson(refreshPayload);
        return new AuthBearer(
            generateTocken(authPayloadJson),
            generateTocken(refreshPayloadJson)
        );
    }
    
    public Result<PayloadType> ReadFromString<PayloadType>(string input)
    {
        if(input is null)
        {
            return Result.Failure<PayloadType>(new Error("1", "input is null"));
        }
        
        var parts = input.Split('.');

        if(parts.Length != 3 || parts == null)
        {
            return Result.Failure<PayloadType>(new Error("2", "Token invalid"));
        }
        if(CheckUnchanging(parts).IsSucsesfull == false)
        {
            return Result.Failure<PayloadType>(new Error("3", "TokenInfoWosChange"));
        }

        var content = JsonConvert.DeserializeObject<PayloadType>(parts[1]);

        if(content is null)
        {
            return Result.Failure<PayloadType>(new Error("4", ""));
        }
        return Result.Sucsesfull<PayloadType>(content);

    }

    private string generateTocken(string payloadJson)
    {
        var encodedHeader = getEncodedStringFromText(Header);
        var encodedPayload = getEncodedStringFromText(
            getObjectJson(payloadJson)
        );
        var encodedSignature = getEncodedStringFromBytes(
            getSignature(encodedHeader, encodedPayload)
        );
        var authTocken = $"{encodedHeader}.{encodedPayload}.{encodedSignature}";
        return authTocken;
    }
    private string getEncodedStringFromText(string Json)
    {
        var plainTextBypes = Encoding.UTF8.GetBytes(Json);
        return Convert.ToBase64String(plainTextBypes);
    }
    private string getEncodedStringFromBytes(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
    private string getObjectJson(object Payload)
    {
        return JsonConvert.SerializeObject(Payload);
    }
    private byte[] getSignature(string EncodedHeader, string EncodedPayload)
    {
        return getEncodedBytesFromString($"{_secrets.Value.JWTSecrets}.{EncodedHeader}.{EncodedPayload}");
    }
    private byte[] getEncodedBytesFromString(string initialData)
    {
        var bytes = Encoding.UTF8.GetBytes(initialData);
        return _encoder.ComputeHash(bytes);
    }

    private string getDecodedString(string encodedString)
    {
        var encodedTextBytes = Convert.FromBase64String(encodedString);
        return Encoding.UTF8.GetString(encodedTextBytes);
    }

    private bool IsJWTToken(string type)
    {
        return type == "JWT";
    }
    private bool HaveAvaliableAlgholitm(string alghoritm)
    {
        return alghoritm == "HS256";
    }

    private Result CheckUnchanging(string[] parts)
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
        var GeneratedCheckCode = getSignature(parts[0], parts[1]);

        if(String.Equals(CheckCodeFromToken, GeneratedCheckCode))
        {
            return Result.Failure(new Error("123", "CRC changed"));
        }

        return Result.Sucsesfull();
    }    

}
