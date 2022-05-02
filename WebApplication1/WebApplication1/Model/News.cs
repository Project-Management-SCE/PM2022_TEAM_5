using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class News
    {

        [Key]
        [Column("id")]
        public int id { get; set; }
        public string text { get; set; }
    }


}
