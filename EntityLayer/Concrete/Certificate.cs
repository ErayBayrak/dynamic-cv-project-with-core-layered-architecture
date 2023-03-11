using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Certificate
    {
        [Key]
        public int CertificateID { get; set; }
        public string Description { get; set; }
        public DateTime CertificateDate { get; set; }
        public bool CertificateStatus { get; set; }
    }
}
