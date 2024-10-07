using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        List<Member> GetMembers();

        Member GetMemberByID(int id);

        void AddMember(Member m);
        void UpdateMember(Member m);
        void DeleteMember(Member m);
    }
}
