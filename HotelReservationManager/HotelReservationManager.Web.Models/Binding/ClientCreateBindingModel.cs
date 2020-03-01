using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.Web.Models.Binding
{
    public class ClientCreateBindingModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [MaxLength(10, ErrorMessage = "Phonenumber must be 10 digits or less"), MinLength(3)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public bool isAdult { get; set; }

        
    }
}
