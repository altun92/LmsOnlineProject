using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LmsOnlineProject.Models
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Branslar> Branslars { get; set; }
        public DbSet<Egitmenler> Egitmenlers { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Kurslar> Kurslars { get; set; }
        public DbSet<Ogrenciler> Ogrencilers { get; set; }

    }
}