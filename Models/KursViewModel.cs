using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class KursViewModel
    {
        public IEnumerable<Kurslar> kurslars { get; set; }
        public IEnumerable<Egitmenler> egitmenlers { get; set; }
        public IEnumerable<Kategoriler> kategorilers { get; set; }
    }
}