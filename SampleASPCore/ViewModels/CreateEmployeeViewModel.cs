using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "Fullname tidak boleh kosong")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        /*[RegularExpression(@"^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$",
        ErrorMessage = "Format Url tidak sesuai")]
        public string Url { get; set; }*/
    }
}