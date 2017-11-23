using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ticketshop.Models;    
public class TheaterViewModel {
        //[Key]
        public int TheaterID { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public int Available_seats { get; set; }
    }