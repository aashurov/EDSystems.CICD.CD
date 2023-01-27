using System;
namespace EDSystems.WebApi.Models.S3;

public class S3ResponseDto
{
    public int StatusCode { get; set; } = 200;

    public string Message { get; set; } = "";
}

