using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public String Name { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public String Topic { get; set; }
        [StringLength(300, ErrorMessage = "Description Max Length is 300 characters")]
        public String Message { get; set; }
    }
}
