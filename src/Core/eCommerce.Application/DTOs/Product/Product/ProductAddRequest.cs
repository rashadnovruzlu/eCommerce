using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class ProductAddRequest : BaseDTO, IMapTo<Product>
    {
        public string BrendIdHash { get; set; }
        [JsonIgnore]
        public int BrendId { get { return Decrypt<int>(BrendIdHash); } set { BrendIdHash = Encrypt(value); } }
        public string SubCategoryIdHash { get; set; }
        [JsonIgnore]
        public int SubCategoryId { get { return Decrypt<int>(SubCategoryIdHash); } set { SubCategoryIdHash = Encrypt(value); } }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public DateTime InsertDate { get; set; }
        public ICollection<ProductTranslationAddRequest> ProductTranslations { get; set; }

    }
}