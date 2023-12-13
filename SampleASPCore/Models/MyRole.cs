using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models
{
    public class MyRole
    {
        public string RoleName { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
    }
}