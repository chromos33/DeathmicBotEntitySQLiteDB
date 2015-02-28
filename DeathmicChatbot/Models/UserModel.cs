using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeathmicChatbot.Models
{
    [Table("UserModel")]
    public class UserModel
    {
        public UserModel()
        {

        }
        [Key]
        public long UserID { get; set; }
        public string nick { get; set; }
        public int visitcount { get; set; }
        public DateTime lastvisit { get; set; }
    }
}
