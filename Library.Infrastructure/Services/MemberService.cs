using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext context;

        public MemberService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<Member> GetAllMembers()
        {
            return context.Members.Include(m => m.Loan).OrderBy(m => m.Name).ToList();
        }

        public void AddMember(Member newMember)
        {
            context.Add(newMember);
            context.SaveChanges();
        }

        public void UpdateMember(Member editedMember)
        {
            context.Update(editedMember);
            context.SaveChanges();
        }

        public void UpdateMember(int id, Member editedMember)
        {
            throw new NotImplementedException();
        }
        public Member GetMemberById(int id)
        {
            return context.Members.Find(id);
        }
        public void DeleteMember(Member deletedMember)
        {
            context.Remove(deletedMember);
            context.SaveChanges();
        }
    }
}
