using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SocialMedia.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Post> Posts { get; set; }
        public ICollection<Follow> Follows { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
