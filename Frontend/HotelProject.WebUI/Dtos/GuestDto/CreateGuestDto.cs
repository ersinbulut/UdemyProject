using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.GuestDto
{
    public class CreateGuestDto
    {
        [Display(Name = "Misafir Adı")]
        public string Name { get; set; }
        
        [Display(Name = "Misafir Soyadı")]
        public string Surname { get; set; }
        
        [Display(Name = "Misafir Şehir")]
        public string City { get; set; }
    }
}
