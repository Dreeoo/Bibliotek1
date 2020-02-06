using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        ICollection<Member> GetAllMembers();
        Member GetMemberById(int id);
        void AddMember(Member member);
        void UpdateMember(Member editedMember);
        void UpdateMember(int id, Member editedMember);
        void DeleteMember(Member member);
    }

}
