using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApiWithEF.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [NotMapped]
        public string ReTypePassword { get; set; }

        public int? ManagerId { get; set; }
       
        [ForeignKey("ManagerId")]
        public User? Manager { get; set; }
        // this will add DeptID as a foreign Key to Dept table
        public int DeptId  { get; set; }
        public Dept? Dept { get; set; }

        // this will add DeptID as a foreign Key to Role table

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
