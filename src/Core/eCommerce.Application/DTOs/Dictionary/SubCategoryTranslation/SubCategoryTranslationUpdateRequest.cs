using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class SubCategoryTranslationUpdateRequest : BaseDTO, IMapTo<SubCategoryTranslation>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string Name { get; set; }
        public string LanguageIdHash { get; set; }
        [JsonIgnore]
        public int LanguageId { get { return Decrypt<int>(LanguageIdHash); } set { LanguageIdHash = Encrypt(value); } }
        public string SubCategoryIdHash { get; set; }
        [JsonIgnore]
        public int SubCategoryId { get { return Decrypt<int>(SubCategoryIdHash); } set { SubCategoryIdHash = Encrypt(value); } }

    }
}