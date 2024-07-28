using BlazorServerApp.Models;
using System.Collections.Generic;

namespace BlazorServerApp.Services
{
    public interface IMemberService
    {
        int Create(Member member);
        Member GetById(int id);

        //IEnumerable<MemberViewModel> GetAll();
        //without IEnumerable
        public List<Member> GetAll();

        void Delete(int id);
        void DeleteAll();
        //void Update(int id, MemberViewModel dto);


        //to wrap
        void AddMember(Member member);

    }
}
