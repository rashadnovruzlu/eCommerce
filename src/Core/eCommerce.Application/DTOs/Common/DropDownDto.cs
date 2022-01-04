using System.Text.Json.Serialization;

namespace eCommerce.Application;

public sealed class DropDownDto : BaseDTO
{

    public string ValueHash { get; set; }

    [JsonIgnore]
    public int Value { get { return Decrypt<int>(ValueHash); } set { ValueHash = Encrypt(value); } }

    public string DisplayText { get; set; }
    public bool Select { get; set; }
}
