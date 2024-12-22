using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class Kategoriler
    {
        [Key]
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }

        public ICollection<Kurslar> Kurslars { get; set; }
    }
}