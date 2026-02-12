using Microsoft.AspNetCore.Identity;

namespace WebApp1.Models
{
    public class AppliactionUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
