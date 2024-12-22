using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class Branslar
    {
        [Key]
        public int BransId { get; set; }
        public string BransAd { get; set; }

        public ICollection<Egitmenler> Egitmenlers { get; set; }
    }
}