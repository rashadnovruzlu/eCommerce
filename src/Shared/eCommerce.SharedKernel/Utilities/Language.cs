namespace eCommerce.SharedKernel;

public class Language
{
    private Language(string clture, int value) { Clture = clture; Value = value; }

    public string Clture { get; private set; }
    public int Value { get; private set; }

    public static Language Azerbaijan { get { return new Language("az-Latn-AZ", (int)LanguageCode.Azerbaijan); } }
    public static Language English { get { return new Language("en-US", (int)LanguageCode.English); } }
    public static Language Russian { get { return new Language("ru-RU", (int)LanguageCode.Russian); } }

    public static Language Find(string clture)
    {
        if (clture == Azerbaijan.Clture)
            return Azerbaijan;
        else if (clture == English.Clture)
            return English;
        else if (clture == Russian.Clture)
            return Russian;

        return English;
    }

    public static Language Find(int languageId)
    {
        if (languageId == (int)LanguageCode.Azerbaijan)
            return Azerbaijan;
        else if (languageId == (int)LanguageCode.English)
            return English;
        else if (languageId == (int)LanguageCode.Russian)
            return Russian;

        return English;
    }
}

public enum LanguageCode
{
    None,
    Azerbaijan = 1,
    English = 2,
    Russian = 3
}