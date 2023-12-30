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
using Auth.Common;
using Authorise;
using System.Text.Json;

namespace Authorise.JWT;

public class JWTTokenSource : ITokenCreater
{
    private const string Header = "{'alg': 'HS256','typ': 'JWT'}";

    private readonly IOptions<AuthSecrets> _secrets;
    private readonly HMACSHA256 _encoder;

    public JWTTokenSource(IOptions<AuthSecrets> secrets)
    {
        _secrets = secrets;
        _encoder = new HMACSHA256();
    }


    public AuthBearer Generate(TokenInfo tokenInfo)
    {
        var authTokenLifeTime = DateTime.Now.AddMinutes(tokenInfo.MinutsOfLife);
        var refreshTokenLifeTime = DateTime.Now.AddMinutes(tokenInfo.MinutsForRefresh);

        var authPayload = new AuthPayload(){
            UserId = tokenInfo.UserInfo.UserId,
            Issue = _secrets.Value.Issuer,
            IssuedAt = new NumericDate(DateTime.Now).NumberDate,
            Explanetion = new NumericDate(authTokenLifeTime).NumberDate
    };
        var refreshPayload = new RefreshPayload(){
            Issue = _secrets.Value.Issuer,
            IssuedAt = new NumericDate(DateTime.Now).NumberDate,
            RefreshTimeout = new NumericDate(refreshTokenLifeTime).NumberDate,
            NotActiveBefore = new NumericDate(authTokenLifeTime).NumberDate
        };
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

        if(parts == null || parts.Length != 3)
        {
            return Result.Failure<PayloadType>(new Error("2", "Token invalid"));
        }

        var checkUnchangingResult = CheckUnchanging(parts);

        if(checkUnchangingResult.IsSucsesfull == false)
        {
            return Result.Failure<PayloadType>(new Error("3", $"TokenInfoWasChange: {checkUnchangingResult.ErrorInfo.Code} - {checkUnchangingResult.ErrorInfo.Message}"));
        }

        var contentResult = readEncodedPayload<PayloadType>(parts[1]);
        
        if(contentResult.IsSucsesfull == false)
        {
            return Result.Failure<PayloadType>(contentResult.ErrorInfo);
        }
        
        var content = contentResult.ResultValue;

        return Result.Sucsesfull<PayloadType>(content);

    }

    private Result<PayloadType> readEncodedPayload<PayloadType>(string payload)
    {
        try{
            var decodedPayload = getDecodedString(payload).Replace("\\\"", "'").Replace("\"", "");

            var type = typeof(PayloadType);
            
            var content = (PayloadType)JsonConvert.DeserializeObject(
                decodedPayload,
                typeof(PayloadType)
                );
            

            if(content is null)
            {
                return Result.Failure<PayloadType>(new Error("123", "Parse error"));
            }

            return Result.Sucsesfull<PayloadType>(content);
        }
        catch (Exception ex)
        {
            return Result.Failure<PayloadType>(new Error("123", ex.Message));
        }
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
        return  getEncodedBytesFromString($"{_secrets.Value.JWTSecrets}.{EncodedHeader}.{EncodedPayload}");
    }
    private byte[] getEncodedBytesFromString(string initialData)
    {
        var bytes = Encoding.UTF8.GetBytes(initialData);
        return _encoder.ComputeHash(bytes);
    }

    private string getDecodedString(string encodedString)
    {
        var encodedTextBytes = Convert.FromBase64String(encodedString);
        return Encoding.ASCII.GetString(encodedTextBytes);
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
        var headerParseResult = readHeaderContent(parts[0]);

        if(headerParseResult.IsSucsesfull == false)
        {
            return Result.Failure(headerParseResult.ErrorInfo);
        }

        var header = headerParseResult.ResultValue;

        if(IsJWTToken(header.Type) == false)
        {
            return Result.Failure(new Error("5", "Is not jwt token"));
        }

        if(HaveAvaliableAlgholitm(header.Algorithm) == false)
        {
            return Result.Failure(new Error("6", "Algholithm not support"));
        }

        var CheckCodeFromToken = parts[2];
        var GeneratedCheckCode = getEncodedStringFromBytes(getSignature(parts[0], parts[1]));

        if(realCodeEqualExpected(GeneratedCheckCode, CheckCodeFromToken) == false)
        {
            return Result.Failure(new Error("123", "CRC changed"));
        }

        return Result.Sucsesfull();
    }

    private bool realCodeEqualExpected(string generatedCode, string expectedCode)
    {
        var compareResult = string.Compare(generatedCode, expectedCode);
        return compareResult == 0;
    }
    private Result<HeaderContent> readHeaderContent(string encodedHeader)
    {
        try
        {
            var header = getDecodedString(encodedHeader);
            var headerContent = JsonConvert.DeserializeObject<HeaderContent>(header);

            if(headerContent == null)
            {
                return Result.Failure<HeaderContent>(new Error("4", "Header uncurrect"));
            }

            return Result.Sucsesfull<HeaderContent>(headerContent);
        }
        catch (Exception ex)
        {
            return Result.Failure<HeaderContent>(new Error("4", $"Parse error: {ex.Message}"));
        }
        
    }
}
