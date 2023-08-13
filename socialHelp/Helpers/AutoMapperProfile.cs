using AutoMapper;
using socialHelp.Entities;
using Models = socialHelp.Models;

namespace socialHelp.Helpers
{
    public class AutoMapperProfile: Profile
    {
    public AutoMapperProfile()
    {
        CreateMap<Models.SocialHelp.RequestCreate, SocialHelp>();
        CreateMap<Models.Beneficiary.RequestCreate, Beneficiary>();

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