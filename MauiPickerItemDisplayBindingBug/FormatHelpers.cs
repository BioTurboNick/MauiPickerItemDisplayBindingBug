using System.Globalization;

namespace MauiPickerItemDisplayBindingBug;

public static class FormatHelpers
{
    static readonly char[] superscriptCharacters = ['⁰', '¹', '²', '³', '⁴', '⁵', '⁶', '⁷', '⁸', '⁹', '⁻'];
    static readonly char[] characters = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-'];
    static readonly Dictionary<char, char> superscriptDictionary = new(superscriptCharacters.Length);
    const char times = '×';

    static FormatHelpers()
    {
        for (int i = 0; i < superscriptCharacters.Length; i++)
            superscriptDictionary.Add(characters[i], superscriptCharacters[i]);
    }


    public static string GetSuperscript(int exponentValue, CultureInfo culture)
    {
        string formatedValue = exponentValue.ToString("D", culture);

        string formattedSuperscripts = string.Empty;

        for (int i = 0; i < formatedValue.Length; i++)
            formattedSuperscripts += superscriptDictionary[formatedValue[i]];

        return formattedSuperscripts;
    }


    public static string ToPowerOfTen(int value, CultureInfo culture)
    {
        string formattedValue = string.Empty;

        if (value == 0) return formattedValue;

        formattedValue += times + 10.ToString(culture);

        if (value == 1) return formattedValue;

        formattedValue += GetSuperscript(value, culture);

        return formattedValue;
    }
}
