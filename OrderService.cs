using System.Collections.Generic;
using System;

namespace hw5
{
    class OrderService
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
            for (int i = 0; i < orderDatabase.Count; i++)
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
            foreach (Order order in orderDatabase)
            {
                if (order.Id == id)
                {
                    Console.WriteLine(order);
                    return true;
                }
            }
            throw new Exception("The order is not existed");
        }

        public bool SearchOrderByUsername(string username)
        {
            foreach (Order order in orderDatabase)
            {
                if (order.Buyer.Name == username)
                {
                    Console.WriteLine(order);
                    return true;
                }
            }
            throw new Exception("The order is not existed");
        }


        public void Display()
        {
            foreach (Order order in this.orderDatabase)
            {
                Console.WriteLine(order);
            }
        }

    }
}