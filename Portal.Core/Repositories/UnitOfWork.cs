using Portal.Core.Interfaces;
using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ActivityPortalContext _context;
        private EventRepository _eventRepository;
        private GuideRepository _guideRepository;
        private LookupRepository _lookupRepository;
        private GuidesEventRepository _guideEventRepository;
        private MembersEventRepository _memberEventRepository;
        private MemberRepository _memberRepository;
        private UserRepository _userRepository;
        private UsersRoleRepository _userRoleRepository;
        private RoleRepository _roleRepository;

        public UnitOfWork(ActivityPortalContext context)
        {
            this._context = context;
        }

        public IEventRepository Events => _eventRepository = _eventRepository ?? new EventRepository(_context);
        public IGuideRepository Guides => _guideRepository = _guideRepository ?? new GuideRepository(_context);
        public ILookupRepository Lookups => _lookupRepository = _lookupRepository ?? new LookupRepository(_context);
        public IGuideEventRepository GuideEvents => _guideEventRepository = _guideEventRepository ?? new GuidesEventRepository(_context);
        public IMemberEventRepository  MemberEvents => _memberEventRepository = _memberEventRepository ?? new MembersEventRepository(_context);
        public IMemberRepository Members => _memberRepository = _memberRepository ?? new MemberRepository(_context);
        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IUserRoleRepository UserRoles => _userRoleRepository = _userRoleRepository ?? new UsersRoleRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
