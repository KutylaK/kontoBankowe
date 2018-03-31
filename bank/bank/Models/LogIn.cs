using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bank.Models
{
    public class LogIn
    {
        [Key]
        public Guid OId { get; set; }
        [Index(IsUnique = true)]
        [StringLength(30)]
        public string Login { get; set; }
        public string Paswrd { get; set; }
        public int Saldo { get; set; }

        public LogIn()
        {
            OId = Guid.NewGuid();
        }

    }

    public class Przelew
    {
        [Key]
        public Guid OId { get; set; }
        public string Nadawca { get; set; }
        public string Odbiorca { get; set; }
        public int Stawka { get; set; }

        public Przelew()
        {
            OId = Guid.NewGuid();
        }

    }


    public class LogInDBContext : DbContext
    {
        public DbSet<LogIn> LogIns { get; set; }
        public DbSet<Przelew> Przelewy { get; set; }
    }
}