using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class SubCategoryAddRequest : BaseDTO, IMapTo<SubCategory>
    {
        public string CategoryIdHash { get; set; }
        [JsonIgnore]
        public int CategoryId { get { return Decrypt<int>(CategoryIdHash); } set { CategoryIdHash = Encrypt(value); } }
        public string Name { get; set; }
        public ICollection<SubCategoryTranslationAddRequest> SubCategoryTranslations { get; set; }

    }
}