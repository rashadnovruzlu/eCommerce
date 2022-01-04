namespace eCommerce.Domain;
/// <summary>
///  Table -larin səhifə sayına görə gətirilməsi tələb olunan cədvəllərdə istifadə edilirş Server side pagination üçün istifadə edilir.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ServerSidePaginationAttribute : Attribute
{
    public ServerSidePaginationAttribute()
    {

    }
}
/// <summary>
/// Cədvəllərin id və name sütunlarına görə gətirilməsi üçün istifadə edilir. 
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DropDownAttribute : Attribute
{
    public DropDownAttribute()
    {

    }
}

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DictionaryTableAttribute : Attribute
{
    public DictionaryTableAttribute()
    {

    }
}

/// <summary>
/// İnsert və update əməliyyatları zamanı əlaqəli cədvəllərin də daxil edilməsini tələb etmək üçün istifadə edilir.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class ChildTableAttribute : Attribute
{
    public ChildTableAttribute()
    {

    }
}

/// <summary>
/// Tərcüməsi tələb edilən sütunlar üçün istifadə edilir
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class TranslatableColumnAttribute : Attribute
{
    public TranslatableColumnAttribute()
    {

    }
}


/// <summary>
/// Dropdaün-larda sütun üzrə filtrasiya tələb edilən sütünlarda istifadə edilir.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class FileterableColumnAttribute : Attribute
{
    public FileterableColumnAttribute()
    {

    }
}

/// <summary>
/// inner join üçün istifadə edilir
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class JoinableColumnAttribute : Attribute
{
    private readonly string columnName;
    public JoinableColumnAttribute(string columnName = null)
    {
        this.columnName = columnName;
    }

    public string ColumnName => columnName;
}

/// <summary>
/// Left join üçün istifadə edilir
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class LeftJoinableColumnAttribute : Attribute
{
    private readonly string columnName;
    public LeftJoinableColumnAttribute(string columnName = null)
    {
        this.columnName = columnName;
    }

    public string ColumnName => columnName;
}
