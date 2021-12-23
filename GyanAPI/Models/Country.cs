using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Models
{
    public class Country
    {
        [Key]
        public int Cid { get; set; }
        public string CName { get; set; }
    }
}
