using BlazorServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Entities
{
    public class MembersDbContext :DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=MembersDbContext_1;Trusted_Connection=True;";



        public DbSet<Member> Members { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
