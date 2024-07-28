using BlazorServerApp.Entities;
using BlazorServerApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazorServerApp.Services
{
    public class MemberService : IMemberService
    {

        private readonly MembersDbContext _membersDbContext;


        public MemberService(MembersDbContext membersDbContext)
        {
            _membersDbContext = membersDbContext;
        }


        public int Create(Member member)
        {
            _membersDbContext.Add(member);
            _membersDbContext.SaveChanges();

            return member.Id;
        }

        public void Delete(int id)
        {
            var member = _membersDbContext
                .Members
                .FirstOrDefault(m => m.Id == id);

            if(member is null)
            {
                throw new System.Exception("Member not found by id, can not to delete");
            }
            
            _membersDbContext.Remove(member);
            _membersDbContext.SaveChanges();
        }

        public void DeleteAll()
        {
            _membersDbContext.Members.RemoveRange(_membersDbContext.Members);
            _membersDbContext.SaveChanges();
        }

        //public IEnumerable<MemberViewModel> GetAll()
        //{
        //    var members = _membersDbContext
        //        .Members
        //        .ToList();

        //    return members;
        //}        
        //without IEnumerable
        public List<Member> GetAll()
        {
            var members = _membersDbContext
                .Members
                .ToList();

            return members;
        }

        public Member GetById(int id)
        {
            var member = _membersDbContext
                 .Members
                 .FirstOrDefault(m => m.Id == id);
            
            if(member is null)
            {
                throw new System.Exception("Member not found by id, can not found");
            }

            return member;
        }

        //public void Update(int id, MemberViewModel dto)
        //{
        //}
    }
}
