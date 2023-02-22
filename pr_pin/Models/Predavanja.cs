using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pr_pin.Models
{
    public class Predavanja
    {
        

        
        public int PredavanjaId { get; set; }

        [Display(Name = "Naslov predavanja")]
        public string NaslovTeme { get; set; }

        [Display(Name = "Datum početka predavanja")]
        [DataType(DataType.Date)]
        public DateTime datumPredavanja { get; set; }

        public int? SpeakerId { get; set; }

        [Display(Name = "Ime predavača")]
        public Speaker? Speaker { get; set; }

    }
}
