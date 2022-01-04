using eCommerce.SharedKernel;

namespace eCommerce.Application;

public class BaseDTO
{
    protected const string _hashName = "Hash";

    protected string Encrypt(int? id)
    {
        if (id == null)
            return null;

        return TextEncryption.Encrypt(id.ToString());
    }



    protected T Decrypt<T>(string id)
    {
        if (id is null)

            return default(T);

        return (T)Convert.ChangeType(TextEncryption.Decrypt(id.ToString()), typeof(T));

    }
}

