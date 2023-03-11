using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
    }
}
