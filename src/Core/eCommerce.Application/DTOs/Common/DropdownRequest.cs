using System.Text.Json.Serialization;

namespace eCommerce.Application;

public class DropdownRequest : PagingRequest
{
    public DropdownRequest()
    {

    }

    public string DependentColumnIdHash { get; set; }

    [JsonIgnore]
    public int? DependentColumnId { get { return Decrypt<int>(DependentColumnIdHash); } set { DependentColumnIdHash = Encrypt(value); } }

    public string SearchKey { get; set; }

    public DropdownRequest(string searchKey)
    {
        SearchKey = searchKey;
    }

}
