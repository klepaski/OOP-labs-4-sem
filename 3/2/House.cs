﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [Serializable]
    public class House
    {
        public DateTime Date_built {get;set;}
        public string Material { get; set; }
        public int Floor { get; set; }
        public decimal Rooms { get; set; }
        public int Meter { get; set; }
        public string Result { get; set; }
        public Address Address { get; set; }
        public int Price { get; set; }
    }
}
