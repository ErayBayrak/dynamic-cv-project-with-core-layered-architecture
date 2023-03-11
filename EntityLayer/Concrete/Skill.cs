using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        public string SkillDescription { get; set; }
        public string LanguagesAndTools { get; set; }
        public byte Rate { get; set; }
        public bool RateStatus { get; set; }
    }
}
