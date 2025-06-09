using System.Net;
using System.Text.Json;

namespace APBD_TECT_2.Exceptions;

public class BadRequestException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public BadRequestException(string message, HttpStatusCode statusCode = HttpStatusCode.UnprocessableContent) :
        base(message)
    {
        StatusCode = statusCode;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

[Serializable]
public class InternalServerErrorException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public InternalServerErrorException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        StatusCode = statusCode;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

