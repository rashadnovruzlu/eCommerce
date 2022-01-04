namespace eCommerce.Domain;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}
