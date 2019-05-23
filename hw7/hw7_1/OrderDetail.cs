using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace hw7
{
    [Serializable]
    public class OrderItem
    {
        public Good Good { get; set; }
        public string Detail { get; set; }
        public uint number { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(Good good, string Detail, uint number)
        {
            this.Good = good;
            this.Detail = Detail;
            this.number = number;
        }



        public override string ToString()
        {
            return $"{Good.Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderItem)
            {
                OrderItem orderItem = (OrderItem)obj;
                return this.Good.Equals(orderItem.Good);
            }
            return false;
        }

    }
}