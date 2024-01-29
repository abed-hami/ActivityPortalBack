using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        IGuideRepository Guides { get; }
        ILookupRepository Lookups { get; }
        IGuideEventRepository GuideEvents { get; }
        IMemberEventRepository MemberEvents { get; }
        IMemberRepository Members { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        
        Task<int> CommitAsync();
    }
}
