using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    [Serializable]
    public class Order : IComparable<Order>
    {
        //当前最大的id号，订单从300001开始编号

        private static uint idGenerator = 300000;

        public uint Id { get; set; }
        public Guest Buyer { get; set; }
        public List<OrderItem> orderitems;
        public double Price;

        public Order()
        {

        }

        public Order(Guest guest)
        {
            this.Buyer = guest;
            idGenerator++;
            this.Id = idGenerator;
            orderitems = new List<OrderItem>();
            Price = 0;
        }
        //加入的orderitem的名字不能一样也就是good不能是一样的
        public void AddItem(Good good, string detail, uint number)
        {
            OrderItem newitem = new OrderItem(good, detail, number);
            foreach (OrderItem orderitem in orderitems)
            {
                if (orderitem.Equals(newitem))
                    throw new Exception("This item is already existed in the order!");
            }
            orderitems.Add(newitem);
            UpdatePrice();
        }

        public void UpdatePrice()
        {
            Price = 0;
            foreach (OrderItem item in orderitems)
            {
                Price += item.Good.Price * item.number;
            }
        }

        //order的buyer不能是一样的
        public override bool Equals(object obj)
        {
            bool flag = true;
            if (!(obj is Order))
            {
                flag = false;
            }
            else
            {
                Order order = (Order)obj;
                if (!(this.Buyer.Equals(order.Buyer)))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public override string ToString()
        {
            string items = "";
            foreach (OrderItem item in orderitems)
            {
                items += item.ToString() + " ";
            }
            if (items == "")
            {
                items = "NONE";
            }
            return $"OrderID: {Id}  Buyer: {Buyer}  Item: {items}  Price: {Price}";
        }

        public int CompareTo(Order obj)
        {
            return (int)(this.Id - obj.Id);
        }

    }
}
