using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class Ogrenciler
    {
        [Key]
        public int OgrenciId { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string OgrenciEmail { get; set; }
        public char OgrenciTel { get; set; }
        public string OgrenciImage { get; set; }

        public int KursId { get; set; }
        public virtual Kurslar Kurslar { get; set; }
    }
}