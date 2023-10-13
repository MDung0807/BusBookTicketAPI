﻿namespace BusBookTicket.Common.Models.Entity
{
    public class SeatItem
    {
        #region -- Properties --
        public int seatID { get; set; }
        public int seatNumber { get; set; }
        public int status { get; set; }
        #endregion -- Properties --

        #region -- Relationship --
        public BusType busType { get; set; }
        public TicketItem? ticketItem { get; set; }
        #endregion -- Relationship --



    }
}