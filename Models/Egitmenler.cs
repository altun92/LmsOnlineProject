using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class Egitmenler
    {
        [Key]
        public int EgitmenId { get; set; }
        public string EgitmenAd { get; set; }
        public string EgitmenSoyad { get; set; }
        public string EgitmenEmail { get; set; }
        public char EgitmenTel { get; set; }
        public string EgitmenImage { get; set; }

        public int BransId { get; set; }
        public virtual Branslar Branslar { get; set; }

        public ICollection<Kurslar> Kurslars { get; set; }
    }
}