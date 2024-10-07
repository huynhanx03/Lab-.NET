using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member m) => MemberDAO.Instance.InsertMember(m);

        public void DeleteMember(Member m) => MemberDAO.Instance.DeleteMember(m);

        public Member GetMemberByID(int id) => MemberDAO.Instance.FindMemberById(id);

        public List<Member> GetMembers() => MemberDAO.GetMembers();

        public void UpdateMember(Member m) => MemberDAO.Instance.UpdateMember(m);
    }
}
