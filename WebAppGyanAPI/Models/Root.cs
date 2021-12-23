using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGyanAPI.Models
{
    public class Root
    {
        public string status { get; set; }
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }
      
    }

}
