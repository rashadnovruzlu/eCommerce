using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class ProductTranslationAddRequest : BaseDTO, IMapTo<ProductTranslation>
    {
        public string LanguageIdHash { get; set; }
        [JsonIgnore]
        public int LanguageId { get { return Decrypt<int>(LanguageIdHash); } set { LanguageIdHash = Encrypt(value); } }
        public string ProductIdHash { get; set; }
        [JsonIgnore]
        public int ProductId { get { return Decrypt<int>(ProductIdHash); } set { ProductIdHash = Encrypt(value); } }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}