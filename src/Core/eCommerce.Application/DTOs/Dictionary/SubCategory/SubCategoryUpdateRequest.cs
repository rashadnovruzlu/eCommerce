using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class SubCategoryUpdateRequest : BaseDTO, IMapTo<SubCategory>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string CategoryIdHash { get; set; }
        [JsonIgnore]
        public int CategoryId { get { return Decrypt<int>(CategoryIdHash); } set { CategoryIdHash = Encrypt(value); } }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SubCategoryTranslationUpdateRequest> SubCategoryTranslations { get; set; }
        public int[] DeletedSubCategoryTranslations { get; set; }

    }
}