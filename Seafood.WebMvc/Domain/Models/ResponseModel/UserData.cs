using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class UserData
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public List<string> Roles { get; set; }
        public bool IsAdminUser { get; set; }
    }
}
