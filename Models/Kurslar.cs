using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class Kurslar
    {
        [Key]
        public int KursId { get; set; }
        public string KursAd { get; set; }
        public string KursAciklama { get; set; }
        public string KursImage { get; set; }
        public DateTime KursBaslangicTarih { get; set; }
        public DateTime KursBitisTarih { get; set; }
        public double KursFiyat { get; set; }
        public int KursKapasite { get; set; }

        public int EgitmenId { get; set; }
        public virtual Egitmenler Egitmenler { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }

        // Bir tabloda birden fazla olacak nesneyi ICollection olarak tutuyoruz.
        public ICollection<Ogrenciler> Ogrencilers { get; set; }
    }
}