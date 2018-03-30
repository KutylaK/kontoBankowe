using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bank.Models
{
    public class Przelew
    {
        [Key]
        public string Nadawca { get; set; }
        public string Odiorca { get; set; }
        public int Stawka { get; set; }
    }

    public class PrzelewDBContext : DbContext
    {
        public DbSet<Przelew> Przelewy { get; set; }
    }
}
