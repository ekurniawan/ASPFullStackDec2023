using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.ViewModels
{
    public class EmployeeWithProductViewModel
    {
        public List<Employee> employees { get; set; }
        public List<Product> products { get; set; }
    }
}