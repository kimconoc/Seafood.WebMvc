using Domain.Models.BaseModel;
using System;
using System.Security.Claims;

namespace Domain.Models.ResponseModel
{
    public class User : VBaseModel
    {
        public static ClaimsIdentity Identity { get; internal set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string DisplayName { get; set; }
        public string Avarta { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Roles { get; set; }
        public bool IsAdminUser { get; set; }
        public bool IsLocked { get; set; } = false;
        public string Session { get; set; }
        public string SessionId { get; set; }
    }
}
