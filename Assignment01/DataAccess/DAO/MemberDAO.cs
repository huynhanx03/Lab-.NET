using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new Object();
        private MemberDAO() { }

        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                }
                return instance;
            }
        }
        public static List<Member> GetMembers()
        {
            List<Member> members;
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    members = context.Members.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public Member FindMemberById(int mId)
        {
            Member m = new Member();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    m = context.Members.SingleOrDefault(x => x.MemberId == mId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return m;
        }

        public void InsertMember(Member m)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Members.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateMember(Member m)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Entry<Member>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteMember(Member m)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    var m1 = context.Members.SingleOrDefault(c => c.MemberId == m.MemberId);
                    context.Members.Remove(m1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
