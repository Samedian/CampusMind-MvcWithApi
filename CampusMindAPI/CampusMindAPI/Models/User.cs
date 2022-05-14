using System;
using System.Collections.Generic;

#nullable disable

namespace CampusMindAPI.Models
{
    public partial class User
    {
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string RoleAssign { get; set; }
    }
}
