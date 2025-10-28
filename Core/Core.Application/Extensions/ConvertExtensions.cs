namespace Core.Application.Extensions;

public static class ConvertExtensions
{
    public static int ConvertToInt(this string vehSubBodyType)
    {
        string[] parts = vehSubBodyType.Split('+');
        string numberString = parts[0];

        int number;
        if (int.TryParse(numberString, out number))
            return number;
        return -1;
    }
}