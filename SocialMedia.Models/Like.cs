using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class Like : BaseModel
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
