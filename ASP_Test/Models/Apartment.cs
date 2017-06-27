using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Test.Models
{
    public class Apartment
    {
        public long ID { get; private set; }
        public string Address { get; set; }
        public int RoomsNumber { get; set; }
        public int RentPrice { get; set; }

        public Apartment()
        {

        }

        public Apartment(long id, string address, int rooms, int price)
        {
            ID = id;
            Address = address;
            RoomsNumber = rooms;
            RentPrice = price;
        }



    }
}