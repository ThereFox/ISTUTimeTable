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

namespace Authorise.JWT;

public class JWTTokenSource
{
    private const string Header = "{\"alg\": \"HS256\",\"typ\": \"JWT\"}}";


    private readonly IOptions<AuthSecrets> _secrets;
    private readonly HMACSHA256 _encoder; //add secret key
    

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

}
