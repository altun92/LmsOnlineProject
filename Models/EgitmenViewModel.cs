using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LmsOnlineProject.Models
{
    public class EgitmenViewModel
    {
        public IEnumerable<Egitmenler> Egitmenler { get; set; }
        public IEnumerable<Branslar> Branslar { get; set; }
    }
}