using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMind.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string RoleAssign { get; set; }
    }
}
