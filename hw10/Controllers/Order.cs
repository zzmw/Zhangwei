using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace order
{

    public class Order : IComparable<Order>
    {

        public uint Id { get; set; }
        public string Buyer { get; set; }
        public string Good { get; set; }
        public double Price { get; set; }


        public Order()
        {
            
        }

        public Order(uint id, string guest,string good,double price)
        {
            this.Buyer = guest;
            this.Id = id;
            this.Good=good;
            this.Price=price;
        }



        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                Order ord = (Order)obj;
                return ord.Id == this.Id;
            }
            return false;
        }

        public override string ToString()
        {
            return $"OrderID: {Id}  Buyer: {Buyer}  Good: {Good}  Price: {Price}";
        }

        public int CompareTo(Order obj)
        {
            return (int)(this.Id - obj.Id);
        }
    }


}
