using System;
using System.ComponentModel.DataAnnotations;

namespace pr_pin.Models
{
    public class Speaker

    {
       
        public int SpeakerId { get; set; }

        [Display(Name = "Ime i prezime predavača")]
        public string Ime { get; set; }

        [Display(Name = "Stručno područje predavača")]
        public string Tema { get; set; }

        [Display(Name = "Foto predavača")]
        public string Slika { get; set; }

        public string Spol { get; set; }

        public virtual ICollection<Predavanja> Predavanjaa { get; } = new List<Predavanja>();
    }
}
