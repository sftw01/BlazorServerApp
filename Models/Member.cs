using System;

namespace BlazorServerApp.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string MemberName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public int MemberCnt { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
