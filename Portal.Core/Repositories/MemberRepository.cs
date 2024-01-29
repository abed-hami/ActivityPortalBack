using Microsoft.EntityFrameworkCore;
using Portal.Core.Interfaces;
using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public MemberRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _dbContext.Set<Member>().ToList();
        }

        public Member GetMemberById(int id)
        {
            return _dbContext.Set<Member>().Find(id);
        }

        public void AddMember(Member product)
        {
           
                _dbContext.Set<Member>().Add(product);
                _dbContext.SaveChanges();
            
            
            
        }

        public void UpdateMember(Member product)
        {
            var existingEntity = _dbContext.Set<Member>().Local.FirstOrDefault(e => e.Id == product.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the modified entity
            _dbContext.Entry(product).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
        public Member GetMemberByEmail(string email, string pass)
        {
            return _dbContext.Set<Member>().FirstOrDefault(u => u.Email == email && u.Password == pass);
        }
        public Member GetMemberByUsername(string email)
        {
           Member m=_dbContext.Set<Member>().FirstOrDefault(u => u.Email == email);

            
            return m;
        }
        public void DeleteMember(int id)
        {
            var product = _dbContext.Set<Member>().Find(id);
            if (product != null)
            {
                _dbContext.Set<Member>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
