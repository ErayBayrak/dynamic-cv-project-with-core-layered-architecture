using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        public string Title { get; set; }
        public string Subtitle1 { get; set; }
        public string Subtitle2 { get; set; }
        public string GPA { get; set; }
        public DateTime EducationTime { get; set; }
        public string EducationDate { get; set; }
        public bool EducationStatus { get; set; }
    }
}
