using BlazorServerApp.Entities;
using BlazorServerApp.Models;
using BlazorServerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using BlazorServerApp.Models;

namespace BlazorServerApp.Seeder
{
    public interface IMemberListSeede
    {
        void Seed(int quantity);
    }

    public class MemberListSeeder : IMemberListSeede
    {
    
        private readonly MembersDbContext _dbContext;

        public MemberListSeeder(MembersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //method to seed the database with random data
        public void Seed(int quantity)
        {
            //check if the database can connect
            if(_dbContext.Database.CanConnect())
            {
                //chceck if the database is empty
                if (! _dbContext.Members.Any())
                {
                    List<Member> memberList = new List<Member>();

                    for (int x = 0; x < quantity; x++)
                    {
                        Random random = new Random();
                        Member memberRandom = new Member
                        {

                            Age = random.Next(20, 60),
                            Email = $"mail{x}@user.com",
                            MemberName = "Username_" + x.ToString(),
                            JoiningDate = DateTime.Now,
                            MemberCnt = x + 1
                        };
                        memberList.Add(memberRandom);
                    }
                    _dbContext.Members.AddRange(memberList);
                    _dbContext.SaveChanges();
                }

            }
        }
    }
}
