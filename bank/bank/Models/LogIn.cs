using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bank.Models
{
    public class LogIn
    {
        [Key]
        public string Login { get; set; }
        public string Paswrd { get; set; }
        public int Saldo { get; set; }
    }

    public class Przelew
    {
        [Key]
        public string Nadawca { get; set; }
        public string Odiorca { get; set; }
        public int Stawka { get; set; }
    }


    public class LogInDBContext : DbContext
    {
        public DbSet<LogIn> LogIns { get; set; }
        public DbSet<Przelew> Przelewy { get; set; }
    }
}