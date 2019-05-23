using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OrderServiceLib
{

    public class OrderService
    {
        public List<Order> orderDatabase;
        public OrderService()
        {
            orderDatabase = new List<Order>();
        }

        public bool AddOrder(Order neworder)
        {
            foreach (Order order in orderDatabase)
            {
                if (order.Equals(neworder))
                    return false;
            }
            this.orderDatabase.Add(neworder);
            return true;
        }

        public bool DeleteOrderById(uint id)
        {
            for (int i = 0; i < orderDatabase.Count(); i++)
            {
                if (orderDatabase[i].Id == id)
                {
                    orderDatabase.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        public List<Order> SearchOrderById(uint id)
        {
            var searchResult = from order in this.orderDatabase where order.Id == id select order;
            List<Order> resultList = new List<Order>();
            foreach (Order order in searchResult)
            {
                resultList.Add(order);
            }
            return resultList;

        }

        public List<Order> SearchOrderByUsername(string username)
        {
            var searchResult = this.orderDatabase.Where(order => order.Buyer.Equals(username));
            List<Order> resultList = new List<Order>();
            foreach (Order order in searchResult)
            {
                resultList.Add(order);
            }
            return resultList;
        }


        public void Display()
        {
            foreach (Order order in this.orderDatabase)
            {
                Console.WriteLine(order);
            }
        }
        //TODO: 使用using
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
