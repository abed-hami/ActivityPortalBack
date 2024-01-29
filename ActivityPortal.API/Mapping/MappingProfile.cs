using ActivityPortal.API.Models;
using ActivityPortal.API.Resources;
using AutoMapper;
using Portal.Core.Models;

namespace ActivityPortal.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Event, EventResource>();
            CreateMap<EventResource, Event>();

            CreateMap<Member, MemberResource>();
            CreateMap<MemberResource, Member>();

            CreateMap<WebsiteInformation, WebsiteInformationResource>();
            CreateMap<WebsiteInformationResource, WebsiteInformation>();

            CreateMap<MembersEvent, MembersEventResource>();
            CreateMap<MembersEventResource, MembersEvent>();

            CreateMap<Role, RoleResource>();
            CreateMap<RoleResource, Role>();

            CreateMap<User, UserResource>();
            CreateMap<UserResource, User>();

            CreateMap<UsersRole, UserRoleResource>();
            CreateMap<UserRoleResource, UsersRole>();

            CreateMap<Lookup, LookupResource>();
            CreateMap<LookupResource, Lookup>();

            CreateMap<Guide, GuideResource>();
            CreateMap<GuideResource, Guide>();

            CreateMap< GuidesEvent, GuidesEventResource>();
            CreateMap<GuidesEventResource, GuidesEvent>();



        }
    }
}
