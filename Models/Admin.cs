using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class Admin
    {
        [Key]
        public int KullaniciId { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciParola { get; set; }
    }
}