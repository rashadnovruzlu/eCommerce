using Microsoft.EntityFrameworkCore;

namespace eCommerce.Persistence;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Language>().HasData(
        //      new Language { Id = (int)Utility.LanguageCode.Azerbaijan, Name = "Azərbaycan", LanguageCulture = Utility.Language.Azerbaijan.Clture, DisplayOrder = 1, Published = true },
        //      new Language { Id = (int)Utility.LanguageCode.English, Name = "İngilis", LanguageCulture = Utility.Language.English.Clture, DisplayOrder = 2, Published = true },
        //      new Language { Id = (int)Utility.LanguageCode.Russian, Name = "Rus", LanguageCulture = Utility.Language.Russian.Clture, DisplayOrder = 3, Published = true }

        //  );

        //modelBuilder.Entity<LanguageTranslation>().HasData(

        //     new LanguageTranslation { Id = 1, LanguageId = (int)Utility.LanguageCode.Azerbaijan, Name = "Azərbaycan", LanguageCulture = Utility.Language.Azerbaijan.Clture, Published = true },
        //     new LanguageTranslation { Id = 2, LanguageId = (int)Utility.LanguageCode.Azerbaijan, Name = "Azerbaijan ", LanguageCulture = Utility.Language.English.Clture, Published = true },
        //     new LanguageTranslation { Id = 3, LanguageId = (int)Utility.LanguageCode.Azerbaijan, Name = "Азербайджан", LanguageCulture = Utility.Language.Russian.Clture, Published = true },

        //     new LanguageTranslation { Id = 4, LanguageId = (int)Utility.LanguageCode.English, Name = "İngilis", LanguageCulture = Utility.Language.Azerbaijan.Clture, Published = true },
        //     new LanguageTranslation { Id = 5, LanguageId = (int)Utility.LanguageCode.English, Name = "English ", LanguageCulture = Utility.Language.English.Clture, Published = true },
        //     new LanguageTranslation { Id = 6, LanguageId = (int)Utility.LanguageCode.English, Name = "Английский", LanguageCulture = Utility.Language.Russian.Clture, Published = true },

        //     new LanguageTranslation { Id = 7, LanguageId = (int)Utility.LanguageCode.Russian, Name = "Rus", LanguageCulture = Utility.Language.Azerbaijan.Clture, Published = true },
        //     new LanguageTranslation { Id = 8, LanguageId = (int)Utility.LanguageCode.Russian, Name = "Russian ", LanguageCulture = Utility.Language.English.Clture, Published = true },
        //     new LanguageTranslation { Id = 9, LanguageId = (int)Utility.LanguageCode.Russian, Name = "Pусский", LanguageCulture = Utility.Language.Russian.Clture, Published = true }
        // );
    }
}
