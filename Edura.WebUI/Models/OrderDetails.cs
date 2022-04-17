using System.ComponentModel.DataAnnotations;

namespace Edura.WebUI.Models
{
    public class OrderDetails
    {
        [Required]
        public string AdresTanimi { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string Semt { get; set; }
        [Required]
        public string Telefon { get; set; }
    }
}