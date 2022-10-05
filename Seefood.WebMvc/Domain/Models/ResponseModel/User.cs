using Domain.Models.BaseModel;
using System.Security.Claims;

namespace Domain.Models.ResponseModel
{
    public class User : VBaseModel
    {
        public static ClaimsIdentity Identity { get; internal set; }
        public string Username { get; set; }
        public string Roles { get; set; }
        public string Fullname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DisplayName { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public bool IsAdminUser { get; set; }
        public bool IsLocked { get; set; } = false;
    }
}
