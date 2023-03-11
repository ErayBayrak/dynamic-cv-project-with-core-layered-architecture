using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SocialMedia
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool SocialMediaStatus { get; set; }
    }
}
