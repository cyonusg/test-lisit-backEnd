using AutoMapper;
using location.Entities;
using Models = location.Models;

namespace users.Helpers
{
    public class AutoMapperProfile: Profile
    {
    public AutoMapperProfile()
    {
        // CreateRequest -> Country
        CreateMap<Models.Country.CreateRequest, Country>();
        // CreateRequest -> Region
        CreateMap<Models.Region.CreateRequest, Region>();
        // CreateRequest -> Commune
        CreateMap<Models.Commune.CreateRequest, Commune>();

        // UpdateRequest -> User
        /*CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));*/
    }
    }
}