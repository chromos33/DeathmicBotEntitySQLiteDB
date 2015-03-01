using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DeathmicChatbot.Models;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DeathmicChatbot
{
    class EntityFrameworkSQliteProvider
    {
        private UserContext _context;

        public void testDB()
        {
            _context = new UserContext();
            UserModel _user = new UserModel();
            _user.lastvisit = new DateTime(2015, 02, 28);
            _user.nick = "test2";
            _user.visitcount++;
            _context.Database.CreateIfNotExists();
            var nickfromdb = (from u in _context.Users where u.nick.Equals(_user.nick) select u);
            if(nickfromdb.Count() >0)
            {
                System.Diagnostics.Debug.WriteLine(_user.nick+"iamhere");
            } else
            {
                _context.Users.Add(_user);
                _context.SaveChanges();
            }

        }
    }

    public class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserModel")
        {
            
            Database.SetInitializer<UserContext>(null);
        }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
