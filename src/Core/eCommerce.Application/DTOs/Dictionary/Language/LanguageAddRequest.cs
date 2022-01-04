using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class LanguageAddRequest : BaseDTO, IMapTo<Language>
    {
        public string Name { get; set; }
        public string Culture { get; set; }

    }
}