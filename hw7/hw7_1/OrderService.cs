using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;



namespace hw7
{

    public class OrderService
    {
        public List<Order> orderDatabase;
        public OrderService()
        {
            orderDatabase = new List<Order>();
        }

        public void AddOrder(Order neworder)
        {
            foreach (Order order in orderDatabase)
            {
                if (order.Equals(neworder))
                    throw new Exception("The order from the same person is already existed in the order database!");
            }
            this.orderDatabase.Add(neworder);
        }

        public bool DeleteOrderById(uint id)
        {
            for (int i = 0; i < orderDatabase.Count(); i++)
            {
                if (orderDatabase[i].Id == id)
                {
                    orderDatabase.RemoveAt(i);
                    Console.WriteLine("Order is successfully removed!");
                    return true;
                }
            }
            throw new Exception("The order is not existed");

        }

        public bool SearchOrderById(uint id)
        {
            // 使用foreach进行查找
            // foreach (Order order in orderDatabase)
            // {
            //     if (order.Id == id)
            //     {
            //         Console.WriteLine(order);
            //         return true;
            //     }
            // }
            // throw new Exception("The order is not existed");

            var searchResult = from order in this.orderDatabase where order.Id == id select order;
            if (searchResult.Count() == 0)
            {
                throw new Exception("The order is not existed");
            }
            else
            {
                foreach (Order order in searchResult)
                {
                    Console.WriteLine(order);
                }
                return true;
            }

        }

        public bool SearchOrderByUsername(string username)
        {
            // 使用foreach进行查找
            // foreach (Order order in orderDatabase)
            // {
            //     if (order.Buyer.Name == username)
            //     {
            //         Console.WriteLine(order);
            //         return true;
            //     }
            // }
            // throw new Exception("The order is not existed");

            var searchResult = this.orderDatabase.Where(order => order.Buyer.Name.Equals(username));
            if (searchResult.Count() == 0)
            {
                throw new Exception("The order is not existed");
            }
            else
            {
                foreach (Order order in searchResult)
                {
                    Console.WriteLine(order);
                }
                return true;
            }
        }


        public void Display()
        {
            foreach (Order order in this.orderDatabase)
            {
                Console.WriteLine(order);
            }
        }

        public void Export(String filename)
        {

            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            xmlSerializer.Serialize(fs, this.orderDatabase);
            fs.Close();
        }

        public void Import(String filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            this.orderDatabase = (List<Order>)xmlSerializer.Deserialize(fs);
            fs.Close();
        }

    }
}