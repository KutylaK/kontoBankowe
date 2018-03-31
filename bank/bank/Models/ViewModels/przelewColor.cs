using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bank.Models.ViewModels
{
    public class PrzelewColor
    {
        public Przelew przelew { get; set; }
        public string kolor { get; set; }

        public PrzelewColor(Przelew p, string k)
        {
            przelew = p;
            kolor = k;
        }
    }
}