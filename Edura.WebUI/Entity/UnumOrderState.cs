using System.ComponentModel.DataAnnotations;

namespace Edura.WebUI.Entity
{
    public enum UnumOrderState
    {
        [Display(Name ="Onay Bekleniyor")]
        Waiting,
        [Display(Name = "Sipariş Tamalandı")]
        Completed
    }
}