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
    }
}
