using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace pr_pin.Models
{
    public class SpeakerViewModel
    {
       
        public string ime { get; set; }

        public string tema { get; set; }

        public string spol { get; set; }

        public IFormFile? profilnaSlika { get; set; }

        
    }
}
