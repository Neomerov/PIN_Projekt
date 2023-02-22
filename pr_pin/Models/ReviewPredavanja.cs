using System.ComponentModel.DataAnnotations;

namespace pr_pin.Models
{
    public class ReviewPredavanja
    {
        [Display(Name = "Ime Predavača")]
        public string ime { get; set; }

        [Display(Name = "Foto predavača")]
        public string? profilnaSlika { get; set; }

        [Display(Name = "Tema predavanja")]
        public string NaslovTeme { get; set; }

        [Display(Name = "Datum predavanja")]
        [DataType(DataType.Date)]
        public DateTime datumPredavanja { get; set; }
    }
}
