namespace eCommerce.Application;

public class PagingRequest : BaseDTO
{
    public PagingRequest()
    {
        Filters = new List<PagingRequestFilter>();
    }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 15;
    public List<PagingRequestFilter> Filters { get; set; }


}


public class PagingRequestFilter : BaseDTO
{

    private object v;
    private string fieldName;



    public object Value
    {
        get
        {
            if (fieldName.IndexOf(_hashName) != -1 && FieldName.Substring(fieldName.Length - 4, 4) == _hashName)
                return Decrypt<int>(v.ToString());

            return v;
        }
        set { v = value; }
    }

    public string FieldName
    {
        get { return fieldName; }
        set { fieldName = value; }
    }

    public string EqualityType { get; set; }
}