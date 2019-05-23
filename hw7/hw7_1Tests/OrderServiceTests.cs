using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {

            Good good1 = new Good("good1", 1);
            Good good2 = new Good("good2", 2);
            Good good3 = new Good("good3", 3);

            Guest user1 = new Guest("user1");

            Order order1 = new Order(user1);

            OrderService service = new OrderService();

            order1.AddItem(good1, "comment1", 1);
            order1.AddItem(good2, "comment2", 2);

            service.AddOrder(order1);

            bool flag = true;
            if (!service.orderDatabase[0].Buyer.Equals(user1))
                flag = false;
            if (service.orderDatabase[0].Price != 5)
                flag = false;
            if (service.orderDatabase[0].Id != 300001)
                flag = false;
            if (service.orderDatabase[0].orderitems[0].Detail != "comment1")
                flag = false;
            if (!(service.orderDatabase[0].orderitems[0].Good.Equals(good1)))
                flag = false;
            if (service.orderDatabase[0].orderitems[0].number != 1)
                flag = false;
            if (service.orderDatabase[0].orderitems[1].Detail != "comment2")
                flag = false;
            if (!(service.orderDatabase[0].orderitems[1].Good.Equals(good2)))
                flag = false;
            if (service.orderDatabase[0].orderitems[1].number != 2)
                flag = false;

            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void DeleteOrderByIdTest()
        {
            Good apple = new Good("Apple", 1);
            Good banana = new Good("Banana", 2);
            Good catFood = new Good("Cat Food", 3);

            Guest aaron = new Guest("Aaron");
            Guest billy = new Guest("Billy");
            Guest catherine = new Guest("Catherine");

            Order order1 = new Order(aaron);
            Order order2 = new Order(billy);
            Order order3 = new Order(catherine);

            order1.AddItem(apple, "None", 1);
            order1.AddItem(banana, "fresh!", 2);
            order2.AddItem(catFood, "My cat loves it!", 3);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            service.DeleteOrderById(order1.Id);
            service.DeleteOrderById(order2.Id);
            Assert.IsFalse(service.orderDatabase.Contains(order1) || service.orderDatabase.Contains(order2));

        }

        [TestMethod()]
        public void SearchOrderByIdTest()
        {
            Good apple = new Good("Apple", 1);
            Good banana = new Good("Banana", 2);
            Good catFood = new Good("Cat Food", 3);

            Guest aaron = new Guest("Aaron");
            Guest billy = new Guest("Billy");
            Guest catherine = new Guest("Catherine");

            Order order1 = new Order(aaron);
            Order order2 = new Order(billy);
            Order order3 = new Order(catherine);

            order1.AddItem(apple, "None", 1);
            order1.AddItem(banana, "fresh!", 2);
            order2.AddItem(catFood, "My cat loves it!", 3);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            Assert.IsTrue(service.SearchOrderById(300001));
        }

        [TestMethod()]
        public void SearchOrderByUsernameTest()
        {
            Good apple = new Good("Apple", 1);
            Good banana = new Good("Banana", 2);
            Good catFood = new Good("Cat Food", 3);

            Guest aaron = new Guest("Aaron");
            Guest billy = new Guest("Billy");
            Guest catherine = new Guest("Catherine");

            Order order1 = new Order(aaron);
            Order order2 = new Order(billy);
            Order order3 = new Order(catherine);

            order1.AddItem(apple, "None", 1);
            order1.AddItem(banana, "fresh!", 2);
            order2.AddItem(catFood, "My cat loves it!", 3);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            Assert.IsTrue(service.SearchOrderByUsername("Aaron"));
        }

    }
}
