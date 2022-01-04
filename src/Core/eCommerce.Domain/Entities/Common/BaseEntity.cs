using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain;

public abstract class BaseEntity<T> : BaseEntity, IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual T Id { get; set; }

}


public class BaseEntity
{

}
