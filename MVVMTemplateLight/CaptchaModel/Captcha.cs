using System;

namespace CaptchaModel;

public static class Captcha
{
    public static (string captchaHashCode, byte[] image) GenerateImageAsByteArray()
    {
        var code = new Random().Next(100_000, 999_999).ToString();
        return (
            GetHashString(code),
            new CaptchaGenerator().GenerateImageAsByteArray(code.ToString()));
    }
}