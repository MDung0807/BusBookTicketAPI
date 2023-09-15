﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookTicket.Models.Entity
{
    public class Review
    {
        #region -- Properties --
        public int reviewID { get; set; }
        public string? reviews { get; set; }
        public DateTime dateCreate { get; set; }
        public DateTime dateUpdate { get; set; }
        public string? image { get; set; }
        public int rate { get; set; }
        #endregion -- Properties --

        #region -- Relationship --
        public Customer? customer { get; set; }
        public Company company { get; set; }
        #endregion -- Relationship --

    }
}
