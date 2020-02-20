using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineInventoryAndBillingSystem.Common
{
    [MetadataType(typeof(Validation))]
    //public partial class User
    //{
    //    public string ConfirmPassword { get; set; }
    //}
    public class Validation
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
        public string CustomerSecondName { get; set; }
        [Display(Name = "State")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "State Required")]
        public string State { get; set; }
        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City Required")]
        public string City { get; set; }
        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Display(Name = "Cell Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Cell Number Required")]
        public string CellNumber { get; set; }
        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of Birth Required")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Display(Name = "Registration Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Registration Number is Required")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "PinCode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PinCode Required")]
        [DataType(DataType.PostalCode)]
        public string PinCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Min 8 digits required")]
        [MaxLength(15, ErrorMessage = "Max 15 Digits allowed")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Dont Match")]
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string gender { get; set; }
        public string Search { get; set; }
        public int UserId { get; set; }
    }
}
