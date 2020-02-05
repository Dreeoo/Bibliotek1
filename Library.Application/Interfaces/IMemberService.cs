using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        ICollection<Member> GetAllMembers();
        void AddMember(Member member);
        Member GetMemberById(int id);

        void UpdateMember(Member editedMember);
        void UpdateMember(int id, Member editedMember);
    }

}
