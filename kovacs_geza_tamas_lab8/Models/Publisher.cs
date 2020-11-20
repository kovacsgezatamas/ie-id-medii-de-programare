﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kovacs_geza_tamas_lab8.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public virtual ICollection<Book> Books { get; set; } //navigation property
    }
}
