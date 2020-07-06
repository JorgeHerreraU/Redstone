using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Users : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordExpires { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
