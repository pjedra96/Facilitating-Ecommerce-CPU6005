using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WesthoughtonWorldOfWicker.Models
{
    public class Info
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public String Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public String City { get; set; }
        [Required(ErrorMessage = "County is required")]
        [StringLength(40)]
        public String County { get; set; }
        [Required(ErrorMessage = "Postcode is required")]
        [DisplayName("Postcode")]
        [StringLength(10)]
        public String Postcode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public String Country { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(24)]
        public String Phone { get; set; }
    }
}
