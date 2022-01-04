using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class CategoryTranslationAddRequest : BaseDTO, IMapTo<CategoryTranslation>
    {
        public string LanguageIdHash { get; set; }
        [JsonIgnore]
        public int LanguageId { get { return Decrypt<int>(LanguageIdHash); } set { LanguageIdHash = Encrypt(value); } }
        public string CategoryIdHash { get; set; }
        [JsonIgnore]
        public int CategoryId { get { return Decrypt<int>(CategoryIdHash); } set { CategoryIdHash = Encrypt(value); } }
        public string Name { get; set; }

    }
}