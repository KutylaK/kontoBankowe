﻿using System;
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
    }

    public class LogInDBContext : DbContext
    {
        public DbSet<LogIn> LogIns { get; set; }
    }
}