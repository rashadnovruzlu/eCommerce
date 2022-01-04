using AutoMapper;

namespace eCommerce.Application;

public interface IMapTo<T>
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
}
