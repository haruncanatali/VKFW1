using VKFW1.Api.Enums;

namespace VKFW1.Api.Extensions;

public static class StringExtensions
{
    public static string ArrangeName(this string source,Gender gender)
    {
        source = source.Replace("Mrs.", "").Replace("Mr.", "");
        return gender == Gender.Female
            ? "Mrs." + source
            : "Mr." + source;
    }
}